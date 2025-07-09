using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;

public partial class Administration_InsertPoliceSavings : System.Web.UI.Page
{
    Class1 cla;
    FunctionClass fc;
    DataTable dt = new DataTable();
    string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        fc = new FunctionClass();
        user = Session["userid"].ToString();
        string progname = "Administration/InsertPoliceSavings.aspx";
        if (fc.IsValid(progname, user))
        {
        }
        else
        {
            Response.Redirect("login.aspx");
        }

    }
    protected void txtappno_TextChanged(object sender, System.EventArgs e)
    {
        Class1 cla = new Class1();
        string appno = txtappno.Text;
        dgvpolicedeta.DataSource = cla.getcustomerdeta(appno);
        dgvpolicedeta.DataBind();
    }
    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        Class1 cla = new Class1();
        string appno = txtappno.Text;
        string savingsNo = txtsavingsno.Text;
        string cracno = txtcracno.Text;
        dt = cla.getcustomerdeta(appno);
        string branchcode = dt.Rows[0][1].ToString();

        cla.insertdate(appno, savingsNo, branchcode, DateTime.Now, user, cracno);
        lblmsg.Text = "Successfully Inserted....";
    }
}
