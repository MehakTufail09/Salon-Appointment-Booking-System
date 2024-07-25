using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SalonAppointment
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed9_Click(object sender, EventArgs e)
        {
            string full_name = full_name_txt.Text;
            string phone = phone_txt.Text;
            string email = email_txt.Text;
            string password = pass_txt.Text;
            if (string.IsNullOrEmpty(full_name) && string.IsNullOrEmpty(phone) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                fullNameErrorLabel.Text = "*Full Name is required!";
                phoneErrorLabel.Text = "*Phone is required!";
                emailErrorLabel.Text = "*Email is required!";
                passwordErrorLabel.Text = "*Password is required!";

                return;
            }
            else
            {
                if (string.IsNullOrEmpty(full_name))
                {
                    fullNameErrorLabel.Text = "*Full Name is required!";
                    return;
                }
                else
                {
                    fullNameErrorLabel.Text = "";
                }

                if (string.IsNullOrEmpty(phone))
                {
                    phoneErrorLabel.Text = "*Phone is required!";
                    return;
                }
                else
                {
                    phoneErrorLabel.Text = "";
                }

                if (string.IsNullOrEmpty(email))
                {
                    emailErrorLabel.Text = "*Email is required!";
                    return;
                }
                else
                {
                    emailErrorLabel.Text = "";
                }

                if (string.IsNullOrEmpty(password))
                {
                    passwordErrorLabel.Text = "*Password is required!";
                    return;
                }
                else
                {
                    passwordErrorLabel.Text = "";
                }
            }
          
            signupToLogin sign = new signupToLogin();
            if (sign.isEmailExist(email))
            {
                emailErrorLabel.Text = "Email already exists!";
                return;
            }
            else
            {
                emailErrorLabel.Text = "";
            }
            if (!sign.IsValidEmail(email))
            {
                emailErrorLabel.Text = "Invalid email format!";
                return;
            }
            else
            {
                emailErrorLabel.Text = "";
            }
            if (password.Length < 8)
            {
                passwordErrorLabel.Text = "Password must be at least 8 characters!";
                return;
            }
            else
            {
                passwordErrorLabel.Text = "";
            }

            try
            {

               
                sign.Signup(full_name, phone, email, password);
                Response.Write("Successfully Signup");
             }
            catch (Exception ex) { 
            Response.Write(ex.Message);
            }
           
        }
    }
}