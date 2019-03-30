<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="BloodBankDetailForm.aspx.cs" Inherits="IPA1.AdminLab.BloodBankDetailForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input[type="text"], input[type="textarea"]
        {
            width: 206px;
        }
        .style1
        {
            width: 210px;
        }
        .style2
        {
            color: #FF0000;
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
                    BloodBank Detail Form
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="BloodBankDetail.aspx">BloodBank</a> <span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">BloodBank Detail Form</a><span class="divider-last">&nbsp;</span></li>
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
                            <i class="icon-reorder"></i>BloodBank Detail Form</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                            </div>
                        </div>
                        
                    </div>
                    <div class="space10">
                    </div>
                    <!-- Here Put grid or table -->
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <table class="" style="margin-left: 15px;">
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblBillNo" runat="server" Text="Bill No"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBillNo" runat="server" Enabled="False" MaxLength="8"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblBloodBankName" runat="server" Text="BloodBank's Name"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBloodBankName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBloodBankName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcvBBName" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblName" runat="server" Text="Patient's Name"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcvName" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBloodGroup" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBloodGroup_SelectedIndexChanged">
                                            <asp:ListItem>--Select Blood Group--</asp:ListItem>
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
                                        <asp:Label ID="lblcvBloodGroup" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblNoOfBottle" runat="server" Text="No Of Bottle"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoOfBottle" runat="server" OnTextChanged="txtNoOfBottle_TextChanged1"
                                            AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rvNoOfBottle" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtNoOfBottle" ValidationGroup="Submit" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <%-- <asp:RegularExpressionValidator ID="reNoOfBottle" runat="server" 
                                            ErrorMessage="Enter only Digits" ControlToValidate="txtNoOfBottle" 
                                            ValidationExpression="\d+" ValidationGroup="Submit" ForeColor="Red" 
                                            SetFocusOnError="True"></asp:RegularExpressionValidator>
                                        --%>
                                        <br />
                                        <asp:Label ID="lblcvNoOfBottle" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblRate" runat="server" Text="Rate(Per Bottle)"></asp:Label>
                                        <span class="style2">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRate" runat="server" AutoPostBack="True" OnTextChanged="txtRate_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rvRate" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtRate" ValidationGroup="Submit" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:Label ID="lblcvRate" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="False" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcvTotalAmount" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblDiscount" runat="server" Text="Discount"></asp:Label>
                                        &nbsp;(%)<span class="style2">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiscount" runat="server" OnTextChanged="txtDiscount_TextChanged1"
                                            AutoPostBack="True" MaxLength="6"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rvDiscount" runat="server" ErrorMessage="*" ForeColor="Red"
                                            ControlToValidate="txtDiscount" ValidationGroup="Submit" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:Label ID="lblcvDiscount" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblDiscountAmount" runat="server" Text="Discount Amount"></asp:Label>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDiscountAmount" runat="server" Enabled="False" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="lblFinalAmount" runat="server" Text="Final Amount"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFinalAmount" runat="server" Enabled="False" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                               
                            </table>
                            <br />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlName" />
                            <asp:AsyncPostBackTrigger ControlID="ddlBloodBankName" />
                            <asp:AsyncPostBackTrigger ControlID="ddlBloodGroup" />
                            <asp:AsyncPostBackTrigger ControlID="txtDiscount" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <table style="margin-left: 15px;">
                        <tr align="center">
                             <td class="style4">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                  
                           
                             <td>
                                  

                               <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click"
                                ValidationGroup="Submit" class="btn btn-primary">
                            <i class="icon-ok icon-white"></i>
                            Submit
                            </asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="btnReset" runat="server" OnClick="btnReset_Click"
                                 class="btn btn-primary">
                               <i class="icon-refresh"></i>
                                Reset
                                </asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                                 class="btn btn-primary">
                                  <i class="icon-ban-circle"></i>
                                 Cancel
                                 </asp:LinkButton>
                                
                             </td>
                                  
                        </tr>
                    </table>
                     <br />
                </div>
            </div>
        </div>
        <!-- END EXAMPLE TABLE widget-->
    </div>
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
