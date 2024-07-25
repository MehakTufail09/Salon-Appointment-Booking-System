using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonAppointment
{
    
    public partial class ViewAppointment : System.Web.UI.Page
    {
        private string connectionString = "Data Source=Mehak\\SQLEXPRESS01;Initial Catalog=salon;Integrated Security=True;Encrypt=False";
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
                CurrentDateLabel.Text = today.ToString("dddd, dd MMMM");

                PopulateAppointments();
            }
        }
        private void PopulateAppointments()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = @"
           SELECT a.*, c.full_name, c.phone, s.slot_type, s.start_time
           FROM appointmnet a
           INNER JOIN slots s ON a.slot_id = s.slot_id
           INNER JOIN customers c ON a.cus_id = c.cus_id
           WHERE s.s_date = @CurrentDate;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    DateTime currentDate = DateTime.ParseExact(CurrentDateLabel.Text.Split(',')[1].Trim(), "dd MMMM", System.Globalization.CultureInfo.InvariantCulture);
                    cmd.Parameters.AddWithValue("@CurrentDate", currentDate);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            AppointmentsRepeater.DataSource = dt;
            AppointmentsRepeater.DataBind();
        }
       

        protected void NextDateButton_Click1(object sender, EventArgs e)
        {
            DateTime currentMondayDate = DateTime.Parse(CurrentDateLabel.Text.Split(',')[1].Trim());
            DateTime nextDate = currentMondayDate.AddDays(1); // Start from the next day after current Monday

            while (nextDate.DayOfWeek == DayOfWeek.Saturday || nextDate.DayOfWeek == DayOfWeek.Sunday)
            {
                nextDate = nextDate.AddDays(1); // Skip weekends
            }

            CurrentDateLabel.Text = $"{nextDate.ToString("dddd, dd MMMM")}";
            PopulateAppointments();
        }
    }
}