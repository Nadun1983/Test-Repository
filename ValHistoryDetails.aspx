<%@ Page Language="C#" MasterPageFile="~/ValuationInspection.master" AutoEventWireup="true" CodeFile="ValHistoryDetails.aspx.cs" Inherits="ValHistoryDetails" Title="Untitled Page" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:Label ID="Label3" runat="server" Text="Enter Appno and Click Show Details" Width="288px"></asp:Label><br />
    <table>
        <tr>
            <td colspan="3" style="height: 21px">
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Text="Application No" Width="104px"></asp:Label></td>
            <td colspan="2">
                <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></td>
        </tr>
    </table>
</asp:Content>

