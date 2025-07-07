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
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text.RegularExpressions;
using System.Net.Mail;


public partial class SalaryTextFile : System.Web.UI.Page
{
    PrintClass p;
    FunctionClass fc;
    CribCalculateNDIA ccn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                FunctionClass fc = new FunctionClass();
                string username = Session["userid"].ToString();
                string progname = "SalaryTextFile.aspx";
                if (fc.IsValid(progname, username))
                {
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
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        MonthlyProcessClass mp = new MonthlyProcessClass();
        TextFileClass tfc = new TextFileClass();
        DataTable dt = new DataTable();
        dt = mp.getSalaryBatchData();
        string txtfilename = DateTime.Now.ToString("yyyyMMM");

        string inptemppath = @"c:\CreditSystem\SalaryBatchData\Temp\LoanSalaryBatch-" + txtfilename + ".txt";
        string inpfilepath = @"c:\CreditSystem\SalaryBatchData\LoanSalaryBatch-" + txtfilename + ".txt";

        string createmode = tfc.CreateNewFile(inptemppath, inpfilepath);
        if (createmode == "Success")
        {
            foreach (DataRow dr in dt.Rows)
            {
                tfc.writeToFile(dr[0].ToString(), inpfilepath);
            }

            lblMsg.Text = "File create success. File name = LoanSalaryBatch-" + txtfilename + ".txt";
        }
        else
        {
            lblMsg.Text = createmode;
        }
    }
    protected void btnCentral_Click(object sender, EventArgs e)
    {
        MonthlyProcessClass mp = new MonthlyProcessClass();
        TextFileClass tfc = new TextFileClass();
        DataTable dt = new DataTable();
        dt = mp.getCentralLiabilityData();
        string txtfilename = DateTime.Now.ToString("yyyyMMMdd");

        string inptemppath = @"c:\CreditSystem\CentralData\Temp\LIAB_CRH" + txtfilename + ".txt";
        string inpfilepath = @"C:\CreditSystem\CentralData\LIAB_CRH" + txtfilename + ".txt";

        string createmode = tfc.CreateNewFile(inptemppath, inpfilepath);
        if (createmode == "Success")
        {
            foreach (DataRow dr in dt.Rows)
            {
                tfc.writeToFile(dr[0].ToString(), inpfilepath);
            }

            lblMsg.Text = "File create success. File name = CreditDivCentralData-" + txtfilename + ".txt";
        }
        else
        {
            lblMsg.Text = createmode;
        }

        //string ftpfullpath = "ftp://10.1.0.232//liadetail//LIAB_CRH"+txtfilename+".txt";    //"ftp://" + ftphost + ftpfilepath;   

        string ftpfullpath = "ftp://10.1.0.232//liadetail//LIAB_CRHeadOffice.txt"; 
        FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
        ftp.Proxy = null;
        ftp.Credentials = new NetworkCredential("lia", "lia@234");
        //userid and password for the ftp server to given   

        ftp.KeepAlive = true;
        ftp.UseBinary = true;
        ftp.Method = WebRequestMethods.Ftp.UploadFile;
        FileStream fs = File.OpenRead(inpfilepath);
        byte[] buffer = new byte[fs.Length];
        fs.Read(buffer, 0, buffer.Length);
        fs.Close();
        Stream ftpstream = ftp.GetRequestStream();
        ftpstream.Write(buffer, 0, buffer.Length);
        ftpstream.Close();

    }
    protected void btnArreas_Click(object sender, EventArgs e)
    {
        MonthlyProcessClass mp = new MonthlyProcessClass();
        FunctionClass fc = new FunctionClass();
        TextFileClass tfc = new TextFileClass();
        DataTable dt = new DataTable();
        DateTime indate = fc.GetDateinDateKey(txtDate.Text);
        string datekey = fc.GetDateKeyinDate(txtDate.Text);
        string currentdate = fc.GetStringDate(DateTime.Parse(DateTime.Now.ToString()));
        dt = mp.getArreasData(datekey, indate);
        //string txtfilename = DateTime.Now.ToString("yyyyMMMdd");

        string inptemppath = @"D:\CreditSystem\LoanReminder\Temp\CLR_0308_" + currentdate + ".txt";
        string inpfilepath = @"D:\CreditSystem\LoanReminder\CLR_0308_" + currentdate + ".txt";

        string createmode = tfc.CreateNewFile(inptemppath, inpfilepath);
        if (createmode == "Success")
        {
            foreach (DataRow dr in dt.Rows)
            {
                tfc.writeToFile(dr[0].ToString(), inpfilepath);
            }

            lblMsg.Text = "File create success. File name = LoanReminderLetters-" + currentdate + ".txt";
        }
        else
        {
            lblMsg.Text = createmode;
        }

        //string ftpfullpath = "ftp://10.1.0.232//liadetail//LIAB_CRH"+txtfilename+".txt";    //"ftp://" + ftphost + ftpfilepath;   

        //string ftpfullpath = "ftp://10.1.40.26//LoanReminder//CLR_0308_" + currentdate + ".txt";
        //FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
        //ftp.Proxy = null;
        //ftp.Credentials = new NetworkCredential("Aruni", "nsb@123456");
        ////userid and password for the ftp server to given   

        //ftp.KeepAlive = true;
        //ftp.UseBinary = true;
        //ftp.Method = WebRequestMethods.Ftp.UploadFile;
        //FileStream fs = File.OpenRead(inpfilepath);
        //byte[] buffer = new byte[fs.Length];
        //fs.Read(buffer, 0, buffer.Length);
        //fs.Close();
        //Stream ftpstream = ftp.GetRequestStream();
        //ftpstream.Write(buffer, 0, buffer.Length);
        //ftpstream.Close();
    }
    protected void btnSMS_Click(object sender, EventArgs e)
    {
        ArreasSMS rc = new ArreasSMS();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SendSMS sms = new SendSMS();
        FunctionClass fc = new FunctionClass();
        string datekey = fc.GetDateKeyinDate(txtDate.Text);
        string newdate = fc.GetStringLongDate(txtDate.Text);

        string user = "NSBSMS";
        string authentication = "nsbcustsms";
        if (user == "NSBSMS" && authentication == "nsbcustsms")
        {
            dt = rc.GetArreasData(datekey);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string cracno = dt.Rows[i]["cracno"].ToString();
                string ArreasDays = dt.Rows[i]["ArreasDays"].ToString();
                string ArreasTotal = dt.Rows[i]["ArreasTotal"].ToString();
                string Mobile = dt.Rows[i]["Mobile"].ToString();
                string NicNo = dt.Rows[i]["NicNo"].ToString();

                //string cracno = "603086146398";
                //string ArreasDays = "121";
                //string ArreasTotal = "715,332.75";
                //string Mobile = "0773864060";
                //string NicNo = "785900065v";

                if (Mobile.Length == 10 && Mobile.Substring(0, 2) == "07")
                {
                    string smsMsg = "Your NSB Loan No:" + cracno + " is overdue by " + ArreasDays + " days with Rs." + ArreasTotal + " as of "
                    + newdate + ". Please settle immediately to prevent instituting legal action. Pls ignore if it has been settled.";
                    WebSMSOld.Service creditSMS = new WebSMSOld.Service();
                    //SendSMSNew.Service creditSMS = new SendSMSNew.Service();
                    //WSMSGatewayNewOne.Service creditSMS = new WSMSGatewayNewOne.Service();
                    //WSsmsGateWay.Service crediSMS = new WSsmsGateWay.Service();

                    string sReturn = creditSMS.SMS_Data_INSERTINTO_SMS_Table(user, authentication, Mobile, smsMsg);

                    if (sReturn.Contains("M000|"))
                    {
                        string return2 = creditSMS.GetDataFromSMSMessageTable();
                    }
                    //string sReturn = creditSMS.Send_SMS_via_Epic_Service("NSBSMS", "nsbsms123#", Mobile, smsMsg, "HLOAN" + cracno, "HLOANRMN", "L");
                    //string sReturn = creditSMS.SMS_Data_INSERTINTO_SMS_Table("NSBSMS", "nsbcustsms", Mobile, smsMsg,cracno);
                    //string sReturn2 = crediSMS.GetDataFromSMSMessageTable();


                    rc.insertSMSLog(NicNo, Mobile, cracno, DateTime.Now, "Y", datekey);

                }
                else
                {
                    rc.insertSMSLog(NicNo, Mobile, cracno, DateTime.Now, "N", datekey);
                }

            }
        }

    }
    protected void btnEPF_Click(object sender, EventArgs e)
    {
        LoadCustomer lc = new LoadCustomer();
        DataTable myDataTable = new DataTable();
        myDataTable = SetDataTable(myDataTable);
        
        try
        {
            //UploadFileToServer(FileUpload1.FileName);
            //string Filepath = Server.MapPath("CeylincoCHQ/" + FileUpload1.FileName);
            string Filepath = "D:/Bimali_new/Staff/" + epfUpload.FileName;
            string onlyFileName = epfUpload.FileName;
            StreamReader sr = new StreamReader(Filepath);


            //string add_usr = lblTeller.Text.ToString();
            //int txn_no;
            //bool payment = true;
            //string myValue = "NULL";


            string input;
            int line = 0;
            string secondLine;
            int j = 0;

            DataRow row;

            while ((input = sr.ReadLine()) != null)
            {


                string[] words = input.Split('|');
                row = myDataTable.NewRow();
                row["epfno"] = words[0].ToString();
                row["initials"] = words[1].ToString();
                row["surname"] = words[2].ToString();
                row["NicNo"] = words[3].ToString();
                //DateTime s_issue_date = DateTime.ParseExact(words[3], "dd-MM-yyyy", CultureInfo.InvariantCulture);

                //row["issue_date"] = s_issue_date;

                //row["add_date"] = DateTime.Now;
                //row["txn_no"] = null;
                //row["payment"] = true;
                //row["expiry_date"] = s_issue_date.AddDays(55);
                myDataTable.Rows.Add(row);
                j++;
            }
            lc.InsertBulkEpfNo(myDataTable);
            
        }
        catch (Exception ex)
        {
            lblErr.Text = ex.Message;
        }
    }

    private DataTable SetDataTable(DataTable myDataTable)
    {
        DataTable dt;
        dt = new DataTable();

        DataColumn epfno;
        epfno = new DataColumn();
        epfno.DataType = Type.GetType("System.String");
        epfno.ColumnName = "epfno";
        dt.Columns.Add(epfno);

        DataColumn initials;
        initials = new DataColumn();
        initials.DataType = Type.GetType("System.String");
        initials.ColumnName = "initials";
        dt.Columns.Add(initials);

        DataColumn surname;
        surname = new DataColumn();
        surname.DataType = Type.GetType("System.String");
        surname.ColumnName = "surname";
        dt.Columns.Add(surname);

        DataColumn NicNo;
        NicNo = new DataColumn();
        NicNo.DataType = Type.GetType("System.String");
        NicNo.ColumnName = "NicNo";
        dt.Columns.Add(NicNo);

        return dt;

    }
    //protected void btnEmail_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable dt = new DataTable();
    //        SendSMS sm = new SendSMS();
    //        dt = sm.GetEmailAddressDetails();

    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            string cracno = dt.Rows[i]["cracno"].ToString();
    //            string email = dt.Rows[i]["email"].ToString();
    //            CreateReport(cracno, email);
    //        }

    //        string sMailServer = "10.1.40.20";// ConfigurationSettings.AppSettings["MailServer"];
    //        SmtpMail.SmtpServer = sMailServer;

    //        MailMessage msg = new MailMessage();

    //        string sMailFromAddress = ConfigurationSettings.AppSettings["MailFromAddress"];
    //        msg.From = "bimali.it@nsb.lk";

    //        //DateTime dDate = Convert.ToDateTime(dtProcessDate);
    //        //string sDate = dDate.Year.ToString() + " - " + dDate.Month.ToString() + " - " + dDate.Day.ToString();

    //        msg.Subject = "Customer Statement";

    //        //string[] arr = new string[5];
    //        string sAttachmentPaths = "D:/BatchPrint02102015.pdf";//"D:/BatchPrint02102015.pdf";
    //        //arr = sAttachmentPaths.Split('|');
    //        //for (int i = 0; i < arr.Length; i++)
    //        //{
    //        msg.Attachments.Add(new MailAttachment(@"D:/BatchPrint02102015.pdf"));
    //        //}
    //        msg.To = "bimali.it@nsb.lk";
    //        msg.Body = "Please Find the attachment  ";
    //        SmtpMail.Send(msg);

    //        //return "Send Successfull";
    //    }
    //    catch (Exception ex)
    //    {
    //        //return ex.Message.ToString();
    //    }
    //}

    //private void CreateReport(string cracno, string email)
    //{ 
    
    //}
    //protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    switch (RadioButtonList1.SelectedIndex)
    //    {
    //        case 0:
    //            MultiView1.ActiveViewIndex = 0;
    //            break;

    //        case 1:
    //            MultiView1.ActiveViewIndex = 1;
    //            break;

    //        case 2:
    //            MultiView1.ActiveViewIndex = 2;
    //            break;

    //        case 3:
    //            MultiView1.ActiveViewIndex = 3;
    //            break;
    //    }
    //}

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (RadioButtonList1.SelectedIndex)
        {
            case 0:
                MultiView1.ActiveViewIndex = 0;
                break;

            case 1:
                MultiView1.ActiveViewIndex = 1;
                break;

            case 2:
                MultiView1.ActiveViewIndex = 2;
                break;

            case 3:
                MultiView1.ActiveViewIndex = 3;
                break;
            case 4:
                MultiView1.ActiveViewIndex = 4;
                break;
        }
    }

    protected void rblQuter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblQuter.SelectedValue == "1st")
        {
            txtFromEmailDate.Text = "0101" + tbYear.Text;
            txtToEmailDate.Text = "3103" + tbYear.Text;
        }
        else if (rblQuter.SelectedValue == "2nd")
        {
            txtFromEmailDate.Text = "0104" + tbYear.Text;
            txtToEmailDate.Text = "3006" + tbYear.Text;
        }
        else if (rblQuter.SelectedValue == "3rd")
        {
            txtFromEmailDate.Text = "0107" + tbYear.Text;
            txtToEmailDate.Text = "3009" + tbYear.Text;
        }
        else if (rblQuter.SelectedValue == "4th")
        {
            txtFromEmailDate.Text = "0110" + tbYear.Text;
            txtToEmailDate.Text = "3112" + tbYear.Text;
        }
        else if (rblQuter.SelectedValue == "Yearly")
        {
            txtFromEmailDate.Text = "0101" + tbYear.Text;
            txtToEmailDate.Text = "3112" + tbYear.Text;
        }
    }
    protected void btnEmailStatement_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        fc = new FunctionClass();
        SendSMS sm = new SendSMS();
        dt = sm.GetEmailAddressDetails(fc.GetSystemDate("A"));
        //dt = sm.GetEmailAddressDetails(DateTime.Parse("2017/08/08"));

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string cracno = dt.Rows[i]["cracno"].ToString();
            string email = dt.Rows[i]["email"].ToString();
            string nicno = dt.Rows[i]["nicno"].ToString();
            CreateReport(cracno, email, txtFromEmailDate.Text, txtToEmailDate.Text, nicno);
        }
    }

    private void CreateReport(string cracno, string email, string emailFromDate, string emailToDate, string nicno)
    {
        fc = new FunctionClass();
        SendSMS sm = new SendSMS();

        DateTime fromdate = fc.GetDateinDateKey(emailFromDate);
        DateTime todate = fc.GetDateinDateKey(emailToDate);
        DateDifference ddf = new DateDifference(todate, fromdate);
        if (fromdate.Year > 2009 || todate < fromdate)
        {
            int transcount = sm.getTransCount(cracno, fromdate, todate);
            if (transcount > 0)
            {
                ccn = new CribCalculateNDIA();
                ccn.RecoveryProcessTempForCrib(cracno);
                double amtinarreas = ccn.TotArreas;
                int nida = ccn.NoofDaysinArreas;
                if (nida <= 30)
                {
                    amtinarreas = 0;
                    nida = 0;
                }
                LogClass logc = new LogClass();


                p = new PrintClass();
                string fpath = Server.MapPath("~/Reports/CustStatement.rpt");
                string file = @"C:\CustomerEmails\" + cracno + ".pdf"; //Server.MapPath("~/Reports/Email.pdf");
                p.SetConnectionForEmail(fpath, file, "CreditAdmin", "ncms@36", "DB195", "TDB");

                p.SetParams("cracno", cracno);
                p.SetParams("fromDate", fromdate);
                p.SetParams("toDate", todate);
                p.SetParams("ndia", nida);
                p.SetParams("amtinarreas", amtinarreas);
                p.GetPdfReportForEmail(Response);
                //p.GetPdfReport(Response);
                //p.GetDirectReport(prinerip, printername);
                //p.Close();
                SendingEmail(cracno, email, nicno);
                p.ForSendEmail(Response);
            }
            else
            {
                lblMsg.Text = "No transactions";
            }
        }
        else
        {
            lblMsg.Text = "You cannot take earlier than 2010";
        }
    }

    private void SendingEmail(string cracno, string email, string nicno)
    {
        fc = new FunctionClass();
        SendSMS sm = new SendSMS();
        //string Date = txtDate.Text.Trim().ToString();
        try
        {
            Regex regex = new Regex("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$");
            Match match = regex.Match(email);
            if (match.Success)
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpClient = new SmtpClient("nsbmail", 25);


                mail.From = new MailAddress("admin.credit@nsb.lk");
                try
                {
                    mail.To.Add(email);

                    mail.Subject = "NSB Customer statement of Loan No: " + cracno;
                    mail.Body = "Please Find the attachment.";

                    try
                    {
                        System.Net.Mail.Attachment attachment;
                        // @"C:\CustomerEmails\" + cracno + ".pdf";
                        attachment = new System.Net.Mail.Attachment(@"C:\CustomerEmails\" + cracno + ".pdf");
                        mail.Attachments.Add(attachment);
                    }
                    catch
                    {
                        lblMsg.Text = "attachment fail";
                    }

                    SmtpClient.UseDefaultCredentials = true;
                    System.Net.NetworkCredential nc = CredentialCache.DefaultNetworkCredentials;
                    SmtpClient.Credentials = (System.Net.ICredentialsByHost)nc.GetCredential("ExchangeServerNameSoll", 25, "Basic");
                    SmtpClient.Send(mail);

                    mail.Attachments.Dispose();
                    mail.Dispose();

                    //string State = "Y".ToString();
                    sm.insertEmailLog(nicno, email, cracno, DateTime.Now, "Y", fc.GetSystemDate("A"));
                    lblMsg.Text = "Email successfully sent.";
                    //UpdateEmailState = EMail.UpdateEachEmailState(Date, FDNo, BranchCode, State);
                }
                catch (Exception)
                {
                    lblMsg.Text = "Sending mail is failed.";
                    sm.insertEmailLog(nicno, email, cracno, DateTime.Now, "N", fc.GetSystemDate("A"));
                }
            }
            else
            {
                //string State = "Error".ToString();
                sm.insertEmailLog(nicno, email, cracno, DateTime.Now, "N", fc.GetSystemDate("A"));
            }
        }
        catch
        {
            lblMsg.Text = "Sending mail is failed.";
            sm.insertEmailLog(nicno, email, cracno, DateTime.Now, "N", fc.GetSystemDate("A"));
        }
    }
}
