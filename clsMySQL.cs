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
using MySql.Data.MySqlClient;

/// <summary>
/// clsMySQL 的摘要描述
/// </summary>
public class clsMySQL
{
    private MySqlConnection objConn;
    private MySqlCommand objCmd;
    private MySqlTransaction Trans;
    private String strConnString;  
    
    public clsMySQL()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
        strConnString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString; 
            //System.c Configuration.ConfigurationSettings.AppSettings["MySQL"];
	}

    public MySqlDataReader QueryDataReader(String strSQL)
    {
        MySqlDataReader dtReader;
        objConn = new MySqlConnection();
        objConn.ConnectionString = strConnString;
        objConn.Open();

        objCmd = new MySqlCommand(strSQL, objConn);
        dtReader = objCmd.ExecuteReader();
        objConn.Close();
        return dtReader; //*** Return DataReader ***//  
     
    }

    public DataSet QueryDataSet(String strSQL)    {
       
        DataSet ds = new DataSet();
        
        MySqlDataAdapter dtAdapter = new MySqlDataAdapter();
        objConn = new MySqlConnection();
        objConn.ConnectionString = strConnString;
        objConn.Open();

        objCmd = new MySqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandText = strSQL;
        objCmd.CommandType = CommandType.Text;
        dtAdapter.SelectCommand = objCmd;
        dtAdapter.Fill(ds);
        objConn.Close();                
        return ds;   //*** Return DataSet ***//              
    }
    
    public DataTable QueryDataTable(String strSQL)
    {
        MySqlDataAdapter dtAdapter;
        DataTable dt = new DataTable();
        objConn = new MySqlConnection();
        objConn.ConnectionString = strConnString;
        objConn.Open();

        dtAdapter = new MySqlDataAdapter(strSQL, objConn);
        dtAdapter.Fill(dt);
        objConn.Close();
        return dt; //*** Return DataTable ***//        
    }

    public Boolean QueryExecuteNonQuery(String strSQL)
    {
        objConn = new MySqlConnection();
        objConn.ConnectionString = strConnString;
        objConn.Open();

        try
        {
            objCmd = new MySqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = strSQL;
            objCmd.ExecuteNonQuery();
            objConn.Close();
            return true; //*** Return True ***//
        }
        catch (Exception)
        {
            objConn.Close();
            return false; //*** Return False ***//
        }
    }
    public Object QueryExecuteScalar(String strSQL)
    {
        Object obj;
        objConn = new MySqlConnection();
        objConn.ConnectionString = strConnString;
        objConn.Open();

        try
        {
            objCmd = new MySqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = strSQL;

            obj = objCmd.ExecuteScalar();  //*** Return Scalar ***//
            objConn.Close();
            return obj;
        }
        catch (Exception)
        {
            objConn.Close();
            return null; //*** Return Nothing ***//
        }
    }

    public void TransStart()
    {
        objConn = new MySqlConnection();
        objConn.ConnectionString = strConnString;
        objConn.Open();
        Trans = objConn.BeginTransaction(IsolationLevel.ReadCommitted);
    }


    public void TransExecute(String strSQL)
    {
        objCmd = new MySqlCommand();
        objCmd.Connection = objConn;
        objCmd.Transaction = Trans;
        objCmd.CommandType = CommandType.Text;
        objCmd.CommandText = strSQL;
        objCmd.ExecuteNonQuery();
    }


    public void TransRollBack()
    {
        Trans.Rollback();
    }

    public void TransCommit()
    {
        Trans.Commit();
    }

    public void Close()
    {
        objConn.Close();
        objConn = null;
    }


    public Boolean myBatchNonQuery(ArrayList arSQL)
    {    
        objConn = new MySqlConnection();
        objConn.ConnectionString = strConnString;
        objConn.Open();
        try
        {
            foreach (string strSQL in arSQL)
            {
                objCmd = new MySqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = strSQL;
                objCmd.ExecuteNonQuery();
            }
            //Trans.Commit();
            objConn.Close();
            return true; //*** Return True ***//
        }
        catch (Exception)
        {
            //Trans.Rollback();
            objConn.Close();
            return false; //*** Return False ***//
        }
    }


    //By TW Shao**********************************
    //  1.dbConn -> 2.執行需要的功能 > 3.dbClose
    public void dbConn()
    {
        objConn = new MySqlConnection();
        objConn.ConnectionString = strConnString;
        objConn.Open();        
    }

    public MySqlDataReader dbQueryDR(String strSQL)
    {
        MySqlDataReader dtReader;
        objCmd = new MySqlCommand(strSQL, objConn);
        dtReader = objCmd.ExecuteReader();        
        return dtReader; //*** Return DataReader ***//  
    }

    public DataSet dbQueryDS(String strSQL)
    {

        DataSet ds = new DataSet();
        MySqlDataAdapter dtAdapter = new MySqlDataAdapter();        

        objCmd = new MySqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandText = strSQL;
        objCmd.CommandType = CommandType.Text;
        dtAdapter.SelectCommand = objCmd;
        dtAdapter.Fill(ds);        
        return ds;   //*** Return DataSet ***//              
    }

    public DataTable dbQueryDT(String strSQL)
    {
        MySqlDataAdapter dtAdapter;
        DataTable dt = new DataTable();        

        dtAdapter = new MySqlDataAdapter(strSQL, objConn);
        dtAdapter.Fill(dt);
        objConn.Close();
        return dt; //*** Return DataTable ***//        
    }

    public Boolean dbQueryExecuteNonQuery(String strSQL)
    {
        try
        {
            objCmd = new MySqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = strSQL;
            objCmd.ExecuteNonQuery();     
            return true; //*** Return True ***//
        }
        catch (Exception)
        {            
            return false; //*** Return False ***//
        }
    }
    public Object dbQueryExecuteScalar(String strSQL)
    {
        Object obj;

        try
        {
            objCmd = new MySqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = strSQL;

            obj = objCmd.ExecuteScalar();  //*** Return Scalar ***//        
            return obj;
        }
        catch (Exception)
        {            
            return null; //*** Return Nothing ***//
        }
    }

    public void dbClose()
    {
        objConn.Close();
        objConn = null;
    }


    public Boolean dbBatchNonQuery(ArrayList arSQL)  //多個Insert/Delete/Update SQL指令要執行
    {        
        try
        {
            foreach (string strSQL in arSQL)
            {
                objCmd = new MySqlCommand();
                objCmd.Connection = objConn;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = strSQL;
                objCmd.ExecuteNonQuery();
            }     
            
            return true; //*** Return True ***//
        }
        catch (Exception)
        {            
            return false; //*** Return False ***//
        }
    }


    //*************************************



    //***********************************
    public struct DBReply
    {
        public Exception ex;
        public DataSet dsDataSet;
        public DataTable dtDataTable;
        public int iUpdate_Count;
    }

    public DBReply Query(string strSQL)    //Query DataTable
    {
        DBReply dr = new DBReply();
        try
        {                            
            MySqlDataAdapter dtAdapter;            
            objConn = new MySqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();

            dtAdapter = new MySqlDataAdapter(strSQL, objConn);
            dr.dtDataTable = new DataTable();
            dtAdapter.Fill(dr.dtDataTable);         
        }
        catch (Exception ex)
        {
            dr.ex = ex;
        }
        return dr;
    }

    public DBReply QueryDS(String strSQL)  //Query DataSet
    {        
        DBReply dr = new DBReply();
        try
        {
            MySqlDataAdapter dtAdapter = new MySqlDataAdapter();
            objConn = new MySqlConnection();
            objConn.ConnectionString = strConnString;
            objConn.Open();

            objCmd = new MySqlCommand();
            objCmd.Connection = objConn;
            objCmd.CommandText = strSQL;
            objCmd.CommandType = CommandType.Text;
            dtAdapter.SelectCommand = objCmd;
            dr.dsDataSet = new DataSet();
            dtAdapter.Fill(dr.dsDataSet);            
        }
        catch (Exception ex)
        {
            dr.ex = ex;
        }
        return dr;
    }

    public DBReply BatchNonQuery(ArrayList arSQL)
    {
        DBReply dr = new DBReply();
        //SqlTransaction transaction = conn.BeginTransaction("BeginTransaction");        
        try
        {     
            foreach (string strSQL in arSQL)
            {

                objCmd = new MySqlCommand();
                objCmd.Connection = objConn;
                objCmd.Transaction = Trans;
                objCmd.CommandType = CommandType.Text;
                objCmd.CommandText = strSQL;
                dr.iUpdate_Count =objCmd.ExecuteNonQuery();
                
            }
            Trans.Commit();
        }
        catch (Exception ex)
        {
            Trans.Rollback();
            dr.ex = ex;
        }
        return dr;
    }

    //***********************************

}