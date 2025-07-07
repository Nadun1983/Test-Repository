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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class ValuerPayment : System.Web.UI.Page
{

    SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["housdbString"].ConnectionString);
   
    static DateTime toDate, fromDate;
    //decimal totval = 0;
    DataTable dt;
    valuerpayments vp;
    FunctionClass fc;
    LastSerialClass ls;

    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Visible = false;

        if (Page.IsPostBack != true)
        {


            if (!Page.IsPostBack)
            {
                try
                {
                    FunctionClass fc = new FunctionClass();
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    string username = Session["userid"].ToString();
                    string progname = "ValuerPayment.aspx";
                    if (fc.IsValid(progname, username))
                    {
                        ValuerClass vc = new ValuerClass();
                        //DataTable dt = new DataTable();
                        dt = vc.GetAllValuersName();
                        ddlvaluersnames.DataSource = dt;
                        ddlvaluersnames.DataTextField = "FullName";
                        ddlvaluersnames.DataValueField = "ValuerId";
                        ddlvaluersnames.DataBind();
                        txtfrom.Focus();
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
    }
   
    protected void btn10comision_Click(object sender, EventArgs e)
    {
        Response.Redirect("Commisionvaluerpayment.aspx");
    }
    protected void btnPrntValRec_Click(object sender, EventArgs e)
    {
        fc = new FunctionClass();
        DateTime DTimeFrm = fc.GetDate((txtfrom.Text));
        DateTime DTimeTo = fc.GetDate(txtto.Text);
        int CompaanyID = Int32.Parse((ddlvaluersnames.SelectedIndex.ToString()));

        string fpath = "";
        ReportDocument myReportDocument = new ReportDocument();
        ExportOptions ExOpt = new ExportOptions();
        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();

        string sFileName;
        sFileName = @"C:\test.pdf";

        fpath = Server.MapPath("~/Reports\\ValuerPaymentList.rpt");

        myReportDocument.Load(fpath);
        myReportDocument.SetDatabaseLogon("CreditAdmin", "ncms@36", "DB195", "T");

        diskOpts.DiskFileName = sFileName;
        ExOpt = myReportDocument.ExportOptions;
        ExOpt.ExportDestinationType = ExportDestinationType.DiskFile;
        ExOpt.ExportFormatType = ExportFormatType.PortableDocFormat;
        ExOpt.DestinationOptions = diskOpts;

        myReportDocument.SetParameterValue("@valid", CompaanyID);
        myReportDocument.SetParameterValue("@frmd", DTimeFrm);
        myReportDocument.SetParameterValue("@tday", DTimeTo);
        myReportDocument.SetParameterValue("commisionpay", txt10pval.Text);
        myReportDocument.SetParameterValue("totpay", txtvalupayment.Text);
        myReportDocument.Export();

        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.WriteFile(sFileName);
        Response.Flush();
        Response.Close();

    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        //Execute checkprint function()

        //Get Maximum Transaction number       
        vp = new valuerpayments();
        ls = new LastSerialClass();
        fc = new FunctionClass();
        DateTime ValSendDate = System.DateTime.Now;
        string SerialDesc = "OPTransactionID";
        long MaxTransNum = 0;

        //Amila
        MaxTransNum = ls.GetMaxNumber(SerialDesc, true);

        long TransactionNo = 0;
        TransactionNo = MaxTransNum + 1;

        //update the table(valuation and OutsidePayments) saying payed to the valuer

        int id = Convert.ToInt32(ddlvaluersnames.SelectedIndex.ToString());
        vp = new valuerpayments();
        DateTime PaymentDate = System.DateTime.Now;
        string Paymenttype="V";

        decimal ValuerPayment = decimal.Parse(txtvalupayment.Text);
        int Outsidepaymentupdate = vp.UpdateOutSidePayment(TransactionNo, ValuerPayment,PaymentDate, Paymenttype);
        if (Outsidepaymentupdate > 0)
        {
            DateTime PaidDate = System.DateTime.Now;
            int rowupdated = vp.PaydToValuer(id, fc.GetDate(txtfrom.Text), fc.GetDate(txtto.Text), PaidDate, TransactionNo);

            //Amila
            int UpdateLS = ls.UpdateLastserial(TransactionNo.ToString(), long.Parse(SerialDesc));
            if ((rowupdated > 0) && (UpdateLS > 0))
            {
                lblMsg.Text = "Successfully Paid to the valuer";
            }
            else
            {
                lblMsg.Text = "An Error Please Don't Print the Cheque";
            }
        }
        else
        {
            lblMsg.Text = "Invalid Payment to outsider";
        }
    }

    protected void ddlvaluersnames_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(ddlvaluersnames.SelectedValue.ToString());
        fc = new FunctionClass();

        DateTime fDate = fc.GetDate(txtfrom.Text);
        DateTime tDate = fc.GetDate(txtto.Text);

        vp = new valuerpayments();
        
        dt = vp.totvalfee(id, fDate, tDate);
        GridView1.DataSource = dt;
        GridView1.DataBind();


        Panel1.Visible = true;
                
        string value="";
        if (dt.Rows.Count > 0)
        {
            value = dt.Rows[0][0].ToString();

            if (vp.IsCalCommision(id))  //Calculate 10% Commision and Deduct From the Valuer.
            {
                if ((value != "") || (value != "0"))
                {
                    Decimal totval;
                    totval = Convert.ToDecimal(value);
                    txttotval.Text = totval.ToString();

                    txttottransval.Text = dt.Rows[0][1].ToString();

                    decimal tenval;
                    tenval = ((totval * 10) / 100);
                    txt10pval.Text = tenval.ToString();

                    decimal totvalpay = ((totval - tenval) + (Convert.ToDecimal(dt.Rows[0][1])));
                    txtvalupayment.Text = totvalpay.ToString();
                    Panel1.Visible = true;
                    lblMsg.Text = ddlvaluersnames.SelectedItem.Text + "is Selected";
                    txtchno.Focus();
                }
                else
                {
                    lblMsg.Text = "No payment to Display";
                }
            }
            else //Without Calculate 10% Commision
            {
                Decimal totval = new Decimal();
                totval = Convert.ToDecimal(value);
                txttotval.Text = totval.ToString();

                txttottransval.Text = dt.Rows[0][1].ToString();

                decimal tenval = 0;
                txt10pval.Text = tenval.ToString();

                decimal totvalpay = ((totval - tenval) + (Convert.ToDecimal(dt.Rows[0][1])));
                txtvalupayment.Text = totvalpay.ToString();
                Panel1.Visible = true;
                lblMsg.Text = ddlvaluersnames.SelectedItem.Text + "is Selected";
                txtchno.Focus();
            }
        }

        else
        {
            
            Panel1.Visible = false;
            lblMsg.Text = "No Payments to Display";
        }        
           
            
    }
    protected void txtfrom_TextChanged(object sender, EventArgs e)
    {
        fc = new FunctionClass();
        fromDate = new DateTime();
        fromDate = fc.GetDate(txtfrom.Text);
        txtto.Focus();
    }
    protected void txtto_TextChanged(object sender, EventArgs e)
    {
        fc = new FunctionClass();
        toDate = new DateTime();
        toDate = fc.GetDate(txtto.Text);
        ddlvaluersnames.Focus();
    }
    protected void GridView1_PageIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(ddlvaluersnames.SelectedValue.ToString());
        fc = new FunctionClass();

        DateTime fDate = fc.GetDate(txtfrom.Text);
        DateTime tDate = fc.GetDate(txtto.Text);

        vp = new valuerpayments();
        GridView1.DataSource = vp.valfee(id, fDate, tDate);
        GridView1.DataBind();
       
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }


    //vihanga for testing 2008-12-18

    protected void Button1_Click(object sender, EventArgs e)
    {
        fc = new FunctionClass();

        //vihanga variable

        int valuerid = 4;
        decimal amount = 2500;
        string Sentence = "To the credit of";
        string amountinword1 = "Two thousand five hundred";
        string amountinword2 = "ninety five rupees only";        


        string fpath = "";
        ReportDocument myReportDocument = new ReportDocument();
        ExportOptions ExOpt = new ExportOptions();
        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();

        string sFileName;
        sFileName = @"C:\test.pdf";

        fpath = Server.MapPath("~/Reports\\valuerCheque.rpt");

        myReportDocument.Load(fpath);
        myReportDocument.SetDatabaseLogon("CreditAdmin", "ncms@36", "DB195", "T");


        diskOpts.DiskFileName = sFileName;
        ExOpt = myReportDocument.ExportOptions;
        ExOpt.ExportDestinationType = ExportDestinationType.DiskFile;
        ExOpt.ExportFormatType = ExportFormatType.PortableDocFormat;
        ExOpt.DestinationOptions = diskOpts;

        myReportDocument.SetParameterValue("@valuerId", valuerid);
        myReportDocument.SetParameterValue("@amount", amount);
        myReportDocument.SetParameterValue("@Sentence", Sentence);
        myReportDocument.SetParameterValue("@amountinword1", amountinword1);
        myReportDocument.SetParameterValue("@amountinword2", amountinword2);
       
        myReportDocument.Export();

        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.WriteFile(sFileName);
        Response.Flush();
        Response.Close();
    }
}
