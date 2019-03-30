<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true" CodeBehind="PaymentDetail.aspx.cs" Inherits="IPA1.AdminLab.ViewPaymentDetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 126px;
        }
        .style2
        {
            width: 129px;
        }
        .style3
        {
            width: 200px
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
                    Payment 
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
            </div>
        </div>
        
        <asp:MultiView ID="mvPayment" runat="server" ActiveViewIndex="0">
            <asp:View ID="vPayment" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Payment</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
                <!-- END PAGE HEADER-->
                <!-- BEGIN ADVANCED TABLE widget-->
                <div class="row-fluid">
                    <div class="span12">
                        <!-- BEGIN EXAMPLE TABLE widget-->
                        <div class="widget">
                            <div class="widget-title">
                                <h4>
                                    <i class="icon-reorder"></i>Payment</h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                    class="icon-remove"></a></span>
                            </div>
                            <div class="widget-body">
                                <div class="portlet-body">
                                    <div class="clearfix">
                                        <div class="btn-group">
                                            <asp:Button ID="btnNew" class="btn btn-info" runat="server" Text="Make Payment" 
                                                OnClick="btnNew_Click">
                                                            </asp:Button>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblStatus" runat="server" Text="Select User Type" ForeColor="#2A6496"
                                                Font-Bold="True" Font-Names="Verdana" Font-Size="12pt" CssClass="lblselect">
                                                </asp:Label>
                                            &nbsp;
                                            <asp:DropDownList ID="ddlType" runat="server" 
                                                AutoPostBack="True" CssClass="form-control" 
                                                style="margin-bottom:0px;"
                                                onselectedindexchanged="ddlType_SelectedIndexChanged">
                                               
                                                
                                            </asp:DropDownList>
                                            <%-- <button id="sample_editable_1_new" class="btn green">
                                        Add New <i class="icon-plus"></i>
                                    </button>
                                            --%>
                                        </div>
                                        
                                       
                                    </div>
                                    <div class="space10"></div>
                                    <div class="row-fluid">
                                        <div class="span6">
                                            <div class="dataTables_length">
                                                <asp:DropDownList ID="ddlRecPerPage" runat="server" AutoPostBack="True" 
                                                    CssClass="input-small m-wrap" 
                                                    OnSelectedIndexChanged="ddlRecPerPage_SelectedIndexChanged">
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
                                                <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" 
                                                    onkeyup="RefreshUpdatePanel();" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>--%>
                                    <asp:GridView ID="gvPaymentDetail" runat="server" AllowPaging="True" 
                                        AllowSorting="True" AutoGenerateColumns="False" BorderColor="#cccccc" 
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" 
                                        class="table table-striped table-hover" DataKeyNames="Payment_ID" 
                                        EnableModelValidation="True" ForeColor="#333333" GridLines="Both" 
                                        OnPageIndexChanging="gvPaymentDetail_PageIndexChanging" 
                                        OnRowCommand="gvPaymentDetail_RowCommand" OnSorting="gvPaymentDetail_Sorting" 
                                        PageSize="5">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Payment ID" SortExpression="Payment_ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("Payment_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblIID" runat="server" Text='<%#Eval("Payment_ID") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Bill No" SortExpression="BillNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBillNo" runat="server" Text='<%#Eval("BillNo") %>'></asp:Label>
                                                </ItemTemplate>
                                          </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Type" SortExpression="User Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUserType" runat="server" Text='<%#Eval("StackHolder") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblUserType" runat="server" Text='<%#Eval("StackHolder") %>'></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Name" SortExpression="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtName" runat="server" class="inputtext" 
                                                        Text='<%#Eval("Name") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtTAmount" runat="server" class="inputtext" 
                                                        Text='<%#Eval("FinalAmount") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("PaymentStatus") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtStatus" runat="server" class="inputtext" 
                                                        Text='<%#Eval("PaymentStatus") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" runat="server" class="btn btn-primary" 
                                                        CommandArgument='<%#Eval("Payment_ID") %>' CommandName="View" 
                                                        onclick="btnView_Click" Text="View" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#ebebeb" />
                                        <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="Red" />
                                        <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                        <PagerStyle BackColor="#d6d6d6" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                    <div class="space15">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE widget-->
                    </div>
                </div>
            </asp:View>
            <!-- END ADVANCED TABLE widget-->
            <asp:View ID="vPaymentDetail" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span></li>
                    <li>
                        <li><asp:LinkButton ID="lblPayment" runat="server" onclick="lblPayment_Click"  >Payment</asp:LinkButton>
                <span class="divider">&nbsp; </span></li>
                    
                    <li><a href="#">Payment Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Payment Detail</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                
                                            </div>
                                            <div class="space10">
                                            </div>
                                            <table class="">
                                               <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblPaymentID" runat="server" Text="Payment_ID"></asp:Label>
                                            </td>
                                            <td>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtPaymentID" runat="server" MaxLength="20" CssClass="inputtext"
                                                        Width="206px" Enabled="False"></asp:TextBox>
                                                </div>
                                            </td>
                                            <%--<td>
                                        <asp:RequiredFieldValidator ID="rfvPaymentID"" runat="server" ControlToValidate="txtPaymentID"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                        
                                    </td>--%>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblselecttype" runat="server" Text="StakeHolder's Type"></asp:Label>
                                            </td>
                                            <td>
                                               
                                                <asp:DropDownList ID="ddlselecttype" runat="server" AutoPostBack="True" onselectedindexchanged="ddlselecttype_SelectedIndexChanged1" 
                                                    Enabled="False" Width="220px">
                                                </asp:DropDownList>                
                                            </td>
                                            <%--<td>
                                        <asp:CustomValidator ID="cvddlselecttype" runat="server" ControlToValidate="ddlselecttype"
                                            OnServerValidate="cvddlselecttype_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                                    </td>--%>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged"
                                                    Height="30px" Enabled="False" Width="220px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblBillNo" runat="server" Text="BillNo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBillNo" runat="server" Enabled="False" 
                                                    onselectedindexchanged="ddlBillNo_SelectedIndexChanged" Width="220px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                                            </td>
                                            <td>
                                                <%--<asp:DropDownList ID="ddlAmount" runat="server" Width="220px">
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="txtAmount" runat="server" Width="206px" Enabled="False"></asp:TextBox>


                                            </td>
                                            <td>
                                               <%-- <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ControlToValidate="txtAmount"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblChequeNo" runat="server" Text="Cheque No"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChequeNo" runat="server" MaxLength="10" CssClass="inputtext"
                                                    Width="206px" Enabled="False"></asp:TextBox>
                                            </td>
                                            <%--<td>
                        <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo"
                            ErrorMessage="Enter Digits Only" ForeColor="Red" ValidationExpression="[0-9]+"
                            ValidationGroup="Submit"></asp:RegularExpressionValidator>
                        <br />
                        <asp:CustomValidator ID="cvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                            ErrorMessage="Contact no must be in 10 digit" ForeColor="Red" OnServerValidate="cvMobileNo_ServerValidate"
                            ValidationGroup="Submit"></asp:CustomValidator>
                    </td>--%>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblChequeDate" runat="server" Text="Cheque Date"></asp:Label>
                                                <span class="style2"></span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChequeDate" runat="server" Width="206px" Height="22px" 
                                                    Enabled="False"></asp:TextBox>
                                                <cc:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtChequeDate"
                                                    >
                                                </cc:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                            </td>
                                            <td>
                                                &nbsp;<asp:Button ID="btnCancle" runat="server" CssClass="btn btn-primary" Text="Cancel"
                                                    OnClick="btnCancle_Click" />
                                                &nbsp;</td>
                                        </tr>
                                            </table>
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
    <script type="text/javascript">
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
