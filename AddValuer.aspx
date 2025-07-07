<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AddValuer.aspx.cs" Inherits="AddValuer" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label><br />
    <br />
    <asp:Button ID="btnAutoLoanView" runat="server" onclick="btnAutoLoanView_Click" 
        Text="Auto Loan Valuers" Width="196px" />
&nbsp;&nbsp;
    <asp:Button ID="btnHPLView" runat="server" onclick="btnHPLView_Click" 
        Text="HPL Valuer Details" Width="226px" />
&nbsp;<asp:Panel ID="pnlAutoLoan" runat="server">
        <table style="width:100%;">
            <tr>
                <td style="width: 153px">
                    <asp:Label ID="Label1" runat="server" Text="Valuer Name to Search" 
                        Visible="False"></asp:Label>
                </td>
                <td style="width: 11px">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtValuerName" runat="server" AutoPostBack="True" 
                        ontextchanged="txtValuerName_TextChanged" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 153px">
                    <asp:Label ID="Label2" runat="server" Text="Enter new Valuer Name"></asp:Label>
                </td>
                <td style="width: 11px">
                    :</td>
                <td>
                    <asp:TextBox ID="txtNewValuer" runat="server" Width="378px"></asp:TextBox>
                    &nbsp;
                    <asp:Button ID="btnAutoLoan" runat="server" onclick="btnAutoLoan_Click" 
                        Text="Save" Width="83px" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="grvValuers" runat="server">
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 153px">
                    &nbsp;</td>
                <td style="width: 11px">
                    &nbsp;</td>
                <td>
                    &nbsp;
                    </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlValuer" runat="server">
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 192px">
                                Enter Valuer ID number</td>
                            <td style="width: 204px">
                                <asp:TextBox ID="txtvaluerID" runat="server" Width="165px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnedit" runat="server" onclick="btnedit_Click" Text="EDIT" 
                                Width="92px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 192px">
                                <asp:Button ID="btnaddnewvaluer" runat="server" onclick="btnaddnewvaluer_Click" 
                                Text="Add New Valuer" Width="149px" />
                            </td>
                            <td style="width: 204px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 142px">
                                Title</td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="147px">
                                    <asp:ListItem Value="1">Mr</asp:ListItem>
                                    <asp:ListItem Value="2">Mrs</asp:ListItem>
                                    <asp:ListItem Value="3">Miss</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Sur Name</td>
                            <td>
                                <asp:TextBox ID="txtsurname" runat="server" Width="260px">
                            </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Initial</td>
                            <td>
                                <asp:TextBox ID="txtinitial" runat="server" Width="260px">
                            </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Location</td>
                            <td>
                                <asp:TextBox ID="txtlocation" runat="server" Width="260px">
                            </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Street</td>
                            <td>
                                <asp:TextBox ID="txtstreet" runat="server" Width="260px">
                            </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                City</td>
                            <td>
                                <asp:TextBox ID="txtcity" runat="server" Width="260px">
                            </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Telephone</td>
                            <td>
                                <asp:TextBox ID="txttelephone" runat="server" Width="260px">
                            </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                NicNo/EPF</td>
                            <td>
                                <asp:TextBox ID="txtnicno" runat="server" Width="260px">
                            </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Status</td>
                            <td>
                                <asp:TextBox ID="txtstatus" runat="server" Width="260px">A</asp:TextBox>
                                &nbsp;A- Active , I - Inactive</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                valuertype</td>
                            <td>
                                <asp:TextBox ID="txtvaluertype" runat="server" Width="260px">O</asp:TextBox>
                                &nbsp;O - Outsider , S - Staff</td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                Qualification/ Grade</td>
                            <td>
                                <asp:TextBox ID="txtqualification" runat="server" Width="260px">
                            </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 142px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" 
                                Width="162px" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                                Text="Update" Width="156px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GridView2" runat="server" Height="117px" Width="341px">
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    </asp:Content>

