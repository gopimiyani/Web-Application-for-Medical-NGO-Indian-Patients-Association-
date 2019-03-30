<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="IPA1.AdminLab.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Forgot Password</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="../assets/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/style_responsive.css" rel="stylesheet" />
    <link href="../css/style_default.css" rel="stylesheet" id="style_color" />
    <style type="text/css">
        body
        {
            font-family:"Arial";
            font-size:13px;
            color:#868686;
        }
        .input-prepend
        {
            
    display: inline-block;
    margin-bottom: 10px;
    font-size: 0px;
    white-space: nowrap;
    vertical-align: middle;
}
        }
    </style>
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
        <!-- BEGIN FORGOT PASSWORD FORM -->
        <form id="forgotform" runat="server" class="form-vertical no-padding no-margin">
        <p class="center">
            Enter your e-mail address below to reset your password.</p>
        <div class="control-group">
            <div class="controls">
                <div class="input-prepend" style="width:371px;height:42px;">
                    <span class="add-on"><i class="icon-envelope"></i></span>
                    <asp:TextBox ID="txtEmail" placeholder="Email" runat="server" ValidationGroup="Submit"
                    style="width:313px;height:20px;"></asp:TextBox>
                    <br />
                </div>
            </div>
            <div class="space20">
            </div>
        </div>
        <asp:Button ID="btnSubmit" runat="server" class="btn btn-block login-btn" Text="Submit"
            ValidationGroup="Submit" style="width:370px;height:40px;" OnClick="btnSubmit_Click1" />
            <br />
               <a href="Login.aspx"> << Back to Login </a>

        </form>
        <!-- END FORGOT PASSWORD FORM -->

      
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
<!-- END BODY -->
<!-- Mirrored from thevectorlab.net/adminlab/login.html by HTTrack Website Copier/3.x [XR&CO'2013], Fri, 01 Aug 2014 10:50:13 GMT -->
</html>
