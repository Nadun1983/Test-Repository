<%@ Page Language="C#" MasterPageFile="~/ValuationInspection.master" AutoEventWireup="true" CodeFile="ValuationEditReport.aspx.cs" Inherits="ValuationEditReport" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>

    <table>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblEditValDetailMsg" runat="server" Text="Enter Application Number and Click on Serach Button"
                    Width="400px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Application Number" Width="136px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtappno" runat="server" Width="200px" OnTextChanged="txtappno_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="panelValuerEditReport" runat="server" Height="50px" Width="125px">

    <table id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lbldateofval" runat="server" Text="ValuveDate" Width="106px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtrecdate" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblpval" runat="server" Height="22px" Text="Present Valuation" Width="115px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtpresentval" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblcomval" runat="server" Text="Complete Valuation" Width="133px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtcompltval" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblfsaleval" runat="server" Text="ForcedSaleValue" Width="124px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtfsaleval" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblfireinsval" runat="server" Text="Fire Insurance Valuation" Width="160px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtfireinsval" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Label ID="lblaccrd" runat="server" Text="Access Road" Width="137px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtaccessroad" runat="server" Width="200px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="lblcoment" runat="server" Text="Comments" Width="126px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtcomment" runat="server" TextMode="MultiLine" Width="198px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:Label ID="lblremarks" runat="server" Text="Remarks" Width="130px"></asp:Label></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" Width="198px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" Text="Update"
                    Width="160px" /></td>
            <td style="width: 100px">
                <asp:Button ID="btnclear" runat="server" OnClick="btnclear_Click" Text="Clear" Width="200px" /></td>
        </tr>
    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>

