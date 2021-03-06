﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ApproveNewUser.aspx.cs" Inherits="IPA1.AdminLab.ApproveNewUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style8
        {
            width: 211px;
        }
        
        select[disabled],input[disabled]
        {
            cursor:not-allowed;
            background-color:White;
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
                    Approve New Users <small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvNewUser" runat="server">
            <asp:View ID="vNewUser" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Approve New Users</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>New Users</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                <div class="btn-group">
                                                <asp:Label ID="lblUserType" runat="server" Text="Select User Type" ForeColor="#2A6496"
                                                                Font-Bold="True" Font-Names="Verdana" Font-Size="12pt"></asp:Label>
                                                            &nbsp;&nbsp; &nbsp;
                                                            <asp:DropDownList ID="ddlType" runat="server" OnSelectedIndexChanged="ddlType_SelectedIndexChanged1"
                                                                AutoPostBack="True" CssClass="form-control" Height="33px" 
                                                        Width="">
                                                            </asp:DropDownList>
  
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
                                                        <asp:Label ID="lblSearch" runat="server" Text="Search" Visible="false"></asp:Label>
                                                        <asp:TextBox ID="txtSearch" runat="server" onkeyup="RefreshUpdatePanel();" AutoPostBack="true"
                                                            OnTextChanged="txtSearch_TextChanged" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="divgrid">
                                                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>--%>
                                                <asp:GridView ID="gvRegistration" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CellPadding="4" DataKeyNames="User_ID" EnableModelValidation="True" ForeColor="#333333"
                                                    GridLines="Both" BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid"
                                                    OnPageIndexChanging="gvRegistration_PageIndexChanging" OnRowCommand="gvRegistration_RowCommand"
                                                    AllowSorting="True" OnSorting="GridView1_Sorting" class="table table-striped  table-hover"
                                                    PageSize="5">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <%--  <asp:TemplateField HeaderText="User Type<img src='../img/bullet-arrow-up-down-icon.png'>" SortExpression="StackHolder">--%>
                                                        <asp:TemplateField HeaderText="User Type" SortExpression="StackHolder"><ItemTemplate><asp:Label ID="lblStakeHolder" runat="server" Text='<%#Eval("StackHolder") %>'></asp:Label><asp:Label ID="lblNew" runat="server" Text="New" CssClass="label label-important" 
                                                        Visible='<%# !(bool)Eval("NotificationFlag") %>'>
                                                         </asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtStakeHolder" runat="server" Enabled="false" Text='<%#Eval("StackHolder") %>'></asp:TextBox></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name" SortExpression="FirstName"><ItemTemplate><asp:Label ID="lblName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtName" runat="server" Enabled="false" Text='<%#Eval("FirstName") %>'></asp:TextBox></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact No" SortExpression="MobileNo"><ItemTemplate><asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtContactNo" runat="server" Enabled="false" Text='<%#Eval("MobileNo") %>'></asp:TextBox></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="E-Mail" SortExpression="Email"><ItemTemplate><asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtEmail" runat="server" Enabled="false" Text='<%#Eval("Email") %>'></asp:TextBox></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="State" SortExpression="State"><ItemTemplate><asp:Label ID="lblState" runat="server" Text='<%#Eval("State") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtState" runat="server" Enabled="false" Text='<%#Eval("State") %>'></asp:TextBox></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="City" SortExpression="City"><ItemTemplate><asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'></asp:Label></ItemTemplate><EditItemTemplate><asp:TextBox ID="txtCity" runat="server" Enabled="false" Text='<%#Eval("City") %>'></asp:TextBox></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PinCode" SortExpression="PinCode"><ItemTemplate><asp:Label ID="lblPinCode" runat="server" Text='<%#Eval("PinCode") %>'></asp:Label></ItemTemplate></asp:TemplateField>
                                                     
                                                        <asp:TemplateField HeaderText="View"><ItemTemplate><asp:Button ID="BtnView" Width="65px" runat="server" class="btn btn-primary" 
                                                                    Text="View" CommandName="View" CommandArgument='<%#Eval("User_ID") %>' /></ItemTemplate><EditItemTemplate></EditItemTemplate><FooterTemplate></FooterTemplate></asp:TemplateField>
                                                    </Columns>
                                                    <EditRowStyle BackColor="#ebebeb" />
                                                    <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="Red" />
                                                    <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                                    <PagerStyle BackColor="#284775" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                </asp:GridView>
                                                <%--</ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="txtSearch" />
                                                </Triggers>
                                            </asp:UpdatePanel>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END SAMPLE TABLE widget-->
                </div>
            </asp:View>
            <asp:View ID="vNewUserDetail" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li>
                        <asp:LinkButton ID="lbApproveNewUsers" runat="server" OnClick="lbApproveNewUsers_Click">Approve New Users</asp:LinkButton>
                        <span class="divider">&nbsp;</span> 
                    </li>
                    <li><a href="#">User Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>User Detail</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                               
                                            </div>
                                            <div class="space15">
                                            </div>
                                           <%-- <asp:UpdatePanel ID="Update" runat="server">
                                                <ContentTemplate>--%>
                                                    <table>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblUserID" runat="server" Text=" User ID"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtUserID" runat="server" CssClass="inputtext" Width="224px" 
                                                                    AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvUserID" runat="server" ControlToValidate="txtUserID"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblselecttype" runat="server" Text="Sign Up As"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlselecttype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlselecttype_SelectedIndexChanged"
                                                                    CssClass="form-grid_dropdown" Width="224px" ValidationGroup="Submit" 
                                                                    Enabled="False">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:CustomValidator ID="cvddlselecttype" runat="server" ControlToValidate="ddlselecttype"
                                                                    OnServerValidate="cvddlselecttype_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Profile Pic
                                                            </td>
                                                            <td>
                                                                 <asp:ImageButton ID="ImgProfilePic" runat="server" 
                                                                     onclick="ImgProfilePic_Click" Width="150px" Height="150" ToolTip="Click to download"/>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                        <td></td>
                                                        <td> 
                                                            <asp:Label ID="lblProfilePicture" runat="server" Text=""></asp:Label>
                                                            <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblFirstName" runat="server" Text=" FirstName"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <br />
                                                                <asp:TextBox ID="txtFirstName" runat="server" Width="224px" MaxLength="20" 
                                                                    ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="reFirstName" runat="server" ControlToValidate="txtFirstName"
                                                                    ErrorMessage="Alphabates Only" ValidationExpression="[a-z A-Z]+" ValidationGroup="Submit"
                                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblLastName" runat="server" Text=" LastName"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtLastName" runat="server" Width="224px" MaxLength="20" 
                                                                    ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                &nbsp;&nbsp;
                                                                <asp:RegularExpressionValidator ID="reLastName" runat="server" ControlToValidate="txtLastName"
                                                                    ErrorMessage="Alphabates Only" ValidationExpression="[a-z A-Z]*" ValidationGroup="Submit"
                                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtUserName" runat="server" Style="margin-top: 0px" Width="224px"
                                                                    AutoPostBack="True" OnTextChanged="txtUserName_TextChanged" MaxLength="20" 
                                                                    ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                <br />
                                                                &nbsp;
                                                                <asp:Label ID="lblcvUserName" runat="server" ForeColor="Red" Text="UserName already exists"
                                                                    Visible="False"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                            </td>
                                                            <td>
                                                                <asp:RegularExpressionValidator ID="reUserName" runat="server" ControlToValidate="txtUserName"
                                                                    ErrorMessage="Enter Alphabates and Digits Only " ValidationExpression="[ a-zA-Z0-9]+"
                                                                    ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmail" runat="server" Width="224px" MaxLength="40" 
                                                                    ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                                                                    ErrorMessage="Invalid Email  Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtAddress" runat="server" Rows="4" TextMode="MultiLine" MaxLength="100"
                                                                    ValidationGroup="Submit" Width="224px" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Width="224px" 
                                                                    Enabled="False">
                                                                    <asp:ListItem>Gujarat</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown" 
                                                                    Width="224px" Enabled="False">
                                                                    <asp:ListItem>Surat</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPinCode" runat="server" ValidationGroup="Submit" 
                                                                    Width="224px" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                <asp:RegularExpressionValidator ID="rePinCode" runat="server" ControlToValidate="txtPinCode"
                                                                    ErrorMessage="PinCode must be in 6 digit" ValidationExpression="(\d{6})" ValidationGroup="Submit"
                                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td class="style8">
                                                                <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMobileNo" runat="server" Width="224px" ReadOnly="True"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="rvMobileNo" runat="server" ValidationGroup="Submit" MaximumValue="9999999999"
                                                                    MinimumValue="70000000000" ErrorMessage="Enter Valid Mobile No" ControlToValidate="txtMobileNo"
                                                                    ForeColor="Red"></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="style8">
                                                            </td>
                                                            <td>
                                                                <asp:CustomValidator ID="cvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                                                    ErrorMessage="Contact no must be in 10 digit" ForeColor="Red" ValidationGroup="Submit"
                                                                    OnServerValidate="cvMobileNo_ServerValidate"></asp:CustomValidator>
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>
                                                    <asp:MultiView ID="MvRegister" runat="server" ActiveViewIndex="0">
                                                        <asp:View ID="Volunteer" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="VlblIdProof" runat="server" Text="IdProof"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:ImageButton ID="VImgIdProof" runat="server" onclick="VImgIdProof_Click" Width="150" Height="150" 
                                                                        ToolTip="Click to download"/>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="VfuIdProof" runat="server" Enabled="False" 
                                                                            Visible="False" />
                                                                         <asp:Label ID="VlblImgIdProof" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="VlblBloodGroup" runat="server" Text="BloodGroup"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <br />
                                                                        <asp:DropDownList ID="VddlBloodGroup" runat="server" CssClass="form-grid_dropdown"
                                                                            Width="224px" Enabled="False">
                                                                            <asp:ListItem>A+</asp:ListItem>
                                                                            <asp:ListItem>B+</asp:ListItem>
                                                                            <asp:ListItem>A-</asp:ListItem>
                                                                            <asp:ListItem>B-</asp:ListItem>
                                                                            <asp:ListItem>AB+</asp:ListItem>
                                                                            <asp:ListItem>AB-</asp:ListItem>
                                                                            <asp:ListItem>O+</asp:ListItem>
                                                                            <asp:ListItem>O-</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="VrfvBloodGroup" runat="server" ValidationGroup="Submit"
                                                                            ControlToValidate="VddlBloodGroup" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label runat="server" Text="DOB" ID="VlblDOB"></asp:Label>
                                                                        &nbsp;(dd-MM-YYYY)
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="VtxtDOB" runat="server" Width="224px" ValidationGroup="Submit" 
                                                                            Enabled="False"></asp:TextBox>
                                                                        <cc:CalendarExtender ID="CalendarExtender" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                                            TargetControlID="VtxtDOB"></cc:CalendarExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="VrfvDOB" runat="server" ErrorMessage="*" ForeColor="Red"
                                                                            ValidationGroup="Submit" ControlToValidate="VtxtDOB"></asp:RequiredFieldValidator>
                                                                        <asp:RangeValidator ID="rvtxtDOB" runat="server" ControlToValidate="VtxtDOB" ErrorMessage="Age must be in between 16 to 80"
                                                                            MaximumValue="01-01-1998" MinimumValue="01-01-1935" Type="Date" ValidationGroup="Submit"
                                                                            ForeColor="Red"></asp:RangeValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="Donor" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="DddlBloodGroup" runat="server" CssClass="form-grid_dropdown"
                                                                            ValidationGroup="Submit" Width="224px" Enabled="False">
                                                                            <asp:ListItem>A+</asp:ListItem>
                                                                            <asp:ListItem>A-</asp:ListItem>
                                                                            <asp:ListItem>B+</asp:ListItem>
                                                                            <asp:ListItem>B-</asp:ListItem>
                                                                            <asp:ListItem>AB+</asp:ListItem>
                                                                            <asp:ListItem>AB-</asp:ListItem>
                                                                            <asp:ListItem>O+</asp:ListItem>
                                                                            <asp:ListItem>O-</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="rfvBloodGroup" runat="server" ErrorMessage="*" ForeColor="Red"
                                                                            ValidationGroup="Submit" ControlToValidate="DddlBloodGroup"></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label runat="server" Text="DOB" ID="lblDOB"></asp:Label>
                                                                        &nbsp;(dd-MM-YYYY)
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="DtxtDOB" runat="server" Width="224px" ValidationGroup="Submit" 
                                                                            Enabled="False"></asp:TextBox>
                                                                        <cc:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                                            TargetControlID="DtxtDOB" ></cc:CalendarExtender>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ErrorMessage="*" ForeColor="Red"
                                                                            ValidationGroup="Submit" ControlToValidate="DtxtDOB"></asp:RequiredFieldValidator>
                                                                        <asp:RangeValidator ID="rgDOB" runat="server" ErrorMessage="Age must be in between 16 to 80"
                                                                            MaximumValue="01-01-1998" MinimumValue="01-01-1935" ControlToValidate="DtxtDOB"
                                                                            ValidationGroup="Submit" Type="Date" ForeColor="Red"></asp:RangeValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="Hospital" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="HlblIdProof" runat="server" Text="IdProof"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                         <asp:ImageButton ID="HImgIdProof" runat="server" onclick="HImgIdProof_Click" Width="150" Height="150"
                                                                         ToolTip="Click to download" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="HfuIdProof" runat="server" Enabled="False" 
                                                                            Visible="False" />
                                                                         <asp:Label ID="HlblImgIdProof" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="HlblContactPerson" runat="server" Text="ContactPerson Name"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <br />
                                                                        <asp:TextBox ID="HtxtContactPerson" runat="server" Width="224px" MaxLength="20" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="HrfvContactPerson" runat="server" ErrorMessage="*"
                                                                            ForeColor="Red" ValidationGroup="Submit" ControlToValidate="HtxtContactPerson"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="HreContactPerson" runat="server" ControlToValidate="HtxtContactPerson"
                                                                            ErrorMessage="Alphabates Only" ValidationExpression="[ a-zA-Z]+" ValidationGroup="Submit"
                                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label runat="server" Text="Website" ID="HlblWebsite"></asp:Label>
                                                                        &nbsp;Name
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="HtxtWebsite" runat="server" Width="224px" MaxLength="50" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RegularExpressionValidator ID="HreWebsite" runat="server" ErrorMessage="Invalid Url Format"
                                                                            ValidationExpression="^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$"
                                                                            ControlToValidate="HtxtWebsite" ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="BloodBank" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="BlblIdProof" runat="server" Text="IdProof"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                         <asp:ImageButton ID="BImgIdProof" runat="server" onclick="BImgIdProof_Click" Width="150" Height="150"
                                                                         ToolTip="Click to download" />
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="BfuIdProof" runat="server" Enabled="False" 
                                                                            Visible="False" />
                                                                         <asp:Label ID="BlblImgIdProof" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="BlblContactPerson" runat="server" Text="ContactPerson Name"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <br />
                                                                        <asp:TextBox ID="BtxtContactPerson" runat="server" Width="224px" MaxLength="20" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="BrfvContactPerson" runat="server" ErrorMessage="*"
                                                                            ForeColor="Red" ValidationGroup="Submit" ControlToValidate="BtxtContactPerson"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="BreContactPerson" runat="server" ControlToValidate="BtxtContactPerson"
                                                                            ErrorMessage="Alphabates Only" ValidationExpression="[ a-zA-Z]+" ValidationGroup="Submit"
                                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label runat="server" Text="Website" ID="BlblWebsite"></asp:Label>
                                                                        &nbsp;Name
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="BtxtWebsite" runat="server" Width="224px" MaxLength="50" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RegularExpressionValidator ID="BreWebsite" runat="server" ControlToValidate="BtxtWebsite"
                                                                            ErrorMessage="Invalid Url Format" ValidationExpression="^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$"
                                                                            ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="PharmaCompany" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="PlblIdProof" runat="server" Text="IdProof"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                         <asp:ImageButton ID="PImgIdProof" runat="server" onclick="PImgIdProof_Click" Width="150" Height="150" 
                                                                         ToolTip="Click to download"/>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="PfuIdProof" runat="server" Enabled="False" 
                                                                            Visible="False" />
                                                                         <asp:Label ID="PlblImgIdProof" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="PlblContactPerson" runat="server" Text="ContactPerson Name"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <br />
                                                                        <asp:TextBox ID="PtxtContactPerson" runat="server" Width="224px" MaxLength="20" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="PrfvContactPerson" runat="server" ErrorMessage="*"
                                                                            ForeColor="Red" ValidationGroup="Submit" ControlToValidate="PtxtContactPerson"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="PreContactPerson" runat="server" ControlToValidate="PtxtContactPerson"
                                                                            ErrorMessage="Alphabates Only" ValidationExpression="[ a-zA-Z]+" ValidationGroup="Submit"
                                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label runat="server" Text="Website" ID="PlblWebsite"></asp:Label>
                                                                        &nbsp;Name
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="PtxtWebsite" runat="server" Width="224px" MaxLength="50" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RegularExpressionValidator ID="PreWebsite" runat="server" ControlToValidate="PtxtWebsite"
                                                                            ErrorMessage="Invalid Url Format" ValidationExpression="^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$"
                                                                            ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="Doctor" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="DolblIdProof" runat="server" Text="IdProof"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                         <asp:ImageButton ID="DoImgIdProof" runat="server" onclick="DoImgIdProof_Click" Width="150" Height="150" 
                                                                         ToolTip="Click to download"/>
                                                                        <br />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:FileUpload ID="DfuIdProof" runat="server" Enabled="False" 
                                                                            Visible="False" />
                                                                         <asp:Label ID="DlblImgIdProof" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label runat="server" Text="Degree" ID="DolblDegree"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        <br />
                                                                        <asp:TextBox ID="DotxtDegree" runat="server" Width="224px" MaxLength="20" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RequiredFieldValidator ID="DorfvDegree" runat="server" ErrorMessage="*" ValidationGroup="Submit"
                                                                            ForeColor="Red" ControlToValidate="DotxtDegree"></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="DoreDegree" runat="server" ControlToValidate="DotxtDegree"
                                                                            ErrorMessage="Alphabates Only" ValidationExpression="[a-zA-Z.]+" ValidationGroup="Submit"
                                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        Specialist In
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="DotxtDisease" runat="server" Width="224px" MaxLength="20" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RegularExpressionValidator ID="DoreDisease" runat="server" ControlToValidate="DotxtDisease"
                                                                            ErrorMessage="Alphabates Only" ValidationExpression="[a-zA-Z]+" ValidationGroup="Submit"
                                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                        <br />
                                                        <asp:View ID="NGO" runat="server">
                                                            <table>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label runat="server" Text="Website" ID="NlblWebsite"></asp:Label>
                                                                        &nbsp;Name
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="NtxtWebsite" runat="server" Width="224px" MaxLength="50" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RegularExpressionValidator ID="NreWebsite" runat="server" ControlToValidate="NtxtWebsite"
                                                                            ErrorMessage="Invalid Url Format" ValidationExpression="^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$"
                                                                            ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="NlblPurpose" runat="server" Text="Purpose"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="NtxtPurpose" runat="server" Width="224px" MaxLength="100" 
                                                                            ValidationGroup="Submit" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RegularExpressionValidator ID="NrePurpose" runat="server" ControlToValidate="NtxtPurpose"
                                                                            ErrorMessage="Alphabates Only" ValidationExpression="[a-zA-Z]+" ValidationGroup="Submit"
                                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style8">
                                                                        <asp:Label ID="NlblMission" runat="server" Text="Mission"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="NtxtMission" runat="server" Width="224px" MaxLength="50" 
                                                                            ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:RegularExpressionValidator ID="NreMission" runat="server" ControlToValidate="NtxtMission"
                                                                            ErrorMessage="Alphabates Only" ValidationExpression="[a-zA-Z]+" ValidationGroup="Submit"
                                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:View>
                                                        <asp:View ID="Media" runat="server">
                                                        </asp:View>

                                                        


                                                    </asp:MultiView>
                                                     
                                               <%-- </ContentTemplate>
                                                <Triggers><asp:AsyncPostBackTrigger ControlID="ddlselecttype" /><asp:AsyncPostBackTrigger ControlID="txtUserName" /><asp:AsyncPostBackTrigger ControlID="ddlState" /></Triggers>
                                            </asp:UpdatePanel>--%>
                                            <table>
                                            <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblRFR" runat="server" Text="Reason For Rejection"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRejectionReason" runat="server" Width="224px" Height="80px" 
                                                            TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvRFR" runat="server" ErrorMessage="*" 
                                                            ControlToValidate="txtRejectionReason" ForeColor="Red" 
                                                            ValidationGroup="Reject"></asp:RequiredFieldValidator>
                                                        <asp:Label ID="lblrvReason" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr> 
                                                    
                                                <tr>
                                                    <td class="style8">
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </td>

                                                    <td>
                                                        <asp:LinkButton ID="btnApprove" runat="server" CssClass="btn btn-info" 
                                                            onclick="btnApprove_Click" ValidationGroup="Submit">

                                                        <i class="icon-ok icon-white"></i>
                                                        

                                                        Approve

                                                        </asp:LinkButton>
                                                        &nbsp;&nbsp;<asp:LinkButton ID="btnReject" runat="server" 
                                                            CssClass="btn btn-info" onclick="btnReject_Click" ValidationGroup="Reject">

                                                        <i class="icon-remove icon-white"></i>
                                                        

                                                        Reject

                                                        </asp:LinkButton>
                                                        &nbsp;&nbsp;<asp:LinkButton ID="btnCancel" runat="server" 
                                                            CssClass="btn btn-info" onclick="btnCancel_Click">

                                                        <i class="icon-ban-circle icon-white"></i>
                                                        

                                                        Cancel

                                                        </asp:LinkButton>
                                                        
                                                        <%--<asp:Button ID="btnApprove" runat="server" CssClass="btn btn-info" Text="Approve"
                                                            ValidationGroup="Submit" OnClick="btnApprove_Click" />
                                                        &nbsp;&nbsp;
                                                        <asp:Button ID="btnReject" runat="server" CssClass="btn btn-info" Text="Reject" OnClick="btnReject_Click" />
                                                        &nbsp;&nbsp;
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info" Text="Cancel" OnClick="btnCancel_Click" />--%>
                                                  </td>
                                                  
                                               
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
