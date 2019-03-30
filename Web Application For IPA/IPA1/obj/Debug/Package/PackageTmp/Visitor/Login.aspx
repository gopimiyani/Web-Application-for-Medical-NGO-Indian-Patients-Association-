<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" 
CodeBehind="Login.aspx.cs" Inherits="IPA1.Visitor.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="css/loginstyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="loginbody">
    <div id="login-form">

        <h3 style="margin-left:20px;">Login</h3>

        <fieldset>

            <form action="javascript:void(0);" method="get" class="">
            <div class="form-group">
               <asp:DropDownList ID="ddlUserType" runat="server" class="form-control" 
                    placeholder="" AppendDataBoundItems="True" 
                    onselectedindexchanged="ddlUserType_SelectedIndexChanged" style="width:330px;height:40px">

                </asp:DropDownList>
            </div>
         <%--          <asp:Label ID="lblrvUserType" runat="server" Text="*" ForeColor="Red" 
                    Visible="False"></asp:Label>
      --%>
            <div class="form-group">
            <asp:TextBox ID="txtUserName" runat="server" placeholder="Username" CssClass="form-control" ForeColor="#555555">
            </asp:TextBox>
             </div>
              <div class="form-group">
          
            <asp:TextBox ID="txtPwd" runat="server"  placeholder="Password" TextMode="Password"
            style="margin-top:15px;" ForeColor="#555555" CssClass="form-control">
            
            </asp:TextBox>
          </div>     
       <footer class="clearfix">

         <span class=""  style="margin-left:5px;color:#64686D" >
                      
                      <asp:CheckBox ID="cbRememberMe" runat="server" ></asp:CheckBox>
                      </span>Remember Me
       
                    <span class="info" style="margin-left:80px;" >?</span><a href="ForgotPassword.aspx">Forgot Password</a>

                    

                </footer>
          
                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" 
                ValidationGroup="Login" Width="150px"/>
             
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click"
                Width="150px" style="margin-left:25px;" />

                             

            </form>

        </fieldset>

    </div> <!-- end login-form -->
    </div>
</asp:Content>
