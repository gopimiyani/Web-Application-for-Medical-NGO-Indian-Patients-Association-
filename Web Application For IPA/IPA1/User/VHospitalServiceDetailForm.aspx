<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true"
 CodeBehind="VHospitalServiceDetailForm.aspx.cs" Inherits="IPA1.User.VHospitalServiceDetailForm" %>
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
   .form-control[readonly]
   {
       background-color:White;
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
 
 .divgrid input, .textarea, .uneditable-input
{
    width:100px;
}

.divgrid input[type="text"]
{
    width:100px;
}
</style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <section id="contact" style="margin-top:50px;">
<%--<asp:Image ID="Image1" runat="server" style="height:1000px" ImageUrl="~/Visitor/images/testimonial/bg.jpg"></asp:Image>--%>
      <%--  <div  id="google-map"  style="height:650px" ></div>--%>
        <div  style="height:1500px" ></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:150px;">
                          <div class="contact-form" style="border: 1px solid #CCC; width:700px; padding-left:50px">
                            <h3>Hospital Service Detail Form</h3>
                            <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                         
               <table>
                                        <tr>
                                          <td>
                                       <h4> <u>
                                               <asp:Label ID="lblBillNo" runat="server" Text="BillNo: "></asp:Label>
                                               <asp:Label ID="lblBillNo1" runat="server"></asp:Label>
                                               </u></h4 >
                                             
                                           
                                                                                       </td>
                                            </tr>
                                            <tr>
                                       <td>
                                             <div class="form-group">
                                            </td>
                                        </tr>
                                        <tr>
                                        <td>
                                            <asp:Label ID="lblcvHName" runat="server" ForeColor="Red" CssClass="lable-validation"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td>
                                             Doctor Name<span class="style2">*</span></span>
                                            </td>
                                            <td>
                                                Patient Name<span class="style2">*</span></span>
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
                                                <asp:DropDownList ID="ddlPName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPName_SelectedIndexChanged" class="form-control">
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
                                                    AutoPostBack="True" style="cursor:default;background-color:White;"></asp:TextBox>
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
                                                Discharge Date(optional)<span class="style2"></span>
                                            </td>
                                             <td>
                                                Discharge Time(optional)<span class="style2"></span>
                                            </td>
                                            <tr>
                                            <td>
                                                
                                                <asp:TextBox ID="txtDischargeDate" runat="server" 
                                                    ontextchanged="txtDischargeDate_TextChanged" class="form-control" 
                                                    AutoPostBack="True" style="cursor:default;background-color:White;"></asp:TextBox>
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
                                           <%--     <asp:RequiredFieldValidator ID="rfvDischargeDate" runat="server" ControlToValidate="txtDischargeDate"
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

                            
                            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                            <ContentTemplate>

                                     <div class="divgrid" style="">   
                                         <br />
                                    <asp:GridView ID="gvHospital" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        DataKeyNames="id" EnableModelValidation="True" ForeColor="#333333" CellPadding="4"
                                        GridLines="Horizontal" OnPageIndexChanging="gvHospital_PageIndexChanging" OnRowCancelingEdit="gvHospital_RowCancelingEdit"
                                        OnRowDeleting="gvHospital_RowDeleting" OnRowEditing="gvHospital_RowEditing" OnRowUpdating="gvHospital_RowUpdating"
                                        BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid" ShowFooter="True" style="Width:300px;" PageSize="5" >
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                                </ItemTemplate>

                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtId" runat="server" Enabled="false" Text='<%#Eval("id")  %>' style="width:50px; margin-bottom:25px; height:25px"> </asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblServiceDescription" runat="server" Text='<%#Eval("ServiceDescription") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtServiceDescription" runat="server" Text='<%#Eval("ServiceDescription") %>' style="width:120px; margin-top:50px"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvServiceDescription" runat="server" ControlToValidate="txtServiceDescription"
                                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                                    <asp:RegularExpressionValidator ID="revServiceDescription" runat="server" SetFocusOnError="True"
                                                        ErrorMessage="Invalid Service Description" ControlToValidate="txtServiceDescription"
                                                        ValidationExpression="[a-zA-Z0-9 ]+" ValidationGroup="Update" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtIServiceDescription" runat="server" style="width:100px; margin-top:45px;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvIServiceDescription" runat="server" ControlToValidate="txtIServiceDescription"
                                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                                    <asp:RegularExpressionValidator ID="revIServiceDescription" runat="server" SetFocusOnError="True"
                                                        ErrorMessage="Invalid Service Description" ControlToValidate="txtIServiceDescription"
                                                        ValidationExpression="[a-zA-Z0-9 ]+" ValidationGroup="Insert" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Charge">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblServiceCharge" runat="server" Text='<%#Eval("ServiceCharges") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtServiceCharge" runat="server" Text='<%#Eval("ServiceCharges") %>'
                                                        OnTextChanged="txtServiceCharge_TextChanged" AutoPostBack="True" style="width:100px;" > </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvServiceCharge" runat="server" ControlToValidate="txtServiceCharge"
                                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red" ></asp:RequiredFieldValidator><br />
                                                    <asp:Label ID="lblcvServiceCharge" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtIServiceCharge" runat="server" OnTextChanged="txtIServiceCharge_TextChanged"
                                                        AutoPostBack="True" style="margin-bottom:30px; width:120px;"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvIServiceCharge" runat="server" ControlToValidate="txtIServiceCharge"
                                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                                    <asp:Label ID="lblcvIServiceCharge" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" class="btn btn-primary" Text="Edit" CommandName="Edit" style="width:60px; padding-right:40px;">
                                    </asp:Button>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Update" class="btn btn-primary"
                                        Text="Update" CommandName="Update" style=" margin-bottom:25px; width:60px;"/>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnInsert" runat="server" ValidationGroup="Insert" class="btn btn-primary"
                                        Text="Insert" OnClick="btnInsert_Click" style=" width:60px; margin-bottom:55px; "></asp:Button>
                                </FooterTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" Text="Delete" CommandName="Delete" style="width:60px;" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" CommandName="Cancel" style="margin-bottom:25px; width:60px;"/>
                                </EditItemTemplate>
                                
                            </asp:TemplateField>

                                        </Columns>
                                     <EditRowStyle BackColor="#ebebeb" />
                                        <FooterStyle BackColor="White" Font-Bold="False" Height="25px" />
                                        <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                        <PagerStyle BackColor="#d6d6d6" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="40px" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" width="50" />
                   </asp:GridView>
                                    </div>
                                    
                                   
                                       <asp:Label ID="lblgvHospital" runat="server" cssclass="label-validation"></asp:Label>
                                   
                          </ContentTemplate>
                                     <Triggers>
                                     </Triggers>
                                     </asp:UpdatePanel>

                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
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
                                                <asp:TextBox ID="txtTAmount" runat="server" MaxLength="20" Enabled="False" class="form-control"></asp:TextBox>
                                           </div>
                                            </td>
                                            <td>
                                               <div class="form-group">
                                                <asp:TextBox ID="txtDiscount" runat="server" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged" class="form-control"></asp:TextBox>
                                           </div>
                                         
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Label ID="lblcvTAmount" runat="server" ForeColor="Red" CssClass="lable-validation"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:requiredfieldvalidator id="rvdiscount" runat="server" errormessage="Required" forecolor="red"
                                                    controltovalidate="txtDiscount" validationgroup="Submit" setfocusonerror="true" CssClass="label-validation"></asp:requiredfieldvalidator>
                                                
                                                <asp:Label ID="lblcvDiscount" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                                            
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
                                             <asp:TextBox ID="txtDiscountAmount" runat="server" Enabled="False" class="form-group" ></asp:TextBox>
                                           </div>
                                            </td>
                                            <td>
                                             <div class="form-group">
                                                 <asp:TextBox ID="txtFinalAmount" runat="server" Enabled="False"  class="form-control"></asp:TextBox>
                                           
                                    
                                           </div> 
                                            </td>
                                            </tr>
                                    </table>

                          </ContentTemplate>
                         <Triggers>

                         <asp:AsyncPostBackTrigger ControlID="txtDiscount" />
                           
                      
                         </Triggers>
                         </asp:UpdatePanel>



                            <table>
                                <tr>
                                 <%-- <td style="width:200px;">

                                  </td>
                                 --%>   <td>
                                  
                            <br />
<div class="form-inline">
<div class="form-group">

                               <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                                ValidationGroup="Submit" class="btn btn-primary">
                            <i class="icon-ok icon-white"></i>
                            Submit
                            </asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="btnReset" runat="server" OnClick="btnReset_Click"
                                 class="btn btn-primary">
                               <i class="icon-refresh"></i>
                                Reset
                                </asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                                 class="btn btn-primary">
                                  <i class="icon-ban-circle"></i>
                                 Cancel
                                 </asp:LinkButton>
                       </div></div>  
                      
                                  </td>
                                </tr>
                            </table>
                             </div>
    </div>
    </div>
   
   </div></div>

   </section>
</asp:Content>
