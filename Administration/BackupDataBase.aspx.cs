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
using System.IO;
using System.Data.SqlClient;

public partial class Administration_BackupDataBase : System.Web.UI.Page
{
    SqlCommand cmd;
    SqlConnection conn;
    BatchEnter be;
    DataBaseClass db;
    FunctionClass fc;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hfusername.Value = Session["userid"].ToString();
        }
    }

    protected void btnGetBackUp_Click(object sender, EventArgs e)
    {
        db = new DataBaseClass();
        fc=new FunctionClass();
        string userName = hfusername.Value.ToString();

        lblMsg.Text = "Backup Database..............";
        cmd = new SqlCommand();
        string NAME = "CreditDatabaseTDB";
        NAME = txtName.Text.ToString();
        if (NAME.Length < 4)
        {
            NAME = "CreditDatabaseTDB";
        }

        //check backup name
        if (db.IsNameExsist(NAME))
        {
            lblMsg.Text = "This BackName Already Exsist.";
        }
        else
        {
            conn = new SqlConnection("server=DB195;database=TDB;uid=CreditAdmin;pwd=ncms@36");
            //cmd = new SqlCommand("[sp_BackupDatabase]", conn);
            cmd = new SqlCommand(@"BACKUP DATABASE TDB
                                TO DISK = 'E:\credit\backups\TDB.Bak'
                                   WITH FORMAT,
                                      MEDIANAME = 'Z_SQLServerBackups',
                                      NAME = @NAME;", conn);
            cmd.CommandTimeout = 100;
            cmd.Parameters.AddWithValue("NAME", NAME);
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.Text;

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                lblMsg.Text = "Successfuly Backup yout Database";
                //Insert log Record
                int row = db.InsertBackupRecord(fc.GetSystemDateKey("A"), NAME, userName, System.DateTime.Now);
            }
            catch (Exception err)
            {
                lblMsg.Text = "Cannot Get The Backup";
            }

            conn.Close();

            //Copy backups file........

            //string sourse = @"\\10.1.0.199\\credit\\backups";
            //string destination = @"\\10.1.5.15\\Database Backup\\";

            //destination = destination + backName;

            //try
            //{
            //    File.Copy(sourse, destination, true);
            //}

            //catch (Exception er)
            //{
            //    lblMsg.Text = "Cannot Copy Backup Database To your PC";
            //}       
        }

    }
}
