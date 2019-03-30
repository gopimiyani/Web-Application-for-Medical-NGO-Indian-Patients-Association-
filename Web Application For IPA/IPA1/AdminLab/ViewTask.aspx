<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ViewTask.aspx.cs" Inherits="IPA1.AdminLab.AssignTask" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style5
        {
            width: 253px;
        }
        .style7
        {
            height: 42px;
        }
        .style8
        {
            width: 237px;
        }
        .style9
        {
            width: 253px;
            height: 29px;
        }
        .style10
        {
            width: 211px;
            height: 29px;
        }
        .style11
        {
            width: 166px;
        }
        .form-inline
        {
            width: 288px;
        }
        input[type="text"]
        {
            width: 290px;
        }
        .style14
        {
            width: 252px;
        }
        .style15
        {
            width: 32px;
        }
        .style16
        {
            width: 283px;
        }
        
        input[readonly]
{
    cursor:not-allowed;
    background-color:White;
}


input[disabled]
{cursor:not-allowed;background-color:#eee}

    </style>
    <script type="text/javascript">
        function RefreshUpdatePanel() {
            __doPostBack('<%= txtSearch.ClientID %>', '');
        };
    </script>

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
        <asp:MultiView ID="mvTask" runat="server">
            <br />
            <asp:View ID="vTask" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
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
                                                    <asp:LinkButton ID="btnAssign" runat="server" class="btn btn-info" 
                                                        onclick="btnAssign_Click">
                                                    <i class="icon-plus icon-white"></i>
                                                    Assign
                                                    
                                                    </asp:LinkButton>
                                                </div>
                                                
                                            </div>
                                            <div class="space15">
                                            </div>
                                         
                                            <div class="row-fluid">
                                                <div class="span6">
                                                    <div class="dataTables_length">
                                                        <asp:DropDownList ID="ddlRecPerPage" CssClass="input-small m-wrap" runat="server" OnSelectedIndexChanged="ddlRecPerPage_SelectedIndexChanged" AutoPostBack="True">
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
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search" Visible="false" ></asp:Label>
                                                        <asp:TextBox ID="txtSearch" runat="server" onkeyup="RefreshUpdatePanel();" AutoPostBack="true"
                                                            OnTextChanged="txtSearch_TextChanged" Visible="false" ></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--         <asp:UpdatePanel ID="Update" runat="server">
                                                <ContentTemplate>
                                            --%>
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                ShowFooter="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="Task_ID"
                                                OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting" AllowSorting="True"
                                                CellPadding="4" ForeColor="#333333" GridLines="None" class="table table-striped table-hover"
                                                PageSize="5">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Task ID" SortExpression="Task_ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTaskId" runat="server" Text='<%#Eval("Task_ID") %>'></asp:Label>
                                                      &nbsp;&nbsp;
                                                                   <asp:Label ID="lblNew" runat="server" Text="completed" CssClass="label label-important"
                                                        Visible='<%# (bool)Eval("NFComplete")%>'>
                                                    </asp:Label>

                                                     <asp:Label ID="Label2" runat="server" Text="In Progress" CssClass="label label-important"
                                                        Visible='<%# (bool)Eval("NFInProgress")%>'>
                                                    </asp:Label>


                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtTaskId" runat="server" Enabled="false" Text='<%#Eval("Task_ID") %>'> </asp:TextBox>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Task" SortExpression="Subject">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assigned To" SortExpression="FirstName">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assigned Date" SortExpression="EntryDateTime">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssignedDate" runat="server" Text='<%#Eval("EntryDateTime","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                        <ItemTemplate>
                                                            <div class="label label-<%#Eval("Status") %>">
                                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                                            </div>


                                                      


                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnView" runat="server" Text="View" class="btn btn-primary" CommandName="View"
                                                                CommandArgument='<%#Eval("Task_ID") %>'></asp:Button>
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
                    <!-- Tasks having extended completion date -->
                    <!-- BEGIN ADVANCED TABLE widget-->
                    <!-- BEGIN EXAMPLE TABLE widget-->
                    <div class="space10">
                    </div>
                    <div class="widget">
                        <div class="widget-title">
                            <h4>
                                <i class="icon-reorder"></i>Tasks Having Extended Completion Date</h4>
                            <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                class="icon-remove"></a></span>
                        </div>
                        <div class="widget-body">
                            <div class="portlet-body">
                                <div class="space15">
                                </div>
                                <div class="row-fluid">
                                    <div class="span6">
                                        <div class="dataTables_length">
                                            <asp:DropDownList ID="ddlRecPerPage1" CssClass="input-small m-wrap" runat="server"
                                                OnSelectedIndexChanged="ddlRecPerPage1_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="Label1" runat="server" Text="records per page"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="span6">
                                        <div class="dataTables_filter">
                                            <asp:Label ID="lblSearch1" runat="server" Text="Search" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtSearch1" runat="server" onkeyup="RefreshUpdatePanel();" AutoPostBack="true"
                                                OnTextChanged="txtSearch1_TextChanged" Visible="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <%--     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                --%>
                                <asp:GridView ID="gvExtendedTask" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    ShowFooter="True" OnPageIndexChanging="gvExtendedTask_PageIndexChanging" DataKeyNames="Task_ID"
                                    OnRowCommand="gvExtendedTask_RowCommand" OnSorting="gvExtendedTask_Sorting" AllowSorting="True"
                                    CellPadding="4" ForeColor="#333333" GridLines="None" class="table table-striped table-hover"
                                    PageSize="5">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Task ID" SortExpression="Task_ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaskId" runat="server" Text='<%#Eval("Task_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtTaskId" runat="server" Enabled="false" Text='<%#Eval("Task_ID") %>'> </asp:TextBox>
                                            </EditItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Task" SortExpression="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Assigned To" SortExpression="FirstName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="Assigned Date" SortExpression="EntryDateTime">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAssignedDate" runat="server" Text='<%#Eval("EntryDateTime","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                               </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Completion Date" SortExpression="CompletionDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompletionDate" runat="server" Text='<%#Eval("CompletionDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                            <ItemTemplate>
                                                <div class="label label-<%#Eval("Status") %>">
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Over Days" SortExpression="Days">
                                            <ItemTemplate>
                                                <div class="label label-important">
                                                    <asp:Label ID="lblDays" runat="server" Text='  <%#Eval("Days")+" Days"%>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderText="Extended Days" SortExpression="Days">
                                            <ItemTemplate>
                                                <div class="label label-important">
                                                    <asp:Label ID="lblExtendedDays" runat="server" Text='  <%#Eval("ExtendedDays")%> '></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            </EditItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:Button ID="btnView" runat="server" Text="View" class="btn btn-primary" CommandName="View"
                                                    CommandArgument='<%#Eval("Task_ID") %>' OnClick="btnView_Click1"></asp:Button>
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
                                <%--                 </ContentTemplate>
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
    <!--end-->
    </div> </asp:View>
    <asp:View ID="vTaskDetail" runat="server">
        <ul class="breadcrumb">
            <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
            </li>
            <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
            <li>
                <asp:LinkButton ID="lbTasks" runat="server" OnClick="lbTasks_Click">Tasks</asp:LinkButton>
                <span class="divider">&nbsp;</span> </li>
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
                                       
                                    </div>
                                    <div class="space10">
                                    </div>
                                    <div runat="server" id="divTaskDetail">
                                        <asp:Panel ID="pTaskDetail" runat="server">
                                     
                                        <table class="">
                                          <tr>
                                                <td class="style9">
                                                    Task ID
                                                </td>
                                                <td class="style10">
                                                    <asp:TextBox ID="txtTask_ID" runat="server" Enabled="False" ></asp:TextBox>
                                                </td>
                                            </tr>
                                           
                                            <tr>
                                                <td class="style9">
                                                    Assigned On
                                                </td>
                                                <td class="style10">
                                                    <asp:Label ID="lblAssignedOn" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Assigned To
                                                </td>
                                                <td class="style11">
                                                    <asp:DropDownList ID="ddlVName" runat="server" CssClass="disable" AutoPostBack="True"
                                                        OnSelectedIndexChanged="ddlVName_SelectedIndexChanged" Enabled="False">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Task
                                                </td>
                                                <td class="style11">
                                                    <asp:TextBox ID="txtSubjectA" runat="server" Width="" Enabled="False" MaxLength="50"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvTask" runat="server" ControlToValidate="txtSubjectA"
                                                        ErrorMessage="*" ValidationGroup="Submit" SetFocusOnError="True" 
                                                        style="color: #FF0000"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Detail
                                                </td>
                                                <td class="style11">
                                                    <asp:TextBox ID="txtDetail" runat="server" Height="98px" TextMode="MultiLine" Width="290px"
                                                        Enabled="False" MaxLength="500"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvDetail" runat="server" ControlToValidate="txtDetail"
                                                        ErrorMessage="*" ValidationGroup="Submit" SetFocusOnError="True" 
                                                        style="color: #FF0000"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Priority
                                                </td>
                                                <td class="style11">
                                                    <asp:DropDownList ID="ddlPriority" runat="server" Width="" Height="26px" Enabled="False">
                                                        <asp:ListItem>High</asp:ListItem>
                                                        <asp:ListItem>Low</asp:ListItem>
                                                        <asp:ListItem>Medium</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Status
                                                </td>
                                                <td class="style11">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" Height="26px" Enabled="False" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                        <asp:ListItem>Pending</asp:ListItem>
                                                        <asp:ListItem>In Progress</asp:ListItem>
                                                        <asp:ListItem>Complete</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Completion Date
                                                </td>
                                                <td class="style11">
                                                    <asp:TextBox ID="txtCDate" runat="server" Height="21px" Width="" Enabled="False"></asp:TextBox>
                                                    <cc:CalendarExtender ID="CalendarExtender_CDate" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                        TargetControlID="txtCDate">
                                                    </cc:CalendarExtender>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfvCDate" runat="server" ControlToValidate="txtCDate"
                                                        ErrorMessage="*" ValidationGroup="Submit" SetFocusOnError="True" 
                                                        style="color: #FF0000"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="lblcvCDate" runat="server" ForeColor="Red" Text="Completion Date can't be in the Past!"
                                                        Visible="False"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Completion Time
                                                </td>
                                                <td class="style11">
                                                   
                                                        <asp:DropDownList ID="ddlHour" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                        <asp:DropDownList ID="ddlMinute" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                        <asp:DropDownList ID="ddlAMPM" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                   
                                                </td>
                                                <td class="style7">
                                                    <asp:Label ID="lblcvCTime" runat="server" ForeColor="#FF3300"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Extended Days
                                                </td>
                                                <td class="style11">
                                                    <asp:TextBox ID="txtExtendedDays" runat="server" Width="" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Work Completion In %
                                                </td>
                                                <td class="style11">
                                                    <asp:TextBox ID="txtWCP" runat="server" Width="" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Remarks
                                                </td>
                                                <td class="style11">
                                                    <asp:TextBox ID="txtRemarks" runat="server" Width="290px" TextMode="MultiLine" Height="80px"
                                                     Enabled="False" OnTextChanged="txtRemarks_TextChanged"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Actual Completion Date
                                                </td>
                                                <td class="style11">
                                                    <asp:TextBox ID="txtACDate" runat="server" Width="" Enabled="False"></asp:TextBox>
                                                    <cc:CalendarExtender ID="CalendarExtender_ACDate" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                        TargetControlID="txtACDate">
                                                    </cc:CalendarExtender>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style5">
                                                    Actual Completion Time
                                                </td>
                                                <td class="style11">
                                                    <asp:DropDownList ID="ddlHour1" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                        <asp:DropDownList ID="ddlMinute1" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                                        &nbsp;&nbsp;
                                                        <asp:DropDownList ID="ddlAMPM1" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown"
                                                            Enabled="False">
                                                        </asp:DropDownList>
                                             </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                           </asp:Panel>
                                        <asp:Panel ID="pRequestAttachment" runat="server" Visible="false">
                                            <table>
                                                <tr>
                                                    <td class="style5">
                                                        <br />
                                                        Attachment
                                                    </td>
                                                    <td class="style11">
                                                        <br />
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
                                    </div>
                                    <table>
                                        <tr>
                                            <td class="style5">
                                                <br />
                                            </td>
                                            <td class="style16">


                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td class="style16">
                                                <asp:Button ID="btnUpdate" runat="server" Text="Submit" OnClick="btnUpdate_Click"
                                                    CssClass="btn btn-primary" ValidationGroup="Submit" />
                                                &nbsp;&nbsp;&nbsp;
                                                
                                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" 
                                                    OnClick="btnDelete_Click" OnClientClick="Confirm()" Text="Delete" />
                                                &nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" 
                                                    OnClick="btnCancel_Click" Text="Cancel" />
                                                
                                                </td>
                                            <td class="style15">
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
