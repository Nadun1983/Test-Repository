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

public partial class UserAccess : System.Web.UI.Page
{
    SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["housdbString"].ConnectionString);
    FunctionClass fc;
    AccessCodes accesscls = new AccessCodes();
    DataTable dt = new DataTable();
    Encryption enc;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string username = Session["userid"].ToString();
                string progname = "UserAccess.aspx";
                if (fc.IsValid(progname, username))
                {
                    Label2.Focus();
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
    
    //Save New user details to Users table and Program Access details to PrgAccess table
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string message = "";
        dt = accesscls.GetExistUserName("0308" + txtUser.Text).Tables[0];
      
        if (dt.Rows.Count > 0)
        {
            errMsg.Text = "User Name Already Existed";
        }
        else
        {
            //string epfno = accesscls.GetEpfNo(txtUser.Text);
            //if (epfno == txtUser.Text)
            //{
                message = newUserRecord();
                tblNew.Visible = false;
                if (message == "Invalid Password...")
                {
                    Label2.Text = "Invalid Password. Please try again";
                //tblSubId.Visible = true;
                }
                else
                {
                    Label2.Text = "You Have Successfully Assigned User For main programs \n Please Assign Sub programs if only you have the Authority";
                    tblSubId.Visible = true;
                }

            //}
        }
        
        LoadSubId();
    }

    private string newUserRecord()
    {
        enc = new Encryption();
        accesscls = new AccessCodes();
        string returnvalue = "";

        string password = txtPw.Text;
        if (accesscls.validatePassword(password))
        {
            password = enc.encryptPassword(txtPw.Text.ToString());
            int rowadded = accesscls.InsertUserDetails("0308" + txtUser.Text.ToString(), ddlstatus.SelectedValue.ToString(), password,
                                             int.Parse(txtEpfNo.Text.ToString()), txtName.Text.ToString(), txtDesig.Text.ToString(),
                                             "A", true, "0308", 100, Session["userid"].ToString(), System.DateTime.Now);

            returnvalue = "You Have Successfully Assigned User For main programs \n Please Assign Sub programs if only you have the Authority";

            foreach (GridViewRow gv in grvAccess.Rows)
            {
                CheckBox chk = new CheckBox();
                chk = (CheckBox)gv.FindControl("chkno");
                if (chk.Checked)
                {
                    accesscls.InsertPrgAccessDet("0308" + txtUser.Text, int.Parse(gv.Cells[1].Text), 100);
                }
            }

            accesscls.InsertPrgAccessDet("0308" + txtUser.Text, 22, 100);
            accesscls.InsertPrgAccessDet("0308" + txtUser.Text, 23, 100);
        }
        else
        {
            returnvalue = "Invalid Password...";
        }

        return returnvalue;
    }
    //private void newUserRecord()
    //{

    //    int rowadded = accesscls.InsertUserDetails("0308" + txtUser.Text.ToString(), ddlstatus.SelectedValue.ToString(), txtPw.Text.ToString(),
    //                                     int.Parse(txtEpfNo.Text.ToString()), txtName.Text.ToString(), txtDesig.Text.ToString(),
    //                                     "A", true, "0308", 100);

    //    //accesscls.InsertUserDetails("0308"+txtUser.Text.ToString(), ddlstatus.SelectedValue.ToString(), txtPw.Text.ToString(),
    //      //                               int.Parse(txtEpfNo.Text.ToString()), txtName.Text.ToString(), txtDesig.Text.ToString(),
    //       //                              "A",true,"0308", 100);
    //    foreach (GridViewRow gv in grvAccess.Rows)
    //    {
    //        CheckBox chk = new CheckBox();
    //        chk = (CheckBox)gv.FindControl("chkno");
    //        if (chk.Checked)
    //        {
    //            accesscls.InsertPrgAccessDet("0308"+txtUser.Text, int.Parse(gv.Cells[1].Text),100);
    //        }
    //    }

    //    accesscls.InsertPrgAccessDet("0308" + txtUser.Text, 22, 100);
    //    accesscls.InsertPrgAccessDet("0308" + txtUser.Text, 23, 100);
    //}

    //If New Users
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Label2.Text = "";//Loading Program access Names
        dt = accesscls.LoadAllPrgNames(true).Tables[0];
        grvAccess.DataSource = dt;
        grvAccess.DataBind();

        tblNew.Visible = false;
        tblEx.Visible = false;
        pnlEPF.Visible = true;
        tbresetpassword.Visible = false;
    }
    
    //Exisiting Users
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        //Loading Usernames in a DropDownList
        tbresetpassword.Visible = false;
        dvUserDet.Visible = false;
        grvExUsers.Visible = false;

        dt = accesscls.LoadUserDet().Tables[0];
        ddlUser.DataSource = dt;
        ddlUser.DataTextField = "UserId";
        ddlUser.DataValueField = "UserId";
        ddlUser.DataBind();
        ddlUser.Items.Insert(0, "");

        tblNew.Visible = false;
        tblEx.Visible = true;
        pnlEPF.Visible = false;
    }
    
    //Show Already selected access details for a selected user
    protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label2.Text = "";
        grvExUsers.Visible = true;
        dvUserDet.Visible = true;
        loadExUser();

        LoadSelectedPrg();
        dt = accesscls.GetExistUserName(ddlUser.SelectedValue.ToString()).Tables[0];
        dvUserDet.DataSource = dt;
        dvUserDet.DataBind();

        
    }

    private void loadExUser()
    {
        dt = accesscls.ShowAllPrograms().Tables[0];
        grvExUsers.DataSource = dt;
        grvExUsers.DataBind();
        dt.Dispose();
    }

    private void LoadSelectedPrg()
    {
        foreach (GridViewRow gr in grvExUsers.Rows)
        {

            dt = accesscls.GetExistPrgId(ddlUser.SelectedValue.ToString(), int.Parse(gr.Cells[1].Text)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ((CheckBox)gr.FindControl("chkno")).Enabled = false;
                ((Label)gr.FindControl("lblstat")).Text = "OK";
                ((LinkButton)gr.FindControl("LinkButton3")).Enabled = true;
            }
        }
    }
    
    //Insert some more selected access programs
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gv in grvExUsers.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gv.FindControl("chkno");
            if (chk.Checked)
            {
                accesscls.InsertPrgAccessDet(ddlUser.SelectedValue.ToString(), int.Parse(gv.Cells[1].Text),100);
            }
        }
        loadExUser();
        LoadSelectedPrg();
    }
    protected void grvExUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string prgig = ((Label)grvExUsers.Rows[e.RowIndex].FindControl("prg")).Text;
        accesscls.DeleteUsersPrgId(ddlUser.SelectedValue.ToString(), int.Parse(prgig));
        loadExUser();
        LoadSelectedPrg();

    }

    private void LoadSubId()
    {
        dt = accesscls.ShowSubPrgIds("0308"+txtUser.Text).Tables[0];
        grvSubPrg.DataSource = dt;
        grvSubPrg.DataBind();
    }

    protected void btnSubId_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gv in grvSubPrg.Rows)
        {
            CheckBox chk = new CheckBox();
            chk = (CheckBox)gv.FindControl("chkSub");
            if (chk.Checked)
            {
                accesscls.InsertPrgAccessDet("0308"+txtUser.Text, int.Parse(gv.Cells[1].Text), 100);
            }
        }
        tblSubId.Visible = false;
        Label2.Text = "You have successfully assigned Sub Programs";
    }

    protected void lbnResetPassword_Click(object sender, EventArgs e)
    {
        tblEx.Visible = false;
        tblNew.Visible = false;
        tblSubId.Visible = false;
        tbresetpassword.Visible = true;
        pnlEPF.Visible = false;

        dt = accesscls.LoadUserDet().Tables[0];
        ddlUserList.DataSource = dt;
        ddlUserList.DataTextField = "UserId";
        ddlUserList.DataValueField = "UserId";
        ddlUserList.DataBind();
        ddlUserList.Items.Insert(0, "");
    }

    protected void btnresetpaswdsave_Click(object sender, EventArgs e)
    {
        accesscls = new AccessCodes();
        enc = new Encryption();
        int reRows = 0;
        string resetPassword = txtResetPassword.Text.ToString();

        if (accesscls.validatePassword(resetPassword))
        {
            resetPassword = enc.encryptPassword(resetPassword);
            reRows = accesscls.ResetPassword(ddlUserList.SelectedValue.ToString(), resetPassword);

            if (reRows > 0)
            {
                lblResetPasd.Text = "Reset the password ...";
            }
            else
            {
                lblResetPasd.Text = "Please contact system admin....";
            }
        }
    }
    protected void btnstatus_Click(object sender, EventArgs e)
    {
        accesscls = new AccessCodes();
        string status = ddlchangestatus.SelectedValue.ToString();
        string username = ddlUser.SelectedValue.ToString();
        accesscls.Updatestatus(username, status);
        dt = accesscls.GetExistUserName(ddlUser.SelectedValue.ToString()).Tables[0];
        dvUserDet.DataSource = dt;
        dvUserDet.DataBind();
    }
    protected void txtEpfNo_TextChanged(object sender, EventArgs e)
    {
        //accesscls = new AccessCodes();
        //string epfno = accesscls.GetEpfNo(txtEpfNo.Text);
        //if (epfno == txtEpfNo.Text)
        accesscls = new AccessCodes();
        string EPF = txtEpfNo.Text.ToString().Trim();
        string epfno = accesscls.GetEpfNo(EPF);
        string epfno1 = epfno.Trim();
        if (epfno1 == txtEpfNo.Text.ToString().Trim())

        {
            dt = accesscls.GetExistUserName("0308" + txtEpfNo.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                tblNew.Visible = false;
                tblEx.Visible = false;
                lblEpfNo.Text = "Username aslready existed";
            }
            else
            {
                tblNew.Visible = true;
                tblEx.Visible = false;
                DataTable dte = new DataTable();
                dte = accesscls.GetEPFDetails(epfno);
                string userid = dte.Rows[0]["EpfNo"].ToString();
                string username = dte.Rows[0]["FullName"].ToString();
                txtUser.Text = userid;
                txtName.Text = username;
                lblEpfNo.Text = "";
            }
        }
        else
        {
            tblNew.Visible = false;
            lblEpfNo.Text = "Wrong EPFNo";
        }
    }
    
}
