using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class search : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SearchApplication.aspx");
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenu.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/CustInquiryLogDetails.aspx");
    }
    protected void ProcessFile_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FileProcessing.aspx");
    }

    protected void lbnGlSearch(object sender, EventArgs e)
    {
        Response.Redirect("~/GlSearch.aspx");
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/TrackingSummary.aspx");
    }
}
