using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SalonAppointment
{
    public class Salon
    {
        private string connectionString = "Data Source=Mehak\\SQLEXPRESS01;Initial Catalog=salon;Integrated Security=True;Encrypt=False";
        public void CreateSlot(DateTime date, string startTime, string slotType)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
             
                string query = "INSERT INTO slots (s_date, start_time, slot_type, is_booked) VALUES (@Date, @StartTime, @SlotType, 0)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@StartTime", startTime);
                    cmd.Parameters.AddWithValue("@SlotType", slotType);

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }
       
        public void BookAppointment(int userId, int slotId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Check if the slot is available
                string checkQuery = "SELECT is_booked FROM slots WHERE slot_id = @SlotId";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@SlotId", slotId);
                int isBooked = (int)checkCmd.ExecuteScalar();

                if (isBooked == 1)
                {

                    throw new Exception("Slot is already booked.");
                }

                // Update the slot to booked
                string updateQuery = "UPDATE slots SET is_booked = 1 WHERE slot_id = @SlotId";
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@SlotId", slotId);
                updateCmd.ExecuteNonQuery();

                // Insert appointment
                string insertQuery = "INSERT INTO appointmnet (cus_id, slot_id) VALUES (@UserId, @SlotId)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@UserId", userId);
                insertCmd.Parameters.AddWithValue("@SlotId", slotId);
                insertCmd.ExecuteNonQuery();

                con.Close();
            }
        }

        }
}