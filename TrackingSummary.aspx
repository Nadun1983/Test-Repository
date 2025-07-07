<%@ Page Language="C#" MasterPageFile="~/Recovery/RecMaster.master" AutoEventWireup="true" CodeFile="TrackingSummary.aspx.cs" Inherits="TrackingSummary" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
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
            <td>
                From Date(DDMMYYYY)</td>
            <td>
                <asp:TextBox ID="txtfrom" runat="server"></asp:TextBox>
            </td>
            <td>
                To Date(DDMMYYYY)</td>
            <td>
                <asp:TextBox ID="txtto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnsubmot" runat="server" onclick="btnsubmot_Click" 
                    Text="Display Data" Width="680px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="dgvtrack" runat="server" BackColor="#DEBA84" 
                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    CellSpacing="2">
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

