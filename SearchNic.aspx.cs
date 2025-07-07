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

public partial class SearchNic : System.Web.UI.Page
{
    FunctionClass fc;
    string user;

    protected void Page_Load(object sender, EventArgs e)
    {
        fc = new FunctionClass();
        user = Session["userid"].ToString();
        string progname = "SearchNic.aspx";
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["MainNic"] = "Customer";
        Response.Redirect("details.aspx");
      
    }
}
