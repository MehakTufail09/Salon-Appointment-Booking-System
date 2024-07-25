using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalonAppointment
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateSlots(object sender, EventArgs e)
        {
            Response.Redirect("CreateSlots.aspx");
        }

        protected void ViewAppointments(object sender, EventArgs e)
        {
            Response.Redirect("ViewAppointment.aspx");
        }
    }
}