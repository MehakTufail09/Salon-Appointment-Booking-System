<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="SalonAppointment.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
        <title>Admin Dashboard</title>
       <link href="stylesheet.css" rel="stylesheet" />
    </head>
<body style="background-image:url('/images/beauty.jpg')">
    <div class="admindashboard">

        <form runat="server">
            <h2>Admin Dashboard</h2>
            <asp:Button Text="Create Slots" runat="server" CssClass="btncreateslots" OnClick="CreateSlots" />
            <asp:Button Text="View Appointments" runat="server" CssClass="btnviewappointment" OnClick="ViewAppointments" />

        </form>

    </div>
</body>
</html>
