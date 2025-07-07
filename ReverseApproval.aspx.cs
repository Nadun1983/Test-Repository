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

public partial class ReverseApproval : System.Web.UI.Page
{

    ApprovalClass ac;
    private static string status;
    private static bool isToDisburse;
    private string appno;
    int crcat;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                string username = Session["userid"].ToString();
                string progname = "ReverseApproval.aspx";
                if (fc.IsValid(progname, username))
                {
                    txtAppNo.Focus();
                    btnReverse.Visible = false;
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
    protected void txtAppNo_TextChanged(object sender, EventArgs e)
    {
        ac = new ApprovalClass();
        //2010/07/16 line 2
        //crcat = ac.GetCrCatCode(appno);
        status = ac.IsApproved(txtAppNo.Text); //,crcat);
        isToDisburse = ac.IsDisbursed(txtAppNo.Text);

        if (status == "A")
        {
            if (isToDisburse == true)
            {
                btnReverse.Visible = false;
                lblError.Text = "Can't Reverse. You have already disbursed the Application";
            }
            else
            {
                btnReverse.Visible = true;
            }
        }
        else
        {
            lblError.Text = "Can't Reverse. You still haven't Approved the Application";
        }

    }
    protected void btnReverse_Click(object sender, EventArgs e)
    {
        ac = new ApprovalClass();
        if (ac.UpdateReverseApplicatin(txtAppNo.Text, "N", DateTime.Now) != 0)
        {
            lblError.Text = "You have successfully Reverse the Approval";
        }
        else
        {
            lblError.Text = "Error updating reversal";
        }
    }
}
