<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValuerPayment.aspx.cs" Inherits="ValuerPayment"  MasterPageFile="~/ValuationInspection.master" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Label ID="lblMsg" runat="server" Text="Enter the Data Range and Select the Valuer"></asp:Label><br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Width="264px" /><br />
    <table>
        <tr>
            <td style="width: 176px">
                    <asp:Label ID="lblfrom" runat="server" Text="From (DDMMYYYY)" Width="151px"></asp:Label></td>
            <td style="width: 100px">
                    <asp:TextBox ID="txtfrom" runat="server" Width="230px" AutoPostBack="True" OnTextChanged="txtfrom_TextChanged" ToolTip="DDMMYYYY"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 176px">
                    <asp:Label ID="lblto" runat="server" Text="To (DDMMYYYY)"></asp:Label></td>
            <td style="width: 100px">
                    <asp:TextBox ID="txtto" runat="server" AutoPostBack="True" OnTextChanged="txtto_TextChanged" ToolTip="DDMMYYYY" Width="230px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                    <asp:DropDownList ID="ddlvaluersnames" runat="server" Width="418px" AutoPostBack="True" OnSelectedIndexChanged="ddlvaluersnames_SelectedIndexChanged">
                    </asp:DropDownList></td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Height="50px" Visible="False" Width="125px">
    <table>
        <tr>
            <td style="width: 100px">
                    <asp:GridView ID="GridView1" runat="server" Width="230px" AllowPaging="True" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging">
                    </asp:GridView>
            </td>
            <td style="width: 100px">
                    <table id="TABLE1" onclick="return TABLE1_onclick()" style="width: 280px;">
                        <tr>
                            <td style="width: 100px; height: 26px;">
                                <asp:Label ID="lbltotval" runat="server"   Text="Total Valuation"
                                    Width="126px"></asp:Label></td>
                            <td style="width: 100px; height: 26px;">
                                <asp:TextBox ID="txttotval" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 21px;">
                                <asp:Label ID="lbltrans" runat="server"   Text="Transport" Width="124px"></asp:Label></td>
                            <td style="width: 100px; height: 21px;">
                                <asp:TextBox ID="txttottransval" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="lbl10OfVal" runat="server"   Text="10% Of Valuation"
                                    Width="125px"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txt10pval" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="lblValPaymnt" runat="server"   Text="Valuer Payment"
                                    Width="124px"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtvalupayment" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="lblChkNo" runat="server"   Text="Cheque Number"
                                    Width="125px"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtchno" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                <asp:Label ID="lblChkDate" runat="server"   Text="Cheque Date"
                                    Width="125px"></asp:Label></td>
                            <td style="width: 100px">
                                <asp:TextBox ID="txtcdate" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnPrntValRec" runat="server" Text="Print Valuer Receipt" Width="284px" OnClick="btnPrntValRec_Click"     /></td>
                        </tr>
                         <tr>
                             <td colspan="2" style="height: 40px">
                                <asp:Button ID="btnprint" runat="server" Text="Print Cheque" Width="284px" OnClick="btnprint_Click"     /></td>
                        </tr>
                    </table>
            </td>
        </tr>
    </table>
    </asp:Panel>
    <br />
    <br />
    
</asp:Content>