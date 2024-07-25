<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="SalonAppointment.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
       <form id="form1" runat="server">
        <div class="appointmentBox">
           <h2>Book Now!</h2>

 <div class="date-display">
     <asp:Label ID="CurrentDateLabel" runat="server" CssClass="date-label"></asp:Label>
     <asp:Button ID="NextDateButton" Text="Next Date" CssClass="btnforget" runat="server" OnClick="NextDateButton_Click"  />
 </div>

 <div class="slots-container">
    <asp:DataList ID="SlotsDataList" runat="server">
    <ItemTemplate>
        <div class="slot-box">
            <p><strong>Slot Type:</strong> <%# Eval("slot_type") %></p>
            <p><strong>Time:</strong> <%# Eval("start_time") %></p>
            <asp:Button ID="BookNowButton" Text="Book Now" CssClass="btnbook" runat="server" CommandName="BookSlot" CommandArgument='<%# Eval("slot_id") %>' OnClick="BookNowButton_Click"/>
        </div>
    </ItemTemplate>
</asp:DataList>
     
          
        </div>
    </form>
</body>
</html>
