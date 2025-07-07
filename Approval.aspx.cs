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

public partial class Approval : System.Web.UI.Page
{
    ApprovalClass ac;
    ExistAppNos exApp; 
    DataTable dt;
    ExistLoanDetails ld;
    FunctionClass fc;
    decimal authorityamt = 0;
    DateTime Cdate = new DateTime();
    static int crcat = 0;
    string appno;

    private bool canDisburse = false;
    string status;
    string fpath = "";

  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    FunctionClass fc = new FunctionClass();
                    HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    string username = Session["userid"].ToString();
                    string progname = "Approval.aspx";
                    if (fc.IsValid(progname, username))
                    {
                        ac = new ApprovalClass();
                        appno = Session["appno"].ToString();
                        //crcat = ac.GetCrcat(appno);
                        grdArreasLoans.DataSource = ac.GetPreviousArreasLoanDetails(appno);
                        grdArreasLoans.DataBind();
                
                        status = ac.IsApproved(appno);
                        if (status != "A")
                        {
                            Panel1.Visible = true;
                            DataTable dt = new DataTable();
                            dt = ac.GetApprovalStatus(appno, false);
                            if (dt.Rows.Count != 0)
                            {
                                dtvApprovalStatus.DataSource = dt;
                                dtvApprovalStatus.DataBind();

                                grvAppDetails.DataSource = ac.GetApprovedPersonalDetails(appno);
                                grvAppDetails.DataBind();

                                status = ac.IsApproved(appno);
                                lblMsg.Text = "Please Check Process For Approval";
                            }
                            else
                            {
                                btnSetApproval.Visible = false;
                                //btnPrintFacilityPaper.Visible = false;
                                lblMsg.Text = "Enter Correct Application Number or Application is already disburesed";
                            }
                        }
                        else
                        {
                            Panel1.Visible = false;
                            lblMsg.Text = "Application Already Approved Continue with Disburcement Transfer by Clicking the Disbursement Button";
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
    }
    


    protected void btnCheckProcess_Click(object sender, EventArgs e)
     {
        string approveduser = Session["userid"].ToString();
        appno = Session["appno"].ToString();
        ac = new ApprovalClass();
        fc = new FunctionClass();
        status = ac.IsApproved(appno);
        crcat = ac.GetCrcat(appno);
        int PurposeCode = ac.PurposeCode(appno);
        DateTime currentdate = fc.GetSystemDate("A");

        CressWebScore.cressRating rating = new CressWebScore.cressRating();
        string score = rating.RatingData(appno);

        string rate = score.Substring(6, 4);

        if (rate != "null")
        {
            if ((crcat != 16) && (crcat != 19) && (crcat != 11)) //change 2011-08-15
            {
                int catpurposeid = ac.GetCatPurposeId(appno);
                if (catpurposeid == 59 || catpurposeid == 60)
                {
                    //ac = new ApprovalClass();
                    int rowupdated = 0;
                    rowupdated = ac.UpdateApprovalStatus("A", appno, currentdate, approveduser);
                    if (rowupdated != 0)
                    {
                        double approvedamt = ac.GetApprovdAmt(appno);
                        ac.UpdateCrApp("A", approvedamt, "Y", currentdate, approveduser, appno);
                        dtvApprovalStatus.DataSource = ac.GetApprovalStatus(appno, true);
                        dtvApprovalStatus.DataBind();
                        lblMsg.Text = "Application Accepted";

                    }
                    else
                    {
                        lblMsg.Text = "Error in Application acceptance";
                    }
                }
                if (crcat == 5 && PurposeCode == 11)
                {
                    int rowupdated = 0;
                    rowupdated = ac.UpdateApprovalStatus("A", appno, currentdate, approveduser);
                    if (rowupdated != 0)
                    {
                        string receivedUser = ac.GetReceivedAppUser(appno);
                        double approvedamt = ac.GetApprovdAmt(appno);
                        ac.InsertintoSpecialApproval(appno, receivedUser, approveduser, Convert.ToDateTime(DateTime.Now.ToString()), currentdate, approvedamt,
                            "Special Approval has Given by Snr.DGM Mr.Dhammika Perera");
                        ac.UpdateCrApp("A", approvedamt, "Y", currentdate, approveduser, appno);
                        dtvApprovalStatus.DataSource = ac.GetApprovalStatus(appno, true);
                        dtvApprovalStatus.DataBind();
                        lblMsg.Text = "Application Accepted given by Special Approval";
                        //Session["appno"] = _appno;
                        //Response.Redirect("~/ToDisburse.aspx");
                    }
                    else
                    {
                        lblMsg.Text = "Error in Application acceptance";
                    }
                }
                else
                {
                    switch (status)
                    {
                        case "":
                            lblMsg.Text = "Cannnot Approve the Application Fields not Completed";
                            break;

                        case "N":
                            ac = new ApprovalClass();
                            int rowupdated = 0;
                            rowupdated = ac.UpdateApprovalStatus("A", appno, currentdate, approveduser);
                            if (rowupdated != 0)
                            {
                                double approvedamt = ac.GetApprovdAmt(appno);
                                ac.UpdateCrApp("A", approvedamt, "Y", currentdate, approveduser, appno);
                                dtvApprovalStatus.DataSource = ac.GetApprovalStatus(appno, true);
                                dtvApprovalStatus.DataBind();
                                lblMsg.Text = "Application Accepted";
                                //Session["appno"] = _appno;
                                //Response.Redirect("~/ToDisburse.aspx");
                            }
                            else
                            {
                                lblMsg.Text = "Error in Application acceptance";
                            }
                            break;

                        case "A":
                            lblMsg.Text = "Application Already Approved";
                            Session["appno"] = appno;
                            break;
                    }
                }
            }
            else
            {
                ac = new ApprovalClass();
                int rowupdated = 0;
                rowupdated = ac.UpdateApprovalStatus("A", appno, currentdate, approveduser);
                if (rowupdated != 0)
                {
                    double approvedamt = ac.GetApprovdAmt(appno);
                    ac.UpdateCrApp("A", approvedamt, "Y", currentdate, approveduser, appno);
                    dtvApprovalStatus.DataSource = ac.GetApprovalStatus(appno, true);
                    dtvApprovalStatus.DataBind();
                    lblMsg.Text = "Application Accepted";

                }
                else
                {
                    lblMsg.Text = "Error in Application acceptance";
                }
            }
        }
        else
        {
            DateTime RecvDate = ac.GetReceivedDate(appno);
            DateTime fixedDate = DateTime.Parse("2017/10/15");
            if (RecvDate > fixedDate)
            {
                lblMsg.Text = "Please enter the Credit Score in CRESS";
            }
            else
            {
                if ((crcat != 16) && (crcat != 19) && (crcat != 11)) //change 2011-08-15
                {
                    int catpurposeid = ac.GetCatPurposeId(appno);
                    if (crcat == 19 && (catpurposeid == 59 || catpurposeid == 60))
                    {
                        //ac = new ApprovalClass();
                        int rowupdated = 0;
                        rowupdated = ac.UpdateApprovalStatus("A", appno, currentdate, approveduser);
                        if (rowupdated != 0)
                        {
                            double approvedamt = ac.GetApprovdAmt(appno);
                            ac.UpdateCrApp("A", approvedamt, "Y", currentdate, approveduser, appno);
                            dtvApprovalStatus.DataSource = ac.GetApprovalStatus(appno, true);
                            dtvApprovalStatus.DataBind();
                            lblMsg.Text = "Application Accepted";

                        }
                        else
                        {
                            lblMsg.Text = "Error in Application acceptance";
                        }
                    }
                    if (crcat == 5 && PurposeCode == 11)
                    {
                        int rowupdated = 0;
                        rowupdated = ac.UpdateApprovalStatus("A", appno, currentdate, approveduser);
                        if (rowupdated != 0)
                        {
                            string receivedUser = ac.GetReceivedAppUser(appno);
                            double approvedamt = ac.GetApprovdAmt(appno);
                            ac.InsertintoSpecialApproval(appno, receivedUser, approveduser, Convert.ToDateTime(DateTime.Now.ToString()), currentdate, approvedamt,
                                "Special Approval has Given by Snr.DGM Mr.Dhammika Perera");
                            ac.UpdateCrApp("A", approvedamt, "Y", currentdate, approveduser, appno);
                            dtvApprovalStatus.DataSource = ac.GetApprovalStatus(appno, true);
                            dtvApprovalStatus.DataBind();
                            lblMsg.Text = "Application Accepted given by Special Approval";
                            //Session["appno"] = _appno;
                            //Response.Redirect("~/ToDisburse.aspx");
                        }
                        else
                        {
                            lblMsg.Text = "Error in Application acceptance";
                        }
                    }
                    else
                    {
                        switch (status)
                        {
                            case "":
                                lblMsg.Text = "Cannnot Approve the Application Fields not Completed";
                                break;

                            case "N":
                                ac = new ApprovalClass();
                                int rowupdated = 0;
                                rowupdated = ac.UpdateApprovalStatus("A", appno, currentdate, approveduser);
                                if (rowupdated != 0)
                                {
                                    double approvedamt = ac.GetApprovdAmt(appno);
                                    ac.UpdateCrApp("A", approvedamt, "Y", currentdate, approveduser, appno);
                                    dtvApprovalStatus.DataSource = ac.GetApprovalStatus(appno, true);
                                    dtvApprovalStatus.DataBind();
                                    lblMsg.Text = "Application Accepted";
                                    //Session["appno"] = _appno;
                                    //Response.Redirect("~/ToDisburse.aspx");
                                }
                                else
                                {
                                    lblMsg.Text = "Error in Application acceptance";
                                }
                                break;

                            case "A":
                                lblMsg.Text = "Application Already Approved";
                                Session["appno"] = appno;
                                break;
                        }
                    }
                }
                else
                {
                    ac = new ApprovalClass();
                    int rowupdated = 0;
                    int rowpayment = 0;
                    rowpayment = ac.GetPaymentRowCount(appno);
                    if (rowpayment != 0)
                    {
                        rowupdated = ac.UpdateApprovalStatus("A", appno, currentdate, approveduser);
                        if (rowupdated != 0)
                        {
                            double approvedamt = ac.GetApprovdAmt(appno);
                            ac.UpdateCrApp("A", approvedamt, "Y", currentdate, approveduser, appno);
                            dtvApprovalStatus.DataSource = ac.GetApprovalStatus(appno, true);
                            dtvApprovalStatus.DataBind();
                            lblMsg.Text = "Application Accepted";

                        }
                        else
                        {
                            lblMsg.Text = "Error in Application acceptance";
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Please take payment";
                    }
                }
            }
        }

    }

    private void DisbursementProcess(string appno)
    {
        ac = new ApprovalClass();
        long cracno;
        cracno = ac.GetCrAcNo("CRACNO", true);



        // Insert Records to Old Tables

        bool isfiletransfer = false;

        isfiletransfer = true;

        if (isfiletransfer)
        {
            if (ac.UpdateCracStatus("SerialDesc", true) != 0)
            {

                lblMsg.Text = "File Trnsfer Succesfully Completed";
            }
            else
            {
                lblMsg.Text = "File Trnsfer Succesfully Completed Last Serial Not Updated";
            }
        }
        else
        {
            lblMsg.Text = "Error in File Tranfering Contact System Administrator";
        }

    }





  
}