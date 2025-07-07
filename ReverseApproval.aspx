<%@ Page Language="C#" MasterPageFile="~/ApprovalPage.master" AutoEventWireup="true" CodeFile="ReverseApproval.aspx.cs" Inherits="ReverseApproval" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblError" runat="server" Font-Bold="True"></asp:Label><br />
    <br />
    <table style="width: 415px;        ">
        <tr>
            <td style="width: 159px; height: 26px; background-color: #ffffc9;">
                <strong>
                Enter Application No</strong></td>
            <td style="width: 11px; height: 26px">
                :</td>
            <td style="height: 26px">
                <asp:TextBox ID="txtAppNo" runat="server" OnTextChanged="txtAppNo_TextChanged"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnReverse" runat="server"  
            Text="Reverse Approval"
        Visible="False" OnClick="btnReverse_Click" />
</asp:Content>

