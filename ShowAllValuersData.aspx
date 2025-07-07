<%@ Page Language="C#" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="ShowAllValuersData.aspx.cs" Inherits="ShowAllValuersData" MasterPageFile="~/ValuationInspection.master" %>
 
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
                    <asp:Label ID="lblac" runat="server" Text="Enter the Date Range" Width="328px"></asp:Label><br />                      
    <table id="table1" runat="server">
        <tr>
            <td style="width: 100px">
                    <asp:Label ID="lblfrom" runat="server" Text="From (DDMMYYYY)" Width="152px"></asp:Label></td>
            <td style="width: 100px">
                    <asp:TextBox ID="txtfrom" runat="server" Width="146px" OnTextChanged="txtfrom_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 100px">
                    <asp:Label ID="lblto" runat="server" Text="To (DDMMYYYY)" Width="153px"></asp:Label></td>
            <td style="width: 100px">
                    <asp:TextBox ID="txtto" runat="server" Width="148px" OnTextChanged="txtto_TextChanged"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 42px">
                <asp:Button ID="btnValLed" runat="server" Height="32px" Text="Show Valuation Ledger"
                    Width="312px" OnClick="btnValLed_Click" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnToExcel" runat="server" Height="32px" OnClick="btnToExcel_Click"
                    Text="Transfer To Excel" Width="312px" /></td>
        </tr>
        <tr>
            <td colspan="2">
                    <asp:Button ID="btnall" runat="server" Height="31px" OnClick="btnall_Click" Text="Show All Details"
                        Width="314px" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnPrint" runat="server" Height="27px" OnClick="btnPrint_Click" Text="Print All Details"
                    Width="312px" /></td>
        </tr>
    </table>   
                    <asp:GridView ID="gvallvaluersdetails" runat="server" AllowPaging="True" OnPageIndexChanging="gvallvaluersdetails_PageIndexChanging" PageSize="50">
                    </asp:GridView>
    <br />
    <cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"></cr:crystalreportviewer>
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