<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="SearchServiceProvider.aspx.cs" Inherits="IPA1.Visitor.SearchServiceProvider" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
       
        td
        {
            padding-top: 8px;
        }
       
        .divmargin 
 {
     margin-left: 30px; 
     margin-right:30px;
            
 }
        
    </style>
     
   
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <asp:MultiView ID="mvUser" runat="server" ActiveViewIndex="0">
        <asp:View ID="vUser" runat="server">
                  <div class="divmargin">
             
                <div style=" font-weight: bold; color: #707070; font-size: 20pt;
                   ">
                    <br />
                    Search For Available Service Provider
                    </div>
                <br />
                
               <u>Note:</u> You can search for any of the available service provider to make your request. 
               By entering pincode you can search available nearest Service provider. 
                <br /><br />
                <table>
                <tr>
                <td style="width:auto">
                   Select Any Service Provider &nbsp;
                   </td>
                   <td style="width:250px;">
                    <asp:DropDownList ID="ddlselecttype" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlselecttype_SelectedIndexChanged"
                        OnTextChanged="ddlselecttype_TextChanged1"  ToolTip="Select Service Provider as per your need" >
                    </asp:DropDownList>
                   </td>
                   <td style="width:200px;" >
                    <asp:CustomValidator ID="cvddlselecttype" runat="server" OnServerValidate="cvddlselecttype_ServerValidate1"
                        ForeColor="Red"></asp:CustomValidator>
                   </td>
               <td>

                    Search by PinCode
                    &nbsp;
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
                     </td>
                     <td>  
                        <asp:TextBox ID="txtPinCode" runat="server" OnTextChanged="txtPinCode_TextChanged" 
                            ToolTip="Enter PinCode to search service provider from that area"  class="form-control" AutoPostBack="True"
                            ></asp:TextBox>
                            </td>
                            <td>
                           <asp:Label runat="server" ID="lblSearch" ForeColor="Red"></asp:Label>
                          <%--  <asp:RegularExpressionValidator ID="rePinCode" runat="server" 
                                                        ControlToValidate="txtPinCode" ErrorMessage="Invalid PinCode !" 
                                                        ForeColor="Red" ValidationExpression="^[0-9]{1,6}$" ValidationGroup="btnSearch"></asp:RegularExpressionValidator>
                             
                         --%>   
                               </td>  
                               </tr>
                                             
                     </table>
                        <br />
                        <asp:Button ID="btnSearch" runat="server" Style="display: none" Text="Search"   OnClick="btnSearch_Click" />
                        <br />
                    </asp:Panel>
                    <div style="margin-left:30px;margin-right:30px;margin-bottom:50px;">
                    <asp:GridView ID="gvUser" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CellPadding="4" DataKeyNames="User_ID" style="margin-right:10px" EnableModelValidation="True" ForeColor="#333333"
                        GridLines="Both" OnPageIndexChanging="gvUser_PageIndexChanging" BorderWidth="1px"
                        BorderColor="#cccccc" BorderStyle="Solid" OnRowCommand="gvUser_RowCommand" OnSelectedIndexChanged="gvUser_SelectedIndexChanged"
                        AllowSorting="True" OnSorting="GridView1_Sorting" class="table table-striped  table-bordered"
                        PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                        <Columns>
                        
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
                                
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View">
                                <ItemTemplate>
                                    <asp:Button ID="btnView" class="btn btn-primary" runat="server" Text="View" CommandName="View"
                                        CommandArgument='<%#Eval("User_ID") %>' ToolTip="View more Detail"/>
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
                    </div>
                </div>
                
        </asp:View>
        <asp:View ID="vUserDetail" runat="server">
          <!-- BEGIN PAGE CONTENT-->
            <asp:Button ID="btnBack" class="btn btn-primary" runat="server" OnClick="btnBack_click" Text="Back" style="margin-left:1185px; margin-top:15px"></asp:Button>
          <br />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Note: You can contact the below service provider using below contact Detail.
            <table style="margin-left: 30px">
                <tr>
                   <%-- <td>    
                        <asp:Label ID="Label1" runat="server" Text="User Type" Visible="False"></asp:Label>
                        
                    </td>--%>
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
                    <td style="padding-top:5px;">
                        <asp:TextBox ID="txtFirstName" runat="server" BorderColor="White" BorderStyle="None"
                            Font-Bold="True" Font-Size="X-Large" Width="283px"></asp:TextBox>
                        <asp:TextBox ID="txtLastName" runat="server" BorderColor="White" BorderStyle="None"
                            Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address:
                    </td>
                    <td>
                        <div class="search-input-area">
                            <i class="icon-map-marker" style="font-size: xx-large"></i>
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" BorderColor="White"
                                BorderStyle="None" Rows="3" Width="282px"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtCity" runat="server" Visible="False" BorderColor="White" BorderStyle="None"></asp:TextBox>
                            <asp:TextBox ID="txtState" runat="server" Visible="False" BorderColor="White" BorderStyle="None"></asp:TextBox>
                            <asp:TextBox ID="txtPinCode1" runat="server" Visible="False" BorderColor="White" BorderStyle="None"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email:
                    </td>
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
                        Mobile No:
                    </td>
                    <td>
                        <div class="search-input-area">
                            <i class="icon-phone" style="font-size: x-large"></i>
                            <asp:TextBox ID="txtMobileNo" runat="server" BorderColor="White" BorderStyle="None"
                                ValidationGroup="Submit" Width="176px"></asp:TextBox>
                        </div>
                        
                    </td>
                </tr>
            </table>
            <br />
            <asp:MultiView ID="MvRegister" runat="server" ActiveViewIndex="0">
                <asp:View ID="Volunteer" runat="server">
               <div style="margin-left: 30px;margin-bottom:30px;">
                    <table style="margin-left: 20px;margin-bottom:30px;">
                       
                            <%
                                                
                                Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtAddress.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"570\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                            %>
                       
                    </table>
                </div>
                </asp:View>
                <asp:View ID="Donor" runat="server">
                    <table>
                    </table>
                </asp:View>
                <asp:View ID="Hospital" runat="server">
                     <table style="margin-left: 20px;margin-bottom:30px;">
                        
                            <%
                                                
                                Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtFirstName.Text + "Hospital" + txtPinCode1.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"570\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                            %>
                    </table>
                </asp:View>
                <asp:View ID="BloodBank" runat="server">
                    <table style="margin-left: 20px;margin-bottom:30px;">
                            <%
                                                
                                Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtFirstName.Text + "BloodBank" + txtPinCode1.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"570\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                            %>
                    
                    </table>
                </asp:View>
                <asp:View ID="PharmaCompany" runat="server">
                      <table style="margin-left: 20px;margin-bottom:30px;">
                            <%
                                                
                                Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtFirstName.Text + "Pharmaceutical" + txtPinCode1.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"570\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                            %>
                    
                    </table>
                </asp:View>
                <asp:View ID="Doctor" runat="server">
                     <table style="margin-left: 20px;margin-bottom:30px;">
                    </table>
                </asp:View>
                <br />
                <asp:View ID="NGO" runat="server">
                     <table style="margin-left: 20px;margin-bottom:30px;">
                            <%
                                                
                                Response.Write("<iframe  src=\"https://www.google.com/maps/embed?pb=!1m12!1m8!1m3!1d1904939.4532538687!2d72.81017772!3d21.1689128!3m2!1i1024!2i768!4f13.1!2m1!1s" + txtFirstName.Text + txtPinCode1.Text + "!5e0!3m2!1sen!2sin!4v1422699736554\" width=\"570\" height=\"500\" frameborder=\"0\" style=\"border:0\"></iframe>");    
                            %>
                        
                    </table>
                </asp:View>
                <asp:View ID="Media" runat="server">
                </asp:View>
            </asp:MultiView>
        </asp:View>
    </asp:MultiView>
</asp:Content>
