using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonAppointment
{
    public partial class CreateSlots : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime today = DateTime.Today;

                // If today is Saturday or Sunday, get the date of next Monday
                if (today.DayOfWeek == DayOfWeek.Saturday)
                {
                    today = today.AddDays(2); // Move to Monday
                }
                else if (today.DayOfWeek == DayOfWeek.Sunday)
                {
                    today = today.AddDays(1); // Move to Monday
                }

                // Display today's date or next Monday's date
                MondayDateLabel.Text = today.ToString("dddd, dd MMMM");


                PopulateStartTime();
            }
        }

        protected void PopulateStartTime()
        {
            StartTimeDropdown.Items.Clear();       // this will Populate start time dropdown based on selected slot type


            for (int i = 8; i < 20; i++)
            {
                string startTime = $"{i}:00AM";
                string endTime = $"{i + 1}:00AM";

                if (i >= 12) // Convert to PM after 12PM
                {
                    startTime = $"{i - 12}:00PM";
                    endTime = $"{i - 11}:00PM";
                }

                if (i == 11) // Special case for 11:00AM-12:00PM
                {
                    endTime = $"{i + 1}:00PM";
                }
                else if (i == 19) // Special case for 7:00PM-8:00PM
                {
                    endTime = "8:00PM";
                }

                StartTimeDropdown.Items.Add(new ListItem($"{startTime}-{endTime}", $"{startTime}-{endTime}"));
            }
        }
        protected void StartTimeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Extract start time from selected value
            string selectedValue = StartTimeDropdown.SelectedValue;
            string startTimeStr = selectedValue.Split('-')[0].Trim();

            // Parse start time to DateTime
            DateTime startTime;
            if (!DateTime.TryParseExact(startTimeStr, "h:mmtt", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out startTime))
            {
                Response.Write("Invalid start time.");
                return;
            }

            
            DateTime incrementedTime = startTime.AddHours(1);

          
            string newTimeRange = $"{startTime.ToString("h:mmtt")}-{incrementedTime.ToString("h:mmtt")}";

          
            bool timeRangeExists = false;
            foreach (ListItem item in StartTimeDropdown.Items)
            {
                if (item.Value == newTimeRange)
                {
                    timeRangeExists = true;
                    break;
                }
            }

            // If new time range doesn't exist, add it to dropdown items
            if (!timeRangeExists)
            {
                StartTimeDropdown.Items.Add(new ListItem(newTimeRange, newTimeRange));
            }

            // Set new selected value
            StartTimeDropdown.SelectedValue = newTimeRange;
        }

        protected void NextDate(object sender, EventArgs e)
        {
            DateTime currentMondayDate = DateTime.Parse(MondayDateLabel.Text.Split(',')[1].Trim());
            DateTime nextDate = currentMondayDate.AddDays(1); // Start from the next day after current Monday

            while (nextDate.DayOfWeek == DayOfWeek.Saturday || nextDate.DayOfWeek == DayOfWeek.Sunday)
            {
                nextDate = nextDate.AddDays(1); // Skip weekends
            }

            MondayDateLabel.Text = $"{nextDate.ToString("dddd, dd MMMM")}";
        }

        protected void CreateSlot(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now.Date;
          
            DateTime selectedDate = DateTime.Parse(MondayDateLabel.Text.Split(',')[1].Trim());
            string selectedTimeRange = StartTimeDropdown.SelectedValue;
            string selectedSlotType = SlotTypeDropdown.SelectedValue;

            try
            {
                Salon salon = new Salon();
                salon.CreateSlot(selectedDate, selectedTimeRange.Split('-')[0].Trim(), selectedSlotType);


                Response.Write("Slot created successfully!");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)  // SQL Server error number for duplicate key violation
                {
                    Response.Write("Slot already exists for this time.");
                }
                else
                {
                    Response.Write("Error: " + ex.Message);
                }
            }
        }
    }
}