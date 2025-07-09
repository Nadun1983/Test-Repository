<%@ Page Title="" Language="C#" MasterPageFile="~/Recovery/RecMaster.master" AutoEventWireup="true" CodeFile="DueDateCorrection.aspx.cs" Inherits="Recovery_DueDateCorrection" %>

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
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server" style="font-weight: 700">Date Format is (DDMMYYYY)</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Loan Number</td>
            <td>
                <asp:TextBox ID="txtLoanNo" runat="server" Width="183px" 
                    ontextchanged="txtLoanNo_TextChanged"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                Current Details of This Loan</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="dgvExHousDetails" runat="server" Width="621px">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Current Transaction
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="dgvExTransactionDetails" runat="server" Width="620px">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;<asp:Button ID="btnCorrectHousProp" runat="server" 
                    onclick="btnCorrectHousProp_Click" Text="Correct Master Record" Width="173px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" onclick="btnCorrect_Click" Text="Correct The Transactions" 
                    Width="171px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                New Details</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="dgvNewhousDetails" runat="server" Width="622px">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                New Transaction</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="dgvNewTransaction" runat="server" Width="622px">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

