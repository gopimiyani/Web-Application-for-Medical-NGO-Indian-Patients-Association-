<%@ Page Title="" Language="C#" MasterPageFile="~/VolunteerLab/Volunteer.Master"
    AutoEventWireup="true" CodeBehind="~/VolunteerLab/ViewTask.aspx.cs" Inherits="IPA1.VolunteerLab.ViewTask" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 262px;
        }
        .style2
        {
            width: 262px;
            height: 52px;
        }
        .style3
        {
            height: 32px;
        }
        .style4
        {
            height: 35px;
        }
        .style6
        {
            height: 52px;
        }
        
        input[type="text"]
        {
            width: 290px;
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
        <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
        --%>
        <asp:MultiView ID="mvTask" runat="server">
            <br />
            <asp:View ID="vTask" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
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
                                <%--  <div id="divPendingTasks" runat="server">--%>
                                <div class="widget">
                                    <div class="widget-title">
                                        <h4>
                                            <i class="icon-reorder"></i>Pending Tasks</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                              
                                            </div>
                                            <div class="space15">
                                            </div>
                                            <%--             <div class="widget-body">
                                            --%>
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
                                                        <asp:Label ID="lblRecPerPage" runat="server" Text="records per page"></asp:Label>
                                                    </div>
                                                </div>
                                            
                                            </div>
                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                BackColor="White" CellPadding="4" GridLines="Horizontal" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid"
                                                PageSize="5" OnSorting="GridView1_Sorting" AllowSorting="True" class="table table-striped table-hover">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Task" SortExpression="Subject">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTaskID" runat="server" Text='<%#Eval("Task_ID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                                      <asp:Label ID="lblNew" runat="server" Text="New" CssClass="label label-important"
                                                        Visible='<%# (bool)Eval("NFNew")%>'>
                                                    </asp:Label>
                                                        <asp:Label ID="lblUpdate" runat="server" Text="Updated" CssClass="label label-important"
                                                        Visible='<%# (bool)Eval("NFUpdate")%>'>
                                                    </asp:Label>
                                                        <asp:Label ID="lblNearerTask" runat="server" Text="Nearer Task" CssClass="label label-important"
                                                        Visible='<%# (bool)Eval("NFNearerTask")%>'>
                                                    </asp:Label>
                                                    
                                                    
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--    <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                                    --%>
                                                    <asp:TemplateField HeaderText="Priority" SortExpression="Priority">
                                                        <ItemTemplate>
                                                            <div class="label label-<%#Eval("Priority") %>">
                                                                <asp:Label ID="lblPriority" runat="server" Text='<%#Eval("Priority") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assigned Date" SortExpression="EntryDateTime">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssignedDate" runat="server" Text='<%#Eval("EntryDateTime","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Completion Date" SortExpression="CompletionDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCompletionDate" runat="server" Text='<%#Eval("CompletionDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                       
                                                      
                                                        </ItemTemplate>
                                                    
                                                    </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="Command">
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
                                            <br />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END SAMPLE TABLE widget-->
                        <!-- BEGIN EXAMPLE TABLE widget-->
                        <%--     <div id="divInProgressedTasks" runat="server">--%>
                        <!-- BEGIN ADVANCED TABLE widget-->
                        <div class="row-fluid">
                            <div class="span12">
                                <!-- BEGIN EXAMPLE TABLE widget-->
                                <div class="widget">
                                    <div class="widget-title">
                                        <h4>
                                            <i class="icon-reorder"></i>InProgressed Tasks</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                              
                                            </div>
                                            <div class="space15">
                                            </div>
                                            <%--             <div class="widget-body">
                                            --%>
                                            <div class="row-fluid">
                                                <div class="span6">
                                                    <div class="dataTables_length">
                                                        <asp:DropDownList ID="ddlRecPerPage2" CssClass="input-small m-wrap" runat="server"
                                                            OnSelectedIndexChanged="ddlRecPerPage2_SelectedIndexChanged" AutoPostBack="True">
                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:Label ID="Label1" runat="server" Text="records per page"></asp:Label>
                                                    </div>
                                                </div>
                                              <%--  <div class="span6">
                                                    <div class="dataTables_filter">
                                                        <asp:Label ID="Label2" runat="server" Text="Search"></asp:Label>
                                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>--%>
                                            </div>
                                            <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                BackColor="White" CellPadding="4" GridLines="Horizontal" OnPageIndexChanging="GridView2_PageIndexChanging"
                                                OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid"
                                                PageSize="5" AllowSorting="True" OnSorting="GridView2_Sorting" class="table table-striped table-hover">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Task" SortExpression="Subject">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTaskID" runat="server" Text='<%#Eval("Task_ID") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                                     &nbsp;&nbsp;
                                                                <asp:Label ID="lblNearerTask" runat="server" Text="Nearer Task" CssClass="label label-important"
                                                        Visible='<%# (bool)Eval("NFNearerTask")%>'>
                                                    </asp:Label>
                                             
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Priority" SortExpression="Priority">
                                                        <ItemTemplate>
                                                            <div class="label label-<%#Eval("Priority") %>">
                                                                <asp:Label ID="lblPriority" runat="server" Text='<%#Eval("Priority") %>'></asp:Label>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assigned Date" SortExpression="EntryDateTime">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssignedDate" runat="server" Text='<%#Eval("EntryDateTime","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Completion Date" SortExpression="CompletionDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCompletionDate" runat="server" Text='<%#Eval("CompletionDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Command">
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
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END SAMPLE TABLE widget-->
                    <!-- BEGIN EXAMPLE TABLE widget-->
                    <%--       <div id="divCompletedTasks" runat="server">--%>
                    <div class="widget">
                        <div class="widget-title">
                            <h4>
                                <i class="icon-reorder"></i>Completed Tasks</h4>
                            <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                class="icon-remove"></a></span>
                        </div>
                        <div class="widget-body">
                            <div class="portlet-body">
                                <div class="clearfix">
                                    
                                </div>
                                <div class="space15">
                                </div>
                                <%--             <div class="widget-body">
                                --%>
                                <div class="row-fluid">
                                    <div class="span6">
                                        <div class="dataTables_length">
                                            <asp:DropDownList ID="ddlRecPerPage3" CssClass="input-small m-wrap" runat="server"
                                                OnSelectedIndexChanged="ddlRecPerPage3_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="Label3" runat="server" Text="records per page"></asp:Label>
                                        </div>
                                    </div>
                                 <%--   <div class="span6">
                                        <div class="dataTables_filter">
                                            <asp:Label ID="Label4" runat="server" Text="Search"></asp:Label>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                </div>
                                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    BackColor="White" CellPadding="4" GridLines="Horizontal" OnPageIndexChanging="GridView3_PageIndexChanging"
                                    OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid"
                                    PageSize="5" AllowSorting="True" OnSorting="GridView3_Sorting" class="table table-striped table-hover">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Task" SortExpression="Subject">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTaskID" runat="server" Text='<%#Eval("Task_ID") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--    <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                        --%>
                                        <asp:TemplateField HeaderText="Priority" SortExpression="Priority">
                                            <ItemTemplate>
                                                <div class="label label-<%#Eval("Priority") %>">
                                                    <asp:Label ID="lblPriority" runat="server" Text='<%#Eval("Priority") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Assigned Date" SortExpression="EntryDateTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssignedDate" runat="server" Text='<%#Eval("EntryDateTime","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Completion Date" SortExpression="CompletionDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCompletionDate" runat="server" Text='<%#Eval("CompletionDate","{0:dd/MM/yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Command">
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
                            </div>
                        </div>
                    </div>
                </div>
    </div>
    <!-- END SAMPLE TABLE widget-->
    </asp:View>
    <br />
    <asp:View ID="vTaskDetail" runat="server">
        <ul class="breadcrumb">
            <li><a href="Dashboard.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
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
                                    <div class="space15">
                                    </div>
                                    <%--               <asp:UpdatePanel>
                                                        <ContentTemplate>
                                                        
                                    --%>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                        <ContentTemplate>
                                            <table class="">
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtTask_ID" runat="server" Visible="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Assigned By
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtFrom" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Assigned On
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtAssignedOn" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Task
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtTask" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Detail
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtDetail" runat="server" Enabled="False" Height="100px" TextMode="MultiLine"
                                                            Width="290px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Priority
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtPriority" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Completion Date
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtCDate" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        Completion Time
                                                    </td>
                                                    <td class="style6">
                                                        <div class="form-group form-inline">
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
                                                        </div>
                                                    </td>
                                                    <td class="style6">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Status
                                                    </td>
                                                    <td class="style3">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-grid_dropdown" Height="27px"
                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                            <asp:ListItem>Pending</asp:ListItem>
                                                            <asp:ListItem>In Progress</asp:ListItem>
                                                            <asp:ListItem>Complete</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvStatus" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        Work Completion In %
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtWCP" runat="server"></asp:TextBox>
                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtACDate"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        --%>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvWCP" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtACDate"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                --%>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblACDate" runat="server" Text="Actual Completion Date"></asp:Label>
                                                    </td>
                                                    <td class="style3">

                                                     <asp:TextBox ID="txtACDate" runat="server" ></asp:TextBox>
                                                     <cc:CalendarExtender ID="CalendarExtender_ACDate" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                            TargetControlID="txtACDate">
                                                            </cc:CalendarExtender>

                                                        <asp:Label ID="lblcvACDate" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                      <%--  <asp:TextBox ID="txtACDate" runat="server" OnTextChanged="txtACDate_TextChanged"></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender_ACDate" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                            TargetControlID="txtACDate">
                                                        </cc:CalendarExtender>--%>
                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtACDate"
                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        --%>
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblACTime" runat="server" Text="Actual Completion Time"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <div class="form-group form-inline">
                                                            <asp:DropDownList ID="ddlHour1" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp;
                                                            <asp:DropDownList ID="ddlMinute1" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                            &nbsp;&nbsp;
                                                            <asp:DropDownList ID="ddlAMPM1" runat="server" Height="28px" Width="90px" CssClass="form-grid_dropdown">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvACTime" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                
                                                 <tr>
                                                    <td class="style1">
                                                        Remarks
                                                    </td>
                                                    <td class="style3">
                                                        <br />
                                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Height="80px" Width="290px"
                                                            MaxLength="150"></asp:TextBox>
                                                  
                                                    </td>
                                                    <td>
                                                          <asp:Label ID="lblcvtxtRemarks" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>

                                            </table>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlStatus" />
                                            <asp:AsyncPostBackTrigger ControlID="txtWCP" />
                                            <asp:AsyncPostBackTrigger ControlID="txtACDate" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:Panel ID="pRequestAttachment" runat="server" Visible="false">
                                        <table>
                                            <tr>
                                                <td class="style1">
                                                    <br />
                                                    Attachment
                                                </td>
                                                <td class="style3">
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
                                    <table>
                                        <tr>
                                            <td class="style1">
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td class="style4">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Submit"
                                                    OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                                                &nbsp;<asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset"
                                                    CssClass="btn btn-primary" />
                                                &nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                                    CssClass="btn btn-primary" />
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
    <script>
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
</asp:Content>
