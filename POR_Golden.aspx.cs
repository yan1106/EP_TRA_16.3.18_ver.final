using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string srcCtl = "";
    public string srcForm = "";
    public List<string> por_golden_data = new List<string>();

    /*
    public void ReturnOpener()
    {
        string jsStr = "";
        jsStr += "window.opener." + srcForm + "." + srcCtl + ".value = ";
        jsStr += "window.opener." + srcForm + "." + srcCtl + ".value = form1." + por_golden_data[1] + ".value; ";
        jsStr += "window.close();";
        jsStr += "self.opener." + srcForm + ".submit();";
        ClientScript.RegisterStartupScript(this.GetType(), "ret", jsStr, true);

    }
    */



    protected void Page_Load(object sender, EventArgs e)
    {

    }

    
  

    protected void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
    {
        int index;
        int i = 0;
        index = Convert.ToInt32(e.CommandArgument);
        GridViewRow selecteRow = GridView1.Rows[index];
        TableCell productName_Device = selecteRow.Cells[1];
        TableCell productName_Production_Site = selecteRow.Cells[2];
        TableCell productName_PKG = selecteRow.Cells[3];
        TableCell productName_Wafer = selecteRow.Cells[4];
        TableCell productName_fab = selecteRow.Cells[5];
        TableCell productWaferPSV = selecteRow.Cells[6];
        TableCell productRVSI = selecteRow.Cells[7];
        TableCell productCustomer = selecteRow.Cells[8];
       


        if (e.CommandName == "yan")
        {

            
             /*por_golden_data.Add(productName_Device.Text);
             por_golden_data.Add(productName_Production_Site.Text);
             por_golden_data.Add(productName_PKG.Text);
             por_golden_data.Add(productName_Wafer.Text);
             por_golden_data.Add(productName_fab.Text);
             por_golden_data.Add(productWaferPSV.Text);
             por_golden_data.Add(productRVSI.Text);
             por_golden_data.Add(productCustomer.Text);
             */

            /* string Device = "Device=" + Server.HtmlEncode(productName_Device.Text);
              string Production_Site = "Production_Site=" + Server.HtmlEncode(productName_Production_Site.Text);
              string PKG = "PKG=" + Server.HtmlEncode(productName_PKG.Text);
              string Wafer = "Wafer=" + Server.HtmlEncode(productName_Wafer.Text);
              string fab = "fab=" + Server.HtmlEncode(productName_fab.Text);
              string WaferPSV = "WaferPSV=" + Server.HtmlEncode(productWaferPSV.Text);
              string RVSI = "RVSI=" + Server.HtmlEncode(productRVSI.Text);
              string Customer = "Customer=" + Server.HtmlEncode(productCustomer.Text);

              string connn = Device + "&" + Production_Site + "&" + PKG + "&" + Wafer + "&" + fab + "&" + WaferPSV + "&" + RVSI + "&" + Customer;

              Server.Transfer("EP_TRA.aspx?" + connn);
              */

            string strScript = "";
            string arydata = "";
            arydata = productName_Device.Text + "|" + productName_Production_Site.Text + "|" + productName_PKG.Text + "|" + productName_Wafer.Text
                +"|"+ productName_fab.Text +"|" + productWaferPSV.Text +"|" + productRVSI.Text +"|" + productCustomer.Text;
            strScript = "<script language='javascript'>Confirm('確定？','" + arydata + "');</script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", strScript);




            /* for (i=0;i<8;i++)
             {
                 Response.Write(por_golden_data[i]+"<br />");
             }*/
            // Response.Write("<script>window.open('POR_Golden.aspx','POR_Golden_Condition',config='height=1024,width=1100');</script>");


            /*
             Response.Redirect("~/EP_TRA.aspx?Device="+this.por_golden_data[0] +"Production_Site=" + this.por_golden_data[1] + "PKG=" + this.por_golden_data[2] +
                  "Wafer=" + this.por_golden_data[3] + "Name_fab=" + this.por_golden_data[4] + "WaferPSV=" + this.por_golden_data[5] +
                  "RVSI=" + this.por_golden_data[6] + "Customer=" + this.por_golden_data[7]);
             */



            /*Response.Redirect("~/EP_TRA.aspx?" + this.por_golden_data[1]  + this.por_golden_data[2] +
                 this.por_golden_data[3] +  this.por_golden_data[4] +  this.por_golden_data[5] +
                 this.por_golden_data[6]  + this.por_golden_data[7]);*/





        }
    }

    [System.Web.Services.WebMethod(EnableSession = true)]

    public static string CreateJob(string strConjData)
    {
        string strError = "";
        string[] strData = new string[1];
        strData = strConjData.Split('|');
        HttpContext.Current.Session["value1"] = strData[0];
        HttpContext.Current.Session["value2"] = strData[1];
        HttpContext.Current.Session["value3"] = strData[2];
        HttpContext.Current.Session["value4"] = strData[3];
        HttpContext.Current.Session["value5"] = strData[4];
        HttpContext.Current.Session["value6"] = strData[5];
        HttpContext.Current.Session["value7"] = strData[6];
        HttpContext.Current.Session["value8"] = strData[7];
        return strError;
    }


    protected void Search_Por_Sql(string porsql)
    {

        clsMySQL db = new clsMySQL(); //Connection MySQL
        clsMySQL.DBReply dr = db.QueryDS(porsql);
        GridView1.DataSource = dr.dsDataSet.Tables[0].DefaultView;
        GridView1.DataBind();
        db.Close();



    }


    protected void Search_por_Click(object sender, EventArgs e)
    {
      
        GridView1.Visible = true;
       


        clsMySQL db = new clsMySQL();
        Boolean bisWhereExist = false;
        string strQuerySQL = "";
        //lblError.Text = "";
        if (PKG_TextBox.Text.Trim() != "" || WaferT_TextBox.Text.Trim() != "" ||
             FAB.Text.Trim() != "" || WaferPSV_TextBox.Text.Trim() != "" || RVSI_TextBox.Text.Trim() != "" ||
             Customer_TextBox.Text.Trim() != "" || ProductionSite_TextBox.Text.Trim() != "")
        {
            strQuerySQL = "Select * from npipor Where Stype='POR' ";
            bisWhereExist = true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('完全沒有輸入，Error~~')", true);
        }
        if (PKG_TextBox.Text.Trim() != "")
        {
            if (bisWhereExist)
            {
                strQuerySQL = strQuerySQL + "and POR_02 like'" + PKG_TextBox.Text + "%' ";
            }
            else
            {
                strQuerySQL = strQuerySQL + "Where POR_01 like'" + PKG_TextBox.Text + "%' ";
            }         
        }
       
        if (WaferT_TextBox.Text.Trim() != "")
        {
            if (bisWhereExist)
            {
                strQuerySQL = strQuerySQL + "and POR_03 like'" + WaferT_TextBox.Text + "%' ";
            }
            else
            {
                strQuerySQL = strQuerySQL + "Where POR_03 like'" + WaferT_TextBox.Text + "%' ";
            }
        }
        if (FAB.Text.Trim() != "")
        {
            if (bisWhereExist)
            {
                strQuerySQL = strQuerySQL + "and POR_04 like'" + FAB.Text + "%' ";
            }
            else
            {
                strQuerySQL = strQuerySQL + "Where POR_04 like'" + FAB.Text + "%' ";
            }
        }
        if (WaferPSV_TextBox.Text.Trim() != "")
        {
            if (bisWhereExist)
            {
                strQuerySQL = strQuerySQL + "and POR_05 like'" + WaferPSV_TextBox.Text + "%' ";
            }
            else
            {
                strQuerySQL = strQuerySQL + "Where POR_04 like'" + WaferPSV_TextBox.Text + "%' ";
            }
        }
        if (RVSI_TextBox.Text.Trim() != "")
        {
            if (bisWhereExist)
            {
                strQuerySQL = strQuerySQL + "and POR_11 like'" + RVSI_TextBox.Text + "%' ";
            }
            else
            {
                strQuerySQL = strQuerySQL + "Where POR_11 like'" + RVSI_TextBox.Text + "%'";
            }
        }
        if (Customer_TextBox.Text.Trim() != "")
        {
            if (bisWhereExist)
            {
                strQuerySQL = strQuerySQL + "and POR_14 like'" + Customer_TextBox.Text + "%' ";
            }
            else
            {
                strQuerySQL = strQuerySQL + "Where POR_14 like'" + Customer_TextBox.Text + "%' ";
            }
        }
        if (ProductionSite_TextBox.Text.Trim() != "")
        {
            if (bisWhereExist)
            {
                strQuerySQL = strQuerySQL + "and POR_01 like'" + ProductionSite_TextBox.Text + "%' ";
            }
            else
            {
                strQuerySQL = strQuerySQL + "Where POR_01 like'" + ProductionSite_TextBox.Text + "%' ";
            }
        }
        //lblError.Text = strQuerySQL;
        try
        {
            clsMySQL.DBReply dr = db.QueryDS(strQuerySQL);
            GridView1.DataSource = dr.dsDataSet.Tables[0].DefaultView;
            GridView1.DataBind();
            db.Close();
        }
        catch (Exception ex)
        {
            //lblError.Text = "[NPIPOR Function-Error Message, btn_Search_Click] : " + ex.ToString();
        }























































    }
}