<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true"
    CodeBehind="ReportUser.aspx.cs" Inherits="IPA1.SuperAdmin.ReportUser" %>
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
                    Report of User Detail
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#"></a>Report<span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Report of User Detail</a><span class="divider-last">&nbsp;</span></li>
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
                            Report of User Detail</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                               
                            </div>
                            <div class="space15">
                            </div>
                            <table style="">
                                <tr>
                                    <td class="style8">
                                        <asp:Label ID="Label1" runat="server" Text="Select Any Admin"></asp:Label>
                                        <span class="style2"></span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlAName" runat="server" CssClass="form-grid_dropdown" AppendDataBoundItems="True"
                                            Height="27px" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        <asp:Label ID="lblselecttype" runat="server" Text="Select User Type"></asp:Label>
                                        <span class="style2"></span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlselecttype" runat="server" AutoPostBack="True" CssClass="form-grid_dropdown"
                                            Width="224px" ValidationGroup="Submit">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:CustomValidator ID="cvddlselecttype" runat="server" ControlToValidate="ddlselecttype"
                                            OnServerValidate="cvddlselecttype_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        <asp:Label runat="server" Text="JoinDate  From :" ID="lblJoinDateFrom"></asp:Label>
                                        <span class="style2"></span>(dd-MM-YYYY)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJoinDateFrom" runat="server" Width="224px" ValidationGroup="Submit"></asp:TextBox>
                                        <cc:calendarextender id="CalendarExtender" runat="server" format="dd-MM-yyyy" enabled="True"
                                            targetcontrolid="txtJoinDateFrom">
                                                </cc:calendarextender>
                                    </td>
                                    <td class="style8">
                                        &nbsp;&nbsp;
                                        <asp:Label runat="server" Text=" To:" ID="lblJoinDateTo"></asp:Label>
                                        <span class="style2"></span>(dd-MM-YYYY)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJoinDateTo" runat="server" Width="224px" ValidationGroup="Submit"></asp:TextBox>
                                        <asp:Label ID="lblcvJoinDateTo" runat="server" ForeColor="Red" Text="JoinDate(From) can't be greater than JoinDate(To)!"
                                            Visible="False"></asp:Label>
                                        <cc:calendarextender id="CalendarExtender1" runat="server" format="dd-MM-yyyy" enabled="True"
                                            targetcontrolid="txtJoinDateTo">
                                                </cc:calendarextender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Width="224px">
                                            <asp:ListItem>Gujarat</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:CustomValidator ID="cvState" runat="server" ControlToValidate="ddlState" ForeColor="Red"
                                            OnServerValidate="cvState_ServerValidate"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown" Width="224px">
                                            <asp:ListItem>Surat</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:CustomValidator ID="cvCity" runat="server" ControlToValidate="ddlCity" ForeColor="Red"
                                            OnServerValidate="cvCity_ServerValidate"></asp:CustomValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style8">
                                        <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPinCode" runat="server" ValidationGroup="Submit" Width="224px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="rePinCode" runat="server" ControlToValidate="txtPinCode"
                                            ErrorMessage="Invalid PinCode!" ValidationExpression="^[0-9]{1,6}$" ValidationGroup="Submit"
                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                        <br />
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
