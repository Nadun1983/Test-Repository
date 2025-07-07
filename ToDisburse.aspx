<%@ Page Language="C#" MasterPageFile="~/ToDisburseMaster.master" AutoEventWireup="true" CodeFile="ToDisburse.aspx.cs" Inherits="ToDisburse" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label><br />
    <br />
    <asp:GridView ID="dgvLoanToDisb" runat="server" Caption="Loans to be Disbursed" Width="600px" 
     BackColor="LightGoldenrodYellow" BorderColor="Tan"   CellPadding="2" ForeColor="Black" GridLines="None" OnSelectedIndexChanging="dgvLoanToDisb_SelectedIndexChanging" >
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
    <br />
    <asp:Panel ID="panelEnterAppNo" runat="server" Height="50px" Width="125px">
    <table style="   
          width: 345px; border-bottom: darkgoldenrod 2px solid">
        <tr>
            <td style="width: 155px; background-color: #ffffc9">
                <strong>Enter Application No:</strong></td>
            <td>
                <asp:TextBox ID="txtAppno" runat="server" OnTextChanged="txtAppno_TextChanged" ></asp:TextBox></td>
        </tr>
    </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="dgvPrimaryDetails" runat="server" Caption="Primary Loan Details" Width="800px" 
     BackColor="LightGoldenrodYellow" BorderColor="Tan"   CellPadding="2" ForeColor="Black" GridLines="None" >
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
                <asp:GridView ID="dgvSeconderyDetails" runat="server" 
        Caption="Secondary Loan Details" Width="800px" BackColor="LightGoldenrodYellow" 
        BorderColor="Tan"   CellPadding="2" ForeColor="Black" 
        GridLines="None" AutoGenerateColumns="False" 
        onrowcancelingedit="dgvSeconderyDetails_RowCancelingEdit" 
        onrowediting="dgvSeconderyDetails_RowEditing" 
        onrowupdating="dgvSeconderyDetails_RowUpdating">
                    <FooterStyle BackColor="Tan" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    <Columns>
                        <asp:BoundField ReadOnly="True" />
                        <asp:BoundField ReadOnly="True" />
                        <asp:BoundField DataField="ApprovedAmt" HeaderText="Approved Amt" 
                            ReadOnly="True" />
                        <asp:TemplateField HeaderText="Loan Category">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlCategory" runat="server" 
                                    DataSourceID="SqlDataSource1" DataTextField="CrDes" 
                                    DataValueField="CrCatCode">
                                </asp:DropDownList>
                                &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:housdbString %>" 
                                    SelectCommand="SELECT [CrCatCode], [CrDes] FROM [CrCategory]">
                                </asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("LoanCategory") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="boqamount" HeaderText="BOQ Amount" ReadOnly="True" />
                        <asp:BoundField DataField="IntRate" HeaderText="Interest Rate" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="noofdisb" HeaderText="No.Of Disbursements" 
                            ReadOnly="True" />
                        <asp:BoundField DataField="No of Instalments" HeaderText="No of Instalments" 
                            ReadOnly="True" />
                        <asp:CommandField HeaderText="Edit Category" ShowEditButton="True" />
                    </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnTransAppDetails" runat="server"  
                   Text="Transfer Application Details" Width="221px" Visible="False"     OnClick="btnTransAppDetails_Click" /><br />
    <br />
    <asp:GridView ID="dgvLoanDetails" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
          CellPadding="2" ForeColor="Black" GridLines="None" Width="291px">
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
    <asp:Panel ID="Panel1" runat="server" Height="0px" Width="0px">
    </asp:Panel>
    <br />
</asp:Content>

