<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="PCDetailForm.aspx.cs" Inherits="IPA1.AdminLab.PCDetailForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 220px;
        }
        .style2
        {
            width: 220px;
        }
        input[type="text"],input[type="textarea"]
        {
            width:206px;
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
                    PharmaCompany Detail Form
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="PharmaCompanyDetail.aspx">PharmaCompany Detail</a><span class="divider">&nbsp;</span></li>
                    <li><a href="#">PharmaCompany Detail Form</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN ADVANCED TABLE widget-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN EXAMPLE TABLE widget-->
                <div class="widget">
                    <div class="widget-title">
                        <h4>
                            <i class="icon-reorder"></i>PharmaCompany Detail Form</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                            </div><div class="space10"></div>

                       
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>
                       
                <table >
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblBillNo" runat="server" Text="BillNo"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBillNo" runat="server" Enabled="False" MaxLength="8"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblPCName" runat="server" Text="PharmaCompany's Name"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPCName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPCName_SelectedIndexChanged1">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblcvPCName" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="lblName" runat="server" Text="Patient's Name"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPatientName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPatientName_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="lblcvName" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlPCName" />
                <asp:AsyncPostBackTrigger ControlID="ddlPatientName" />

                </Triggers>
                       </asp:UpdatePanel>
                <br />


                <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                <ContentTemplate>
                <div class="divgrid">
                    <asp:GridView ID="gvPharmaCompany" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="id" EnableModelValidation="True" ForeColor="#333333" CellPadding="4"
                        GridLines="Horizontal" BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid"
                        ShowFooter="True" OnPageIndexChanging="gvPharmaCompany_PageIndexChanging" OnRowCancelingEdit="gvPharmaCompany_RowCancelingEdit"
                        OnRowDeleting="gvPharmaCompany_RowDeleting" OnRowEditing="gvPharmaCompany_RowEditing"
                        OnRowUpdating="gvPharmaCompany_RowUpdating" class="table table-striped  table-bordered"
                        PageSize="5">
                          <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtId" runat="server" Enabled="false" Text='<%#Eval("id") %>'> </asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Item Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemName" runat="server" Text='<%#Eval("ItemName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtItemName" runat="server" Text='<%#Eval("ItemName") %>'> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvItemName" runat="server" ControlToValidate="txtItemName"
                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                    <asp:RegularExpressionValidator ID="revItemName" runat="server" SetFocusOnError="True"
                                        ErrorMessage="Invalid Item Name" ControlToValidate="txtItemName" ValidationExpression="[a-zA-Z0-9 ]+"
                                        ValidationGroup="Update" ForeColor="Red"></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtIItemName" runat="server" class="inputtext"></asp:TextBox>
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
                                        OnTextChanged="txtRate_TextChanged" AutoPostBack="True" MaxLength="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvRate" runat="server" ErrorMessage="*" ForeColor="Red"
                                        ControlToValidate="txtRate" ValidationGroup="Update" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    
                                    <asp:Label ID="lblcvRate" runat="server" ForeColor="Red"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtIRate" runat="server" class="inputtext" OnTextChanged="txtIRate_TextChanged"
                                        AutoPostBack="true" MaxLength="5"></asp:TextBox>
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
                                        OnTextChanged="txtQuantity_TextChanged" AutoPostBack="True" MaxLength="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rvQuantity" runat="server" ErrorMessage="*" ForeColor="Red"
                                        ControlToValidate="txtQuantity" ValidationGroup="Update" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                    
                                    <asp:Label ID="lblcvQuantity" runat="server" ForeColor="Red"></asp:Label>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtIQuantity" runat="server" class="inputtext" OnTextChanged="txtIQuantity_TextChanged"
                                        AutoPostBack="True" MaxLength="5"></asp:TextBox>
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
                                    <asp:TextBox ID="txtTotalAmount" runat="server" Text='<%#Eval("Amount") %>' Enabled="False"> </asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblcvTotalAmount" runat="server"></asp:Label>
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
                        <FooterStyle BackColor="#d6d6d6" Font-Bold="False" ForeColor="" />
                        <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                        <PagerStyle BackColor="#284775" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>


                    <br />
                    <asp:Label ID="lblgvPharmaCompany" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
                 </ContentTemplate>
                <Triggers>
               <%-- <asp:AsyncPostBackTrigger ControlID="txtIRate" />
                <asp:AsyncPostBackTrigger ControlID="txtIQuantiity" />
--%>
                </Triggers>
                       </asp:UpdatePanel>
              

                <br />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                
                <table class="">
                    <tr>
                        <td class="style2">
                            Total Amount
                        </td>
                        <td>
                            <asp:TextBox ID="txtTAmount" runat="server" Width="" Enabled="False" 
                                ontextchanged="txtTAmount_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                        <asp:Label ID="lblcvTAmount" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Discount(%)
                        </td>
                        <td>
                            <asp:TextBox ID="txtDiscount" runat="server" Width="" AutoPostBack="True" 
                                OnTextChanged="txtDiscount_TextChanged" MaxLength="4"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rvDiscount" runat="server" ErrorMessage="*" ForeColor="Red"
                                ControlToValidate="txtDiscount" ValidationGroup="Submit" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblcvDiscount" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
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
                        <td class="style2">
                            Final Amount
                        </td>
                        <td>
                            <asp:TextBox ID="txtFinalAmount" runat="server" Width="" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
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
                        <td class="style2">
                            &nbsp;
                            <br />
                            <br />
                        </td>
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
                         
                          <%--  <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                ValidationGroup="Submit" class="btn btn-primary" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn btn-primary" OnClick="btnReset_Click" />
                            &nbsp;&nbsp;
                            <asp:Button ID="btnCancel" class="btn btn-primary" runat="server" OnClick="btnCancel_Click"
                                Text="Cancel" />--%>
                        </td>
                    </tr>
                </table>
                </div>
                </div>
                
</div>
            </div>
        </div>
    </div>
    </div>
    <!-- END EXAMPLE TABLE widget-->
    <!-- END ADVANCED TABLE widget-->
    <!-- END PAGE CONTENT-->
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
    <script type="text/javascript" src="../js/table-editable.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
</asp:Content>
