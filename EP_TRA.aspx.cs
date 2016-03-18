using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using MySql.Data.MySqlClient;



public partial class Default : System.Web.UI.Page
{

    MySql.Data.MySqlClient.MySqlConnection conn;
    public List<string> temp_Data = new List<string>();
    public List<string> por_golden_condition = new List<string>();
    public List<string> por_golden_data = new List<string>();
    public List<string> npimanual_data = new List<string>();
    public List<string> npiapp_data = new List<string>();
    public List<string> npiimport_data = new List<string>();
    public List<string> Str_Effect = new List<string>();

    public string Conninf = "server=10.14.41.200;uid=new;" + "pwd=new; database=dbbu3;";

    

    protected void DBInit()
    {
        string strSQL = string.Format("SELECT * FROM npiimportdata");
        try
        {
            clsMySQL db = new clsMySQL(); //Connection MySQL
            clsMySQL.DBReply dr = db.QueryDS(strSQL);
            db.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = "Exception Error Message----  " + ex.ToString() + ">>>>>>>>>>" + strSQL;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!Page.IsPostBack)
        {
            //DBInit();
            Panel1.Visible = false;
            
        }
        


    }

    protected void put_effect_data()
    {
        Str_Effect.Add("Assembly");
        Str_Effect.Add("Reliability");
        Str_Effect.Add("CP");
        Str_Effect.Add("UBM");
        Str_Effect.Add("PHOTO");
        Str_Effect.Add("PLAT");
        Str_Effect.Add("PI1");
        Str_Effect.Add("ETCH");
        Str_Effect.Add("DESCUM");
        Str_Effect.Add("2RFL");
        Str_Effect.Add("PPHO");
        Str_Effect.Add("PR STRIP");
        Str_Effect.Add("FT");
        Str_Effect.Add("FV & 2D");
        Str_Effect.Add("2D");
        Str_Effect.Add("FV");
        Str_Effect.Add("3D");
        Str_Effect.Add("BH/Cop");
        Str_Effect.Add("RS");
        Str_Effect.Add("Void");
        Str_Effect.Add("Shear test");
        Str_Effect.Add("Pull test");
      
    }







    protected bool check_Customer_data(string mySQL, string ConnStr)
    {
        string TableFild = "";
        int FieldCunt = 0;
        bool sign = false;
        int i;
        List<string> Customerdata = new List<string>();

        MySqlConnection MySqlConn = new MySqlConnection(ConnStr);
        MySqlConn.Open();


        

        MySqlCommand MySqlCmd = new MySqlCommand(mySQL, MySqlConn);
        MySqlDataReader SelData = MySqlCmd.ExecuteReader();
        
        while (SelData.Read())
        {
           

            TableFild = (String)SelData["New_Customer"];
            Customerdata.Add(TableFild);
            FieldCunt++;

        }

        SelData.Close();
        MySqlConn.Close();
       

        for (i = 0; i < FieldCunt; i++) {
            if (Customer_TB.Text == Customerdata[i])
            {
                sign = true;
                break;
            }
            else
                sign = false;
            }
        if (sign)
            return true;
        else
            return false;
        
    }

    protected bool check_NewDevice_data(string mySQL, string ConnStr)
    {
        string TableFild = "";
        int FieldCunt = 0;
        bool sign = false;
        int i;
        List<string> NewDevicedata = new List<string>();

        MySqlConnection MySqlConn = new MySqlConnection(ConnStr);
        MySqlConn.Open();

        MySqlCommand MySqlCmd = new MySqlCommand(mySQL, MySqlConn);
        MySqlDataReader SelData = MySqlCmd.ExecuteReader();

        while (SelData.Read())
        {


            TableFild = (String)SelData["New_Device"];
            NewDevicedata.Add(TableFild);
            FieldCunt++;

        }

        SelData.Close();
        MySqlConn.Close();
       

        for (i = 0; i < FieldCunt; i++)
        {
            if (ND_TB.Text == NewDevicedata[i])
            {
                sign = true;
                break;
            }
            else
                sign = false;
        }
        if (sign)
            return true;
        else
            return false;

    }

    protected void POR_Goledn_pickup_data(string mySQL)
    {
        int i,j;
        
         string TableFild = "";
         int FieldCunt = 0;
         

        MySqlConnection MySqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString);
        MySqlConn.Open();

         MySqlCommand MySqlCmd = new MySqlCommand(mySQL, MySqlConn);
         MySqlDataReader mydr = MySqlCmd.ExecuteReader();

      


