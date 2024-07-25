<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="SalonAppointment.UserDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User dashboard</title>
   <style>
       body{
            margin: 0;
 padding: 0;
 background-image: url("/images/book.jpg");
 background-size: cover;
 background-repeat: no-repeat;
 font-family: sans-serif;
       }
       .btnbook{
            border: none;
            outline: none;
            height: 40px;
            width:250px;
            margin-left:40%;
            
            font-size: 16px;
            color: #fff;
            background-color: hotpink;
            cursor: pointer;
            border-radius: 20px;
            transition: .3s ease-in-out;
       }
       .btnbook:hover{
            background-color:deeppink;
            color: white;
       }
       h2{
           text-align:center;
           color:white;
           margin-top:23%;
          
            text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5);
           
       }
   </style>
</head>
<body style="background-image:url('/images/book.jpg')">
    <form  runat="server">
        <div class="userdashboard">
            <h2>Book Your Appointments Here</h2>
            <asp:Button Text="Book Appointment" runat="server" CssClass="btnbook" OnClick="Unnamed1_Click" Height="43px"/>
            <br />
            <br />

           
        </div>
    </form>
</body>
</html>
