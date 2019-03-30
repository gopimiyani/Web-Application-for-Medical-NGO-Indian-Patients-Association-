<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" 
AutoEventWireup="true" CodeBehind="TermsandCondition.aspx.cs" Inherits="IPA1.Visitor.TermsandCondition" %>
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
<asp:MultiView ID="mvAdmin" runat="server" ActiveViewIndex="0">
        <asp:View ID="vAdmin" runat="server">
                  <div class="divmargin">
             
                <div style="margin-left:80px;font-weight: bold; color: #707070; font-size: 20pt;">
                    <br />
                    Terms and Conditions
                    </div>
                <br />
                
                 
                
               
             
                    <div style="margin-left:80px;margin-right:100px;margin-bottom:50px;">
                    <asp:GridView ID="GvTerm" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            CellPadding="4" DataKeyNames="Term_ID" EnableModelValidation="True" ForeColor="#333333"
                                            GridLines="Both" OnPageIndexChanging="GvTerm_PageIndexChanging" OnRowCancelingEdit="GvTerm_RowCancelingEdit"
                                            OnRowDeleting="GvTerm_RowDeleting" OnRowEditing="GvTerm_RowEditing" OnRowUpdating="GvTerm_RowUpdating"
                                            ShowFooter="True" BorderWidth="1px" BorderColor="#cccccc" BorderStyle="Solid"
                                            class="table table-striped  table-bordered" PageSize="5">
                                            <AlternatingRowStyle BackColor="White" ForeColor="#333333" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Term No" SortExpression="Term_ID">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMCode" runat="server" Text='<%#Eval("Term_ID") %>' Width="80"></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Term_ID") %>'></asp:Label>
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <%--   <asp:TextBox ID="txtICode" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rfvICode" runat="server" 
            ControlToValidate="txtICode" ValidationGroup="Insert" 
            ErrorMessage="*" SetFocusOnError="True" 
            ></asp:RequiredFieldValidator>
                                                        --%></FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Terms and Conditions" SortExpression="TermName">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("TermName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtName" class="inputtext" runat="server" Text='<%#Eval("TermName") %>'
                                                            Width="600" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                                            ValidationGroup="Update" ForeColor="Red" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                   <%-- <FooterTemplate>
                                                        <asp:TextBox ID="txtIName" runat="server" class="inputtext" Width="600" TextMode="MultiLine"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvIName" runat="server" ControlToValidate="txtIName"
                                                            ValidationGroup="Insert" ForeColor="Red" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                    </FooterTemplate>--%>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnEdit" class="btn btn-info" Width="65px" runat="server" Text="Edit" CommandName="Edit" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Button ID="btnUpdate" runat="server"  Width="65px" class="btn btn-inverse" Text="Update" CommandName="Update"
                                                            ValidationGroup="Update" />
                                                    </EditItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="btninsert" runat="server"  Width="65px" class="btn btn-info" Text="Insert" ValidationGroup="Insert"
                                                            OnClick="btninsert_Click" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnDelete" class="btn btn-info"  Width="65px" runat="server" Text="Delete" CommandName="Delete" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Button ID="btnCancel" runat="server"  Width="65px" class="btn btn-inverse" Text="Cancel" CommandName="Cancel" />
                                                    </EditItemTemplate>
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
        </asp:MultiView>

</asp:Content>
