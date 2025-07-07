<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AddDistricToValuer.aspx.cs" Inherits="AddDistricToValuer" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMsg" runat="server" Width="368px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px" valign="top">
                <asp:DropDownList ID="ddlvaluers" runat="server" Width="208px" AutoPostBack="True" OnSelectedIndexChanged="ddlvaluers_SelectedIndexChanged1" Font-Names="Verdana">
                    <asp:ListItem Value="valuerid">fullname</asp:ListItem>
                </asp:DropDownList></td>
            <td colspan="2" valign="top">
                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False"
                    Height="50px" OnPageIndexChanged="DetailsView1_PageIndexChanged" OnPageIndexChanging="DetailsView1_PageIndexChanging"
                    Width="272px" OnModeChanging="DetailsView1_ModeChanging" 
                    OnItemInserting="DetailsView1_ItemInserting" 
                    OnItemUpdating="DetailsView1_ItemUpdating" 
                    OnItemCommand="DetailsView1_ItemCommand">
                    <Fields>
                        <asp:TemplateField HeaderText="DistricName" SortExpression="DistricName">
                            <EditItemTemplate>
                                <asp:DropDownList id="ddlInsert" runat="server" DataSourceID="SqlDataSource1" DataTextField="DistName"
                                    DataValueField="Distcode" Width="144px">
</asp:DropDownList><asp:SqlDataSource id="SqlDataSource1" runat="server"
    ConnectionString="<%$ ConnectionStrings:housdbString %>" SelectCommand="SELECT [Distcode], [DistName] FROM [District] ORDER BY [DistName]">
</asp:SqlDataSource>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <asp:DropDownList ID="ddlInsert" runat="server" DataSourceID="SqlDataSource2" DataTextField="DistName"
                                    DataValueField="Distcode" Width="144px">
                                </asp:DropDownList>
                                <br />
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:housdbString %>"
                                    SelectCommand="SELECT [Distcode], [DistName] FROM [District] ORDER BY [DistName]">
                                </asp:SqlDataSource>
                            </InsertItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Height="24px" Text='<%# Bind("DistName") %>'
                                    Width="96px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowInsertButton="True" />
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
        <tr>
            <td colspan="3">
            </td>
        </tr>
    </table>
</asp:Content>

