<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="valuation.aspx.cs" Inherits="valuation" MasterPageFile="~/ValuerAssignUnhide.master" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
                    <table style="width: 484px; height: 75px; vertical-align: top; text-align: left;">
                        <tr>
                            <td style="height: 2px" colspan="2">
                                <asp:Label ID="lblmsg1" runat="server"   Width="800px" Font-Bold="False">Action Taken</asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 2px" valign="top">
                                <asp:GridView ID="dgvAsseginedValuer" runat="server" Height="114px">
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 2px;" valign="top" colspan="2">
                                <asp:DropDownList ID="ddldist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddldist_SelectedIndexChanged" Width="400px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="height: 4px;" colspan="2">
                                <asp:DropDownList ID="ddlvaluer" runat="server" Width="400px" OnSelectedIndexChanged="ddlvaluer_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 4px">
                                <asp:Button ID="btnsave" runat="server" Text="Save" Width="400px" OnClick="btnsave_Click"     /></td>
                        </tr>
                    </table>
   </asp:Content>