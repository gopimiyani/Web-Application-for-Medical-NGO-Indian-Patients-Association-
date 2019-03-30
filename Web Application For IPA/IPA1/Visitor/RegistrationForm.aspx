<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true"
    CodeBehind="RegistrationForm.aspx.cs" Inherits="IPA1.Visitor.RegistrationForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">

 .label-validation
 {
     font-size:small;
     padding-left:4px;
      color:Red;
 }
 
 .style2
{
    font-size:small;
}
 .form-group
 {
     margin-bottom:0px;
    width: 300px;
  }
  .form-inline .form-control,.form-control
  {
      width:95%;
  }
  
  
      
  .form-group-marginbottom
 {
     margin-bottom:25px;
    width: 300px;
  }
  
.form-group-margintop
{
    margin-top:25;
    width:300px;
}
 .form-group-marginleft
 {
     margin-left:57px;
    width: 300px;
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
    width:300px;
    padding-right:50px;
}



.ajax__calendar_container {padding:4px;position:absolute;cursor:default;width:210px;font-size:11px;text-align:center;font-family:tahoma,verdana,helvetica;}

.ajax__calendar_body {height:139px;width:210px;position:relative;overflow:hidden;margin:auto;}

.ajax__calendar_days, .ajax__calendar_months, .ajax__calendar_years {top:0px;left:0px;height:139px;width:170px;position:absolute;text-align:center;margin:auto;}

.ajax__calendar_container TABLE {font-size:11px;}

.ajax__calendar_header {height:20px;width:100%;}

.ajax__calendar_title {cursor:pointer;font-weight:bold;}

.ajax__calendar_footer {height:15px;}

.ajax__calendar_today {cursor:pointer;padding-top:3px;}

.ajax__calendar_dayname {height:17px;width:17px;text-align:right;padding:0 2px;}

.ajax__calendar_day {height:17px;width:18px;text-align:right;padding:0 2px;cursor:pointer;}

.ajax__calendar_month {height:44px;width:40px;text-align:center;cursor:pointer;overflow:hidden;}

.ajax__calendar_year {height:44px;width:40px;text-align:center;cursor:pointer;overflow:hidden;}

