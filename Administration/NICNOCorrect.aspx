<%@ Page Language="C#" MasterPageFile="~/CustomerInquiryMaster.master" AutoEventWireup="true" CodeFile="NICNOCorrect.aspx.cs" Inherits="Administration_NICNOCorrect" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter CRACNO :- " 
             ></asp:Label>
        <asp:TextBox ID="tbCracno" runat="server" Width="139px" 
            ontextchanged="tbCracno_TextChanged"></asp:TextBox>
    </p>
    <strong>
    <asp:GridView ID="dgvCustDetails" runat="server"
                        Width="689px" Caption="Customer Details" 
         >
    </asp:GridView>
    </strong>
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 133px">
        <asp:Label ID="Label2" runat="server" Text="Enter NICNo :- " 
                     ></asp:Label>
            </td>
            <td>
        <asp:TextBox ID="tbNicno" runat="server" Width="139px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
        <asp:Label ID="Label3" runat="server" Text="Holder Type :- " 
                     ></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rbHolderRelation" runat="server" 
                     >
                    <asp:ListItem Value="P">Primary Holder</asp:ListItem>
                    <asp:ListItem Value="S">Secondary Holder</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 133px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 133px">
                <asp:Button ID="btnUpdate" runat="server" Text="Update NIC" 
                    onclick="btnUpdate_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 133px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

    <br />
    <strong>
    <asp:GridView ID="dgvCustDetailsUpdated" runat="server"
                        Width="689px" Caption="Customer Details After Changes">
    </asp:GridView>
    </strong>
    
</asp:Content>

