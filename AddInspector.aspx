<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AddInspector.aspx.cs" Inherits="AddInspector" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" Font-Bold="True"></asp:Label><br />
    <br />
    <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="True" OnTextChanged="txtSearch_TextChanged"></asp:TextBox><br />
    <br />
    <asp:DetailsView ID="dtvAddInspector" runat="server" Height="414px" 
        Width="574px" AllowPaging="True" AutoGenerateRows="False" 
        OnItemInserted="dtvAddInspector_ItemInserted" 
        OnItemInserting="dtvAddInspector_ItemInserting" 
        OnModeChanging="dtvAddInspector_ModeChanging" 
        OnItemUpdated="dtvAddInspector_ItemUpdated" 
        OnItemUpdating="dtvAddInspector_ItemUpdating" 
        OnPageIndexChanged="dtvAddInspector_PageIndexChanged" 
        OnPageIndexChanging="dtvAddInspector_PageIndexChanging" 
        OnItemCommand="dtvAddInspector_ItemCommand" >
        <Fields>
            <asp:BoundField DataField="INSPECTID" HeaderText="Inspect Id" SortExpression="INSPECTID" />
            <asp:TemplateField HeaderText="Title Code" SortExpression="TITLECODE">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlTitleCodeE" runat="server" DataSourceID="ObjectDataSource1" DataTextField="TITLEDESC" DataValueField="TITLECODE">
                    </asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" InsertMethod="Insert"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DataSet1TableAdapters.TITLETableAdapter">
                        <InsertParameters>
                            <asp:Parameter Name="TITLECODE" Type="Int32" />
                            <asp:Parameter Name="TITLEDESC" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                </EditItemTemplate>
                <InsertItemTemplate>
                    &nbsp;<asp:DropDownList ID="ddlTitleCodeI" runat="server" DataSourceID="ObjectDataSource1" DataTextField="TITLEDESC" DataValueField="TITLECODE" >
                    </asp:DropDownList><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" InsertMethod="Insert"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="DataSet1TableAdapters.TITLETableAdapter">
                        <InsertParameters>
                            <asp:Parameter Name="TITLECODE" Type="Int32" />
                            <asp:Parameter Name="TITLEDESC" Type="String" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TITLECODE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="SURNAME" HeaderText="Surname" SortExpression="SURNAME" />
            <asp:BoundField DataField="INITIALS" HeaderText="Initials" SortExpression="INITIALS" />
            <asp:BoundField DataField="EPFNO" HeaderText="EPF No" SortExpression="EPFNO" />
            <asp:BoundField DataField="DESIGNATION" HeaderText="Destination" SortExpression="DESIGNATION" />
            <asp:BoundField DataField="GRADE" HeaderText="Grade" SortExpression="GRADE" />
            <asp:BoundField DataField="BRANCHCODE" HeaderText="Branch Code" SortExpression="BRANCHCODE" />
            <asp:BoundField DataField="TELENO" HeaderText="Contact No" SortExpression="TELENO" />
            <asp:BoundField DataField="ADDUSER" HeaderText="Add User" SortExpression="ADDUSER" />
            <asp:BoundField DataField="DestAcNo" HeaderText="Account No" SortExpression="DestAcNo" />
            <asp:BoundField DataField="EmailOffice" HeaderText="Office Email" SortExpression="EmailOffice" />
            <asp:BoundField DataField="TelRes" HeaderText="Contact No (Res.)" SortExpression="TelRes" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
            <asp:BoundField DataField="ADDDateTime" HeaderText="ADD Date" SortExpression="ADDDateTime" />
            <asp:TemplateField ShowHeader="False">
                <InsertItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Insert"
                        Text="Insert"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="New"
                        Text="New"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Fields>
    </asp:DetailsView>
</asp:Content>

