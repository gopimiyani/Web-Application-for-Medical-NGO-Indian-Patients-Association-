<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="HospitalDetail.aspx.cs" Inherits="IPA1.AdminLab.HospitalDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            width: 148px;
        }
        .style5
        {
            width: 220px;
        }
        .style6
        {
            width: 220px;
        }
        input[type="text"]
        {
            width:206px;
        }
        
        .style7
        {
            color: red;
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
                    Hospital</h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvHospital" runat="server">
            <br />
            <asp:View ID="vHospital" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Hospital</a><span class="divider-last">&nbsp;</span></li>
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
                                            <i class="icon-reorder"></i>Hospital</h4>
                                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                            class="icon-remove"></a></span>
                                    </div>
                                    <div class="widget-body">
                                        <div class="portlet-body">
                                            <div class="clearfix">
                                                <div class="btn-group">
                                                    <div class="form-group form-inline">
                                                        <asp:Button ID="btnNew" class="btn btn-primary" runat="server" Text="New" OnClick="btnNew_Click">
                                                        </asp:Button>
                                                        <asp:Label ID="lblType" runat="server" Text="Select Any Hospital" ForeColor="#2A6496"
                                                            Font-Bold="True" Font-Names="Verdana" Font-Size="12pt" CssClass="lblselect"></asp:Label>
                                                        &nbsp;
                                                        <asp:DropDownList ID="ddlHospitalName" runat="server" AutoPostBack="True" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddlHospitalName_SelectedIndexChanged"
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
                                        <asp:GridView ID="gvHospital" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="4" DataKeyNames="HospitalDetail_ID" EnableModelValidation="True"
                                            ForeColor="#333333" GridLines="Both" BorderWidth="1px" BorderColor="#cccccc"
                                            BorderStyle="Solid" OnRowCommand="gvHospital_RowCommand" class="table table-striped table-hover"
                                            PageSize="5" OnPageIndexChanging="gvHospital_PageIndexChanging1" 
                                            AllowSorting="True" onsorting="gvHospital_Sorting">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Hospital's Name" SortExpression="FirstName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtName" runat="server" Enabled="false" Text='<%#Eval("FirstName") %>'></asp:TextBox></EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Patient's Name" SortExpression="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPatientName" runat="server" Text='<%#Eval("Name") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPatientName" runat="server" Enabled="false" Text='<%#Eval("Name") %>'></asp:TextBox></EditItemTemplate>
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
                                                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtTotalAmount" runat="server" Enabled="false" Text='<%#Eval("TotalAmount") %>'></asp:TextBox></EditItemTemplate>
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
                                                        <asp:Label ID="lblPaymentStatus" runat="server" Text='<%#Eval("PaymentStatus") %>'></asp:Label></ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtPaymentStatus" runat="server" Enabled="false" Text='<%#Eval("PaymentStatus") %>'></asp:TextBox></EditItemTemplate>
                                                    <FooterTemplate>
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                    
                                                        <asp:Button ID="btnView" class="btn btn-primary" runat="server" Text="View" CommandName="View"
                                                            CommandArgument='<%#Eval("HospitalDetail_ID") %>' /></ItemTemplate>
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
                    </div>
                </div>
                <!-- END SAMPLE TABLE widget-->
    
    </asp:View>
    <asp:View ID="vHospitalDetail" runat="server">
        <ul class="breadcrumb">
            <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
            </li>
            <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
            <li>
                <asp:LinkButton ID="lbHospital" runat="server" OnClick="lbHospital_Click">Hospital</asp:LinkButton>
                <span class="divider">&nbsp;</span></li>
            <li><a href="#">Hospital Service Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                    <i class="icon-reorder"></i>Hospital Service Detail</h4>
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
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="" >
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtHospitalDetail_ID" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style5">
                                                        <asp:Label ID="lblBillNo" runat="server" Text="BillNo"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBillNo" runat="server" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style5">
                                                        Hospital <span class="style2">Name</span></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlHospitalName1" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style5">
                                                        Patient <span class="style2">Name</span>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPName" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style5">
                                                        Doctor Name<span class="style2"><span class="style7">* </span></span>&nbsp;</td>
                                                    <td>
                                                        <asp:TextBox ID="txtDName" runat="server" MaxLength="20"></asp:TextBox>
                                                    </td>
                                                      <td>
                                                <asp:RequiredFieldValidator ID="rfvDName" runat="server" ControlToValidate="txtDName"
                                                    ErrorMessage="Enter Doctor name!" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="reDName" runat="server" ControlToValidate="txtDName"
                                                    ErrorMessage="Alphabates Only" ValidationExpression="[a-z A-Z]+" ValidationGroup="Submit"
                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                         
                                       
                                                </tr>
                                                <tr>
                                                    <td class="style5">
                                                        <span class="style2">Admit Date<span class="style7">*</span></span>
                                                    </td>
                                                    <td class="style56">
                                                        <asp:TextBox ID="txtAdmitDate" runat="server" Width=""  style="cursor:default;" 
                                                            AutoPostBack="True" ontextchanged="txtAdmitDate_TextChanged"></asp:TextBox>
                                                        <cc:CalendarExtender ID="txtAdmitDate_CalendarExtender" runat="server" Format="dd-MM-yyyy"
                                                            Enabled="True" TargetControlID="txtAdmitDate">
                                                        </cc:CalendarExtender>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfvAdmitDate" runat="server" ControlToValidate="txtAdmitDate"
                                                            ErrorMessage="*" ValidationGroup="Submit" SetFocusOnError="True" 
                                                            style="color: #FF0000"></asp:RequiredFieldValidator>
                                                     
                                                    </td>
                                                </tr>
                                                <tr>
                                            <td class="style6">
                                                Admit Time<span class="style2"><span class="style7">*</span></span>
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
                                                    <td class="style5">
                                                        <span class="style2">Discharge Date</span>
                                                    </td>
                                                    <td class="style56">
                                                        <br />
                                                        <asp:TextBox ID="txtDischargeDate" runat="server" Width style="cursor:default;" 
                                                            AutoPostBack="True" ontextchanged="txtDischargeDate_TextChanged"></asp:TextBox>
                                                        <cc:CalendarExtender ID="txtDischargeDate_CalendarExtender" runat="server" Format="dd-MM-yyyy" Enabled="True"
                                                            TargetControlID="txtDischargeDate">
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
                                            <asp:AsyncPostBackTrigger ControlID="ddlHospitalName1" />
                                            <asp:AsyncPostBackTrigger ControlID="txtAdmitDate" />
                                            <asp:AsyncPostBackTrigger ControlID="txtDischargeDate" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <br />
                                    <asp:GridView ID="gvHospitalDetail" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        DataKeyNames="id" EnableModelValidation="True" ForeColor="#333333" CellPadding="4"
                                        GridLines="Horizontal" OnPageIndexChanging="gvHospitalDetail_PageIndexChanging"
                                        OnRowCancelingEdit="gvHospitalDetail_RowCancelingEdit" OnRowDeleting="gvHospitalDetail_RowDeleting"
                                        OnRowEditing="gvHospitalDetail_RowEditing" OnRowUpdating="gvHospitalDetail_RowUpdating"
                                        BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid" ShowFooter="True"
                                        PageSize="5" CssClass="table table-striped  table-bordered">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("id") %>'></asp:Label></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtId" runat="server" Enabled="false" Text='<%#Eval("id") %>'> </asp:TextBox></EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Service Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblServiceDescription" runat="server" Text='<%#Eval("ServiceDescription") %>'></asp:Label></ItemTemplate>
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
                                                    <asp:Label ID="lblServiceCharge" runat="server" Text='<%#Eval("ServiceCharges") %>'></asp:Label></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtServiceCharge" runat="server" 
                                                        Text='<%#Eval("ServiceCharges") %>' 
                                                        ontextchanged="txtServiceCharge_TextChanged" AutoPostBack="True"> </asp:TextBox>
                                                    
                                                            <asp:RequiredFieldValidator ID="rfvServiceCharge" runat="server" 
                                                            ControlToValidate="txtServiceCharge" ForeColor="Red"
                                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                                                 
                                                    <asp:Label ID="lblcvServiceCharge" runat="server" Text="" ForeColor="Red"></asp:Label>
                                               
                                                        </EditItemTemplate>
                                               
                                               
                                               
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtIServiceCharge" runat="server" 
                                                        ontextchanged="txtIServiceCharge_TextChanged" AutoPostBack="True"></asp:TextBox>


                                                           <asp:RequiredFieldValidator ID="rfvIServiceCharge" runat="server" ControlToValidate="txtIServiceCharge"
                                                        ValidationGroup="Insert" ErrorMessage="*" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator><br />
                                                  
                                                    <asp:Label ID="lblcvIServiceCharge" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                
                                                  </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:Button class="btn btn-info" ID="btnEdit" runat="server" Text="Edit" CommandName="Edit">
                                                    </asp:Button></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Button class="btn btn-inverse" ID="btnUpdate" runat="server" ValidationGroup="Update"
                                                        Text="Update" CommandName="Update" />
                                                        
                                                          
                                                        </EditItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button class="btn btn-info" ID="btnInsert" runat="server" ValidationGroup="Insert"
                                                        Text="Insert" OnClick="btnInsert_Click"></asp:Button></FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemTemplate>
                                                    <asp:Button class="btn btn-info" ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" /></ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Button class="btn btn-inverse" ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" /></EditItemTemplate>
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
                                    <br />
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <table style="width: 100%; margin-left: 15px;"">
                                                <tr>
                                                    <td class="style6">
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
                                                    <td class="style6">
                                                        Discount(%)<span class="style2"><span class="style7">*</span></span>
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
                                                    <td class="style6">
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
                                                    <td class="style6">
                                                        Final Amount
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFinalAmount" runat="server" Width="" Enabled="False"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style6">
                                                        Payment Status
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPStatus" runat="server" Enabled="False">
                                                            <asp:ListItem>Unpaid</asp:ListItem>
                                                            <asp:ListItem>Paid</asp:ListItem>
                                                        </asp:DropDownList>
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
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                         
                      

                                    </td>
                                </tr>
                            </table>
                          

                                   
                                   
                                   
                                    <%--<table>
                                        <tr>
                                            <td class="style5">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                            <td>
                                                <br />
                                                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="Submit"
                                                    CssClass="btn btn-primary" />&nbsp;&nbsp;<asp:Button ID="Button2" runat="server"
                                                        Text="Reset" OnClick="btnReset_Click" CssClass="btn btn-primary" />&nbsp;&nbsp;<asp:Button
                                                            ID="Button3" runat="server" OnClick="btnCancel_Click" Text="Cancel" CssClass="btn btn-primary" />
                                            </td>
                                        </tr>
                                    </table>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:View>
    </asp:MultiView> </div>
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
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
</asp:Content>
