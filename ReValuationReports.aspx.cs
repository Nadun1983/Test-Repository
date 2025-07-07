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

public partial class ReValuationReports : System.Web.UI.Page
{
    DataTable dt;
    ValuationFunctions vf;

    protected void Page_Load(object sender, EventArgs e)
    {
        vf = new ValuationFunctions();
        dt = new DataTable();
        dt = vf.GetExpireData("S", "730");
        GridView1.DataSource = dt;
        GridView1.DataBind();

        dt = vf.GetExpireData("O", "1500");
        GridView2.DataSource = dt;
        GridView2.DataBind();

    }
}
