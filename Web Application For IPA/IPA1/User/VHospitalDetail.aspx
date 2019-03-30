<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" 
CodeBehind="VHospitalDetail.aspx.cs" Inherits="IPA1.User.VHospitalDetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
  input[type="text"][disabled="disabled"],select[disabled]
   {
       width:100%;
       height:34px;
       border: 1px solid #ccc;
       border-radius: 4px;
       cursor:not-allowed;
       padding: 6px 12px;
       background-color: rgb(235, 235, 228);
   }  
 .style2
 {
    color:Red;
 }
 
 .label-validation
 {
     padding-left:4px;
     font-size:small;
     color:Red;
 }
 
 .form-group
 {
     margin-bottom:0px;
    width: 250px;
  }
  
  .form-group-marginbottom
 {
     margin-bottom:25px;
    width: 250px;
  }

 .form-group-marginleft
 {
     margin-left:57px;
    width: 250px;
  }
 #contact .container-wrapper {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: none;
  z-index: 1;
 }

 td
 {
     width:250px;
     padding-right:50px;
 }
 
</style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <asp:MultiView ID="mvHospital" runat="server">
            <br />
            <asp:View ID="vHospital" runat="server">

 <section id="contact" style="margin-top:50px;">
<%--<asp:Image ID="Image1" runat="server" style="height:1000px" ImageUrl="~/Visitor/images/testimonial/bg.jpg"></asp:Image>--%>
      <%--  <div  id="google-map"  style="height:650px" ></div>--%>
        <div  style="height:1500px" ></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:150px;">
                          <div class="contact-form" style="border: 1px solid #CCC;width:700px; padding-left:50px;">
                            <h3>Hospital Service Detail </h3>
                           <div  style="font-size:15px;">
                              <u>Note:</u> 1. Click on New button to fill new service detail form. 
                               <div style="margin-left:40px;">
                               <p>
                                2. Click on View button to view the details of services provided by you. 
                               </p> </div>
                            </div>

      
          <asp:Button ID="btnNew" class="btn btn-primary" runat="server" Text="New" OnClick="btnNew_Click" style="margin-bottom:15px;">
                                                        </asp:Button>
                                                 <div class="row-fluid">
                                                <table>
                                               
                                               <tr>
                                               <td>
                                            <div class="span6">
                                                <div class="dataTables_length">
                                               <div class="form-inline">   
                                             <div class="form-group">
                                               <asp:DropDownList ID="ddlRecPerPage" class="form-control" runat="server"
                                                        OnSelectedIndexChanged="ddlRecPerPage_SelectedIndexChanged" AutoPostBack="True" Width="80px">
                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp;
                                                     <asp:Label ID="lblRecPerPage" runat="server" Text="records per page"></asp:Label>
                                                    </div>
                                                   </div>
                                                </div>
                                            </div>
                                            </td>
                                          
                                      
                                          <td style="padding-right:0px;padding-left:0px;">
                                             <div class="span6">
                                                <div class="dataTables_filter">
                                                <div class="form-inline">
                                                <div class="form-group" style="margin-right:0px;">
                                                 <asp:Label ID="lblSearch" runat="server" Text="Search" Visible="false"></asp:Label>
                                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control" Width="165px"
                                                    Visible="false"></asp:TextBox>
                                                </div>
                                                </div>
                                            </div>
                                        </div>
                                            </td>
                                            </tr>
                                          </table> 
                                        </div>
                                        <br />
                              <div class="divgrid">
                                  <asp:GridView ID="gvHospital" runat="server" AllowPaging="True" 
                                      AutoGenerateColumns="False" BorderColor="#cccccc" BorderStyle="Solid" 
                                      BorderWidth="1px" CellPadding="4" class="table table-striped  table-bordered" 
                                      DataKeyNames="HospitalDetail_ID" EnableModelValidation="True" 
                                      ForeColor="#333333" GridLines="Both" 
                                      OnPageIndexChanging="gvHospital_PageIndexChanging1" 
                                      OnRowCommand="gvHospital_RowCommand" PageSize="5" style="width:600px;" 
                                      AllowSorting="True" onsorting="gvHospital_Sorting">
                                      <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                      <Columns>
                                          <%--           <asp:TemplateField HeaderText="Hospital's Name" SortExpression="FirstName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtName" runat="server" Enabled="false" Text='<%#Eval("FirstName") %>'></asp:TextBox></EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                     --%>
                                          <asp:TemplateField HeaderText="BillNo" SortExpression="BillNo">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblBillNo" runat="server" Text='<%#Eval("BillNo") %>'></asp:Label>
                                              </ItemTemplate>
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="txtBillNo" runat="server" Enabled="false" 
                                                      Text='<%#Eval("BillNo") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <FooterTemplate>
                                              </FooterTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Patient's Name | ID" SortExpression="Name">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                              </ItemTemplate>
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="txtPatientName" runat="server" Enabled="false" 
                                                      Text='<%#Eval("Name") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <FooterTemplate>
                                              </FooterTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalAmount">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                              </ItemTemplate>
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="false" 
                                                      Text='<%#Eval("TotalAmount") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <FooterTemplate>
                                              </FooterTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Discount" SortExpression="Discount">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'></asp:Label>
                                              </ItemTemplate>
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="txtDiscount" runat="server" Enabled="false" 
                                                      Text='<%#Eval("Discount") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <FooterTemplate>
                                              </FooterTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Final Amount" SortExpression="FinalAmount">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblFinalAmount" runat="server" Text='<%#Eval("FinalAmount") %>'></asp:Label>
                                              </ItemTemplate>
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="txtFinalAmount" runat="server" Enabled="false" 
                                                      Text='<%#Eval("FinalAmount") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <FooterTemplate>
                                              </FooterTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Payment Status" SortExpression="PaymentStatus">
                                              <ItemTemplate>
                                                  <asp:Label ID="lblPaymentStatus" runat="server" 
                                                      Text='<%#Eval("PaymentStatus") %>'></asp:Label>
                                              </ItemTemplate>
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="txtPaymentStatus" runat="server" Enabled="false" 
                                                      Text='<%#Eval("PaymentStatus") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <FooterTemplate>
                                              </FooterTemplate>
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="View">
                                              <ItemTemplate>
                                                  <asp:Button ID="btnView" runat="server" class="btn btn-primary" 
                                                      CommandArgument='<%#Eval("HospitalDetail_ID") %>' CommandName="View" 
                                                      style="width:70px;" Text="View" />
                                              </ItemTemplate>
                                              <EditItemTemplate>
                                              </EditItemTemplate>
                                              <FooterTemplate>
                                              </FooterTemplate>
                                          </asp:TemplateField>
                                      </Columns>
                                      <EditRowStyle BackColor="#ebebeb" />
                                      <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="Red" />
                                      <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                      <PagerStyle BackColor="#d6d6d6" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                      <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                      <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                  </asp:GridView>
                              </div>
                                </div>
                                </div>
                                </div>
                                </div>
                                </div>
                                </section>
                                </asp:View>

                                 <asp:View ID="vHospitalDetail" runat="server">
    <section id="contact" style="margin-top:50px;">
