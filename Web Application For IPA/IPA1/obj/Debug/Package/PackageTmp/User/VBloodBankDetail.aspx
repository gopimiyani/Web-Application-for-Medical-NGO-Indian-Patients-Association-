<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true"
 CodeBehind="VBloodBankDetail.aspx.cs" Inherits="IPA1.User.VBloodBankDetail" %>
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

<asp:MultiView ID="mvBloodBank" runat="server" ActiveViewIndex="0">
            <br />
            <asp:View ID="vBloodBank" runat="server">
 

<section id="contact" style="margin-top:50px;">
<%--<asp:Image ID="Image1" runat="server" style="height:1000px" ImageUrl="~/Visitor/images/testimonial/bg.jpg"></asp:Image>--%>
      <%--  <div  id="google-map"  style="height:650px" ></div>--%>
        <div  style="height:1000px" ></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:150px;">
                          <div class="contact-form" style="border: 1px solid #CCC;width:900px;">
                            <h3>Blood Bank Service Detail </h3>
                            <div  style="font-size:15px;">
                              <u>Note:</u> 1. Click on New button to fill new service detail form. 
                               <div style="margin-left:40px;">
                               <p>
                                2. Click on View button to view the details of services provided by you. 
                               </p> </div>
                            </div>
                          
                         
       
          <div class="btn-group">
                                                    <div class="form-group form-inline">
                                                        <asp:Button ID="btnNew" class="btn btn-primary" runat="server" Text="New" OnClick="btnNew_Click1">
                                                        </asp:Button>
                                                        <br />
                                                        <br />
                                                    </div>
                                                </div>
                                             
                                               <div class="row-fluid">
                                                <table>
                                               
                                               <tr>
                                               <td>
                                            <div class="span6">
                                                <div class="dataTables_length">
                                               <div class="form-inline">   
                                             <div class="form-group">
                                               <asp:DropDownList ID="ddlRecPerPage" class="form-control" runat="server"
                                                        OnSelectedIndexChanged="ddlRecPerPage_SelectedIndexChanged" AutoPostBack="True" Width="70px">
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
                                          
                                         <td style="width:1000px;">
                                          
                                         </td>
                                      
                                          <td>
                                             <div class="span6">
                                                <div class="dataTables_filter">
                                                <div class="form-inline">
                                                <div class="form-group" style="margin-right:0px;">
                                                 <asp:Label ID="lblSearch" runat="server" Text="Search" Visible="false"></asp:Label>
                                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                                </div>
                                                </div>
                                            </div>
                                        </div>
                                            </td>
                                            </tr>
                                          </table> 
                                        </div>
                                        <br />
                                        <asp:GridView ID="gvBloodBank" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="4" DataKeyNames="BloodBankDetail_ID" EnableModelValidation="True"
                                            ForeColor="#333333" GridLines="Both" BorderWidth="1px" BorderColor="#cccccc"
                                            BorderStyle="Solid" OnPageIndexChanging="gvBloodBank_PageIndexChanging" OnRowCommand="gvBloodBank_RowCommand1"
                                            PageSize="5" class="table table-striped  table-bordered" AllowSorting="True"
                                            OnSorting="gvBloodBank_Sorting">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="BloodBankDetail ID" SortExpression="BloodBankDetail_ID"
                                                    Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBloodBankDetail_ID" runat="server" Text='<%#Eval("BloodBankDetail_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:TemplateField HeaderText="BillNo" SortExpression="BillNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBillNo" runat="server" Text='<%#Eval("BillNo") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtBillNo" runat="server" Enabled="false" Text='<%#Eval("BillNo") %>'></asp:TextBox></EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:TemplateField HeaderText="Patient's Name" SortExpression="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPName" runat="server" Enabled="false" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalAmount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="false" Text='<%#Eval("TotalAmount") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Discount" SortExpression="Discount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtDiscount" runat="server" Enabled="false" Text='<%#Eval("Discount") %>'></asp:TextBox></EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Final Amount" SortExpression="FinalAmount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFinalAmount" runat="server" Text='<%#Eval("FinalAmount") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtFinalAmount" runat="server" Enabled="false" Text='<%#Eval("FinalAmount") %>'></asp:TextBox></EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Payment Status" SortExpression="PaymentStatus">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPaymentStatus" runat="server" Text='<%#Eval("PaymentStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPaymentStatus" runat="server" Enabled="false" Text='<%#Eval("PaymentStatus") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnView" class="btn btn-primary" runat="server" Text="View" CommandName="View"
                                                            CommandArgument='<%#Eval("BloodBankDetail_ID") %>' />
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
                        <!-- END SAMPLE TABLE widget-->
                    </div>
                    </section>
            </asp:View>
            <asp:View ID="vBloodBankDetail" runat="server">

            
<section id="contact" style="margin-top:50px;">
<%--<asp:Image ID="Image1" runat="server" style="height:1000px" ImageUrl="~/Visitor/images/testimonial/bg.jpg"></asp:Image>--%>
      <%--  <div  id="google-map"  style="height:650px" ></div>--%>
        <div  style="height:1000px" ></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:150px;">
                          <div class="contact-form" style="border: 1px solid #CCC;width:900px;">
                            <h3>Blood Bank Service Detail </h3>
                          <%--  <div  style="font-size:15px;">
                              <u>Note:</u> 
                               <div style="margin-left:40px;">
                               <p>
                                2. Click on View button to view the details of services provided by you. 
                               </p> </div>
                            </div>
                          --%>
                         
       
 
             <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtBloodBankDetail_ID" runat="server" Visible="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
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
                          <%--  <tr>
                           <td>
                            <div class="form-group">
                               <asp:DropDownList ID="ddlBBName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBloodBankName_SelectedIndexChanged" class="form-control" Enabled="false">
                                        </asp:DropDownList>
                                   </div>
                            </td>
                            </tr>
                            <tr>
                                 <td>
                                    <asp:Label ID="lblcvBBName" runat="server" ForeColor="Red" CssClass="lable-validation"></asp:Label>
                                 </td>
                            
                       
                            </tr>
                          --%>  
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
                                   <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" class="form-control" >
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
            <asp:TextBox ID="txtNoOfBottle" runat="server" OnTextChanged="txtNoOfBottle_TextChanged"
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
                                        <br />
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
      <asp:RequiredFieldValidator ID="rvDiscount" runat="server" ErrorMessage="Required" ForeColor="Red" CssClass="label-validation"
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
                              <asp:TextBox ID="txtDiscountAmount" runat="server" Enabled="False" MaxLength="10" class="form-control"></asp:TextBox>
                         </div>
                         </td>
                         <td>
                           <div class="form-group">
                           <asp:TextBox ID="txtFinalAmount" runat="server" Enabled="False" MaxLength="10" class="form-control"></asp:TextBox>
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
                                        <asp:DropDownList ID="ddlPStatus" runat="server" Enabled="False" class="form-control">
                                            <asp:ListItem>Unpaid</asp:ListItem>
                                            <asp:ListItem>Paid</asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                                                <br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlName" />
                          <%--  <asp:AsyncPostBackTrigger ControlID="ddlBloodBankName" />--%>
                            <asp:AsyncPostBackTrigger ControlID="ddlBloodGroup" />
                            <asp:AsyncPostBackTrigger ControlID="txtDiscount" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <table>
                      <tr>     
                             <td>
                             
                                 <br />
                             
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
                    </div>
                    </div>
                    </section>
                    </asp:View>
                           
 
             </asp:Multiview>      

  
</asp:Content>
