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
using System.Data.SqlClient;

public partial class Administration_TDBBackup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        FunctionClass fc = new FunctionClass();
        string user = Session["userid"].ToString();
        string progname = "Administration/TDBBackup.aspx";
        if (fc.IsValid(progname, user))
        {
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void btnBackup_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string constring = ConfigurationManager.ConnectionStrings["housdbString"].ConnectionString.ToString();


        SqlConnection sqlcon = new SqlConnection(constring);
        SqlCommand sqlcmd = new SqlCommand("exec TDB_Backup", sqlcon);
        sqlcmd.CommandTimeout = 500;
        try
        {
            sqlcon.Open();
            sqlcmd.ExecuteNonQuery();
            lblMsg.Text += "Database backup success !";
        }
        catch (Exception er)
        {
            lblMsg.Text = er.Message;
        }
        finally
        {
            sqlcon.Close();
            sqlcon.Dispose();
            sqlcmd.Dispose();
        }

        
    }
}
