<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppNoSearch.aspx.cs" Inherits="AppNoSearch" MasterPageFile="~/loanmain.master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 442px;         background-color: #ffffc9;">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblCaption" runat="server" Font-Bold="True" Font-Size="11pt"></asp:Label></td>
        </tr>
    </table>
    <br />
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>&nbsp;<br />
    <table style="width: 441px;        ">
        <tr>
            <td style="text-align: left; background-color: #ffffc9;">
                Application No</td>
            <td>
                :</td>
            <td style="text-align: left">
                <asp:TextBox ID="txtappno" runat="server" Width="191px" ValidationGroup="grapp" OnTextChanged="txtappno_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="text-align: left">
                </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="text-align: left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Error: AppNo Required!" ControlToValidate="txtappno" Display="Dynamic" ValidationGroup="grapp"></asp:RequiredFieldValidator><br />
                </td>
        </tr>
    </table>
</asp:Content>


