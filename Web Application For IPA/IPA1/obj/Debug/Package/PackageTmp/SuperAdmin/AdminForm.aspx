<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true" 
CodeBehind="AdminForm.aspx.cs" Inherits="IPA1.SuperAdmin.AdminForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
    
       input[type="text"],input[type="textarea"]
        {
            width:206px;
        }
   

    .style1
    {
        width: 210px;
    }
   

        .style2
        {
            color: #FF0000;
        }
        .style4
        {
            width: 190px;
        }
        .style5
        {
            width: 227px;
        }
   

        .style6
        {
            width: 259px;
        }
        .style7
        {
            width: 204px;
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
                    Admin Detail Form
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="AdminDetail.aspx">Admin</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Admin Detail Form</a><span class="divider-last">&nbsp;</span></li>
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
                            <i class="icon-reorder"></i>Admin Form</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="btn-group pull-right">
                            <button class="btn dropdown-toggle" data-toggle="dropdown">
                                Tools <i class="icon-angle-down"></i>
                            </button>
                            <ul class="dropdown-menu pull-right">
                                <li><a href="#">Print</a></li>
                                <li><a href="#">Save as PDF</a></li>
                                <li><a href="#">Export to Excel</a></li>
                            </ul>
                        </div>
                    </div>
        
                            <div class="space10">
                            </div>
                           
                            <!-- Here Put grid or table -->
                            <table class="" style="margin-left:15px;">
  
   <tr>
                    <td class="style4">
                        <asp:Label ID="lblFirstName" runat="server" Text=" FirstName"></asp:Label>
                        <span class="style2" ForeColor="Red">*</span>
                 
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtFirstName" runat="server" Width="" 
                            CssClass="inputtext" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                            ControlToValidate="txtFirstName" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="reFirstName" runat="server" 
                            ControlToValidate="txtFirstName" ErrorMessage="Alphabates Only" 
                            ValidationExpression="[a-z A-Z]+" ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblLastName" runat="server" Text=" LastName"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtLastName" runat="server" Width="" CssClass="inputtext" 
                            MaxLength="20" ValidationGroup="Submit"></asp:TextBox>
                    </td>
                    <td>
                    
                   
                    
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtLastName" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    
                   
                    
                        <asp:RegularExpressionValidator ID="reLastName" runat="server" 
                            ControlToValidate="txtLastName" ErrorMessage="Alphabates Only" 
                            ValidationExpression="[a-z A-Z]*" ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                    
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                        <span class="style2">*</span>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtUserName" runat="server" 
                            Style="margin-top: 0px" Width="" AutoPostBack="True" CssClass="inputtext" 
                            MaxLength="20" ValidationGroup="Submit" 
                            ontextchanged="txtUserName_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                            ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    
                   
                        <asp:Label ID="lblcvUserName" runat="server" ForeColor="Red" Text=""
                                                    Visible="False"></asp:Label>
                                                <br />
                                            
                        
                    </td>
                </tr>
                <tr>
                <td class="style4"></td>
                <td class="style5"><asp:RegularExpressionValidator ID="reUserName" runat="server" 
                            ControlToValidate="txtUserName" ErrorMessage="Enter Alphabates and Digits Only " 
                            ValidationExpression="[a-zA-Z0-9]+" ValidationGroup="Submit" 
                        ForeColor="Red"></asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                        <span class="style2">*</span></td>
                    <td class="style5">
                        <asp:TextBox ID="txtEmail" runat="server" Width="" CssClass="inputtext" 
                            MaxLength="40" ValidationGroup="Submit" AutoPostBack="false" 
                            ontextchanged="txtEmail_TextChanged"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="reEmail" runat="server" 
                            ControlToValidate="txtEmail" ErrorMessage="Invalid Email  Address" 
                            ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="Submit"></asp:RegularExpressionValidator>
                             <asp:Label ID="lblcvEmail" runat="server" CssClass="label-validation" 
                               ForeColor="Red" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                        <span class="style2">*</span>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtPassword" runat="server" 
                            TextMode="Password" Width="210px" MaxLength="30" ValidationGroup="Submit" 
                            CssClass="inputtext"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                            ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rePassword" runat="server" 
                            ControlToValidate="txtPassword" ErrorMessage="Password should be min of 8 characters at least 1 Alphabet and 1 Number" 
                            ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
                            ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                        <span class="style2">*</span>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" 
                            Width="210px" MaxLength="30" ValidationGroup="Submit" CssClass="inputtext"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="comConfirmPassword" runat="server" 
                            ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" 
                            ErrorMessage="This Password does not match." ForeColor="Red" 
                            ValidationGroup="Submit"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                        <span class="style2">*</span>
                    </td>
                    <td class="style5"  >
                        <asp:TextBox ID="txtAddress" runat="server" Rows="4" TextMode="MultiLine" 
                            MaxLength="100" ValidationGroup="Submit" BorderColor="Silver" 
                            BorderStyle="Solid" BorderWidth="1px" Width="210px" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                            ControlToValidate="txtAddress" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                        &nbsp;<span class="style2">*</span>
                    </td>
                    <td class="style5">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" 
                            AutoPostBack="True" onselectedindexchanged="ddlState_SelectedIndexChanged" >
                            <asp:ListItem>Gujarat</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" 
                            ControlToValidate="ddlState" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                        &nbsp;<span class="style2">*</span>
                    </td>
             
                    <td class="style5">
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown">
                            <asp:ListItem>Surat</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" 
                            ControlToValidate="ddlCity" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                        <span class="style2">*</span>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtPinCode" runat="server" ValidationGroup="Submit" 
                            Width="" CssClass="inputtext"></asp:TextBox>
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
                    <td class="style4">
                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                        &nbsp;<span class="style2">*</span></td>
                    <td class="style5">
                        <asp:TextBox ID="txtMobileNo" runat="server" Width="" 
                            ValidationGroup="Submit" CssClass="inputtext" MaxLength="10"></asp:TextBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" 
                            ControlToValidate="txtMobileNo" ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvMobileNo" runat="server" 
                            ErrorMessage="Enter Valid MobileNo" ControlToValidate="txtMobileNo" 
                            MaximumValue="9999999999" MinimumValue="7000000000" ValidationGroup="Submit" 
                            ForeColor="Red"></asp:RangeValidator>
                        <br />
                         </td>
                </tr>
                <tr>
                   <td class="style4">
                        <asp:Label ID="lblIPAddress" runat="server" Text="IP Address"></asp:Label>
                        &nbsp;<span class="style2">*</span></td>
                 <td class="style5">
                 <asp:TextBox ID="txtIpaddress" class="inputtext" runat="server"></asp:TextBox>
                 </td>
                 <td>
            <asp:RequiredFieldValidator ID="rfvIpaddress" runat="server" ErrorMessage="*" 
                        SetFocusOnError="True" ValidationGroup="Submit" 
                        ControlToValidate="txtIpaddress" ForeColor="Red"></asp:RequiredFieldValidator>
       <asp:RegularExpressionValidator ID="reIpaddress" runat="server" ErrorMessage="Invalid IP!" 
                        ValidationExpression="^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$" 
                        ValidationGroup="Submit" ControlToValidate="txtIpaddress" 
                        SetFocusOnError="True" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
                </tr>



                
                
                     <tr>
                     <td class="style4">  <asp:Label ID="lblProfilePic" runat="server" Text="Upload Your ProfilePic"></asp:Label>      </td>
                     <td class="style5"> 
                         <asp:FileUpload ID="fuProfilePic" runat="server"></asp:FileUpload>      </td>
                     
                     <td> <asp:Label ID="lblProfilePicture" runat="server" ForeColor="Red"></asp:Label></td>
                     
                     </tr>   
                   </table>
                   <table>
                <tr>
                    <td class="style7">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
                        <br />
                        <br />
                    </td>
                    <td class="style6" >
                       
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" 
                             Text="Submit" ValidationGroup="Submit" onclick="btnSubmit_Click" />
                        &nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-info" 
                             Text="Reset" onclick="btnReset_Click" />

                    &nbsp;<asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info" 
                             Text="Cancel" onclick="btnCancel_Click" />
                    
                    </td>
                </tr>
    

     </table>
                        </div>
                    </div>
                </div>
                <!-- END EXAMPLE TABLE widget-->
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
    <script type="text/javascript" src="../js/table-editable.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
</asp:Content>
