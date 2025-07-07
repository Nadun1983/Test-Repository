using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;


public partial class valuation : System.Web.UI.Page 
{
    SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["housdbString"].ConnectionString);
    ValuerClass vc;
    valuerpayments vp;
    static string appno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string username = Session["userid"].ToString();
                string progname = "valuation.aspx";
                if (fc.IsValid(progname, username))
                {
                    vp = new valuerpayments();
                    vc = new ValuerClass();
                    ValuationFunctions vf = new ValuationFunctions();
                    DataTable dt = new DataTable();
                    appno = Session["AppNo"].ToString();

                    dt = vf.ValuationReportDetails(appno);
                    if (dt.Rows.Count != 0)
                    {
                        dgvAsseginedValuer.DataSource = dt;
                        dgvAsseginedValuer.DataBind();
                    }
                    else
                    {
                        lblmsg1.Text = " Valuer not Assign yet ";
                    }


                    ddldist.DataSource = vc.GetDistictList();
                    ddldist.DataTextField = "DistName";
                    ddldist.DataValueField = "DistCode";
                    ddldist.DataBind();
                    ddldist.Focus();
                    lblmsg1.Text += "Please Select the District ";


                    ddlvaluer.DataSource = vc.GetValuer(1);
                    ddlvaluer.DataTextField = "ValuerName";
                    ddlvaluer.DataValueField = "valuerid";
                    ddlvaluer.DataBind();
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
    public void clearlabel()
    {
        lblmsg1.Visible = false;       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("receievevaluation.aspx");
    }    
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("valuationsendletter.aspx");
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        DataTable CheckValPayment;
        ValuerClass vc;
        decimal ValuerFee = 0;
        decimal TrportFee = 0;
        decimal CommisFee = 0;
        double tempCommision = 0;
        int count = 0;
        string type;

        //Check weather the APPNO is an exsisting APPNO
        vc = new ValuerClass();
        bool alreadyappnoexis = vc.checkexisappno(appno);

        if (alreadyappnoexis) //if there is  exsisting record to the appno
        {
            lblmsg1.Text = "A Valuer is already assigned for the Valuation";
            lblmsg1.Visible = true;
        }
        else
        {   
            //get check payments
            long AppNo = Int64.Parse(Session["AppNo"].ToString());
            CheckValPayment = vc.CheckPayedForValuation(AppNo);
            count = CheckValPayment.Rows.Count;

            if (count > 0)
            {

                ValuerFee = decimal.Parse(CheckValPayment.Rows[0][1].ToString());
                TrportFee = decimal.Parse(CheckValPayment.Rows[1][1].ToString());
                tempCommision = (double.Parse(CheckValPayment.Rows[0][1].ToString())) * 0.1;
                CommisFee = decimal.Parse(tempCommision.ToString());
                type = CheckValPayment.Rows[0][0].ToString();


                DateTime senddate = System.DateTime.Now;
                string valuerid = ddlvaluer.SelectedValue.ToString();
                string valuerType = vc.getValuerType(valuerid);
                ValuerClass vclas = new ValuerClass();
                string hide = "H";
                string status = "A";
                string AddUser = Session["userid"].ToString();
                int updatelevel = -100;
                string IsTrPortPd = "N";
                string IsValuerPd = "N";
                string IsCommisPaid = "N";
                string IsGovtPaid = "N";
                string IsExpTrPaid = "N";
                string IsExpValuerPd = "N";

                vc.InsertValersDetails(appno, Convert.ToInt32(valuerid), senddate, hide, status, AddUser, senddate, updatelevel,
                                       IsTrPortPd, IsValuerPd, IsCommisPaid, IsGovtPaid, IsExpTrPaid, IsExpValuerPd, ValuerFee, TrportFee, CommisFee, type, valuerType);
                lblmsg1.Text = ddlvaluer.DataTextField + " is successfully assigned to Application" + appno;
            }
            else
            {
                lblmsg1.Text = "Payment Not Made";
            }
        }
    }

    protected void btnentervaluationdetails_Click(object sender, EventArgs e)
    {
        if (true)
        {
            Response.Redirect("EnterValuationReportDetails.aspx");
        }
        else
        {
            //give some error msg
        }
    }
    protected void btnedit_Click1(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConfidentialLt.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("ValuerPayment.aspx");
    }
    protected void btnallvaluersdata_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShowAllValuersData.aspx");
    }
    protected void btncompay_Click(object sender, EventArgs e)
    {
        Response.Redirect("Commisionvaluerpayment.aspx");
    }
    protected void btnaddedit_Click(object sender, EventArgs e)
    {
        Response.Redirect("ValersProfile.aspx");
    }
    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {
        int distCode = Convert.ToInt32(ddldist.SelectedValue.ToString());
        vc = new ValuerClass();
        ddlvaluer.DataSource = vc.GetValuer(distCode);
        ddlvaluer.DataTextField = "ValuerName";
        ddlvaluer.DataValueField = "valuerid";
        ddlvaluer.DataBind();
        lblmsg1.Text = "Selected District is " + ddldist.SelectedItem.Text.ToString() + ", Now Select the Valuer";
        ddlvaluer.Focus();
    }
    protected void ddlvaluer_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        lblmsg1.Text = "Selected District and Valuer Name are " + ddldist.SelectedItem.Text.ToString() + " and " + ddlvaluer.SelectedItem.Text.ToString();
        btnsave.Focus();
    }
}
