<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="IPA1.AdminLab.NewsDetail" %>

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
        .style4
        {
            width: 28px;
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
                    News<small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvNews" runat="server">
            <br />
            <asp:View ID="vNews" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">News</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>News</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                <div class="btn-group">
                                                    <asp:LinkButton ID="btnAddNews" runat="server" class="btn btn-info" OnClick="btnAddNews_Click">
                                                    <i class="icon-plus icon-white"></i>
                                                    Add News
                                                    
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
                                            <asp:GridView ID="gvNews" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                ShowFooter="True" OnPageIndexChanging="gvNews_PageIndexChanging" DataKeyNames="News_ID"
                                                OnRowCommand="gvNews_RowCommand" OnSorting="gvNews_Sorting" AllowSorting="True"
                                                CellPadding="4" ForeColor="#333333" GridLines="None" class="table table-striped table-hover"
                                                PageSize="5">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="News ID" SortExpression="News_ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNews_ID" runat="server" Text='<%#Eval("News_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="News Title" SortExpression="NewsTitle">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNewsTitle" runat="server" Text='<%#Eval("NewsTitle") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                      <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("StartDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                  
                                                    <asp:TemplateField HeaderText="Close Date" SortExpression="CloseDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCloseDate" runat="server" Text='<%#Eval("CloseDate","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnView" runat="server" Text="View" class="btn btn-info" CommandName="View"
                                                                CommandArgument='<%#Eval("News_ID") %>'></asp:Button>
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
    <asp:View ID="vNewsDetail" runat="server">
        <ul class="breadcrumb">
            <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
            </li>
            <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
            <li>
                <asp:LinkButton ID="lbNewss" runat="server" OnClick="lbNewss_Click">Newss</asp:LinkButton>
                <span class="divider">&nbsp;</span> </li>
            <li><a href="#">News Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                    <i class="icon-reorder"></i>News Detail</h4>
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
                                                        <asp:Label ID="lblNews_ID" runat="server" Text="News ID"></asp:Label>
                                                        
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNews_ID" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style4">

                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEntryDateTime" runat="server" Text="Entry DateTime"></asp:Label>
                                                        
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEntryDateTime" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style4">

                                                    </td>
                                                </tr>
                                               
                                               <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblNewsTitle" runat="server" Text="News Title"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNewsTitle" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="style4">

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                            ControlToValidate="txtNewsTitle" ErrorMessage="*" ForeColor="Red" 
                                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>

                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblNewsDescription" runat="server" Text="News Description"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtNewsDescription" runat="server"  Height="130px" 
                                                            TextMode="MultiLine" Width="210px"></asp:TextBox>
                                                    </td>
                                                    <td class="style4">

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                            ControlToValidate="txtNewsDescription" ErrorMessage="*" ForeColor="Red" 
                                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>

                                                    </td>
                                                </tr>
                                                     <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblStartDate" runat="server" Text="Start Date"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtStartDate" runat="server" AutoPostBack="True" 
                                                            ontextchanged="txtStartDate_TextChanged"></asp:TextBox>
                                                         <cc:CalendarExtender ID="CalendarExtender_StartDate" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                            TargetControlID="txtStartDate">
                                                        </cc:CalendarExtender>
                                                 
                                                    </td>
                                                    <td class="style4">

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                            ControlToValidate="txtStartDate" ErrorMessage="*" ForeColor="Red" 
                                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>

                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblCloseDate" runat="server" Text="Close Date"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCloseDate" runat="server"></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender_CloseDate" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                            TargetControlID="txtCloseDate">
                                                        </cc:CalendarExtender>
                                                 
                                                    </td>
                                                    <td class="style4">

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                            ControlToValidate="txtCloseDate" ErrorMessage="*" ForeColor="Red" 
                                                            ValidationGroup="Submit"></asp:RequiredFieldValidator>

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
                                                &nbsp;<asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click" 
                                                OnClientClick="Confirm()" class="btn btn-primary">
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
            if (confirm("Are you sure you want to delete the record?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
