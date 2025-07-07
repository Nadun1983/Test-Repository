<%@ Page Language="C#" MasterPageFile="~/AppSubmission.master" AutoEventWireup="true" CodeFile="ApplicationSubmission.aspx.cs" Inherits="ApplicationSubmission" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label><br />
    <br />
    <table style="      border-bottom: darkgoldenrod 2px solid">
        <tr>
            <td colspan="2">
    <asp:GridView ID="dgvCheckList" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvCheckList_SelectedIndexChanged" Width="436px" OnRowEditing="dgvCheckList_RowEditing" OnRowCancelingEdit="dgvCheckList_RowCancelingEdit" OnRowUpdating="dgvCheckList_RowUpdating" OnPageIndexChanged="dgvCheckList_PageIndexChanged" OnPageIndexChanging="dgvCheckList_PageIndexChanging">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:CheckBoxField DataField="IsLatest" HeaderText="Submit" SortExpression="IsLatest" />
            <asp:TemplateField HeaderText="No" SortExpression="chklistno">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="False" Text='<%# Bind("chklistno") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("chklistno") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="IsLatest" HeaderText="Submit" SortExpression="IsLatest" />
            <asp:TemplateField HeaderText="Description" SortExpression="Description">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="False" Text='<%# Bind("Description") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NoOfcopies" HeaderText="No of Copies" SortExpression="NoOfcopies" />
        </Columns>
    </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 193px">
                Enter Application Number</td>
            <td style="width: 124px">
                <asp:TextBox ID="txtAppNo" runat="server" OnTextChanged="txtAppNo_TextChanged" Width="229px"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 21px">
    <asp:Button ID="btnSubmission" runat="server"  
          OnClick="btnSubmission_Click" Text="Submit" Width="435px" Visible="False"   /></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 21px">
                <asp:Button ID="btnPrint" runat="server"  
          Text="Print Reciept" Width="435px" Visible="False" OnClick="btnPrint_Click"   /></td>
        </tr>
    </table>
    <br />
</asp:Content>

