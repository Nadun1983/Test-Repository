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


public partial class RecoveryProcess : System.Web.UI.Page
{
    static string user;
    static DateTime processdate;
    RecoveryProcesClass rp;
    CrTransClass cc;
    LastSerialClass ls;
    FunctionClass fc;
    static int dateofrecprocess;
    protected void Page_Load(object sender, EventArgs e)
    {
        fc = new FunctionClass();
       if (!Page.IsPostBack)
        {
            try
            {
               
                user = Session["userid"].ToString();
                string progname = "RecoveryProcess.aspx";
                if (fc.IsValid(progname, user))
                {
                    ls = new LastSerialClass();

                    processdate = fc.GetSystemDate("A");
                    dateofrecprocess = fc.GetDateKeyinDate(processdate);
                    
                    if (dateofrecprocess >= ls.GetMaxNumber("LastRecProcessDate", true))
                    {
                        txtDateDue.Text = processdate.ToShortDateString();
                        lblMsg.Text = "Please Select the Date to Run the Recovery Payment set Process ";
                    }
                    else
                    {
                        ls.UpdateLastSerialStatus("LastRecProcessDate", true);
                        lblMsg.Text = "canoot continue with the given date";
                        btnConfirm.Visible = false;
                        btnRecoveryProcess.Visible = false;
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
    
    protected void btnRecoveryProcess_Click(object sender, EventArgs e)
    {
        // Need to  set the Entered Date (E0001)
        lblDateDue.Text = processdate.ToShortDateString();
        pnlConfDate.Visible = true;
        btnRecoveryProcess.Visible = false;
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        rp = new RecoveryProcesClass();
        string IsDisbursed = "Y";
        // Total Recovery Process
        int noofrec = 0;//rp.RecoveryProcess(processdate, user, IsDisbursed);

        lblMsg.Text = rp.Message;
        btnConfirm.Visible = false;
        btnRecoveryProcess.Visible = false;
        if (noofrec >= 0)
        {
            processdate.AddDays(1);
            ls = new LastSerialClass();
            ls.UpdateLastserial("LastRecProcessDate", dateofrecprocess + 1);
        }
    }
    protected void txtDateDue_TextChanged(object sender, EventArgs e)
    {
        if (DateTime.TryParse(txtDateDue.Text, out processdate))
        {
            // Date Updated
            lblMsg.Text = "Date is Changed by the user please verify the date before proceed";
        }
        else
        {
            lblMsg.Text = "Error in entered date formate please enter a corect date";
        }
    }
    protected void btnNPLTransaction_Click(object sender, EventArgs e)
    {

    }
}
