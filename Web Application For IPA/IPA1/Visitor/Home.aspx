<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="IPA1.Visitor.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--/#main-slider start -->
        <section id="main-slider">
        <div class="owl-carousel">


          <div class="item" style="background-image: url(images/slider/slide2.jpg);">
                <div class="slider-inner">
                    <div class="container" style="margin-left:530px;margin-top:20px;">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                  
                                  <h2><span style="color:White;text-align:justify">Make the right choice! <br>Help those who are in need.</span></h2>
                               <a class="btn btn-primary btn-lg" href="RegistrationForm.aspx">Join Us</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div><!--/.item-->

               <div class="item" style="background-image: url(images/slider/Donate.jpg);">
                <div class="slider-inner">
                    <div class="container" style="margin-left:560px;">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                  
                                  <h2><span style="color:White;text-align:justify">Your donation really <br />can help save a life!</span></h2>
                                    <a class="btn btn-primary btn-lg" href="Donate.aspx">Donate</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div><!--/.item-->

            

             <div class="item" style="background-image: url(images/slider/blood.jpg);">
                <div class="slider-inner">
                    <div class="container" style="margin-left:130px;">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="carousel-content">
                                  
                                  <h2><span style="color:#c30A08;text-align:justify">
                                  For Blood Requirement 
                                  </h2>
                                    <a class="btn btn-primary btn-lg" style="background-color:#c30A08"  href="SearchAdmin.aspx">
                                    Click Here
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div><!--/.item-->


        </div><!--/.owl-carousel-->
    </section>
        <!--/#main-slider end-->
        

        <div class="container" style="margin-top:100px;">
           
                       <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Recent News</h2>
             <%--   <p class="text-center wow fadeInDown">
               <br>
               You may also see our activity how we are working in all parts of the country. 
                 </p>--%>
            </div>
        </div>    
           <section id="testimonial" style="padding-top:50px;">

        

          <%
              BusLib.Transaction.News objNews = new BusLib.Transaction.News();
              objNews.GetRecentNews();
              
               %>

        <div class="container">
            <div class="row">
                <div class="col-sm-8 col-sm-offset-2">

                    <div id="carousel-testimonial" class="carousel slide text-center" data-ride="carousel">
                        <!-- Wrapper for slides -->
                        <div class="carousel-inner" role="listbox">
                           
                           <%
                               if (objNews.Ds.Tables[0].Rows.Count > 0)
                               {
                                   for (int i = 0; i < objNews.Ds.Tables[0].Rows.Count; i++)
                                   {
                                       if (i == 0)
                                       {
                                       %>
                                           <div class="item active">
                                <p>
                                <img class="img-circle img-thumbnail" src="images/News1.jpg" width="100px" height="100px" alt=""/></p>
                              
                                <h4>
                                
                                <% Response.Write(objNews.Ds.Tables[0].Rows[i]["NewsTitle"].ToString()); %>
                                
                                </h4>
                                <%--<small> Treatment, storage, and disposal (TSD) worker</small>--%>
                                <p>
                                
                                <% Response.Write(objNews.Ds.Tables[0].Rows[i]["NewsDescription"].ToString()); %>

                                </p>
                          
                            </div>
                                           
                                     <% }
                                       else
                                       {
                                           %>
                             <div class="item">
                                <p><img class="img-circle img-thumbnail" src="images/News1.jpg"  width="100px" height="100px" alt=""/></p>
                                <h4>
                              <% Response.Write(objNews.Ds.Tables[0].Rows[i]["NewsTitle"].ToString()); %>
                                
                                </h4>
                                <%--<small>Treatment, storage, and disposal (TSD) worker</small>--%>
                                <p>
                                  <% Response.Write(objNews.Ds.Tables[0].Rows[i]["NewsDescription"].ToString()); %>
                                
                                </p>
                            </div>

                             <%       }
                                   }
                               }
                               
                                %>


                                </div>
                        <!-- Controls -->
                        <div class="btns">
                            <a class="btn btn-primary btn-sm" href="#carousel-testimonial" role="button" data-slide="prev">
                                <span class="fa fa-angle-left" style="padding-top:0px;" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="btn btn-primary btn-sm" href="#carousel-testimonial" role="button" data-slide="next">
                                <span class="fa fa-angle-right" style="padding-top:0px;" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
        <br />
        <br />
        <!--/# News End-->



</asp:Content>
