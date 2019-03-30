<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="NewUserRegistration.aspx.cs" Inherits="IPA1.AdminLab.NewUserRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style8
        {
            width: 211px;
        }
        .style2
        {
            color: #FF0000;
        }
        input[readonly]
{
    cursor:not-allowed;
    background-color:White;
}
input[disabled]
{cursor:not-allowed;background-color:#eee}

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
                    New User Registration
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Master</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="UserMast.aspx">User Master</a><span class="divider">&nbsp;</span></li>
                    <li><a href="#">New User Registration</a><span class="divider-last">&nbsp;</span></li>
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
                            <i class="icon-reorder"></i>New User Registraion</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                             
                            </div>
                            <div class="space15">
                            </div>
                            <asp:UpdatePanel ID="Update" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblselecttype" runat="server" Text="Sign Up As"></asp:Label>
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlselecttype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlselecttype_SelectedIndexChanged"
                                                    CssClass="form-grid_dropdown" Width="224px" ValidationGroup="Submit" OnTextChanged="ddlselecttype_TextChanged1">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvddlselecttype" runat="server" ControlToValidate="ddlselecttype"
                                                    OnServerValidate="cvddlselecttype_ServerValidate" ForeColor="Red"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblFirstName" runat="server" Text=" FirstName"></asp:Label>
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFirstName" runat="server" Width="224px" MaxLength="20" ValidationGroup="Submit"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                                    ErrorMessage="Enter your First name!" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
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
                                                <asp:TextBox ID="txtLastName" runat="server" Width="224px" MaxLength="20" ValidationGroup="Submit"></asp:TextBox>
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
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUserName" runat="server" Style="margin-top: 0px" Width="224px"
                                                    AutoPostBack="True" OnTextChanged="txtUserName_TextChanged" MaxLength="20" ValidationGroup="Submit"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblcvUserName" runat="server" ForeColor="Red" Text=""
                                                    Visible="False"></asp:Label>
                                                <br />
                                                &nbsp;
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
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" runat="server" Width="224px" MaxLength="40" ValidationGroup="Submit"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                                                    ErrorMessage="Invalid Email  Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                                    
                                                      <asp:Label ID="lblcvEmail" runat="server" CssClass="label-validation" 
                                                      ForeColor="Red" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="224px" MaxLength="30"
                                                    ValidationGroup="Submit"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rePassword" runat="server" ControlToValidate="txtPassword"
                                                    ErrorMessage="Password should be min of 8 characters at least 1 Alphabet and 1 Number"
                                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ValidationGroup="Submit"
                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="224px"
                                                    MaxLength="30" ValidationGroup="Submit"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="comConfirmPassword" runat="server" ControlToCompare="txtPassword"
                                                    ControlToValidate="txtConfirmPassword" ErrorMessage="This Password does not match."
                                                    ForeColor="Red" ValidationGroup="Submit"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtAddress" runat="server" Rows="4" TextMode="MultiLine" MaxLength="100"
                                                    ValidationGroup="Submit" Width="224px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                                &nbsp;<span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Width="224px">
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
                                                &nbsp;<span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown" Width="224px">
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
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPinCode" runat="server" ValidationGroup="Submit" Width="224px"></asp:TextBox>
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
                                        <%-- <tr>
                <td class="style61"></td>
                <td><asp:CustomValidator ID="cvPinCode" runat="server" 
                            ControlToValidate="txtPinCode" ErrorMessage="Pincode must be in 6 digit " 
                            onservervalidate="cvPinCode_ServerValidate" ValidationGroup="Submit"></asp:CustomValidator></td>
                
                </tr>--%>
                

               
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                                                &nbsp;<span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMobileNo" runat="server" Width="224px"></asp:TextBox>
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
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="lblProfilePic" runat="server" Text="Upload Your ProfilePic"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="fuProfilePic" runat="server" Width="224px"></asp:FileUpload>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblProfilePicture" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:MultiView ID="MvRegister" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="Volunteer" runat="server">
                                            <table>

                                             <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="VlblIdProof" runat="server" Text="IdProof"></asp:Label>
                                                        <span class="style63">(Upload Your IdProof)</span><span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="VfuIdProof" runat="server" Width="224px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="VlblcvIdProof" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="VlblBloodGroup" runat="server" Text="BloodGroup"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="VddlBloodGroup" runat="server" CssClass="form-grid_dropdown"
                                                            Width="224px">
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
                                                        <span class="style2">*</span> (dd-MM-YYYY)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="VtxtDOB" runat="server" Width="224px" ValidationGroup="Submit"></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                            TargetControlID="VtxtDOB" SelectedDate="12-12-1975">
                                                        </cc:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="VrfvDOB" runat="server" ErrorMessage="*" ForeColor="Red"
                                                            ValidationGroup="Submit" ControlToValidate="VtxtDOB"></asp:RequiredFieldValidator>
                                                     </td>
                                                </tr>



                                            </table>
                                        </asp:View>
                                        <asp:View ID="Donor" runat="server">
                                            <table>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DddlBloodGroup" runat="server" CssClass="form-grid_dropdown"
                                                            ValidationGroup="Submit" Width="224px">
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
                                                        <span class="style2">*</span> (dd-MM-YYYY)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="DtxtDOB" runat="server" Width="224px" ></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" 
                                                            TargetControlID="DtxtDOB" SelectedDate="12-12-1975">
                                                        </cc:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ErrorMessage="*" ForeColor="Red"
                                                            ValidationGroup="Submit" ControlToValidate="DtxtDOB"></asp:RequiredFieldValidator>
                                                     </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="Hospital" runat="server">
                                            <table>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="HlblIdProof" runat="server" Text="IdProof"></asp:Label>
                                                        <span class="style63">(Upload Your Licence)</span><span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="HfuIdProof" runat="server" Width="224px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvHfuIdProof" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="HlblContactPerson" runat="server" Text="ContactPerson Name"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="HtxtContactPerson" runat="server" Width="224px" MaxLength="20" ValidationGroup="Submit"></asp:TextBox>
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
                                                        &nbsp;Name<br /> e.g.&nbsp; (www.google.com)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="HtxtWebsite" runat="server" Width="224px" MaxLength="50" ValidationGroup="Submit"></asp:TextBox>
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
                                                        <span class="style63">(Upload Your Licence)</span><span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="BfuIdProof" runat="server" Width="224px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvBIdProof" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="BlblContactPerson" runat="server" Text="ContactPerson Name"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="BtxtContactPerson" runat="server" Width="224px" MaxLength="20" ValidationGroup="Submit"></asp:TextBox>
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
                                                        <br />
                                                        e.g.&nbsp; (www.google.com)
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="BtxtWebsite" runat="server" Width="224px" MaxLength="50" ValidationGroup="Submit"></asp:TextBox>
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
                                                        <span class="style63">(Upload Your Licence)</span><span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="PfuIdProof" runat="server" Width="224px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvPfuIdProof" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label ID="PlblContactPerson" runat="server" Text="ContactPerson Name"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="PtxtContactPerson" runat="server" Width="224px" MaxLength="20" ValidationGroup="Submit"></asp:TextBox>
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
                                                        <br />
                                                        e.g.&nbsp; (www.google.com)</td>
                                                    <td>
                                                        <asp:TextBox ID="PtxtWebsite" runat="server" Width="224px" MaxLength="50" ValidationGroup="Submit"></asp:TextBox>
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
                                                        <span class="style63">(Upload Your Degree Certificate)</span><span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:FileUpload ID="DfuIdProof" runat="server" Width="224px" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblcvDfuIdProof" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style8">
                                                        <asp:Label runat="server" Text="Degree" ID="DolblDegree"></asp:Label>
                                                        <span class="style2">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="DotxtDegree" runat="server" Width="224px" MaxLength="20" ValidationGroup="Submit"></asp:TextBox>
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
                                                        <asp:TextBox ID="DotxtDisease" runat="server" Width="224px" MaxLength="20" ValidationGroup="Submit"></asp:TextBox>
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
                                                        <br />
                                                        e.g.&nbsp; (www.google.com)</td>
                                                    <td>
                                                        <asp:TextBox ID="NtxtWebsite" runat="server" Width="224px" MaxLength="50" ValidationGroup="Submit"></asp:TextBox>
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
                                                        <asp:TextBox ID="NtxtPurpose" runat="server" Width="224px" MaxLength="100" ValidationGroup="Submit"></asp:TextBox>
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
                                                        <asp:TextBox ID="NtxtMission" runat="server" Width="224px" MaxLength="50"></asp:TextBox>
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
                                        <br />
                                    </asp:MultiView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlselecttype" />
                                    <asp:AsyncPostBackTrigger ControlID="txtUserName"/>
                                    <asp:AsyncPostBackTrigger ControlID="ddlState"/>
                                </Triggers>
                                
                            </asp:UpdatePanel>
                            <table>
                                <tr>
                                    <td class="style8">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="Submit" ValidationGroup="Submit"
                                            OnClick="btnSubmit_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-info" Text="Reset" OnClick="btnReset_Click" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info" Text="Cancel" OnClick="btnCancel_Click" />
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
