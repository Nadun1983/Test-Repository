using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Administration_MasterChanges : System.Web.UI.Page
{
    FunctionClass fc;
    Recovery rc;
    EditMasterRecords emr;
    DataTable dt;
    static string user;
    static string cracno, appno, acstatus, aprovdamt, grantamt, isdisburse;
    static double outbal, Interestamt, intrate, actoutbal, intrete, instalment, yearbeginbal;
    static string  duenotice, catpurposeid;
    static DateTime Datedue, LastCompletedduedate, Grantdate;
    static DateTime lsttrdate, lstpaiddate, lstreptdate, adddate, penalvaliddate, closeDate, noticedate;
    static string adduser, isdisbursed, recstatus;
    static int noOfInstalment, crperiod, crcat, paidinstalments, graceperiod, recptperiod, loanstatuscode;
    static long disbrefno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fc = new FunctionClass();
            dt = new DataTable();
            rc = new Recovery();
            emr = new EditMasterRecords();

            fc = new FunctionClass();
            user = Session["userid"].ToString();
            string progname = "Administration/MasterChanges.aspx";
            if (fc.IsValid(progname, user))
            {
            
            cracno = Session["cracno"].ToString();
            dgvmaster.DataSource = emr.GetMasterData(cracno);
            dgvmaster.DataBind();

            DataTable datat = new DataTable();
            datat = emr.GetMasterData(cracno);
            txtcracno.Text = cracno.ToString();
            //txtcracno.Text = datat.Rows[0]["cracno"].ToString();
            txtintrate.Text = datat.Rows[0]["intrate"].ToString();
            txtinstalment.Text = datat.Rows[0]["instalment"].ToString();
            txtoutbal.Text = datat.Rows[0]["outbal"].ToString();
            txtactoutbal.Text = datat.Rows[0]["actoutbal"].ToString();
            //txtdatedue.Text = fc.GetDateinDateKeystr(fc.GetDisplayDate(DateTime.Parse(datat.Rows[0]["datedue"].ToString())));
            txtdatedue.Text = fc.GetDateinDateKeystr(DateTime.Parse(datat.Rows[0]["datedue"].ToString()));
            txtlastcompletedduedate.Text = fc.GetDateinDateKeystr(DateTime.Parse(datat.Rows[0]["lastcompletedduedate"].ToString()));
            txtgrantdate.Text = fc.GetDateinDateKeystr(DateTime.Parse(datat.Rows[0]["grantdate"].ToString()));
            txtNoOfinstalment.Text = datat.Rows[0]["crperiod"].ToString();
            txtpenalvaliddate.Text = fc.GetDateinDateKeystr(DateTime.Parse(datat.Rows[0]["penalvaliddate"].ToString()));


            //crmast
            appno = datat.Rows[0]["appno"].ToString();
            acstatus = datat.Rows[0]["acstatus"].ToString();
            aprovdamt = datat.Rows[0]["aprovdamt"].ToString();
            grantamt = datat.Rows[0]["grantamt"].ToString();
            closeDate = DateTime.Parse(datat.Rows[0]["closeDate"].ToString());
            duenotice = datat.Rows[0]["duenotice"].ToString();
            noticedate = DateTime.Parse(datat.Rows[0]["noticedate"].ToString());
            catpurposeid = datat.Rows[0]["catpurposeid"].ToString();
            isdisburse = datat.Rows[0]["isdisburse"].ToString();
            crcat = int.Parse(datat.Rows[0]["crcat"].ToString());
            //housprop
            graceperiod = int.Parse(datat.Rows[0]["graceperiod"].ToString());
            lsttrdate = DateTime.Parse(datat.Rows[0]["lsttrdate"].ToString());
            lstpaiddate = DateTime.Parse(datat.Rows[0]["lstpaiddate"].ToString());
            lstreptdate = DateTime.Parse(datat.Rows[0]["lstreptdate"].ToString());
            recptperiod = int.Parse(datat.Rows[0]["recptperiod"].ToString());
            yearbeginbal = double.Parse(datat.Rows[0]["yearbeginbal"].ToString());
            adduser = datat.Rows[0]["adduser"].ToString();
            adddate = DateTime.Parse(datat.Rows[0]["adddate"].ToString());
            //lastcompletedduedate = datat.Rows[0]["lastcompletedduedate"].ToString();
            isdisbursed = datat.Rows[0]["isdisbursed"].ToString();
            //crperiod = datat.Rows[0]["crperiod"].ToString();
            loanstatuscode = int.Parse(datat.Rows[0]["loanstatuscode"].ToString());
            paidinstalments = int.Parse(datat.Rows[0]["paidinstalments"].ToString());
            penalvaliddate = DateTime.Parse(datat.Rows[0]["penalvaliddate"].ToString());
            recstatus = datat.Rows[0]["recstatus"].ToString();
            //disbrefno = long.Parse(datat.Rows[0]["disbrefno"].ToString());


            intrate = double.Parse(datat.Rows[0]["intrate"].ToString());
            instalment = double.Parse(datat.Rows[0]["instalment"].ToString());
            outbal = double.Parse(datat.Rows[0]["outbal"].ToString());
            actoutbal = double.Parse(datat.Rows[0]["actoutbal"].ToString());
            Datedue = DateTime.Parse(datat.Rows[0]["Datedue"].ToString());
            LastCompletedduedate = DateTime.Parse(datat.Rows[0]["LastCompletedduedate"].ToString());
            Grantdate = DateTime.Parse(datat.Rows[0]["Grantdate"].ToString());
            noOfInstalment = int.Parse(datat.Rows[0]["crperiod"].ToString());
            hfcrperiod.Value=datat.Rows[0]["crperiod"].ToString();

            dgvRecipPeriod.DataSource = emr.GetReciptDate(cracno);
            dgvRecipPeriod.DataBind();
            txtReciptPeriod.Text = recptperiod.ToString();
            
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }
    }


    protected void btnupdatemaster_Click(object sender, EventArgs e)
    {
        int rows = 0;
        emr = new EditMasterRecords();
        fc = new FunctionClass();

        int newcrperiod=int.Parse(hfcrperiod.Value.ToString());
        rows = rows + emr.InsertDatatocrmastHistory(cracno, fc.GetSystemDate("A").ToString(), intrate.ToString(), appno,
                      acstatus, noOfInstalment.ToString(), double.Parse(aprovdamt).ToString(),
                      double.Parse(grantamt).ToString(), Grantdate.ToString(), instalment.ToString(), closeDate.ToString(),
                      duenotice, noticedate.ToString(), catpurposeid, isdisburse, user);
        rows += emr.InsertHouspropHistry(fc.GetSystemDate("A"),cracno, fc.GetSystemDate("A"), intrate, instalment,
                outbal,Datedue , graceperiod, lsttrdate, lstpaiddate, lstreptdate,
                recptperiod, yearbeginbal, adduser, adddate, LastCompletedduedate, isdisbursed, crperiod,
               loanstatuscode, paidinstalments, actoutbal, penalvaliddate, recstatus, user,instalment,
               intrate, LastCompletedduedate, newcrperiod, actoutbal, crcat, crcat, cracno);

        intrate = double.Parse(txtintrate.Text.ToString());
        instalment = double.Parse(txtinstalment.Text.ToString());
        outbal = double.Parse(txtoutbal.Text.ToString());
        actoutbal = double.Parse(txtactoutbal.Text.ToString());
        Datedue = fc.GetDateinDateKey(txtdatedue.Text);
        //Datedue = DateTime.Parse(txtdatedue.Text.ToString());
        LastCompletedduedate = fc.GetDateinDateKey(txtlastcompletedduedate.Text);
        Grantdate = fc.GetDateinDateKey(txtgrantdate.Text);
        noOfInstalment = int.Parse(txtNoOfinstalment.Text.ToString());
        crperiod = int.Parse(txtNoOfinstalment.Text.ToString());
        penalvaliddate = fc.GetDateinDateKey(txtpenalvaliddate.Text);

        

        rows += emr.UpdateMasterDataInCrMast(Grantdate, cracno, intrate, instalment, outbal,double.Parse(grantamt) , Datedue, LastCompletedduedate,   crperiod, actoutbal);
        rows += emr.UpdateMasterDataInHousprop(cracno, intrate, instalment, outbal, Datedue, LastCompletedduedate, crperiod, actoutbal, penalvaliddate);

    }

    protected void btnreciptpd_Click(object sender, EventArgs e)
    {
        emr = new EditMasterRecords();
        emr.UpdateReciptPeriod(cracno, recptperiod.ToString());
    }
    protected void txtReciptPeriod_TextChanged(object sender, EventArgs e)
    {
         recptperiod = int.Parse(txtReciptPeriod.Text);
    }
}
