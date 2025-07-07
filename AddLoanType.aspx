<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AddLoanType.aspx.cs" Inherits="AddLoanType" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label><br />
    <br />
    <table>
        <tr>
            <td colspan="2">
                <asp:DetailsView ID="dtvLoanCat" runat="server" AllowPaging="True" AutoGenerateRows="False"
                    Height="50px" OnItemCommand="dtvLoanCat_ItemCommand" OnItemInserting="dtvLoanCat_ItemInserting"
                    OnItemUpdating="dtvLoanCat_ItemUpdating" OnModeChanging="dtvLoanCat_ModeChanging"
                    OnPageIndexChanged="dtvLoanCat_PageIndexChanged" OnPageIndexChanging="dtvLoanCat_PageIndexChanging"
                    Width="350px">
                    <Fields>
                        <asp:TemplateField HeaderText="CrCatCode" SortExpression="CrCatCode">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("CrCatCode") %>'></asp:Label>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("CrCatCode") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CrDes" HeaderText="CrDes" SortExpression="CrDes" />
                        <asp:CommandField ShowInsertButton="True" />
                        <asp:CommandField ShowEditButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>

