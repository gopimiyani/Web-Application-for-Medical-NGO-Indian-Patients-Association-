<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true"
 CodeBehind="VPCDetailForm.aspx.cs" Inherits="IPA1.User.VPCDetailForm" %>
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
        <div  style="height:1000px" ></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:150px;">
                          <div class="contact-form" style="border: 1px solid #CCC;width:700px;">
                            <h3>Pharma Company Service Detail Form</h3>
                            <br />
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                       
                <table >
                 
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
                 
                           <asp:Label ID="lblName" runat="server" Text="Patient's Name"></asp:Label>
                              <span class="style2">*</span>
                        </td>
                        <tr>
                        <td>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlPatientName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPatientName_SelectedIndexChanged" class="form-control">
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
                </ContentTemplate>
                <Triggers>
                <%--<asp:AsyncPostBackTrigger ControlID="ddlPCName" />--%>
                <asp:AsyncPostBackTrigger ControlID="ddlPatientName" />

                </Triggers>
                       </asp:UpdatePanel>
               


                <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                <ContentTemplate>
                <div class="divgrid">
                    <asp:GridView ID="gvPharmaCompany" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="id" EnableModelValidation="True" ForeColor="#333333" CellPadding="4"
                        GridLines="Horizontal" BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid"
                        ShowFooter="True" OnPageIndexChanging="gvPharmaCompany_PageIndexChanging" OnRowCancelingEdit="gvPharmaCompany_RowCancelingEdit"
                        OnRowDeleting="gvPharmaCompany_RowDeleting" OnRowEditing="gvPharmaCompany_RowEditing"
                        OnRowUpdating="gvPharmaCompany_RowUpdating" class="table table-striped  table-bordered" style="width:300px;"
                        PageSize="5" >
                          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtId" runat="server" Enabled="false" Text='<%#Eval("id") %>' style="width:30px; margin-bottom:25px; height:25px"> </asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ItemName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtItemName" runat="server" Text='<%#Eval("ItemName") %>' style="width:90px;"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvItemName" runat="server" ControlToValidate="txtItemName"
                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="revItemName" runat="server" SetFocusOnError="True"
                                        ErrorMessage="Invalid Item Name" ControlToValidate="txtItemName" ValidationExpression="[a-zA-Z0-9 ]+"
                                        ValidationGroup="Update" ForeColor="Red"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtIItemName" runat="server" style="width:90px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvIItemName" runat="server" ControlToValidate="txtIItemName"
                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br /><asp:RegularExpressionValidator ID="revIItemName" runat="server" SetFocusOnError="True"
                                        ErrorMessage="Invalid Item Name" ControlToValidate="txtIItemName" ValidationExpression="[a-zA-Z0-9 ]+"
                                        ValidationGroup="Insert" ForeColor="Red"></asp:RegularExpressionValidator>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate">
                                <ItemTemplate>
                                    <asp:Label ID="lblRate" runat="server" Text='<%#Eval("Rate") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRate" runat="server" class="inputtext" Text='<%#Eval("Rate") %>'
                                        OnTextChanged="txtRate_TextChanged" AutoPostBack="True" MaxLength="5" style="width:90px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvRate" runat="server" ErrorMessage="*" ForeColor="Red"
                                        ControlToValidate="txtRate" ValidationGroup="Update" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    
                                    <asp:Label ID="lblcvRate" runat="server" ForeColor="Red"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtIRate" runat="server" class="inputtext" OnTextChanged="txtIRate_TextChanged"
                                        AutoPostBack="true" MaxLength="5" style="width:90px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvIRate" runat="server" ControlToValidate="txtIRate"
                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:Label ID="lblcvIRate" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtQuantity" runat="server" class="inputtext" Text='<%#Eval("Quantity") %>'
                                        OnTextChanged="txtQuantity_TextChanged" AutoPostBack="True" MaxLength="5" style="width:90px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvQuantity" runat="server" ErrorMessage="*" ForeColor="Red"
                                        ControlToValidate="txtQuantity" ValidationGroup="Update" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                    
                                    <asp:Label ID="lblcvQuantity" runat="server" ForeColor="Red"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtIQuantity" runat="server" class="inputtext" OnTextChanged="txtIQuantity_TextChanged"
                                        AutoPostBack="True" MaxLength="5" style="width:90px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvIQuantity" runat="server" ControlToValidate="txtIQuantity"
                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                    
                                    <br />
                                    <asp:Label ID="lblcvIQuantity" runat="server" ForeColor="Red"></asp:Label>
                                    
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("Amount") %>' Enabled="False"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTotalAmount" runat="server" Text='<%#Eval("Amount") %>' Enabled="False" style="width:90px; margin-bottom:25px; height:25px"> </asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblcvTotalAmount" runat="server" ></asp:Label>
                                </FooterTemplate>
                           </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" class="btn btn-primary" Text="Edit" CommandName="Edit" Width="60px">
                                    </asp:Button>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Update" class="btn btn-primary"
                                        Text="Update" CommandName="Update" Width="70px"/>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnInsert" runat="server" ValidationGroup="Insert" class="btn btn-primary"
                                        Text="Insert" OnClick="btnInsert_Click" Width="60px"></asp:Button>
                                </FooterTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" Text="Delete" CommandName="Delete" Width="70px"/>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" CommandName="Cancel" Width="70px" />
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


                  
                    <asp:Label ID="lblgvPharmaCompany" runat="server" Text="" ForeColor="Red" CssClass="label-validation"></asp:Label>
                </div>
                 </ContentTemplate>
                <Triggers>
               <%-- <asp:AsyncPostBackTrigger ControlID="txtIRate" />
                <asp:AsyncPostBackTrigger ControlID="txtIQuantiity" />
--%>
                </Triggers>
                       </asp:UpdatePanel>
              

                
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
                                             <asp:TextBox ID="txtDiscountAmount" runat="server" Enabled="False" class="form-control" ></asp:TextBox>
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
                <table style="width:300px;">
                    <tr>
                       
                       
                        <td >
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
  </div>
    </div>
    </div>
   
   </div></div>

   </section>
</asp:Content>