<%--<asp:Image ID="Image1" runat="server" style="height:1000px" ImageUrl="~/Visitor/images/testimonial/bg.jpg"></asp:Image>--%>
      <%--  <div  id="google-map"  style="height:650px" ></div>--%>
        <div  style="height:1500px" ></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:150px;">
                          <div class="contact-form" style="border: 1px solid #CCC; width:700px;">
                            <h3>Hospital Service Detail </h3>
                          <%-- <div  style="font-size:15px;">
                              <u>Note:</u> 1. Click on New button to fill new service detail form. 
                               <div style="margin-left:40px;">
                               <p>
                                2. Click on View button to view the details of services provided by you. 
                               </p> </div>
                            </div>--%>

      

      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>

                                            <table class="" >
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtHospitalDetail_ID" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                        <td>
                                      </td>
                                            <td>
                                          
                                            </td>
                                            </tr>
                                          
                                            <tr>
                                            <td>
                                           
                                              <div class="form-group">
                                           
                                               <h4> <u>
                                               <asp:Label ID="lblBillNo" runat="server" Text="BillNo: "></asp:Label>
                                               <asp:Label ID="lblBillNo1" runat="server"></asp:Label>
                                               </u></h4 >
                                               
                                          
                                          

                                           
                                              <%--  <asp:TextBox ID="txtBillNo" runat="server" Enabled="False"  Width="300px" Height="34px" class="form-control" ></asp:TextBox>--%>
                                          <%-- <h3> <asp:Label ID="lblBillNo1" runat="server"></asp:Label></h3>--%>
                                            </div>
                                      
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                        <td>
                                         <%--   <asp:Label ID="lblcvHName" runat="server" ForeColor="Red" CssClass="lable-validation"></asp:Label>--%>
                                        </td>
                                        <td>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            <br />
                                             Doctor Name<span class="style2">*</span>
                                            </td>
                                            <td>
                                            <br />
                                                Patient Name<span class="style2">*</span>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                             <div class="form-inline">
                                        <div class="form-group">
                                          <asp:Label ID="lblDr" runat="server" Text="Dr." style="text-align:left"></asp:Label>
                                              
                                          <asp:TextBox ID="txtDName" runat="server" MaxLength="50"  Width="220px" class="form-control"></asp:TextBox>
                                       </div>
                                       </div>
                                       
                                            </td>
                                             <td>
                                             <div class="form-group">
                                                <asp:DropDownList ID="ddlPName" runat="server" Enabled="false"  class="form-control">
                                                </asp:DropDownList>
                                                </div>
                                            </td>
                                            <tr>
                                            <td>
                                           
                                                  <asp:requiredfieldvalidator id="rfvdname1" runat="server" controltovalidate="txtDName"
                                                    errormessage="Required" forecolor="red" validationgroup="Submit" CssClass="label-validation"></asp:requiredfieldvalidator>
                                               
                                               <asp:RegularExpressionValidator ID="reDName" runat="server" ControlToValidate="txtDName"
                                                    ErrorMessage="Alphabets only!" ValidationExpression="[a-z A-Z ]+" ValidationGroup="Submit"
                                                    ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                                          
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcvPName" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                                            </td>
                                        </tr>
                                     
                                        <tr>
                                            <td>
                                              Admit Date<span class="style2">*</span>
                                            </td>
                                              <td>
                                                Admit Time<span class="style2">*</span>
                                            </td>
                                        


                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtAdmitDate" runat="server" 
                                                    ontextchanged="txtAdmitDate_TextChanged" class="form-control" 
                                                     AutoPostBack="True"></asp:TextBox>
                                                <cc:CalendarExtender ID="txtAdmitDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                    Enabled="True" TargetControlID="txtAdmitDate">
                                                </cc:CalendarExtender>
                                            </td>
                                               <td>
                                                <div class="form-group form-inline">
                                                    <asp:DropDownList ID="ddlHour" runat="server" Height="30px" Width="80px" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlMinute" runat="server" Height="30px" Width="80px" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlAMPM" runat="server" Height="30px" Width="80px" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvAdmitDate" runat="server" ControlToValidate="txtAdmitDate"
                                                    ErrorMessage="Required" ValidationGroup="Submit" SetFocusOnError="True" CssClass="label-validation"></asp:RequiredFieldValidator>
                                            </td>
                                              <td>
                                              <div class="form-group">
                                                <asp:Label ID="lblcvAdmitTime" runat="server" cssclass="label-validation"></asp:Label>
                                          
                                          </div>  </td>
                                        </tr>
                                    
                                        <tr>
                                            <td>
                                                Discharge Date(optional)
                                            </td>
                                             <td>
                                                Discharge Time(optional)
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                                
                                                <asp:TextBox ID="txtDischargeDate" runat="server" 
                                                    ontextchanged="txtDischargeDate_TextChanged" 
                                                    class="form-control" AutoPostBack="True"></asp:TextBox>
                                            <cc:CalendarExtender ID="txtDischargeDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                    Enabled="True" TargetControlID="txtDischargeDate">
                                                </cc:CalendarExtender>
                                            </td>
                                                <td>
                                                <div class="form-group form-inline">
                                                    <asp:DropDownList ID="ddlHour1" runat="server" Height="30px" Width="80px" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlMinute1" runat="server" Height="30px" Width="80px" CssClass="form-control">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlAMPM1" runat="server" Height="30px" Width="80px" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                          <%--      <asp:RequiredFieldValidator ID="rfvDischargeDate" runat="server" ControlToValidate="txtDischargeDate"
                                                    ErrorMessage="Required" ValidationGroup="Submit" SetFocusOnError="True" cssclass="label-validation"></asp:RequiredFieldValidator>
                                         --%>       
                                                <asp:Label ID="lblcvDischargeDate" runat="server" ForeColor="Red" Text="Discharge Date can't be in the Past!"
                                                    Visible="False" CssClass="label-validation"></asp:Label>
                                            </td>
                                       
                                                <td>
                                                    <asp:Label ID="lblcvDischargeTime" runat="server" cssclass="label-validation"></asp:Label>
                                                </td>
                                            </tr>
                                      
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlPName" />
                                       
                                            <asp:AsyncPostBackTrigger ControlID="txtAdmitDate" />
                                            <asp:AsyncPostBackTrigger ControlID="txtDischargeDate" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    
                                   
                                    
                                    <br />
                              <asp:GridView ID="gvHospitalDetail" runat="server" AllowPaging="True" 
                                  AutoGenerateColumns="False" BorderColor="#cccccc" BorderStyle="Solid" 
                                  BorderWidth="1px" CellPadding="4" 
                                  CssClass="table table-striped  table-bordered" DataKeyNames="id" 
                                  EnableModelValidation="True" ForeColor="#333333" GridLines="Horizontal" 
                                  OnPageIndexChanging="gvHospitalDetail_PageIndexChanging" 
                                  OnRowCancelingEdit="gvHospitalDetail_RowCancelingEdit" 
                                  OnRowDeleting="gvHospitalDetail_RowDeleting" 
                                  OnRowEditing="gvHospitalDetail_RowEditing" 
                                  OnRowUpdating="gvHospitalDetail_RowUpdating" PageSize="5" ShowFooter="True">
                                  <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                  <Columns>
                                      <asp:TemplateField HeaderText="ID">
                                          <ItemTemplate>
                                              <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                          </ItemTemplate>
                                          <EditItemTemplate>
                                              <asp:TextBox ID="txtId" runat="server" Enabled="false" 
                                                  style="width:120px; margin-top:10px; height:25px" Text='<%#Eval("id") %>'>
                                              </asp:TextBox>
                                          </EditItemTemplate>
                                          <FooterTemplate>
                                          </FooterTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Service Description">
                                          <ItemTemplate>
                                              <asp:Label ID="lblServiceDescription" runat="server" 
                                                  Text='<%#Eval("ServiceDescription") %>'></asp:Label>
                                          </ItemTemplate>
                                          <EditItemTemplate>
                                              <asp:TextBox ID="txtServiceDescription" runat="server" 
                                                  style="width:180px; margin-top:10px" Text='<%#Eval("ServiceDescription") %>'>
                                              </asp:TextBox>
                                              <asp:RequiredFieldValidator ID="rfvServiceDescription" runat="server" 
                                                  ControlToValidate="txtServiceDescription" ErrorMessage="*" ForeColor="Red" 
                                                  SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                              <br />
                                              <asp:RegularExpressionValidator ID="revServiceDescription" runat="server" 
                                                  ControlToValidate="txtServiceDescription" 
                                                  ErrorMessage="Invalid Service Description" ForeColor="Red" 
                                                  SetFocusOnError="True" ValidationExpression="[a-zA-Z0-9 ]+" 
                                                  ValidationGroup="Update"></asp:RegularExpressionValidator>
                                          </EditItemTemplate>
                                          <FooterTemplate>
                                              <asp:TextBox ID="txtIServiceDescription" runat="server" 
                                                  style="width:180px; margin-top:10px"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="rfvIServiceDescription" runat="server" 
                                                  ControlToValidate="txtIServiceDescription" ErrorMessage="*" ForeColor="Red" 
                                                  SetFocusOnError="True" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                              <br />
                                              <asp:RegularExpressionValidator ID="revIServiceDescription" runat="server" 
                                                  ControlToValidate="txtIServiceDescription" 
                                                  ErrorMessage="Invalid Service Description" ForeColor="Red" 
                                                  SetFocusOnError="True" ValidationExpression="[a-zA-Z0-9 ]+" 
                                                  ValidationGroup="Insert"></asp:RegularExpressionValidator>
                                          </FooterTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Service Charge">
                                          <ItemTemplate>
                                              <asp:Label ID="lblServiceCharge" runat="server" 
                                                  Text='<%#Eval("ServiceCharges") %>'></asp:Label>
                                          </ItemTemplate>
                                          <EditItemTemplate>
                                              <asp:TextBox ID="txtServiceCharge" runat="server" AutoPostBack="True" 
                                                  ontextchanged="txtServiceCharge_TextChanged" 
                                                  style="width:180; margin-top:10px;" Text='<%#Eval("ServiceCharges") %>'>
                                              </asp:TextBox>
                                              <asp:RequiredFieldValidator ID="rfvServiceCharge" runat="server" 
                                                  ControlToValidate="txtServiceCharge" ErrorMessage="*" ForeColor="Red" 
                                                  SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                              <br />
                                              <asp:Label ID="lblcvServiceCharge" runat="server" ForeColor="Red" Text=""></asp:Label>
                                          </EditItemTemplate>
                                          <FooterTemplate>
                                              <asp:TextBox ID="txtIServiceCharge" runat="server" AutoPostBack="True" 
                                                  ontextchanged="txtIServiceCharge_TextChanged" 
                                                  style="width:180; margin-top:10px;"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="rfvIServiceCharge" runat="server" 
                                                  ControlToValidate="txtIServiceCharge" ErrorMessage="*" ForeColor="Red" 
                                                  SetFocusOnError="True" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                                              <br />
                                              <asp:Label ID="lblcvIServiceCharge" runat="server" ForeColor="Red" Text=""></asp:Label>
                                          </FooterTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Edit">
                                          <ItemTemplate>
                                              <asp:Button ID="btnEdit" runat="server" class="btn btn-primary" 
                                                  CommandName="Edit" style="width:70px;" Text="Edit" />
                                          </ItemTemplate>
                                          <EditItemTemplate>
                                              <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" 
                                                  CommandName="Update" style="margin-bottom:25px; width:70px;" Text="Update" 
                                                  ValidationGroup="Update" />
                                          </EditItemTemplate>
                                          <FooterTemplate>
                                              <asp:Button ID="btnInsert" runat="server" class="btn btn-primary" 
                                                  OnClick="btnInsert_Click" style="margin-bottom:25px; width:70px;" Text="Insert" 
                                                  ValidationGroup="Insert" />
                                          </FooterTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Delete">
                                          <ItemTemplate>
                                              <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" 
                                                  CommandName="Delete" style="margin-bottom:25px; width:70px;" Text="Delete" />
                                          </ItemTemplate>
                                          <EditItemTemplate>
                                              <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" 
                                                  CommandName="Cancel" style="width:70px;" Text="Cancel" />
                                          </EditItemTemplate>
                                          <FooterTemplate>
                                          </FooterTemplate>
                                      </asp:TemplateField>
                                  </Columns>
                                  <EditRowStyle BackColor="#ebebeb" Width="300px" />
                                  <FooterStyle BackColor="White" Font-Bold="False" Height="20px" />
                                  <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" 
                                      height="5px" />
                                  <PagerStyle BackColor="#d6d6d6" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                  <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="10px" />
                                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" 
                                      width="10px" />
                              </asp:GridView>
                              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                  <ContentTemplate>
                                      <table>
                                          <tr>
                                              <td>
                                                  Total Amount
                                              </td>
                                              <td>
                                                  Discount(%)<span class="style2">*</span>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <div class="form-group">
                                                      <asp:TextBox ID="txtTAmount" runat="server" class="form-control" 
                                                          Enabled="False" MaxLength="20"></asp:TextBox>
                                                  </div>
                                              </td>
                                              <td>
                                                  <div class="form-group">
                                                      <asp:TextBox ID="txtDiscount" runat="server" AutoPostBack="True" 
                                                          class="form-control" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                                  </div>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="lblcvTAmount" runat="server" CssClass="lable-validation" 
                                                      ForeColor="Red"></asp:Label>
                                              </td>
                                              <td>
                                                  <asp:RequiredFieldValidator ID="rvdiscount" runat="server" 
                                                      controltovalidate="txtDiscount" CssClass="label-validation" errormessage="*" 
                                                      forecolor="red" setfocusonerror="true" validationgroup="Submit"></asp:RequiredFieldValidator>
                                                  <asp:Label ID="lblcvDiscount" runat="server" CssClass="label-validation" 
                                                      ForeColor="Red"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="lblDiscountAmount" runat="server" Text="Discount Amount"></asp:Label>
                                              </td>
                                              <td>
                                                  Final Amount
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <div class="form-group">
                                                      <asp:TextBox ID="txtDiscountAmount" runat="server" class="form-group" 
                                                          Enabled="False"></asp:TextBox>
                                                  </div>
                                              </td>
                                              <td>
                                                  <div class="form-group">
                                                      <asp:TextBox ID="txtFinalAmount" runat="server" class="form-control" 
                                                          Enabled="False"></asp:TextBox>
                                                  </div>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <br />
                                                  Payment Status
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <div class="form-group">
                                                      <asp:DropDownList ID="ddlPStatus" runat="server" class="form-control" 
                                                          Enabled="False">
                                                          <asp:ListItem>Unpaid</asp:ListItem>
                                                          <asp:ListItem>Paid</asp:ListItem>
                                                      </asp:DropDownList>
                                                  </div>
                                              </td>
                                          </tr>
                                      </table>
                                  </ContentTemplate>
                                  <triggers>
                                      <asp:AsyncPostBackTrigger ControlID="txtDiscount" />
                                  </triggers>
                              </asp:UpdatePanel>
                              <table>
                                  <tr>
                                      <td>
                                          <br />
                                          <div class="form-inline">
                                              <div class="form-group">
                                                  <asp:LinkButton ID="btnSubmit" runat="server" class="btn btn-primary" 
                                                      OnClick="btnSubmit_Click" ValidationGroup="Submit">
                                                  <i class="icon-ok icon-white"></i>Submit
                                                  </asp:LinkButton>
                                                  &nbsp;<asp:LinkButton ID="btnReset" runat="server" class="btn btn-primary" 
                                                      OnClick="btnReset_Click"> <i class="icon-refresh">
                                                  </i>Reset
                                                  </asp:LinkButton>
                                                  &nbsp;<asp:LinkButton ID="btnCancel" runat="server" class="btn btn-primary" 
                                                      OnClick="btnCancel_Click">
                                                  <i class="icon-ban-circle"></i>Cancel
                                                  </asp:LinkButton>
                                                  <br />
                                              </div>
                                          </div>
                                      </td>
                                  </tr>
                                  <tr>
                                      <td>
                                          <br />
                                      </td>
                                  </tr>
                              </table>
                          
                          </div>
                          </div>
                                </div>
                                </div>
                                </div>
                                </section>
                                

                          </asp:View>
                                </asp:MultiView>
                                 
</asp:Content>