        while (mydr.Read())
        {

            /*for (i = 0; i < 6; i++) {
                for (j = 0; j < 10; j++) {
                    if ((i == 5 && j == 6) || (i == 5 && j == 7) || (i == 5 && j == 8) || (i == 5 && j == 9))
                        break;
                        if (j == 0 && i==0)
                        continue;
                            TableFild = (String)mydr["POR_"+ Convert.ToString(i) + Convert.ToString(j)];
                            if(TableFild == null) {
                        por_golden_data.Add(".");
                            }
                    por_golden_data.Add(TableFild);
                   
                }
            }
            */




           
 
            por_golden_data.Add((String)mydr["POR_15"]);
            por_golden_data.Add((String)mydr["POR_14"]);
            por_golden_data.Add((String)mydr["POR_17"]);
            por_golden_data.Add((String)mydr["POR_18"]);
            por_golden_data.Add((String)mydr["POR_46"]);
            por_golden_data.Add((String)mydr["POR_24"]);
            por_golden_data.Add((String)mydr["POR_04"]);
            por_golden_data.Add((String)mydr["POR_03"]);
            por_golden_data.Add((String)mydr["POR_12"]);
            por_golden_data.Add((String)mydr["POR_20"]); 
            por_golden_data.Add((String)mydr["POR_23"]);
            por_golden_data.Add((String)mydr["POR_21"]);
            por_golden_data.Add((String)mydr["POR_25"]);
            por_golden_data.Add((String)mydr["POR_02"]);
            por_golden_data.Add((String)mydr["POR_26"]);
            por_golden_data.Add((String)mydr["POR_55"]);
            por_golden_data.Add((String)mydr["POR_16"]);
            por_golden_data.Add((String)mydr["POR_33"]);
            por_golden_data.Add((String)mydr["POR_30"]);
            por_golden_data.Add((String)mydr["POR_31"]);
            por_golden_data.Add((String)mydr["POR_32"]);
            por_golden_data.Add((String)mydr["POR_13"]);
            por_golden_data.Add((String)mydr["POR_29"]);
            por_golden_data.Add((String)mydr["POR_27"]);
            por_golden_data.Add((String)mydr["POR_28"]);
            por_golden_data.Add((String)mydr["POR_34"]);
            por_golden_data.Add((String)mydr["POR_50"]); 
            por_golden_data.Add((String)mydr["POR_44"]);
            por_golden_data.Add((String)mydr["POR_43"]);
            por_golden_data.Add((String)mydr["POR_19"]);
            por_golden_data.Add((String)mydr["POR_35"]);
            por_golden_data.Add((String)mydr["POR_45"]);
            por_golden_data.Add((String)mydr["POR_22"]);
            por_golden_data.Add((String)mydr["POR_10"]);
            por_golden_data.Add((String)mydr["POR_48"]);
            por_golden_data.Add((String)mydr["POR_49"]);
            por_golden_data.Add((String)mydr["POR_36"]);
            por_golden_data.Add((String)mydr["POR_38"]);
            por_golden_data.Add((String)mydr["POR_39"]);
            por_golden_data.Add((String)mydr["POR_40"]);
            por_golden_data.Add((String)mydr["POR_41"]);
          


        }
         mydr.Close();
         MySqlConn.Close();
         
      
       




    }
    protected void POR_Goledn_putdata()
    {
        POR_15.Text = por_golden_data[0];
        POR_14.Text = por_golden_data[1];
        POR_17.Text = por_golden_data[2];
        POR_18.Text = por_golden_data[3];
        POR_46.Text = por_golden_data[4];
        POR_24.Text = por_golden_data[5];
        POR_04.Text = por_golden_data[6];
        POR_03.Text = por_golden_data[7];
        POR_12.Text = por_golden_data[8];
        POR_20.Text = por_golden_data[9];
        POR_23.Text = por_golden_data[10];
        POR_21.Text = por_golden_data[11];
        POR_25.Text = por_golden_data[12];
        POR_02.Text = por_golden_data[13];
        POR_26.Text = por_golden_data[14];
        POR_55.Text = por_golden_data[15];
        POR_16.Text = por_golden_data[16];
        POR_33.Text = por_golden_data[17];
        POR_30.Text = por_golden_data[18];
        POR_31.Text = por_golden_data[19];
        POR_32.Text = por_golden_data[20];
        POR_13.Text = por_golden_data[21];
        POR_29.Text = por_golden_data[22];
        POR_27.Text = por_golden_data[23];
        POR_28.Text = por_golden_data[24];
        POR_34.Text = por_golden_data[25];
        POR_50.Text = por_golden_data[26];
        POR_44.Text = por_golden_data[27];
        POR_43.Text = por_golden_data[28];
        POR_19.Text = por_golden_data[29];
        POR_35.Text = por_golden_data[30];
        POR_45.Text = por_golden_data[31];
        POR_22.Text = por_golden_data[32];
        POR_10.Text = por_golden_data[33];
        POR_48.Text = por_golden_data[34];
        POR_49.Text = por_golden_data[35];
        POR_36.Text = por_golden_data[36];
        POR_38.Text = por_golden_data[37];
        POR_39.Text = por_golden_data[38];
        POR_40.Text = por_golden_data[39];
        POR_41.Text = por_golden_data[40];

    }


    protected string receive_npiimportdata(string mySQL, int i)
    {
        string TableFild = "";
        int FieldCunt = 0;


        // clsMySQL db = new clsMySQL();

        //MySqlDataReader mydr = db.QueryDataReader(mySQL);
        MySqlConnection MySqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString);
        MySqlConn.Open();

        MySqlCommand MySqlCmd = new MySqlCommand(mySQL, MySqlConn);
        MySqlDataReader mydr = MySqlCmd.ExecuteReader();

        while (mydr.Read())
        {
            for (FieldCunt = 0; FieldCunt <= 0; FieldCunt++)
            {

            TableFild = mydr.GetString(0);
            temp_Data.Add(TableFild);

            }

        }
        mydr.Close();
        MySqlConn.Close();
        return temp_Data[i];
    }

    protected void put_npiimport_data()
    {
        // string strSQL1 = " select * From npiapp where npiapp.New_Customer like '" + customer_sign +'%'+ "' and npiapp.New_Device LIKE '" + New_Device_sign + "%'";
        string sql1 = "select Im_Value from npiimportdata where SType='DIF' AND Im_Pos='D4' and New_Customer like '"+ Customer_TB.Text+'%'+"'and New_Device like '"+ ND_TB.Text +"%'";    
        string sql2 = "select Im_Value from npiimportdata where SType='DIF' AND Im_Pos='D5'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql3 = "select Im_Value from npiimportdata where SType='DIF' AND Im_Pos='D19'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql4 = "select Im_Value from npiimportdata where SType='DIF' AND Im_Pos='G19' and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql5 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='D16'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql6 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='D13'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql7 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='D7'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql8 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='D8'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql9 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='D9'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql10 = "select Im_Value from npiimportdata where SType='DIF' AND Im_Pos='F11'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql11 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='D11'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql12 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='D12'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql13 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='D26'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql14 = "select Im_Value from npiimportdata where SType='DRC' AND Im_Pos='F38'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql15 = "select Im_Value from npiimportdata where SType='DRC' AND Im_Pos='F39'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql16 = "select Im_Value from npiimportdata where SType='DRC' AND Im_Pos='F35'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql17 = "select Im_Value from npiimportdata where SType='DRC' AND Im_Pos='F34'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql18 = "select Im_Value from npiimportdata where SType='DIF' AND Im_Pos='D29'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql19 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='E26'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql20 = "select Im_Value from npiimportdata where SType='Q_R' AND Im_Pos='D30'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";
        string sql21 = "select Im_Value from npiimportdata where SType='DIF' AND Im_Pos='D30'and New_Customer like '" + Customer_TB.Text + '%' + "'and New_Device like '" + ND_TB.Text + "%'";

        npiimport_data.Add(receive_npiimportdata(sql1, 0));
        npiimport_data.Add(receive_npiimportdata(sql2, 1));
        npiimport_data.Add(receive_npiimportdata(sql3, 2));

        npiimport_data.Add(receive_npiimportdata(sql4, 3));
        npiimport_data.Add(receive_npiimportdata(sql5, 4));
        npiimport_data.Add(receive_npiimportdata(sql6, 5));    
        npiimport_data.Add(receive_npiimportdata(sql7, 6));
        npiimport_data.Add(receive_npiimportdata(sql8, 7));
        npiimport_data.Add(receive_npiimportdata(sql9, 8));
        npiimport_data.Add(receive_npiimportdata(sql10, 9));
        npiimport_data.Add(receive_npiimportdata(sql11, 10));
        npiimport_data.Add(receive_npiimportdata(sql12, 11));
        npiimport_data.Add(receive_npiimportdata(sql13, 12));
        npiimport_data.Add(receive_npiimportdata(sql14, 13));
        npiimport_data.Add(receive_npiimportdata(sql15, 14));
        npiimport_data.Add(receive_npiimportdata(sql16, 15));
        npiimport_data.Add(receive_npiimportdata(sql17, 16));
        npiimport_data.Add(receive_npiimportdata(sql18, 17));
        npiimport_data.Add(receive_npiimportdata(sql19, 18));
        npiimport_data.Add(receive_npiimportdata(sql20, 19));
        npiimport_data.Add(receive_npiimportdata(sql21, 20));

        DIFD4.Text = npiimport_data[0];
        DIFD5.Text = npiimport_data[1];
        DIFD19.Text = npiimport_data[2];
        DIFG19.Text = npiimport_data[3];
        Q_RD16.Text = npiimport_data[4];
        Q_RD13.Text = npiimport_data[5];

        Q_RD7.Text = npiimport_data[6];
        Q_RD8.Text = npiimport_data[7];
        Q_RD9.Text = npiimport_data[8];
        
        DIFF11.Text = npiimport_data[9];
        Q_RD11.Text = npiimport_data[10];

        Q_RD12.Text = npiimport_data[11];
        Q_RD26.Text = npiimport_data[12];
        DRCF38.Text = npiimport_data[13];
        DRCF39.Text = npiimport_data[14];
        DRCF35.Text = npiimport_data[15];
        DRCF34.Text = npiimport_data[16];
        DIFD29.Text = npiimport_data[17];
        Q_RE26.Text = npiimport_data[18];
        Q_RD30.Text = npiimport_data[19];
        DIFD30.Text = npiimport_data[20];
    



    }

    protected void receive_npimanual_data()
    {
        clsMySQL db = new clsMySQL();
        string customer_sign = Customer_TB.Text;
        string New_Device_sign = ND_TB.Text;

        //string strSQL1 = " select * From npiapp,npimanual where npiapp.New_Customer = '" + customer_sign + "' and npiapp.New_Device = '" + New_Device_sign + "'and npimanual.New_Customer = '" + customer_sign + "' and npimanual.New_Device = '" + New_Device_sign + "'";
        string strSQL1 = "select * From npimanual where  npimanual.New_Customer like '" + customer_sign+'%' + "' and npimanual.New_Device Like'" + New_Device_sign +"%'";
        MySqlConnection MySqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString);
        MySqlConn.Open();

        MySqlCommand MySqlCmd = new MySqlCommand(strSQL1, MySqlConn);
        MySqlDataReader mydr = MySqlCmd.ExecuteReader();




        while (mydr.Read())
        {
            npimanual_data.Add((String)mydr["Man_01"]);
            npimanual_data.Add((String)mydr["Man_02"]);
            npimanual_data.Add((String)mydr["Man_03"]);
            npimanual_data.Add((String)mydr["Man_04"]);
            npimanual_data.Add((String)mydr["Man_05"]);
            npimanual_data.Add((String)mydr["Man_06"]);
            npimanual_data.Add((String)mydr["Man_07"]);
            npimanual_data.Add((String)mydr["Man_08"]);
            npimanual_data.Add((String)mydr["Man_09"]);
            npimanual_data.Add((String)mydr["Man_10"]);
            npimanual_data.Add((String)mydr["Man_11"]);
            npimanual_data.Add((String)mydr["Man_12"]);
            npimanual_data.Add((String)mydr["Man_13"]);
            npimanual_data.Add((String)mydr["Man_14"]);
            npimanual_data.Add((String)mydr["Man_15"]);
            npimanual_data.Add((String)mydr["Man_16"]);
            npimanual_data.Add((String)mydr["Man_17"]);
            npimanual_data.Add((String)mydr["Man_18"]);
            npimanual_data.Add((String)mydr["Man_19"]);
            npimanual_data.Add((String)mydr["Man_20"]);
            npimanual_data.Add((String)mydr["Man_21"]);
            npimanual_data.Add((String)mydr["Man_22"]);
        }
        mydr.Close();
        MySqlConn.Close();
        Man_01.Text = npimanual_data[0];
        Man_02.Text = npimanual_data[1];
        Man_03.Text = npimanual_data[2];
        Man_04.Text = npimanual_data[3];
        Man_05.Text = npimanual_data[4];
        Man_06.Text = npimanual_data[5];
        Man_07.Text = npimanual_data[6];
        Man_08.Text = npimanual_data[7];
        Man_09.Text = npimanual_data[8];
        Man_10.Text = npimanual_data[9];
        Man_11.Text = npimanual_data[10];
        Man_12.Text = npimanual_data[11];
        Man_13.Text = npimanual_data[12];
        Man_14.Text = npimanual_data[13];
        Man_15.Text = npimanual_data[14];
        Man_16.Text = npimanual_data[15];
        Man_17.Text = npimanual_data[16];
        Man_18.Text = npimanual_data[17];
        Man_19.Text = npimanual_data[18];
        man_20.Text = npimanual_data[19];
        man_21.Text = npimanual_data[20];
        man_22.Text = npimanual_data[21];       

    }

    protected void receive_npiapp_data()
    {
        clsMySQL db = new clsMySQL();
        string customer_sign = Customer_TB.Text;
        string New_Device_sign = ND_TB.Text;

        string strSQL1 = " select * From npiapp where npiapp.New_Customer like '" + customer_sign +'%'+ "' and npiapp.New_Device LIKE '" + New_Device_sign + "%'";
        //strQuerySQL = strQuerySQL + "and POR_01 like'" + ProductionSite_TextBox.Text + "%' ";
        MySqlConnection MySqlConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString);
        MySqlConn.Open();

        MySqlCommand MySqlCmd = new MySqlCommand(strSQL1, MySqlConn);
        MySqlDataReader mydr = MySqlCmd.ExecuteReader();




        while (mydr.Read())
        {
            npiapp_data.Add((String)mydr["APP_08"]);
            npiapp_data.Add((String)mydr["APP_21"]);
            npiapp_data.Add((String)mydr["APP_33"]);
            npiapp_data.Add((String)mydr["APP_09"]);
            npiapp_data.Add((String)mydr["APP_11"]);
            npiapp_data.Add((String)mydr["APP_10"]);
            npiapp_data.Add((String)mydr["APP_12"]);
        }
        mydr.Close();
        MySqlConn.Close();

        APP_08.Text = npiapp_data[0];
        APP_21.Text = npiapp_data[1];
        APP_33.Text = npiapp_data[2];
        APP_09.Text = npiapp_data[3];
        APP_11.Text = npiapp_data[4];
        APP_10.Text = npiapp_data[5];
        APP_12.Text = npiapp_data[6];
        APP_21_2.Text = npiapp_data[1];
        APP_11_2.Text = npiapp_data[4];
        APP_09_2.Text = npiapp_data[3];
        APP_11_3.Text = npiapp_data[4];
        APP_11_4.Text = npiapp_data[4];

        APP_11_5.Text = npiapp_data[4];
        APP_11_6.Text = npiapp_data[4];
        APP_11_7.Text = npiapp_data[4];
       


    }




    protected void POR_Butt_Click1(object sender, EventArgs e)
    {
        

      
    

    }

  
  
    protected void cmdFilter_Click(object sender, EventArgs e)
    {
      
        Label1.Text = Session["value1"].ToString();
        Label2.Text = Session["value2"].ToString();
        Label3.Text = Session["value3"].ToString();
        Label4.Text = Session["value4"].ToString();
        Label5.Text = Session["value5"].ToString();
        Label6.Text = Session["value6"].ToString();
        Label7.Text = Session["value7"].ToString();
        Label8.Text = Session["value8"].ToString();
       
        Panel1.Visible = true;
        //string porsql = " select '"+temp_por + "' From npipor where POR_17 = '" + Label1.Text + "' and POR_01 = '" + Label2.Text + "'and POR_02 = '" + Label3.Text + "' and POR_03 = '" + Label4.Text + "'and POR_04 = '" + Label5.Text + "'and POR_05 = '" + Label6.Text + "'and POR_11 ='" + Label7.Text + "'and POR_14 ='" + Label8.Text + "'";
        string porsql = " select * From npipor where POR_17 = '" + Label1.Text + "' and POR_01 = '" + Label2.Text + "'and POR_02 = '" + Label3.Text + "' and POR_03 = '" + Label4.Text + "'and POR_04 = '" + Label5.Text + "'and POR_05 = '" + Label6.Text + "'and POR_11 ='" + Label7.Text + "'and POR_14 ='" + Label8.Text + "'";
        POR_Goledn_pickup_data(porsql);
        POR_Goledn_putdata();
        
 


        
       
}
    

    protected void Customer_TB_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Select_POR_Click(object sender, EventArgs e)
    {
        //日期輸入的頁面，將 TextBox 以 TextBoxId 網址參數傳給日期頁面 
        /*  sUrl = "POR_Golden.aspx?Device="+ this.por_golden_data[0] + "Production_Site=" + this.por_golden_data[1] + "PKG=" + this.por_golden_data[2] +
                      "Wafer=" + this.por_golden_data[3] + "Name_fab=" + this.por_golden_data[4] + "WaferPSV=" + this.por_golden_data[5] +
                      "RVSI=" + this.por_golden_data[6] + "Customer=" + this.por_golden_data[7];*/
        // sScript = "window.open('POR_Golden.aspx','','height=1024,width=1100,status=no,toolbar=no,menubar=no,location=no','')";
        // this.Label1.Attributes["onclick"] = sScript;
        
        string strScript = string.Format("<script language='javascript'>AddWork();</script>");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", strScript);
    }

   










    protected void GAP_butt1(object sender, EventArgs e)
    {
        //Convert.ToDouble(DIFD19.Text) / 1000
      
        Double new_device_number = (Convert.ToDouble(DIFD19.Text)/1000) * (Convert.ToDouble(DIFG19.Text) / 1000);

        string temp_number = Convert.ToString(Math.Round(new_device_number, 2));

        




        put_effect_data();
        if (POR_14.Text == DIFD4.Text)
        {
            gap2.Text = "Y";
            gap2.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap2.Text = "N";
            gap2.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_17.Text == DIFD5.Text)
        {
            gap3.Text = "Y";
            gap3.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap3.Text = "N";
            gap3.ForeColor = System.Drawing.Color.Blue;
        }
        

        if (POR_18.Text == temp_number )
        {
            gap4.Text = "Y";
            gap4.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap4.Text = "N";
            gap4.ForeColor = System.Drawing.Color.Blue;
        }
        
        if (POR_46.Text == Q_RD16.Text)
        {
            gap5.Text = "Y";
            gap5.ForeColor = System.Drawing.Color.Green;
            Eff_05.Text = Str_Effect[2];
        }
        else
        {
            gap5.Text = "N";
            gap5.ForeColor = System.Drawing.Color.Blue;
            Eff_05.Text = "--";
        }

        if (POR_24.Text == Q_RD13.Text)
        {
            gap6.Text = "Y";
            gap6.ForeColor = System.Drawing.Color.Green;
            Eff_06.Text = Str_Effect[3] + "<br />" + Str_Effect[4] + "<br />" + Str_Effect[5] + "<br />";
        }
        else
        {

            gap6.Text = "N";
            gap6.ForeColor = System.Drawing.Color.Blue;
            Eff_06.Text = "--";
        }

        if (POR_04.Text == Q_RD7.Text)
        {
            gap7.Text = "Y";
            gap7.ForeColor = System.Drawing.Color.Green;
            Eff_07.Text = Str_Effect[0]+"<br />"+ Str_Effect[1] + "<br />";
        }
        else
        {
            gap7.Text = "N";
            gap7.ForeColor = System.Drawing.Color.Blue;
            Eff_07.Text = "--";
        }

        if (POR_03.Text == Q_RD8.Text)
        {
            gap8.Text = "Y";
            gap8.ForeColor = System.Drawing.Color.Green;
            Eff_08.Text = Str_Effect[0] + "<br />" + Str_Effect[1]+"<br />";
        }
        else
        {
            gap8.Text = "N";
            gap8.ForeColor = System.Drawing.Color.Blue;
            Eff_08.Text = "--";
        }

        if (POR_12.Text == Q_RD9.Text)
        {
            gap9.Text = "Y";
            gap9.ForeColor = System.Drawing.Color.Green;
            Eff_09.Text = Str_Effect[0] + "<br />" + Str_Effect[1] + "<br />";
        }
        else
        {
            gap9.Text = "N";
            gap9.ForeColor = System.Drawing.Color.Blue;
            Eff_09.Text = "--";
        }

        if (POR_20.Text == DIFF11.Text)
        {
            gap10.Text = "Y";
            gap10.ForeColor = System.Drawing.Color.Green;
            Eff_10.Text = Str_Effect[3] + "<br />" + Str_Effect[0] + "<br />";

        }
        else
        {
            gap10.Text = "N";
            gap10.ForeColor = System.Drawing.Color.Blue;
            Eff_10.Text = "--";
        }

        if (POR_23.Text == Q_RD11.Text)
        {
            gap11.Text = "Y";
            gap11.ForeColor = System.Drawing.Color.Green;
            Eff_11.Text = Str_Effect[4] + "<br />" + Str_Effect[5] + "<br />";
        }
        else
        {
            gap11.Text = "N";
            gap11.ForeColor = System.Drawing.Color.Blue;
            Eff_11.Text = "--";
        }

        if (POR_21.Text == Man_01.Text)
        {
            gap12.Text = "Y";
            gap12.ForeColor = System.Drawing.Color.Green;
            Eff_12.Text = Str_Effect[6] + "<br />" + " "  ;
        }
        else
        {
            gap12.Text = "N";
            gap12.ForeColor = System.Drawing.Color.Blue;
            Eff_12.Text = "--";
        }


        if (POR_25.Text == Q_RD12.Text)
        {
            gap13.Text = "Y";
            gap13.ForeColor = System.Drawing.Color.Green;
            Eff_13.Text = Str_Effect[6] + "<br />" + Str_Effect[3];
        }
        else
        {
            gap13.Text = "N";
            gap13.ForeColor = System.Drawing.Color.Blue;
            Eff_13.Text = "--";
        }


        if (POR_02.Text == APP_08.Text)
        {
            gap14.Text = "Y";
            gap14.ForeColor = System.Drawing.Color.Green;
            Eff_14.Text = "--";
        }
        else
        {
            gap14.Text = "N";
            gap14.ForeColor = System.Drawing.Color.Blue;
            Eff_14.Text = "--";
        }



        if (POR_26.Text == Man_02.Text)
        {
            gap15.Text = "Y";
            gap15.ForeColor = System.Drawing.Color.Green;
            Eff_15.Text = Str_Effect[6] +"<br />";
        }
        else
        {
            gap15.Text = "N";
            gap15.ForeColor = System.Drawing.Color.Blue;
            Eff_15.Text = "--";
        }

        if (POR_55.Text == Man_03.Text)
        {
            gap16.Text = "Y";
            gap16.ForeColor = System.Drawing.Color.Green;
            Eff_16.Text = Str_Effect[6] + "<br />";
        }
        else
        {
            gap16.Text = "N";
            gap16.ForeColor = System.Drawing.Color.Blue;
            Eff_16.Text = "--";
        }


        if (POR_16.Text == Man_04.Text)
        {
            gap17.Text = "Y";
            gap17.ForeColor = System.Drawing.Color.Green;
            Eff_17.Text = Str_Effect[7] + "<br />" +Str_Effect[0];
        }
        else
        {
            gap17.Text = "N";
            gap17.ForeColor = System.Drawing.Color.Blue;
            Eff_17.Text = "--";
        }


        if (POR_33.Text == Q_RD26.Text)
        {
            gap18.Text = "Y";
            gap18.ForeColor = System.Drawing.Color.Green;
            Eff_18.Text = Str_Effect[9] + "<br />" + Str_Effect[0];
        }
        else
        {
            gap18.Text = "N";
            gap18.ForeColor = System.Drawing.Color.Blue;
            Eff_18.Text = "--";
        }

        if (POR_30.Text == APP_21.Text)
        {
            gap19.Text = "Y";
            gap19.ForeColor = System.Drawing.Color.Green;
            Eff_19.Text = Str_Effect[6] + "<br />"  ;
        }
        else
        {
            gap19.Text = "N";
            gap19.ForeColor = System.Drawing.Color.Blue;
            Eff_19.Text = "--";
        }

        if ("NA" == DRCF38.Text)
        {
            gap20.Text = "Y";
            gap20.ForeColor = System.Drawing.Color.Green;
            Eff_20.Text = Str_Effect[10] + "<br />" ;
        }
        else
        {
            gap20.Text = "N";
            gap20.ForeColor = System.Drawing.Color.Blue;
            Eff_20.Text = "--";
        }

        if (POR_31.Text == DRCF39.Text)
        {
            gap21.Text = "Y";
            gap21.ForeColor = System.Drawing.Color.Green;
            Eff_21.Text = Str_Effect[6] + "<br />";
        }
        else
        {
            gap21.Text = "N";
            gap21.ForeColor = System.Drawing.Color.Blue;
            Eff_21.Text = "--";
        }

        if (POR_32.Text == DRCF35.Text)
        {
            gap22.Text = "Y";
            gap22.ForeColor = System.Drawing.Color.Green;
            Eff_22.Text = Str_Effect[6] + "<br />";
        }
        else
        {
            gap22.Text = "N";
            gap22.ForeColor = System.Drawing.Color.Blue;
            Eff_22.Text = "--";
        }

        if (POR_13.Text == Man_05.Text)
        {
            gap23.Text = "Y";
            gap23.ForeColor = System.Drawing.Color.Green;
            Eff_23.Text = Str_Effect[10] + "<br />";
        }
        else
        {
            gap23.Text = "N";
            gap23.ForeColor = System.Drawing.Color.Blue;
            Eff_23.Text = "--";
        }

        if (POR_29.Text == APP_33.Text)
        {
            gap24.Text = "Y";
            gap24.ForeColor = System.Drawing.Color.Green;
            Eff_24.Text = Str_Effect[10] + "<br />"+ Str_Effect[5] + "<br />"+ Str_Effect[0] + "<br />";
        }
        else
        {
            gap24.Text = "N";
            gap24.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_27.Text == DRCF34.Text)
        {
            gap25.Text = "Y";
            gap25.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap25.Text = "N";
            gap25.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_28.Text == Man_06.Text)
        {
            gap26.Text = "Y";
            gap26.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap26.Text = "N";
            gap26.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_34.Text == Man_07.Text)
        {
            gap27.Text = "Y";
            gap27.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap27.Text = "N";
            gap27.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_50.Text == Man_08.Text)
        {
            gap28.Text = "Y";
            gap28.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap28.Text = "N";
            gap28.ForeColor = System.Drawing.Color.Blue;
        }


        if (POR_44.Text == Man_09.Text)
        {
            gap29.Text = "Y";
            gap29.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap29.Text = "N";
            gap29.ForeColor = System.Drawing.Color.Blue;
        }


        if (POR_43.Text == Man_10.Text)
        {
            gap30.Text = "Y";
            gap30.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap30.Text = "N";
            gap30.ForeColor = System.Drawing.Color.Blue;
        }


        if (POR_19.Text == DIFD29.Text)
        {
            gap31.Text = "Y";
            gap31.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap31.Text = "N";
            gap31.ForeColor = System.Drawing.Color.Blue;
        }


        if (POR_35.Text == APP_09.Text)
        {
            gap32.Text = "Y";
            gap32.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap32.Text = "N";
            gap32.ForeColor = System.Drawing.Color.Blue;
        }


        if (POR_45.Text == APP_11.Text)
        {
            gap33.Text = "Y";
            gap33.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap33.Text = "N";
            gap33.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_22.Text == Man_11.Text)
        {
            gap34.Text = "Y";
            gap34.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap34.Text = "N";
            gap34.ForeColor = System.Drawing.Color.Blue;
        }


        if ("1" == Man_12.Text)
        {
            gap35.Text = "Y";
            gap35.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap35.Text = "N";
            gap35.ForeColor = System.Drawing.Color.Blue;
        }

        if ("+/-0.5" == Q_RE26.Text)
        {
            gap36.Text = "Y";
            gap36.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap36.Text = "N";
            gap36.ForeColor = System.Drawing.Color.Blue;
        }

        if ("'+/-10%" == APP_10.Text)
        {
            gap37.Text = "Y";
            gap37.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap37.Text = "N";
            gap37.ForeColor = System.Drawing.Color.Blue;
        }



        if ("+/-10%" == APP_12.Text)
        {
            gap38.Text = "Y";
            gap38.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap38.Text = "N";
            gap38.ForeColor = System.Drawing.Color.Blue;
        }

        if ("'<20 um" == Man_13.Text)
        {
            gap39.Text = "Y";
            gap39.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap39.Text = "N";
            gap39.ForeColor = System.Drawing.Color.Blue;
        }

        if ("LF: >2.5 g/mil^2" == Man_14.Text)
        {
            gap40.Text = "Y";
            gap40.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap40.Text = "N";
            gap40.ForeColor = System.Drawing.Color.Blue;
        }

        if ("<10 %" == Man_15.Text)
        {
            gap41.Text = "Y";
            gap41.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap41.Text = "N";
            gap41.ForeColor = System.Drawing.Color.Blue;
        }

        if ("BGM3A:15~30nm" == Man_16.Text)
        {
            gap42.Text = "Y";
            gap42.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap42.Text = "N";
            gap42.ForeColor = System.Drawing.Color.Blue;
        }


        if ( POR_10.Text == Q_RD30.Text)
        {
            gap43.Text = "Y";
            gap43.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap43.Text = "N";
            gap43.ForeColor = System.Drawing.Color.Blue;
        }
        

        if (58 <= Convert.ToInt32(Man_17.Text) && Convert.ToInt32(Man_17.Text) <= 25747)
        {
            gap44.Text = "N";
            gap44.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap44.Text = "Y";
            gap44.ForeColor = System.Drawing.Color.Blue;
        }


        if ("No" == Man_18.Text)
        {
            gap45.Text = "Y";
            gap45.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap45.Text = "N";
            gap45.ForeColor = System.Drawing.Color.Blue;
        }


        if (22 <= Convert.ToInt32(APP_21.Text) && Convert.ToInt32(APP_21.Text) <= 240)
        {
            gap46.Text = "N";
            gap46.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap46.Text = "Y";
            gap46.ForeColor = System.Drawing.Color.Blue;
        }

        if (84 <= Convert.ToInt32(APP_11.Text) && Convert.ToInt32(APP_11.Text) <= 127)
        {
            gap47.Text = "N";
            gap47.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap47.Text = "Y";
            gap47.ForeColor = System.Drawing.Color.Blue;
        }

        if (58 <= Convert.ToInt32(Man_19.Text) && Convert.ToInt32(Man_19.Text) <= 25747)
        {
            gap51.Text = "N";
            gap51.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap51.Text = "Y";
            gap51.ForeColor = System.Drawing.Color.Blue;
        }


        if (172 <= Convert.ToInt32(DIFD30.Text) && Convert.ToInt32(DIFD30.Text) <= 18510)
        {
            gap52.Text = "N";
            gap52.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap52.Text = "Y";
            gap52.ForeColor = System.Drawing.Color.Blue;
        }

        if (65 <= Convert.ToInt32(APP_09.Text) && Convert.ToInt32(APP_09.Text) <= 108)
        {
            gap53.Text = "N";
            gap53.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap53.Text = "Y";
            gap53.ForeColor = System.Drawing.Color.Blue;
        }

        if (84 <= Convert.ToInt32(APP_11_2.Text) && Convert.ToInt32(APP_11_2.Text) <= 138)
        {
            gap54.Text = "N";
            gap54.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap54.Text = "Y";
            gap54.ForeColor = System.Drawing.Color.Blue;
        }


        if (30 <= Convert.ToInt32(APP_11_3.Text) && Convert.ToInt32(APP_11_2.Text) <= 326)
        {
            gap55.Text = "N";
            gap55.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap55.Text = "Y";
            gap55.ForeColor = System.Drawing.Color.Blue;
        }

        if (30 <= Convert.ToInt32(APP_11_4.Text) && Convert.ToInt32(APP_11_4.Text) <= 326)
        {
            gap56.Text = "N";
            gap56.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap56.Text = "Y";
            gap56.ForeColor = System.Drawing.Color.Blue;
        }


        if (23 <= Convert.ToInt32(APP_11_5.Text) && Convert.ToInt32(APP_11_5.Text) <= 326)
        {
            gap57.Text = "N";
            gap57.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap57.Text = "Y";
            gap57.ForeColor = System.Drawing.Color.Blue;
        }
      

        if ((200 <= Convert.ToInt32(APP_11_6.Text) && Convert.ToInt32(APP_11_6.Text) <= 326) ||
            (83 <= Convert.ToInt32(APP_11_6.Text) && Convert.ToInt32(APP_11_6.Text) <= 140))
        {
            gap58.Text = "N";
            gap58.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap58.Text = "Y";
            gap58.ForeColor = System.Drawing.Color.Blue;
        }


        if (POR_48.Text == man_20.Text)
        {
            gap59.Text = "Y";
            gap59.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap59.Text = "N";
            gap59.ForeColor = System.Drawing.Color.Blue;
        }


        if (POR_49.Text == man_21.Text)
        {
            gap60.Text = "Y";
            gap60.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap60.Text = "N";
            gap60.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_36.Text == man_22.Text)
        {
            gap61.Text = "Y";
            gap61.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap61.Text = "N";
            gap61.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_38.Text == "NA")
        {
            gap62.Text = "Y";
            gap62.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap62.Text = "N";
            gap62.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_39.Text == "NA")
        {
            gap63.Text = "Y";
            gap63.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap63.Text = "N";
            gap63.ForeColor = System.Drawing.Color.Blue;
        }


        if (POR_40.Text == "NA")
        {
            gap64.Text = "Y";
            gap64.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap64.Text = "N";
            gap64.ForeColor = System.Drawing.Color.Blue;
        }

        if (POR_41.Text == "NA")
        {
            gap65.Text = "Y";
            gap65.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            gap65.Text = "N";
            gap65.ForeColor = System.Drawing.Color.Blue;
        }




        /*


          }
          else if()
          {


              ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('New_Device條件未選擇，請再重新選擇一次!')", true);
          }
          else if ()
          {
              ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('POR_Golden條件未選擇，請再重新選擇一次!')", true);
          }
          else
          {
              ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('兩條件未選擇，請再重新選擇一次!')", true);
          }
          */

    }





    protected void ND_TB_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Search_Device1(object sender, EventArgs e)
    {
        string SQL_Customer = "SELECT DISTINCT npiimportdata.New_Customer FROM npiimportdata";
        string SQL_NewDevice = "SELECT DISTINCT npiimportdata.New_Device FROM npiimportdata";
        
        /*if (Customer_TB.Text.Trim() != "" && ND_TB.Text.Trim() != "")
        {
            if (check_Customer_data(SQL_Customer, Conninf) && check_NewDevice_data(SQL_NewDevice, Conninf))
            {
                

            }
            else
            {
                if ((!check_NewDevice_data(SQL_NewDevice, Conninf)) && (!check_Customer_data(SQL_Customer, Conninf)))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('DIF/Q&R/DRC/Application/Mamual File中的New_Customer 與 New_Device欄位無此資料，請重新填寫!')", true);
                }
                if (!check_Customer_data(SQL_Customer, Conninf))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('DIF/Q&R/DRC/Application/Mamual File中的New_Customer欄位無此資料，請重新填寫!')", true);
                }
                if (!check_NewDevice_data(SQL_NewDevice, Conninf))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('DIF/Q&R/DRC/Application/Mamual File中的New_Device欄位無此資料，請重新填寫!')", true);
                }

            }

        }
        else {
            if (Customer_TB.Text.Trim() == "" && ND_TB.Text.Trim() == "")
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('New_Customer與New_Device條件必須填寫')", true);
            if (Customer_TB.Text.Trim() == "")
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('New_Customer條件必須填寫')", true);
            if (ND_TB.Text.Trim() == "")
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('New_Device條件必須填寫')", true);

        }*/
        Panel1.Visible = true;
        receive_npiapp_data();
        put_npiimport_data();
        receive_npimanual_data();
        
    }

  

    protected void ND_TB_TextChanged1(object sender, EventArgs e)
    {

    }
}