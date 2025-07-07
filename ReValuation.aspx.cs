using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ReValuation : System.Web.UI.Page
{
    ValuationFunctions vf;
    ValuerClass vc;
    DataTable dt;
    FunctionClass fc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtappno.Focus();

            dt = new DataTable();
            vc = new ValuerClass();
            ddlvaluer.DataSource = vc.GetValuer(1);
            ddlvaluer.DataTextField = "ValuerName";
            ddlvaluer.DataValueField = "valuerid";
            ddlvaluer.DataBind();

            VisibleFalse();
        }
    }

    private void VisibleFalse()
    {
        ddlvaluer.Visible = false;
        lblassVal.Visible = false;
        btnAssignValuer.Visible = false;
    }

    private void VisibleTrue()
    {
        ddlvaluer.Visible = true;
        lblassVal.Visible = true;
        btnAssignValuer.Visible = true;
    }

    protected void txtappno_TextChanged(object sender, EventArgs e)
    {


    }
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        vf = new ValuationFunctions();
        dt = new DataTable();
        vc = new ValuerClass();

        string appno = txtappno.Text;

        //validate appno. Display Customer details
        try
        {
            dt = vf.DisplayCustDetails(appno);
            dgvCustDetails.DataSource = dt;
            dgvCustDetails.DataBind();

            //Display Property Details
            dt = new DataTable();
            dt = vf.DisplayPropertyDetails(appno);
            dgvPropertyDetails.DataSource = dt;
            dgvPropertyDetails.DataBind();

            //Display valuation details
            dt = new DataTable();
            dt = vf.DisplayExistValDetails(appno);
            dgvExistValDetails.DataSource = dt;
            dgvExistValDetails.DataBind();

            hfappno.Value = appno.ToString();

            VisibleTrue();
        }
        catch (Exception err)
        {
            lblMsg.Text = "Invalid Application Number";
        }
    }

    protected void ddlValuers_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAssignValuer_Click(object sender, EventArgs e)
    {
        vc = new ValuerClass();
        fc = new FunctionClass();
        vf = new ValuationFunctions();
        dt = new DataTable();

        string valuerid = ddlvaluer.SelectedValue.ToString();
        string valuerType = vc.getValuerType(valuerid);
        DateTime sysDate = fc.GetSystemDate("A");
        string user = Session["userid"].ToString();
        int a = vc.InsertValersDetails(hfappno.Value, int.Parse(valuerid), sysDate, "R", "A", user, sysDate, -101, "Y", "Y", "N", "N", "N", "N", 0, 0, 0, "N", valuerType);

        if (a > 0)
        {
            lblMsg.Text = "Successfuly assigned";
            //Display valuation details
            dt = vf.DisplayExistValDetails(hfappno.Value);
            dgvExistValDetails.DataSource = dt;
            dgvExistValDetails.DataBind();
        }
        else
        {
            lblMsg.Text = "Invalid Data. Contact System Admin";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/ReValuationReports.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        vf = new ValuationFunctions();
        string appno = vf.getAppNoFromCracno(txtcracno.Text.ToString());
        txtappno.Text = appno.ToString();
    }
}
