<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAccess.aspx.cs" Inherits="UserAccess" MasterPageFile="~/Admin.master" %>

<script runat="server">

   
</script>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label><br />
    <table style="width: 680px">
        <tr>
            <td style="width: 126px; text-align: left">
                <asp:LinkButton ID="LinkButton1" runat="server" BackColor="#FFFFC9" 
                      
                    Font-Bold="True" Font-Underline="False" 
                    OnClick="LinkButton1_Click" Width="108px" style="height: 18px">Add New User</asp:LinkButton></td>
            <td style="text-align: left">
                <asp:LinkButton ID="LinkButton2" runat="server" BackColor="#FFFFC9"   Font-Bold="True" Font-Underline="False" OnClick="LinkButton2_Click" Width="113px">Existing Users</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lbnResetPassword" runat="server" BackColor="#FFFFC9" 
                      
                    Font-Bold="True" Font-Underline="False" 
                    OnClick="lbnResetPassword_Click" Width="151px" style="text-align: center">Reset Password</asp:LinkButton></td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 126px; text-align: left">
                &nbsp;</td>
            <td style="text-align: left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table  style="width: 682px;   
        
     " runat="server" visible="false" id="tbresetpassword">
        <tr>
            <td colspan="2" style="height: 33px">
                <asp:Label ID="lblResetPasd" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
        <tr>
            <td colspan="2" style="height: 33px">
                <strong>
                Select User Name: </strong>
                <asp:DropDownList ID="ddlUserList" runat="server" Font-Bold="True" 
                    Height="29px" Width="160px">
                </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Enter ResetPassword&nbsp;&nbsp;
                                        <asp:TextBox ID="txtResetPassword" runat="server" Width="198px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 59px">
                                        <asp:Button ID="btnresetpaswdsave" runat="server" Text="Save" Width="91px" 
                                            onclick="btnresetpaswdsave_Click" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        <asp:Panel ID="pnlEPF" runat="server" Visible="False">
                            <table style="width:100%;">
                                <tr>
                                    <td style="width: 137px">
                                        Enter EPF No</td>
                                    <td style="width: 17px">
                                        :</td>
                                    <td>
                                        <asp:TextBox ID="txtEpfNo" runat="server" ontextchanged="txtEpfNo_TextChanged" 
                                            AutoPostBack="True" Height="22px">0</asp:TextBox>
                                        <asp:Label ID="lblEpfNo" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                            <br />
    <table style="width: 682px;   
        
     " runat="server" visible="false" id="tblNew">
        <tr>
            <td colspan="3" style="width: 144px; background-color: #ffffc9; text-align: left">
                <strong>Add New User</strong></td>
        </tr>
        <tr>
            <td colspan="3" style="width: 144px; text-align: left">
            </td>
        </tr>
        <tr>
            <td style="width: 135px; background-color: #ffffc9; text-align: left">
                User Id</td>
            <td style="width: 9px; text-align: left">
                :</td>
            <td style="text-align: left">
                <asp:TextBox ID="txtUser" runat="server" ReadOnly="True"></asp:TextBox><span
                    style="color: red">* </span>
            </td>
        </tr>
        <tr>
            <td style="width: 135px; background-color: #ffffc9; text-align: left">
                Name of the Officer</td>
            <td style="width: 9px; text-align: left">
                :</td>
            <td style="text-align: left">
                <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="375px"></asp:TextBox><span style="color: red">*</span></td>
        </tr>
        <tr>
            <td style="width: 135px; background-color: #ffffc9; text-align: left">
                Password</td>
            <td style="width: 9px; text-align: left">
                :</td>
            <td style="text-align: left">
                <asp:TextBox ID="txtPw" runat="server" TextMode="Password" Width="148px"></asp:TextBox><span style="color: red">*</span></td>
        </tr>
        <tr>
            <td style="width: 135px; background-color: #ffffc9; text-align: left">
                Confirm Password</td>
            <td style="width: 9px; text-align: left">
                :</td>
            <td style="text-align: left">
                <asp:TextBox ID="txtCpw" runat="server" TextMode="Password" Width="147px"></asp:TextBox><span style="color: red">*</span>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPw"
                    ControlToValidate="txtCpw" ErrorMessage="confirm password is different"  ></asp:CompareValidator></td>
        </tr>
        <tr>
            <td style="width: 135px; background-color: #ffffc9; text-align: left; height: 24px;">
                Branch</td>
            <td style="width: 9px; text-align: left; height: 24px;">
                :</td>
            <td style="text-align: left; height: 24px;">
                <asp:DropDownList ID="ddlBranch" runat="server" DataSourceID="SqlDataSource1" DataTextField="BranchName" DataValueField="BranchNo" >
                </asp:DropDownList>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 135px; background-color: #ffffc9; text-align: left; height: 26px;">
                Designation</td>
            <td style="width: 9px; text-align: left; height: 26px;">
                :</td>
            <td style="text-align: left; height: 26px;">
                <asp:TextBox ID="txtDesig" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 135px; background-color: #ffffc9; text-align: left">
                Status</td>
            <td style="width: 9px; text-align: left">
                :</td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlstatus" runat="server" >
                    <asp:ListItem Value="A" Selected="True">Active</asp:ListItem>
                    <asp:ListItem Value="I">Inactive</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label1" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: left">
                <asp:GridView ID="grvAccess" runat="server" AutoGenerateColumns="False" Height="248px" Width="569px">
                    <Columns>
                        <asp:TemplateField>
                        <ItemTemplate>
                        <asp:CheckBox ID = "chkno" runat="server" />
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="prgId" HeaderText="Program Id" />
                        <asp:BoundField DataField="prgDescription" HeaderText="Access Program" />
                        <asp:BoundField DataField="CategoryId" HeaderText="Category" />
                    </Columns>
                    
                        
                
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:housdbString %>"
                    SelectCommand="SELECT [BranchNo], [BranchName] FROM [nsb_branch] ORDER BY [BranchName]">
                </asp:SqlDataSource>
                <br />
                <asp:Button ID="btnSave" runat="server"  
                         OnClick="btnSave_Click"
                    Text="Save" Width="75px" />
                <asp:Label ID="errMsg" runat="server" Font-Bold="True" ForeColor="Red" Width="285px"></asp:Label>
                </td>
        </tr>
    </table>
    <br />
    <table style="width: 679px;        " id="tblSubId" runat="server" visible="false">
        <tr>
            <td colspan="3" style="height: 247px; width: 671px;">
                <asp:GridView ID="grvSubPrg" runat="server" AutoGenerateColumns="False" Height="205px" Width="567px" Caption="Access to the Sub Programs">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSub" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PrgId" HeaderText="ProgramId" />
                        <asp:BoundField DataField="PrgDescription" HeaderText="Description" />
                        <asp:BoundField DataField="CategoryId" HeaderText="Category" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="btnSubId" runat="server" Text="Save" Width="72px" OnClick="btnSubId_Click"       /></td>
        </tr>
    </table>
    <br />
    <table style="width: 680px;        " id="tblEx" runat="server" visible="false">
        <tr>
            <td style="text-align: left">
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <strong>
                Select User Name:</strong>
                <asp:DropDownList ID="ddlUser" runat="server" OnSelectedIndexChanged="ddlUser_SelectedIndexChanged" AutoPostBack="True" Font-Bold="True" Width="120px">
                </asp:DropDownList><br />
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Panel ID="Panel2" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Change User Status"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlchangestatus" runat="server" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="A">Active</asp:ListItem>
                                    <asp:ListItem Value="I">Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnstatus" runat="server" onclick="btnstatus_Click" 
                                    Text="Change Status" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:DetailsView ID="dvUserDet" runat="server" AutoGenerateRows="False" Height="140px"
                    Visible="False" Width="380px">
                    <Fields>
                        <asp:BoundField DataField="username" HeaderText="User Name" >
                            <HeaderStyle BackColor="#FFFFC0" Font-Bold="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="epfno" HeaderText="Epf No" >
                            <HeaderStyle BackColor="#FFFFC0" Font-Bold="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="designation" HeaderText="Designation" >
                            <HeaderStyle BackColor="#FFFFC0" Font-Bold="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="brcode" HeaderText="Branch Code" >
                            <HeaderStyle BackColor="#FFFFC0" Font-Bold="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Fields>
                    <HeaderStyle Font-Bold="True" />
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:GridView ID="grvExUsers" runat="server" AutoGenerateColumns="False" Width="659px" Height="253px" Visible="False" OnRowDeleting="grvExUsers_RowDeleting">
                    <Columns>
                        <asp:TemplateField>
                        <ItemTemplate><asp:CheckBox ID="chkno" runat="server" /></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PrgId" HeaderText="Prg Id" />
                        <asp:TemplateField HeaderText="Status">
                        <ItemTemplate><asp:Label ID="lblstat" runat="server" ForeColor="Red" /></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PrgDescription" HeaderText="Access Program" />
                        <asp:TemplateField HeaderText="Remove Access">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" Enabled="False" CommandName="delete">Remove Access</asp:LinkButton>
                                <asp:Label ID = "prg" Text='<%# DataBinder.Eval (Container.DataItem, "PrgId") %>' Visible="false" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CategoryId" HeaderText="Category" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Button ID="btnUpdate" runat="server"  
                        OnClick="btnUpdate_Click"
                    Text="Update" Width="89px" /></td>
        </tr>
        <tr>
            <td style="text-align: left">
                &nbsp;</td>
        </tr>
    </table>
    <br />
</asp:Content>


