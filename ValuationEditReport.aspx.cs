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
using System.Data.SqlClient;

public partial class ValuationEditReport : System.Web.UI.Page
{
    ValuationFunctions valFunc;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        panelValuerEditReport.Visible = false;
        if (!Page.IsPostBack)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string username = Session["userid"].ToString();
                string progname = "ValuationEditReport.aspx";
                if (fc.IsValid(progname, username))
                {
                    txtappno.Focus();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch
            {
                Response.Redirect("login.aspx");
            }
        }
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        //Check is there any null or Empty values.

        if ((txtappno.Text != "") && (txtrecdate.Text != "") && (txtpresentval.Text != "") && (txtfsaleval.Text != ""))
        {
            string APPNO = txtappno.Text.ToString();
            DateTime DATEOFVAL = DateTime.Parse(txtrecdate.Text);
            decimal PRESENTVAL = decimal.Parse(txtpresentval.Text);
            decimal COMPLETEVAL = decimal.Parse(txtcompltval.Text);
            decimal FORCEVAL = decimal.Parse(txtfsaleval.Text);
            decimal FIREINSURANCE = decimal.Parse(txtfireinsval.Text);
            string AccessRoad = txtaccessroad.Text.ToString();
            string ValuerComments = txtcomment.Text.ToString();
            string REMARKS = txtremarks.Text.ToString();

            valFunc = new ValuationFunctions();
            int RowAdded = 0;

            //Check is there any ZERO values and Confirm values
            if ((PRESENTVAL > 0) && (FORCEVAL > 0))
            {
                RowAdded = valFunc.updateValuationReport(APPNO, DATEOFVAL, PRESENTVAL, COMPLETEVAL, FORCEVAL, FIREINSURANCE, AccessRoad, ValuerComments, REMARKS);

                if (RowAdded > 0)
                {
                    lblEditValDetailMsg.Text = "Successfully updated";
                }
                else
                {
                    lblEditValDetailMsg.Text = "Sorry Invalid Data";
                }
            }
            else
            {
                lblEditValDetailMsg.Text = "Sorry You Entered Invalid Data";
            }

        }
        else
        {
            lblEditValDetailMsg.Text = "Please Check You entered Data again";
        }

    }

    public void clear()
    {
        txtappno.Text = "";

        txtrecdate.Text = "";
        txtpresentval.Text = "";
        txtcompltval.Text = "";
        txtfsaleval.Text = "";
        txtfireinsval.Text = "";
        txtaccessroad.Text = "";        
        txtcomment.Text = "";        
        txtremarks.Text = "";
        
       
    }
    protected void txtappno_TextChanged(object sender, EventArgs e)
    {
        string appno = txtappno.Text.ToString();
        valFunc = new ValuationFunctions();
        dt = new DataTable();
        dt = valFunc.ValuationReportDetails(appno);
        int count = dt.Rows.Count;

        if (count > 0)
        {
            txtrecdate.Text = dt.Rows[0][0].ToString();
            txtpresentval.Text = dt.Rows[0][1].ToString();
            txtcompltval.Text = dt.Rows[0][2].ToString();
            txtfsaleval.Text = dt.Rows[0][3].ToString();
            txtfireinsval.Text = dt.Rows[0][4].ToString();
            txtaccessroad.Text = dt.Rows[0][5].ToString();
            txtcomment.Text = dt.Rows[0][6].ToString();
            txtremarks.Text = dt.Rows[0][7].ToString();

            lblEditValDetailMsg.Text = "Edit data and Click Update";

            panelValuerEditReport.Visible = true;
        }
        else
        {
            panelValuerEditReport.Visible = false;
            lblEditValDetailMsg.Text = "Check your AppNo Again";
        }

    }
}
