<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs"
    Inherits="IPA1.AdminLab.ResetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Reset Password</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="../assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/style_responsive.css" rel="stylesheet" />
    <link href="../css/style_default.css" rel="stylesheet" id="style_color" />
</head>
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
        <!-- BEGIN FORGOT PASSWORD FORM -->
        <form id="loginform" class="form-vertical no-padding no-margin" runat="server">
        <div class="lock">
            <i class="icon-key" style="font-size:78pt"></i>
        </div>
        <div class="control-wrap">
            <h4>
                Select your new password</h4>
            <div class="control-group">
                <div class="controls">
                    <div class="input-prepend">
                       <span class="add-on"><i class="icon-key"></i></span>
                        <asp:TextBox ID="txtChangePassword" placeholder="Enter New Password" runat="server"
                            TextMode="Password"></asp:TextBox>
                       <%-- <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtChangePassword"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>--%>
                        <br />
                        <br />
                       
                       <span class="add-on"><i class="icon-key"></i></span>
                        <asp:TextBox ID="txtConfirmPassword" placeholder="Retype new Password" runat="server"
                            TextMode="Password"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                            ErrorMessage="*" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>--%>
                    </div>
                    <div class="clearfix space5">
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:Button ID="btnSubmit" runat="server" class="btn btn-block login-btn" Text="Change password"
            ValidationGroup="Submit" OnClick="btnSubmit_Click" />
            <br />
               <a href="Login.aspx"> << Back to Login </a>
        <!-- END FORGOT PASSWORD FORM -->
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
function forget-btn_onclick() {

}

    </script>
    <!-- END JAVASCRIPTS -->
</body>
</html>
