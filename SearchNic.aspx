<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchNic.aspx.cs" Inherits="SearchNic"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head><link rel="stylesheet" type="text/css" href="main.css" />
<title></title>
</head>
<body style="  text-align: center;">
<form id="form1" runat="server">
    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/logo.jpg" /><br />
    <br />
<table style="   
          width: 355px; border-bottom: darkgoldenrod 2px solid">
    <tr>
        <td colspan="3" style="background-color: #ffffc9; text-align: left">
            <strong>For Customer Details</strong></td>
    </tr>
    <tr>
        <td colspan="3" style="text-align: left">
        </td>
    </tr>
        <tr>
            <td style="width: 164px; background-color: #ffffc9; text-align: left">
                Customer NIC No:</td>
            <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtnicnumber" runat="server" MaxLength="10" ValidationGroup="grserch"
                        Width="141px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 164px; text-align: left">
                <asp:Button ID="btnSearch"
                            runat="server" Font-Bold="False" OnClick="btnSearch_Click"
                            Text="Search" ValidationGroup="grserch"       /></td>
            <td colspan="2" style="text-align: left">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnicnumber"
                        Display="Dynamic" ErrorMessage="Please Enter NIC Number !" Font-Bold="False"
                          Font-Strikeout="False" Height="17px" SetFocusOnError="True" ValidationGroup="grserch"
                        Width="201px"></asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtnicnumber"
                        Display="Dynamic" ErrorMessage="Required 9 integers ending with 'v' or 'x'"  
                        ValidationExpression="\d{9}[vVxX]" ValidationGroup="grserch" Width="300px"></asp:RegularExpressionValidator></td>
        </tr>
    </table>
    <br />
    </form>
    </body>
</html>

