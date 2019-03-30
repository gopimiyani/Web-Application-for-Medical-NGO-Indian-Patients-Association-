<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true" CodeBehind="MultiViewDemo.aspx.cs" Inherits="IPA1.AdminLab.MultiViewDemo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link rel="stylesheet" href="../assets/data-tables/DT_bootstrap.css" />
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
                    Tasks <small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvTask" runat="server">
            <br />
            <asp:View ID="vTask" runat="server">
                <ul class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Tasks</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Tasks</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                <div class="btn-group">
                                                   
                                                </div>
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
                                            <div class="space15">
                                            </div>
                                            <div class="row-fluid">
                                                <div class="span6">
                                                    <div class="dataTables_length">
                                                        <asp:DropDownList ID="ddlRecPerPage" cssClass="input-small m-wrap" runat="server"
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
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label>
                                                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <table class="table table-striped table-hover">
                                                



                                            </table>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END SAMPLE TABLE widget-->
                </div>
            </asp:View>
            
            <asp:View ID="vTaskDetail" runat="server">
                <ul class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Tasks</a><span class="divider">&nbsp;</span></li>
                    <li><a href="#">Task Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Task Detail</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
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
                                            <div class="space15">
                                            </div>
                                            <table class="table table-striped table-hover">
                                                

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
    <script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../assets/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/jquery.blockui.js"></script>
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
    <script>
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
    <script type="text/javascript">
        document.getElementById("btnAssign").onclick = function () {
            location.href = "~/AssignTask.aspx";
        };
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
