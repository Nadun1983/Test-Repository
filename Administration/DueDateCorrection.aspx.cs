using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Recovery_DueDateCorrection : System.Web.UI.Page
{
    Corrections cs;
    RecoveryProcesClass rpc;
    static string cracno;
    FunctionClass fc;
    DataTable dt1, dt2;
    string user;

    protected void Page_Load(object sender, EventArgs e)
    {

        fc = new FunctionClass();
        user = Session["userid"].ToString();
        string progname = "Administration/DueDateCorrection.aspx";
        if (fc.IsValid(progname, user))
        {
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }    

    protected void btnCorrect_Click(object sender, EventArgs e)
    {
        dt2 = new DataTable();    
        cs = new Corrections();
        rpc = new RecoveryProcesClass();
        DateTime datedue, lastcompleteddatedue;
        DataTable dt = new DataTable();
        dt = rpc.GetBaseRecords(cracno);
        datedue = DateTime.Parse(dt.Rows[0]["datedue"].ToString());
        lastcompleteddatedue = DateTime.Parse(dt.Rows[0]["lastcompletedduedate"].ToString());

        cracno = txtLoanNo.Text.ToString();
        cs.SetTransDateDue(cracno);
        cs.InsertIntoDueDateCorrection(DateTime.Now, cracno, datedue, lastcompleteddatedue, user, "Transaction Record");
        dt2 = cs.GetTransassignData(cracno);
        dgvNewTransaction.DataSource = dt2;
        dgvNewTransaction.DataBind();
    }
    protected void btnCorrectHousProp_Click(object sender, EventArgs e)
    {
        
        dt1 = new DataTable();
        cs = new Corrections(); rpc = new RecoveryProcesClass();
        DateTime datedue, lastcompleteddatedue;
        fc = new FunctionClass();

        DataTable dt = new DataTable();
        dt = rpc.GetBaseRecords(cracno);
        datedue = DateTime.Parse(dt.Rows[0]["datedue"].ToString());
        lastcompleteddatedue = DateTime.Parse(dt.Rows[0]["lastcompletedduedate"].ToString());

        rpc = new RecoveryProcesClass();
        rpc.SetDateDue(cracno, datedue, lastcompleteddatedue);
        cs.InsertIntoDueDateCorrection(DateTime.Now, cracno, datedue, lastcompleteddatedue, user, "Master Record");

        dt1 = cs.GetHouspropData(cracno);
        dgvNewhousDetails.DataSource = dt1;
        dgvNewhousDetails.DataBind();
    }

    protected void txtLoanNo_TextChanged(object sender, EventArgs e)
    {
        cracno = txtLoanNo.Text.ToString();

        dt1 = new DataTable();
        dt2 = new DataTable();
        cs = new Corrections();

        cs.SetTransDateDue(cracno);

        dt1 = cs.GetHouspropData(cracno);
        dt2 = cs.GetTransassignData(cracno);

        dgvExHousDetails.DataSource = dt1;
        dgvExHousDetails.DataBind();

        dgvExTransactionDetails.DataSource = dt2;
        dgvExTransactionDetails.DataBind();
    }
}
