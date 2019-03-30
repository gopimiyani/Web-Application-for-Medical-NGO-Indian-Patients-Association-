<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="ForwardRequest.aspx.cs" Inherits="IPA1.AdminLab.ForwardRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            width: 583px;
        }
        input[type="text"]
        {
            width: 206px;
        }
    </style>
    <%-- <script type="text/javascript">
        function RefreshUpdatePanel() {
            __doPostBack('<%= txtSearch.ClientID %>', '');
        };
    </script>--%>
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
                    Forward Request
                </h3>
            </div>
        <asp:MultiView ID="mvForwardRequest" runat="server" ActiveViewIndex="0">
        <br />
            <asp:View ID="vForwardRequest" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li>
                        <asp:LinkButton ID="lbPateintRequests" runat="server" OnClick="lbPatientRequests_Click">Patient Requests</asp:LinkButton>
                        <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Patient Request Detail</a><span class="divider">&nbsp;</span></li>
                    <li><a href="#">Forward Request </a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
                <!-- END PAGE HEADER-->
                <!-- BEGIN ADVANCED TABLE widget-->
                <div class="row-fluid">
                    <div class="span12">
                     <!-- BEGIN ADVANCED TABLE widget-->
                        <div class="row-fluid">
                            <div class="span12">
                        <!-- BEGIN EXAMPLE TABLE widget-->
                       
                        <div class="widget">
                            <div class="widget-title">
                                <h4>
                                    <i class="icon-reorder"></i>Forward Request</h4>
                                <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                                    class="icon-remove"></a></span>
                            </div>
                            <div class="widget-body">

                              <div class="alert alert-info">
                                    <div style="color: Black">
                                        <strong>Note: </strong>
                                        <br />
                                        1. Click View button to view volunteer's contact and location details.<br />
                                        2. Click Forward button to forward the request to volunteer which will be assigned as a task
                                        and the request detail will be sent as an attachment.
                                    </div>
                                </div>
                             
                                <div class="portlet-body">
                                    <div class="clearfix">
                                        <div class="btn-group pull-right">
                                                    <button class="btn dropdown-toggle" data-toggle="dropdown">
                                                        Tools <i class="icon-angle-down"></i>
                                                    </button>
                                                    <ul class="dropdown-menu pull-right">
                                                        <li>
                                                            <asp:LinkButton ID="lbPrint" runat="server">Print</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbSaveAsPDF" runat="server" OnClick="lbSaveAsPDF_Click">Save as PDF</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbExportToExcel" runat="server" 
                                                                OnClick="lbExportToExcel_Click">Export to Excel</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbExportToWord" runat="server" 
                                                                OnClick="lbExportToWord_Click">Export to Word</asp:LinkButton>
                                                        </li>
                                                    </ul>
                                                </div>
                                    </div>
                            <%--        <div class="space10">
                                    </div>
                            --%>        
                                    <table>
                                        <tr>
                                            <td class="style7">
                                                Search Volunteer by PinCode :
                                                <asp:Panel ID="PnlVSearch" runat="server" DefaultButton="btnSearch">
                                                    <asp:TextBox ID="txtVSearch" runat="server" 
                                                        ontextchanged="txtVSearch_TextChanged"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="rePinCode" runat="server" 
                                                        ControlToValidate="txtVSearch" ErrorMessage="Invalid PinCode !" 
                                                        ForeColor="Red" ValidationExpression="^[0-9]{1,6}$" ValidationGroup="btnSearch"></asp:RegularExpressionValidator>
                                                    
                                                    <asp:Label ID="lblVSearch" runat="server" ForeColor="Red"></asp:Label>
                                                    <br />
                                                    <asp:Button ID="btnSearch" runat="server" Style="display: none" Text="Search" OnClick="btnSearch_Click" />
                                                    
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table> 
                                     
                                    </div>
                                    <div class="space15">
                                        </div>  
                                       
                                        <div class="row-fluid">
                                            <div class="span6">
                                                <div class="dataTables_length">
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlRecPerPage" runat="server" AutoPostBack="True" 
                                                        CssClass="input-small m-wrap" 
                                                        OnSelectedIndexChanged="ddlRecPerPage_SelectedIndexChanged">
                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:Label ID="lblRecPerPage" runat="server" Text="records per page"></asp:Label>
                                                   
                                                    &nbsp;</div>
                                            </div>
                                    <asp:GridView ID="gvUser" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                        CellPadding="4" DataKeyNames="User_ID" EnableModelValidation="True" ForeColor="#333333"
                                        GridLines="Both" OnPageIndexChanging="gvUser_PageIndexChanging" BorderWidth="1px"
                                        BorderColor="#cccccc" BorderStyle="Solid" OnRowCommand="gvUser_RowCommand" OnSelectedIndexChanged="gvUser_SelectedIndexChanged"
                                        AllowSorting="True" OnSorting="GridView1_Sorting" class="table table-striped  table-bordered"
                                        PageSize="5">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                        <Columns>
                                           
                                            <asp:TemplateField HeaderText="User ID" SortExpression="User_ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUser_ID" runat="server"  Text='<%#Eval("User_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                           
                                            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Visible="false" Text='<%#Eval("User_ID") %>'></asp:Label>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                                </ItemTemplate>
                                               </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Address" SortExpression="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                </ItemTemplate>
                                               </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No" SortExpression="MobileNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContact" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtContact" class="inputtext" runat="server" Text='<%#Eval("MobileNo") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvContact" runat="server" ControlToValidate="txtContact"
                                                        ValidationGroup="Update" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                </EditItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PinCode" SortExpression="PinCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("PinCode") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" class="btn btn-primary" runat="server" Text="View" CommandName="View"
                                                        CommandArgument='<%#Eval("User_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Forward">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnForward" class="btn btn-info" runat="server" Text="Forward" CommandName="Forward"
                                                        CommandArgument='<%#Eval("User_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EditRowStyle BackColor="#ebebeb" />
                                        <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="Red" />
                                        <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                                        <PagerStyle BackColor="#284775" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                    
                                    </div>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE widget-->
                    </div>
                  
            </asp:View>
            <asp:View ID="View1" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbPatientRequests_Click">Patient Requests</asp:LinkButton>
                        <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Patient Request Detail</a><span class="divider">&nbsp;</span></li>
                    <li><a href="#">Forward Request </a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
                <!-- END PAGE HEADER-->
                <!-- BEGIN ADVANCED TABLE widget-->
                <div class="row-fluid">
                    <div class="span12">
                        <!-- BEGIN EXAMPLE TABLE widget-->
                        <div class="widget">
                            <div class="widget-title">
                                <h4>
                                    <i class="icon-reorder"></i>Forward Request</h4>
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
                                                            <asp:LinkButton ID="lbPrint1" runat="server">Print</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbSaveAsPDF1" runat="server" OnClick="lbSaveAsPDF1_Click">Save as PDF</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbExportToExcel1" runat="server" 
                                                                OnClick="lbExportToExcel1_Click">Export to Excel</asp:LinkButton>
                                                        </li>
                                                        <li>
                                                            <asp:LinkButton ID="lbExportToWord1" runat="server" 
                                                                OnClick="lbExportToWord1_Click">Export to Word</asp:LinkButton>
                                                        </li>
                                                    </ul>
                                                </div>
                                    </div>
                                    <div class="space10">
                                    </div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtVUserID" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtFirstName" runat="server" BorderColor="White" BorderStyle="None"
                                                    Font-Bold="True" Font-Size="X-Large" Width="283px"></asp:TextBox>
                                                <asp:TextBox ID="txtLastName" runat="server" BorderColor="White" BorderStyle="None"
                                                    Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="search-input-area">
                                                    <i class="icon-map-marker" style="font-size: xx-large"></i>
                                                    <asp:TextBox ID="txtVAddress" runat="server" TextMode="MultiLine" BorderColor="White"
                                                        BorderStyle="None" Rows="2" Width="282px"></asp:TextBox>
                                                    <br />
                                                    <asp:TextBox ID="txtCity" runat="server" Visible="False" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    <asp:TextBox ID="txtState" runat="server" Visible="False" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    <asp:TextBox ID="txtVPinCode" runat="server" Visible="False" BorderColor="White"
                                                        BorderStyle="None"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="search-input-area">
                                                    <i class="icon-envelope" style="font-size: x-large"></i>
                                                    <asp:TextBox ID="txtVEmail" runat="server" MaxLength="40" ValidationGroup="Submit"
                                                        BorderColor="White" BorderStyle="None" Width="249px"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="search-input-area">
                                                    <i class="icon-phone" style="font-size: x-large"></i>
                                                    <asp:TextBox ID="txtVMobileNo" runat="server" BorderColor="White" BorderStyle="None"
                                                        ValidationGroup="Submit" Width="176px"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div>
                                                    <%
                                                
                                                        Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtVAddress.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"500\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                                                    %>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td class="style6">
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnForwad" runat="server" CssClass="btn btn-primary" OnClick="btnForward_Click"
                                                    Text="Forward" 
                                                         data-trigger="hover" data-placement="left" 
                                                            data-content="Click Forward button to forward the request to volunteer which will be assigned as a task
                                        and the request detail will be sent as an attachment."
                                                            data-original-title="Request Status is 'Pending'" />
                                                        
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancel1" runat="server" CssClass="btn btn-primary"
                                                    OnClick="btnCancel1_Click" Text="Cancel" />
                                                <br />
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <!-- END EXAMPLE TABLE widget-->
                    </div>
                </div>
                
            </asp:View>
        </asp:MultiView>
        
        </div>
        </div>
        
</asp:Content>
