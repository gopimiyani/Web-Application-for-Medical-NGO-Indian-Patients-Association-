<%@ Page Title="" Language="C#" MasterPageFile="~/VolunteerLab/Volunteer.Master" AutoEventWireup="true"
    CodeBehind="PatientRequestForm.aspx.cs" Inherits="IPA1.AdminLab.PatientRequestForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 199px;
        }
        .style2
        {
            color: #FF0000;
        }
          input[type="text"],input[type="textarea"]
        {
            width:206px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    Patient Request Form
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="ViewRequest.aspx">Patient Requests</a><span class="divider">&nbsp;</span></li>
                    <li><a href="#">Patient Request Form</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN ADVANCED TABLE widget-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN EXAMPLE TABLE widget-->
                <div class="widget">
                    <div class="widget-title">
                        <h4>
                            <i class="icon-reorder"></i>Patient Request Form</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                                <%--   <div class="btn-group">
                                  <button id="sample_editable_1_new" class="btn green">
                                        Add New <i class="icon-plus"></i>
                                    </button>
                                    </div>
                                --%>
                                <div class="btn-group pull-right">
                                    <button class="btn dropdown-toggle" data-toggle="dropdown">
                                        Tools <i class="icon-angle-down"></i>
                                    </button>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="#">Print</a></li>
                                        <li><a href="#">Save as PDF</a></li>
                                        <li><a href="#">Export to Excel</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="space12">
                            </div>
                            <!-- Here Put grid or table -->
                            <table>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td class="style5">
                                        <div class="controls">
                                            <asp:TextBox ID="txtName" runat="server" MaxLength="20" ></asp:TextBox>
                                        </div>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="reName" runat="server" ControlToValidate="txtName"
                                            ErrorMessage="Alphabates Only" ValidationExpression="[a-z A-Z]+" ValidationGroup="Submit"
                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="Label1" runat="server" Text="Subject"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td class="style5">
                                        <asp:TextBox ID="txtSubject" runat="server" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        Request Detail<span class="style2">*</span>
                                    </td>
                                    <td class="style5">
                                        <asp:TextBox ID="txtDescr" runat="server" TextMode="MultiLine" MaxLength="100" 
                                            Height="94px" Width="206px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvDescr" runat="server" ControlToValidate="txtDescr"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td class="style5">
                                        <asp:TextBox ID="txtAddress" runat="server" Font-Bold="False" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td class="style5">
                                        <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                            ErrorMessage="Enter Digits Only" ValidationExpression="[0-9]+" ValidationGroup="Submit"
                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:CustomValidator ID="cvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                            ErrorMessage="Contact no must be in 10 digit" ForeColor="Red" ValidationGroup="Submit"
                                            OnServerValidate="cvMobileNo_ServerValidate"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                        <span class="style2"></span>
                                    </td>
                                    <td class="style5">
                                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                                            ErrorMessage="Invalid Email  Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td class="style5">
                                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                            <asp:ListItem>Gujarat</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td class="style5">
                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown">
                                            <asp:ListItem>Surat</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td class="style5">
                                        <asp:TextBox ID="txtPinCode" runat="server" MaxLength="6"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="rePinCode" runat="server" ControlToValidate="txtPinCode"
                                            ErrorMessage="Enter Digits Only" ValidationExpression="[0-9]+" ValidationGroup="Submit"
                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                        <br />
                                        <asp:CustomValidator ID="cvPinCode" runat="server" ControlToValidate="txtPinCode"
                                            ErrorMessage="Pincode must be in 6 digit " OnServerValidate="cvPinCode_ServerValidate"
                                            ValidationGroup="Submit" ForeColor="Red"></asp:CustomValidator>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td colspan="3">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                            ValidationGroup="Submit" CssClass="btn btn-primary" />
                                    </td>
                                    <td>
                                        &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"
                                            CssClass="btn btn-primary" />
                                        &nbsp;<asp:Button ID="btnCancle" runat="server" Text="Cancel" OnClick="btnCancle_Click"
                                            CssClass="btn btn-primary" />
                                    </td>
                                </tr>
                            </table>
                            <!-- End -->
                        </div>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE widget-->
            </div>
        </div>
        <!-- END ADVANCED TABLE widget-->
        <!-- END PAGE CONTENT-->
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
</asp:Content>
