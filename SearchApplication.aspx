<%@ Page Language="C#" MasterPageFile="~/search.master" AutoEventWireup="true" CodeFile="SearchApplication.aspx.cs" Inherits="SearchApplication" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 726px">
        <tr>
            <td>
                <asp:HiddenField ID="hfnicno" runat="server" />
                <asp:Label ID="lblMsg" runat="server" Height="16px" Width="408px"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 60px">
                <strong>Search By: </strong>
                <asp:RadioButtonList ID="rboption" runat="server" 
                    Width="714px"    
                      AutoPostBack="True" 
                    onselectedindexchanged="rboption_SelectedIndexChanged">
                    <asp:ListItem Value="NIC">NIC</asp:ListItem>
                    <asp:ListItem>Initial</asp:ListItem>
                    <asp:ListItem Value="sname">Sure Name</asp:ListItem>
                    <asp:ListItem Value="pnumber">PassportNumber</asp:ListItem>
                    <asp:ListItem Value="Status">Application Status</asp:ListItem>
                    <asp:ListItem Value="LoanAccount">Loan Account No</asp:ListItem>
                    <asp:ListItem Value="AppNoDisb">Application No</asp:ListItem>
                    <asp:ListItem>Instalment</asp:ListItem>
                    <asp:ListItem>Address</asp:ListItem>
                    <asp:ListItem Value="EPF">EPF No</asp:ListItem>
                </asp:RadioButtonList>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="height: 27px">
                <strong>Enter Relevant Details:</strong>
                <asp:TextBox ID="txtsearchoption" runat="server" OnTextChanged="txtsearchoption_TextChanged"
                    Width="195px"></asp:TextBox>&nbsp;
                <asp:Button ID="btnPrintPreview" runat="server" onclick="btnPrintPreview_Click" 
                    Text="Print Preview" Width="147px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="dgvsearchresult" runat="server" Width="695px" 
                    AllowPaging="True" OnPageIndexChanging="dgvsearchresult_PageIndexChanging" 
                    onselectedindexchanging="dgvsearchresult_SelectedIndexChanging">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:DetailsView ID="dvcustdetail" runat="server" Height="50px" Width="125px">
                </asp:DetailsView>
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

