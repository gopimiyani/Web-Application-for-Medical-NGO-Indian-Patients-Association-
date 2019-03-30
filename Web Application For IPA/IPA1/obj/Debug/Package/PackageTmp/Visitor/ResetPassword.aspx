<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="IPA1.Visitor.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="css/loginstyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="loginbody">
    <div id="login-form">

        <h3 style="margin-left:20px;">Reset Password</h3>

        <fieldset>

            <form action="javascript:void(0);" method="get" class="">
            <div class="form-group">
      
            <asp:TextBox ID="txtChangePassword" placeholder="Enter New Password" runat="server"
                            TextMode="Password" CssClass="form-control" ForeColor="#555555" Width="330px">
            </asp:TextBox>
                  
            </div>
             <div class="form-group">
              <asp:TextBox ID="txtConfirmPassword" placeholder="Retype new Password" runat="server"
                            TextMode="Password" CssClass="form-control" ForeColor="#555555" Width="330px">
          </asp:TextBox>
                     
             </div>
          <footer class="clearfix">
                </footer>
          
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Reset Password" 
                Width="330px"/>
            
            </form>

        </fieldset>

    </div> <!-- end login-form -->
    </div>





</asp:Content>
