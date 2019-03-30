<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="BloodBankDetail.aspx.cs" Inherits="IPA1.AdminLab.BloodBankDetail" %>

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
         .lblselect
        {
         padding: 0px 5px 0px 15px;
         vertical-align: middle;   
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
                    BloodBank <small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvBloodBank" runat="server" ActiveViewIndex="0">
            <br />
            <asp:View ID="vBloodBank" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">BloodBank</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>BloodBank</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                <div class="btn-group">
                                                    <div class="form-group form-inline">
                                                        <asp:Button ID="btnNew" class="btn btn-primary" runat="server" Text="New" OnClick="btnNew_Click1">
                                                        </asp:Button>
                                                        <asp:Label ID="lblUserType" runat="server" Text="Select Any BloodBank" ForeColor="#2A6496"
                                                            Font-Bold="True" Font-Names="Verdana" Font-Size="12pt" CssClass="lblselect" ></asp:Label>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:DropDownList ID="ddlBloodBankName" runat="server" AutoPostBack="True" CssClass=""
                                                            OnSelectedIndexChanged="ddlBloodBank_SelectedIndexChanged"
                                                            style="margin-bottom:0px;">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            
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
                                        <asp:GridView ID="gvBloodBank" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="4" DataKeyNames="BloodBankDetail_ID" EnableModelValidation="True"
                                            ForeColor="#333333" GridLines="Both" BorderWidth="1px" BorderColor="#cccccc"
                                            BorderStyle="Solid" OnPageIndexChanging="gvBloodBank_PageIndexChanging" OnRowCommand="gvBloodBank_RowCommand1"
                                            PageSize="5" class="table table-striped table-hover" AllowSorting="True"
                                            OnSorting="gvBloodBank_Sorting">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="BloodBankDetail ID" SortExpression="BloodBankDetail_ID"
                                                    Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBloodBankDetail_ID" runat="server" Text='<%#Eval("BloodBankDetail_ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BloodBank's Name" SortExpression="FirstName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStakeHolder" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtStakeHolder" runat="server" Enabled="false" Text='<%#Eval("FirstName") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Patient's Name" SortExpression="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPName" runat="server" Enabled="false" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BillNo" SortExpression="BillNo">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblBillNo" runat="server" Text='<%#Eval("BillNo") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtBillNo" runat="server" Enabled="false" Text='<%#Eval("BillNo") %>'></asp:TextBox></EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount" SortExpression="TotalAmount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="false" Text='<%#Eval("TotalAmount") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Discount" SortExpression="Discount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("Discount") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtDiscount" runat="server" Enabled="false" Text='<%#Eval("Discount") %>'></asp:TextBox></EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Final Amount" SortExpression="FinalAmount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFinalAmount" runat="server" Text='<%#Eval("FinalAmount") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtFinalAmount" runat="server" Enabled="false" Text='<%#Eval("FinalAmount") %>'></asp:TextBox></EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Payment Status" SortExpression="PaymentStatus">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPaymentStatus" runat="server" Text='<%#Eval("PaymentStatus") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPaymentStatus" runat="server" Enabled="false" Text='<%#Eval("PaymentStatus") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnView" class="btn btn-primary" runat="server" Text="View" CommandName="View"
                                                            CommandArgument='<%#Eval("BloodBankDetail_ID") %>' />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EditRowStyle BackColor="#ebebeb" />
                                            <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="Red" />
                                            <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                            <PagerStyle BackColor="#d6d6d6" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END SAMPLE TABLE widget-->
                    </div>
            </asp:View>
            <asp:View ID="vBloodBankDetail" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li>
                        <asp:LinkButton ID="lbBloodBank" runat="server" OnClick="lbBloodBank_Click">BloodBank</asp:LinkButton>
                        <span class="divider">&nbsp; </span></li>
                    <li><a href="#">BloodBank Service Detail</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- BEGIN PAGE CONT<asp:LinkButton runat="server">LinkButton</asp:LinkButton>ENT-->
                <div class="row-fluid">
                    <div class="span12">
                        <!-- BEGIN ADVANCED TABLE<asp:LinkButton runat="server">LinkButton</asp:LinkButton> widget-->
                        <div class="row-fluid">
                            <div class="span12">
                                <!-- BEGIN EXAMPLE TABLE widget-->
                                <div class="widget">
                                    <div class="widget-title">
                                        <h4>
                                            <i class="icon-reorder"></i>BloodBank Service Detail</h4>
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
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                            <ContentTemplate>
                                                <table class="">
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="txtBloodBankDetail_ID" runat="server" Visible="false"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                            <asp:Label ID="lblBillNo" runat="server" Text="Bill No"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBillNo" runat="server" Enabled="False"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                            <asp:Label ID="lblBloodBankName" runat="server" Text="BloodBank's Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlBBName" runat="server" Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                            <asp:Label ID="lblPatientName" runat="server" Text="Patient's Name"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlName" runat="server" Enabled="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                            <asp:Label ID="lblBloodGroup" runat="server" Text="BloodGroup"></asp:Label>
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
                                                            <asp:TextBox ID="txtNoOfBottle" runat="server" AutoPostBack="True" OnTextChanged="txtNoOfBottle_TextChanged"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rvNoOfBottle" runat="server" ErrorMessage="*" ForeColor="Red"
                                                                ControlToValidate="txtNoOfBottle" ValidationGroup="Submit" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                            <%--    <asp:RegularExpressionValidator ID="reNoOfBottle" runat="server" ErrorMessage="Enter only Digits"
                                                    ControlToValidate="txtNoOfBottle" ValidationExpression="\d+" ValidationGroup="Submit"
                                                    ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                                            --%>
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
                                                            <asp:Label ID="lblcvRate" runat="server" ForeColor="Red"></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                            <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="False"></asp:TextBox>
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
                                                                AutoPostBack="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rvDiscount" runat="server" ErrorMessage="*" ForeColor="Red"
                                                                ControlToValidate="txtDiscount" ValidationGroup="Submit" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                            <asp:Label ID="lblcvDiscount" runat="server" ForeColor="Red"></asp:Label>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                            <asp:Label ID="lblDiscountAmount" runat="server" Text="Discount Amount"></asp:Label>
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtDiscountAmount" runat="server" Enabled="False"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtFinalAmount" runat="server" Enabled="False"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="style1">
                                                            <asp:Label ID="lblPStatus" runat="server" Text="Payment Status"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPStatus" runat="server" Enabled="False">
                                                                <asp:ListItem>Unpaid</asp:ListItem>
                                                                <asp:ListItem>Paid</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlBloodGroup" />
                                                <asp:AsyncPostBackTrigger ControlID="txtDiscount" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <br />
                                                    <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Submit"
                                                        class="btn btn-primary">
                            <i class="icon-ok icon-white"></i>
                            Submit
                                                    </asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="btnReset" runat="server" OnClick="btnReset_Click" class="btn btn-primary">
                               <i class="icon-refresh"></i>
                                Reset
                                                    </asp:LinkButton>
                                                    &nbsp;<asp:LinkButton ID="btnCancel" runat="server" OnClick="btnCancel_Click" class="btn btn-primary">
                                  <i class="icon-ban-circle"></i>
                                 Cancel
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                        <%--<table>
                                    

                                        <tr align="center">
                                            <td>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click"
                                                    ValidationGroup="Submit" />
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" OnClick="btnReset_Click" />
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                        --%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
    </div>
    </div> </asp:View> </asp:MultiView> </div>
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
    <script>
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
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
