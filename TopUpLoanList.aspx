<%@ Page Language="C#" MasterPageFile="~/Recovery/RecMaster.master" AutoEventWireup="true" CodeFile="TopUpLoanList.aspx.cs" Inherits="TopUpLoanList" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="GetTopUpLoansList" />
    </p>
    <p>
        <asp:GridView ID="dgvtopuploans" runat="server">
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Accounts From"></asp:Label>
        <asp:TextBox ID="txtfrom" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Account To
        <asp:TextBox ID="txtto" runat="server" ontextchanged="txtto_TextChanged"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
</asp:Content>

