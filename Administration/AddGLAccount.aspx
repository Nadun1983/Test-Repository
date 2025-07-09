<%@ Page Language="C#" MasterPageFile="~/Administration/AdministrationHome.master" AutoEventWireup="true" CodeFile="AddGLAccount.aspx.cs" Inherits="Administration_AddGLAccount" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 102%;
        }
        .style3
        {
            width: 156px;
            text-align: right;
        }
        .style5
        {
            width: 406px;
        }
        .style6
        {
            width: 120px;
        }
        .style7
        {
            width: 179px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style2">
        <tr>
            <td class="style3">
                Branch :-</td>
            <td class="style5">
                <asp:DropDownList ID="ddlBranchCode" runat="server" 
                    DataSourceID="NSBBranchDataSource" DataTextField="branchname" 
                    DataValueField="branchno">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                GL Task ID:-</td>
            <td class="style5" valign="middle">
                <table class="style2">
                    <tr>
                        <td class="style6">
                <asp:TextBox ID="tbGltaskID"  style="text-transform:uppercase"  runat="server" ontextchanged="tbGltaskID_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                <asp:Button ID="btnChkAvailability" runat="server" 
                    onclick="btnChkAvailability_Click" Text="Check Avalability" />
                        </td>
                        <td class="style7">
                <asp:Label ID="lblTaskStatus" runat="server" Width="302px"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Trans Ref :-</td>
            <td class="style5">
                <asp:DropDownList ID="ddlTransRef" runat="server">
                    <asp:ListItem>AAAA</asp:ListItem>
                    <asp:ListItem>APPE</asp:ListItem>
                    <asp:ListItem>APPN</asp:ListItem>
                    <asp:ListItem>DISB</asp:ListItem>
                    <asp:ListItem>MISC</asp:ListItem>
                    <asp:ListItem>OTHR</asp:ListItem>
                    <asp:ListItem>RECV</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Description :-</td>
            <td class="style5">
                <asp:TextBox ID="tbDescription" runat="server" Width="232px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Category :-</td>
            <td class="style5">
                <asp:DropDownList ID="ddlCategory" runat="server" 
                    DataSourceID="CategeryDataSource" DataTextField="Description" 
                    DataValueField="CategeryID">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Based on Loans :-</td>
                                    <td class="style5">
                                        <asp:RadioButtonList ID="rblBasedonLoans" runat="server" 
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="True">Yes</asp:ListItem>
                                            <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style3">
                                        Based on Status :-</td>
            <td class="style5">
                <asp:RadioButtonList ID="rblBasedonStatus" runat="server" 
                    RepeatDirection="Horizontal" style="margin-left: 0px">
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Based on Income :-</td>
            <td class="style5">
                <asp:RadioButtonList ID="rblBasedonIncome" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Value="I" Selected="True">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Enabled="False">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style5">
                <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
                    Text="Update" Visible="False" />
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:SqlDataSource ID="NSBBranchDataSource" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:housdbString %>" 
                    SelectCommand="select branchno,branchname from nsb_branch">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="CategeryDataSource" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:housdbString %>" 
                    SelectCommand="select CategeryID,Description from category">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>

