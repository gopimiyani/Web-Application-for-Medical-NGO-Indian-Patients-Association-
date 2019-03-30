<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true"
    CodeBehind="PCProfile.aspx.cs" Inherits="IPA1.User.PCProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">

.table>thead>tr>th, .table>tbody>tr>th, .table>tfoot>tr>th, .table>thead>tr>td, .table>tbody>tr>td, .table>tfoot>tr>td
{
    padding:15px;
}

</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row-fluid">
        <div class="span12">
            <div class="widget">
                <div class="widget-title">
                    <br />
                    <br />
                    <h3 style="margin-left:90px;">
                        &nbsp;&nbsp; Profile</h3>
                    <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                        class="icon-remove"></a></span>
                </div>
                <table class="table table-borderless" style="margin-left:90px; width:85%;">
                    <tr>
                        <td>
                            Profile Pic
                        </td>
                        <td>
                            <asp:Image ID="ImgProfilePic" runat="server" Height="210px" Width="214px"></asp:Image>
                        <asp:FileUpload ID="fuProfilePic" runat="server" />
                                        <asp:Label ID="lblProfilePic" runat="server" Text=""></asp:Label>
                                        
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                    <td class="style5">
                        <asp:Label ID="lblFirstName" runat="server" Text="FirstName"></asp:Label>
                    </td>
                    <td class="style53">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputtext" Width="210px"
                            MaxLength="20" ValidationGroup="Submit" Enabled="True" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblLastName" runat="server" Text=" LastName"></asp:Label>
                    </td>
                    <td class="style53">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="inputtext" Width="210px" MaxLength="20"
                            ValidationGroup="Submit" Enabled="True" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
                        <span class="style2">
                    </td>
                    <td class="style53">
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="inputtext" Style="margin-top: 0px"
                            Width="210px" MaxLength="20" ValidationGroup="Submit" Enabled="True" 
                            ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
                    </td>
                    <td class="style53">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputtext" Width="210px" MaxLength="40"
                            ValidationGroup="Submit" Enabled="True" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td class="style53">
                        <asp:TextBox ID="txtAddress" runat="server" Rows="4" TextMode="MultiLine" MaxLength="100"
                            CssClass="inputtext" Enabled="True" Width="210px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style53">
                        <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            <asp:ListItem>Gujarat</asp:ListItem>
                        </asp:DropDownList>
                        <td>
                            &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style53">
                        <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown">
                            <asp:ListItem>Surat</asp:ListItem>
                        </asp:DropDownList>
                        <td>
                            &nbsp;
                        </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblPinCode" runat="server" Text="PinCode"></asp:Label>
                    </td>
                    <td class="style52">
                        <asp:TextBox ID="txtPinCode" runat="server" ValidationGroup="Submit" Width="210px"
                            Enabled="True" CssClass="inputtext"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPinCode" runat="server" ControlToValidate="txtPinCode"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rePinCode" runat="server" ControlToValidate="txtPinCode"
                                                    ErrorMessage="PinCode must be in 6 digit" ValidationExpression="(\d{6})" ValidationGroup="Submit"
                                                    ForeColor="Red"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style53">
                        <asp:TextBox ID="txtMobileNo" runat="server" Width="210px" ValidationGroup="Submit"
                            CssClass="inputtext" Enabled="True"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ControlToValidate="txtMobileNo"
                                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="rvMobileNo" runat="server" ValidationGroup="Submit" MaximumValue="9999999999"
                                                    MinimumValue="70000000000" ErrorMessage="Enter Valid Mobile No" ControlToValidate="txtMobileNo"
                                                    ForeColor="Red"></asp:RangeValidator>
                    </td>
                    <td class="style1">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        IdProof
                    </td>
                    <td>
                        <asp:Image ID="ImgIdProof" runat="server" Height="150px" Width="216px"></asp:Image>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            <asp:Label ID="VlblContactPerson" runat="server" Text="ContactPerson"></asp:Label>
                            &nbsp;
                        </td>
                        <td class="style56">
                            <asp:TextBox ID="txtContactPerson" runat="server" Width="210px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContactPerson" runat="server" ErrorMessage="*"
                                                            ForeColor="Red" ValidationGroup="Submit" ControlToValidate="txtContactPerson"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="reContactPerson" runat="server" ControlToValidate="txtContactPerson"
                                                            ErrorMessage="Alphabates Only" ValidationExpression="[ a-zA-Z]+" ValidationGroup="Submit"
                                                            ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style5">
                            <asp:Label runat="server" Text="Website Name" ID="VlblWebsite"></asp:Label>
                        </td>
                        <td class="style56">
                            <asp:TextBox ID="txtWebsite" runat="server" Width="210px"  ValidationGroup="Submit"
                                Enabled="True"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="reWebsite" runat="server" ErrorMessage="Invalid Url Format"
                                                            ValidationExpression="^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$"
                                                            ControlToValidate="txtWebsite" ValidationGroup="Submit" ForeColor="Red"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" ValidationGroup="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />&nbsp;
                            &nbsp; &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" OnClick="btnCancel_Click" />
                        </td>
                         <td>
                        &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
   
</asp:Content>
