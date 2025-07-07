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
using System.IO;

public partial class ShowAllValuersData : System.Web.UI.Page
{
    FunctionClass fc;
    DataTable dt;
    ValuerClass vc;

    protected void Page_Load(object sender, EventArgs e)
    {
        VerifyRenderingInServerForm(table1);
        gvallvaluersdetails.GridLines = GridLines.Both;  

        btnall.Visible = false;
        btnPrint.Visible = false;
        
        try
        {
            FunctionClass fc = new FunctionClass();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            string username = Session["userid"].ToString();
            string progname = "ShowAllValuersData.aspx";
            if (fc.IsValid(progname, username))
            {
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

        txtfrom.Focus();

    }
    protected void btnall_Click(object sender, EventArgs e)
    {
        fc = new FunctionClass();
        ValuerClass vc = new ValuerClass();
        DataTable dt = new DataTable();

        try
        {
            DateTime frm = fc.GetDate((txtfrom.Text));
            DateTime tto = fc.GetDate((txtto.Text));

            dt = vc.allValuersdetails(frm, tto);
            gvallvaluersdetails.DataSource = dt;
            gvallvaluersdetails.DataBind();

            lblac.Text = "Valuatioon Details are shown in the selected period";
        }
        catch (Exception error)
        {
            lblac.Text = "Wrong Date Range";
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        fc = new FunctionClass();

        DateTime fDate = fc.GetDate(txtfrom.Text);
        DateTime tDate = fc.GetDate(txtto.Text);

        string fpath = "";
        ReportDocument myReportDocument = new ReportDocument();
        ExportOptions ExOpt = new ExportOptions();
        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();

        string sFileName;
        sFileName = @"C:\test.pdf";

        fpath = Server.MapPath("~/Reports\\PrintValuationLedger.rpt");

        myReportDocument.Load(fpath);
        myReportDocument.SetDatabaseLogon("CreditAdmin", "ncms@36", "DB195", "T");

        diskOpts.DiskFileName = sFileName;
        ExOpt = myReportDocument.ExportOptions;
        ExOpt.ExportDestinationType = ExportDestinationType.DiskFile;
        ExOpt.ExportFormatType = ExportFormatType.PortableDocFormat;
        ExOpt.DestinationOptions = diskOpts;

        myReportDocument.SetParameterValue("@frmdate", fDate);
        myReportDocument.SetParameterValue("@todate", tDate);
        myReportDocument.Export();

        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.WriteFile(sFileName);
        Response.Flush();
        Response.Close();


    }

    protected void btnValLed_Click(object sender, EventArgs e)
    {
        fc = new FunctionClass();
        dt = new DataTable();
        vc = new ValuerClass();

        DateTime frm = fc.GetDate(txtfrom.Text.ToString());
        DateTime dateto = fc.GetDate(txtto.Text.ToString());

        dt = vc.ValuationLedger(frm, dateto);

        if (dt.Rows.Count > 0)
        {
            gvallvaluersdetails.DataSource = dt;
            gvallvaluersdetails.DataBind();
        }
        else
        {
            lblac.Text = "Please check you entered dates";
        }

    }
    protected void txtfrom_TextChanged(object sender, EventArgs e)
    {
        txtto.Focus();
    }
    protected void txtto_TextChanged(object sender, EventArgs e)
    {
        btnValLed.Focus();
    }
    protected void gvallvaluersdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvallvaluersdetails.PageIndex = e.NewPageIndex;

        fc = new FunctionClass();
        dt = new DataTable();
        vc = new ValuerClass();

        DateTime frm = fc.GetDate(txtfrom.Text.ToString());
        DateTime dateto = fc.GetDate(txtto.Text.ToString());

        dt = vc.ValuationLedger(frm, dateto);

        if (dt.Rows.Count > 0)
        {
            gvallvaluersdetails.DataSource = dt;
            gvallvaluersdetails.DataBind();
        }
        else
        {
            lblac.Text = "Please check you entered dates";
        }

    }
    protected void btnToExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
        Response.Charset = "";

        Response.ContentType = "application/vnd.xls";
        StringWriter StringWriter = new System.IO.StringWriter();
        HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);
        gvallvaluersdetails.RenderControl(HtmlTextWriter);        
        Response.Write(StringWriter.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that a Form control was rendered */
    }

}
