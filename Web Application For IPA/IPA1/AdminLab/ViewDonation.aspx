<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="ViewDonation.aspx.cs" Inherits="IPA1.AdminLab.ViewDonation" EnableEventValidation=false %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 108px;
        }
        .style3
        {
            width: 190px;
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
                    Donation
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvDonation" runat="server" ActiveViewIndex="0">
            <br />
            <asp:View ID="vDonation" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Donation</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Donation</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                <div class="btn-group">
                                               
                                                    <asp:LinkButton ID="btnNew" runat="server" class="btn btn-info" OnClick="BtnNew_Click">
                                                    <i class="icon-plus icon-white"></i>
                                                   Donate
                                                    
                                                    </asp:LinkButton>
                                                </div>
                                                
                                                <div class="btn-group pull-right">
                                                    <button class="btn dropdown-toggle" data-toggle="dropdown">
                                                        Tools <i class="icon-angle-down"></i>
                                                    </button>
                                                    <ul class="dropdown-menu pull-right">
                                                       
                                                        <li>
                                                            <asp:LinkButton ID="lbSaveAsPDF" runat="server" OnClick="lbSaveAsPDF_Click">Save as PDF</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbExportToExcel" runat="server" OnClick="lbExportToExcel_Click">Export to Excel</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbExportToWord" runat="server" OnClick="lbExportToWord_Click">Export to Word</asp:LinkButton>
                                                        </li>
                                                    </ul>
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
                                                        <asp:TextBox ID="txtSearch" runat="server" Visible="false"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--<asp:UpdatePanel ID="Update" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>--%>
                                                    <asp:GridView ID="GridView1" runat="server"  AllowPaging="True" AutoGenerateColumns="False"
                                                        ShowFooter="True" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="Donation_ID"
                                                        OnRowCommand="GridView1_RowCommand" OnSorting="GridView1_Sorting" AllowSorting="True"
                                                        CellPadding="4" ForeColor="#333333" GridLines="None" class="table table-striped table-hover"
                                                        PageSize="5" >
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Donation ID" SortExpression="Donation_ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDonationId" runat="server" Text='<%#Eval("Donation_ID") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtDonationId" runat="server" Enabled="false" Text='<%#Eval("Donation_ID") %>'> </asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnView" runat="server" Text="View" class="btn btn-info" CommandName="View"
                                                                        CommandArgument='<%#Eval("Donation_ID") %>'></asp:Button>
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
                                                      </ContentTemplate>
                               <%-- <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtSearch" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END SAMPLE TABLE widget-->
                </div>
            </asp:View>
            <asp:View ID="vDonationDetail" runat="server">
                <ul class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li>
                        <asp:LinkButton ID="lbDonation" runat="server" OnClick="lbDonation_Click">Donation</asp:LinkButton>
                        <span class="divider">&nbsp;</span></li>
                    <li><a href="#">Donation Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Donation Detail</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                
                                            </div>
                                            <div class="space15">
                                            </div>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td class="style3">
                                                        <asp:Label ID="lblType" runat="server" Text="Payment Type"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtType" runat="server" Font-Bold="False" MaxLength="100" CssClass="inputtext"
                                                            Width="206px" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style3">
                                                        <asp:Label ID="lblAmount" runat="server" Text="Amount"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAmount" runat="server" Font-Bold="False" MaxLength="100" CssClass="inputtext"
                                                            Width="206px" Enabled="false"></asp:TextBox>
                                                    
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="style3">
                                                        <asp:Label ID="lblChequeNo" runat="server" Text="Cheque No"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtChequeNo" runat="server" MaxLength="10" CssClass="inputtext"
                                                            Width="206px" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style3">
                                                        <asp:Label ID="lblChequeDate" runat="server" Text="Cheque Date"></asp:Label>
                                                        <span class="style2"></span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtChequeDate" runat="server" Width="206px" Height="22px" Enabled="false"></asp:TextBox>
                                                        <cc:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MM-yyyy" TargetControlID="txtChequeDate">
                                                        </cc:CalendarExtender>
                                                    </td>
                                                </tr>
                                               <%-- <tr>
                                                    <td class="style3">
                                                        <asp:Label ID="lblBankName" runat="server" Text="Bank Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBankName" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>--%>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td class="style3">
                                                    </td>
                                                    <td>
                                                        <br />
                                                        <%-- <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Submit"
                                                                class="btn btn-primary">
                            <i class="icon-ok icon-white"></i>
                            Submit
                                                            </asp:LinkButton>--%>
                                                        &nbsp;<asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" class="btn btn-primary">
                               <i class="icon-refresh"></i>
                                Cancel
                                                        </asp:LinkButton>
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
    <script type="text/javascript" src="../js/table-editable.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
</asp:Content>
