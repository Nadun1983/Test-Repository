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

public partial class ToDisburse : System.Web.UI.Page
{
    # region Variables
    LastSerialClass ls;
    DisbursementClass dc;
    FunctionClass fc;
    ApprovalClass ac;
    static DataTable SecondryDetails;
    static string selectAppno;
    static string enteredAppno;
    static string appno, cracno;
    static double approveamount, installment, intrate;
    static string AcStatus, user;
    static int crcatcode, crperiod, catpurposeid;
    static DateTime datedue;
    DataTable dt;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                user = Session["userid"].ToString();
                string progname = "ToDisburse.aspx";
                if (fc.IsValid(progname, user))
                {
                    dc = new DisbursementClass();
                    dt = new DataTable();
                    dt = dc.GetApplicationsToDisb("A", false);
                    if (dt.Rows.Count != 0)
                    {
                        lblMsg.Text = dt.Rows.Count + " Loans to Disburse";
                        dgvLoanToDisb.DataSource = dt;
                        dgvLoanToDisb.DataBind();
                        panelEnterAppNo.Visible = false;
                    }
                    else
                    {
                        lblMsg.Text = "No loans to Disburse";
                    }
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

    protected void dgvLoanToDisb_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        selectAppno = dgvLoanToDisb.Rows[e.NewSelectedIndex].Cells[1].Text.ToString();
        panelEnterAppNo.Visible = true;
        txtAppno.Focus();
    }
    protected void txtAppno_TextChanged(object sender, EventArgs e)
    {
        dc = new DisbursementClass();
        enteredAppno = txtAppno.Text;
        if (enteredAppno == selectAppno)
        {
            dgvPrimaryDetails.DataSource = dc.GetPrimaryDetails(enteredAppno);
            dgvPrimaryDetails.DataBind();
            SecondryDetails = dc.GetSecondryDetails(enteredAppno);
            dgvSeconderyDetails.DataSource = SecondryDetails;
            dgvSeconderyDetails.DataBind();
            lblMsg.Text = "Selected Aplication number is " + enteredAppno;

            btnTransAppDetails.Visible = true;
        }
        else
        {
            lblMsg.Text = "Enter correct application number";
        }
    }
    protected void btnTransAppDetails_Click(object sender, EventArgs e)
    {
        appno = txtAppno.Text;
	    double totalamt = 0;

        ls = new LastSerialClass();
        //fc = new FunctionClass();
        dc = new DisbursementClass();
        //AcStatus = "A";
        //if ((txtCrAcNo.Text.Length % 14 == 0) || (txtCrAcNo.Text.Length % 13 == 0))
        //{
        //    cracno = txtCrAcNo.Text; ;
        //string[] w = new string[SecondryDetails.Rows.Count];
        //w = cracno.Split('|');
        ac = new ApprovalClass();
        fc = new FunctionClass();
        // Get CrAcNo
        long longCrAcNo = ac.GetCrAcNo("CRACNO", true);
        if (longCrAcNo == 0)
        {
            lblMsg.Text = "A Loan is processing Please try again";
            return;
        }
        else
        {
            //longCrAcNo += 1;
            //cracno = "603080" + (longCrAcNo).ToString();
            //cracno = cracno + fc.GetModuler10(cracno);
            SecondryDetails = dc.GetSecondryDetails(appno);
        //vihanga 2009-08-01
        //}
            for (int i = 0; i < SecondryDetails.Rows.Count; i++)
            {

                //vihanga 2009-08-01
                longCrAcNo += 1;
                cracno = "60308" + (longCrAcNo).ToString();
                cracno = cracno + fc.GetModuler10(cracno);


               // cracno=w[i].ToString();

                string serial;
                
                approveamount = double.Parse(SecondryDetails.Rows[i][1].ToString());
		        totalamt = double.Parse(SecondryDetails.Rows[i][17].ToString());
                
                //vihanga 2009-08-01
                //serial = ls.GetMaxNumber("CRACNO", true).ToString("0000000");
                //serial = longCrAcNo.ToString();
                
                
                //string brcode = fc.GetBranchCode(user);
                //cracno = "6" + brcode + serial;
                //cracno += fc.GetModuler10(cracno);

                dgvSeconderyDetails.DataSource = SecondryDetails;
                dgvSeconderyDetails.DataBind();
                
                crcatcode = int.Parse(SecondryDetails.Rows[i][3].ToString());
                crperiod = int.Parse(SecondryDetails.Rows[i][12].ToString());
                intrate = double.Parse(SecondryDetails.Rows[i][9].ToString());
                installment = fc.GetMonthlyInstalmentRounded(approveamount, intrate, crperiod);
                catpurposeid = int.Parse(SecondryDetails.Rows[i][10].ToString());

                // Insert CrMast
                if (dc.InsertCrMast("A", appno, approveamount, cracno, crcatcode, crperiod, installment, intrate, 0, catpurposeid,0) != 0)
                {
                    //2009-05-13 vihanga**
                    //calculate datedue
                    double crappamt, crgrantamt;
                    DateTime crgrantdate;
                    DataTable tmp = new DataTable();
                    tmp = dc.ConfirmFullyGrant(cracno);
                    crappamt = Convert.ToDouble(tmp.Rows[0]["aprovdamt"].ToString());
                    crgrantamt = Convert.ToDouble(tmp.Rows[0]["grantamt"].ToString());

                    //Insert House Prop
                    if (dc.InsertHousProp(fc.GetSystemDate("A"), user, cracno, installment, "N", crperiod, 1, crcatcode, intrate /*for performing loan*/) != 0)
                    {

			            if ((crcatcode == 1) && (totalamt > 5000000.00))
                        {
                            dc.InsertLoanFloatingRates(appno, cracno, totalamt, approveamount, intrate, 0.00, "Y");
                        }

                        for (int q = 0; q < dgvPrimaryDetails.Rows.Count; q++)
                        {
                            string nicno = dgvPrimaryDetails.Rows[q].Cells[2].Text.ToString();
                            string holdertype = dgvPrimaryDetails.Rows[q].Cells[3].Text.ToString();
                            if (dc.InsertCrHolder(nicno, appno, cracno, holdertype) != 0)
                            {
                                lblMsg.Text += " Application successfully transfered " + cracno;
                                dc.UpdateIsToDisburseInApprovalStat(appno, true);
                                
                                //vihanga 2009-08-01
                                ls.UpdateLastserial("cracno", longCrAcNo);
                            }

                            else
                            {
                                ls.UpdateLastSerialStatus("cracno", true);
                            }
                        }
                    }
                    else
                    {
                        ls.UpdateLastSerialStatus("cracno", true);
                    }
                }
                else
                {
                    ls.UpdateLastSerialStatus("cracno", true);
                }

            }

            dgvLoanToDisb.DataSource = dc.GetApplicationsToDisb("A", false);
            dgvLoanToDisb.DataBind();

            dgvLoanDetails.DataSource = dc.GetApprovedLoanDetails(appno);
            dgvLoanDetails.DataBind();

            btnTransAppDetails.Visible = false;
        }
}

