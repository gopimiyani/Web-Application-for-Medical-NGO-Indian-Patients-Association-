<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true"
    CodeBehind="SHMast.aspx.cs" Inherits="IPA1.SuperAdmin.SHMast" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    Stakeholder Master<%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Master</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Stakeholder Master</a><span class="divider-last">&nbsp;</span></li>
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
                            <i class="icon-reorder"></i>Stakeholder Master</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                                <%--   <div class="btn-group">
                                  <button id="sample_editable_1_new" class="btn green">
                                        Add New <i class="icon-plus"></i>
                                    </button>
                                    </div>
                                --%>
                                 <div class="btn-group pull-right">
                                    <button class="btn dropdown-toggle" data-toggle="dropdown">
                                        Tools <i class="icon-angle-down"></i>
                                    </button>
                                    <ul class="dropdown-menu pull-right">
                                        <%--<li>
                                            <asp:LinkButton ID="lbPrint" runat="server">Print</asp:LinkButton>
                                        </li>--%>
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
                            </div><div class="space12">
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
                                        <asp:Label ID="Label1" runat="server" Text="records per page"></asp:Label>
                                    </div>
                                </div>
                                <div class="span6">
                                    <div class="dataTables_filter">
                                        <asp:Label ID="lblSearch" runat="server" Text="Search"></asp:Label>
                                        <asp:TextBox ID="txtSearch" runat="server" onkeyup="RefreshUpdatePanel();" AutoPostBack="true"
                                            OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="Update" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gvSH" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        DataKeyNames="StakeHolder_ID" OnPageIndexChanging="GridView1_PageIndexChanging"
                                        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                                        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ShowFooter="True"
                                        ForeColor="#333333" GridLines="None" PageSize="5" class="table table-striped table-hover"
                                        AllowSorting="True" OnSorting="gvSH_Sorting">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Stakeholder ID" SortExpression="StakeHolder_ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSHId" runat="server" Text='<%#Eval("StakeHolder_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtSHId" runat="server" Enabled="false" Text='<%#Eval("StakeHolder_ID") %>'> </asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stakeholder Name" SortExpression="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSHName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtSHName" runat="server" Text='<%#Eval("Name") %>'> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtName" runat="server" ControlToValidate="txtSHName"
                                                        ForeColor="Red" ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="retxtSHName" runat="server" ErrorMessage="Alphabates Only!"
                                                        ControlToValidate="txtSHName" ValidationGroup="Update" ValidationExpression="[a-zA-Z ]+"
                                                        SetFocusOnError="True" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtISHName" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtIName" runat="server" ControlToValidate="txtISHName"
                                                        ForeColor="Red" ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                                    <asp:RegularExpressionValidator ID="retxtSHName" runat="server" ErrorMessage="Alphabates Only!"
                                                        ControlToValidate="txtISHName" ValidationGroup="Insert" ValidationExpression="[a-zA-Z ]+"
                                                        SetFocusOnError="True" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn btn-info" CommandName="Edit">
                                                    </asp:Button>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Update" Text="Update"
                                                        class="btn  btn-inverse" CommandName="Update" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button ID="btnInsert" runat="server" class="btn  btn-info" ValidationGroup="Insert"
                                                        Text="Insert" OnClick="btnInsert_Click" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" class="btn  btn-info" CommandName="Delete" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn  btn-inverse"
                                                        CommandName="Cancel" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#ebebeb" />
                                        <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="" />
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
    <%--<script type="text/javascript" src="../assets/uniform/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../assets/data-tables/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../assets/data-tables/DT_bootstrap.js"></script>
    <script type="text/javascript" src="../js/table-editable.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>

    --%>
    <script type="text/javascript" src="../assets/uniform/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../assets/data-tables/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../assets/data-tables/DT_bootstrap.js"></script>
    <script src="../js/scripts.js"></script>
    <script src="../js/table-editable.js"></script>
    <script>
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
</asp:Content>
