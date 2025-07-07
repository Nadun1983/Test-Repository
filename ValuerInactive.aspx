<%@ Page Language="C#" MasterPageFile="~/ValuerAssignUnhide.master" AutoEventWireup="true" CodeFile="ValuerInactive.aspx.cs" Inherits="ValuerInactive" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:GridView ID="dgvData" runat="server" AutoGenerateColumns="False" 
    onrowcancelingedit="dgvData_RowCancelingEdit" onrowediting="dgvData_RowEditing" 
    onrowupdating="dgvData_RowUpdating" 
    onselectedindexchanged="dgvData_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="appno" HeaderText="appno" ReadOnly="True" />
        <asp:BoundField DataField="valuerid" HeaderText="valuerid" ReadOnly="True" />
        <asp:BoundField DataField="ValuerName" HeaderText="ValuerName" 
            ReadOnly="True" />
        <asp:BoundField DataField="senddate" HeaderText="senddate" ReadOnly="True" />
        <asp:BoundField DataField="hide" HeaderText="hide" ReadOnly="True" />
        <asp:TemplateField HeaderText="status">
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("status") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlstatus" runat="server">
                    <asp:ListItem>A</asp:ListItem>
                    <asp:ListItem>I</asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" />
    </Columns>
</asp:GridView>
<br />
    <table>
        <tr>
            <td>
                <asp:HiddenField ID="hfappno" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

