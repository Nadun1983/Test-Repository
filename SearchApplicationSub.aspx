<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchApplicationSub.aspx.cs" Inherits="SearchApplicationSub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <img alt="zdfghzfxg" longdesc="gf" src="images/banner.jpg" 
                    style="width: 900px; height: 100px" /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="DgvCustDetails" runat="server">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="dgvLoanDetails" runat="server" Width="753px" 
                    AllowPaging="True" PageSize="20">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Total Approved Amount (Rs)"></asp:Label>
&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lbltotaprvdamt" runat="server" Font-Bold="True" 
                                Font-Size="Medium"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Total loan Instalment (Rs)"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblTotLoanInstlment" runat="server" Font-Bold="True" 
                                Font-Size="Medium"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" 
                                Text="Total Out Balance (Rs)"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblTotOutbal" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</form>
</body>
</html>
