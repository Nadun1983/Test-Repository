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

public partial class TrackingSummary : System.Web.UI.Page
{
      FunctionClass fc;
      PrintClass p;
      DataTable dt = new DataTable();
      Search sh = new Search();

    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnsubmot_Click(object sender, EventArgs e)
    {
        string file = Server.MapPath("~/Reports/Tracking.pdf");
        string fpath;
        fc = new FunctionClass();
        p = new PrintClass();
        DateTime fromdate = fc.GetDateinDateKey(txtfrom.Text);
        DateTime todate = fc.GetDateinDateKey(txtto.Text);
        fpath = Server.MapPath("~/Reports/ApplicationTrackingSummary.rpt");
        p.SetConnection(fpath, file, "CreditAdmin", "ncms@36", "DB195", "TDB");
        p.SetParams("fromdate", fromdate);
        p.SetParams("todate", todate);
        p.GetPdfReport(Response);
    }
}
