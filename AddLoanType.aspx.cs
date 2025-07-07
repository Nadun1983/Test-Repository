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

public partial class AddLoanType : System.Web.UI.Page
{
    AdminClass ac;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string username = Session["userid"].ToString();
                string progname = "AddLoanType.aspx";
                if (fc.IsValid(progname, username))
                {
                    ac = new AdminClass();
                    dtvLoanCat.DataSource = ac.GetLoanTypes();
                    dtvLoanCat.DataBind();
                    lblMsg.Text = "Navigate to Change Loan Types ...............";
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
    protected void dtvLoanCat_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        dtvLoanCat.PageIndex = e.NewPageIndex;
    }
    protected void dtvLoanCat_PageIndexChanged(object sender, EventArgs e)
    {
        ac = new AdminClass();
        dtvLoanCat.DataSource = ac.GetLoanTypes();
        dtvLoanCat.DataBind();
    }
    protected void dtvLoanCat_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        ac = new AdminClass();

        string CrDes = ((TextBox)dtvLoanCat.Rows[1].Cells[1].Controls[0]).Text.ToString();
        
        if (ac.InsertLoanType(CrDes) != 0)
        {
            lblMsg.Text = "Record is Succesfully Inserted";
        }
        else
        {
            lblMsg.Text = "Error in Record Insert";
        }

    }
    protected void dtvLoanCat_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        ac = new AdminClass();

        string CrDes = ((TextBox)dtvLoanCat.Rows[1].Cells[1].Controls[0]).Text.ToString();
        int CrCatCode = int.Parse(((TextBox)dtvLoanCat.Rows[0].Cells[1].Controls[0]).Text.ToString());

        if (ac.UpdateLoanType(CrCatCode, CrDes) != 0)
        {
            lblMsg.Text = "Record is Succesfully Updated";
        }
        else
        {
            lblMsg.Text = "Error in Record Updating";
        }
    }
    protected void dtvLoanCat_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (e.NewMode == DetailsViewMode.Insert)
        {
            dtvLoanCat.ChangeMode(DetailsViewMode.Insert);
            ac = new AdminClass();
            dtvLoanCat.DataSource = ac.GetLoanTypes();
            dtvLoanCat.DataBind();

        }


        if (e.NewMode == DetailsViewMode.Edit)
        {
            dtvLoanCat.ChangeMode(DetailsViewMode.Edit);
            ac = new AdminClass();
            dtvLoanCat.DataSource = ac.GetLoanTypes();
            dtvLoanCat.DataBind();
        }

    }
    protected void dtvLoanCat_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
        {
            lblMsg.Text = "User Calcellation";
            dtvLoanCat.ChangeMode(DetailsViewMode.ReadOnly);
            ac = new AdminClass();
            dtvLoanCat.DataSource = ac.GetLoanTypes();
            dtvLoanCat.DataBind();
        }
    }
}
