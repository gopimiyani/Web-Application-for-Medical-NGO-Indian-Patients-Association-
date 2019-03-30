<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="EventForm.aspx.cs" Inherits="IPA1.AdminLab.EventForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link rel="stylesheet" type="text/css" href="../assets/bootstrap-timepicker/compiled/timepicker.css" />
<link rel="stylesheet" type="text/css" href="../assets/clockface/css/clockface.css" />
    <style type="text/css">
        .style1
        {
            width: 204px;
        }
        input[type="text"]
        {
            width: 210px;
        }
        .style2
        {
            color: #FF3300;
        }
        input[readonly]
        {
            cursor: default;
            background-color: White;
        }
        .style3
        {
            width: 188px;
        }
        .style5
        {
            width: 113px;
        }
        .style6
        {
            width: 175px;
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
                    Events <small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <ul class="breadcrumb">
            <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
            </li>
            <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
            <li><a href="EventDetail.aspx">Event Detail</a><span class="divider">&nbsp;</span></li>
            <li><a href="#">Register an Event</a><span class="divider-last">&nbsp;</span></li>
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
                                    <i class="icon-reorder"></i>Register an Event</h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                    class="icon-remove"></a></span>
                            </div>
                            <div class="widget-body">
                                <div class="portlet-body">
                                    <div class="clearfix">
                                        
                                    </div>
                                    <div class="space10">
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="">
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventName" runat="server" Text="Event Name"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="style6">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="txtEventName" ErrorMessage="*" ForeColor="Red" 
                                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventDescription" runat="server" Text="Event Description"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEventDescription" runat="server" TextMode="MultiLine"
                                                            Height="95px" Width="210px"></asp:TextBox>
                                                    </td>
                                                    <td class="style6">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="txtEventDescription" ErrorMessage="*" ForeColor="Red" 
                                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventDate" runat="server" Text="Event Date"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEventDate" runat="server"></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                            TargetControlID="txtEventDate">
                                                        </cc:CalendarExtender>
                                                    </td>
                                                    <td class="style6">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                            ControlToValidate="txtEventDate" ErrorMessage="*" ForeColor="Red" 
                                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr style="height:30px;">
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventStartTime" runat="server" Text="Event StartTime"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                            <div class="form-group form-inline">
                                                            <asp:DropDownList ID="ddlHour" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="ddlMinute" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="ddlAMPM" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    
                                                    </td>
                                                    <td class="style6">
                                                      <asp:Label ID="lblcvStartTime" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                </tr>
                                            
                                                <tr style="height:52px;">
                                                    <td class="style1">
                                                        <asp:Label ID="Label1" runat="server" Text="Event EndTime"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                            <div class="form-group form-inline">
                                                            <asp:DropDownList ID="ddlHour1" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="ddlMinute1" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="ddlAMPM1" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    
                                                    </td>
                                                    <td class="style6">
                                                        
                                                        <asp:Label ID="lblcvEndTime" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    
                                                    </td>
                                                </tr>
                                            
                                            
                                            
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventLocation" runat="server" Text="Event Location"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEventLocation" runat="server" TextMode="MultiLine"
                                                            Height="95px" Width="210px"></asp:TextBox>
                                                    </td>
                                                    <td class="style6">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                                            ControlToValidate="txtEventLocation" ErrorMessage="*" ForeColor="Red" 
                                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                 <%--       <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="" />
                                            <asp:AsyncPostBackTrigger ControlID="" />
                                        </Triggers>
                                 --%>   </asp:UpdatePanel>
                                    <table>
                                        <tr>
                                            <td class="style3">
                                            </td>
                                            <td>
                                                <br />
                                                <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Submit"
                                                    class="btn btn-primary">
                                           <i class="icon-ok icon-white"></i>
                                             Submit
                                                </asp:LinkButton>
                                                &nbsp;<asp:LinkButton ID="btnReset" runat="server" OnClick="btnReset_Click" class="btn btn-primary">
                                              <i class="icon-refresh"></i>
                                                 Reset
                                                </asp:LinkButton>
                                                &nbsp;<asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" class="btn btn-primary">
                                              <i class="icon-ban-circle"></i>
                                             Cancel
                                                </asp:LinkButton>
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
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
    <script type="text/javascript" src="../js/scripts.js"></script>
    <script type="text/javascript" src="../js/table-editable.js"></script>

      <script type="text/javascript" src="../assets/bootstrap-timepicker/js/bootstrap-timepicker.js"></script>
  <script type="text/javascript" src="../assets/clockface/js/clockface.js"></script>
    
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
</asp:Content>
