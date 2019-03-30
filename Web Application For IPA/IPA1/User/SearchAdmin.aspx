<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="SearchAdmin.aspx.cs" Inherits="IPA1.User.SearchAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        td
        {
            padding-top: 8px;
        }
        
        .divmargin
        {
            margin-left: 30px;
            margin-right: 30px;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="margin-top:50px;"></div>
<asp:MultiView ID="mvAdmin" runat="server" ActiveViewIndex="0">
        <asp:View ID="vAdmin" runat="server">
            <div class="divmargin">
                <div style="margin-left: 80px; font-weight: bold; color: #707070; font-size: 20pt;">
                    <br />
                    <%-- For Blood Requirement Call --%>
                </div>
                <br />
                <div style="margin-left: 80px; font-size: ">
                    <u>Note:</u> For Blood Requirement just call one of the below IPA associator basis
                    on your area.
                </div>
                <br />
                <div style="margin-left: 80px; margin-right: 100px; margin-bottom: 50px;">
                    <asp:GridView ID="gvAdmin" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="4" DataKeyNames="Admin_ID" EnableModelValidation="True" ForeColor="#333333"
                        GridLines="Both" OnPageIndexChanging="gvAdmin_PageIndexChanging" BorderWidth="1px"
                        BorderColor="#cccccc" class="table table-striped  table-bordered" BorderStyle="Solid"
                        OnRowCommand="gvAdmin_RowCommand" OnSelectedIndexChanged="gvAdmin_SelectedIndexChanged"
                        AllowSorting="True" OnSorting="gvAdmin_Sorting" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                        <Columns>
                            <%--<asp:TemplateField HeaderText="Admin ID" SortExpression="Admin_ID">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("Admin_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblIID" runat="server" Text='<%#Eval("Admin_ID") %>'></asp:Label>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtName" class="inputtext" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Working Area" SortExpression="WorkingPinCode">
                                <ItemTemplate>
                                    <asp:Label ID="lblWorkingPinCode" runat="server" Text='<%#Eval("WorkingPinCode") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact No" SortExpression="MobileNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblContact" runat="server" Text='<%#Eval("MobileNo") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMobileNo" class="inputtext" runat="server" Text='<%#Eval("MobileNo") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="View">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnView" class="btn btn-info" runat="server" Text="View" CommandName="View"
                                                                    CommandArgument='<%#Eval("Admin_ID") %>' />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>--%>
                        </Columns>
                        <EditRowStyle BackColor="#ebebeb" />
                        <FooterStyle BackColor="#d6d6d6" Font-Bold="True" ForeColor="" />
                        <HeaderStyle BackColor="#f2f2f2" Font-Bold="True" ForeColor="#5c5c5c" />
                        <PagerStyle BackColor="#d6d6d6" ForeColor="#5c5c5c" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vUserDetail" runat="server">
            <!-- BEGIN PAGE CONTENT-->
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Note: You can contact the below service
            provider using below contact Detail.
            <table class="" style="margin-left: 15px;">
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblAdminID" runat="server" Text=" Admin ID"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtAdminID" runat="server" CssClass="inputtext" MaxLength="20" Enabled="False"
                            Width="210px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblFirstName" runat="server" Text=" FirstName"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputtext" MaxLength="20"
                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="reFirstName" runat="server" ControlToValidate="txtFirstName"
                            ErrorMessage="Alphabates Only" ValidationExpression="[a-z A-Z]+" ValidationGroup="Submit"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblLastName" runat="server" Text=" LastName"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputtext" MaxLength="20"
                            ValidationGroup="Submit" ReadOnly="True" Width="208px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="reLastName" runat="server" ControlToValidate="txtLastName"
                            ErrorMessage="Alphabates Only" ValidationExpression="[a-z A-Z]*" ValidationGroup="Submit"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblProfilePic" runat="server" Text="Upload Your ProfilePic"></asp:Label>
                    </td>
                    <td class="style5">
                        <br />
                        <asp:Image ID="ImgProfilePic" runat="server" Height="150px" Width="220px" />
                        <br />
                        <asp:FileUpload ID="fuProfilePic" runat="server" Enabled="False"></asp:FileUpload>
                    </td>
                    <td class="style9">
                        <asp:Label ID="lblProfilePicture" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style5">
                        <br />
                        <asp:TextBox ID="txtUserName" runat="server" Style="margin-top: 0px" AutoPostBack="True"
                            CssClass="inputtext" MaxLength="20" ValidationGroup="Submit" OnTextChanged="txtUserName_TextChanged"
                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblcvUserName" runat="server" ForeColor="Red" Text="" Visible="False"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                    </td>
                    <td class="style5">
                        <asp:RegularExpressionValidator ID="reUserName" runat="server" ControlToValidate="txtUserName"
                            ErrorMessage="Enter Alphabates and Digits Only " ValidationExpression="[a-zA-Z0-9]+"
                            ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputtext" MaxLength="40" ValidationGroup="Submit"
                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="Invalid Email  Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ValidationGroup="Submit"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtAddress" runat="server" Rows="4" TextMode="MultiLine" MaxLength="100"
                            ValidationGroup="Submit" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Enabled="False">
                            <asp:ListItem>Gujarat</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                        &nbsp;
                        <br />
                    </td>
                    <td class="style5">
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown" Enabled="False">
                            <asp:ListItem>Surat</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="inputtext" ReadOnly="True"
                            Width="210px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rePinCode" runat="server" ControlToValidate="txtPinCode"
                            ErrorMessage="PinCode must be in 6 digit" ValidationExpression="(\d{6})" ValidationGroup="Submit"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="inputtext" MaxLength="10"
                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvMobileNo" runat="server" ErrorMessage="Enter Valid MobileNo"
                            ControlToValidate="txtMobileNo" MaximumValue="9999999999" MinimumValue="7000000000"
                            ValidationGroup="Submit" ForeColor="Red"></asp:RangeValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblWorkingArea" runat="server" Text="Working Area"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtWorkingArea" runat="server" Rows="4" TextMode="MultiLine" MaxLength="100"
                            ValidationGroup="Submit" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                            ReadOnly="True" Width="210px" Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style9">
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <asp:Label ID="lblIPAddress" runat="server" Text="IP Address"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style5">
                        <asp:TextBox ID="txtIpaddress" class="inputtext" runat="server" Width="210px"></asp:TextBox>
                    </td>
                    <td class="style9">
                        <asp:RequiredFieldValidator ID="rfvIpaddress" runat="server" ErrorMessage="*" SetFocusOnError="True"
                            ValidationGroup="Submit" ControlToValidate="txtIpaddress" ForeColor="Red"></asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="reIpaddress" runat="server" ErrorMessage="Invalid IP!"
                            ValidationExpression="^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$"
                            ValidationGroup="Submit" ControlToValidate="txtIpaddress" SetFocusOnError="True"
                            ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style8">
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        <br />
                        <br />
                    </td>
                    <td class="style5">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="Submit" ValidationGroup="Submit"
                            OnClick="btnSubmit_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-info" Text="Cancel" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>
