<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="PharmaCompanyDetail.aspx.cs" Inherits="IPA1.AdminLab.PharmaCompanyDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 220px;
        }
        .style3
        {
            width: 220px;
        }
        .style4
        {
            width: 220px;
            height: 32px;
        }
        .style5
        {
            height: 32px;
        }
               input[type="text"],input[type="textarea"]
        {
            width:206px;
        }
    .lblselect
        {
         padding: 0px 5px 0px 15px;
         vertical-align: middle;   
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN THEME CUSTOMIZER-->
                <div id="theme-change" class="hidden-phone">
                    <i class="icon-cogs"></i><span class="settings"><span class="text">Theme:</span> <span
                        class="colors"><span class="color-default" data-style="default"></span><span class="color-gray"
                            data-style="gray"></span><span class="color-purple" data-style="purple"></span>
                        <span class="color-navy-blue" data-style="navy-blue"></span></span></span>
                </div>
                <!-- END THEME CUSTOMIZER-->
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">
                    PharmaCompany<small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvPC" runat="server">
            <br />
            <asp:View ID="vPC" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">PharmaCompany</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- BEGIN PAGE CONTENT-->
                <div class="row-fluid">
                    <div class="span12">
                        <!-- BEGIN ADVANCED TABLE widget-->
                        <div class="row-fluid">
                            <div class="span12">
                                <!-- BEGIN EXAMPLE TABLE widget-->
                                <div class="widget">
                                    <div class="widget-title">
                                        <h4>
                                            <i class="icon-reorder"></i>PharmaCompany</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                <div class="btn-group">
                                                    <div class="form-group form-inline">
                                                        <asp:Button ID="btnNew" class="btn btn-primary" runat="server" Text="New" OnClick="btnNew_Click">
                                                        </asp:Button>
                                                        &nbsp;<asp:Label ID="lblType" runat="server" Font-Bold="True" Font-Names="Verdana" 
                                                            Font-Size="12pt" ForeColor="#2A6496" Text="Select Any PharmaCompany" CssClass="lblselect"></asp:Label>
                                                        &nbsp;
                                                        <asp:DropDownList ID="ddlPharmaCompanyName" runat="server" AutoPostBack="True" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddlPharmaCompanyName_SelectedIndexChanged"
                                                            style="margin-bottom:0px;">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                            </div>
                                            <div class="space12">
                                            </div>
                                            <div class="row-fluid">
                                                <div class="span6">
                                                    <div class="dataTables_length">
                                                        <asp:DropDownList ID="ddlRecPerPage" CssClass="input-small m-wrap" runat="server"
                                                            OnSelectedIndexChanged="ddlRecPerPage_SelectedIndexChanged" AutoPostBack="True">
                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblRecPerPage" runat="server" Text="records per page"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="span6">
                                                    <div class="dataTables_filter">
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search" Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtSearch" runat="server" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                                <asp:GridView ID="gvPharmaCompany" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CellPadding="4" DataKeyNames="PharmaCompanyDetail_ID" EnableModelValidation="True"
                                                    ForeColor="#333333" GridLines="Both" BorderWidth="1px" BorderColor="#cccccc"
                                                    BorderStyle="Solid" OnRowCommand="gvPharmaCompany_RowCommand" class="table table-striped table-hover"
                                                    PageSize="5" onpageindexchanging="gvPharmaCompany_PageIndexChanging" 
                                                AllowSorting="True" onsorting="gvPharmaCompany_Sorting1">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="PharmaCompany's Name" SortExpression="FirstName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label></ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtName" runat="server" Enabled="false" Text='<%#Eval("FirstName") %>'></asp:TextBox></EditItemTemplate>
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
                                           
                                           
                                           
                                                        <asp:TemplateField HeaderText="BillNo" SortExpression="BillNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBillNo" runat="server" Text='<%#Eval("BillNo") %>'></asp:Label></ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtBillNo" runat="server" Enabled="false" Text='<%#Eval("BillNo") %>'></asp:TextBox></EditItemTemplate>
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
                    </div>
                    <!-- END SAMPLE TABLE widget-->
                </div>
            </asp:View>
            <asp:View ID="vPCDetail" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                   
                    <li>
                    <asp:LinkButton ID="lbPharmaCompany" runat="server" onclick="lbPharmaCompany_Click">PharmaCompany</asp:LinkButton>
                    <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">PharmaCompany Service Detail</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- BEGIN PAGE CONTENT-->
                <div class="row-fluid">
                    <div class="span12">
                        <!-- BEGIN ADVANCED TABLE widget-->
                        <div class="row-fluid">
                            <div class="span12">
                                <!-- BEGIN EXAMPLE TABLE widget-->
                                <div class="widget">
                                    <div class="widget-title">
                                        <h4>
                                            <i class="icon-reorder"></i>PharmaCompanyService Detail</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                             
                            </div>
                                            <div class="space15">
                                            </div>
                                          
                                           <table class="">
                                           
                                             <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblBillNo" runat="server" Text="Bill No"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBillNo" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                           
                                           
                                            <tr>
                                            
                                            <td>
                                                <asp:TextBox ID="txtPharmaCompanyDetail_ID" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                            
                                            </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblPCName" runat="server" Text="PharmaCompany's Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPCName" runat="server" AutoPostBack="True" 
                                                            OnTextChanged="ddlPCName_TextChanged" 
                                                            onselectedindexchanged="ddlPCName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                             <asp:Label ID="lblcvPCName" runat="server" ForeColor="Red"></asp:Label>
                            
                            </td>
                         </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblName" runat="server" Text="Patient's Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                     <td>
                             <asp:Label ID="lblcvName" runat="server" ForeColor="Red"></asp:Label>
                            
                            </td>
                        </tr>
                                              
                                            </table>

                                         
                                          



                                            <br />
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
                                                            <asp:TextBox ID="txtPCServiceId" runat="server" Enabled="false" Text='<%#Eval("PharmaCompanyService_ID") %>'> </asp:TextBox></EditItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="#">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtId" runat="server" Enabled="false" Text='<%#Eval("id") %>'> </asp:TextBox></EditItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ItemName") %>'></asp:Label></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtItemName" runat="server" Text='<%#Eval("ItemName") %>'> </asp:TextBox>
                                                       
                                                         <asp:RequiredFieldValidator ID="rfvItemName" runat="server" ControlToValidate="txtItemName"
                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <br />
                                    <asp:RegularExpressionValidator ID="revItemName" runat="server" SetFocusOnError="True" ErrorMessage="Invalid Item Name" 
                                    ControlToValidate="txtItemName" ValidationExpression="[a-zA-Z0-9 ]+" ValidationGroup="Update" ForeColor="Red"></asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                                  
                                                       
                                                       
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtIItemName" runat="server" class="inputtext"></asp:TextBox> 
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
                                                            <asp:TextBox ID="txtRate" runat="server" class="inputtext" Text='<%#Eval("Rate") %>'> </asp:TextBox>
                                                       
                                                           <asp:RequiredFieldValidator ID="rvRate" runat="server" ErrorMessage="*" 
                                            ForeColor="Red" ControlToValidate="txtRate" ValidationGroup="Update" 
                                            SetFocusOnError="True" ></asp:RequiredFieldValidator>
                                      

                                    <br />
                                    <asp:Label ID="lblcvRate" runat="server" ForeColor="Red"></asp:Label>
                                  </EditItemTemplate>

                                                       
                                                        <FooterTemplate>
                                                            <asp:TextBox ID="txtIRate" runat="server" class="inputtext" 
                                                                ontextchanged="txtIRate_TextChanged" AutoPostBack="true"></asp:TextBox>

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
                                                                OnTextChanged="txtQuantity_TextChanged" AutoPostBack="True"> </asp:TextBox>
                                                        
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
                                                                ontextchanged="txtIQuantity_TextChanged" AutoPostBack="True"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtTotalAmount" runat="server" Text='<%#Eval("Amount") %>' Enabled="False"> </asp:TextBox>
                                                           <%--   <asp:Label ID="lblcvTAmount" runat="server" ></asp:Label>--%>
                                                      
                                                            </EditItemTemplate>
                                                       
                                                       
                                                        <FooterTemplate>
                                                        <asp:Label ID="lblcvTotalAmount" runat="server" ></asp:Label>
                                                        </FooterTemplate>

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEdit" runat="server" Width="60px" class="btn btn-info" Text="Edit" CommandName="Edit" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Update"  Width="70px" class="btn btn-inverse"
                                                                Text="Update" CommandName="Update" />
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Button ID="btnInsert" runat="server" Width="70px" ValidationGroup="Insert" class="btn btn-info"
                                                                Text="Insert" OnClick="btnInsert_Click"></asp:Button></FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDelete"  Width="70px" runat="server" class="btn btn-info" Text="Delete" CommandName="Delete" /></ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:Button ID="btnCancel" runat="server"  Width="70px" class="btn btn-inverse" Text="Cancel" CommandName="Cancel" /></EditItemTemplate>
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
                                            <br />
                                            <br />
                                            
                                             <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                                          <ContentTemplate>
                                          
                                         
                                       
                                         
                                            <table>
                                                <tr>
                                                    <td class="style4">
                                                        Total Amount
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtTAmount" runat="server" Width="" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    <asp:Label ID="lblcvTAmount" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style3">
                                                        Discount(%)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDiscount" runat="server" Width="" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                                    </td>
                                                      <td>
                                      <asp:RequiredFieldValidator ID="rvDiscount" runat="server" ErrorMessage="*" 
                                            ForeColor="Red" ControlToValidate="txtDiscount" ValidationGroup="Submit" 
                                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                                      <br />
                                    <asp:Label ID="lblcvDiscount" runat="server" ForeColor="Red"></asp:Label>
                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="style3">
                                                        <asp:Label ID="lblDiscountAmount" runat="server" Text="Discount Amount"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtDiscountAmount" runat="server" Enabled="False" Width=""></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style3">
                                                        Final Amount
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFinalAmount" runat="server" Width="" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style3">
                                                        Payment Status
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPStatus" runat="server" Enabled="False">
                                                            <asp:ListItem>Paid</asp:ListItem>
                                                            <asp:ListItem>Unpaid</asp:ListItem>
                                                        </asp:DropDownList>
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
                                    <td class="style4">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
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
                         
                      

                                    </td>
                                </tr>
                            </table>
                          

                                   
                                   
                                   
                                          
                                       <%--   <table>
                                                <tr>
                                                    <td class="style3">
                                                        &nbsp;
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                                            ValidationGroup="Submit" class="btn btn-primary" />&nbsp;&nbsp;&nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary" OnClick="btnReset_Click" />
                                                        &nbsp;&nbsp;<asp:Button ID="btnCancel" class="btn btn-primary" runat="server" OnClick="btnCancel_Click"
                                                            Text="Cancel" />
                                                    </td>
                                                </tr>
                                            </table>
--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
    <!-- BEGIN JAVASCRIPTS -->
    <!-- Load javascripts at bottom, this will reduce page load time -->
    <!-- ie8 fixes -->
    <!--[if lt IE 9]>
   <script src="js/excanvas.js"></script>
   <script src="js/respond.js"></script>
   <![endif]-->
    <script type="text/javascript" src="../assets/uniform/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../assets/data-tables/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../assets/data-tables/DT_bootstrap.js"></script>
    <script type="text/javascript" src="../js/scripts.js"></script>
    <script type="text/javascript" src="../js/table-editable.js"></script>
    <script  type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure you want to delete record?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
