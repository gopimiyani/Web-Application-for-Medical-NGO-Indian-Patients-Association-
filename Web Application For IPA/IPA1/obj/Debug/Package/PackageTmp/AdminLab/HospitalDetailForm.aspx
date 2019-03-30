<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="HospitalDetailForm.aspx.cs" Inherits="IPA1.AdminLab.HospitalDetailForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input[type="text"], input[type="textarea"]
        {
            width: 206px;
        }
        .style1
        {
            color: #FF0000;
        }
        
        .style2
        {
            width: 123px;
        }
        .style3
        {
            width: 220px;
        }
        .style4
        {
            width: 220px;
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
                    Hospital Service Detail Form
                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="HospitalDetail.aspx">Hospital</a><span class="divider">&nbsp;</span></li>
                    <li><a href="#">Hospital Service Detail Form</a><span class="divider-last">&nbsp;</span></li>
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
                            <i class="icon-reorder"></i>Hospital Service Detail Form</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                               
                            </div>
                            <div class="space10">
                            </div>
                            <!-- Here Put grid or table -->
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table class="">
                                        <tr>
                                            <td class="style3">
                                                <asp:Label ID="lblBillNo" runat="server" Text="BillNo"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBillNo" runat="server" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Hospital <span class="style2">Name<span class="style1">*</span></span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlHName" runat="server" AutoPostBack="True" 
                                                    OnTextChanged="ddlHName_TextChanged" 
                                                    onselectedindexchanged="ddlHName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcvHName" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Patient <span class="style2">Name<span class="style1">*</span></span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPName_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcvPName" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                Doctor Name<span class="style2"><span class="style1">*</span></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="lblDr" runat="server" Text="Dr." style="text-align:left"></asp:Label>
                                                </td>
                                            <td>
                                                <asp:TextBox ID="txtDName" runat="server" MaxLength="20"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvDName" runat="server" ControlToValidate="txtDName"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="reDName" runat="server" ControlToValidate="txtDName"
                                                    ErrorMessage="Alphabets only!" ValidationExpression="[a-z A-Z ]+" ValidationGroup="Submit"
                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <span class="style2">Admit Date<span class="style1">*</span></span>
                                            </td>
                                            <td class="style56">
                                                <asp:TextBox ID="txtAdmitDate" runat="server" Width="" 
                                                    ontextchanged="txtAdmitDate_TextChanged" style="cursor:default;" 
                                                    AutoPostBack="True"></asp:TextBox>
                                                <cc:CalendarExtender ID="txtAdmitDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                    Enabled="True" TargetControlID="txtAdmitDate">
                                                </cc:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rfvAdmitDate" runat="server" ControlToValidate="txtAdmitDate"
                                                    ErrorMessage="*" ValidationGroup="Submit" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style6">
                                                Admit Time<span class="style2"><span class="style1">*</span></span>
                                            </td>
                                            <td class="style12">
                                                <div class="form-group form-inline">
                                                    <asp:DropDownList ID="ddlHour" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlMinute" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlAMPM" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lblcvAdmitTime" runat="server" ForeColor="#FF3300"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style3">
                                                <span class="style2">Discharge Date</span>
                                            </td>
                                            <td class="style56">
                                                <br />
                                                <asp:TextBox ID="txtDischargeDate" runat="server" Width="" 
                                                    ontextchanged="txtDischargeDate_TextChanged" style="cursor:default;" 
                                                    AutoPostBack="True"></asp:TextBox>
                                            <cc:CalendarExtender ID="txtDischargeDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                    Enabled="True" TargetControlID="txtDischargeDate">
                                                </cc:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblcvDischargeDate" runat="server" ForeColor="Red" Text="Discharge Date can't be in the Past!"
                                                    Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style5">
                                                Discharge Time
                                            </td>
                                            <td class="style11">
                                                <div class="form-group form-inline">
                                                    <asp:DropDownList ID="ddlHour1" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlMinute1" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="ddlAMPM1" runat="server" Height="28px" Width="70px" CssClass="form-grid_dropdown">
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td class="style7">
                                                <asp:Label ID="lblcvDischargeTime" runat="server" ForeColor="#FF3300"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                            
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPName" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlHName" />
                                    <asp:AsyncPostBackTrigger ControlID="txtAdmitDate" />
                                    <asp:AsyncPostBackTrigger ControlID="txtDischargeDate" />
                                  
                                </Triggers>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Conditional">
                            <ContentTemplate>

                                    <br />
                                    <asp:GridView ID="gvHospital" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        DataKeyNames="id" EnableModelValidation="True" ForeColor="#333333" CellPadding="4"
                                        GridLines="Horizontal" OnPageIndexChanging="gvHospital_PageIndexChanging" OnRowCancelingEdit="gvHospital_RowCancelingEdit"
                                        OnRowDeleting="gvHospital_RowDeleting" OnRowEditing="gvHospital_RowEditing" OnRowUpdating="gvHospital_RowUpdating"
                                        BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid" ShowFooter="True">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtId" runat="server" Enabled="false" Text='<%#Eval("id") %>'> </asp:TextBox>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblServiceDescription" runat="server" Text='<%#Eval("ServiceDescription") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtServiceDescription" runat="server" Text='<%#Eval("ServiceDescription") %>'> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvServiceDescription" runat="server" ControlToValidate="txtServiceDescription"
                                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                                    <asp:RegularExpressionValidator ID="revServiceDescription" runat="server" SetFocusOnError="True"
                                                        ErrorMessage="Invalid Service Description" ControlToValidate="txtServiceDescription"
                                                        ValidationExpression="[a-zA-Z0-9 ]+" ValidationGroup="Update" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtIServiceDescription" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvIServiceDescription" runat="server" ControlToValidate="txtIServiceDescription"
                                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                                    <asp:RegularExpressionValidator ID="revIServiceDescription" runat="server" SetFocusOnError="True"
                                                        ErrorMessage="Invalid Service Description" ControlToValidate="txtIServiceDescription"
                                                        ValidationExpression="[a-zA-Z0-9 ]+" ValidationGroup="Insert" ForeColor="Red"></asp:RegularExpressionValidator>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Charge">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblServiceCharge" runat="server" Text='<%#Eval("ServiceCharges") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtServiceCharge" runat="server" Text='<%#Eval("ServiceCharges") %>'
                                                        OnTextChanged="txtServiceCharge_TextChanged" AutoPostBack="True"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvServiceCharge" runat="server" ControlToValidate="txtServiceCharge"
                                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red" ></asp:RequiredFieldValidator><br />
                                                    <asp:Label ID="lblcvServiceCharge" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtIServiceCharge" runat="server" OnTextChanged="txtIServiceCharge_TextChanged"
                                                        AutoPostBack="True"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvIServiceCharge" runat="server" ControlToValidate="txtIServiceCharge"
                                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                                    <asp:Label ID="lblcvIServiceCharge" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                          <%--  <asp:TemplateField HeaderText="Command">
                                                <ItemTemplate>
                                                    <asp:Button class="btn btn-info" ID="btnEdit" runat="server" Text="Edit" CommandName="Edit">
                                                    </asp:Button>
                                                    <asp:Button class="btn btn-info" ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Button class="btn btn-inverse" ID="btnUpdate" runat="server" ValidationGroup="Update"
                                                        Text="Update" CommandName="Update" />
                                                    <asp:Button class="btn btn-inverse" ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button class="btn btn-info" ID="btnInsert" runat="server" ValidationGroup="Insert"
                                                        Text="Insert" OnClick="btnInsert_Click"></asp:Button>
                                                </FooterTemplate>
                                            </asp:TemplateField>--%>

                                              <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" class="btn btn-primary" Text="Edit" CommandName="Edit">
                                    </asp:Button>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdate" runat="server" ValidationGroup="Update" class="btn btn-primary"
                                        Text="Update" CommandName="Update" />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="btnInsert" runat="server" ValidationGroup="Insert" class="btn btn-primary"
                                        Text="Insert" OnClick="btnInsert_Click"></asp:Button>
                                </FooterTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" class="btn btn-primary" Text="Delete" CommandName="Delete" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" CommandName="Cancel" />
                                </EditItemTemplate>
                                
                            </asp:TemplateField>

                                        </Columns>
                                        <EditRowStyle BackColor="#ebebeb" />
                                        <FooterStyle BackColor="#d6d6d6" Font-Bold="False" ForeColor="" />
                                        <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                        <PagerStyle BackColor="#d6d6d6" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>

                                    
                                    <br />
                                       <asp:Label ID="lblgvHospital" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <br />
                                     </ContentTemplate>
                                     <Triggers>
                                     </Triggers>
                                     </asp:UpdatePanel>

                                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                    <ContentTemplate>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="style4">
                                                Total Amount
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTAmount" runat="server" MaxLength="20" Enabled="False"></asp:TextBox>
                                            </td>
                                            <td>
                                            <asp:Label ID="lblcvTAmount" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                Discount(%) <span class="style2"><span class="style1">*</span></span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDiscount" runat="server" Width="" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="rvDiscount" runat="server" ErrorMessage="*" ForeColor="Red"
                                                    ControlToValidate="txtDiscount" ValidationGroup="Submit" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <br />
                                                <asp:Label ID="lblcvDiscount" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                <asp:Label ID="lblDiscountAmount" runat="server" Text="Discount Amount"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDiscountAmount" runat="server" Enabled="False" Width=""></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="style4">
                                                Final Amount
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFinalAmount" runat="server" Width="" Enabled="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>

                                          </ContentTemplate>
                         <Triggers>

                         <asp:AsyncPostBackTrigger ControlID="txtDiscount" />
                           
                      
                         </Triggers>
                         </asp:UpdatePanel>



                            <table>
                                <tr>
                                    <td class="style4">
                                        &nbsp;
                                    </td>
                                    <td>
                                  
                            <br />


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
                         
                      
                                     <%--   <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="Submit"
                                            CssClass="btn btn-primary" />&nbsp;&nbsp;<asp:Button ID="Button2" runat="server"
                                                Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-primary" />&nbsp;&nbsp;<asp:Button
                                                    ID="Button3" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-primary" />
                                    --%></td>
                                </tr>
                            </table>
                            <!-- End -->
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
