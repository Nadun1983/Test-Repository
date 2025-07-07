<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:BoundField HeaderText="BranchNo" DataField="Branchno" />
                <asp:BoundField HeaderText="Branch Name" DataField="branchname" />
            </Columns>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <EditRowStyle BackColor="#999999" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle   ForeColor="#284775" />
        </asp:GridView>
        <br />
        <br />
        <br />
        download to excell</div>
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="167px">
            <asp:ListItem Value="1">Yes</asp:ListItem>
            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="submit" />
    </form>
</body>
</html>
