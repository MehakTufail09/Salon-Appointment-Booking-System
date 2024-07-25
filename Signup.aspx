<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="SalonAppointment.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <link href="stylesheet.css" rel="stylesheet" />
</head>
<body style="background-image:url('/images/girl.jpg');">
    
    <div class="signuppage">
    <img src="profile pic.jpg" alt="iconimg" class="user" />
    <h2 class="signuptext">Sign Up Here</h2>
    <form runat="server" >

    <!-- Full name -->
    <asp:label Text="Full Name" CssClass="lblname" runat="server"></asp:label>
     <asp:Label ID="fullNameErrorLabel" runat="server" ForeColor="Red"></asp:Label>
       <asp:TextBox ID="full_name_txt" CssClass="txtname" runat="server" placeholder="Full Name "></asp:TextBox>
      
    <!-- phone -->
        <asp:Label Text="Phone" CssClass="lblph" runat="server" ></asp:Label>
         <asp:Label ID="phoneErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        <asp:TextBox ID="phone_txt" CssClass="txtph" runat="server" placeholder="Phone"></asp:TextBox>
  
     <!-- Email -->
    <asp:Label  Text="Email" CssClass="lblemail" runat="server"></asp:Label>
     <asp:Label ID="emailErrorLabel" runat="server" ForeColor="Red"></asp:Label>
    <asp:TextBox iD="email_txt" CssClass="txtemail" runat="server" placeholder="Email"></asp:TextBox>
    
     <!-- password -->    
     <asp:Label  Text="Password" CssClass="lblpassword" runat="server" ></asp:Label>
     <asp:Label ID="passwordErrorLabel" runat="server" ForeColor="Red"></asp:Label>
     <asp:TextBox iD="pass_txt" CssClass="txtpassword" runat="server" TextMode="Password" placeholder="********"></asp:TextBox>
    
     <!-- Signup button -->

    <asp:Button Text="Sign Up" runat="server" CssClass="btnsignup" OnClick="Unnamed9_Click"/>
    <asp:Label Text="Already have an account?" CssClass="lblalready" runat="server"></asp:Label>
    
   <!-- Navigate to login page -->
   <asp:HyperLink ID="tologin" NavigateUrl="~/Signin.aspx" CssClass="linkbtnlogin" runat="server" Text="Login"></asp:HyperLink>
</form>
   </div>
        
   
</body>
</html>
