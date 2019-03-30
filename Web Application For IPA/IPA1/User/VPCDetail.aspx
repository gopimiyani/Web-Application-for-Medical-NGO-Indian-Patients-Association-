<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true"
 CodeBehind="VPCDetail.aspx.cs" Inherits="IPA1.User.VPCDetail" %>
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
 <section id="contact" style="margin-top:50px;">
<%--<asp:Image ID="Image1" runat="server" style="height:1000px" ImageUrl="~/Visitor/images/testimonial/bg.jpg"></asp:Image>--%>
      <%--  <div  id="google-map"  style="height:650px" ></div>--%>
        <div  style="height:1500px" ></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:150px;">
                          <div class="contact-form" style="border: 1px solid #CCC;width:700px; padding-left:20px;">
                            <h3>Pharma Company Service Detail </h3>
                            <br />

                             <asp:MultiView ID="mvPC" runat="server">
            <br />
            <asp:View ID="vPC" runat="server"> 
               <div class="btn-group">
                                                    <div class="form-group form-inline">
                                                        <asp:Button ID="btnNew" class="btn btn-primary" runat="server" Text="New" OnClick="btnNew_Click">
                                                        </asp:Button>
                                                       
                                                        
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
                                                 <br />
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
                                                    <asp:TextBox ID="txtSearch" runat="server" class="form-control"
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
                                                <asp:GridView ID="gvPharmaCompany" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CellPadding="4" DataKeyNames="PharmaCompanyDetail_ID" EnableModelValidation="True"
                                                    ForeColor="#333333" GridLines="Both" BorderWidth="1px" BorderColor="#cccccc"
                                                    BorderStyle="Solid" OnRowCommand="gvPharmaCompany_RowCommand" class="table table-striped  table-bordered"
                                                    PageSize="5" onpageindexchanging="gvPharmaCompany_PageIndexChanging" 
                                                AllowSorting="True" onsorting="gvPharmaCompany_Sorting1">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                    <Columns>
                                                      
                                           
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
                                                                <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("Name") %>'></asp:Label></ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtPatientName" runat="server" Enabled="false" Text='<%#Eval("Name") %>'></asp:TextBox></EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                           
                                           
                                           
                                                        <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalAmount">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label></ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="false" Text='<%#Eval("TotalAmount") %>'></asp:TextBox></EditItemTemplate>
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
                                                                <asp:Label ID="lblPaymentStatus" runat="server" Text='<%#Eval("PaymentStatus") %>'></asp:Label></ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtPaymentStatus" runat="server" Enabled="false" Text='<%#Eval("PaymentStatus") %>'></asp:TextBox></EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" class="btn btn-primary" runat="server" Text="View" CommandName="View"
                                                                    CommandArgument='<%#Eval("PharmaCompanyDetail_ID") %>' /></ItemTemplate>
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
                      </asp:View>
            <asp:View ID="vPCDetail" runat="server">
              <table>
                                           
                                          
                                           
                                            <tr>
                                            
                                            <td>
                                                <asp:TextBox ID="txtPharmaCompanyDetail_ID" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                            
                                            </tr>

                                               <tr>
                                        <%--<td>
                                        <asp:Label ID="lblPName" runat="server" Text="Pharma Company Name"></asp:Label>
                                             <span class="style2">*</span>
                                        </td>--%>
                                            <td>
                                              <h4> <u>
                                               <asp:Label ID="lblBillNo" runat="server" Text="BillNo: "></asp:Label>
                                               <asp:Label ID="lblBillNo1" runat="server"></asp:Label>
                                               </u></h4 >
                                     
                                            </td>
                                            </tr>
                                           
                                           <%-- <td>
                                             <div class="form-group">
                                              <asp:DropDownList ID="ddlPCName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPCName_SelectedIndexChanged" class="form-control">
                            </asp:DropDownList>   </div>
                                           
                                            </td>--%>
                                           
                                        
                                     <%--   <tr>
                                        <td>
                                            <asp:Label ID="lblcvPCName" runat="server" ForeColor="Red" CssClass="lable-validation"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        </tr>--%>
                                
                 
                 
                 
                 
                 
                 
                 <tr>
                 <td>
                 
                           <asp:Label ID="lblName" runat="server" Text="Patient's Name"></asp:Label>
                              <span class="style2">*</span>
                        </td>
                        </tr>
                        <tr>
                        <td>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPatientName_SelectedIndexChanged" class="form-control">
                            </asp:DropDownList>
                            </div>
                        </td>
                        </tr>
                        <tr>
                        <td>
                            <asp:Label ID="lblcvName" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                        </td>
                    </tr>  
                                            </table>

                                         
                                          



                                           
                                            <div class="divgrid">
                                            <asp:GridView ID="gvPCDetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                DataKeyNames="PharmaCompanyService_ID" EnableModelValidation="True" ForeColor="#333333"
                                                CellPadding="4" GridLines="Horizontal" BorderWidth="1px" BorderColor="#cccccc"
                                                BorderStyle="Solid" ShowFooter="True" OnPageIndexChanging="gvPCDetail_PageIndexChanging"
                                                OnRowCancelingEdit="gvPCDetail_RowCancelingEdit" OnRowDeleting="gvPCDetail_RowDeleting"
                                                OnRowEditing="gvPCDetail_RowEditing" OnRowUpdating="gvPCDetail_RowUpdating" class="table table-striped  table-bordered"
                                                PageSize="5">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="PharmaCompanyService_ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPCServiceId" runat="server" Text='<%#Eval("PharmaCompanyService_ID") %>'></asp:Label></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtPCServiceId" runat="server" Enabled="false" Text='<%#Eval("PharmaCompanyService_ID") %>' style="width:40px;"> </asp:TextBox></EditItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="#">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtId" runat="server" Enabled="false" Text='<%#Eval("id") %>' style="width:120px; margin-bottom:25px; height:25px"> </asp:TextBox></EditItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ItemName") %>'></asp:Label></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtItemName" runat="server" Text='<%#Eval("ItemName") %>' style="width:90px;"> </asp:TextBox>
                                                       
                                                         <asp:RequiredFieldValidator ID="rfvItemName" runat="server" ControlToValidate="txtItemName"
                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <br />
                                    <asp:RegularExpressionValidator ID="revItemName" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Item Name" 
                                    ControlToValidate="txtItemName" ValidationExpression="[a-zA-Z0-9 ]+" ValidationGroup="Update" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                                  
                                                       
                                                       
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtIItemName" runat="server" class="inputtext" style="width:90px;"></asp:TextBox> 
                                                             <asp:RequiredFieldValidator ID="rfvIItemName" runat="server" ControlToValidate="txtIItemName"
                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="revIItemName" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Item Name"
                                     ControlToValidate="txtIItemName" ValidationExpression="[a-zA-Z0-9 ]+" ValidationGroup="Insert" ForeColor="Red"></asp:RegularExpressionValidator>

                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtRate" runat="server" class="inputtext" Text='<%#Eval("Rate") %>' style="width:90px;"> </asp:TextBox>
                                                       
                                                           <asp:RequiredFieldValidator ID="rvRate" runat="server" ErrorMessage="*" 
                                            ForeColor="Red" ControlToValidate="txtRate" ValidationGroup="Update" 
                                            SetFocusOnError="True" ></asp:RequiredFieldValidator>
                                      

                                    <br />
                                    <asp:Label ID="lblcvRate" runat="server" ForeColor="Red"></asp:Label>
                                  </EditItemTemplate>

                                                       
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtIRate" runat="server" class="inputtext" 
                                                                ontextchanged="txtIRate_TextChanged" AutoPostBack="true" style="width:90px;"></asp:TextBox>

                                                              <asp:RequiredFieldValidator ID="rfvIRate" runat="server" ControlToValidate="txtIRate"
                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                <br />
                                    <asp:Label ID="lblcvIRate" runat="server" ForeColor="Red" Text=""></asp:Label>
                                  
                                                        </FooterTemplate>


                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtQuantity" runat="server" class="inputtext" Text='<%#Eval("Quantity") %>'
                                                                OnTextChanged="txtQuantity_TextChanged" AutoPostBack="True" style="width:90px;"> </asp:TextBox>
                                                        
                                                         <asp:RequiredFieldValidator ID="rvQuantity" runat="server" ErrorMessage="*" 
                                            ForeColor="Red" ControlToValidate="txtQuantity" ValidationGroup="Update" 
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                          <%--      <asp:RegularExpressionValidator ID="revQuantity" runat="server" SetFocusOnError="True" ErrorMessage="Enter only Digits" 
                                ControlToValidate="txtQuantity" ValidationExpression="[0-9 ]+" ValidationGroup="Update" ForeColor="Red"></asp:RegularExpressionValidator>
                          --%>                      
                                        
                                            
                                     <asp:Label ID="lblcvQuantity" runat="server" ForeColor="Red"></asp:Label>
                                     </EditItemTemplate>
                                                        
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtIQuantity" runat="server" class="inputtext" 
                                                                ontextchanged="txtIQuantity_TextChanged" AutoPostBack="True" style="width:90px;"></asp:TextBox>
                                                              <asp:RequiredFieldValidator ID="rfvIQuantity" runat="server" ControlToValidate="txtIQuantity"
                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                           <%--     <asp:RegularExpressionValidator ID="revIQuantity" runat="server" SetFocusOnError="True" ErrorMessage="Enter only Digits" 
                                ControlToValidate="txtIQuantity" ValidationExpression="[0-9 ]+" ValidationGroup="Insert" ForeColor="Red"></asp:RegularExpressionValidator>
                           --%>     
                           
                                           
                                     <asp:Label ID="lblcvIQuantity" runat="server" ForeColor="Red"></asp:Label>

                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("Amount") %>' Enabled="False"></asp:Label></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTotalAmount" runat="server" Text='<%#Eval("Amount") %>' Enabled="False" style="width:90px; margin-bottom:25px; height:25px"> </asp:TextBox>
                                                           <%--   <asp:Label ID="lblcvTAmount" runat="server" ></asp:Label>--%>
                                                      
                                                            </EditItemTemplate>
                                                       
                                                       
                                                        <FooterTemplate>
                                                        <asp:Label ID="lblcvTotalAmount" runat="server" ></asp:Label>
                                                        </FooterTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEdit" runat="server" Width="60px" class="btn btn-primary" Text="Edit" CommandName="Edit" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Update"  Width="70px" class="btn btn-primary"
                                                                Text="Update" CommandName="Update" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Button ID="btnInsert" runat="server" Width="70px" ValidationGroup="Insert" class="btn btn-info"
                                                                Text="Insert" OnClick="btnInsert_Click"></asp:Button></FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDelete"  Width="70px" runat="server" class="btn btn-primary" Text="Delete" CommandName="Delete" /></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Button ID="btnCancel" runat="server"  Width="70px" class="btn btn-primary" Text="Cancel" CommandName="Cancel" /></EditItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#ebebeb" />
                                                <FooterStyle BackColor="#d6d6d6" Font-Bold="False"/>
                                                <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                                <PagerStyle BackColor="#284775" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            </asp:GridView>
                                            </div>
                                            <br />
                                            <asp:Label ID="lblgvPharmaCompany" runat="server" ForeColor="Red" Text=""></asp:Label>
                                         
                                         
                                       
                                         
                                            
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
                                            <asp:Label ID="lblcvTAmount" runat="server" ForeColor="Red" CssClass="label-validation"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:requiredfieldvalidator id="rvdiscount" runat="server" errormessage="*" forecolor="red"
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
                                                                                   <tr>
                                                                        
                                                                                       <td>
                                                                                                  <br />
                                                                                           Payment Status
                                                                                       </td>
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

                          </ContentTemplate>
                         <Triggers>

                         <asp:AsyncPostBackTrigger ControlID="txtDiscount" />
                           
                      
                         </Triggers>
                         </asp:UpdatePanel>



                                      <table style="width:300px;">
                                <tr>
                                  <td class="">
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
                         
                      

                                    </td>
                                </tr>
                            </table>
                          
</asp:View>
</asp:multiview>
        </section>
    </div>
    </div>
    </div>
    </div>
    </div>
</asp:Content>
