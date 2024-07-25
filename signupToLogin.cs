using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web;
using System.Xml.Linq;

namespace SalonAppointment
{
    public class signupToLogin
    {
        public string full_name {  get; set; }
       public  string phone { get; set; }
       public string email { get; set; }
       public string password { get; set; }
        public void Signup(string Name, string Phone, string Email, string Password )
        {
            SqlConnection con = new SqlConnection(@"Data Source=Mehak\SQLEXPRESS01;Initial Catalog=salon;Integrated Security=True;Encrypt=False");
            string query = $"insert into customers(full_name, phone,  email, password) values('{Name}', '{Phone}', '{Email}', '{Password}')";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        
        
        }

        public int signin(string Email, string Password) {
            SqlConnection con = new SqlConnection(@"Data Source=Mehak\SQLEXPRESS01;Initial Catalog=salon;Integrated Security=True;Encrypt=False");
            string query = $"SELECT cus_id FROM customers WHERE email = '{Email}' AND password = '{Password}'";

            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
          
             int userId = (int?)cmd.ExecuteScalar() ?? 0;
            con.Close();
            return userId;
           
        }
      public bool isEmailExist(string email)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Mehak\SQLEXPRESS01;Initial Catalog=salon;Integrated Security=True;Encrypt=False");
            string query = $"select count(*) from customers where email ='{email}'";
            con.Open() ;
            SqlCommand cmd = new SqlCommand(query, con);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count > 0;



        }

        public bool IsValidEmail(string email)
               {
                   // validate email format
                string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
               return System.Text.RegularExpressions.Regex.IsMatch(email, pattern);
               }

    }
}