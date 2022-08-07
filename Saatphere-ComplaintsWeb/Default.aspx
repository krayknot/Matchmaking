<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="_Default" %>
<head>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 255px;
        }
    </style>
</head>

<form id="form1" runat="server">
<table cellpadding="0" cellspacing="0" class="style1">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            Biodata ID [Numeric id]:</td>
        <td>
            <asp:TextBox ID="txtBiodataID" runat="server" Width="139px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            Complaint Type:</td>
        <td>
            <asp:DropDownList ID="drpComplaintType" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            Complaint Details:</td>
        <td>
            <asp:TextBox ID="txtComplaintDetails" runat="server" Height="144px" 
                TextMode="MultiLine" Width="475px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                Text="Submit Complaint" />
        </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</form>

