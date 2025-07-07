<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="RecoveryProcess.aspx.cs" Inherits="RecoveryProcess" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server"></asp:Label><br />
    <table style="border-right: darkgoldenrod thin solid; border-top: darkgoldenrod thin solid;
        border-left: darkgoldenrod thin solid; border-bottom: darkgoldenrod thin solid">
        <tr>
            <td style="width: 139px; background-color: #ffffc9">
                Date Due</td>
            <td style="width: 69px">
                <asp:TextBox ID="txtDateDue" runat="server" OnTextChanged="txtDateDue_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 26px">
                <asp:Button ID="btnRecoveryProcess" runat="server"    
                    OnClick="btnRecoveryProcess_Click" Text="Recovery  Process" Width="300px" /></td>
        </tr>
        <tr>
            <td colspan="2" rowspan="2">
                <asp:Panel ID="pnlConfDate" runat="server" Height="50px" Visible="False">
                    <table>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="lblDateDue" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Button ID="btnConfirm" runat="server"    
                                    OnClick="btnConfirm_Click" Text="Confirm Date and Start Recovery" Width="300px" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
        </tr>
    </table>
    <br />
    <br />
    <table style="border-right: darkgoldenrod thin solid; border-top: darkgoldenrod thin solid;
        border-left: darkgoldenrod thin solid; border-bottom: darkgoldenrod thin solid">
        <tr>
            <td colspan="2">
                &nbsp;<asp:Button ID="btnNPLTransaction" runat="server"    
                                    OnClick="btnNPLTransaction_Click" Text="Loan Transaction " Width="300px" /></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