        //else
        //{
        //    lblMsg.Text = "Invalid Account Number";
        //}
    protected void dgvSeconderyDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        dc = new DisbursementClass();
        dgvSeconderyDetails.EditIndex = e.NewEditIndex;
        SecondryDetails = dc.GetSecondryDetails(txtAppno.Text);
        dgvSeconderyDetails.DataSource = SecondryDetails;
        dgvSeconderyDetails.DataBind();
    }


    protected void dgvSeconderyDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        dc = new DisbursementClass();
        dgvSeconderyDetails.EditIndex = -1;
        SecondryDetails = dc.GetSecondryDetails(txtAppno.Text);
        dgvSeconderyDetails.DataSource = SecondryDetails;
        dgvSeconderyDetails.DataBind();
    }
    protected void dgvSeconderyDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        dc = new DisbursementClass();
        SecondryDetails = dc.GetSecondryDetails(txtAppno.Text);
        dgvSeconderyDetails.DataSource = SecondryDetails;
        //fc = new FunctionClass();
        //double AssignAmt = double.Parse(((TextBox)dgvPaymentList.Rows[e.RowIndex].Cells[3].Controls[1]).Text.ToString());
        DropDownList ddlcat = (DropDownList)dgvSeconderyDetails.Rows[e.RowIndex].Controls[0].FindControl("ddlCategory");

        SecondryDetails.Rows[e.RowIndex]["LoanCategory"] = ddlcat.SelectedItem.Text;
        string purposecode = SecondryDetails.Rows[e.RowIndex][16].ToString();
        SecondryDetails.Rows[e.RowIndex][3] = int.Parse(ddlcat.SelectedValue.ToString());
        //SecondryDetails.Rows[e.RowIndex][10] = dc.GetCrCatPurposeId(ddlcat.SelectedValue.ToString(), purposecode);

        int newcatpurposeid = dc.GetCrCatPurposeId(ddlcat.SelectedValue.ToString(), purposecode);
        int oldcatpurposeid = int.Parse(SecondryDetails.Rows[e.RowIndex][10].ToString());
        appno = txtAppno.Text;
        double intrate = double.Parse(SecondryDetails.Rows[e.RowIndex][9].ToString());
        double approveamount = double.Parse(SecondryDetails.Rows[e.RowIndex][1].ToString());
        dc.UpdateAppCategory(appno, intrate, newcatpurposeid, approveamount, oldcatpurposeid);

          
        dgvSeconderyDetails.EditIndex = -1;
        dgvSeconderyDetails.DataSource = SecondryDetails;
        dgvSeconderyDetails.DataBind();
    }
}