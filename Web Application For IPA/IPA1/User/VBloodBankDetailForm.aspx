<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" 
CodeBehind="VBloodBankDetailForm.aspx.cs" Inherits="IPA1.User.VBloodBankDetailForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style type="text/css">
   input[type="text"][disabled="disabled"],select[disabled]
   {
       width:300px;
       height:34px;
       border: 1px solid #ccc;
       border-radius: 4px;
       cursor:not-allowed;
       padding: 6px 12px;
       background-color: rgb(235, 235, 228);
   }  
   /*input[type="text"]
   {
       padding: 6px 12px;
   }*/
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
    width: 300px;
  }
  
  .form-group-marginbottom
 {
     margin-bottom:25px;
    width: 300px;
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
 
</style>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section id="contact" style="margin-top:50px;">
<%--<asp:Image ID="Image1" runat="server" style="height:1000px" ImageUrl="~/Visitor/images/testimonial/bg.jpg"></asp:Image>--%>
      <%--  <div  id="google-map"  style="height:650px" ></div>--%>
        <div  style="height:1000px" ></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:150px;">
                          <div class="contact-form" style="border: 1px solid #CCC;width:900px;">
                            <h3>Blood Bank Service Detail Form</h3>
                            <br />
                              <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <table>
                            <tr>
                          <%--  <td>
                                  <asp:Label ID="lblBloodBankName" runat="server" Text="BloodBank's Name"></asp:Label>
                                        <span class="style2">*</span>
                                  
                            </td>--%>
                            <td>
                               <h4> <u>
                                               <asp:Label ID="lblBillNo" runat="server" Text="BillNo: "></asp:Label>
                                               <asp:Label ID="lblBillNo1" runat="server"></asp:Label>
                                               </u></h4 >
                                   
                            </td>
                            </tr>
                        
                            <tr>
                           <td>
                                  <asp:Label ID="lblName" runat="server" Text="Patient's Name"></asp:Label>
                                        <span class="style2">*</span>
                                 
                            </td>
                           <td>
                             <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup"></asp:Label>
                                        <span class="style2">*</span>
                                   
                            </td>
                            </tr>
    
      <tr>
                           <td>
                             <div class="form-group">
                                   <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" class="form-control">
                                        </asp:DropDownList>
                                </div>
                           
                            </td>
                           <td> 
                             <div class="form-group">
                             <asp:DropDownList ID="ddlBloodGroup" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBloodGroup_SelectedIndexChanged">
                                            <asp:ListItem>--Select Blood Group--</asp:ListItem>
                                            <asp:ListItem>A+</asp:ListItem>
                                            <asp:ListItem>A-</asp:ListItem>
                                            <asp:ListItem>B+</asp:ListItem>
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
                                 <asp:Label ID="lblcvName" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                           </td>
                           <td>
                               <asp:Label ID="lblcvBloodGroup" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                            </td>
                            </tr>
    

    <tr>
    <td>
            <asp:Label ID="lblNoOfBottle" runat="server" Text="No Of Bottle"></asp:Label>
                                        <span class="style2">*</span>
                                
    </td>
    <td>
         <asp:Label ID="lblRate" runat="server" Text="Rate(Per Bottle)"></asp:Label>
                                        <span class="style2">*</span>
                                   
    </td>
    </tr>
    <tr>
    <td>
      <div class="form-group">
            <asp:TextBox ID="txtNoOfBottle" runat="server" OnTextChanged="txtNoOfBottle_TextChanged1"
                                            AutoPostBack="True" class="form-control"></asp:TextBox>
       </div>                         
    </td>
    <td>
      <div class="form-group">
              <asp:TextBox ID="txtRate" runat="server" AutoPostBack="True" class="form-control" OnTextChanged="txtRate_TextChanged"></asp:TextBox>
    </div>
    </td>
    </tr>
    <tr>
    <td>
       <asp:RequiredFieldValidator ID="rvNoOfBottle" runat="server" ErrorMessage="Required" ForeColor="Red" CssClass="label-validation"
                                            ControlToValidate="txtNoOfBottle" ValidationGroup="Submit" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <%-- <asp:RegularExpressionValidator ID="reNoOfBottle" runat="server" 
                                            ErrorMessage="Enter only Digits" ControlToValidate="txtNoOfBottle" 
                                            ValidationExpression="\d+" ValidationGroup="Submit" ForeColor="Red" 
                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                        --%>
                                        
                                        <asp:Label ID="lblcvNoOfBottle" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                                   
    </td>
    <td>
             <asp:RequiredFieldValidator ID="rvRate" runat="server" ErrorMessage="Required" ForeColor="Red"
                                            ControlToValidate="txtRate" ValidationGroup="Submit" SetFocusOnError="True" CssClass="label-validation"></asp:RequiredFieldValidator>
                                        
                                        <asp:Label ID="lblcvRate" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                               
    </td>
    </tr>

    <tr>
    <td>
           <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount"></asp:Label>
    </td>
    <td>
       <asp:Label ID="lblDiscount" runat="server" Text="Discount(%)"></asp:Label>
                                        <span class="style2">*</span>
                                   
    </td>
    </tr>
           <tr>
    <td>
      <div class="form-group">
          <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="False" MaxLength="10" class="form-control"></asp:TextBox>
   </div>
    </td>
    <td>
      <div class="form-group">
                <asp:TextBox ID="txtDiscount" runat="server" OnTextChanged="txtDiscount_TextChanged1"
                                            AutoPostBack="True" MaxLength="6" class="form-control"></asp:TextBox>
      </div>                      
    </td>
    </tr>
             
              <tr>
    <td>
       <asp:Label ID="lblcvTotalAmount" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
    </td>
    <td>
      <asp:RequiredFieldValidator ID="rfvDiscount" runat="server" ErrorMessage="Required" ForeColor="Red" CssClass="label-validation"
                                            ControlToValidate="txtDiscount" ValidationGroup="Submit" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        
                                        <asp:Label ID="lblcvDiscount" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                                   
    </td>
    </tr>
                         <tr>
                         <td>
                          <asp:Label ID="lblDiscountAmount" runat="server" Text="Discount Amount"></asp:Label>
                         </td>
                         <td>
                           <asp:Label ID="lblFinalAmount" runat="server" Text="Final Amount"></asp:Label>
                         </td>
                         </tr>        
                                <tr>
                         <td>
                           <div class="form-group">
                              <asp:TextBox ID="txtDiscountAmount"  runat="server" Enabled="False" MaxLength="10" class="form-control"></asp:TextBox>
                         </div>
                         </td>
                         <td>
                           <div class="form-group">
                           <asp:TextBox ID="txtFinalAmount" runat="server"  Enabled="False" MaxLength="10" class="form-control"></asp:TextBox>
                        </div>
                         </td>
                         </tr>   
                           
                            </table>
                            <br />
                            <br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlName" />
                            <asp:AsyncPostBackTrigger ControlID="ddlBloodGroup" />
                            <asp:AsyncPostBackTrigger ControlID="txtDiscount" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <table>
                      <tr>     
                             <td>
                             
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
                         <br />
                      </td>                
                        </tr>
                    </table>
                               </div>
    </div>
    </div>
   
   </div></div>

   </section>
</asp:Content>
