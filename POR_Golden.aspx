<%@ Page Language="C#" AutoEventWireup="true" CodeFile="POR_Golden.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>POR_Golden!</title>
<head runat="server">
    <link rel="stylesheet" href="..\css\styles.css" type="text/css" />
<link rel="stylesheet" href="http://code.jquery.com/ui/1.9.2/themes/base/jquery-ui.css" />
<script src="http://code.jquery.com/jquery-1.8.3.js"></script>
<script src="http://jqueryui.com/resources/demos/external/jquery.bgiframe-2.1.2.js"></script>
<script src="http://code.jquery.com/ui/1.9.2/jquery-ui.js"></script>
<script type="text/javascript">
    function Confirm(strMsg, strData) {
        var isOK = confirm(strMsg);
        if (isOK) {
            PageMethods.CreateJob(strData, OnSuccess, OnFail);
                
        }
    }
    function OnSuccess(receiveData, userContext, methodName) {
        //成功時，目地控制項顯示所接收結果
        if (receiveData == "") {
            window.parent.$('#dialog').dialog('close');
            window.parent.$('#cmdFilter').click();
        } else {
            alert(methodName + ": " + receiveData);
        }
    }

    function OnFail(error, userContext, methodName) {
        if (error != null) {
            alert(methodName + ": " + error.get_message());
        }
    }
</script>
</head>
<body>
    <form id="form1"  runat="server">
          
      
    <asp:Panel ID="CPSP_Panel" runat="server" Visible="true" Width="1079px">             
    <fieldset class="auto-style85">
    <legend style="font-weight: 900; font-size: large;" class="auto-style96">POR Golden Condition</legend>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <table class="auto-style160">
            <tr>
                <td class="auto-style166"><span class="auto-style98"><strong>PKG </strong></span></td>
                <td class="auto-style164">
                    <asp:TextBox ID="PKG_TextBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style159"><strong>FAB</strong></td>
                <td class="auto-style158">
                    <asp:TextBox ID="FAB" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style161"><strong><span class="auto-style106">RVSI(Y/N)</span></strong></td>
                <td class="auto-style158">
                    <asp:TextBox ID="RVSI_TextBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style163"><strong>Production Site</strong></td>
                <td class="auto-style158">
                    <asp:TextBox ID="ProductionSite_TextBox" runat="server" Width="100px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style167"><span class="auto-style156">　</span><span class="auto-style168"><strong>Wafer Tech.(nm)</strong></span></td>
                <td class="auto-style165">
                    <asp:TextBox ID="WaferT_TextBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style157"><span class="auto-style168"><strong>Wafer PSV type / Thickness</strong></span></td>
                <td class="auto-style169">
                    <asp:TextBox ID="WaferPSV_TextBox" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style162"><strong><span class="auto-style107">Customer</span></strong></td>
                <td class="auto-style169">
                    <asp:TextBox ID="Customer_TextBox" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" style="text-align: center">
                    
                    <asp:Button ID="Search_por" runat="server" class="blueButton button2" OnClick="Search_por_Click" Text="Search" />
                    
                   
                </td>
            </tr>
        </table>
        
        <br />
        <br />
        </fieldset><br /> &nbsp;<hr />
       
        <br />
        
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>
          
     
         
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" 
                BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
                 GridLines="None" Height="150px"
               DataKeyNames="POR_Customer,POR_Device" 
        onrowcommand="GridView1_RowCommand">
                <Columns>
                    <asp:ButtonField CommandName="yan" Text="選取"  />
                    <asp:BoundField DataField="POR_17" HeaderText="*Device" />
                    <asp:BoundField DataField="POR_01" HeaderText="*Production Site" />
                    <asp:BoundField DataField="POR_02" HeaderText="*PKG " />
                    <asp:BoundField DataField="POR_03" HeaderText="*Wafer Tech.(nm)" />
                    <asp:BoundField DataField="POR_04" HeaderText="*FAB" />
                    <asp:BoundField DataField="POR_05" HeaderText="*Wafer PSV type / Thickness" />
                    <asp:BoundField DataField="POR_11" HeaderText="*RVSI(Y/N)" />
                    <asp:BoundField DataField="POR_14" HeaderText="*Customer" />
                </Columns>
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />

            </asp:GridView>
            <br />
           
        
            &nbsp;
        
        <br />
 </asp:Panel>

         
        
    </form>
</body>
</html>
