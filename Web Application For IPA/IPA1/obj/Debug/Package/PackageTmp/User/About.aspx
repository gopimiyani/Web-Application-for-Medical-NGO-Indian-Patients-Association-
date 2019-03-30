<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="IPA1.User.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <!--/#about start -->
        <section id="about" style="padding-top:50px;margin-top:60px;">
        <div class="container">

            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">About Us</h2>
                <p class="text-center wow fadeInDown">
                The Indian Patients Association is an <b>independent self-funding association</b> 
                which is there to help and support all patients in India by providing the 
                medical help to those people who are not able to get proper medical services 
                due to their economic situation and for some other reason.</p>
            </div>

            <div class="row">
                <div class="col-sm-6 wow fadeInLeft" style="margin-top:20px;">
                    <h3 class="column-title"></h3>
                    <!-- 16:9 aspect ratio -->
                    <div class="embed-responsive embed-responsive-16by9">
                <asp:Image ID="ImageAbout" runat="server" ImageUrl="~/Visitor/images/Healthcare2.jpg" Width="400px" Height="350px"></asp:Image>    
                    <%--    <iframe src="//player.vimeo.com/video/58093852?title=0&amp;byline=0&amp;portrait=0&amp;color=e79b39" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>--%>
                    
                    </div>
                </div>

                <div class="col-sm-6 wow fadeInRight">
                    <h3 class="column-title">Our Mission</h3>
                    <p>
                    <b>“No patients should have to be turned away without getting Medicare services 
                    due to lack of money” </b>
                    </p>

                    <p style="text-align:justify">
                    IPA will make awareness to the people to help others and 
                    will provide a medium to the organization who wants to help 
                    and the people who wants the help. 
                    </p>
                    
                    <p>
                    <b>
                    
                    Objectives
                    </b>
                    </p>
                    <div class="row">
                        <div class="col-sm-6">
                            <ul class="nostyle">
                                <li style="width:500px;"><i class="fa fa-check-square"></i> 24/7 Avaibility</li>
                                <li style="width:500px;"><i class="fa fa-check-square"></i> Build a strong and a bouncing platform</li>
                                <li style="width:500px;"><i class="fa fa-check-square"></i> To encourage  people to help others</li>
                                <li style="width:500px;"><i class="fa fa-check-square"></i> Provide efficient communication </li>
                         
                            </ul>
                        </div>

                        <%--<div class="col-sm-6">
                            <ul class="nostyle">
                            </ul>
                        </div>--%>
                    </div>

                  <%--  <a class="btn btn-primary" href="#">Learn More</a>--%>

        </div>
    </section>
        <!--/#about end -->

       
       <!--/#services start -->
        <section id="services" style="padding-top:50px;">
        <div class="container">

            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Our Services</h2>
                <p class="text-center wow fadeInDown">
                All of our services is centralized to the walfare of the poor people.
                We serve them with better medical services.
                
                <br> <%--et dolore magna aliqua. Ut enim ad minim veniam--%>
                
                </p>
            </div>

            <div class="row">
                <div class="features">
                    <div class="col-md-5 col-sm-6 wow fadeInUp" data-wow-duration="300ms" data-wow-delay="0ms">
                        <div class="media service-box">
                            <div class="pull-left">
                                <i class="fa fa-line-chart" 
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">Fund Raising</h4>
                                  <p style="text-align:justify">
                                We raise funds for the poor people all 
                                over the country-India. We collect donation aiming to provide
                                medical help and keep them safe.

                                </p>
                            </div>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-5 col-sm-6 wow fadeInUp" data-wow-duration="300ms"
                     data-wow-delay="100ms" style="margin-left:40px;">
                        <div class="media service-box">
                            <div class="pull-left">
                               <i class="fa fa-time"
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                            <div class="media-body">
                                <h4 class="media-heading">24/7 Avaibility</h4>
                                <p style="text-align:justify">
                               
                               We cater to all parts of the country 
                               to help any patient who's in any kind of need
                               at any time. You can cotact any time.

                                 </p>
                            </div>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-5 col-sm-6 wow fadeInUp" data-wow-duration="300ms" 
                    data-wow-delay="200ms">
                        <div class="media service-box">
                            <div class="pull-left">
                              
                                   <i class="fa fa-heart"
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                             <div class="media-body">
                                <h4 class="media-heading">Healthcare Solutions</h4>
                                <p style="text-align:justify">
                                We constantly seek out volunteers, hospitals, doctors,
                                pharmacompanies, bloodbanks and financial donors to
                                provide best healthcare solutions to needy and poor patients.
                                </p>
                            </div>
                        </div>
                    </div><!--/.col-md-4-->
                
                    <div class="col-md-5 col-sm-6 wow fadeInUp" data-wow-duration="300ms" 
                    data-wow-delay="300ms" style="margin-left:40px;">
                        <div class="media service-box">
                            <div class="pull-left">
                                  <i class="fa fa-group"
                                style="width: 100px; height: 100px; font-size:40px; padding-top:20px;">
                                </i>
                            </div>
                             <div class="media-body">
                                <h4 class="media-heading">Efficient communication and coordination</h4>
                                <p style="text-align:justify">
                                We provide improved communication and coordination among 
                                healthcare volunteers, donors, hospitals, bloodbanks,
                                patients and healthcare organizations.
                                 </p>
                            </div>
                        </div>
                    </div><!--/.col-md-4-->

                    
                </div>
            </div><!--/.row-->    
        </div><!--/.container-->
    </section>
        <!--/#services end-->
       


</asp:Content>
