<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="ViewInquiry.aspx.cs" Inherits="IPA1.AdminLab.ViewInquiry" EnableEventValidation=false %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 148px;
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
                    Inquiry <small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvInquiry" runat="server" ActiveViewIndex="0">
            <br />
            <asp:View ID="vInquiry" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Inquiry</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Inquiry</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                
                                               <div class="btn-group pull-right">

                                    <button class="btn dropdown-toggle" data-toggle="dropdown">
                                        Tools <i class="icon-angle-down"></i>
                                  </button>
                                   
                                    <ul class="dropdown-menu pull-right">
                                       
                                        <li>
                                               <asp:LinkButton ID="lbSaveAsPDF" runat="server" onclick="lbSaveAsPDF_Click">Save as PDF</asp:LinkButton>
                                        </li>
                                        <li>
                                          <asp:LinkButton ID="lbExportToExcel" runat="server" onclick="lbExportToExcel_Click">Export to Excel</asp:LinkButton>
                                        </li>
                                        <li>
                                          <asp:LinkButton ID="lbExportToWord" runat="server" onclick="lbExportToWord_Click">Export to Word</asp:LinkButton>
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
                                            <asp:UpdatePanel ID="Update" runat="server">
                                <ContentTemplate>
                                            <asp:GridView ID="gvInquiry" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                ShowFooter="True" OnPageIndexChanging="gvInquiry_PageIndexChanging" DataKeyNames="Inquiry_ID"
                                                OnRowCommand="gvInquiry_RowCommand" OnSorting="gvInquiry_Sorting" AllowSorting="True"
                                                CellPadding="4" ForeColor="#333333" GridLines="None" class="table table-striped table-hover"
                                                PageSize="5">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Inquiry ID" SortExpression="Inquiry_ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInquiryID" runat="server" Text='<%#Eval("Inquiry_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtInquiryID" runat="server" Enabled="false" Text='<%#Eval("Inquiry_ID") %>'> </asp:TextBox>
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
                                                    <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnView" runat="server" Text="View" class="btn btn-info" CommandName="View"
                                                                CommandArgument='<%#Eval("Inquiry_ID") %>'></asp:Button>
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
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="txtSearch" />
                                </Triggers>
                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END SAMPLE TABLE widget-->
                </div>
            </asp:View>
            <asp:View ID="vInquiryDetail" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li>
                        <asp:LinkButton ID="lbInquiry" runat="server" OnClick="lbInquiry_Click">Inquiry</asp:LinkButton>
                        <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Inquiry Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Inquiry Detail</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                               
                                                </div>
                                            </div>
                                            <div class="space15">
                                            </div>
                                            <table class="">
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblInquiryID" runat="server" Text="Inquiry ID"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtInquiryID" runat="server" ReadOnly="True" Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtName" runat="server" ReadOnly="True" Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True" Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSubject" runat="server" ReadOnly="True" Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblMessage" runat="server" Text="Message"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtmessage" runat="server" ReadOnly="True" Rows="4" TextMode="MultiLine"
                                                            Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblAnswer" runat="server" Text="Answer"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAnswer" runat="server" Rows="4" TextMode="MultiLine" Width="210px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td class="style1">
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Submit"
                                                            class="btn btn-primary">
                            <i class="icon-ok icon-white"></i>
                            Submit
                                                        </asp:LinkButton>
                                                        &nbsp;<asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" class="btn btn-primary">
                               <i class="icon-ban-circle"></i>
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
    <script>
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
    
    
</asp:Content>
