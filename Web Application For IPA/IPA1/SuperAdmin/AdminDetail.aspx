<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true"
    CodeBehind="AdminDetail.aspx.cs" Inherits="IPA1.SuperAdmin.AdminDetail1" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../assets/data-tables/DT_bootstrap.css" />
    <style type="text/css">
        .style5
        {
            width: 210px;
        }
        
        .style8
        {
            width: 190px;
        }
        
        .style9
        {
            width: 251px;
        }
    </style>
    <script src="../Scripts/ASPSnippets_Pager.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function RefreshUpdatePanel() {
            __doPostBack('<%= txtSearch.ClientID %>', '');
        };
    </script>
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
                    Admin  <small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvAdmin" runat="server" ActiveViewIndex="0">
            <br />
            <asp:View ID="vAdmin" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Admin</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Admin
                                        </h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                <div class="btn-group">
                                                    <asp:LinkButton ID="btnNew" runat="server" class="btn btn-info" OnClick="btnNew_Click">

                                                    <i class="icon-plus icon-white"></i>
                                                    

                                                    Create

                                                    

                                                    
                                                    </asp:LinkButton>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </div>
                                                <div class="btn-group pull-right">
                                                    <button class="btn dropdown-toggle" data-toggle="dropdown">
                                                        Tools <i class="icon-angle-down"></i>
                                                    </button>
                                                    <ul class="dropdown-menu pull-right">
                                                     <%--   <li>
                                                            <asp:LinkButton ID="lbPrint" runat="server">Print</asp:LinkButton>
                                                        </li>--%>
                                                        <li>
                                                            <asp:LinkButton ID="lbSaveAsPDF" runat="server" OnClick="lbSaveAsPDF_Click">Save as PDF</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbExportToExcel" runat="server" OnClick="lbExportToExcel_Click">Export to Excel</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbExportToWord" runat="server" OnClick="lbExportToWord_Click">Export to Word</asp:LinkButton>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="space15">
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
                                                        <asp:TextBox ID="txtSearch" runat="server" OnTextChanged="txtSearch_TextChanged"
                                                            onkeyup="RefreshUpdatePanel();" AutoPostBack="True" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div>
                                                <asp:GridView ID="gvAdmin" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CellPadding="4" DataKeyNames="Admin_ID" EnableModelValidation="True" ForeColor="#333333"
                                                    GridLines="Both" OnPageIndexChanging="gvAdmin_PageIndexChanging" BorderWidth="1px"
                                                    BorderColor="#cccccc" class="table table-striped table-hover" BorderStyle="Solid"
                                                    OnRowCommand="gvAdmin_RowCommand" OnSelectedIndexChanged="gvAdmin_SelectedIndexChanged"
                                                    AllowSorting="True" OnSorting="gvAdmin_Sorting" PageSize="5">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Admin ID" SortExpression="Admin_ID"><ItemTemplate><asp:Label ID="lblID" runat="server" Text='<%#Eval("Admin_ID") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:Label ID="lblIID" runat="server" Text='<%#Eval("Admin_ID") %>'></asp:Label></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" SortExpression="Name"><ItemTemplate><asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtName" class="inputtext" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Working Area" SortExpression="WorkingPinCode"><ItemTemplate><asp:Label ID="lblWorkingPinCode" runat="server" Text='<%#Eval("WorkingPinCode") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Contact No" SortExpression="MobileNo"><ItemTemplate><asp:Label ID="lblContact" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtMobileNo" class="inputtext" runat="server" Text='<%#Eval("MobileNo") %>'></asp:TextBox></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View"><ItemTemplate><asp:Button ID="btnView" class="btn btn-info" runat="server" Text="View" CommandName="View"
                                                                    CommandArgument='<%#Eval("Admin_ID") %>' /></ItemTemplate><EditItemTemplate></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#ebebeb" />
                                                    <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="" />
                                                    <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                                    <PagerStyle BackColor="#d6d6d6" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                </asp:GridView>
                                                <br />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END SAMPLE TABLE widget-->
                </div>
            </asp:View>
            <asp:View ID="vAdminDetail" runat="server">
                <ul class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <%--  <li><a href="#">Admin</a><span class="divider">&nbsp;</span></li>--%>
                    <li>
                        <asp:LinkButton ID="lbAdmin" runat="server" OnClick="lblAdmin_Click">Admin</asp:LinkButton>
                        <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Admin Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Admin Detail</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                           </div>
                                            <div class="space15">
                                            </div>
                                            <table class="" style="margin-left: 15px;">
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblAdminID" runat="server" Text=" Admin ID"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtAdminID" runat="server" CssClass="inputtext" MaxLength="20" Enabled="False"
                                                            Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblFirstName" runat="server" Text=" FirstName"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputtext" MaxLength="20"
                                                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="reFirstName" runat="server" ControlToValidate="txtFirstName"
                                                            ErrorMessage="Alphabates Only" ValidationExpression="[a-z A-Z]+" ValidationGroup="Submit"
                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblLastName" runat="server" Text=" LastName"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputtext" MaxLength="20"
                                                            ValidationGroup="Submit" ReadOnly="True" Width="208px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="reLastName" runat="server" ControlToValidate="txtLastName"
                                                            ErrorMessage="Alphabates Only" ValidationExpression="[a-z A-Z]*" ValidationGroup="Submit"
                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblProfilePic" runat="server" Text="Upload Your ProfilePic"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <br />
                                                        <asp:Image ID="ImgProfilePic" runat="server" Height="150px" Width="220px" />
                                                        <br />
                                                        <asp:FileUpload ID="fuProfilePic" runat="server" Enabled="False"></asp:FileUpload>
                                                        <asp:Label ID="lblProfilePicName" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:Label ID="lblProfilePicture" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style5">
                                                        <br />
                                                        <asp:TextBox ID="txtUserName" runat="server" Style="margin-top: 0px" AutoPostBack="True"
                                                            CssClass="inputtext" MaxLength="20" ValidationGroup="Submit" OnTextChanged="txtUserName_TextChanged"
                                                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        <asp:Label ID="lblcvUserName" runat="server" ForeColor="Red" Text="" Visible="False"></asp:Label>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                    </td>
                                                    <td class="style5">
                                                        <asp:RegularExpressionValidator ID="reUserName" runat="server" ControlToValidate="txtUserName"
                                                            ErrorMessage="Enter Alphabates and Digits Only " ValidationExpression="[a-zA-Z0-9]+"
                                                            ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputtext" MaxLength="40" ValidationGroup="Submit"
                                                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                                                            ErrorMessage="Invalid Email  Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtAddress" runat="server" Rows="4" TextMode="MultiLine" MaxLength="100"
                                                            ValidationGroup="Submit" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style5">
                                                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Enabled="False">
                                                            <asp:ListItem>Gujarat</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                                        &nbsp;
                                                        <br />
                                                    </td>
                                                    <td class="style5">
                                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown" Enabled="False">
                                                            <asp:ListItem>Surat</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="inputtext" ReadOnly="True"
                                                            Width="210px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rePinCode" runat="server" ControlToValidate="txtPinCode"
                                                            ErrorMessage="PinCode must be in 6 digit" ValidationExpression="(\d{6})" ValidationGroup="Submit"
                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="inputtext" MaxLength="10"
                                                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="rvMobileNo" runat="server" ErrorMessage="Enter Valid MobileNo"
                                                            ControlToValidate="txtMobileNo" MaximumValue="9999999999" MinimumValue="7000000000"
                                                            ValidationGroup="Submit" ForeColor="Red"></asp:RangeValidator>
                                                        <br />
                                                    </td>
                                                </tr>


                                                 <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblWorkingArea" runat="server" Text="Working Area"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtWorkingArea" runat="server" Rows="4" TextMode="MultiLine" MaxLength="100"
                                                            ValidationGroup="Submit" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style9">
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td class="style8">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblIPAddress" runat="server" Text="IP Address"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtIpaddress" class="inputtext" runat="server" Width="210px"></asp:TextBox>
                                                    </td>
                                                    <td class="style9">
                                                        <asp:RequiredFieldValidator ID="rfvIpaddress" runat="server" ErrorMessage="*" SetFocusOnError="True"
                                                            ValidationGroup="Submit" ControlToValidate="txtIpaddress" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                                        <asp:RegularExpressionValidator ID="reIpaddress" runat="server" ErrorMessage="Invalid IP!"
                                                            ValidationExpression="^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$"
                                                            ValidationGroup="Submit" ControlToValidate="txtIpaddress" SetFocusOnError="True"
                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </td>
                                                    <td class="style5">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="Submit"
                                                            ValidationGroup="Submit" OnClick="btnSubmit_Click" />
                                                   
                                                   
                                                        &nbsp;<asp:Button ID="btnDelete" runat="server" CssClass="btn btn-info" Text="Delete" OnClick="btnDelete_Click" OnClientClick="Confirm()" />
                                                   
                                                        &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info" Text="Cancel" OnClick="btnCancel_Click" />
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
