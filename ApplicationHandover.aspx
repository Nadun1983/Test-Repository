<%@ Page Language="C#" MasterPageFile="~/AppSubmission.master" AutoEventWireup="true" CodeFile="ApplicationHandover.aspx.cs" Inherits="ApplicationHandover" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label><br />
    <br />
    <table style="      border-bottom: darkgoldenrod 2px solid">
        <tr>
            <td style="width: 209px">
                Enter Application Number</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlAppNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAppNo_SelectedIndexChanged"
                    Width="220px" Font-Names="Verdana">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="dgvCheckList" runat="server" Height="108px" Width="431px" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="chklistno" HeaderText="Check List No" SortExpression="chklistno" />
                        <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description" />
                        <asp:BoundField DataField="NoOfcopies" HeaderText="No of Copies" SortExpression="NoOfcopies" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSubmission" runat="server"  
                      OnClick="btnSubmission_Click" Text="Submit" Width="435px"   /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnPrint" runat="server"  
                      Text="Print Reciept" Width="435px" Visible="False" OnClick="btnPrint_Click"   /></td>
        </tr>
    </table>
    <br />
</asp:Content>

