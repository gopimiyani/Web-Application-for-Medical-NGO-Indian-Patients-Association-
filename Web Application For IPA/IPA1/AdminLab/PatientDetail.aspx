<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="PatientDetail.aspx.cs" Inherits="IPA1.AdminLab.View_Patient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
                
               input[type="text"],input[type="textarea"]
        {
            width:206px;
        }
   
   
        .style1
        {
            width: 161px
        }
   
        .style2
        {
            width: 200px;
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
                    Patient <small></small>
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvPatient" runat="server" ActiveViewIndex="0">
            <br />
            <asp:View ID="vPatient" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    
                    <li><a href="#">Patient</a><span class="divider-last">&nbsp;</span></li>
                
                    
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
                                            <i class="icon-reorder"></i>Patient</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                               
                                               
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
                                              
                                            </div>
                                                <asp:GridView ID="gvPatientDetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                    CellPadding="4" DataKeyNames="Patient_ID" EnableModelValidation="True" ForeColor="#333333"
                                                    GridLines="Both" BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid"
                                                    AllowSorting="True"  class="table table-striped table-hover" OnPageIndexChanging="gvPatientDetail_PageIndexChanging1"
                                                    OnRowCommand="gvPatientDetail_RowCommand1" OnSorting="gvPatientDetail_Sorting1">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Patient ID" SortExpression="Patient_ID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Patient_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblIID" runat="server" Text='<%#Eval("Patient_ID") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Patient Name" SortExpression="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtName" class="inputtext" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact No" SortExpression="MobileNo">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtMobileNo" class="inputtext" runat="server" Text='<%#Eval("MobileNo") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Address" SortExpression="Address">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtAddress" class="inputtext" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" class="btn btn-primary" runat="server" Text="View" CommandName="View"
                                                                    CommandArgument='<%#Eval("Patient_ID") %>' />
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
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END SAMPLE TABLE widget-->
                </div>
            </asp:View>
            <asp:View ID="vPatientDetail" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                   <li><asp:LinkButton ID="lblPatient" runat="server" onclick="lblPatient_Click" >Patient</asp:LinkButton>
                <span class="divider">&nbsp; </span></li>
                    <li><a href="#">Patient Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Patient Detail</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                              
                                            </div>
                                            <div class="space15">
                                            </div>
                                            <table >
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblPatientID" runat="server" Text="Patient_ID"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtPatientID" runat="server" MaxLength="20" 
                                                            CssClass="inputtext" Width="206px" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblRequestID" runat="server" Text="Request_ID"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtRequestID" runat="server" MaxLength="20" 
                                                            CssClass="inputtext" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtName" runat="server" MaxLength="20" CssClass="inputtext" 
                                                            Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="reName" runat="server" ControlToValidate="txtName"
                                                            ErrorMessage="Alphabates Only" ValidationExpression="[a-z A-Z]+" 
                                                            ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtAddress" runat="server" Font-Bold="False" MaxLength="100" 
                                                            CssClass="inputtext" Rows="4" TextMode="MultiLine" Width="206px" 
                                                            Enabled="False"></asp:TextBox>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" 
                                                            CssClass="inputtext" Enabled="False"></asp:TextBox>
                                                </td>
                                                <td class="style2">
                                                    <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" 
                                                        ControlToValidate="txtMobileNo" ErrorMessage="*" ForeColor="Red" 
                                                        ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ID="cvMobileNo" runat="server" 
                                                        ControlToValidate="txtMobileNo" ErrorMessage="Contact no must be in 10 digit" 
                                                        ForeColor="Red" OnServerValidate="cvMobileNo_ServerValidate" 
                                                        ValidationGroup="Submit"></asp:CustomValidator>
                                                    <td>
                                                        &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                        <td>

                                                        </td>
                                                        <td>
                                                        <asp:RegularExpressionValidator ID="revMobileNo" runat="server" 
                                                            ControlToValidate="txtMobileNo" ErrorMessage="Enter Digits Only" 
                                                            ForeColor="Red" ValidationExpression="[0-9]+" ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                                                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Enabled="False">
                                                            <asp:ListItem>Gujarat</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown" 
                                                            Enabled="False">
                                                            <asp:ListItem>Surat</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="style2">
                                                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style1">
                                                        <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                                                    </td>
                                                    <td class="style5">
                                                        <asp:TextBox ID="txtPinCode" runat="server" MaxLength="6" CssClass="inputtext" 
                                                            Enabled="False"></asp:TextBox>
                                                        </td>
                                                        <td>

                                                        <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode"
                                                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        
                                                        <asp:CustomValidator ID="cvPinCode" runat="server" ControlToValidate="txtPinCode"
                                                            ErrorMessage="Pincode must be in 6 digit " OnServerValidate="cvPinCode_ServerValidate"
                                                            ValidationGroup="Submit" ForeColor="Red"></asp:CustomValidator>

                                                        </td>
                                                        </tr>
                                                        <tr>
                                                        <td></td>
                                                        <td>
                                                        <asp:RegularExpressionValidator ID="rePinCode0" runat="server" 
                                                            ControlToValidate="txtPinCode" ErrorMessage="Enter Digits Only" ForeColor="Red" 
                                                            ValidationExpression="[0-9]+" ValidationGroup="Submit"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td class="style2">
                                                        
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td class="style1" >
                                                        
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"
                                                            ValidationGroup="Submit" CssClass="btn btn-primary" />
                                                    </td>
                                                    <td>
                                                        &nbsp;<asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click"
                                                            CssClass="btn btn-primary" Visible="false" />
                                                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-primary"
                                                            OnClick="btnCancel_Click" />
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
    <script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../assets/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/jquery.blockui.js"></script>
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
        document.getElementById("btnAssign").onclick = function () {
            location.href = "~/AssignTask.aspx";
        };
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
