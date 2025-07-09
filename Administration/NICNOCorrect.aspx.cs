using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Administration_NICNOCorrect : System.Web.UI.Page
{
    Recovery rc;
    DataTable dt;
    AdminClass ac;
    FunctionClass fc;

    protected void Page_Load(object sender, EventArgs e)
    {
        fc = new FunctionClass();
        string user = Session["userid"].ToString();
        string progname = "Administration/NICNOCorrect.aspx";
        if (fc.IsValid(progname, user))
        {
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void tbCracno_TextChanged(object sender, EventArgs e)
    {
        //Load Customer details
        rc = new Recovery();
        string cracno = tbCracno.Text;
        dt = new DataTable();
        dt = rc.GetCustomerdetails(cracno);
        dgvCustDetails.DataSource = dt;
        dgvCustDetails.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ac = new AdminClass();
        dt = new DataTable();
        rc = new Recovery();

        string cracno = tbCracno.Text;
        string changeuser = Session["userid"].ToString();
        DataTable tdt = rc.GetCustomerdetailsAppno(cracno);
        string appno = tdt.Rows[0]["appno"].ToString();
        string newnicno = tbNicno.Text;
        string holdrelation = rbHolderRelation.SelectedValue.ToString();

        //Update AppHolder
        ac.UpdateCorrectedNICAppHolder(appno, newnicno, holdrelation,changeuser);
        //Update CrHolder
        ac.UpdateCorrectedNICCrHolder(appno, newnicno, holdrelation, changeuser);


        //Show updated details
        dt = rc.GetCustomerdetails(cracno);
        dgvCustDetailsUpdated.DataSource = dt;
        dgvCustDetailsUpdated.DataBind();
    }
}
