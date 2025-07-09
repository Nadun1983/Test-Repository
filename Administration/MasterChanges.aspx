<%@ Page Language="C#" MasterPageFile="~/loanmain.master" AutoEventWireup="true" CodeFile="MasterChanges.aspx.cs" Inherits="Administration_MasterChanges" Title="Untitled Page" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 55%;
        }
        .style3
        {
            width: 193px;
        }
    .style4
    {
        width: 100%;
    }
        .style6
        {
        }
        .style7
        {
            width: 41px;
        }
        .style8
        {
            width: 94px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="height: 16px">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </p>
<p style="height: 16px">
        &nbsp;</p>
<p style="height: 16px">
        <asp:Label runat="server" style="font-weight: 700" 
            Text="Please check the Existing Deatails ."></asp:Label>
    </p>
    <p>
        <asp:GridView ID="dgvmaster" runat="server" Width="596px">
        </asp:GridView>
    </p>
<p>
        <asp:Label runat="server" style="font-weight: 700" 
            Text="Change Master Data in Correct Boxes and Update Master Data."></asp:Label>
    </p>
    <table class="style2">
        <tr>
            <td class="style3">
                CrAcNo</td>
            <td>
                <asp:TextBox ID="txtcracno" runat="server" 
                    Width="202px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Interest Rate</td>
            <td>
                <asp:TextBox ID="txtintrate" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Instalment</td>
            <td>
                <asp:TextBox ID="txtinstalment" runat="server" Width="200px" ReadOnly="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Outstanding Balance</td>
            <td>
                <asp:TextBox ID="txtoutbal" runat="server" Width="198px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Actual Outstanding Balance</td>
            <td>
                <asp:TextBox ID="txtactoutbal" runat="server" Width="199px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Date Due</td>
            <td>
                <asp:TextBox ID="txtdatedue" runat="server" Width="197px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Last Completed Due Date</td>
            <td>
                <asp:TextBox ID="txtlastcompletedduedate" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Grant Date</td>
            <td>
                <asp:TextBox ID="txtgrantdate" runat="server" Width="198px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                No Of Instalment</td>
            <td>
                <asp:TextBox ID="txtNoOfinstalment" runat="server" Width="197px" 
                    ReadOnly="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Penal Valid Date</td>
            <td>
                <asp:TextBox ID="txtpenalvaliddate" runat="server" Width="196px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Button ID="btnupdatemaster" runat="server" Text="Update Master Data" 
                    Width="198px" onclick="btnupdatemaster_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
                            <asp:HiddenField ID="hfcrperiod" runat="server" />
    <br />
<table class="style4">
    <tr>
        <td colspan="2">
            <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
                Text="Change Recipt Period"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="dgvRecipPeriod" runat="server">
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style8">
            Recipt Period</td>
        <td class="style7">
            <asp:TextBox ID="txtReciptPeriod" runat="server" 
                ontextchanged="txtReciptPeriod_TextChanged"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6" colspan="2">
            <asp:Button ID="btnreciptpd" runat="server" onclick="btnreciptpd_Click" 
                Text="Update Recipt Period" Width="222px" />
        </td>
    </tr>
</table>
    <br />
    <p>
        &nbsp;</p>
</asp:Content>

