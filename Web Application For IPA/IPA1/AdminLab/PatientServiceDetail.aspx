<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientServiceDetail.aspx.cs"
    Inherits="IPA1.AdminLab.PatientServiceDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            BusLib.Transaction.Patient objPatient = new BusLib.Transaction.Patient();
            BusLib.Common.Registration objRegister = new BusLib.Common.Registration();
            BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();
             BusLib.Common.EncryptDecryptQueryString objEDQueryString = new BusLib.Common.EncryptDecryptQueryString();
          String Request_ID="";
        String User_ID = "";

        if (Request.QueryString.Count > 0)
        {


            ViewState["User_ID"] = "";
            ViewState["Request_ID"] = "";
            string strReq = "";
            strReq = Request.RawUrl;
            strReq = strReq.Substring(strReq.IndexOf('?') + 1);

            if (!strReq.Equals(""))
            {
                strReq = DecryptQueryString(strReq);

                //Parse the value... this is done is very raw format.. you can add loops or so to get the values out of the query string...
                string[] arrMsgs = strReq.Split('&');
                string[] arrIndMsg;

                arrIndMsg = arrMsgs[0].Split('=');
                Request_ID = arrIndMsg[1].ToString().Trim();
                ViewState["Request_ID"] = Request_ID;

                arrIndMsg = arrMsgs[1].Split('='); //
                User_ID = arrIndMsg[1].ToString().Trim();

                if (User_ID != "" && Request_ID != "")
                {
                    objRequest.Request_ID1 = Convert.ToInt16(Request_ID);
                    objRequest.GetDataSet_GetPatientDetail();
                    //  objPatient.GetDataSet_GetPatientDetail();

                    objRegister.User_ID1 = Convert.ToInt16(User_ID);

                    objRegister.GetDataSet_Select();

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



        }
        
        
        
        
        
        %>



        <div>
            <b><u>&nbsp;PATIENT DETAIL </u></b>
            <br />
            <br />
        </div>
        <table cellpadding="5px">
            <tr>
                <td class="style3">
                    Request No
                    <br />
                </td>
                <td style="width: 400px;">
                    <%  Response.Write(objRequest.Ds.Tables[0].Rows[0]["Request_ID"].ToString());   %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Name
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["Name"].ToString());  
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Address
                </td>
                <td style="width: 400px;">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["Address"].ToString());  
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    City
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["City"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    State
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["State"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    PinCode
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["PinCode"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Mobile No
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["MobileNo"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Email
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRequest.Ds.Tables[0].Rows[0]["Email"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    IdProof
                </td>
                <td class="style6">
                    <asp:ImageButton ID="ibIdProof" runat="server" Width="150px" Height="150px" OnClick="ibIdProof_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Disease Related Documents 1
                </td>
                <td class="style6">
                    <asp:ImageButton ID="ibDocument1" runat="server" Width="150px" Height="150px" OnClick="ibDocument1_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Disease Related Documents 2
                </td>
                <td class="style6">
                    <asp:ImageButton ID="ibDocument2" runat="server" Width="150px" Height="150px" OnClick="ibDocument2_Click" />
                </td>
            </tr>
        </table>
        <br />
        <div>
            <b><u>&nbsp;HOSPITAL DETAIL </u></b>
            <br />
            <br />
        </div>
        <table cellpadding="5px">
            <tr>
                <td class="style3">
                    ID
                </td>
                <td style="width: 400px;">
                    <% 
                        Response.Write(objRegister.Ds.Tables[0].Rows[0]["User_ID"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Name
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRegister.Ds.Tables[0].Rows[0]["FirstName"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Address
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRegister.Ds.Tables[0].Rows[0]["Address"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    City
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRegister.Ds.Tables[0].Rows[0]["City"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    State
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRegister.Ds.Tables[0].Rows[0]["State"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    PinCode
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRegister.Ds.Tables[0].Rows[0]["PinCode"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Mobile No
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRegister.Ds.Tables[0].Rows[0]["MobileNo"].ToString());
                    %>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Email
                </td>
                <td class="style6">
                    <% 
                        Response.Write(objRegister.Ds.Tables[0].Rows[0]["Email"].ToString());
                    %>
                </td>
            </tr>
        </table>
         </div>
    </form>

       
 
   
</body>
</html>
