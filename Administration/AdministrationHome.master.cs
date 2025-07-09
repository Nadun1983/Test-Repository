using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Administration_AdministrationHome : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbnEditGlCode0_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Administration/AddGLAccount.aspx");
    }
    protected void lbnAdduser_Click(object sender, EventArgs e)
    {

    }
    protected void lbnAddInspector_Click(object sender, EventArgs e)
    {

    }
    protected void lbnAddValuer_Click(object sender, EventArgs e)
    {

    }
    protected void AddDistrictToValuer(object sender, EventArgs e)
    {

    }
    protected void lbnAddLoanType_Click(object sender, EventArgs e)
    {

    }
    protected void lbnRecProcess_Click(object sender, EventArgs e)
    {

    }
    protected void lbnEditGlCode_Click(object sender, EventArgs e)
    {

    }
    protected void lbnLogout_Click(object sender, EventArgs e)
    {

    }
    protected void lbnMain_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenu.aspx");
    }
}
