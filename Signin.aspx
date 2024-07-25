<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="SalonAppointment.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Signin</title>
     <link href="stylesheet.css" rel="stylesheet" />
</head>
<body>
   
   <div class="loginpage">
       <img src="profile pic.jpg" alt="iconimg" class="user" />
       <h2 class="logintext">Login Here</h2>
        <form runat="server">
     <asp:Label  Text="Email" CssClass="lblemail" runat="server"></asp:Label>
     <asp:TextBox ID="email_txt" CssClass="txtemail" runat="server" placeholder="Email"></asp:TextBox>
      <asp:Label Text=" " ID="emailErrorLabel" runat="server"></asp:Label>
            <br />
       <asp:Label Text="Password" CssClass="lblpassword" runat="server" ></asp:Label>
            <br />
       <asp:Label Text=" " ID="passwordErrorLabel" runat="server"></asp:Label>
       <asp:TextBox ID="pass_txt" CssClass="txtpassword" runat="server" TextMode="Password" placeholder="********"></asp:TextBox>
     <asp:Button Text="Sign in" runat="server" CssClass="btnsignin" OnClick="Unnamed5_Click"/>
   
 </form>
    </div>
   
</body>
</html>
