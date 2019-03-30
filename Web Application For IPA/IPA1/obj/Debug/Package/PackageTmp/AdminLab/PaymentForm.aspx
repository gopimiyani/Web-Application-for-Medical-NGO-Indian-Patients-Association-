<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="PaymentForm.aspx.cs" Inherits="IPA1.AdminLab.PaymentForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input[type="text"], input[type="textarea"]
        {
            
        }
        
        
        .style2
        {
            width: 147px;
            height: 38px;
            color: #FF0000;
        }
        .style3
        {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                    Make a Payment</h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                     <li><a href="PaymentDetail.aspx">Payment Detail</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Make a Payment</a><span class="divider-last">&nbsp;</span></li>
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
                            Make a Payment</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                                
                            </div>
                            &nbsp;
                            <asp:UpdatePanel ID="Update" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblPaymentID" runat="server" Text="Payment_ID"></asp:Label>
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtPaymentID" runat="server" MaxLength="20" CssClass="inputtext"
                                                        Width="206px" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </td>
                                            <%--<td>
                                        <asp:RequiredFieldValidator ID="rfvPaymentID"" runat="server" ControlToValidate="txtPaymentID"
                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                        
                                    </td>--%>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblselecttype" runat="server" Text="User Type"></asp:Label>
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                               
                                                <asp:DropDownList ID="ddlselecttype" runat="server" AutoPostBack="True" 
                                                    Width="220px" onselectedindexchanged="ddlselecttype_SelectedIndexChanged1">
                                                </asp:DropDownList>                
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcvType" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                                                <span class="style2">*</span></td>
                                            <td>
                                                <asp:DropDownList ID="ddlName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged"
                                                    Height="30px" Width="220px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcvName" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblBillNo" runat="server" Text="BillNo"></asp:Label>
                                                <span class="style2">*</span></td>
                                            <td>
                                                <asp:DropDownList ID="ddlBillNo" runat="server" Width="220px" 
                                                    AutoPostBack="True" onselectedindexchanged="ddlBillNo_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                              <td>
                                                <asp:Label ID="lblcvBillNo" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblAmount" runat="server" Text="Total Amount"></asp:Label>
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTotalAmount" runat="server" Font-Bold="False" 
                                                    MaxLength="100" CssClass="inputtext"
                                                    Width="206px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblChequeNo" runat="server" Text="Cheque No"></asp:Label>
                                                <span class="style2">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChequeNo" runat="server" MaxLength="10" CssClass="inputtext"
                                                    Width="206px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvChequeNo" runat="server" ControlToValidate="txtChequeNo"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="reChequeNo" runat="server" ControlToValidate="txtChequeNo"
                                                    ErrorMessage="Cheque No must be of 6 digit" ValidationExpression="(\d{6})" ValidationGroup="Submit"
                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblChequeDate" runat="server" Text="Cheque Date"></asp:Label>
                                                <span class="style2"></span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtChequeDate" runat="server" Width="206px"></asp:TextBox>
                                                <cc:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" 
                                                    TargetControlID="txtChequeDate">
                                                </cc:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                                        <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlselecttype" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlName" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlBillNo" />
                                        </Triggers>
                                        </asp:UpdatePanel>
                                        
                                    <table>
                                        <tr>
                                            <td class="style3">
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbconfirmstep" runat="server" AutoPostBack="True" 
                                                    oncheckedchanged="cbconfirmstep_CheckedChanged" Text="Confirm All Steps" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <br />
                                                <br />
                                                <br />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit"
                                                    ValidationGroup="Submit" OnClick="btnSubmit_Click" />
                                                &nbsp;<asp:Button ID="btnReset" runat="server" CssClass="btn btn-primary" Text="Reset"
                                                    OnClick="btnReset_Click" />
                                                &nbsp;<asp:Button ID="btnCancle" runat="server" CssClass="btn btn-primary" Text="Cancel"
                                                    OnClick="btnCancle_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    </div> </div> </div>
                                    <!-- END EXAMPLE TABLE widget-->
                                    </div> </div>
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
                               <%-- </ContentTemplate>
                            </asp:UpdatePanel>--%>
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
