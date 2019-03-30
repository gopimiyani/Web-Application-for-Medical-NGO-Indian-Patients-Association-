<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForwardRequestDetail.aspx.cs"
    Inherits="IPA1.AdminLab.Request_forward" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 23px;
            width: 239px;
        }
        .style2
        {
            width: 400px;
            height: 23px;
        }
        .style3
        {
            width: 239px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%
            BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();
            BusLib.Common.Registration objRegister = new BusLib.Common.Registration();
            BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
                      if (Request.QueryString.Count > 0)
                        {
                            if (Request.QueryString["Request_ID"].ToString() != "")
                            {
                                objRequest.Request_ID1 = Convert.ToInt16( Request.QueryString["Request_ID"].ToString() );
                                
                                objRequest.GetDataSet_GetViewRequestDetail();
                      
                            }
                            else
                            {
                                Response.Redirect("~/AdminLab/Login.aspx");
                            }
                            
                        }
                        else
                        {
                            //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Access Denied '); </script>");
                            //return;
                            Response.Redirect("~/AdminLab/Login.aspx");
                        }
                    %>
        
            
              
        <div>
          <b><u>&nbsp;REQUEST DETAIL </u></b><br />
            <br />
        </div>
        <table cellpadding="5px">
            <tr>
                <td class="style3">
                    Request No <br />
                </td>
                <td style="width: 400px;">
                <%  Response.Write(objRequest.Ds.Tables[0].Rows[0]["Request_ID"].ToString());   %>      
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Referenced by StakeHolder <br />

                </td>
                <td class="style6">
                    <% 
                            
                        if (objRequest.Ds.Tables[0].Rows[0]["User_ID"].ToString() != "0")
                        {

                            int UserID = Convert.ToInt16(objRequest.Ds.Tables[0].Rows[0]["User_ID"].ToString());
                            objRegister.User_ID1 = UserID;
                            objRegister.GetDataSet_Select();
                            if (objRegister.Ds.Tables[0].Rows[0]["FirstName"].ToString() != null)
                            {
                                String FirstName = objRegister.Ds.Tables[0].Rows[0]["FirstName"].ToString();
                                //txtUserID.Text = FirstName + " | " + UserID;
                                Response.Write(objRegister.Ds.Tables[0].Rows[0]["FirstName"].ToString());
                            }
                        }
                           
                    %>
                </td>
            </tr>
         
            <tr>
                <td class="style3" >
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; OR<br />

                </td>
                <td class="style6">
                </td>
            </tr>
         
         
            <tr>
                <td class="style3">
                    Referenced by Admin <br />
                </td>
                <td class="style6">
                    <% 
                            
                        if (objRequest.Ds.Tables[0].Rows[0]["Admin_ID"].ToString() != "0")
                        {
                            objAdmin.Admin_ID1 = Convert.ToInt16(objRequest.Ds.Tables[0].Rows[0]["Admin_ID"].ToString());
                            objAdmin.GetDataset();

                            Response.Write(objAdmin.Ds.Tables[0].Rows[0]["FirstName"].ToString());
                        }

                           
                    %>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    Date <br />
                </td>
                <td class="style2">
                    <% 
                        DateTime RequestDate = Convert.ToDateTime(objRequest.Ds.Tables[0].Rows[0]["Date"].ToString());
                        Response.Write(RequestDate.ToString("dd-MM-yyyy"));
  
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Name </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["Name"].ToString());  
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Subject </td>
                <td style="width: 400px;">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["Subject"].ToString());  
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Request Detail </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["Description"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Address </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["Address"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Mobile No</td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["MobileNo"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Email </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["Email"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    City </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["City"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    State </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["State"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    PinCode </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["PinCode"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    ID Proof </td>
                <td class="style6">

                    <% 
                //        String IdProof = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof1"].ToString();
                    %>
                    <asp:ImageButton ID="ibIdProof" runat="server" Width="150px" Height="150px" onclick="ibIdProof_Click" />
                    <br />
                </td>
            </tr>


             <tr>
                <td class="style3">
                    Disease related document </td>
                <td class="style6">
                <%
                    
                     %>
                    <asp:ImageButton ID="ibDiseaseDoc1" runat="server" Width="150px" Height="150px" 
                        onclick="ibDiseaseDoc1_Click" />
                      &nbsp;&nbsp;
                      <asp:ImageButton ID="ibDiseaseDoc2" runat="server" Width="150px" Height="150px" 
                        onclick="ibDiseaseDoc2_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
