<%@ Page Title="" Language="C#" MasterPageFile="~/VolunteerLab/Volunteer.Master"
    AutoEventWireup="true" CodeBehind="VolunteerProfile.aspx.cs" Inherits="IPA1.VolunteerLab.VolunteerProfile" %>

    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 204px;
        }
        input[type="text"]
        {
        }
        input[readonly]
        {
            cursor: default;
            background-color: White;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    Profile
                    <%--  <small>simple profile page</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Profile</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN PAGE CONTENT-->
        <div class="row-fluid">
            <div class="span12">
                <div class="widget">
                    <div class="widget-title">
                        <h4>
                            <i class="icon-user"></i>Profile</h4>
                        <p>
                            &nbsp;</p>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                        <br />
                    </div>
                    <div style="margin-left: 50;">
                        <table class="table table-borderless" style="margin-left:20px; width:95%;">
                            <tbody>
                                <tr>
                                    <td class="style1">
                                        Profile Pic
                                    </td>
                                    <td class="style3">
                                        <asp:Image ID="ImgProfilePic" runat="server" Height="168px" Width="221px"></asp:Image><br /><br />
                                        <asp:FileUpload ID="fuProfilePic" runat="server" />
                                        <asp:Label ID="lblProfilePic" runat="server" Text=""></asp:Label>
                                        
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblFirstName" runat="server" Text=" FirstName"></asp:Label>
                                    </td>
                                    <td class="style3">
                                        <asp:TextBox ID="txtFirstName" runat="server" Width="210px" MaxLength="20" ValidationGroup="Submit"
                                            Enabled="True" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblLastName" runat="server" Text="LastName"></asp:Label>
                                    </td>
                                    <td class="style3">
                                        <asp:TextBox ID="txtLastName" runat="server" Width="210px" MaxLength="20" ValidationGroup="Submit"
                                            Enabled="True" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                                    </td>
                                    <td class="style3">
                                        <asp:TextBox ID="txtUserName" runat="server" Style="margin-top: 0px" Width="210px"
                                            MaxLength="20" ValidationGroup="Submit" Enabled="True" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                                    </td>
                                    <td class="style3">
                                        <asp:TextBox ID="txtEmail" runat="server" Width="210px" MaxLength="40" ValidationGroup="Submit"
                                            Enabled="True" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                    </td>
                                    <td class="style3">
                                        <asp:TextBox ID="txtAddress" runat="server" Rows="4" TextMode="MultiLine" MaxLength="100"
                                            Enabled="True" Width="210px"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                            <asp:ListItem>Gujarat</asp:ListItem>
                                        </asp:DropDownList>
                                        <td>
                                            &nbsp;
                                        </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown">
                                            <asp:ListItem>Surat</asp:ListItem>
                                        </asp:DropDownList>
                                        <td>
                                            &nbsp;
                                        </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                                    </td>
                                    <td class="style3">
                                        <asp:TextBox ID="txtPinCode" runat="server" ValidationGroup="Submit" Width="210px"
                                            Enabled="True"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rePinCode" runat="server" ControlToValidate="txtPinCode"
                                                    ErrorMessage="PinCode must be in 6 digit" ValidationExpression="(\d{6})" ValidationGroup="Submit"
                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                    </td>
                                     <td>
                                            &nbsp;
                                        </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        <asp:TextBox ID="txtMobileNo" runat="server" Width="210px" ValidationGroup="Submit"
                                            Enabled="True"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="rvMobileNo" runat="server" ValidationGroup="Submit" MaximumValue="9999999999"
                                                    MinimumValue="70000000000" ErrorMessage="Enter Valid Mobile No" ControlToValidate="txtMobileNo"
                                                    ForeColor="Red"></asp:RangeValidator>
                                    </td>
                                     <td>
                                            &nbsp;
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        IdProof
                                    </td>
                                    <td>
                                        <asp:Image ID="ImgIdProof" runat="server" Height="150px" Width="216px"></asp:Image><br />
                                        
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style5">
                                        <asp:Label ID="VlblBloodGroup" runat="server" Text="BloodGroup"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td class="style56">
                                        <asp:DropDownList ID="ddlBloodGroup" runat="server" Enabled="False">
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
                                            &nbsp;
                                        </td>
                                </tr>
                                <tr>
                                    <td class="style5">
                                        <asp:Label runat="server" Text="DOB" ID="VlblDOB"></asp:Label>
                                    </td>
                                    <td class="style56">
                                        <asp:TextBox ID="VtxtDOB" runat="server" Width="210px" ReadOnly="True" ValidationGroup="Submit"
                                            Enabled="False"></asp:TextBox>
                                       <%-- <cc:calendarextender id="CalendarExtender" runat="server" format="dd-MM-yyyy" enabled="True"
                                            targetcontrolid="VtxtDOB">
                            </cc:calendarextender>--%>
                                    </td>
                                    <td>
                                        <%--<asp:RangeValidator ID="RangeValidator1" runat="server" 
                            ControlToValidate="VtxtDOB" ErrorMessage="Age must be in between 16 to 80" 
                            MaximumValue="1998/1/1" MinimumValue="1935/1/1"></asp:RangeValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" OnClick="btnSubmit_Click"
                                            Text="Save" ValidationGroup="Submit" />&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />
                                    </td>
                                     <td>
                                            &nbsp;
                                        </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <!-- END PAGE CONTENT-->
        </div>
        <!-- END PAGE CONTAINER-->
        <!-- END CONTAINER -->
        <!-- BEGIN JAVASCRIPTS -->
        <!-- Load javascripts at bottom, this will reduce page load time -->
        <script src="js/jquery-1.8.3.min.js"></script>
        <script src="assets/bootstrap/js/bootstrap.min.js"></script>
        <script src="js/jquery.blockui.js"></script>
        <!-- ie8 fixes -->
        <!--[if lt IE 9]>
   <script src="js/excanvas.js"></script>
   <script src="js/respond.js"></script>
   <![endif]-->
        <script type="text/javascript" src="assets/chosen-bootstrap/chosen/chosen.jquery.min.js"></script>
        <script type="text/javascript" src="assets/uniform/jquery.uniform.min.js"></script>
        <script src="js/scripts.js"></script>
        <script>
            jQuery(document).ready(function () {
                // initiate layout and plugins
                App.init();
            });
        </script>
        <!-- END JAVASCRIPTS -->
</asp:Content>
