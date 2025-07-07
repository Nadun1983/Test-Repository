<%@ Page Language="C#" MasterPageFile="~/loanmain.master" AutoEventWireup="true" CodeFile="SalaryTextFile.aspx.cs" Inherits="SalaryTextFile" Title="Untitled Page" %>

<script runat="server">

   
   
  
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 160px;
        }
        .style2
        {
            width: 8px;
        }
        .style11
        {
            width: 152px;
        }
        .style12
        {
            width: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>Generate Salary File</asp:ListItem>
            <asp:ListItem>Central Liability Data</asp:ListItem>
            <asp:ListItem>Send Monthly SMS</asp:ListItem>
            <asp:ListItem>Email Customer Statement</asp:ListItem>
            <asp:ListItem>Load EPF Numbers</asp:ListItem>
            <asp:ListItem>Generate AML Data File</asp:ListItem>
        </asp:RadioButtonList>
        <br />
    </p>
    <p>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </p>
   
    <p>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                Generating Staff Loan details for Pay Slip :
                <asp:Button ID="btnGenerate" runat="server" onclick="btnGenerate_Click" 
                    Text="Generate Salary Text File" />
            </asp:View>
            <asp:View ID="View2" runat="server">
                Generate Loan data for Central Liability system:
                <asp:Button ID="btnCentral" runat="server" onclick="btnCentral_Click" 
                    Text="Generate Liability Data - Credit" Width="329px" />
            </asp:View>
            <asp:View ID="View3" runat="server">
                <b>Generating SMS<br />
                </b>
                <table style="width:100%;">
                    <tr>
                        <td class="style1">
                            Enter Month End Date</td>
                        <td class="style2">
                            :</td>
                        <td>
                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            &nbsp;(ddmmyyyy)</td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnArreas" runat="server" onclick="btnArreas_Click" 
                                Text="Generate Arreas Text File" Width="236px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="btnSMS" runat="server" onclick="btnSMS_Click" 
                                Text="Generate SMS" />
                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td class="style11">
                            Statement Year</td>
                        <td class="style12">
                            :</td>
                        <td>
                            <asp:TextBox ID="tbYear" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style11">
                            Quarter</td>
                        <td class="style12">
                            :</td>
                        <td>
                            <asp:RadioButtonList ID="rblQuter" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="rblQuter_SelectedIndexChanged" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem>1st</asp:ListItem>
                                <asp:ListItem>2nd</asp:ListItem>
                                <asp:ListItem>3rd</asp:ListItem>
                                <asp:ListItem>4th</asp:ListItem>
                                <asp:ListItem>Yearly</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style11">
                            From Date</td>
                        <td class="style12">
                            :</td>
                        <td>
                            <asp:TextBox ID="txtFromEmailDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style11">
                            To Date</td>
                        <td class="style12">
                            :</td>
                        <td>
                            <asp:TextBox ID="txtToEmailDate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style11">
                            <asp:Button ID="btnEmailStatement" runat="server" 
                                onclick="btnEmailStatement_Click" Text="Print Email" Width="128px" />
                        </td>
                        <td class="style12">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <table style="width:100%;">
                    <tr>
                        <td colspan="3">
                            Load EPF numbers to the table</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:FileUpload ID="epfUpload" runat="server" Width="429px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnEPF" runat="server" onclick="btnEPF_Click" Text="Get Data" />
                            <asp:Label ID="lblErr" runat="server"></asp:Label>
                        </td>
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
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </asp:View>
            <br />
        </asp:MultiView>
    </p>
</asp:Content>

