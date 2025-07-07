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
using System.Data;
using System.Data.SqlClient;

public partial class SearchApplication : System.Web.UI.Page
{
    Search srch = new Search();
    ApprovalClass ac;
    FunctionClass fc;
    string user;
    int crcat;

    protected void Page_Load(object sender, EventArgs e)
    {
        fc = new FunctionClass();
        //user = Session["userid"].ToString();
        string progname = "SearchApplication.aspx";
    }

    protected void txtsearchoption_TextChanged(object sender, EventArgs e)
    {
        srch=new Search();
        string searchItem = rboption.SelectedValue.ToString();
        hfnicno.Value = "0";

        if (searchItem == "NIC")
        {
            dgvsearchresult.DataSource = srch.searchbyNIC(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
            hfnicno.Value = txtsearchoption.Text.ToString();
        }

            //2010/01/15 vihanga
        else if (searchItem == "Initial")
        {
            dgvsearchresult.DataSource = srch.SearchByInitials(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
        }

        //2010/01/15 vihanga
        else if (searchItem == "Instalment")
        {
            dgvsearchresult.DataSource = srch.SearchByInstalment(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
        }

        //2010/01/15 vihanga
        else if (searchItem == "EPF")
        {
            dgvsearchresult.DataSource = srch.SearchByEPF(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
        }

        //2010/01/15 vihanga
        else if (searchItem == "Address")
        {
            dgvsearchresult.DataSource = srch.SearchByAddress(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
        }


        else if (searchItem == "sname")
        {
            dgvsearchresult.DataSource = srch.searchbySurname(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
        }

        else if (searchItem == "pnumber")
        {
            dgvsearchresult.DataSource = srch.searchbyPassportNo(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
        }

        else if (searchItem == "Status")
        {
            string _appno = txtsearchoption.Text.ToString();
            string status;

            ac = new ApprovalClass();
            DataTable dt = new DataTable();
            dt = ac.GetApprovalStatus(_appno, false);
            if (dt.Rows.Count != 0)
            {
                dgvsearchresult.DataSource = dt;
                dgvsearchresult.DataBind();
                //2010/07/16 line 1
                status = ac.IsApproved(_appno); //,crcat);
                lblMsg.Text = "Please Check Process For Approval";
            }
            else
            {
                //btnSetApproval.Visible = false;
                //btnPrintFacilityPaper.Visible = false;
                lblMsg.Text = "Enter Correct Application Number or Application is already disburesed";
            }
        }
        else if (searchItem == "LoanAccount")
        {
            dgvsearchresult.DataSource = srch.serchByCracno(txtsearchoption.Text);
            dgvsearchresult.DataBind();
        }

        else if (searchItem == "AppNoDisb")
        {
            dgvsearchresult.DataSource = srch.searchbyAppno(txtsearchoption.Text);
            dgvsearchresult.DataBind();
        }

        else
        {
            lblMsg.Text = "Check the entered details";
        }
    }

    protected void dgvsearchresult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvsearchresult.PageIndex = e.NewPageIndex;
        srch = new Search();
        string searchItem = rboption.SelectedValue.ToString();

        if (searchItem == "NIC")
        {
            dgvsearchresult.DataSource = srch.searchbyNIC(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
        }
        else if (searchItem == "sname")
        {
            dgvsearchresult.DataSource = srch.searchbySurname(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
        }

        else if (searchItem == "pnumber")
        {
            dgvsearchresult.DataSource = srch.searchbyPassportNo(txtsearchoption.Text);
            dgvsearchresult.DataBind();
            lblMsg.Text = "...";
        }

        else
        {
            lblMsg.Text = "Check the entered details";
        }
    }

    protected void dgvsearchresult_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        srch = new Search();
        string nicno = dgvsearchresult.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
        lblMsg.Text = "NIC no is"+ nicno;

        dvcustdetail.DataSource = srch.GetCustdetail(nicno);
        dvcustdetail.DataBind();
    }
    protected void rboption_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtsearchoption.Text = "";
        txtsearchoption.Focus();
        dvcustdetail.DataBind();
        dgvsearchresult.DataBind();
    }

    protected void btnPrintPreview_Click(object sender, EventArgs e)
    {
        string nicno = hfnicno.Value;
        if (nicno == "0")
        {
            lblMsg.Text = "Invalid Nic";
        }
        else
        {
            btnPrintPreview.Attributes.Add("onClick", "JavaScript: window.open('\\SearchApplicationSub.aspx?nicno=" + nicno + "','printwindow','menubar=0,resizable=0,width=1000,height=950')");
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
    }
}
