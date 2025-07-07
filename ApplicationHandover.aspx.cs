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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class ApplicationHandover : System.Web.UI.Page
{
    static string  nicno;
    static string appno;
    static DataTable dt = new DataTable();
    CheckListClass cc;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string username = Session["userid"].ToString();
                string progname = "ApplicationHandover.aspx";
                cc = new CheckListClass();
                if (fc.IsValid(progname, username))
                {
                    nicno = Session["nicno"].ToString();
                    ddlAppNo.DataSource = cc.GetApplicationNo(nicno);
                    ddlAppNo.DataTextField = "AppNo";
                    ddlAppNo.DataValueField = "AppNo";
                    ddlAppNo.DataBind();

                    appno = ddlAppNo.Text.ToString();
                    dt = cc.GetApplicationSubmission(nicno, appno, "S");
                    dgvCheckList.DataSource = dt;
                    dgvCheckList.DataBind();

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

    protected void btnSubmission_Click(object sender, EventArgs e)
    {
        cc = new CheckListClass();
        int rowAdded = 0;
        appno = ddlAppNo.SelectedValue.ToString();

        rowAdded = cc.UpdateDucumentSubmission(appno, nicno, "S", "H");
        if (rowAdded != 0)
        {
            btnPrint.Visible = true;
            lblMsg.Text = rowAdded + " Documents are HAnded Over to the Customer";
        }
        else
        {
            btnPrint.Visible = false;
            lblMsg.Text = "Error In Handing over";
        }


    }
    protected void ddlAppNo_SelectedIndexChanged(object sender, EventArgs e)
    {
       dt.Clear();
       appno =  ddlAppNo.SelectedValue.ToString();
       cc = new CheckListClass();
       dt = cc.GetApplicationSubmission(nicno, appno, "S");
       dgvCheckList.DataSource = dt;
       dgvCheckList.DataBind();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ReportDocument myReportDocument = new ReportDocument();

        ExportOptions ExOpt = new ExportOptions();
        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();

        string sFileName;
        sFileName = @"C:\a.pdf";
        string fPath = Server.MapPath("Reports/DocumentSubmission.rpt");

        myReportDocument.Load(fPath);
        myReportDocument.SetDatabaseLogon("CreditAdmin", "ncms@36", "DB195", "NewCreditDb", false);

        diskOpts.DiskFileName = sFileName;
        ExOpt = myReportDocument.ExportOptions;
        ExOpt.ExportDestinationType = ExportDestinationType.DiskFile;
        ExOpt.ExportFormatType = ExportFormatType.PortableDocFormat;
        ExOpt.DestinationOptions = diskOpts;

        myReportDocument.SetParameterValue("@nicno", nicno);
        myReportDocument.SetParameterValue("@appno", appno);
        myReportDocument.SetParameterValue("@DocumentStatus", "H");


        myReportDocument.Export();

        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.WriteFile(sFileName);
        Response.Flush();
        Response.Close(); 
    }
}
