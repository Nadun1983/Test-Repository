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

public partial class AddInspector : System.Web.UI.Page
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
                string progname = "AddInspector.aspx";
                if (fc.IsValid(progname, username))
                {
                    ac = new AdminClass();
                    dtvAddInspector.DataSource = ac.GetInspector();
                    dtvAddInspector.DataBind();
                    lblMsg.Text = "Enter Surname to Search  ...............";
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

    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {
        ac = new AdminClass();
        if (txtSearch.Text != "")
        {
            dtvAddInspector.DataSource = ac.GetInspector(txtSearch.Text);
            dtvAddInspector.DataBind();
        }
        else
        {

            dtvAddInspector.DataSource = ac.GetInspector();
            dtvAddInspector.DataBind();
  
        }
    }

    protected void dtvAddInspector_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (e.NewMode == DetailsViewMode.Insert)
        {
            dtvAddInspector.ChangeMode(DetailsViewMode.Insert);
            ac = new AdminClass();
            if (txtSearch.Text == "")
            {
                dtvAddInspector.DataSource = ac.GetInspector();
                dtvAddInspector.DataBind();
            }
            else
            {
                dtvAddInspector.DataSource = ac.GetInspector(txtSearch.Text);
                dtvAddInspector.DataBind();
            }
        }


        if (e.NewMode == DetailsViewMode.Edit)
        {
            dtvAddInspector.ChangeMode(DetailsViewMode.Edit);
            ac = new AdminClass();
            if (txtSearch.Text == "")
            {
                dtvAddInspector.DataSource = ac.GetInspector();
                dtvAddInspector.DataBind();
            }
            else
            {
                dtvAddInspector.DataSource = ac.GetInspector(txtSearch.Text);
                dtvAddInspector.DataBind();
            }
        }


    }
    protected void dtvAddInspector_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        ac = new AdminClass();
        DropDownList ddllist = new DropDownList();
        ddllist = (DropDownList)dtvAddInspector.FindControl("ddlTitleCodeI");

        int titlecode = int.Parse(ddllist.SelectedValue.ToString());

        string surname = ((TextBox)dtvAddInspector.Rows[2].Cells[1].Controls[0]).Text.ToString();
        string initials = ((TextBox)dtvAddInspector.Rows[3].Cells[1].Controls[0]).Text.ToString();
        string epfNo = ((TextBox)dtvAddInspector.Rows[4].Cells[1].Controls[0]).Text.ToString();
        string destination = ((TextBox)dtvAddInspector.Rows[5].Cells[1].Controls[0]).Text.ToString();
        string grade = ((TextBox)dtvAddInspector.Rows[6].Cells[1].Controls[0]).Text.ToString();
        string branchCode = ((TextBox)dtvAddInspector.Rows[7].Cells[1].Controls[0]).Text.ToString();
        string teleNo = ((TextBox)dtvAddInspector.Rows[8].Cells[1].Controls[0]).Text.ToString();
        string username = Session["userid"].ToString();
        string status = "A";
        string destAccountNo = ((TextBox)dtvAddInspector.Rows[10].Cells[1].Controls[0]).Text.ToString();
        string email = ((TextBox)dtvAddInspector.Rows[11].Cells[1].Controls[0]).Text.ToString();
        string telRes = ((TextBox)dtvAddInspector.Rows[12].Cells[1].Controls[0]).Text.ToString();
        string mobile = ((TextBox)dtvAddInspector.Rows[13].Cells[1].Controls[0]).Text.ToString();
        string ADDDateTime = ((TextBox)dtvAddInspector.Rows[13].Cells[1].Controls[0]).Text.ToString();


        if (ac.InsertInspector(titlecode, surname, initials, epfNo, destination, grade, branchCode, teleNo, username, status,
                    destAccountNo, email, telRes, mobile, DateTime.Now, "A") != 0)
        {
            lblMsg.Text = "Record is Succesfully Inserted";
        }
        else
        {
            lblMsg.Text = "Error in Record Insert";
        }


    }

    //private void LoadAddIspect(int inspectid)
    //{
    //    if (txtSearch.Text == "")
    //    {
    //        dtvAddInspector.DataSource = ac.GetInspector();
    //        dtvAddInspector.DataBind();
    //    }
    //    else
    //    {
    //        dtvAddInspector.DataSource = ac.GetInspector(txtSearch.Text);
    //        dtvAddInspector.DataBind();
    //    }
    //}

    protected void dtvAddInspector_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {

    }

    protected void dtvAddInspector_PageIndexChanged(object sender, EventArgs e)
    {
        ac = new AdminClass();
        if (txtSearch.Text == "")
        {
            dtvAddInspector.DataSource = ac.GetInspector();
            dtvAddInspector.DataBind();
        }
        else
        {
            dtvAddInspector.DataSource = ac.GetInspector(txtSearch.Text);
            dtvAddInspector.DataBind();
        }
    }
    protected void dtvAddInspector_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {
        ac = new AdminClass();
        dtvAddInspector.PageIndex = e.NewPageIndex;
    }
    protected void dtvAddInspector_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        ac = new AdminClass();

        DropDownList ddllist = (DropDownList)dtvAddInspector.FindControl("ddlTitleCodeE");

        int titlecode = int.Parse(ddllist.SelectedValue.ToString());
        int inspectid = int.Parse(((TextBox)dtvAddInspector.Rows[0].Cells[1].Controls[0]).Text.ToString());
        string surname = ((TextBox)dtvAddInspector.Rows[2].Cells[1].Controls[0]).Text.ToString();
        string initials = ((TextBox)dtvAddInspector.Rows[3].Cells[1].Controls[0]).Text.ToString();
        string epfNo = ((TextBox)dtvAddInspector.Rows[4].Cells[1].Controls[0]).Text.ToString();
        string destination = ((TextBox)dtvAddInspector.Rows[5].Cells[1].Controls[0]).Text.ToString();
        string grade = ((TextBox)dtvAddInspector.Rows[6].Cells[1].Controls[0]).Text.ToString();
        string branchCode = ((TextBox)dtvAddInspector.Rows[7].Cells[1].Controls[0]).Text.ToString();
        string teleNo = ((TextBox)dtvAddInspector.Rows[8].Cells[1].Controls[0]).Text.ToString();
        string username = Session["userid"].ToString();
        string status = "A";
        string destAccountNo = ((TextBox)dtvAddInspector.Rows[10].Cells[1].Controls[0]).Text.ToString();
        string email = ((TextBox)dtvAddInspector.Rows[11].Cells[1].Controls[0]).Text.ToString();
        string telRes = ((TextBox)dtvAddInspector.Rows[12].Cells[1].Controls[0]).Text.ToString();
        string mobile = ((TextBox)dtvAddInspector.Rows[13].Cells[1].Controls[0]).Text.ToString();

        if (ac.UpdateInspector(inspectid, titlecode, surname, initials, epfNo, destination, grade, branchCode,
            teleNo, username, status, destAccountNo, email, telRes, mobile) != 0)
            lblMsg.Text = "Records Succesfully Updated";
        else
            lblMsg.Text = "Error in Updating";

    }
    protected void dtvAddInspector_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        ac = new AdminClass();
    }
    //protected void txtSearch_TextChanged(object sender, EventArgs e)
    //{
    //    ac = new AdminClass();
    //    dtvAddInspector.DataSource = ac.GetInspector(txtSearch.Text);
    //    dtvAddInspector.DataBind();
    //}

    protected void dtvAddInspector_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
        {
            lblMsg.Text = "User Calcellation";
            dtvAddInspector.ChangeMode(DetailsViewMode.ReadOnly);
             ac = new AdminClass();
        if (txtSearch.Text == "")
        {
            dtvAddInspector.DataSource = ac.GetInspector();
            dtvAddInspector.DataBind();
        }
        else
        {
            dtvAddInspector.DataSource = ac.GetInspector(txtSearch.Text);
            dtvAddInspector.DataBind();
        }
        }
    }
}
