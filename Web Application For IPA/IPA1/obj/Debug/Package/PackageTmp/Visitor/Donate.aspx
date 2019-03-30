<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="Donate.aspx.cs" Inherits="IPA1.Visitor.Donate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">

.form-group
{
    margin-bottom:25px;
}


#contact .container-wrapper {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: none;
  z-index: 1;
}
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <section id="get-in-touch">
        <div class="container">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Make Donation</h2>
                <p class="text-center wow fadeInDown">
                Your contributions favouring Indian Patients Association is tax-exempt under Section 80 (G) of the Income Tax Act.
               <br /> Make a difference by helping us and continue saving lives! 
                Your donation really can help to save a life!
     
<br/>
                 IPA ensures that your donation is utilized properly. 

                 </p>
            </div>
        </div>
    </section><!--/#get-in-touch-->

    <br />

    <br />
    <h4 style="margin-left:2%;text-align:center;" > Already have a donor account?  <a href="Login.aspx"> <u>Go to Login >></u></a></h4>

    <h4 style="margin-left:2%;;text-align:center"> If you are new user, please register yourself as donor <a href="RegistrationForm.aspx"><u>Register Yourself >></u> </a></h4>
  <br />
  <br />
   <%-- <section id="contact">
    <asp:Image ID="Image1" runat="server" style="height:410px; margin-top:50px;" ImageUrl="images/Donate1.jpg"></asp:Image>
        <div id="" style="height:100px" ></div>
        <div class="container-wrapper" style="">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4" style="margin-left:550px;">
                        <div class="contact-form" style="border: 1px solid #CCC">
                            <h3 style="margin-bottom:20px;">Donate</h3>

                            <form id="main-contact-form" name="contact-form"
                            style="margin-left:20px;" method="post" action="#">
                               
                                <div class="form-group" style="margin-bottom:0px;">
                     
                                 <asp:TextBox ID="txtAmount" runat="server" 
                                 Font-Bold="False" MaxLength="100" CssClass="form-control"
                 placeholder="Amount"  required>
                 
                 </asp:TextBox>
                        <asp:Label ID="lblcvAmount" runat="server" ForeColor="Red" CssClass="label-validation">
                        </asp:Label>--%>
                             
    
   <%-- </div>
                                <div class="form-group">
                                    
                <asp:DropDownList runat="server" ID="ddlCurrency" CssClass="form-control">
                   
                    <asp:ListItem>INR</asp:ListItem>--%>
              
                 <%--   <asp:ListItem>USD</asp:ListItem>
                    <asp:ListItem>EURO</asp:ListItem>
                    <asp:ListItem>Pound</asp:ListItem>--%>
            <%--    </asp:DropDownList>
       

                                </div>
                                <div class="form-group">
                        
                                    <asp:TextBox TextMode="MultiLine"
             runat="server" ID="txtPurpose"  class="form-control" rows="5" placeholder="Purpose">
            </asp:TextBox>
    
                                </div>
                          <asp:Button ID="btnDoante" runat="server" CssClass="btn btn-primary" Text="Donate" 
                    OnClick="btnDonate_Click" ValidationGroup="Donate" />
        
                  </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>--%>
    <!--/#bottom-->



</asp:Content>
