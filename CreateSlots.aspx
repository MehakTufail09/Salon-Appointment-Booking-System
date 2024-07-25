<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateSlots.aspx.cs" Inherits="SalonAppointment.CreateSlots" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Slots</title>
    
      <style>
          body{
           background-image:url('/images/salon.jpg');
           margin: 0;
           padding: 0;
           background-size: cover;
           background-repeat: no-repeat;
           font-family: sans-serif;
           color:white;
           font-weight:bold;
          }
        
          .createSlots{
              position:absolute;
              top: 20%;
              left:35%;
              transform: translate(-50%,_50%);
              width: 400px;
              height: 390px;
              padding: 80px 40px;
              box-sizing: border-box;
              background: rgb(0,0,0,0.8);
          }
          #lblservices{
                color: #ffff; 
                font-size: 16px;
                font-weight: bold;
          }
          .btnnextdate, .btncreateslot{
               border: none;
               outline: none;
               height: 40px;
               font-size: 16px;
               padding:10px;
               padding-left:15px;
                padding-right:15px;
               background-color:darkgoldenrod;
               color: black;
               border-radius: 20px;
               cursor: pointer;
               transition: .3s ease-in-out;
          }
          .btncreateslot:hover, .btnnextdate:hover{
              background-color: black;
              color: darkgoldenrod;
          }
         
      </style>
</head>
  
<body >
    
   
        <div class="createSlots">
      <form runat="server"> 
          <h2>Create Slots</h2>
          <asp:Label ID="MondayDateLabel" runat="server" Text="Date"></asp:Label>
          
          <br />
          <br />
          <asp:Label ID="lblservices" runat="server" Text="Services"></asp:Label>
          <asp:DropDownList ID="SlotTypeDropdown" runat="server">
              <asp:ListItem Text="Bridal Makeup" Value="Bridal Makeup"></asp:ListItem>
               <asp:ListItem Text="Party Makeup" Value="Party Makeup"></asp:ListItem>
               <asp:ListItem Text="Haircut" Value="Haircut"></asp:ListItem>
               <asp:ListItem Text="Facial" Value="Facial"></asp:ListItem>
               <asp:ListItem Text="Waxing" Value="Waxing"></asp:ListItem>
              
          </asp:DropDownList>
          <br />
          <br />
         <label>Start Time</label>
          <asp:DropDownList ID="StartTimeDropdown" runat="server" OnSelectedIndexChanged="StartTimeDropdown_SelectedIndexChanged" AutoPostBack="false">
           
          </asp:DropDownList>
          <br />
          <br />
          <asp:Button Text="Next Date" runat="server" CssClass="btnnextdate" OnClick="NextDate" />
          
           <asp:Button Text="Create Slot" runat="server" CssClass="btncreateslot" OnClick="CreateSlot" />

      </form>       
        </div>
   
</body>
</html>