.ajax__calendar .ajax__calendar_container {border:1px solid #646464;background-color:#ffffff;color:#000000;}

.ajax__calendar .ajax__calendar_footer {border-top:1px solid #f5f5f5;}

.ajax__calendar .ajax__calendar_dayname {border-bottom:1px solid #f5f5f5;}

.ajax__calendar .ajax__calendar_day {border:1px solid #ffffff;}

.ajax__calendar .ajax__calendar_month {border:1px solid #ffffff;}

.ajax__calendar .ajax__calendar_year {border:1px solid #ffffff;}

.ajax__calendar .ajax__calendar_active .ajax__calendar_day {background-color:#edf9ff;border-color:#0066cc;color:#0066cc;}

.ajax__calendar .ajax__calendar_active .ajax__calendar_month {background-color:#edf9ff;border-color:#0066cc;color:#0066cc;}

.ajax__calendar .ajax__calendar_active .ajax__calendar_year {background-color:#edf9ff;border-color:#0066cc;color:#0066cc;}

.ajax__calendar .ajax__calendar_other .ajax__calendar_day {background-color:#ffffff;border-color:#ffffff;color:#646464;}

.ajax__calendar .ajax__calendar_other .ajax__calendar_year {background-color:#ffffff;border-color:#ffffff;color:#646464;}

.ajax__calendar .ajax__calendar_hover .ajax__calendar_day {background-color:#edf9ff;border-color:#daf2fc;color:#0066cc;}

.ajax__calendar .ajax__calendar_hover .ajax__calendar_month {background-color:#edf9ff;border-color:#daf2fc;color:#0066cc;}

.ajax__calendar .ajax__calendar_hover .ajax__calendar_year {background-color:#edf9ff;border-color:#daf2fc;color:#0066cc;}

.ajax__calendar .ajax__calendar_hover .ajax__calendar_title {color:#0066cc;}

.ajax__calendar .ajax__calendar_hover .ajax__calendar_today {color:#0066cc;}


</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PStakeholder" runat="server" Visible="true">
   
   <!-- Content ( JOIN US) -->
   
     <!--/#services start -->
        <section id="services" style="padding-top:50px;">
        <div class="container">

            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">SIGN UP AS ...</h2>
                <p class="text-center wow fadeInDown">
             
             You can join with us if you want to join as one of the below.
             Please select one of the below and fill the registration form.
                <br> <%--et dolore magna aliqua. Ut enim ad minim veniam--%>
                 
                </p>
            </div>
            
            <div class="row">
                <div class="features">
                    
                    <div class="col-md-2 col-md-4 col-xs-6 wow fadeInUp" data-wow-duration="300ms" data-wow-delay="0ms">
                        <div class="media service-box">
                  <asp:LinkButton ID="lbVolunteer" runat="server" onclick="lbVolunteer_Click">
                            <div class="pull-left">
                                <i class="fa fa-user" 
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                            </asp:LinkButton>      
                        
                        <br />
                        
                             <h4 class="media-heading" style="margin-top:90px; margin-left:10px">Volunteer</h4>
                        </div>
                    </div>
                   
                    
                      <div class="row">
                <div class="features">
                    
                    <div class="col-md-2 col-md-4 col-xs-6 wow fadeInUp" data-wow-duration="300ms" data-wow-delay="0ms">
                        <div class="media service-box">
                  <asp:LinkButton ID="lbHospital" runat="server" OnClick="lbHospital_click" >
                            <div class="pull-left">
                                <i class="fa fa-plus" 
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                            </asp:LinkButton>      
                        
                        <br />
                        
                             <h4 class="media-heading" style="margin-top:90px; margin-left:15px">Hospital</h4>
                        </div>
                    </div>
                    
                    
                      <div class="row">
                <div class="features">
                    
                    <div class="col-md-2 col-md-4 col-xs-6 wow fadeInUp" data-wow-duration="300ms" data-wow-delay="0ms">
                        <div class="media service-box">
                  <asp:LinkButton ID="lbBloodBank" runat="server" onclick="lbBloodBank_Click">
                            <div class="pull-left">
                                <i class="fa fa-tint" 
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                            </asp:LinkButton>      
                        
                        <br />
                        
                             <h4 class="media-heading" style="margin-top:90px; margin-left:5px;">Blood Bank</h4>
                        </div>
                    </div>

                      <div class="row">
                <div class="features">
                    
                    <div class="col-md-2 col-md-4 col-xs-6 wow fadeInUp" data-wow-duration="300ms" data-wow-delay="0ms">
                        <div class="media service-box">
                  <asp:LinkButton ID="lbPharmaCompany" runat="server" onclick="lbPharmaCompany_Click">
                            <div class="pull-left">
                                <i class="fa fa-bar-chart" 
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                            </asp:LinkButton>      
                        
                        <br />
                        
                             <h4 class="media-heading" style="margin-top:90px; margin-left:15px; margin-right:30px;">Pharma- Company</h4>
                        </div>
                    </div>
                    

                      <div class="row">
                <div class="features">
                    
                    <div class="col-md-2 col-md-4 col-xs-6 wow fadeInUp" data-wow-duration="300ms" data-wow-delay="0ms">
                        <div class="media service-box">
                  <asp:LinkButton ID="lbDoctor" runat="server" onclick="lbDoctor_Click">
                            <div class="pull-left">
                                <i class="fa fa-plus" 
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                            </asp:LinkButton>      
                        
                        <br />
                        
                             <h4 class="media-heading" style="margin-top:90px; margin-left:22px">Doctor</h4>
                        </div>
                    </div>

                      <div class="row">
                <div class="features">
                    
                    <div class="col-md-2 col-md-4 col-xs-6 wow fadeInUp" data-wow-duration="300ms" data-wow-delay="0ms">
                        <div class="media service-box">
                  <asp:LinkButton ID="lbDonor" runat="server" onclick="lbDonor_Click">
                            <div class="pull-left">
                                <i class="fa fa-user" 
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                            </asp:LinkButton>      
                        
                        <br />
                        
                             <h4 class="media-heading" style="margin-top:90px; margin-left:25px">Donor</h4>
                        </div>
                    </div>

                    
                </div>
            </div><!--/.row-->    
        </div><!--/.container-->
    </section>
   </asp:Panel>
    <asp:Panel ID="PRegister" runat="server" Visible="false">
    
<!-- Content (JOIN US) end -->
   
    <section id="contact">
<%--<asp:Image ID="Image1" runat="server" style="height:900px; width:1350px;" ImageUrl="../Visitor1/images/page2_img4.jpg"></asp:Image>--%>
<%--<asp:Image ID="Image1" runat="server" style="height:900px; width:1350px;" ImageUrl="../Visitor/images/testimonial/bg.jpg"></asp:Image>--%>
        <div style="height:1200px" ></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
             <div class="col-sm-4" style="margin-left:150px;">
                         <div class="contact-form" style="border: 1px solid #CCC;width:700px;">
                        
                         <h3>
               <asp:Label ID="lblRegisterYourSelf" runat="server" Text="Register Yourself"></asp:Label>  
               </h3>        
                         <p style="font-size:15px;">Note: All fields are required except those that are marked as optional. </p>
                         <br />
                         <asp:DropDownList ID="ddlselecttype" name="Select Type" class="form-control" placeholder="Select Type"  
                      runat="server" AutoPostBack="True"
                      OnSelectedIndexChanged="ddlselecttype_SelectedIndexChanged"
                      ValidationGroup="Submit" OnTextChanged="ddlselecttype_TextChanged" visible="false"
                      >
                        </asp:DropDownList>
                        
                
      <table>
<tr>

              
             
                   <td>
                       <div class="form-group">
                        <div class="form-inline">
                           <asp:TextBox ID="txtFirstName" runat="server" class="form-control" 
                               MaxLength="20" placeholder="First Name" ValidationGroup="Submit"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvfirstname" runat="server" 
                      controltovalidate="txtFirstName" CssClass="label-validation" 
                      errormessage="*" forecolor="red" validationgroup="Submit"></asp:RequiredFieldValidator>
                      </div>
                       </div>
                   </td>
                   <td>
                       <div class="form-group">
                           <asp:TextBox ID="txtLastName" runat="server" class="form-control" 
                               MaxLength="20" placeholder="Last Name(Optional)" ValidationGroup="Submit"></asp:TextBox>
                       </div>
                   </td>
                   </tr>
          <tr>
              <td>
                 
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                      ControlToValidate="txtFirstName" CssClass="label-validation" 
                      ErrorMessage="Alphabates Only" ForeColor="Red" 
                      ValidationExpression="[a-z A-Z]+" ValidationGroup="Submit"></asp:RegularExpressionValidator>
              </td>
              <td>
                  <asp:RegularExpressionValidator ID="reLastName" runat="server" 
                      ControlToValidate="txtLastName" CssClass="label-validation" 
                      ErrorMessage="Alphabates Only" ForeColor="Red" 
                      ValidationExpression="[a-z A-Z]*" ValidationGroup="Submit"></asp:RegularExpressionValidator>
              </td>
          </tr>
          <tr>
              <td>
                  <div class="form-group">
                   <div class="form-inline">
                      <asp:TextBox ID="txtUserName" runat="server" AutoPostBack="True" 
                          class="form-control" MaxLength="20" OnTextChanged="txtUserName_TextChanged" 
                          placeholder="User Name" ValidationGroup="Submit"></asp:TextBox>

                           <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                      ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="Red" 
                      ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                      </div>
            
                  </div>
              </td>
              <td>
                  <div class="form-group">
                  <div class="form-inline">
                      <asp:TextBox ID="txtEmail" runat="server" class="form-control" MaxLength="40" 
                          placeholder="Email" ValidationGroup="Submit"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                      ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" 
                      ValidationGroup="Submit" CssClass="label-validation" ></asp:RequiredFieldValidator>
                </div>
                  </div>
              </td>
          </tr>
          <tr>
              <td>
                 
                  <asp:Label ID="lblcvUserName" runat="server" CssClass="label-validation" 
                      ForeColor="Red" Text="" Visible="False"></asp:Label>
              </td>
              <td>
                  <asp:RegularExpressionValidator ID="reEmail" runat="server" 
                      ControlToValidate="txtEmail" CssClass="label-validation" 
                      ErrorMessage="Invalid Email  Address" ForeColor="Red" 
                      ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                      ValidationGroup="Submit"></asp:RegularExpressionValidator>

                       <asp:Label ID="lblcvEmail" runat="server" CssClass="label-validation" 
                      ForeColor="Red" Text=""></asp:Label>
              </td>
          </tr>
          <tr>
              <td>
                  <div class="form-group">
                  <div class="form-inline">
                      <asp:TextBox ID="txtPassword" runat="server" class="form-control" 
                          MaxLength="30" placeholder="Password" TextMode="Password" 
                          ValidationGroup="Submit"></asp:TextBox>

                              <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
              ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red" 
              ValidationGroup="Submit" CssClass="label-validation" ></asp:RequiredFieldValidator>
      

                          </div>
                  </div>
              </td>
              <td>
                  <div class="form-group">
                  <div class="form-inline">
                      <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control" 
                          MaxLength="30" placeholder="Reenter Password" TextMode="Password" 
                          ValidationGroup="Submit"></asp:TextBox>

                              <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" 
                      ControlToValidate="txtConfirmPassword" ErrorMessage="*" ForeColor="Red" 
                      ValidationGroup="Submit" CssClass="label-validation" ></asp:RequiredFieldValidator>
              

                          </div>
                  </div>
              </td>
          </tr>
          <tr>
          <td>
              
                  <asp:RegularExpressionValidator ID="rePassword" runat="server" 
                      ControlToValidate="txtPassword" CssClass="label-validation" 
                      ErrorMessage="Password should be min of 8 characters at least 1 Alphabet and 1 Number" 
                      ForeColor="Red" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" 
                      ValidationGroup="Submit"></asp:RegularExpressionValidator>
              </td>
              <td>
                  <asp:CompareValidator ID="comConfirmPassword" runat="server" 
                      ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                      CssClass="label-validation" ErrorMessage="This Password does not match." 
                      ForeColor="Red" ValidationGroup="Submit"></asp:CompareValidator>
              </td>
          </tr>
          <tr>
              <td>
                  <div class="form-group-marginbottom">
                   <div class="form-inline">
                      <asp:TextBox ID="txtAddress" runat="server" class="form-control" 
                          MaxLength="100" placeholder="Address" Rows="4" TextMode="MultiLine" 
                          ValidationGroup="Submit"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                      ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red" 
                      ValidationGroup="Submit" CssClass="label-validation" ></asp:RequiredFieldValidator>
              </div>
                  </div>
              </td>
              <td>
                  <div class="form-group" style="margin-bottom:15px;">
                      <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" 
                          class="form-control" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" 
                          placeholder="State">
                      </asp:DropDownList>
                  </div>
                  <br />
                  <div class="form-group" style="margin-bottom:20px;">
                      <asp:DropDownList ID="ddlCity" runat="server" class="form-control" 
                          placeholder="City">
                      </asp:DropDownList>
                  </div>
              </td>
          </tr>
         
          <tr>
              <td>
                  <asp:RequiredFieldValidator ID="rfvState" runat="server" 
                      ControlToValidate="ddlState" ErrorMessage="Required" ForeColor="Red" 
                      ValidationGroup="Submit" CssClass="label-validation" ></asp:RequiredFieldValidator>
              </td>
              <td>
                  <asp:RequiredFieldValidator ID="rfvCity" runat="server" 
                      ControlToValidate="ddlCity" ErrorMessage="Required" ForeColor="Red" 
                      ValidationGroup="Submit" CssClass="label-validation" ></asp:RequiredFieldValidator>
              </td>
          </tr>
          <tr>
              <td>
                  <div class="form-group">
                   <div class="form-inline">
                      <asp:TextBox ID="txtPinCode" runat="server" class="form-control" 
                          placeholder="PinCode" ValidationGroup="Submit"></asp:TextBox>

                           <asp:RequiredFieldValidator ID="rfvPincode" runat="server" 
                      ControlToValidate="txtPinCode" ErrorMessage="*" ForeColor="Red" 
                      ValidationGroup="Submit" CssClass="label-validation" ></asp:RequiredFieldValidator>
                 
                  </div>
                  </div>
              </td>
              <td>
                  <div class="form-group">
                   <div class="form-inline">
                      <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" 
                          placeholder="Mobile No"></asp:TextBox>

                               <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" 
                      ControlToValidate="txtMobileNo" ErrorMessage="*" ForeColor="Red" 
                      ValidationGroup="Submit" CssClass="label-validation" ></asp:RequiredFieldValidator>
             
                 </div>
                  </div>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:RegularExpressionValidator ID="rePinCode" runat="server" 
                      ControlToValidate="txtPinCode" CssClass="label-validation" 
                      ErrorMessage="PinCode must be in 6 digit" ForeColor="Red" 
                      ValidationExpression="(\d{6})" ValidationGroup="Submit"></asp:RegularExpressionValidator>
              </td>
              <td>
                  <asp:RangeValidator ID="rvMobileNo" runat="server" 
                      ControlToValidate="txtMobileNo" CssClass="label-validation" 
                      ErrorMessage="Enter Valid Mobile No" ForeColor="Red" MaximumValue="9999999999" 
                      MinimumValue="70000000000" ValidationGroup="Submit"></asp:RangeValidator>
              </td>
          </tr>
          <tr>
              <td>
                  <div class="form-group">
                      <asp:Label ID="lblProfilePic" runat="server" Text="Upload Your ProfilePic(Optional)"></asp:Label>
                  </div>
              </td>
              <td>
              </td>
          </tr>
          <tr>
              <td>
                  <div class="form-group">
                      <asp:FileUpload ID="fuProfilePic" runat="server" class="form-control" 
                          placeholder="Profile Picture" />
                  </div>
              </td>
              <td>
              </td>
          </tr>
          <tr>
              <td>
                  <asp:Label ID="lblProfilePicture" runat="server" CssClass="label-validation" 
                      ForeColor="Red"></asp:Label>
              </td>
              <td>
              </td>
          </tr>
        
                        </table>

               
                   <asp:Multiview ID="MvRegister" runat="server" ActiveViewIndex="0">               
                <asp:View ID="Volunteer" runat="server">
                <table>
                <tr>
                <td>
          <div class="form-group">
           <asp:Label ID="VlblIdProof" runat="server" Text="Upload Your IdProof"></asp:Label>
                                <%--<span class="style2">*</span>--%>
                                </div>
                                </td>
                                <td>
                                 <div class="form-group">
                              <asp:Label ID="VlblBloodGroup" runat="server" Text="BloodGroup" >Blood Group</asp:Label>
                              <%--  <span class="style2">*</span>--%>
                                </div>
                            
                                </td>
                            
                              
                                </tr>
             
              <tr>
                         <td>
                          <div class="form-group" style="padding-bottom:0px;">  
                            
                                <asp:FileUpload ID="VfuIdProof" runat="server"  class="form-control" placeholder="ID Proof" />
                               </div>
                               </td>
                               <td>
                                 <div class="form-group">
                                 <asp:DropDownList ID="VddlBloodGroup" runat="server" Width="" class="form-control" placeholder="Blood Group"  >
                                    <asp:ListItem>A+</asp:ListItem>
                                    <asp:ListItem>B+</asp:ListItem>
                                    <asp:ListItem>A-</asp:ListItem>
                                    <asp:ListItem>B-</asp:ListItem>
                                    <asp:ListItem>AB+</asp:ListItem>
                                    <asp:ListItem>AB-</asp:ListItem>
                                    <asp:ListItem>O+</asp:ListItem>
                                    <asp:ListItem>O-</asp:ListItem>
                                </asp:DropDownList>
                               </div>
                               </td>
                               </tr>
             
                               <tr>
                            
                               <td>

                                <asp:Label ID="VlblcvIdProof" runat="server" Text="" CssClass="label-validation" 
                                ForeColor="Red"></asp:Label>

                               </td>
                               <asp:RequiredFieldValidator ID="VrfvBloodGroup" runat="server" ValidationGroup="Submit"
                                    ControlToValidate="VddlBloodGroup" ErrorMessage="*" ForeColor="Red" CssClass="label-validation" ></asp:RequiredFieldValidator>
                           
                               </tr>
                               
                            
                              <tr>
                         
                                <td>
                                <div class="form-group">
                                     <asp:Label ID="VlblBirthDate" runat="server"  Text="BirthDate">Birth Date</asp:Label>
                                <span class="style2">(Age must be 20)</span>
                                     </div>
                         
                                </td>
                                </tr>
             
             <tr>
                       <td>
                                 <div class="form-group">
                                 <div class="form-inline">
<asp:TextBox ID="VtxtDOB" runat="server"  ValidationGroup="Submit" 
                                          class="form-control" placeholder="Birth Date"></asp:TextBox>
                                      <%--<asp:TextBox ID="VtxtDOB" runat="server"  ValidationGroup="Submit" 
                                          class="form-control" placeholder="Birth Date" ReadOnly="True"></asp:TextBox>--%>
                                <cc:CalendarExtender ID="CalendarExtender_VBirthDate" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                    TargetControlID="VtxtDOB" SelectedDate="12-12-1975"></cc:CalendarExtender>
                                         <asp:RequiredFieldValidator ID="VrfvDOB" runat="server" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="Submit" ControlToValidate="VtxtDOB" CssClass="label-validation" ></asp:RequiredFieldValidator>
                               
                                    </div>
                                    </div>

                               </td>
                               
                               </tr>
                              
                              
                     </table>        
                               </asp:View>
                <asp:View ID="Donor" runat="server">
                <table>
              <tr>
              <td>
                              <div class="form-group">
                                 <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup"></asp:Label>
                               <%-- <span class="style2">*</span>--%>
                                </div>
                               </td>
                              
                               <td>
                                <div class="form-group">
                                 <asp:Label ID="lblBirthDate" runat="server" Text="BirthDate"></asp:Label>
                              <%--  <span class="style2" >*</span>--%>
                                    <span class="style2">(Age must be 18)</span></div>
                               </td>
                              
                               </tr>
                               <tr>
                               <td>
                                 <asp:DropDownList ID="DddlBloodGroup" runat="server" 
                                    ValidationGroup="Submit"  class="form-control" placeholder="Blood Group" >
                                    <asp:ListItem>A+</asp:ListItem>
                                    <asp:ListItem>A-</asp:ListItem>
                                    <asp:ListItem>B+</asp:ListItem>
                                    <asp:ListItem>B-</asp:ListItem>
                                    <asp:ListItem>AB+</asp:ListItem>
                                    <asp:ListItem>AB-</asp:ListItem>
                                    <asp:ListItem>O+</asp:ListItem>
                                    <asp:ListItem>O-</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                <td>
                                 <div class="form-group">
                                 <div class="form-inline">
                                  <asp:TextBox ID="DtxtDOB" runat="server" class="form-control" 
                                         placeholder="Birth Date"></asp:TextBox>
                                <cc:CalendarExtender ID="CalendarExtender_DonorBirthDate" runat="server" Format="dd-MM-yyyy" TargetControlID="DtxtDOB"
                                    SelectedDate="12-12-1975"></cc:CalendarExtender>
                                         <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="Submit" ControlToValidate="DtxtDOB" CssClass="label-validation"></asp:RequiredFieldValidator>
                           
                                    </div>
                             </div>
                                </td>
                                </tr>
                               
                             </table>
                                  </asp:View>
                <asp:View ID="Hospital" runat="server">
          <table>
          <tr>
          <td>
          
                              <div class="form-group">
                                <asp:Label ID="HlblIdProof" runat="server" Text="IdProof"></asp:Label>
                                <span class="style63">(Upload Your Licence)</span><%--<span class="style2">*</span>--%></div>
                               </td>
                               <td>
                                 <div class="form-group">
                                  <asp:Label runat="server" Text="Website Name" ID="HlblWebsite"></asp:Label>
                               
                               (e.g. www.google.com)
                           </div>
                               </td>
                               </tr>

                               <tr>
                               <td>
                               <div class="form-group">
                                <asp:FileUpload ID="HfuIdProof" runat="server" class="form-control" placeholder="Upload Licence"   />
                             </div>
                             </td>
                               <td>
                               <div class="form-group">
                                 <asp:TextBox ID="HtxtWebsite" runat="server"  MaxLength="50" ValidationGroup="Submit" class="form-control" placeholder="Web site(Optional)"  ></asp:TextBox>
                             </div>
                              </td>
                              </tr>

                              <tr>
                              <td>
                              <div class="form-group">
                                <asp:Label ID="lblcvHfuIdProof" runat="server" Text="" CssClass="label-validation" ForeColor="Red"></asp:Label>
                               
                               </div></td>
                               <td>
                               </td>
                                </tr>
                              
                                <tr>
                                 <td>
                                 <br />
                                 <div class="form-group">
                                 <div class="form-inline">
                                <asp:TextBox ID="HtxtContactPerson" runat="server"  MaxLength="20" ValidationGroup="Submit" class="form-control" placeholder="Contact person Name" ></asp:TextBox>
                               <asp:RequiredFieldValidator ID="HrfvContactPerson" runat="server" ErrorMessage="*"
                                    ForeColor="Red" ValidationGroup="Submit" ControlToValidate="HtxtContactPerson" CssClass="label-validation"></asp:RequiredFieldValidator>
                                
                            </div>
                             </div>
                              </td>
                            </tr>
                            
                            <tr>
                          <td>
                                <asp:RegularExpressionValidator ID="HreContactPerson" runat="server" ControlToValidate="HtxtContactPerson"
                                    ErrorMessage="Alphabates Only" ValidationExpression="[ a-zA-Z]+" ValidationGroup="Submit"
                                    ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                             
                               </td>
                             
                    </tr>
                               </table>
                              
                              
                               
                              
                              </asp:View>

                                 <asp:View ID="BloodBank" runat="server">
                                 <table>
                                 <tr>
                                 <td>

                                 <div class="form-group">
                                 <asp:Label ID="BlblIdProof" runat="server" Text="IdProof"></asp:Label>
                                <span class="style63">(Upload Your Licence)</span><%--<span class="style2">*</span>--%></div>
                             </td>
                             <td>
                                
                                 <div class="form-group">
                                  <asp:Label runat="server" Text="Website Name" ID="BlblWebsite"></asp:Label>
                               
                               (e.g. www.google.com)
                             </div>
                             </td>
                             </tr>
                             <tr>
                             <td>
                                <asp:FileUpload ID="BfuIdProof" runat="server"  class="form-control" placeholder="Upload Licence"   />
                               </td>
                               <td>
                               <div class="form-group">
                                  <asp:TextBox ID="BtxtWebsite" runat="server" MaxLength="50" ValidationGroup="Submit"  class="form-control" placeholder="Web site(Optional)" ></asp:TextBox>
                              </div>
                               </td>
                               </tr>
                               <tr>
                               <td>
                                <asp:Label ID="lblcvBIdProof" runat="server" Text="" CssClass="label-validation" ForeColor="Red"></asp:Label>
                           </td>
                         
                           <td>
                             <asp:RegularExpressionValidator ID="BreWebsite" runat="server" ControlToValidate="BtxtWebsite"
                                    ErrorMessage="Invalid Url Format" ValidationExpression="^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$"
                                    ValidationGroup="Submit" ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                           </td>
                           </tr>
                          
                         
                                     <caption>
                                         <br />
                                         <tr>
                                             <td>
                                                 <div class="form-group">
                                                 <div class="form-inline">
                                                     <asp:TextBox ID="BtxtContactPerson" runat="server" class="form-control" 
                                                         MaxLength="20" placeholder="Contact Person Name" 
                                                         ValidationGroup="Submit"></asp:TextBox>

                                                                           <asp:RequiredFieldValidator ID="BrfvContactPerson" runat="server" ErrorMessage="*"
                                    ForeColor="Red" ValidationGroup="Submit" ControlToValidate="BtxtContactPerson" CssClass="label-validation"></asp:RequiredFieldValidator>
                            
                                                 </div>
                                                 </div>
                                             </td>
                                         </tr>
                                     </caption>
                                     
                                     <tr>
                                         <td>
                            
                                             <asp:RegularExpressionValidator ID="BreContactPerson" runat="server" 
                                                 ControlToValidate="BtxtContactPerson" ErrorMessage="Alphabates Only" 
                                                 ForeColor="Red" CssClass="label-validation" ValidationExpression="[ a-zA-Z]+" ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                         </td>
                                     </tr>
                        </table>      
                          
                          
                  </asp:View>                  
                             
             </div>
      
                <asp:View ID="PharmaCompany" runat="server">
                             <table>
                             <tr>
                             <td>

                                <div class="form-group">
                                 <asp:Label ID="PlblIdProof" runat="server" Text="IdProof"></asp:Label>
                                <span class="style63">(Upload Your Licence)</span><%--<span class="style2">*</span>--%></div>
                             </td>
                              <td>
                             
                                 <div class="form-group">
                                  <asp:Label runat="server" Text="Website" ID="plblWebsite"></asp:Label>
                               

                                     &nbsp;Name(e.g. www.google.com)
                       </div>

                             </td>
                             </tr>
                             <tr>
                             <td>
                             <div class="form-group">
                                <asp:FileUpload ID="PfuIdProof" runat="server"  class="form-control" placeholder="Upload Licence" />
                              </div>
                               </td>
                               <td>
                                <div class="form-group">
                                <asp:TextBox ID="PtxtWebsite" runat="server" MaxLength="50" ValidationGroup="Submit" class="form-control" placeholder="Website(Optional)" ></asp:TextBox>
                                </div>
                               </td>
                               </tr>
                               <tr>
                               <td>
                                <asp:Label ID="lblcvPfuIdProof" runat="server"  CssClass="label-validation" Text="" ForeColor="Red"></asp:Label>
                         </td>
                           <td>
                           <div class="form-group">
                         <asp:RegularExpressionValidator ID="PreWebsite" runat="server" ControlToValidate="PtxtWebsite"
                                    ErrorMessage="Invalid Url Format" ValidationExpression="^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$"
                                    ValidationGroup="Submit" ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                           </div>
                         </td>
                         </tr>
                         <tr>
                              <td>
                                 <div class="form-group">
                                 <div class="form-inline">

                                <asp:TextBox ID="PtxtContactPerson" runat="server" MaxLength="20" ValidationGroup="Submit" class="form-control" placeholder="Contact Person" ></asp:TextBox>
                           <asp:RequiredFieldValidator ID="PrfvContactPerson" runat="server" ErrorMessage="*"
                                    ForeColor="Red" ValidationGroup="Submit" ControlToValidate="PtxtContactPerson" CssClass="label-validation"></asp:RequiredFieldValidator>
                        </div>
                        </div>
                               </td>
                          
                         </tr>
                        <tr>
                           <td>
                                <asp:RegularExpressionValidator ID="PreContactPerson" runat="server" ControlToValidate="PtxtContactPerson"
                                    ErrorMessage="Alphabates Only" ValidationExpression="[ a-zA-Z]+" ValidationGroup="Submit"
                                    ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                         </td>
                    
                        </tr>
                              
                       </table>
                </asp:View>
             <asp:View ID="Doctor" runat="server">
             <table>
             <tr>
             <td>

                               </td>
                               <td>
                                 <div class="form-group">
                                <asp:Label ID="DolblIdProof" runat="server" Text="IdProof"></asp:Label>
                                <span class="style63">(Upload Your Degree Certificate)</span><%--<span class="style2">*</span>--%></div>
                   
                               </td>
                               </tr>
                               <tr>
                               <td>
                                <div class="form-group">
                               <div class="form-inline">
                               
                                <asp:TextBox ID="DotxtDegree" runat="server"  MaxLength="20" ValidationGroup="Submit" class="form-control" placeholder="Degree" ></asp:TextBox>
                           <asp:RequiredFieldValidator ID="DorfvDegree" runat="server" ErrorMessage="*" ValidationGroup="Submit"
                                    ForeColor="Red" ControlToValidate="DotxtDegree" CssClass="label-validation"></asp:RequiredFieldValidator>
                             </div>
                       </div>
                           
                              
                           </td>
                           <td>
                            <div class="form-group">
                                <asp:FileUpload ID="DfuIdProof" runat="server" class="form-control" placeholder="Upload your Degree Certificate" />
                           </div>
                            </td>
                           </tr>
                           <tr>
                           <td>
                                <asp:RegularExpressionValidator ID="DoreDegree" runat="server" ControlToValidate="DotxtDegree"
                                    ErrorMessage="Alphabates Only" ValidationExpression="[a-zA-Z.]+" ValidationGroup="Submit"
                                    ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                    
                           </td>
                           <td>
                                <asp:Label ID="lblcvDfuIdProof" runat="server" CssClass="label-validation" Text="" ForeColor="Red"></asp:Label>
                       </td>
                       <td>
                       </td>
                      
                       </tr>
                       <tr>
                       <td>
                       </td>
                    </tr>
                    <tr>
                          <td>
                            <div class="form-group">
                                <asp:TextBox ID="DotxtDisease" runat="server" MaxLength="20" ValidationGroup="Submit" class="form-control" placeholder="Specialist In(Optional)" ></asp:TextBox>
                       </div>
                           </td>
                     
                     <td>
                     <div class="form-group">
                           <asp:RegularExpressionValidator ID="DoreDisease" runat="server" ControlToValidate="DotxtDisease"
                                    ErrorMessage="Alphabates Only" ValidationExpression="[a-zA-Z]+" ValidationGroup="Submit"
                                    ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                          </div>
                       </td>
                    
                    </tr>         
                              
                          </table> 
                          
                </asp:View>
                
                  <asp:View ID="NGO" runat="server">
                             <table>
                             <tr>
                             <td>
                              
                              <div class="form-group">  
                                  <asp:Label runat="server" Text="Website" ID="NlblWebsite"></asp:Label>
                             
                                  &nbsp;Name(e.g. www.google.com)
                               </div>
                                </td>
                                <td></td>
                             
                                </tr>
                                <tr>
                                <td>
                             <div class="form-group">   
                                <asp:TextBox ID="NtxtWebsite" runat="server"  MaxLength="50" ValidationGroup="Submit" class="form-control" placeholder="Website(Optional)"></asp:TextBox>
                             </div>
                             </td>
                             <td>
                              <div class="form-group">
                                <asp:TextBox ID="NtxtPurpose" runat="server"  MaxLength="100" ValidationGroup="Submit" class="form-control" placeholder="Purpose(Optional)"></asp:TextBox>
                             </div>
                             </td>
                             </tr>
                             <tr>
                             <td>
                             <div class="form-group">
                              <asp:RegularExpressionValidator ID="NreWebsite" runat="server" ControlToValidate="NtxtWebsite"
                                    ErrorMessage="Invalid Url Format" ValidationExpression="^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$"
                                    ValidationGroup="Submit" ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                           </div>
                               </td>
                               <td>
                               <div class="form-group">
                                 <asp:RegularExpressionValidator ID="NrePurpose" runat="server" ControlToValidate="NtxtPurpose"
                                    ErrorMessage="Alphabates Only" ValidationExpression="[a-zA-Z]+" ValidationGroup="Submit"
                                    ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                         </div>
                               </td>
                               </tr>
                           <tr>
                           
                             <td>
                             <div class="form-group">
                              
                                <asp:TextBox ID="NtxtMission" runat="server" MaxLength="50" class="form-control" placeholder="Mission(Optional)" ></asp:TextBox>
                               </div>
                         
                             </td>
                           
                         
                           </tr> 
                           <tr>  <td>
                           <div class="form-group">
                                   <asp:RegularExpressionValidator ID="NreMission" runat="server" ControlToValidate="NtxtMission"
                                    ErrorMessage="Alphabates Only" ValidationExpression="[a-zA-Z]+" ValidationGroup="Submit"
                                    ForeColor="Red" CssClass="label-validation"></asp:RegularExpressionValidator>
                         </div>
                               </td>
                             
                           </tr>  
                         </table>
                </asp:View>
                 <asp:View ID="Media" runat="server">

                </asp:View>
                 
    </asp:MultiView>
                                         
                            <br />
                                 <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" ValidationGroup="Submit"
                    OnClick="btnSubmit_Click" /> 
                &nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnReset_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />
                            
                           
                            <%--</form>--%>
                      
  
                 
                   
    </section>
    
    </asp:Panel>
    </div>
    
    
    </div>
    
    
    </div>
    
    
</asp:Content>
