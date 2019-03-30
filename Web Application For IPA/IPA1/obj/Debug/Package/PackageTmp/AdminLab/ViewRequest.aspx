<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ViewRequest.aspx.cs" Inherits="IPA1.AdminLab.ViewRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input[type="text"]
        {
            width: 206px;
        }
        
        .style2
        {
            width: 275px;
        }
        
        .style3
        {
            width: 128px;
        }
        .style4
        {
            width: 275px;
        }
        .style6
        {
            width: 149px;
        }
        .style7
        {
            width: 275px;
            height: 169px;
        }
        .style8
        {
            width: 275px;
            height: 146px;
        }
        .style9
        {
            width: 275px;
            height: 62px;
        }
        .style10
        {
            height: 62px;
        }
        .lblselect
        {
         padding: 0px 5px 0px 15px;
         vertical-align: middle;   
        }
        
    </style>
    <script type="text/javascript">
        function RefreshUpdatePanel() {
            __doPostBack('<%= txtSearch.ClientID %>', '');
        };
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
                    Patient Requests
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
            </div>
        </div>
        <asp:MultiView ID="mvRequest" runat="server">
            <asp:View ID="vRequest" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Patient Requests</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
                <!-- END PAGE HEADER-->
                <!-- BEGIN ADVANCED TABLE widget-->
                <div class="row-fluid">
                    <div class="span12">
                        <!-- BEGIN EXAMPLE TABLE widget-->
                        <div class="widget">
                            <div class="widget-title">
                                <h4>
                                    <i class="icon-reorder"></i>Patient Requests</h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                    class="icon-remove"></a></span>
                            </div>
                            <div class="widget-body">
                                <div class="alert alert-info">
                                    <div style="color: Black">
                                        <strong>Note: </strong>
                                        <br />
                                        1. Click New button to make a new patient request.<br />
                                        2. Click View button to view patient request detail.
                                    </div>
                                </div>
                                <div class="portlet-body">
                                    <div class="clearfix">
                                        <div class="btn-group">
                                            &nbsp;<asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="New"
                                                OnClick="BtnNew_Click" Font-Bold="False"></asp:Button>
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblStatus" runat="server" Text="Select Status" ForeColor="#2A6496"
                                                Font-Bold="True" Font-Names="Verdana" Font-Size="12pt" CssClass="lblselect"></asp:Label>
                                            &nbsp;
                                            <asp:DropDownList ID="ddlStatus1" runat="server" OnSelectedIndexChanged="ddlStatus1_SelectedIndexChanged1"
                                                AutoPostBack="True" CssClass="form-control" style="margin-bottom:0px;">
                                                <asp:ListItem>--Select Status--</asp:ListItem>
                                                <asp:ListItem>Pending</asp:ListItem>
                                                <asp:ListItem>Confirmed</asp:ListItem>
                                                <asp:ListItem>Rejected</asp:ListItem>
                                            </asp:DropDownList>
                                            <%-- <button id="sample_editable_1_new" class="btn green">
                                        Add New <i class="icon-plus"></i>
                                    </button>
                                            --%>
                                        </div>
                                       
                                    </div>
                                    <div class="space15">
                                    </div>
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
                                    <asp:GridView ID="gvRequestDetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="Request_ID" EnableModelValidation="True" ForeColor="#333333"
                                        GridLines="Both" OnPageIndexChanging="gvRequestDetail_PageIndexChanging" BorderWidth="1px"
                                        BorderColor="#cccccc" BorderStyle="Solid" OnRowCommand="gvRequestDetail_RowCommand"
                                        AllowSorting="True" OnSorting="gvRequestDetail_Sorting" class="table table-striped table-hover"
                                        PageSize="5">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Request ID" SortExpression="Request_ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("Request_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblIID" runat="server" Text='<%#Eval("Request_ID") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Request Date" SortExpression="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRequestDate" runat="server" Text='<%#Eval("Date","{0:dd-MM-yyyy}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Patient Name" SortExpression="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtName" class="inputtext" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No" SortExpression="MobileNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobleNo" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtMobileNo" class="inputtext" runat="server" Text='<%#Eval("MobileNo") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                <ItemTemplate>
                                                    <div class="label label-<%#Eval("Status") %>">
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                                    </div>
                                                    <asp:Label ID="lblNew" runat="server" Text="New" CssClass="label label-important"
                                                        Visible='<%# !(bool)Eval("NotificationFlag")%>'>
                                                    </asp:Label>

                                                      <asp:Label ID="lblHold" runat="server" Text="Hold" CssClass="label"
                                                        Visible='<%# (bool)Eval("IsHold")%>'>
                                                    </asp:Label>
                                                
                                                    <asp:Label ID="lblForward" runat="server" Text="Forwarded" CssClass="label label-warning"
                                                        Visible='<%# (bool)Eval("IsForward")%>'>
                                                    </asp:Label>
                                                
                                                
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtStatus" class="inputtext" runat="server" Text='<%#Eval("Status") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Transaction_ID" SortExpression="Request_Patient_ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTransaction_ID" runat="server" Text='<%#Eval("Request_Patient_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblITransactionID" runat="server" Text='<%#Eval("Request_Patient_ID") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            
                                            
                                           


                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" class="btn btn-primary" runat="server" Text="View" CommandName="View"
                                                        CommandArgument='<%#Eval("Request_ID") %>' />
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
                        <!-- END EXAMPLE TABLE widget-->
                    </div>
                </div>
            </asp:View>
            <!-- END ADVANCED TABLE widget-->
            <asp:View ID="vRequestDetail" runat="server">
               <%-- <asp:UpdatePanel ID="Update" runat="server">
                    <ContentTemplate>--%>
                        <ul class="breadcrumb">
                            <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                            </li>
                            <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                            <li>
                                <asp:LinkButton ID="lbPateintRequests" runat="server" OnClick="lbPatientRequests_Click">Patient Requests</asp:LinkButton>
                                <span class="divider">&nbsp;</span> </li>
                            <li><a href="#">Patient Request Detail</a><span class="divider-last">&nbsp;</span></li>
                        </ul>
                        <!-- END PAGE TITLE & BREADCRUMB-->
                        <!-- END PAGE HEADER-->
                        <!-- BEGIN ADVANCED TABLE widget-->
                        <div class="row-fluid">
                            <div class="span12">
                                <!-- BEGIN EXAMPLE TABLE widget-->
                                <div class="widget">
                                    <div class="widget-title">
                                        <h4>
                                            <i class="icon-reorder"></i>Patient Request Detail</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <%-- <div class="alert alert-info">
                                    <div style="color: Black">
                                        <strong>Note: </strong>
                                        <br />
                                        1. Click New button to make a new patient request.<br />
                                        2. Click View button to view patient request detail.
                                    </div>
                                </div>--%>
                                            <table class="">
                                            <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblTransaction_ID" runat="server" Text="Transaction_ID"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtTransaction_ID" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                


                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblRequestNo" runat="server" Text="Request No"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtRequestNo" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblUserID" runat="server" Text="Referenced By Stakeholder"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtUserID" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="style2">
                                                        OR
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="Label2" runat="server" Text="Referenced By Admin"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtAdminID" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtDate" runat="server" Enabled="False"></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender" runat="server" Format="yyyy-MM-dd" Enabled="True"
                                                            TargetControlID="txtDate">
                                                        </cc:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtName" runat="server" MaxLength="20" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtSubject" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        Request Detail
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtDescr" runat="server" Enabled="False" TextMode="MultiLine" Height="98px"
                                                            Width="206"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtAddress" Width="206px" runat="server" TextMode="MultiLine" Height="98px"
                                                            MaxLength="100" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="175px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:DropDownList ID="ddlCity" runat="server" Enabled="False" CssClass="form-grid_dropdown">
                                                            <asp:ListItem>Surat</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:DropDownList ID="ddlState" runat="server" Enabled="False" CssClass="form-grid_dropdown">
                                                            <asp:ListItem>Gujarat</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtPinCode" runat="server" MaxLength="6" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblIdProof" runat="server" Text="IdProof"></asp:Label>
                                                    </td>
                                                    <td class="style8">
                                                        <asp:ImageButton ID="ImgIdProof" runat="server" OnClick="ImgIdProof_Click" Width="166px"
                                                            Height="150px" ToolTip="Click to download"/>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvIdProof" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style7">
                                                        <asp:Label ID="lblDocument1" runat="server" Text="Disease related Documents"></asp:Label>
                                                        &nbsp;1</td>
                                                    <td class="style7">
                                                        <asp:ImageButton ID="ImgDocument1" runat="server" OnClick="ImgDocument1_Click" Width="167px"
                                                            Height="166px" ToolTip="Click to download" />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style9">
                                                    </td>
                                                    <td class="style10">
                                                        <asp:Label ID="lblcvDocument1" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style2">
                                                        Disease related Document 2</td>
                                                    <td class="style7">
                                                        <asp:ImageButton ID="ImgDocument2" runat="server" OnClick="ImgDocument2_Click" Width="171px"
                                                            Height="158px" ToolTip="Click to download" />
                                                        <br />
                                                        <asp:Label ID="lblcvDocument2" runat="server" Text=""></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="Label1" runat="server" Text="Status"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                                                            <asp:ListItem>Pending</asp:ListItem>
                                                            <asp:ListItem>Confirmed</asp:ListItem>
                                                            <asp:ListItem>Rejected</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <%--  <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblAutoResponse" runat="server" Text="Auto Response"></asp:Label>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtAutoResponse" runat="server" Width="206px" 
                                                            MaxLength="100"></asp:TextBox>
                                                       
                                                    </td>
                                                    <td>
                                                     
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtResponse"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                --%>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:Label ID="lblResponse" runat="server" Text="Response"></asp:Label>
                                                        <br />
                                                        <%-- (Give valid reason when request is pending)--%>
                                                    </td>
                                                    <td class="style3">
                                                        <asp:TextBox ID="txtResponse" runat="server" Width="206px" Height="80px" TextMode="MultiLine"
                                                            MaxLength="100"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvResponse" runat="server" ForeColor="Red"></asp:Label>
                                                        <asp:RequiredFieldValidator ID="rfvResponse" runat="server" ControlToValidate="txtResponse"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Panel ID="pConfirmRequest" runat="server">
                                                <table>
                                                    <tr>
                                                        <td class="style2">
                                                            Select Service Provider &nbsp;
                                                        </td>
                                                        <td class="style6">
                                                            <asp:DropDownList ID="ddlselecttype" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td >
                                                            <asp:Label ID="lblselecttype" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
                                                    Search Service Provider using PinCode
                                                    <asp:TextBox ID="txtPinCode1" ToolTip="Press Enter to search nearest areawise Service Provider"  runat="server" Style="margin-left: 25px;"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPinCode"
                                                        ErrorMessage="Invalid PinCode !" ForeColor="Red" ValidationExpression="^[0-9]{1,6}$"
                                                        ValidationGroup="btnSearch"></asp:RegularExpressionValidator>
                                                    <br />
                                                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click1" Style="display: none"
                                                        Text="Search" />
                                                </asp:Panel>
                                                <br />
                                                <br />
                                                <asp:GridView ID="gvUser" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                                    BorderColor="#cccccc" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" class="table table-striped table-hover"
                                                    DataKeyNames="User_ID" EnableModelValidation="True" ForeColor="#333333" GridLines="Both"
                                                    OnPageIndexChanging="gvUser_PageIndexChanging" OnSorting="GridView1_Sorting"
                                                    PageSize="5">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Select" SortExpression="">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkSelect" runat="server" AutoPostBack="true" Enabled="true" OnCheckedChanged="ChkSelect_CheckedChanged" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <%--<asp:TextBox ID="txtName" runat="server" class="inputtext" 
                                                                Text='<%#Eval("Name") %>'></asp:TextBox>--%>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="User ID" SortExpression="User_ID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("User_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblIID" runat="server" Text='<%#Eval("User_ID") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtName" runat="server" class="inputtext" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address" SortExpression="Address">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtAddress" runat="server" class="inputtext" Text='<%#Eval("Address") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact No" SortExpression="MobileNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblContact" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtContact" runat="server" class="inputtext" Text='<%#Eval("MobileNo") %>'></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvContact" runat="server" ControlToValidate="txtContact"
                                                                    ErrorMessage="*" SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PinCode" SortExpression="PinCode">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCity" runat="server" Text='<%#Eval("PinCode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <%-- <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnView" runat="server" class="btn btn-info" 
                                                                CommandArgument='<%#Eval("User_ID") %>' CommandName="View" Text="View" />
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>--%>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#ebebeb" />
                                                    <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="Red" />
                                                    <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                                    <PagerStyle BackColor="#284775" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                </asp:GridView>
                                                <asp:Label ID="lblcvSelectServiceProvider" runat="server" Text="" ForeColor="Red"></asp:Label>
                                            </asp:Panel>
                                            <asp:Panel ID="preasonforrejection" runat="server" Visible="false">
                                                <table>
                                                    <tr>
                                                        <td class="style2">
                                                            <asp:Label ID="lblRFR" runat="server" Text="Reason For Rejection"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtRejectionReason" runat="server" Width="206px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblrvReason" runat="server" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <table>
                                                <caption>
                                                    <br />
                                                    <tr>
                                                        <td class="style1">
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                            <%--   <asp:Button ID="Button2" runat="server"  OnClick="btnSendConfirmation_Click" Text="Send Confirmation" />--%>
                                                        </td>
                                                    </tr>
                                                </caption>
                                            
                                             
                                            
                                                <tr>
                                                    <td class="style4">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        &nbsp;&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSubmit1" runat="server" CssClass="btn btn-primary popovers" OnClick="btnSubmit_Click"
                                                            Text="Submit" ValidationGroup="Submit" data-trigger="hover" data-placement="left"
                                                            data-content="As you click on the submit your Response will be sent to the patient by email."
                                                            data-original-title="Request Status is 'Pending'" />
                                                        <asp:Button ID="btnSubmit2" runat="server" CssClass="btn btn-primary popovers" OnClick="btnSubmit_Click"
                                                            Text="Submit" ValidationGroup="Submit" data-trigger="hover" data-placement="left"
                                                            data-content="As you click on the submit the response as well the request detail
                                                             and selected service provider detail will be sent to both by email and sms."
                                                            data-original-title="Request Status is 'Confirmed'" />
                                                        <asp:Button ID="btnSubmit3" runat="server" CssClass="btn btn-primary popovers" OnClick="btnSubmit_Click"
                                                            Text="Submit" ValidationGroup="Submit" data-trigger="hover" data-placement="left"
                                                            data-content="As you click on the submit your Response as well reason for rejection will be sent to the patient by email."
                                                            data-original-title="Request Status is 'Rejected'" />
                                                        &nbsp;
                                                        <asp:Button ID="btnForward" runat="server" CssClass="btn btn-primary popovers" OnClick="btnForward_Click"
                                                            Text="Forward" data-trigger="hover" data-placement="left" data-content="As you click on the forward you will be redirected to 
                                                            forward request page. The response will not be appended. " data-original-title="Forwad Request to Volunteer to Authenticate it" />
                                                        &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancle_Click"
                                                            Text="Cancel" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>

                   
                <!-- END PAGE CONTENT-->
    </div>
    </div> </div>
    
    <!-- END EXAMPLE TABLE widget-->
    </div> </div> 
   <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
    
    </asp:View> </asp:MultiView>
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
