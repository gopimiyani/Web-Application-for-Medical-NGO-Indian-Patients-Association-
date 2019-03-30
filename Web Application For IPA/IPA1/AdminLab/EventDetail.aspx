<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="EventDetail.aspx.cs" Inherits="IPA1.AdminLab.EventDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        .style3
        {
            width: 188px;
        }
        .style6
        {
            width: 167px
        }
        .style7
        {
            width: 176px
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
                    Events<small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvEvent" runat="server">
            <br />
            <asp:View ID="vEvent" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Events</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Events</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                <div class="btn-group">
                                                    <asp:LinkButton ID="btnRegisterEvent" runat="server" class="btn btn-info" OnClick="btnRegisterEvent_Click">
                                                    <i class="icon-plus icon-white"></i>
                                                    Register Event
                                                    
                                                    </asp:LinkButton>
                                                </div>
                                              
                                            </div>
                                            <div class="space15">
                                            </div>
                                            <%--             <div class="widget-body">
                                            --%>
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
                                                        <asp:TextBox ID="txtSearch" runat="server" onkeyup="RefreshUpdatePanel();" AutoPostBack="true"
                                                            OnTextChanged="txtSearch_TextChanged" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--         <asp:UpdatePanel ID="Update" runat="server">
                                                <ContentTemplate>
                                            --%>
                                            <asp:GridView ID="gvEvent" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                ShowFooter="True" OnPageIndexChanging="gvEvent_PageIndexChanging" DataKeyNames="Event_ID"
                                                OnRowCommand="gvEvent_RowCommand" OnSorting="gvEvent_Sorting" AllowSorting="True"
                                                CellPadding="4" ForeColor="#333333" GridLines="None" class="table table-striped table-hover"
                                                PageSize="5">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Event ID" SortExpression="Event_ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEvent_ID" runat="server" Text='<%#Eval("Event_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Event Name" SortExpression="EventName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEventName" runat="server" Text='<%#Eval("EventName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Event Date" SortExpression="EventDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEventDate" runat="server" Text='<%#Eval("EventDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Time Duration" SortExpression="">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStartTime" runat="server" Text='<%#Eval("StartTime")+" To "%>'></asp:Label>
                                                            <asp:Label ID="lblEndTime" runat="server" Text='<%#Eval("EndTime")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Event Type" SortExpression="EventType">
                                                        <ItemTemplate>
                                                            <div class="label label-Approved">
                                                                <asp:Label ID="lblUpcomingEvent" runat="server" Text='<%#Eval("EventType") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnView" runat="server" Text="View" class="btn btn-info" CommandName="View"
                                                                CommandArgument='<%#Eval("Event_ID") %>'></asp:Button>
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
                                            <%--         </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="txtSearch" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            --%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END SAMPLE TABLE widget-->
                </div>
    </div>
    <!-- END SAMPLE TABLE widget-->
    <!--end-->
    </asp:View>
    <asp:View ID="vEventDetail" runat="server">
        <ul class="breadcrumb">
            <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
            </li>
            <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
            <li>
                <asp:LinkButton ID="lbEvents" runat="server" OnClick="lbEvents_Click">Events</asp:LinkButton>
                <span class="divider">&nbsp;</span> </li>
            <li><a href="#">Event Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                    <i class="icon-reorder"></i>Event Detail</h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                    class="icon-remove"></a></span>
                            </div>
                            <div class="widget-body">
                                <div class="portlet-body">
                                    <div class="clearfix">
                                       
                                    </div>
                                    <div class="space10">
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table class="">
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEvent_ID" runat="server" Text="Event ID"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEvent_ID" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style7">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEntryDate" runat="server" Text="Entry Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEntryDate" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style7">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventName" runat="server" Text="Event Name"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="style7">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEventName"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventDescription" runat="server" Text="Event Description"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEventDescription" runat="server" TextMode="MultiLine" Height="95px"
                                                            Width="210px"></asp:TextBox>
                                                    </td>
                                                    <td class="style7">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEventDescription"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventDate" runat="server" Text="Event Date"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEventDate" runat="server"></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender_EventDate" runat="server" Format="dd-MM-yyyy"
                                                            Enabled="True" TargetControlID="txtEventDate">
                                                        </cc:CalendarExtender>
                                                    </td>
                                                    <td class="style7">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEventDate"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
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
                                                    <td class="style7">
                                                      <asp:Label ID="lblcvStartTime" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    </td>
                                                </tr>
                                            
                                                <tr style="height:52px;">
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventEndTime" runat="server" Text="Event EndTime"></asp:Label>
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
                                                    <td class="style7">
                                                        
                                                        <asp:Label ID="lblcvEndTime" runat="server" ForeColor="#FF3300"></asp:Label>
                                                    
                                                    </td>
                                                </tr>
                                            
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEventLocation" runat="server" Text="Event Location"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEventLocation" runat="server" TextMode="MultiLine" Height="95px"
                                                            Width="210px"></asp:TextBox>
                                                    </td>
                                                    <td class="style7">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEventLocation"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
                                                &nbsp;<asp:LinkButton ID="btnDelete" runat="server" OnClientClick="Confirm()" OnClick="btnDelete_Click"
                                                    class="btn btn-primary">
                                                 <i class="icon-ban-circle"></i>
                                                Delete
                                                </asp:LinkButton>
                                                &nbsp;<asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" class="btn btn-primary">
                                                 <i class="icon-ban-circle"></i>
                                                Cancel
                                                </asp:LinkButton>
                                            </td>
                                            <td>
                                                &nbsp;
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
    </asp:MultiView> </div>
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
