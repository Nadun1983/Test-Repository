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
using System.Data.SqlClient;

public partial class test : System.Web.UI.Page
{
    SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["housdbString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        loadgrd();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (int.Parse(RadioButtonList1.SelectedItem.Value) == 1)
        {
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";         
        }
        
    }

    private void loadgrd()
    {
        string sqlstr1 = "select * from nsb_branch";

        SqlDataAdapter dahistory = new SqlDataAdapter(sqlstr1, myconnection);
        DataSet dshistory = new DataSet();
        dahistory.Fill(dshistory, sqlstr1);

        GridView1.DataSource = dshistory.Tables[sqlstr1];
        GridView1.DataBind();

    }

    
}
