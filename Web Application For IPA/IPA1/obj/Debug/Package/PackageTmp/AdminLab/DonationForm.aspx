<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="DonationForm.aspx.cs" Inherits="IPA1.AdminLab.DonationForm" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 99px;
        }
        .style4
        {
            width: 142px;
        }
        .style5
        {
            width: 158px
        }
        .style6
        {
            width: 161px
        }
        .style7
        {
            width: 205px
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
                    Donation
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Donation Form</a><span class="divider-last">&nbsp;</span></li>
                    <%-- <li><a href="#">Hospital Service Detail Form</a><span class="divider-last">&nbsp;</span></li>--%>
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
                            <i class="icon-reorder"></i>Donation Form</h4>
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
                            <div class="space10">
                            </div>
                           
                                        <br />
                                            <table>
                                                <tr>
                                                    <td class="style5">
                                                        <asp:Label ID="lblAmount1" runat="server" Text="Amount"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAmount" runat="server" Font-Bold="False" MaxLength="100" CssClass="inputtext"
                                                            Width="206px" ></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvAmount" runat="server" ErrorMessage="*" 
                                                            ControlToValidate="txtAmount" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                     <asp:Label ID="lblcvAmount" runat="server" ForeColor="Red" CssClass="label-validation">
                                                        </asp:Label>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td class="style5">
                                                        <asp:Label ID="lblChequeNo" runat="server" Text="Cheque No"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtChequeNo" runat="server" MaxLength="10" CssClass="inputtext"
                                                            Width="206px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvChequeNo" runat="server" ErrorMessage="*" 
                                                            ControlToValidate="txtChequeNo" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="reChequeNo" runat="server" ControlToValidate="txtChequeNo"
                                                    ErrorMessage="Cheque No must be of 6 digit" ValidationExpression="(\d{6})" ValidationGroup="Submit"
                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                                    
                                                   
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style5">
                                                        <asp:Label ID="lblChequeDate" runat="server" Text="Cheque Date"></asp:Label>
                                                        <span class="style2"></span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtChequeDate" runat="server" Width="206px" Height="22px"></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtChequeDate"
                                                            ></cc:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvChequeDate" runat="server" ErrorMessage="*" 
                                                            ControlToValidate="txtChequeDate" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                             <%--   <tr>
                                                    <td class="style5">
                                                        <asp:Label ID="lblBankName" runat="server" Text="Bank Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBankName" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    
                                                </tr>--%>
                                            </table>


                                            <table>
                                <tr>
                                    <td class="style6">
                                      
                                    </td>
                                    <td >
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
                                &nbsp;
                                <asp:LinkButton ID="btnCancel" runat="server" 
                                                            CssClass="btn btn-primary" onclick="btnCancel_Click">
                                                        <i class="icon-ban-circle icon-white"></i>
                                                        Cancel
                                                        </asp:LinkButton>
                           
                         
                      </td>
                                </tr>
                            </table>
                    
                                       
                                        <br />
                                        
                                
                            <table>
                                <%-- <tr>
                                    <td class="style8">
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="Submit" ValidationGroup="Submit"
                                            OnClick="btnSubmit_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-info" Text="Reset" OnClick="btnReset_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info" Text="Cancel" OnClick="btnCancel_Click" />
                                    </td>
                                </tr>--%>
                            </table>
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
