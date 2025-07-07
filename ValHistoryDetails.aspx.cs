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

public partial class ValHistoryDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string AppNo = Session["appno"].ToString();
        string fpath = "";
        ReportDocument myReportDocument = new ReportDocument();
        ExportOptions ExOpt = new ExportOptions();
        DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();

        string sFileName;
        sFileName = @"C:\test.pdf";

        fpath = Server.MapPath("~/Reports\\valuationhistorydetails.rpt");

        myReportDocument.Load(fpath);
        myReportDocument.SetDatabaseLogon("CreditAdmin", "ncms@36", "DB195", "TDb");

        diskOpts.DiskFileName = sFileName;
        ExOpt = myReportDocument.ExportOptions;
        ExOpt.ExportDestinationType = ExportDestinationType.DiskFile;
        ExOpt.ExportFormatType = ExportFormatType.PortableDocFormat;
        ExOpt.DestinationOptions = diskOpts;

        myReportDocument.SetParameterValue("@appno", AppNo);
        myReportDocument.Export();

        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.WriteFile(sFileName);
        Response.Flush();
        Response.Close();

        //try
        //{
        //    FunctionClass fc = new FunctionClass();
        //    string username = Session["userid"].ToString();
        //    string progname = "ValHistoryDetails.aspx";
        //    if (fc.IsValid(progname, username))
        //    {
        //        TextBox1.Focus();
        //    }
        //    else
        //    {
        //        Response.Redirect("login.aspx");
        //    }
        //}
        //catch
        //{
        //    Response.Redirect("login.aspx");
        //}
    }   
 
}
