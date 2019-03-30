<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true"
    CodeBehind="RequestFormUser.aspx.cs" Inherits="IPA1.User.RequestFormUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style3
        {
            font-size: small;
        }
        
        .label-validation
        {
            padding-left: 4px;
            font-size: small;
            color: Red;
        }
        
        .form-group
        {
            margin-bottom: 0px;
            width: 300px;
        }
        
        input[type="checkbox"]
        {
            margin-right: 8px;
        }
        .form-group-marginbottom
        {
            margin-bottom: 25px;
            width: 300px;
        }
        
        .form-group-marginleft
        {
            margin-left: 57px;
            width: 300px;
        }
        #contact .container-wrapper
        {
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
            width: 300px;
            padding-right: 50px;
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="contact">
        <div  style="height:1200px" ></div>
        <div class="container-wrapper">
         <br />
    <br />
   
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:150px;">
                          <div class="contact-form" 
                              style="border: 1px solid #CCC;width:700px;padding-bottom:50px; margin-left: 40px;">
                          <h3>Patient Request Form</h3>

                        
                        
        <div style="font-size:large; padding-left:8px;" >
            Do you have Transaction_ID for the Request that is still pending?
        <br />
        
        
        
<asp:RadioButton ID="rbYes" runat="server" Text=" &nbsp;&nbsp;Yes" 
                oncheckedchanged="rbYes_CheckedChanged" GroupName="Radio" 
                AutoPostBack="True" Font-Size="Large"> </asp:RadioButton>&nbsp;&nbsp;
<asp:RadioButton ID="rbNo" runat="server" Text="&nbsp;&nbsp;No" oncheckedchanged="rbNo_CheckedChanged" 
                GroupName="radio" AutoPostBack="True" Font-Size="Large"></asp:RadioButton>
         
        
        </div>


        
        <asp:Panel ID="pnlVisitor" runat="server">
        <div style="margin-left: 30px; font-weight: normal; font-size: 11pt;
                font-family: Verdana">
           <div  style="font-size:15px;text-align:justify;">
                              <u>Note</u> 

                             : If you are not able to fill the below form by yourself
                    then you can contact any of the 
                     <a href="SearchServiceProvider.aspx" style="color:Blue;"><u>
                     Available Service Providers of IPA
                     </u></a> and 
                    can send the request through them.
                    <br />
                              - All fields are required except those that are marked as optional.
                           
                           
                           
                             <%--  <div style="margin-left:40px;">
                               <p>
                                2. Click on View button to view the details of services provided by you. 
                               </p> </div>--%>
                            </div>
            
            </div>
            <br />
           
            <table>
            <tr>
            <td>
           
            <div class="form-group">


                         <asp:TextBox ID="txtName" runat="server" MaxLength="30" class="form-control" placeholder="Patient Name" ></asp:TextBox>
                      
                      </div>
                      </td>
                      <td>
                        <div class="form-group">
               <asp:TextBox ID="txtSubject" runat="server" MaxLength="50" class="form-control" placeholder="Request Subject"></asp:TextBox>
                    
             </div>
          
                      </td>
                      </tr>
                      <tr>
                      <td>

                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                      
                   
                       <asp:RegularExpressionValidator ID="reName" runat="server" ControlToValidate="txtName"
                            ErrorMessage="Alphabates Only" ForeColor="Red" ValidationExpression="[a-z A-Z]+"
                            ValidationGroup="Submit" CssClass="label-validation"></asp:RegularExpressionValidator>
                 
                   </td>
                   <td>
                   <div class="form-group">
                      <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                 
                 </div>
                   </td>
                   </tr>
           
           <tr>
           <td>
    <br />
            <div class="form-group">

                <asp:TextBox ID="txtDescr" runat="server"  MaxLength="100" TextMode="MultiLine"
                            class="form-control" placeholder="Request Detail (Provide the details about what kind of medical help or treatment you required and the approximate expenditure for the same)"
                             Rows="5">
                            </asp:TextBox>
                      </div>
               </td>       
                 <td> 
                 <br />
                 <div class="form-group">
             <asp:TextBox ID="txtAddress" runat="server" MaxLength="100" TextMode="MultiLine" 
             class="form-control" placeholder="Address"  Rows="5"></asp:TextBox>
           </div>   
            </td>
            </tr>
            <tr>
            <td>
            <div class="form-group">
               <asp:RequiredFieldValidator ID="rfvDescr" runat="server" ControlToValidate="txtDescr"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                    </div>
                    </td>
           <td>
                     <div class="form-group">
                         <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
              </div>
            
              </td> 
              </tr> 
            
   <tr>
   <td>
   <br />
            <div class="form-group">

              <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" class="form-control" placeholder="Mobile No"></asp:TextBox>
                     </div>
                      </td>
                      <td>
                      <br />
                        <div class="form-group">
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                </div>
                      </td>
                      </tr>
                      <tr>
                      <td>
                      
                        <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                     
                        <asp:RangeValidator ID="rvMobileNo" runat="server" ValidationGroup="Submit" MaximumValue="9999999999"
                            MinimumValue="70000000000" ErrorMessage="Enter Valid Mobile No" ControlToValidate="txtMobileNo"
                            ForeColor="Red" CssClass="label-validation"></asp:RangeValidator>
                        </td>
                     <td>
                     <div class="form-group">
                      <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                     
                       <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Invalid Email  Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="Submit" CssClass="label-validation"></asp:RegularExpressionValidator>
                 </div>
                     </td>
                        </tr>
                           
                      
                 <tr>
                 <td>
                 <br />
                  <div class="form-group">
               
                        <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" 
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" class="form-control" placeholder="State">
                            <asp:ListItem>Gujarat</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        </td>
                        <td>
                        <br />
                         <div class="form-group">
               
                        <asp:DropDownList ID="ddlCity" runat="server" class="form-control" placeholder="City">
                            <asp:ListItem>Surat</asp:ListItem>
                        </asp:DropDownList>
                     </div>
                        </td>
                        </tr>
                        <tr>
                        <td>
                       <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                  </td>
                  <td>
                     <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                  </td>
                    
                     
                    </tr>
                     <tr>
                     <td>
                  
                     
                       
  </td>
  <td>
  
  <div class="form-group">
    <%-- <asp:Label ID="lblIdProof" runat="server" Text="IdProof"></asp:Label>--%>
                        
                      
                        <div >
                      IdProof 
                      <span class="style3">(e.g. Licence,Election Card or Any)</span> 
               
                        </div>
                        </div>
  </td>
 
 
  </tr>
  <tr>
  <td>
  
   <div class="form-group">
                       <asp:TextBox ID="txtPinCode" runat="server" MaxLength="6" class="form-control" placeholder="Pincode"></asp:TextBox>
                </div>
                </td> 
  <td>
   <div class="form-group">
                                          <asp:FileUpload ID="fuIdProof" runat="server" />
                    
                     </div>
  
  </td>
 
  </tr>
  <tr>
  <td>
        <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                      
                       <asp:RegularExpressionValidator ID="rePinCode" runat="server" ControlToValidate="txtPinCode"
                            ErrorMessage="Invalid Pincode" ForeColor="Red" ValidationExpression="(\d{6})"
                            ValidationGroup="Submit" CssClass="label-validation"></asp:RegularExpressionValidator>
                               
  </td>
  <td>
  <br />
  <div class="form-group">
      <asp:Label ID="lblcvIdProof" runat="server" ForeColor="Red" CssClass="label-validation" ></asp:Label>
      </div>
  </td>
  </tr>
  <tr>
  <td>
  
                      <div class="form-group">
                        
                         <asp:Label ID="lblDocument1" runat="server" Text="Disease Related Document 1 "></asp:Label>
            
                      </div>
                      </td>
                      <td>
                      
                       <div class="form-group">
             <asp:Label ID="lblDocument2" runat="server" Text="Disease Related Document 2(Optional)" ></asp:Label>
                       


             </div>
          
                      </td>
                      </tr>
                      <tr>
                      <td>
                       <div class="form-group">
                 
                                <asp:FileUpload ID="fuDocument1" runat="server" />
                            
                 </div>
                      </td>
                      <td>
                       <div class="form-group">
      <asp:FileUpload ID="fuDocument2" runat="server" />
           </div>
                      </td>
                      </tr>
                      <tr>
                      <td>
                                                      
                            <asp:Label ID="lblcvDocument1" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                      </td>
                      <td>
                    <%--  <div class="form-group">
                        <asp:Label ID="lblcvDocument2" runat="server"></asp:Label>
                     </div>
                    --%>
                          <asp:Label ID="lblcvDocument2" runat="server" CssClass="label-validation" 
                              ForeColor="Red"></asp:Label>
                    </td>
                      </tr>
                    
         </table>
            <table> 
            <tr>
            <td style="width:200px;">  
            </td>
            
            
            <td>
            <br />           
            <div class="form-group">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" OnClick="btnSubmit_Click"
                            Text="Submit" ValidationGroup="Submit"  />
                        &nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary" OnClick="btnReset_Click"
                            Text="Reset" />
                        &nbsp;<asp:Button ID="btnCancle" runat="server" CssClass="btn btn-primary" OnClick="btnCancle_Click"
                            Text="Cancel" />
                  
            </div>
            </td>
            </tr>
          </table>
     </asp:Panel>
<asp:Panel ID="pnlTransactionID" runat="server">
<table class="">

                                                <tr>
                                                    <td style="width:220px;">
                                                        <asp:Label ID="lblTransactionID" runat="server" Text="Request Transaction_ID"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTransactionID" runat="server"></asp:TextBox>
                                                        
                                                    </td>
                                                    
                                                </tr>
                                              </table>
                                              <table>
                                               <tr>
                                               <td style="width:220px;">
                                               </td>
                                               <td style="padding-top: 25px;"> <asp:Button ID="btnGetInformation" style="width:200px" runat="server" CssClass="btn btn-primary" OnClick="btnGetInformation_Click"
                                                            Text="Get Request Detail" /></td>
                                               
                                               </tr>  

                                                </table>
                                                </asp:Panel>
                                                <br />
<asp:Panel ID="PnlRequestDetail" runat="server">
<div style="font-size:15px; color:Black;" >
          <u>Note:</u> &nbsp; Click on Browse button to update relevant Document.<br /> 
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - All fields are required except those that are marked as optional.<br /> <br />
      </div>
 <table>
            <tr>
            <td>
           
            <div class="form-group">


                         <asp:TextBox ID="vtxtName" runat="server" MaxLength="20" class="form-control" placeholder="Patient Name"></asp:TextBox>
                      
                      </div>
                      </td>
                      <td>
                        <div class="form-group">
               <asp:TextBox ID="vtxtSubject" runat="server" MaxLength="50" class="form-control" placeholder="Request Subject"></asp:TextBox>
                    
             </div>
          
                      </td>
                      </tr>
                      <tr>
                      <td>

                        <asp:RequiredFieldValidator ID="rfvName1" runat="server" ControlToValidate="vtxtName"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                      
                   
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="vtxtName"
                            ErrorMessage="Alphabates Only" ForeColor="Red" ValidationExpression="[a-z A-Z]+"
                            ValidationGroup="Submit" CssClass="label-validation"></asp:RegularExpressionValidator>
                 
                   </td>
                   <td>
                   <div class="form-group">
                      <asp:RequiredFieldValidator ID="rfvSubject1" runat="server" ControlToValidate="vtxtSubject"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                 
                 </div>
                   </td>
                   </tr>
           
           <tr>
           <td>
    
            <div class="form-group">

                <asp:TextBox ID="vtxtRequestDetail" runat="server"  MaxLength="100" TextMode="MultiLine"
                            class="form-control" placeholder="Request Detail" Rows="4" ></asp:TextBox>
                      </div>
               </td>       
                 <td> 
                 <div class="form-group">
             <asp:TextBox ID="vtxtAddress" runat="server" MaxLength="100" TextMode="MultiLine" 
             class="form-control" placeholder="Address" Rows="4"></asp:TextBox>
           </div>   
            </td>
            </tr>
            <tr>
            <td>
            <div class="form-group">
               <asp:RequiredFieldValidator ID="rfvRequestDetail1" runat="server" ControlToValidate="vtxtRequestDetail"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                    </div>
                    </td>
           <td>
                     <div class="form-group">
                         <asp:RequiredFieldValidator ID="rfvAddress1" runat="server" ControlToValidate="vtxtAddress"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
              </div>
            
              </td> 
              </tr> 
            
   <tr>
   <td>
            <div class="form-group">

              <asp:TextBox ID="vtxtMobileNo" runat="server" MaxLength="10" class="form-control" placeholder="Mobile No" ></asp:TextBox>
                     </div>
                      </td>
                      <td>
                        <div class="form-group">
                        <asp:TextBox ID="vtxtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                </div>
                      </td>
                      </tr>
                      <tr>
                      <td>
                      
                        <asp:RequiredFieldValidator ID="rfvMobileNo1" runat="server" ControlToValidate="vtxtMobileNo"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                     
                        <asp:RangeValidator ID="rvMobileNo1" runat="server" ValidationGroup="Submit" MaximumValue="9999999999"
                            MinimumValue="70000000000" ErrorMessage="Enter Valid Mobile No" ControlToValidate="vtxtMobileNo"
                            ForeColor="Red" CssClass="label-validation"></asp:RangeValidator>
                        </td>
                     <td>
                     <div class="form-group">
                       <asp:RequiredFieldValidator ID="rfvEmail1" runat="server" ControlToValidate="vtxtEmail"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                     
                       <asp:RegularExpressionValidator ID="revEmail1" runat="server" ControlToValidate="vtxtEmail"
                            ErrorMessage="Invalid Email  Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="Submit" CssClass="label-validation"></asp:RegularExpressionValidator>
                 </div>
                     </td>
                        </tr>
                           
                      
                 <tr>
                 <td>
                  <div class="form-group">
               
                        <asp:DropDownList ID="vddlState" runat="server" AutoPostBack="True" 
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" class="form-control" placeholder="State">
                            <asp:ListItem>Gujarat</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        </td>
                        <td>
                         <div class="form-group">
               
                        <asp:DropDownList ID="vddlCity" runat="server" class="form-control" placeholder="City" >
                            <asp:ListItem>Surat</asp:ListItem>
                        </asp:DropDownList>
                     </div>
                        </td>
                        </tr>
                        <tr>
                        <td>
                       <asp:RequiredFieldValidator ID="rfvState1" runat="server" ControlToValidate="vddlState"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                  </td>
                  <td>
                     <asp:RequiredFieldValidator ID="rfvCity1" runat="server" ControlToValidate="vddlCity"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                  </td>
                    
                     
                    </tr>
                     <tr>
                     <td>
                  
                     
                       
  </td>
  <td>
  <br />
  <div class="form-group">
    <%-- <asp:Label ID="lblIdProof" runat="server" Text="IdProof"></asp:Label>--%>
                        
                      
                        <div >
                            IdProof&nbsp;
                      <span class="style3">(e.g. Licence,Election Card or Any)</span> 
               
                        </div>
                        </div>
  </td>
 
 
  </tr>
  <tr>
  <td>
   <div class="form-group">
                       <asp:TextBox ID="vtxtPinCode" runat="server" MaxLength="6" class="form-control" placeholder="Pincode"></asp:TextBox>
                </div>
                </td> 
  <td>
   <div class="form-group">
                                  <asp:ImageButton ID="ImgIdProof" runat="server" onclick="ImgIdProof_Click" Width="150" Height="150" /> <br />      
                   <asp:Label ID="lblImgIdProof" runat="server" Text=""></asp:Label> 
                     </div>
  
  </td>
 
  </tr>
  <tr>
  <td>
        <asp:RequiredFieldValidator ID="rfvPinCode1" runat="server" ControlToValidate="vtxtPinCode"
                            ErrorMessage="Required" ForeColor="Red" ValidationGroup="Submit" CssClass="label-validation"></asp:RequiredFieldValidator>
                      
                       <asp:RegularExpressionValidator ID="revPinCode1" runat="server" ControlToValidate="txtPinCode"
                            ErrorMessage="Invalid Pincode" ForeColor="Red" ValidationExpression="(\d{6})"
                            ValidationGroup="Submit" CssClass="label-validation"></asp:RegularExpressionValidator>
                               
  </td>
  <td>
  <div class="form-group">

<asp:FileUpload ID="vfuIdproof" runat="server"></asp:FileUpload>
      
      <br />
      <asp:Label ID="Label1" runat="server" ForeColor="Red" CssClass="label-validation" ></asp:Label>
      <br />
      <br />
      
      </div>
  </td>
  </tr>
  
  <tr>
  <td>
                      <div class="form-group">
                        
                         <asp:Label ID="Label2" runat="server" Text="Disease Related Document 1 "></asp:Label>
                       
                          </div>
                      </td>
                      <td>
                       <div class="form-group">
             <asp:Label ID="Label3" runat="server" Text="Disease Related Document 2" ></asp:Label> <span class="style3">(Optional)</span> 
                       


             </div>
          
          
                      </td>
                      </tr>
                      <tr>
                      <td>
                       <div class="form-group">
                 
                               
 <asp:ImageButton ID="ImgDocument1" runat="server" onclick="ImgDocument1_Click" Width="150" Height="150" /><br />      
                   <asp:Label ID="lblImgDocument1" runat="server" Text=""></asp:Label> 
                                                        
                 </div>
                      </td>
                      <td>
                       <div class="form-group">
     <asp:ImageButton ID="ImgDocument2" runat="server" Height="150" 
                                                             onclick="ImgDocument2_Click" Width="150" />
                                <br />      
                   <asp:Label ID="lblImgDocument2" runat="server" Text=""></asp:Label> 
                                
           </div>
                      </td>
                      </tr>
                      <tr>
                      <td>
                                                      
                            <asp:FileUpload ID="vfuDocument1" runat="server"></asp:FileUpload>
                            
                            <br />
                            <asp:Label ID="Label4" runat="server" CssClass="label-validation" 
                                ForeColor="Red"></asp:Label>
                            
                      </td>
                      
                      <td>
                      <div class="form-group">
                        <asp:FileUpload ID="vfuDocument2" runat="server"></asp:FileUpload>
                          <br />
                          <asp:Label ID="Label5" runat="server" CssClass="label-validation" 
                              ForeColor="Red"></asp:Label>
                     </div>
                     
                    </td>
                      </tr>
                    
         </table><br />
         <br />
            <table> 
            <tr>
            <td style="width:200px;">  
            </td>
            
            
            <td >
                     
            <div class="form-group">
                        <asp:Button ID="vbtnSubmit" runat="server" CssClass="btn btn-primary" 
                           Text="Submit" ValidationGroup="Submit" 
                            onclick="vbtnSubmit_Click" />
                        &nbsp;<asp:Button ID="vbtnReset" runat="server" CssClass="btn btn-primary" 
                            Text="Reset" onclick="vbtnReset_Click" />
                        &nbsp;<asp:Button ID="vbtnCancel" runat="server" CssClass="btn btn-primary" 
                            Text="Cancel" onclick="vbtnCancel_Click" />
                  
            </div>
            </td>
            </tr>
          </table>



 
    
       
        
                                            </asp:Panel>
    </div>
    </div>
    </div>
    </div> </div>
    </section>
</asp:Content>
