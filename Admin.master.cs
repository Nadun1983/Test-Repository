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

public partial class Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void lbnMain_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenu.aspx");
    }
    protected void lbnAdduser_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserAccess.aspx");
    }
    protected void lbnAddInspector_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AddInspector.aspx");
    }
    protected void lbnAddValuer_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AddValuer.aspx");
    }
    protected void lbnAddLoanType_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AddLoanType.aspx");
    }
    protected void lbnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
    protected void AddDistrictToValuer(object sender, EventArgs e)
    {
        Response.Redirect("~/AddDistricToValuer.aspx");
    }
    protected void lbnRecProcess_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RecoveryProcess.aspx");
    }
    protected void lbnEditGlCode_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EditGLCode.aspx");
    }
    protected void lblReschedule_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/RescheduleProcess.aspx");
    }
    protected void lbnIntRates_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ChangeIntRates.aspx");
    }
}
