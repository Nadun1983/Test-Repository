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

public partial class AppSubmission : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbnAppsubmission_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ApplicationSubmission.aspx");
    }
    protected void lbnAppHandOver_Click(object sender, EventArgs e)
    {
        Session["userid"] = Session["userid"].ToString();
        Response.Redirect("~/ApplicationHandover.aspx");
    }
    protected void lbnMain_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenu.aspx");
    }
    protected void lbnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
}
