using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonAppointment
{
    public partial class Booking : System.Web.UI.Page
    {
        private string connectionString = "Data Source=Mehak\\SQLEXPRESS01;Initial Catalog=salon;Integrated Security=True;Encrypt=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                    if (Session["userId"] == null)
                    {
                        // Redirect to login page or display an error message
                        Response.Redirect("Login.aspx");
                    }
                   
                 else { DateTime today = DateTime.Today;
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


                        PopulateSlots(); }
                
            } }


        private void PopulateSlots()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT slot_id, slot_type, start_time FROM slots WHERE s_date = @CurrentDate and is_booked = 0 ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    DateTime currentDate = DateTime.ParseExact(CurrentDateLabel.Text.Split(',')[1].Trim(), "dd MMMM", System.Globalization.CultureInfo.InvariantCulture);
                    cmd.Parameters.AddWithValue("@CurrentDate", currentDate);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            SlotsDataList.DataSource = dt;
            SlotsDataList.DataBind();
        }

        protected void NextDateButton_Click(object sender, EventArgs e)
        {
            DateTime currentSelectedDate = DateTime.ParseExact(CurrentDateLabel.Text.Split(',')[1].Trim(), "dd MMMM", System.Globalization.CultureInfo.InvariantCulture);
            DateTime nextDate = currentSelectedDate.AddDays(1);

            while (nextDate.DayOfWeek == DayOfWeek.Saturday || nextDate.DayOfWeek == DayOfWeek.Sunday)
            {
                nextDate = nextDate.AddDays(1); // Skip weekends
            }

            CurrentDateLabel.Text = $"{nextDate.ToString("dddd, dd MMMM")}";
            PopulateSlots();
        }



        protected void BookNowButton_Click(object sender, EventArgs e)
        {
            int slotId = int.Parse((sender as Button).CommandArgument);
            int userId = (int)Session["userId"];

            try
            {
                Salon book = new Salon();
                book.BookAppointment(userId, slotId);

                Response.Write("Successfully booked!");
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
           
        }
    }


    
}