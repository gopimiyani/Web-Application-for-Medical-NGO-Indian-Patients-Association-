<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IPA1.AdminLab.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Login</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="../assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/style_responsive.css" rel="stylesheet" />
    <link href="../css/style_default.css" rel="stylesheet" id="style_color" />
  
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body id="login-body">
    <div class="login-header">
        <!-- BEGIN LOGO -->
        <div id="logo" class="center">
            <img src="../img/logo.png" alt="logo" class="center" />
        </div>
        <!-- END LOGO -->
    </div>
    <!-- BEGIN LOGIN -->
    <div id="login">
        <!-- BEGIN LOGIN FORM -->
        <form id="loginform" class="form-vertical no-padding no-margin" runat="server">
        <div class="lock">
            <i class="icon-lock"></i>
        </div>
        <div class="control-wrap">
            <h4>
                User Login</h4>
            <div class="control-group">
                <div class="controls">
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-user"></i></span>
                        <asp:TextBox ID="txtUsername" placeholder="Username" runat="server"></asp:TextBox>
                  <%--   <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="*" ControlToValidate="txtUsername"
                            ValidationGroup="Login" Style="color: #FF0000">
                        </asp:RequiredFieldValidator>--%>
                       
                        <%-- <input id="input-username" type="text" placeholder="Username" />--%>
                    </div>
                </div>
            </div>
            <div class="control-group">
                <div class="controls">
                    <div class="input-prepend">
                        <span class="add-on"><i class="icon-key"></i></span>
                        <asp:TextBox ID="txtPassword" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                        <%--  <input id="input-password" type="password" placeholder="Password" />--%>
        <%--       <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="*" ControlToValidate="txtPassword"
                            ValidationGroup="Login">
                        </asp:RequiredFieldValidator>
                   --%>
                    
                    </div>
                    <div class="mtop10">
                        <div class="block-hint pull-left small">
                            <div class="remember">
                                <asp:CheckBox ID="cbRememberMe" runat="server" Text="Remember Me" class="remember"
                                    Checked="True" />
                            </div>
                            <%-- <input type="checkbox" id=""> Remember Me--%>
                        </div>
                        <div class="block-hint pull-right">
                            <a href="ForgotPassword.aspx" class="" id="forget-password">Forgot Password?</a>
                        </div>
                    </div>
                    <div class="clearfix space5">
                    </div>
                </div>
            </div>
        </div>
        <asp:Button ID="btnLogin" runat="server" class="btn btn-block login-btn" Text="Login"
            OnClick="btnLogin_Click" ValidationGroup="Login" />
        <%--  <input type="submit" id="login-btn" class="btn btn-block login-btn" value="Login" />--%>
      <%--  </form>--%>
        <!-- END LOGIN FORM -->
        <!-- BEGIN FORGOT PASSWORD FORM -->
      
      <%--  <form id="forgotform" runat="server" class="form-vertical no-padding no-margin hide" action="http://thevectorlab.net/adminlab/index.html">--%>
    <%-- %>       <div class="form-vertical no-padding no-margin hide">
        <p class="center">
            Enter your e-mail address below to reset your password.</p>
        <div class="control-group">
            <div class="controls">
                <div class="input-prepend">
                    <span class="add-on"><i class="icon-user"></i></span>
                    <asp:TextBox ID="TextBox1" placeholder="Username" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="txtUsername" ValidationGroup="Login" Style="color: #FF0000">
                    </asp:RequiredFieldValidator>
                    <%-- <input id="input-username" type="text" placeholder="Username" />--%>
        <%--        </div>
                <div class="input-prepend">
                    <span class="add-on"><i class="icon-envelope"></i></span>
                    <input id="input-email" type="text" placeholder="Email" />
                </div>
            </div>
            <div class="space20">
            </div>
        </div>
        <input type="button" id="forget-btn" class="btn btn-block login-btn" value="Submit" />
        </form>
       </div>
        <!-- END FORGOT PASSWORD FORM -->
    --%>
    
    </form>
    </div>
    <!-- END LOGIN -->
    <!-- BEGIN COPYRIGHT -->
    <div id="login-copyright">
          Copyright &copy; IPA | Developed By SCETIAN-GJRE
    </div>
    <!-- END COPYRIGHT -->
    <!-- BEGIN JAVASCRIPTS -->
    <script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../assets/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../js/jquery.blockui.js"></script>
    <script type="text/javascript" src="../js/scripts.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.initLogin();
        });
    </script>
    <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
<!-- Mirrored from thevectorlab.net/adminlab/login.html by HTTrack Website Copier/3.x [XR&CO'2013], Fri, 01 Aug 2014 10:50:13 GMT -->
</html>
