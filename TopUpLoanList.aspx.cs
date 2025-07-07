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

public partial class TopUpLoanList : System.Web.UI.Page
{
    ArreasLetters ar;
    FunctionClass fc;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        ArreasLetters ar = new ArreasLetters();
        dt = ar.getloanlist();
        dgvtopuploans.DataSource = dt;
        dgvtopuploans.DataBind();
    }
    protected void txtto_TextChanged(object sender, EventArgs e)
    {
        DailyAnalisis da = new DailyAnalisis();
        fc = new FunctionClass();
        PrintClass p = new PrintClass();
        DataTable dt = new DataTable();
        string accountfrom = txtfrom.Text;
        string accountto = txtto.Text;
        string fpath = Server.MapPath("~/Reports/Topuploanslist.rpt");
        string file = Server.MapPath("~/Reports/a.pdf");

        p.SetConnection(fpath, file, "CreditAdmin", "ncms@36", "DB195", "TDb");

        p.SetParams("accountfrom", accountfrom);
        p.SetParams("accountto", accountto);
        p.GetPdfReport(Response);

        p.Close();
    }
}
