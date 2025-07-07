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

public partial class ValuerAssignUnhide : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbnMain_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenu.aspx");
    }

    protected void lbnAssignValuer_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/valuation.aspx");
    }
    protected void lbnUnhideValuer_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/receievevaluation.aspx");
    }

    protected void lbnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
   
    protected void lbchangestatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ValuerInactive.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ValHistoryDetails.aspx");
    }
    protected void  LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ValuationSendLetter.aspx");
    }
    protected void lbnAssignExistRec_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AssignExistingValRecord.aspx");
    }
}
