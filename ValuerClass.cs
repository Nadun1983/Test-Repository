using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

/// <summary>
/// Summary description for ValuerClass
/// </summary>
public class ValuerClass
{   

	public ValuerClass()
	{
        //
		// TODO: Add constructor logic here
		//
	}

    SqlConnection myconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["housdbString"].ConnectionString);
    private SqlDataAdapter sqlAdapter;    
    private SqlCommand sqlCmd;
    private DataTable dt;

    public DataTable GetDistictList()
    {
        string sqlselect;
        sqlselect = "select  Distcode, DistName from District ";
        sqlAdapter = new SqlDataAdapter(sqlselect, myconnection);

        dt = new DataTable();

        try
        {
            myconnection.Open();
            sqlAdapter.Fill(dt);
        }

        catch (Exception err)
        {
            
        }

        finally
        {
            myconnection.Close();
        }

        return dt;
    } 

   
    //check exsisting appno
    public bool checkexisappno(string APPNO)
    {
        string sqlSelect;

        sqlSelect = @"select APPNO from valuation where APPNO=@APPNO and status='A' and updatelevel=-100";


        // sqlConn = new SqlConnection(conStringServer);
        sqlAdapter = new SqlDataAdapter(sqlSelect, myconnection);

        sqlAdapter.SelectCommand.Parameters.AddWithValue("APPNO", APPNO);

        dt = new DataTable();

        try
        {
            myconnection.Open();
            sqlAdapter.Fill(dt);
        }
        catch (Exception err)
        {
            //
        }

        finally
        {
            myconnection.Close();
        }

        int length = dt.Rows.Count;
        if (length > 0)
        {
            return true;
        }

        else
        {
            return false;
        }
    }

    //insert valuation send details
    public int InsertValersDetails(string APPNO, int VALUERID, DateTime SENDDATE, string HIDE, string STATUS,
                                    string AddUser, DateTime Adddatetime, int UpdateLevel, string IsTrPortPd, string IsValuerPd,
                                    string IsCommisPaid, string IsGovtPaid, string IsExpTrPaid, string IsExpValuerPd,
                                    decimal ValuerFee, decimal TrportFee, decimal CommisFee, int type)
    {
        string _errmessage;
        string sqlInsert;

        //Assing to the others 0
        decimal TranFee = 0;
        decimal ValFee = 0;

        if (type == 1)
        {

            sqlInsert = @"INSERT INTO VALUATION 
                     (APPNO,VALUERID,SENDDATE,HIDE,STATUS,AddUser,Adddatetime,UpdateLevel,IsTrPortPd,IsValuerPd,IsCommisPaid,IsGovtPaid,IsExpTrPaid,IsExpValuerPd,ValuerFee,TrportFee,ExpValuerFee,ExpressTrPort,CommisFee) 
                      VALUES (@APPNO,@VALUERID,@SENDDATE,@HIDE,@STATUS,@AddUser,@Adddatetime,@UpdateLevel,@IsTrPortPd,@IsValuerPd,@IsCommisPaid,@IsGovtPaid,@IsExpTrPaid,@IsExpValuerPd,@ValuerFee,@TrportFee,@TranFee,@ValFee,@CommisFee)";
        }
        else
        {
            sqlInsert = @"INSERT INTO VALUATION 
                     (APPNO,VALUERID,SENDDATE,HIDE,STATUS,AddUser,Adddatetime,UpdateLevel,IsTrPortPd,IsValuerPd,IsCommisPaid,IsGovtPaid,IsExpTrPaid,IsExpValuerPd,ExpValuerFee,ExpressTrPort,ValuerFee,TrportFee,CommisFee) 
                      VALUES (@APPNO,@VALUERID,@SENDDATE,@HIDE,@STATUS,@AddUser,@Adddatetime,@UpdateLevel,@IsTrPortPd,@IsValuerPd,@IsCommisPaid,@IsGovtPaid,@IsExpTrPaid,@IsExpValuerPd,@ValuerFee,@TrportFee,@TranFee,@ValFee,@CommisFee)";
        }
        //sqlConn = new SqlConnection(myconnection);
        sqlCmd = new SqlCommand(sqlInsert, myconnection);

        //

        sqlCmd.Parameters.AddWithValue("APPNO", APPNO);
        sqlCmd.Parameters.AddWithValue("VALUERID", VALUERID);
        sqlCmd.Parameters.AddWithValue("SENDDATE", SENDDATE);
        sqlCmd.Parameters.AddWithValue("HIDE", HIDE);
        sqlCmd.Parameters.AddWithValue("STATUS", STATUS);
        sqlCmd.Parameters.AddWithValue("AddUser", AddUser);
        sqlCmd.Parameters.AddWithValue("Adddatetime", Adddatetime);
        sqlCmd.Parameters.AddWithValue("UpdateLevel", UpdateLevel);
        sqlCmd.Parameters.AddWithValue("IsTrPortPd", IsTrPortPd);
        sqlCmd.Parameters.AddWithValue("IsValuerPd", IsValuerPd);
        sqlCmd.Parameters.AddWithValue("IsCommisPaid", IsCommisPaid);
        sqlCmd.Parameters.AddWithValue("IsGovtPaid", IsGovtPaid);
        sqlCmd.Parameters.AddWithValue("IsExpTrPaid", IsExpTrPaid);
        sqlCmd.Parameters.AddWithValue("IsExpValuerPd", IsExpValuerPd);
        sqlCmd.Parameters.AddWithValue("ValuerFee", ValuerFee);
        sqlCmd.Parameters.AddWithValue("TrportFee", TrportFee);
        sqlCmd.Parameters.AddWithValue("CommisFee", CommisFee);
        sqlCmd.Parameters.AddWithValue("type", type);

        sqlCmd.Parameters.AddWithValue("TranFee", TranFee);
        sqlCmd.Parameters.AddWithValue("ValFee", ValFee);
               
        int rowAdded = 0;

        try
        {
            myconnection.Open();
            rowAdded = sqlCmd.ExecuteNonQuery();
        }

        catch (Exception err)
        {
            _errmessage = err.Message;
        }

        finally
        {
            myconnection.Close();
        }

        return rowAdded;

    }

    //select the appropriate valuers names when user select the distric
    public DataTable GetValuer(int distcode)
    {
        string sqlSelect;

        sqlSelect = @"SELECT v.ValuerId AS valuerid, RTRIM(v.Initial) + RTRIM(v.SurName) AS ValuerName
                    FROM ValuerArea AS a INNER JOIN
                    Valuer AS v ON a.ValuerId = v.ValuerId
                    WHERE (a.DistCode = @distcode)";


       // sqlConn = new SqlConnection(conStringServer);
        sqlAdapter = new SqlDataAdapter(sqlSelect, myconnection);

        sqlAdapter.SelectCommand.Parameters.AddWithValue("distcode", distcode);
        

        dt = new DataTable();

        try
        {
            myconnection.Open();
            sqlAdapter.Fill(dt);
        }
        catch (Exception err)
        {
            //
        }

        finally
        {
            myconnection.Close();
        }

        return dt;
        
    }

  
    public DataTable allValuersdetails(DateTime frmdate , DateTime todate)
    {
        string sqlSelect;

        sqlSelect = @"select vt.APPNO , (rtrim(v.SurName) + ' ' + rtrim(v.Initial)) as Fullname , (vt.ValuerFee + vt.ExpValuerFee) as ValuerFee , 
                      (vt.TrportFee + vt.ExpValuerFee) as Valuer_Tranport_Fee ,((vt.ValuerFee + vt.ExpValuerFee +  vt.TrportFee + vt.ExpValuerFee))
                       as Total_Payment 
                       from VALUATION vt , Valuer v
                       where vt.VALUERID = v.ValuerId and vt.SENDDATE > @frmdate and vt.SENDDATE < @todate and vt.updatelevel=-100
                       order by vt.APPNO";


        // sqlConn = new SqlConnection(conStringServer);
        sqlAdapter = new SqlDataAdapter(sqlSelect, myconnection);

        sqlAdapter.SelectCommand.Parameters.AddWithValue("frmdate", frmdate);
        sqlAdapter.SelectCommand.Parameters.AddWithValue("todate", todate);
        
        dt = new DataTable();

        try
        {
            myconnection.Open();
            sqlAdapter.Fill(dt);
        }
        catch (Exception err)
        {
            //
        }

        finally
        {
            myconnection.Close();
        }

        return dt;
    }

    public DataTable GetAllValuersName()
    {
        string sqlSelect;

        sqlSelect = @"select (rtrim(SurName) + ' ' + rtrim(Initial)) as FullName , ValuerId from Valuer";


        sqlAdapter = new SqlDataAdapter(sqlSelect, myconnection);

        //sqlAdapter.SelectCommand.Parameters.AddWithValue("frmdate", frmdate);

        dt = new DataTable();

        try
        {
            myconnection.Open();
            sqlAdapter.Fill(dt);
        }
        catch (Exception err)
        {
            //
        }

        finally
        {
            myconnection.Close();
        }

        return dt;
    }

    public DataTable GetValuersDepartments()
    {
        string sqlSelect;

        sqlSelect = @"select AName , AuthorityId from ValuationAuthorities";

        sqlAdapter = new SqlDataAdapter(sqlSelect, myconnection);
        //sqlAdapter.SelectCommand.Parameters.AddWithValue("frmdate", frmdate);

        dt = new DataTable();

        try
        {
            myconnection.Open();
            sqlAdapter.Fill(dt);
        }
        catch (Exception err)
        {
            //
        }
        finally
        {
            myconnection.Close();
        }
        return dt;
    }
    public DataTable CheckPayedForValuation(long APPNO)
    {
        string SQlSelect;
        SQlSelect = @"select PaymentTypeId, Amount from paymentmade where appno=@APPNO and 
                     (PaymentTypeId=1 or PaymentTypeId=7 or PaymentTypeId=12 or PaymentTypeId=13)";

        sqlAdapter = new SqlDataAdapter(SQlSelect, myconnection);
        sqlAdapter.SelectCommand.Parameters.AddWithValue("APPNO", APPNO);

        dt = new DataTable();
        try
        {
            myconnection.Open();
            sqlAdapter.Fill(dt);
        }
        catch (Exception er)
        {
            //
        }
        finally
        {
            myconnection.Close();
        }
        return dt;
    }

    public DataTable GetUnhideVauer(string appno, string hide)
    {
        string SQlSelect;
        SQlSelect = @"select (rtrim(val.surname) + ' ' + rtrim(val.Initial)) as fullname , v.senddate , v.appno 
                        from valuation v , valuer val 
                        where v.valuerid = val.valuerid and v.appno=@appno and v.hide=@hide";

        sqlAdapter = new SqlDataAdapter(SQlSelect, myconnection);
        sqlAdapter.SelectCommand.Parameters.AddWithValue("appno", appno);
        sqlAdapter.SelectCommand.Parameters.AddWithValue("hide", hide);

        dt = new DataTable();
        try
        {
            myconnection.Open();
            sqlAdapter.Fill(dt);
        }
        catch (Exception er)
        {
            //
        }
        finally
        {
            myconnection.Close();
        }
        return dt;
    }

    public int SetTrueApprovalstatus(string appno)
    {
        string sqlErr;
        string sqlUpdate;

        sqlUpdate = @"update approvalstatus set IsValuationOK=1 where appno=@Appno";

        sqlCmd = new SqlCommand(sqlUpdate, myconnection);

        sqlCmd.Parameters.AddWithValue("appno", appno);

        int rowadd = 0;

        try
        {
            myconnection.Open();
            rowadd = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception err)
        {
            sqlErr = err.Message;
        }
        finally
        {
            myconnection.Close();
        }

        return rowadd;
    }

    public int SetFalseApprovalstatus(string appno)
    {
        string sqlErr;
        string sqlUpdate;

        sqlUpdate = @"update approvalstatus set IsValuationOK=0 where appno=@Appno";

        sqlCmd = new SqlCommand(sqlUpdate, myconnection);

        sqlCmd.Parameters.AddWithValue("appno", appno);

        int rowadd = 0;

        try
        {
            myconnection.Open();
            rowadd = sqlCmd.ExecuteNonQuery();
        }
        catch (Exception err)
        {
            sqlErr = err.Message;
        }
        finally
        {
            myconnection.Close();
        }

        return rowadd;
    }
}
