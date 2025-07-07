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

public partial class AppNoSearch : System.Web.UI.Page
{
    ExistAppNos excls = new ExistAppNos();
    DataTable dt = new DataTable();
    AccessCodes ac;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack != true)
        {
            try
            {
                FunctionClass fc = new FunctionClass();
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string username = Session["userid"].ToString();
                string progname = "AppNoSearch.aspx";
                if (fc.IsValid(progname, username))
                {
                    lblCaption.Text = Session["description"].ToString();
                    txtappno.Focus();
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
 
    protected void txtappno_TextChanged(object sender, EventArgs e)
     {
        ac = new AccessCodes();
        string username = Session["userid"].ToString();
        string brcode;
        string acountbrcode;
        string appno = "0";
        dt = new DataTable();
        //try
        //{
        //    Convert.ToInt64(txtappno.Text);
        //}
        //catch(Exception ex)
        //{
        //    Label1.Text = "Please Enter Correct Application Number " + ex;
        //}

        appno = txtappno.Text.ToString().Trim();
        string ip = Request.ServerVariables["REMOTE_ADDR"].ToString();
        string sectype = ac.GetSecurityType(appno);
        //if (ac.GetAccess(appno, username, ip))
        //{
            //dt = excls.ExistApplication(appno);

            //if (dt.Rows.Count > 0)
            //{

                brcode = Session["brcode"].ToString();
                string brname = Session["brname"].ToString();
                //string sectype = dt.Rows[0]["SecurityType"].ToString();

                Session["appno"] = txtappno.Text;
                Session["userid"] = username;
                Session["brcode"] = brcode;
                Session["brname"] = brname;
                
                Session["sectype"] = sectype;
                Session["type"] = "F";
                string prgname = Session["prgname"].ToString();
                Response.Redirect(prgname);
            //}

            //else
            //{
            //    Label1.Text = "AppNo Not exist";
            //}
        //}
        //else
        //{
        //    Label1.Text = "not a valid code";
        //}

    }
}
