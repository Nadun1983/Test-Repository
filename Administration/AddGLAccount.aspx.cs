using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Drawing;

public partial class Administration_AddGLAccount : System.Web.UI.Page
{
    private string constring = ConfigurationManager.ConnectionStrings["housdbString"].ToString();
    GlCodesGenerator gcg;
    DataWorksClass dw;

    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    protected void btnChkAvailability_Click(object sender, EventArgs e)
    {
        string taskid = tbGltaskID.Text;
        gcg = new GlCodesGenerator();

        bool gltaskavailability = false; //True if available
        gltaskavailability = gcg.GetGLTaskNames(taskid);

        if (taskid.Length != 4)
        {
            lblTaskStatus.Text = "Task ID length sould 4 !";
            lblTaskStatus.ForeColor = Color.Red;
            btnUpdate.Visible = false;
        }
        else
        {
            if (gltaskavailability == false)
            {
                lblTaskStatus.Text = "Task ID " + tbGltaskID.Text.ToUpper() + " is available to continue......";
                lblTaskStatus.ForeColor = Color.Green;

                btnUpdate.Visible = true;
            }
            else
            {
                lblTaskStatus.Text = "Task ID is not available to continue. Please enter different ID !";
                lblTaskStatus.ForeColor = Color.Red;

                btnUpdate.Visible = false;
            }
        }

    }
    protected void tbGltaskID_TextChanged(object sender, EventArgs e)
    {
        btnChkAvailability_Click(sender, e);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        string TaskId = tbGltaskID.Text.ToUpper();
        int branchid = int.Parse(ddlBranchCode.SelectedValue);
        string ListOrder = "0";
        string IsGLAccount = "True";
        string TransRef = ddlTransRef.SelectedValue;
        string Description = tbDescription.Text;
        string CategoryId = int.Parse(ddlCategory.SelectedValue).ToString("0");
        string Status = "0";
        string ValueType = "0";
        string Types = "0";
        string UnitCharge = "0";
        string PriorityList = "0";
        string BasedOnLoans = rblBasedonLoans.SelectedValue;
        string BasedOnStatus = rblBasedonStatus.SelectedValue;
        string BasedOnIncome = rblBasedonIncome.SelectedValue;

        gcg = new GlCodesGenerator();
        DataTable dt = new DataTable();
        dt = gcg.GetNewTranscatData(TaskId, ListOrder, IsGLAccount, TransRef, Description, CategoryId, Status, ValueType, Types, UnitCharge,
                PriorityList, BasedOnLoans, BasedOnStatus, BasedOnIncome);

        dw = new DataWorksClass(constring);
        dw.SetCommand();
        dw.InsertBulk(dt, "transcat");
        int serialno = gcg.GenerateLOanSerial(int.Parse(CategoryId), TaskId, Description, TransRef);

        string textmsg = gcg.GenerateGLCodes(serialno, Description, TaskId, branchid.ToString("0000"), CategoryId, Status,  ddlBranchCode.SelectedItem.ToString().Trim(), ddlCategory.SelectedItem.ToString().Trim(), rblBasedonLoans.SelectedItem.ToString(), rblBasedonStatus.SelectedItem.ToString(), "");
        lblError.Text = textmsg;
        btnUpdate.Visible = false;
    }
}
