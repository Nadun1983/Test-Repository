<%@ Page Language="C#" MasterPageFile="~/ApprovalPage.master" AutoEventWireup="true" CodeFile="Approval.aspx.cs" Inherits="Approval" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label><br />
    <br />
    <asp:GridView ID="grvAppDetails" runat="server" Width="699px">
    </asp:GridView>
    <br />
    <asp:GridView ID="grdArreasLoans" runat="server" Caption="Previous Arreas Loan Details" BorderWidth="2px">
    </asp:GridView>
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server">
    <table style="      border-bottom: darkgoldenrod 2px solid">
        <tr>
            <td style="width: 100px">
                <asp:DetailsView ID="dtvApprovalStatus" runat="server" Height="69px" Width="400px" Caption="Approval Status">
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100px">
    <asp:Button ID="btnSetApproval" runat="server" Text="Click to Approve" Width="400px"   OnClick="btnCheckProcess_Click"     />
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 18px;">
    </td>
        </tr>
    </table>
        <br />
    </asp:Panel>
    <br />
</asp:Content>

