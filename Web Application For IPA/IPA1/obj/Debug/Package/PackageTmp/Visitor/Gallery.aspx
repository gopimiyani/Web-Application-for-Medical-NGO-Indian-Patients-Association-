<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="IPA1.Visitor.Gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.img-responsive
{
    height:none !important;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <!--/#gallery start -->
        <section id="portfolio" style="padding-top:50px;">
    <%
        BusLib.Master.AlbumMast objAlbum = new BusLib.Master.AlbumMast();
        BusLib.Master.ImageMast objImage = new BusLib.Master.ImageMast();

        objAlbum.GetDataSet("");

        if (Request.QueryString.Count > 0)
        {
            objImage.AlbumID1 = Convert.ToInt16( Request.QueryString["Album_ID"].ToString() );
        }
        
        objImage.GetDataSet("");
         %>
        <div class="container">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Gallery</h2>
                <p class="text-center wow fadeInDown">
                Take a look at our gallery to see how we endanger the poor people 
                who need medicare services.
               <br>
               You may also see our activity how we are working in all parts of the country. 
                 </p>
            </div>
            
            <div class="text-center">
                <ul class="portfolio-filter">
                <li>
               <%--<asp:HyperLink ID="hlAlbumAll" runat="server">HyperLink</asp:HyperLink> --%>
                <a class="active" href="#" data-filter="*">
                All
                </a>
                
                </li>
                <%
                    if (objAlbum.Ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < objAlbum.Ds.Tables[0].Rows.Count; i++)
                        {
                           %>
                         
                            
                              <li>
                   <%
                            Response.Write("<a href=\"#\" data-filter=."  + objAlbum.Ds.Tables[0].Rows[i]["Name"].ToString() + ">" + objAlbum.Ds.Tables[0].Rows[i]["Name"].ToString() + "</a>");
                        %>
                              
                           </a>
                             </li>
                  <%
                      }
                    }
                    
                             %>
                    
                     
                   <%-- <li><a href="#" data-filter=".creative">Creative</a></li>
                    <li><a href="#" data-filter=".corporate">Corporate</a></li>
                    <li><a href="#" data-filter=".portfolio">Portfolio</a></li>--%>

                </ul><!--/#portfolio-filter-->
            </div>

            <div class="portfolio-items">
                    <%
                        if (objImage.Ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < objImage.Ds.Tables[0].Rows.Count; i++)
                            {
                           %>
                           <% Response.Write(" <div class=\"portfolio-item "  + objImage.Ds.Tables[0].Rows[i]["Name"].ToString() + "\">"); %>
                     
                    <div class="portfolio-item-inner">
               
               <% 
                  Response.Write("<img src=\"images/" + objImage.Ds.Tables[0].Rows[i]["ImageName"].ToString() + "\"  class=\"img-responsive\" Width=\"582px\" Height=\"175px\" />");
                              //  Response.Write("<asp:Image ID=\"Image1\" ImageUrl=\"images/" + objImage.Ds.Tables[0].Rows[i]["ImageName"].ToString() + "\"  class=\"img-responsive\" Width=\"582px\" Height=\"175px\" />");
                   %> 
                      <%--<asp:Image ID="Image1" runat="server" class="img-responsive" Width="582px" Height="175px"/>
                       --%>  
                        <%
                         //   Image1.ImageUrl = "images/" + objImage.Ds.Tables[0].Rows[i]["ImageName"].ToString(); 
                         %>
                        
                           
                        <div class="portfolio-info">
                            <h3>
                          <% Response.Write(objImage.Ds.Tables[0].Rows[i]["ImageName"].ToString()); %>
                          <%--  Gallery Item <% Response.Write(i + 1); %>--%>
                            
                            </h3>
                      
                      
                       <% 
                                Response.Write("<a href=\"images/" + objImage.Ds.Tables[0].Rows[i]["ImageName"].ToString() + "\"  class=\"preview\" rel=\"prettyPhoto\">");
                      
                   %>      
                    
                              <i class="fa fa-eye" style="padding-top:9px;"></i></a>
                      
                           


                        </div>
                                   
                    </div>
                </div>
                        <%
                            }
                        } %>
                            
                 <!--/.portfolio-item-->

             
           <!--/.container-->
    </section>
        <!--/#gallery end-->
       

    </div>
       

</asp:Content>
