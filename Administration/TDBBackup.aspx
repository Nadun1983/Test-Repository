<%@ Page Language="C#" MasterPageFile="~/loanmain.master" AutoEventWireup="true" CodeFile="TDBBackup.aspx.cs" Inherits="Administration_TDBBackup" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="TDB Live Backup" Font-Bold="True"></asp:Label>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblMsg0" runat="server" text="This prgram takes the backup of Credit Management System Live Database. It may take few seconds !"></asp:Label></p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBackup" runat="server" Text="Take Backup" 
            onclick="btnBackup_Click" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <br />
    </p>
</asp:Content>

