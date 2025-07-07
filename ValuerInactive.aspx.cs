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

public partial class ValuerInactive : System.Web.UI.Page
{
    SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["housdbString"].ConnectionString);
    ValuationFunctions val;
    static string appno;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string username = Session["userid"].ToString();
                string progname = "valuation.aspx";
                if (fc.IsValid(progname, username))
                {
                    val = new ValuationFunctions();
                    appno = Session["appno"].ToString();
                    hfappno.Value = appno.ToString();
                    dgvData.DataSource = val.GetrelevantValData(appno);
                    dgvData.DataBind();
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            catch
            {
                Response.Redirect("login.aspx");
            }

           
        }
    }
    protected void btnChangeStatus_Click(object sender, EventArgs e)
    {
        //string staus = rbchangestatus.SelectedValue.ToString();
       
        
        ////Inactivate or Activate without checking anything

        //val = new ValuationFunctions();
        //int rowchanges = 0;

        //if (staus == "Inactive")
        //{
        //    rowchanges = val.Inactivate(appno);
        //    if (rowchanges > 0)
        //    {
        //        lblchangestatus.Text = "Valuer is Inactivated ";
        //        val.ChangeApprovalstatus(appno, 0);
        //    }
        //    else
        //    {
        //        lblchangestatus.Text = "Did not change anything";
        //    }
        //}
        //else if (staus == "Active")
        //{
        //    rowchanges = val.Activate(appno);
        //    if (rowchanges > 0)
        //    {
        //        lblchangestatus.Text = "Valuater is Activated ";
        //        val.ChangeApprovalstatus(appno, 1);
        //    }
        //    else
        //    {
        //        lblchangestatus.Text = "Did not change anything";
        //    }
        //}
        //else
        //{
        //    //
        //}
    }

    protected void dgvData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void dgvData_RowEditing(object sender, GridViewEditEventArgs e)
    {
        val = new ValuationFunctions();
        string appno = hfappno.Value.ToString();
        dgvData.EditIndex = e.NewEditIndex;
        dgvData.DataSource = val.GetrelevantValData(appno);
        dgvData.DataBind();
    }

    protected void dgvData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        val = new ValuationFunctions();
        string appno = hfappno.Value.ToString();
        dgvData.EditIndex = -1;
        dgvData.DataSource = val.GetrelevantValData(appno);
        dgvData.DataBind();
    }

    protected void dgvData_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        val = new ValuationFunctions();

        string appno = dgvData.Rows[e.RowIndex].Cells[0].Text.ToString();
        string valuerid = dgvData.Rows[e.RowIndex].Cells[1].Text.ToString();
        DateTime senddate = DateTime.Parse(dgvData.Rows[e.RowIndex].Cells[3].Text.ToString());
        string hide = dgvData.Rows[e.RowIndex].Cells[4].Text.ToString();

        DropDownList tmpTaskid = (DropDownList)(dgvData.Rows[dgvData.EditIndex].FindControl("ddlstatus"));
        string status = tmpTaskid.SelectedValue.ToString();

        int rows = val.ChangeStatus(appno, valuerid, senddate, hide, status);

        dgvData.DataSource = val.GetrelevantValData(appno);
        dgvData.DataBind();
    }
}
