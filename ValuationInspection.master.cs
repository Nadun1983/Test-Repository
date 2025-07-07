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

public partial class Valuation : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

    protected void lbValuationDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EnterValuationReportDetails.aspx");
    }
    protected void lbValuerPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ValuerPayment.aspx");
    }
    
    protected void lbValuationReports_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Reports.aspx");
    }
    protected void lbAssignInspector_Click(object sender, EventArgs e)
    {

    }
    protected void lbReceieveInspection_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/InspectionAccept.aspx");
    }
    protected void lbInspectorPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/InspectorPayments.aspx");
}
    protected void lbLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/login.aspx");
    }
    protected void lbValuationCommisionPayment_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Commisionvaluerpayment.aspx");
    }
    protected void lbnAllValuersDetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ShowAllValuersData.aspx");
    }
    protected void lbMainMenu_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenu.aspx");
    }
    protected void lbMainMenu_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/MainMenu.aspx");
    }
    protected void lbeditvaldetails_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ValuationEditReport.aspx");
    }
    
}
