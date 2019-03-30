<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true" CodeBehind="ReportEvent.aspx.cs" Inherits="IPA1.AdminLab.ReportEvent" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    Report of Event
                    <%--<small>Editable Table Sample</small>--%>
                    Detail</h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#"></a>Report<span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Report of Event</a> Detail<span class="divider-last">&nbsp;</span></li>
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
                            Report of Event Detail</h4>
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
                                <%--    <asp:DropDownList ID="ddlRecPerPage" CssClass="input-small m-wrap" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlRecPerPage_SelectedIndexChanged">
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblRecPerPage" runat="server" Text="records per page"></asp:Label>
                                --%>
                                <%--<div class="btn-group pull-right">
                                    <button class="btn dropdown-toggle" data-toggle="dropdown">
                                        Tools <i class="icon-angle-down"></i>
                                    </button>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="#">Print</a></li>
                                        <li><a href="#">Save as PDF</a></li>
                                        <li><a href="#">Export to Excel</a></li>
                                    </ul>
                                </div>--%>
                            </div>
                            <div class="space15">
                            </div>
                           
                                    <table>
                                       
                                         
                                        <tr>
                                            <td class="style8">
                                                <asp:Label runat="server" Text="Date  From :" ID="lblJoinDateFrom"></asp:Label>
                                                <span class="style2"></span>(dd-MM-YYYY)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtJoinDateFrom" runat="server" Width="224px" ValidationGroup="Submit"></asp:TextBox>
                                                <cc:CalendarExtender ID="CalendarExtender" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                    TargetControlID="txtJoinDateFrom">
                                                </cc:CalendarExtender>
                                                 
                                            </td>
                                            <td class="style8">
                                                &nbsp;&nbsp;
                                                <asp:Label runat="server" Text=" To:" ID="lblJoinDateTo"></asp:Label>
                                                <span class="style2"></span>(dd-MM-YYYY)
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtJoinDateTo" runat="server" Width="224px" 
                                                    ValidationGroup="Submit" ></asp:TextBox>
                                                <asp:Label ID="lblcvJoinDateTo" runat="server"  ForeColor="Red" Text=""
                                                            ></asp:Label>
                                                <cc:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                    TargetControlID="txtJoinDateTo">
                                                </cc:CalendarExtender>
                                                 
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLocation" runat="server" ValidationGroup="Submit" 
                                                    Width="224px" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                           
                                        </tr>
                                         

                                        <tr>
                                            <td class="style8">
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="Submit" ValidationGroup="Submit"
                                                    OnClick="btnSubmit_Click" />
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        
                               </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
