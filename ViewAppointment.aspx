<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="SalonAppointment.ViewAppointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Appointments</title>
     <style>
     body {
         background-image: url('/images/book.jpg');
         margin: 0;
         padding: 0;
         background-size: cover;
         background-repeat: no-repeat;
         font-family: sans-serif;
         color: white;
         font-weight: bold;
     }

     .appointmentBox {
         position: absolute;
         top: 50%;
         left: 50%;
         transform: translate(-50%,-50%);
         width: 500px;
         padding: 40px 20px;
         box-sizing: border-box;
         background: rgba(0,0,0,0.5);
         border-radius: 8px;
         border-radius: 8px;
     }

     .slot-box {
         margin-bottom: 10px;
     }

     .book-button {
         background-color: #4CAF50;
         color: white;
         padding: 10px 20px;
         border: none;
         cursor: pointer;
         border-radius: 5px;
     }

     .book-button:hover {
         background-color: #45a049;
     }
 </style>
</head>
<body>
       <form id="form1" runat="server">
           

            <div class="appointmentBox">
            <h2>All Booked Appointments Here!</h2>

      <div class="date-display">
    <asp:Label ID="CurrentDateLabel" runat="server" CssClass="date-label"></asp:Label>
    <asp:Button ID="NextDateButton" Text="Next Date" CssClass="btnforget" runat="server" OnClick="NextDateButton_Click1" />
</div>

    <div class="slots-container">
    <asp:Repeater ID="AppointmentsRepeater" runat="server">
        <ItemTemplate>
            <div class="slot-box">
                <p style="color:Black"><strong>Customer Name:</strong> <%# Eval("full_name") %> </p>
                <p><strong>Phone:</strong> <%# Eval("phone") %></p>
                <p><strong>Service:</strong> <%# Eval("slot_type") %></p>
                <p><strong>Time:</strong> <%# Eval("start_time") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
                </div>
    </form>
</body>
</html>
