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

public partial class ApplicationSubmission : System.Web.UI.Page
{
    private CheckListClass cc;
    private static string nicno, appno;
    private static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        {
            try
            {
                
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                nicno = Session["nicno"].ToString();
                string username = Session["userid"].ToString();
                string progname = "ApplicationSubmission.aspx";
                if (fc.IsValid(progname, username))
                {
                    cc = new CheckListClass();
                    
                    dt = cc.GetCustomerCheckList(nicno, "N");
                    if (dt.Rows.Count != 0)
                    {
                        dgvCheckList.DataSource = dt;
                        dgvCheckList.DataBind();
                        lblMsg.Text = "Please Edit the Copies if It Necessory";
                    }
                    else
                    {
                        lblMsg.Text = "Check List is not Given to the Customer Generate the Check List Before You Accept the Applications";
                    }
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
        appno = txtAppNo.Text;
        for(int i = 0; i<dt.Rows.Count;i++)
        {
            bool chk = bool.Parse(dt.Rows[i]["IsLatest"].ToString());
            if (chk)
            {
                int chklistno = int.Parse(dt.Rows[i]["chklistno"].ToString());
                string NoOfcopies = dt.Rows[i]["NoOfcopies"].ToString();
                rowAdded += cc.InsertAppSubmission(nicno, appno, chklistno, "S", NoOfcopies);
                btnPrint.Visible = true;
            }
            else
            {
                btnPrint.Visible = false;
            }
        }

        lblMsg.Text = rowAdded + " Documents are Submitted to Database";
    }

    
    protected void dgvCheckList_SelectedIndexChanged(object sender, EventArgs e)
    {
        
       
    }
    protected void txtAppNo_TextChanged(object sender, EventArgs e)
    {
        cc = new CheckListClass();
        if (cc.SearchApp(txtAppNo.Text, nicno) != "")
        {
            lblMsg.Text = appno + " Application number is Correct";
            btnSubmission.Visible = true;
            btnSubmission.Focus();
        }
        else
        {
            txtAppNo.Focus();
            lblMsg.Text = "Please Enter Correct Application Number";
            btnSubmission.Visible = false;
        }

    }

    protected void dgvCheckList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dgvCheckList.EditIndex = e.NewEditIndex;
        cc = new CheckListClass();
        //Data Bind
        dgvCheckList.DataSource = dt;
        dgvCheckList.DataBind();
        lblMsg.Text = "Edit Selected Item | To Calcel Edit Select Cancel";
    }
    protected void dgvCheckList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dgvCheckList.EditIndex = -1;
        dgvCheckList.DataSource = dt;
        dgvCheckList.DataBind();
        lblMsg.Text = "Edit Cancelled";
    }
    protected void dgvCheckList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string NoOfcopies = ((TextBox)dgvCheckList.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString();
        dt.Rows[e.RowIndex]["NoOfcopies"] = NoOfcopies.ToString();

        dgvCheckList.EditIndex = -1;
        dgvCheckList.DataSource = dt;
        dgvCheckList.DataBind();
        lblMsg.Text = "Submitted No of Copies " + NoOfcopies;
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
        myReportDocument.SetParameterValue("@DocumentStatus", "S");


        myReportDocument.Export();

        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.WriteFile(sFileName);
        Response.Flush();
        Response.Close(); 
    }
    protected void dgvCheckList_PageIndexChanged(object sender, EventArgs e)
    {
        dgvCheckList.DataSource = dt;
        dgvCheckList.DataBind();
    }
    protected void dgvCheckList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvCheckList.PageIndex = e.NewPageIndex;
        dgvCheckList.DataSource = dt;
        dgvCheckList.DataBind();
    }
}
