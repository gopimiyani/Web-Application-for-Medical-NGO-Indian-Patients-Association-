<%@ Page Title="" Language="C#" MasterPageFile="~/VolunteerLab/Volunteer.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="IPA1.VolunteerLab.Search1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- BEGIN PAGE CONTAINER-->
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- END THEME CUSTOMIZER-->
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">
                    Search
                </h3>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <asp:MultiView ID="mvSeach" runat="server" ActiveViewIndex="0">
            <asp:View ID="vSearch" runat="server">
                <ul class="breadcrumb">
                    <li><a href="Dashboard.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Search</a> <span class="divider-last">&nbsp;</span> </li>
                </ul>
                <!-- BEGIN PAGE CONTENT-->
                <div class="container-fluid">
                    <!-- END PAGE HEADER-->
                    <!-- BEGIN ADVANCED TABLE widget-->
                    <div class="row-fluid">
                        <div class="span12">
                            <!-- BEGIN EXAMPLE TABLE widget-->
                           
                           
                            <div class="widget">
                                <div class="widget-body">
                                  
                                    <div class="portlet-body">
                                        Select Any StakeHolder &nbsp;
                                        <asp:DropDownList ID="ddlselecttype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlselecttype_SelectedIndexChanged"
                                            OnTextChanged="ddlselecttype_TextChanged1">
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="cvddlselecttype" runat="server" 
                                            onservervalidate="cvddlselecttype_ServerValidate1" ForeColor="Red"></asp:CustomValidator>
                                        <br />
                                        Search by PinCode :
                                        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
                                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                            <asp:Label ID="lblSearch" runat="server" ForeColor="Red"></asp:Label>
                                            <br />
                                            <asp:Button ID="btnSearch" runat="server" Style="display: none" Text="Search" OnClick="btnSearch_Click" />
                                            <br />
                                            <br />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:GridView ID="gvUser" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="User_ID" EnableModelValidation="True" ForeColor="#333333"
                    GridLines="Both" OnPageIndexChanging="gvUser_PageIndexChanging" BorderWidth="1px"
                    BorderColor="#cccccc" BorderStyle="Solid" OnRowCommand="gvUser_RowCommand" OnSelectedIndexChanged="gvUser_SelectedIndexChanged"
                    AllowSorting="True" OnSorting="GridView1_Sorting" class="table table-striped  table-hover"
                    PageSize="5">
                    <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                    <Columns>
                        <%--<asp:TemplateField HeaderText="User ID" SortExpression="User_ID">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("User_ID") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblIID" runat="server" Text='<%#Eval("User_ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" SortExpression="StackHolder">
                            <ItemTemplate>
                                <asp:Label ID="lblType" runat="server" Text='<%#Eval("StackHolder") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtType" class="inputtext" runat="server" Text='<%#Eval("StackHolder") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="txtType"
                                    ValidationGroup="Update" ForeColor="Red" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtName" class="inputtext" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                    ValidationGroup="Update" ForeColor="Red" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
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
                            <%-- <EditItemTemplate>
       <asp:TextBox ID="txtEmail" class="inputtext" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
       <asp:RequiredFieldValidator ID="rfvEmail" runat="server"  
            ControlToValidate="txtEmail" ValidationGroup="Update" 
            ErrorMessage="*" SetFocusOnError="True" 
            ></asp:RequiredFieldValidator>
    </EditItemTemplate>
                            --%>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Command">
                            <ItemTemplate>
                                <asp:Button ID="btnView" class="btn btn-info" runat="server" Text="View" CommandName="View"
                                    CommandArgument='<%#Eval("User_ID") %>' />
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
                    <PagerStyle BackColor="#284775" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </asp:View>
    </div>
    <asp:View ID="vSearchDetail" runat="server">
        <ul class="breadcrumb">
            <li><a href="Dashboard.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
            </li>
            <li>
                <asp:LinkButton ID="lbSearch" runat="server" onclick="lbSearch_Click">Search</asp:LinkButton>
          
            <span class="divider">&nbsp;</span> 
            </li>
         
            <li><a href="#">Search Detail</a><span class="divider-last">&nbsp;</span></li>
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
                                    <i class="icon-reorder"></i>Search Detail</h4>
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
                                                <li><a href="#">Print</a></li>
                                                <li><a href="#">Save as PDF</a></li>
                                                <li><a href="#">Export to Excel</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="space10">
                                    </div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text="User Type" Visible="False"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="True" ValidationGroup="Submit"
                                                    Enabled="False" Visible="False">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td>
                                                Profile Pic
                                            </td>
                                            <td>
                                                <asp:Image ID="ImgProfilePic" runat="server" Height="100px" Width="175px"></asp:Image>
                                            </td>
                                        </tr>--%>
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
                                                    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" BorderColor="White"
                                                        BorderStyle="None" Rows="2" Width="282px"></asp:TextBox>
                                                    <br />
                                                    <asp:TextBox ID="txtCity" runat="server" Visible="False" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    <asp:TextBox ID="txtState" runat="server" Visible="False" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    <asp:TextBox ID="txtPinCode" runat="server" Visible="False" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="search-input-area">
                                                    <i class="icon-envelope" style="font-size: x-large"></i>
                                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="40" ValidationGroup="Submit"
                                                        BorderColor="White" BorderStyle="None" Width="249px"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="search-input-area">
                                                    <i class="icon-phone" style="font-size: x-large"></i>
                                                    <asp:TextBox ID="txtMobileNo" runat="server" BorderColor="White" BorderStyle="None"
                                                        ValidationGroup="Submit" Width="176px"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:MultiView ID="MvRegister" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="Volunteer" runat="server">
                                            <table>
                                            <div>
                                                    <%
                                                
                                                        Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtAddress.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"500\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                                                    %>
                                                </div>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="Donor" runat="server">
                                            <table>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="Hospital" runat="server">
                                            <table>
                                                <%--<tr>
                                                    <td>
                                                        <asp:Label ID="lblHContactPerson" runat="server" Text="ContactPerson Name :"></asp:Label>
                                                        <asp:TextBox ID="HtxtContactPerson" runat="server" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblHWebsite" runat="server" Text="Website Name :"></asp:Label>
                                                        <asp:TextBox ID="HtxtWebsite" runat="server" BorderColor="White" BorderStyle="None"
                                                            ValidationGroup="Submit"></asp:TextBox>
                                                    </td>
                                                </tr>--%>
                                                <div>
                                                    <%
                                                
                                                        Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtFirstName.Text +"Hospital"+ txtPinCode.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"500\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                                                    %>
                                                </div>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="BloodBank" runat="server">
                                            <table>
                                                <%--<tr>
                                                    <td>
                                                        <asp:Label ID="lblBContactPerson" runat="server" Text="ContactPerson Name :"></asp:Label>
                                                        <asp:TextBox ID="BtxtContactPerson" runat="server" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblBWebsite" runat="server" Text="Website Name :"></asp:Label>
                                                        <asp:TextBox ID="BtxtWebsite" runat="server" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    </td>
                                                </tr>--%>
                                                <div>
                                                    <%
                                                
                                                        Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtFirstName.Text +"BloodBank"+ txtPinCode.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"600\" height=\"600\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                                                    %>
                                                </div>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="PharmaCompany" runat="server">
                                            <table>
                                                <%--<tr>
                                                    <td>
                                                        <asp:Label ID="lblPContactPerson" runat="server" Text="ContactPerson Name :"></asp:Label>
                                                        <asp:TextBox ID="PtxtContactPerson" runat="server" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPWebsite" runat="server" Text="Website Name :"></asp:Label>
                                                        <asp:TextBox ID="PtxtWebsite" runat="server" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    </td>
                                                </tr>--%>
                                                <div>
                                                    <%
                                                
                                                        Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtFirstName.Text +"Pharmaceutical"+ txtPinCode.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"500\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                                                    %>
                                                </div>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="Doctor" runat="server">
                                            <table>
                                            </table>
                                        </asp:View>
                                        <br />
                                        <asp:View ID="NGO" runat="server">
                                            <table>
                                               <%-- <tr>
                                                    <td>
                                                        <asp:Label ID="lblNWebsite" runat="server" Text="Website Name : "></asp:Label>
                                                        <asp:TextBox ID="NtxtWebsite" runat="server" BorderColor="White" BorderStyle="None"></asp:TextBox>
                                                    </td>
                                                </tr>--%>
                                                <div>
                                                    <%
                                                
                                                        Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtFirstName.Text + txtPinCode.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"500\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                                                    %>
                                                </div>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="Media" runat="server">
                                        </asp:View>
                                    </asp:MultiView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </asp:View>
    </asp:MultiView>
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
