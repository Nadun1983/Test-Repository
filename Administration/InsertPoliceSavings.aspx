<%@ Page Language="C#" MasterPageFile="~/Recovery/RecMaster.master" AutoEventWireup="true" CodeFile="InsertPoliceSavings.aspx.cs" Inherits="Administration_InsertPoliceSavings" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style2
        {
            font-size: large;
        }
        .style1
        {
            width: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <br />
</p>
<p class="style2" style="font-weight: 700">
    Insert Police Loan Data</p>
<table class="style1">
    <tr>
        <td>
            Enter Application No</td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtappno" runat="server" ontextchanged="txtappno_TextChanged"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="dgvpolicedeta" runat="server">
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            Insert Savings Account</td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtsavingsno" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Insert Loan Ac No</td>
        <td>
            :</td>
        <td>
            <asp:TextBox ID="txtcracno" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button ID="btnsubmit" runat="server" onclick="btnsubmit_Click" 
                Text="Insert Savings Account No" Width="470px" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" Font-Size="Larger" 
                ForeColor="Red"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

