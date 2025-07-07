<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="AboutUs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 28%;
            height: 532px;
            
        }
        .style2
        {
        }
        .style7
        {
            text-align: center;
        }
        #tblMainTable
        {
            height: 9px;
            width: 242px;
        }
        .style8
        {
            width: 337px;
            text-align: left;
             
             
        }
        #form1
        {
            text-align: center;
        }
        .style9
        {
             
        }
        .style10
        {
            font-size: x-small;
        }
    </style>
</head>
<body style="   ">
    <form id="form1" runat="server">
    <div style="text-align: center">
    
        <img alt="" src="images/logo.jpg" style="width: 474px; height: 56px" /><br />
        <table class="style1" align="center">
        
            <tr>
                <td class="style2" colspan="2">
                    <asp:Label ID="Label1"  runat="server" Text="System Developmet Team" 
                        Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style7" colspan="2">
                    <asp:Image ID="Image2" runat="server" Height="104px" 
                        ImageUrl="~/images/Sunimal.jpg" />
                    <br />
                    Sunimal Fernando</td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="Image3" runat="server" Height="104px" 
                        ImageUrl="~/images/Amila.jpg" />
                    <br />
                    Amila Hettiarachchi</td>
                <td class="style7">
                    <asp:Image ID="Image4" runat="server" Height="104px" 
                        ImageUrl="~/images/Bimali.jpg" />
                    <br />
                    Bimali Pinidiya</td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="Image5" runat="server" Height="104px" 
                        ImageUrl="~/images/Dilanka.jpg" />
                    <br />
                    Dilanka Sumanaweera</td>
                <td class="style7">
                    <asp:Image ID="Image6" runat="server" Height="104px" 
                        ImageUrl="~/images/Vihanga.jpg" />
                    <br />
                    Vihanga Nikeshana</td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="Image7" runat="server" Height="104px" 
                        ImageUrl="~/images/Pradeep.jpg" />
                    <br />
                    Pradeep Kalansooriya</td>
                <td class="style7">
                    <asp:Image ID="Image8" runat="server" Height="104px" 
                        ImageUrl="~/images/Vindy.jpg" />
                    <br />
                    Vindya Vidanagamachchi</td>
            </tr>
            </table>
    
        <img src="images/Footer.jpg" style="width: 631px; height: 16px" /></div>
            <table align="center">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
            <span id="ctl00_Footer1_MSFT_copyright" class="style10" 
                style="  " title="NSB IT Division">© All 
            Right Reserved. NCMS Development Team - NSB IT Division. </span>
                    </td>
                </tr>
                <tr>
                    <td style="WIDTH: 100px">
                        <span style="  FONT-SIZE: 7pt">
                        <span class="style9">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/NSBITLogo.jpg" 
                            Width="136px" />
                        </span>
                        </span>
                    </td>
                    <td class="style8">
                        Iformation Technology 
                        Division<br />
                        National Savings Bank<br />
                        Savings House<br />
                        Colombo 03<br />
                        Sri Lanka.</span></td>
                </tr>
            </table>
    </form>

    <p style="text-align: center">
        &nbsp;</p>

</body>
</html>
