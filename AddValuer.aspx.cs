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

public partial class AddValuer : System.Web.UI.Page
{
    static int titlecode = 0;
    AdminClass ac;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
          if (!Page.IsPostBack)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string username = Session["userid"].ToString();
                string progname = "AddValuer.aspx";
                if (fc.IsValid(progname, username))
                {
                    //ac = new AdminClass();
                    //dtvAddValuer.DataSource = ac.GetValuer();
                    //dtvAddValuer.DataBind();
                    //lblMsg.Text = "Enter Surname to Search  ...............";
                    pageLoad();
                    visiblefalse();
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

    private void pageLoad()
    {
        //dtvAddValuer.Visible = false;
        //GridView1.Visible = false;
        //txtSearch.Visible = false;
        lblMsg.Text = "";

        dt = new DataTable();
        ac = new AdminClass();

        dt = ac.GetValuer();
        GridView2.DataSource = dt;
        GridView2.DataBind();
    }

    //protected void txtSearch_TextChanged(object sender, EventArgs e)
    //{
    //    ac = new AdminClass();
    //    if (txtSearch.Text != "")
    //    {
    //        dtvAddValuer.DataSource = ac.GetValuer(txtSearch.Text);
    //        dtvAddValuer.DataBind();
    //    }
    //    else
    //    {
    //        dtvAddValuer.DataSource = ac.GetValuer();
    //        dtvAddValuer.DataBind();
    //    }
    //}
    //protected void dtvAddValuer_PageIndexChanged(object sender, EventArgs e)
    //{
    //    ac = new AdminClass();
    //    if (txtSearch.Text == "")
    //    {
    //        dtvAddValuer.DataSource = ac.GetValuer();
    //        dtvAddValuer.DataBind();
    //    }
    //    else
    //    {
    //        dtvAddValuer.DataSource = ac.GetValuer(txtSearch.Text);
    //        dtvAddValuer.DataBind();
    //    }
    //}
    //protected void dtvAddValuer_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    //{
    //    dtvAddValuer.PageIndex = e.NewPageIndex;
    //}
    //protected void dtvAddValuer_ModeChanging(object sender, DetailsViewModeEventArgs e)
    //{
    //    if (e.NewMode == DetailsViewMode.Insert)
    //    {
    //        dtvAddValuer.ChangeMode(DetailsViewMode.Insert);
    //        ac = new AdminClass();
    //        if (txtSearch.Text != "")
    //        {
    //            dtvAddValuer.DataSource = ac.GetValuer(txtSearch.Text);
    //            dtvAddValuer.DataBind();
    //        }
    //        else
    //        {
    //            dtvAddValuer.DataSource = ac.GetValuer();
    //            dtvAddValuer.DataBind();
    //        }
    //    }

    //    if (e.NewMode == DetailsViewMode.Edit)
    //    {
    //        dtvAddValuer.ChangeMode(DetailsViewMode.Edit);
    //        ac = new AdminClass();
    //        if (txtSearch.Text != "")
    //        {
    //            dtvAddValuer.DataSource = ac.GetValuer(txtSearch.Text);
    //            dtvAddValuer.DataBind();
    //        }
    //        else
    //        {
    //            dtvAddValuer.DataSource = ac.GetValuer();
    //            dtvAddValuer.DataBind();
    //        }
    //    }

    //}
    //protected void dtvAddValuer_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    //{
    //    ac = new AdminClass();
    //    DropDownList ddllist = new DropDownList();
    //    ddllist = (DropDownList)dtvAddValuer.FindControl("ddlTitleCodeI");

    //    try
    //    {
    //        int titlecode = int.Parse(ddllist.SelectedValue.ToString());
    //        string surname = ((TextBox)dtvAddValuer.Rows[1].Cells[1].Controls[0]).Text.ToString();
    //        string initials = ((TextBox)dtvAddValuer.Rows[2].Cells[1].Controls[0]).Text.ToString();
    //        string Location = ((TextBox)dtvAddValuer.Rows[3].Cells[1].Controls[0]).Text.ToString();
    //        string Street = ((TextBox)dtvAddValuer.Rows[4].Cells[1].Controls[0]).Text.ToString();
    //        string City = ((TextBox)dtvAddValuer.Rows[5].Cells[1].Controls[0]).Text.ToString();
    //        string Telephone = ((TextBox)dtvAddValuer.Rows[6].Cells[1].Controls[0]).Text.ToString();
    //        string NicNo = ((TextBox)dtvAddValuer.Rows[7].Cells[1].Controls[0]).Text.ToString();
    //        string ValuerType = ((TextBox)dtvAddValuer.Rows[8].Cells[1].Controls[0]).Text.ToString();
    //        string Employerno = ((TextBox)dtvAddValuer.Rows[9].Cells[1].Controls[0]).Text.ToString();
    //        double CommisRate = double.Parse(((TextBox)dtvAddValuer.Rows[10].Cells[1].Controls[0]).Text.ToString());
    //        string Qualification = ((TextBox)dtvAddValuer.Rows[11].Cells[1].Controls[0]).Text.ToString();
    //        string AddUser = Session["userid"].ToString();
    //        string Status = ((TextBox)dtvAddValuer.Rows[13].Cells[1].Controls[0]).Text.ToString();
    //        int BankCode = 7000;
    //        int BranchCode = int.Parse(((TextBox)dtvAddValuer.Rows[15].Cells[1].Controls[0]).Text.ToString());
    //        string DestAcNo = ((TextBox)dtvAddValuer.Rows[16].Cells[1].Controls[0]).Text.ToString();
    //        string Mobile = ((TextBox)dtvAddValuer.Rows[17].Cells[1].Controls[0]).Text.ToString();
    //        string fax = ((TextBox)dtvAddValuer.Rows[18].Cells[1].Controls[0]).Text.ToString();
    //        string Email = ((TextBox)dtvAddValuer.Rows[19].Cells[1].Controls[0]).Text.ToString();

    //        ac.InsertValuer(titlecode, surname, initials, Location, Street, City, Telephone, NicNo, ValuerType, Employerno, CommisRate, Qualification,
    //        AddUser, Status, BankCode, BranchCode, DestAcNo, Mobile, fax, Email);

    //        lblMsg.Text = "Successfully Saved";
    //    }
    //    catch (Exception er)
    //    {
    //        lblMsg.Text = "Please Check The entered Data";
    //    }
    //}
    //protected void dtvAddValuer_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    //{
      
    //    ac = new AdminClass();
    //    DropDownList ddllist = new DropDownList();
    //    ddllist = (DropDownList)dtvAddValuer.FindControl("ddlTitleCodeI");

    //    try
    //    {
    //        int titlecode = int.Parse(ddllist.SelectedValue.ToString());
    //        string surname = ((TextBox)dtvAddValuer.Rows[1].Cells[1].Controls[0]).Text.ToString();
    //        string initials = ((TextBox)dtvAddValuer.Rows[2].Cells[1].Controls[0]).Text.ToString();
    //        string Location = ((TextBox)dtvAddValuer.Rows[3].Cells[1].Controls[0]).Text.ToString();
    //        string Street = ((TextBox)dtvAddValuer.Rows[4].Cells[1].Controls[0]).Text.ToString();
    //        string City = ((TextBox)dtvAddValuer.Rows[5].Cells[1].Controls[0]).Text.ToString();
    //        string Telephone = ((TextBox)dtvAddValuer.Rows[6].Cells[1].Controls[0]).Text.ToString();
    //        string NicNo = ((TextBox)dtvAddValuer.Rows[7].Cells[1].Controls[0]).Text.ToString();
    //        string ValuerType = ((TextBox)dtvAddValuer.Rows[8].Cells[1].Controls[0]).Text.ToString();
    //        string Employerno = ((TextBox)dtvAddValuer.Rows[9].Cells[1].Controls[0]).Text.ToString();
    //        double CommisRate = double.Parse(((TextBox)dtvAddValuer.Rows[10].Cells[1].Controls[0]).Text.ToString());
    //        string Qualification = ((TextBox)dtvAddValuer.Rows[11].Cells[1].Controls[0]).Text.ToString();
    //        string AddUser = Session["userid"].ToString();
    //        string Status = ((TextBox)dtvAddValuer.Rows[13].Cells[1].Controls[0]).Text.ToString();
    //        int BankCode = 7000;
    //        int BranchCode = int.Parse(((TextBox)dtvAddValuer.Rows[15].Cells[1].Controls[0]).Text.ToString());
    //        string DestAcNo = ((TextBox)dtvAddValuer.Rows[16].Cells[1].Controls[0]).Text.ToString();
    //        string Mobile = ((TextBox)dtvAddValuer.Rows[17].Cells[1].Controls[0]).Text.ToString();
    //        string fax = ((TextBox)dtvAddValuer.Rows[18].Cells[1].Controls[0]).Text.ToString();
    //        string Email = ((TextBox)dtvAddValuer.Rows[19].Cells[1].Controls[0]).Text.ToString();
    //        int ValuerId = int.Parse(((TextBox)dtvAddValuer.Rows[20].Cells[1].Controls[0]).Text.ToString());
            
    //        ac.UpdateValuer(ValuerId,titlecode, surname, initials, Location, Street, City, Telephone, NicNo, ValuerType, Employerno, CommisRate, Qualification,
    //        AddUser, Status, BankCode, BranchCode, DestAcNo, Mobile, fax, Email);

    //        lblMsg.Text = "Successfully Saved";
    //    }
    //    catch (Exception er)
    //    {
    //        lblMsg.Text = "Please Check The entered Data";
    //    }
    //}
    //protected void dtvAddValuer_ItemCommand(object sender, DetailsViewCommandEventArgs e)
    //{
    //    if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
    //    {
    //        lblMsg.Text = "User Calcellation";
    //        dtvAddValuer.ChangeMode(DetailsViewMode.ReadOnly);
    //        ac = new AdminClass();
    //        if (txtSearch.Text == "")
    //        {
    //            dtvAddValuer.DataSource = ac.GetValuer();
    //            dtvAddValuer.DataBind();
    //        }
    //        else
    //        {
    //            dtvAddValuer.DataSource = ac.GetValuer(txtSearch.Text);
    //            dtvAddValuer.DataBind();
    //        }
    //    }
    //}

    protected void btnedit_Click(object sender, EventArgs e)
    {
         clearTextbox();
        visiblefalse();
        btnUpdate.Visible = true;

        int valuerID = int.Parse(txtvaluerID.Text);
        dt = new DataTable();
        ac = new AdminClass();
        dt = ac.GetValuerIndividual(valuerID);

        if (dt.Rows.Count > 0)
        {
            txtsurname.Text = dt.Rows[0][0].ToString();
            txtinitial.Text = dt.Rows[0][1].ToString();
            txtlocation.Text = dt.Rows[0][2].ToString();
            txtstreet.Text = dt.Rows[0][3].ToString();
            txtcity.Text = dt.Rows[0][4].ToString();
            txttelephone.Text = dt.Rows[0][5].ToString();
            txtnicno.Text = dt.Rows[0][6].ToString();
            txtstatus.Text = dt.Rows[0][7].ToString();
            txtvaluertype.Text = dt.Rows[0][8].ToString();
            txtqualification.Text = dt.Rows[0][9].ToString();
            //surname,initial,location,street,city,telephone,nicno,status,valuertype,qualification 
        }
    }

    private void visiblefalse()
    {
        btnSave.Visible = false;
        btnUpdate.Visible = false;
        pnlAutoLoan.Visible = false;
        pnlValuer.Visible = false;
    }

    private void clearTextbox()
    {
        txtsurname.Text = "";
        txtinitial.Text = "";
        txtlocation.Text = "";
        txtstreet.Text = "";
        txtcity.Text = "";
        txttelephone.Text = "";
        txtnicno.Text = "";
        txtstatus.Text = "A";
        txtvaluertype.Text = "O";
        txtqualification.Text = "";
    }
    protected void btnaddnewvaluer_Click(object sender, EventArgs e)
    {
        clearTextbox();
        visiblefalse();
        btnSave.Visible = true;
        txtvaluerID.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ac = new AdminClass();
        int valuerId = ac.getmaxvaluerID() + 1;
        try
        {
            int row = ac.InsertValuer(valuerId,int.Parse(DropDownList1.SelectedValue.ToString()), txtsurname.Text, txtinitial.Text, txtlocation.Text,
                txtstreet.Text, txtcity.Text, txttelephone.Text, txtnicno.Text, txtvaluertype.Text, "", "", txtqualification.Text,
                Session["userid"].ToString(), txtstatus.Text, 7000, "", "", "", "");
            lblMsg.Text = "Successfully saved the new valuer....";
            pageLoad();
            ac.InsertRecordTovaluerarea();
            clearTextbox();
            visiblefalse();
        }
        catch (Exception e1)
        {
            lblMsg.Text = "Invalid data. Please try again";
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ac = new AdminClass();
        int rows = ac.UpdateValuer(int.Parse(txtvaluerID.Text), int.Parse(DropDownList1.SelectedValue.ToString()), txtsurname.Text, txtinitial.Text,
            txtlocation.Text, txtstreet.Text, txtcity.Text, txttelephone.Text, txtnicno.Text, txtvaluertype.Text, "", "", txtqualification.Text,
            Session["userid"].ToString(), txtstatus.Text, 7000, "", "", "", "");
        if (rows > 0)
        {
            lblMsg.Text = "Successfully update";
            visiblefalse();
            pageLoad();
        }
        else
        {
            //
        }
    }
    protected void txtValuerName_TextChanged(object sender, EventArgs e)
    {
        ValuerClass vc = new ValuerClass();
        grvValuers.DataSource = vc.GetAutoLoanValuers(txtValuerName.Text);
        grvValuers.DataBind();
    }
    protected void btnAutoLoan_Click(object sender, EventArgs e)
    {
        ValuerClass vc = new ValuerClass();
        int valuerno = vc.GetAutoLoanValuerid() + 1;
        int row = vc.InsertToAutoLoanValuers(valuerno, txtNewValuer.Text);

        if (row > 0)
            lblMsg.Text = "You Have Successfully inserted the data";
        grvValuers.DataSource = vc.GetAllAutoLoanValuer();
        grvValuers.DataBind();
    }
    protected void btnAutoLoanView_Click(object sender, EventArgs e)
    {
        ValuerClass vc = new ValuerClass();
        pnlAutoLoan.Visible = true;
        pnlValuer.Visible = false;
        grvValuers.DataSource = vc.GetAllAutoLoanValuer();
        grvValuers.DataBind();
    }
    protected void btnHPLView_Click(object sender, EventArgs e)
    {
        pnlAutoLoan.Visible = false;
        pnlValuer.Visible = true;
    }
}