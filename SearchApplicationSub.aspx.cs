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

public partial class SearchApplicationSub : System.Web.UI.Page
{
    Search s;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        s = new Search();
        dt = new DataTable();
        string nicno = Request.QueryString["nicno"].ToString();
        dt = s.GetCustMainDetails(nicno);
        DgvCustDetails.DataSource = dt;
        DgvCustDetails.DataBind();

        dt = s.GetCustLoanDetail(nicno);
        dgvLoanDetails.DataSource = dt;
        dgvLoanDetails.DataBind();

        double totApvdAmt = 0;
        double instalment = 0;
        double totOutBal = 0;

        for (int a = 0; a < dt.Rows.Count; a++)
        {
            totApvdAmt += double.Parse(dt.Rows[a]["AprovdAmt"].ToString());
            totOutBal += double.Parse(dt.Rows[a]["OutBal"].ToString());
            if (double.Parse(dt.Rows[a]["OutBal"].ToString()) > 0)
                instalment += double.Parse(dt.Rows[a]["Instalment"].ToString());
        }

        lbltotaprvdamt.Text = String.Format("{0:n2}", totApvdAmt);
        lblTotLoanInstlment.Text = String.Format("{0:n2}", instalment);
        lblTotOutbal.Text = String.Format("{0:n2}", totOutBal);
    }
}
