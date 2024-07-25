using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonAppointment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                email_txt.Text = string.Empty;
                pass_txt.Text = string.Empty;
            
            }
          
        }

        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            string email = email_txt.Text;
            string password = pass_txt.Text;

            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                emailErrorLabel.Text = "*Email is required!";
                emailErrorLabel.ForeColor = System.Drawing.Color.Red;
                passwordErrorLabel.Text = "*Password is required!";
                passwordErrorLabel.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                emailErrorLabel.Text = "";
                passwordErrorLabel.Text = "";

                if (email == "admin@gmail.com" && password == "admin")
                {
                    Response.Redirect("AdminDashboard.aspx");
                }

                else
                {
                    signupToLogin sign = new signupToLogin();
                    int userId = sign.signin(email, password);

                    if (userId > 0)
                    {
                        Session["userId"] = userId;

                        Response.Write("Sign In successful!");
                        Response.Redirect("UserDashboard.aspx");
                    }
                    else
                    {
                        Response.Write("Wrong email or password");
                    }

                }
            }


        }
    }
    }