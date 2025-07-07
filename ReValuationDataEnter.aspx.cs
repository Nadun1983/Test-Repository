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

public partial class ReValuationDataEnter : System.Web.UI.Page
{
    ValuationFunctions vf;
    FunctionClass fc;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtappno_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        vf = new ValuationFunctions();
        fc = new FunctionClass();
        dt = new DataTable();

        string appno = txtappno.Text;
        string Valuersname = vf.GetrecentValuerName(appno);
        valuername.Text = Valuersname;
        dateofvaluation.Focus();
        hfappno.Value = appno;
        if (Valuersname != "0")
        {
            dt = vf.GetDetails(appno);
            if (dt.Rows.Count > 0)
            {
                dateofvaluation.Text = dt.Rows[0]["dateofval"].ToString();
                presentvaluation.Text = dt.Rows[0]["presentval"].ToString();
                completevaluation.Text = dt.Rows[0]["completeval"].ToString();
                forcedsalevaluation.Text = dt.Rows[0]["forceval"].ToString();
                accessroad.Text = dt.Rows[0]["accessroad"].ToString();
                valuercomment.Text = dt.Rows[0]["valuercomments"].ToString();
                remarks.Text = dt.Rows[0]["remarks"].ToString();
            }
            else
            {
                lblMsg.Text = "Please assign valuer before do access this function..";
            }
        }
    }

    protected void valuername_TextChanged(object sender, EventArgs e)
    {

    }
    protected void dateofvaluation_TextChanged(object sender, EventArgs e)
    {
        presentvaluation.Focus();
    }
    protected void presentvaluation_TextChanged(object sender, EventArgs e)
    {
        completevaluation.Focus();
    }
    protected void completevaluation_TextChanged(object sender, EventArgs e)
    {
        forcedsalevaluation.Focus();
    }
    protected void forcedsalevaluation_TextChanged(object sender, EventArgs e)
    {
        accessroad.Focus();
    }
    protected void accessroad_TextChanged(object sender, EventArgs e)
    {
        valuercomment.Focus();
    }
    protected void valuercomment_TextChanged(object sender, EventArgs e)
    {
        remarks.Focus();
    }
    protected void remarks_TextChanged(object sender, EventArgs e)
    {
        btnSave.Focus();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        vf = new ValuationFunctions();
        fc = new FunctionClass();
        decimal completeVal = 0;
        DateTime dateofval = fc.GetDate("01012000");
        try
        {
            completeVal = decimal.Parse(completevaluation.Text);
            dateofval = fc.GetDate(dateofvaluation.Text);
        }
        catch (Exception ercval)
        {
            completeVal = 0;
        }

        try
        {
            if (dateofval >= fc.GetDate("01017000"))
            {
                lblMsg.Text = "Error. Check you entered date....";
            }
            else
            {
                int a = vf.updateReValuationReport(hfappno.Value.ToString(), dateofval, decimal.Parse(presentvaluation.Text),
                    completeVal, decimal.Parse(forcedsalevaluation.Text), 97, accessroad.Text, valuercomment.Text, remarks.Text);

                if (a > 0)
                    lblMsg.Text = "succesfully Saved";
                else
                    lblMsg.Text = "Error. Please contact system Admin";
            }

        }
        catch (Exception er1)
        {
            lblMsg.Text = "Error. Please contact system Admin";
        }
    }

    protected void btnGetAppno_Click(object sender, EventArgs e)
    {
        vf = new ValuationFunctions();
        string appno = vf.getAppNoFromCracno(txtcracno.Text.ToString());
        txtappno.Text = appno.ToString();
    }
}
