<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="AssignTask.aspx.cs" Inherits="IPA1.AdminLab.AssignTask1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 204px;
        }
        input[type="text"]
        {
            width: 290px;
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
    </style>

    <script type="text/javascript">
    
 function SetTarget() {
     document.forms[0].target = "_blank";
 }
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
                    Tasks <small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <ul class="breadcrumb">
            <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
            </li>
            <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
            <li><a href="ViewTask.aspx">Tasks</a><span class="divider">&nbsp;</span></li>
            <li><a href="#">Assign Task</a><span class="divider-last">&nbsp;</span></li>
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
                                    <i class="icon-reorder"></i>Assign Task</h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                    class="icon-remove"></a></span>
                            </div>
                            <div class="widget-body">
                                <div class="portlet-body">
                                    <div class="clearfix">
                                        <div class="btn-group pull-right">
                                            <button class="btn dropdown-toggle" data-toggle="dropdown" tabindex="1">
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
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <table class="">
                                                <tr>
                                                    <td class="style1">
                                                        Assign To Volunteer<span class="style2">*</span>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:DropDownList ID="ddlVName" runat="server" CssClass="form-grid_dropdown" AppendDataBoundItems="True"
                                                            Height="27px" AutoPostBack="True" OnSelectedIndexChanged="ddlVName_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblrfvVName" runat="server" ForeColor="Red" Text="Select Volunteer Name"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Subject<span class="style2">*</span>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtSubject" runat="server" Width="290px" Height="" MaxLength="50" CssClass="inputtext"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubject"
                                                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Detail<span class="style2">*</span>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtDetail" runat="server" Height="130px" TextMode="MultiLine" Width="290px"
                                                            MaxLength="500"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDetail"
                                                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <%--        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/IdProof/doc.gif" 
                                                Width="150px" Height="150px" onclick="ImageButton1_Click"/>
                                                    --%>
                                                    <td class="style1">
                                                        Priority<span class="style2">*</span>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-grid_dropdown" Height="27px"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlPriority_SelectedIndexChanged">
                                                            <asp:ListItem>--Select Priority--</asp:ListItem>
                                                            <asp:ListItem>High</asp:ListItem>
                                                            <asp:ListItem>Low</asp:ListItem>
                                                            <asp:ListItem>Medium</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="style6">
                                                        <asp:Label ID="lblrfvPriority" runat="server" ForeColor="Red" Text="Select Priority"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Completion Date<span class="style2">*</span>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtCDate" runat="server" Height="" Width="" CssClass="inputtext"></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                            TargetControlID="txtCDate">
                                                        </cc:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCDate"
                                                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        <asp:Label ID="lblcvCDate" runat="server" ForeColor="Red" Text="Completion Date can't be in the Past!"
                                                            Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Completion Time<span class="style2">*</span>
                                                    </td>
                                                    <td class="style3">
                                                        <div class="form-group form-inline">
                                                            <asp:DropDownList ID="ddlHour" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                           &nbsp;&nbsp;
                                                            <asp:DropDownList ID="ddlMinute" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                           &nbsp;&nbsp;
                                                            <asp:DropDownList ID="ddlAMPM" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvCTime" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        &nbsp;
                                                    </td>
                                                    <td class="style3">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlPriority" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlVName" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:Panel ID="pRequestAttachment" runat="server" Visible="false">
                                        <table>
                                            <tr>
                                                <td class="style1">
                                                    Attachment
                                                </td>
                                                <td class="style3">
                                                    <ul class="unstyled">
                                                        <li><i class="icon-paper-clip"></i>
                                                            <asp:LinkButton ID="lbRequestDetail" runat="server" OnClick="lbRequestDetail_Click" OnClientClick = "SetTarget();">Request Detail</asp:LinkButton>
                                                        </li>
                                                    </ul>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <table>
                                        <tr>
                                            <td class="style1">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <br />
                                                <asp:Button ID="Button3" runat="server" class="btn btn-primary" Text="Submit" ValidationGroup="Submit"
                                                    OnClick="btnSubmit_Click" />
                                                &nbsp;<asp:Button ID="Button5" runat="server" class="btn btn-primary" Text="Reset"
                                                    OnClick="btnReset_Click" />
                                                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                    CssClass="btn btn-primary" />
                                                &nbsp;
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
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
</asp:Content>
