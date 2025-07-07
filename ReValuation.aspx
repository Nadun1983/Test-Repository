<%@ Page Language="C#" MasterPageFile="~/loanmain.master" AutoEventWireup="true" CodeFile="ReValuation.aspx.cs" Inherits="ReValuation" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg0" runat="server" Font-Bold="True" 
                    Text="Please Enter Loan Number"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtcracno" runat="server" ontextchanged="txtappno_TextChanged" 
                    Width="158px">603080</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
                    Text="Get Application Number" Width="197px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" 
                    Text="Please Enter Aplication Number"></asp:Label>
&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                Application Number</td>
            <td colspan="2">
                <asp:TextBox ID="txtappno" runat="server" ontextchanged="txtappno_TextChanged" 
                    Width="158px">3080</asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="btnDisplay" runat="server" onclick="btnDisplay_Click" 
                    Text="Display" Width="104px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                Customer Details</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="dgvCustDetails" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                Property Details</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="dgvPropertyDetails" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                Existing Valuation Details</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="dgvExistValDetails" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lblassVal" runat="server" Text="Assign Valuer"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:DropDownList ID="ddlvaluer" runat="server" Height="20px" 
                    onselectedindexchanged="ddlValuers_SelectedIndexChanged" Width="261px">
                </asp:DropDownList>
&nbsp;<asp:Button ID="btnAssignValuer" runat="server" onclick="btnAssignValuer_Click" 
                    Text="Assign Valuer" Width="139px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Report " 
                    Width="203px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:HiddenField ID="hfappno" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

