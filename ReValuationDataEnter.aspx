<%@ Page Language="C#" MasterPageFile="~/loanmain.master" AutoEventWireup="true" CodeFile="ReValuationDataEnter.aspx.cs" Inherits="ReValuationDataEnter" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Enter Loan Number</td>
            <td>
                <asp:TextBox ID="txtcracno" runat="server" Width="165px" 
                    ontextchanged="txtappno_TextChanged">603080</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:Button ID="btnGetAppno" runat="server" Text="Get Application Number" 
                    Width="211px" onclick="btnGetAppno_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Enter Application Number</td>
            <td>
                <asp:TextBox ID="txtappno" runat="server" Width="165px" 
                    ontextchanged="txtappno_TextChanged">3080</asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnDisplay" runat="server" Text="Display" 
                    Width="131px" onclick="btnDisplay_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Valuer Name</td>
            <td>
                <asp:TextBox ID="valuername" runat="server" Width="165px" 
                    ontextchanged="valuername_TextChanged" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Date of Valuation(DDMMYYYY)</td>
            <td>
                <asp:TextBox ID="dateofvaluation" runat="server" Width="165px" 
                    ontextchanged="dateofvaluation_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Present Valuation</td>
            <td>
                <asp:TextBox ID="presentvaluation" runat="server" Width="165px" 
                    ontextchanged="presentvaluation_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Complete Valuation</td>
            <td>
                <asp:TextBox ID="completevaluation" runat="server" Width="165px" 
                    ontextchanged="completevaluation_TextChanged">0</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Fored Sale Value</td>
            <td>
                <asp:TextBox ID="forcedsalevaluation" runat="server" Width="165px" 
                    ontextchanged="forcedsalevaluation_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Access Road</td>
            <td>
                <asp:TextBox ID="accessroad" runat="server" Width="165px" 
                    ontextchanged="accessroad_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Valuer Comments</td>
            <td>
                <asp:TextBox ID="valuercomment" runat="server" Width="165px" 
                    ontextchanged="valuercomment_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                remarks</td>
            <td>
                <asp:TextBox ID="remarks" runat="server" Width="165px" 
                    ontextchanged="remarks_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="161px" 
                    onclick="btnSave_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:HiddenField ID="hfappno" runat="server" />
</asp:Content>

