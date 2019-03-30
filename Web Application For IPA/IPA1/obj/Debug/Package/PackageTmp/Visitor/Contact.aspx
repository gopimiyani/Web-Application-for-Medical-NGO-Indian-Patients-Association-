<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="IPA1.Visitor.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style type="text/css">
 .label-validation
        {           
            padding-left: 4px;
            font-size: small;
            color: Red;
        }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <!--/# get-in-touch start -->
        
        <section id="get-in-touch" style="padding-bottom:0px;padding-top:70px;">
        <div class="container">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Get in Touch</h2>
                  <p class="text-center wow fadeInDown">
                  If you feel, need working for poor people please contact with us and
                   let us know how you like to work for them.
                  <br>Feel free to contact with us through mail address. </p>
                    <div class="row">
                       <div class="wow fadeInDown">
                        <div class="col-sm-4" style="margin-left:90px;">
                            
                            <ul class="nostyle">

                                <li>
                                <h3 style="color:White">Address</h3>
							<address >
                            B-47, Narayannagar Society,<br />
                             Katargam Siganpur Road, <br />
                             Katargam, Surat
								<%--F-73, C-Wing, Shreeji Arcade,<br />
                                B/h. Bhulka Bhavan School,<br />
                                Anand Mahal Road,<br />
                                Adajan, Surat --%>
							</address>
                                </li>
                         
                            </ul>
                        </div>
                          <div class="col-sm-4" style="margin-left:40px;">
                            <ul class="nostyle">
                                <li>
                                
                                	<h3 style="color:White">Phones</h3>
						
								+91 7801802454
                                </li>
                                <li>
                                +91 8886211375
							
                                </li>
                                </ul>
                         
                         
                        </div>
                        <div class="col-sm-2">
                            <ul class="nostyle" >
                                <li>
                                <h3 style="color:White">Email</h3>
                                 IPANGO992015@gmail.com
                                </li>
                         
                            </ul>
                        </div>
                        </div>
                        </div>
                </div>
                </div>
        </section>
        <!--/#get-in-touch-->
        <section id="contact">
        <div id="google-map" style="height:650px" data-latitude="52.365629" data-longitude="4.871331"></div>
        <div class="container-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4 col-sm-offset-8">
                        <div class="contact-form">
                            <h3>Contact Us</h3>

                            Contact with us if any more information needed.
                            </address>

                            <form id="main-contact-form" name="contact-form" method="post" action="#">
                                <div class="form-group">
                                      <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Name" required>
                                      </asp:TextBox>
                   
                                </div>
                                <div class="form-group" style="margin-bottom:0px;">
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email" required>
                                        </asp:TextBox>
                                        <asp:RegularExpressionValidator ID="reEmail" runat="server" ControlToValidate="txtEmail"
                                                    ErrorMessage="Invalid Email  Address" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="Submit" CssClass="label-validation"></asp:RegularExpressionValidator>
                                           
                                  
                                </div>
                                <div class="form-group">

                                    <asp:TextBox ID="txtSubject" runat="server" class="form-control" placeholder="Subject" required>
                                    </asp:TextBox>
                                </div>
                                <div class="form-group">

                                  <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine"
                                  class="form-control" rows="8" placeholder="Message" required>
                                  </asp:TextBox>
                                </div>

                                <asp:Button ID="btnSend" runat="server" Text="Send Message"  ValidationGroup="Submit" CssClass="btn btn-primary" 
                                    onclick="btnSend_Click" />
                            </form>
                        </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </section>

     <!-- gallery end -->


</asp:Content>
