<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="IPA1.ErrorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">


    <div style="margin-left:110px;margin-bottom:190px;margin-top:50px;">
      <img src="/Visitor/images/logo2.jpg" alt="logo" width="150px" height="60px"/>
      <br /><br />
<h2>  Sorry, An Error Has Occurred</h2>
<br />
<h4> An unexpected error occured on our web application. Sorry for the inconveniency.</h4>

<h4>

<%if (Session["User_ID"] != null)
  {
      if (Session["UserType"].ToString() == "SuperAdmin")
      {
          %>
          <a href="../SuperAdmin/Dashboard1.aspx"><u> Return to the home page </u></a>
          <%
      }
      else if (Session["UserType"].ToString() == "Admin")
      {%>

           <a href="../AdminLab/Dashboard1.aspx"><u> Return to the home page </u></a>
      <%}
      else
      {%>
      <a href="../Visitor/Home.aspx"><u> Return to the home page </u></a>
          
      <%}
  }
  else
  {%>
     <a href="../Visitor/Home.aspx"> <u> Return to the home page </u></a>
  <%}%>


  </h4>

</div>
    </form>
</body>
</html>
