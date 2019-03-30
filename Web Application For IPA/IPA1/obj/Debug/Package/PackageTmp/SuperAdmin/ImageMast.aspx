<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true"
    CodeBehind="ImageMast.aspx.cs" Inherits="IPA1.SuperAdmin.ImageMast" EnableEventValidation="false" %>

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
                    Image Master
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Master</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Image Master</a><span class="divider-last">&nbsp;</span></li>
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
                            <i class="icon-reorder"></i>Image Master</h4>
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
                                      <%--  <li>
                                            <asp:LinkButton ID="lbPrint" runat="server">Print</asp:LinkButton>
                                        </li> --%>
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
                         <%--   <asp:UpdatePanel ID="Update" runat="server">
                                <ContentTemplate>--%>
                                    <asp:GridView ID="gvImage" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                        AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Image_ID" ShowFooter="True"
                                        OnPageIndexChanging="gvImage_PageIndexChanging" OnRowCancelingEdit="gvImage_RowCancelingEdit"
                                        OnRowDeleting="gvImage_RowDeleting" OnRowEditing="gvImage_RowEditing" OnRowUpdating="gvImage_RowUpdating"
                                        OnSelectedIndexChanged="gvImage_SelectedIndexChanged" BorderWidth="1px" BorderColor="#cccccc"
                                        BorderStyle="Solid" class="table table-striped table-hover" 
                                        PageSize="5" AllowSorting="True" onsorting="gvImage_Sorting">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Image ID" SortExpression="Image_ID">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%#Eval("Image_ID")%>' ID="lblImageId"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtImageId" class="inputtext" runat="server" Text='<%#Eval("Image_ID")%>'
                                                        Enabled="False"></asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Image " SortExpression="ImageName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblImageName" runat="server" Text='<%#Eval("ImageName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblImageID" runat="server" Text='<%#Eval("Image_ID") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblImageName" runat="server" Text='<%#Eval("ImageName") %>' Visible="true"></asp:Label>
                                                    <asp:FileUpload ID="fuImageName" runat="server" Visible="true"></asp:FileUpload>
                                                    <asp:RequiredFieldValidator ID="rfvImageName" runat="server" ErrorMessage="*" ControlToValidate="fuImageName"
                                                        ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                    <%--<asp:RegularExpressionValidator ID="reImageName" runat="server" ErrorMessage="Invalid File! Please Upload a File with valid Extension" ValidationExpression="/^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpeg|.JPEG|.gif|.GIF| .png|.PNG)$/;" ValidationGroup="Update" ControlToValidate="fuImageName" ></asp:RegularExpressionValidator>--%>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:FileUpload ID="fuImageInsert" runat="server"></asp:FileUpload>
                                                    <asp:RequiredFieldValidator ID="rfvImageName" runat="server" ErrorMessage="*" ValidationGroup="Insert"
                                                        ControlToValidate="fuImageInsert"></asp:RequiredFieldValidator>
                                                    <%-- <asp:RegularExpressionValidator ID="reIImageName" runat="server" ErrorMessage="Invalid File! Please Upload a File with valid Extension" ValidationExpression="/^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.jpeg|.JPEG|.gif|.GIF| .png|.PNG)$/;" ValidationGroup="Insert" ControlToValidate="fuImageInsert" ></asp:RegularExpressionValidator>--%>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Album Name" SortExpression="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAlbumName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblAlbumId" runat="server" Text='<%#Eval("Album_ID") %>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlEditAlbumName" runat="server" Visible="true">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:DropDownList ID="ddlAlbumName" runat="server" CssClass="form-grid_dropdown">
                                                    </asp:DropDownList>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" class="btn btn-info" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" class="btn btn-info"
                                                        ValidationGroup="Update" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button ID="btnInsert" runat="server" Text="Insert" ValidationGroup="Insert"
                                                        class="btn btn-primary" OnClick="btnInsert_Click" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        
                                          <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" class="btn btn-info" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" class="btn btn-info" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                        
                                        
                                        </Columns>
                                        <EditRowStyle BackColor="#ebebeb" />
                                        <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="" />
                                        <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                        <PagerStyle BackColor="#d6d6d6" ForeColor="#5c5c5c" HorizontalAlign="Center" />
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
