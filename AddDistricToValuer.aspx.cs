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

public partial class AddDistricToValuer : System.Web.UI.Page
{
    DataTable dt;
    AdminClass ac;
    DataTable dt2;


    protected void Page_Load(object sender, EventArgs e)
    {
        ac = new AdminClass();
        dt = new DataTable();
        
        if (!Page.IsPostBack)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string username = Session["userid"].ToString();
                string progname = "AddDistricToValuer.aspx";
                if (fc.IsValid(progname, username))
                {

                    dt = ac.GetAllValuersName();
                    ddlvaluers.DataSource = dt;
                    ddlvaluers.DataValueField = "valuerid";
                    ddlvaluers.DataTextField = "fullname";
                    ddlvaluers.DataBind();
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
  
    protected void ddlvaluers_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ac = new AdminClass();
        dt = new DataTable();

        int ValuerId = int.Parse(ddlvaluers.SelectedValue.ToString());
        dt = ac.GetValuersDistrics(ValuerId);        

        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();
        DetailsView1.Visible = true;
    }

    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        DetailsView1.PageIndex = e.NewPageIndex;
    }

    protected void DetailsView1_PageIndexChanged(object sender, EventArgs e)
    {
        ac = new AdminClass();
        dt = new DataTable();

        int ValuerId = int.Parse(ddlvaluers.SelectedValue.ToString());
        dt = ac.GetValuersDistrics(ValuerId);

        DetailsView1.DataSource = dt;
        DetailsView1.DataBind();
        DetailsView1.Visible = true;
    }

    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        ac = new AdminClass();
        DropDownList ddllist = new DropDownList();
        ddllist = (DropDownList)DetailsView1.FindControl("ddlInsert");

        try
        {
            int ValuerId = int.Parse(((TextBox)DetailsView1.Rows[1].Cells[1].Controls[0]).Text.ToString());
            int DistCode = int.Parse(((TextBox)DetailsView1.Rows[2].Cells[1].Controls[0]).Text.ToString());

            ac.AddDistric(ValuerId, DistCode);
            lblMsg.Text = "Successfully Saved";
        }
        catch (Exception er)
        {
            lblMsg.Text = "Please Check The entered Data";
        }
    }

    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        dt = new DataTable();
        ac = new AdminClass();
        dt2 = new DataTable();

        int ValuerId = int.Parse(ddlvaluers.SelectedValue.ToString());
        dt = ac.GetValuersDistrics(ValuerId);
        dt2 = ac.GetAllDistric();

        if (e.NewMode == DetailsViewMode.Insert)
        {
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();            
        }
        else if (e.NewMode == DetailsViewMode.Edit)
        {
            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();
            DetailsView1.Visible = true;
        }
    }

    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {

    }

    protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
        {
            lblMsg.Text = "User Calcellation";
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            ac = new AdminClass();
            DetailsView1.DataSource = ac.GetAllDistric();
            DetailsView1.DataBind();
        }
    }   
}
