<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="IPA1.Visitor.Events" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <!--/# Events start-->
       
        <!-- On Going Events if any -->


           <section id="pricing" 
           style="background-image: -moz-linear-gradient(90deg, #2CAAB3 0%, #2C8CB3 100%);
           padding-top:50px;padding-bottom:10px;">
        <div class="container">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown" style="color:White;">On going events ...</h2>
               <%-- <p class="text-center wow fadeInDown">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut <br> et dolore magna aliqua. Ut enim ad minim veniam</p>--%>


               <section id="pricing" style="padding-top:0px;">

        <% BusLib.Transaction.Event objEvent = new BusLib.Transaction.Event();

           objEvent.GetDataset("");
           int f = 0;
            %>
        
        <div class="container">
        
           

       <%--     <div class="row">--%>

       <%
           if (objEvent.Ds.Tables[0].Rows.Count > 0)
           {
               
               for (int i = 0; i < objEvent.Ds.Tables[0].Rows.Count; i++)
               {
                   if (objEvent.Ds.Tables[0].Rows[i]["EventType"].ToString() == "OnGoing Event")
                   {
                       f = 1;
                  

                   %>
                <div class="col-sm-6 col-md-3">
                    <div class="wow zoomIn" data-wow-duration="400ms" data-wow-delay="0ms">
                   
                              <ul class="pricing" style="background-color:White">
                  
                            <li class="plan-header">
                                <div class="price-duration">
                                <%
                                    String EventDate = objEvent.Ds.Tables[0].Rows[i]["EventDate"].ToString();
                                    String EventDate1 = Convert.ToDateTime(EventDate.Substring(3, 2) + "/" + EventDate.Substring(0, 2) + "/" + EventDate.Substring(6, 4)).ToLongDateString();
                                    String[] Date = EventDate1.Split(' ');
                                    String EventDay = Date[2].Substring(0, 2);
                                    String EventMonth = Date[1];
                                    String EventYear = Date[3];
                                    
                                     %>
                          
                                     <span class="price" style="margin-top:25px;">
                                     <i class="fa fa-calender" style="font-size:25px;"></i>
                                    
                                        <% Response.Write(EventDay); %>
                                    </span>
                                    <span class="duration">
                                    <b>
                                        <% Response.Write(EventMonth); %></b>
                                    </span>
                                    
                                    <span class="duration">
                                    <b>
                                        <% Response.Write(EventYear); %>
                                    </b>
                                    </span>
                                </div>

                                <div class="plan-name">
                                    <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["EventName"].ToString()); %>
                                </div>
                            </li>
                            
                            <li>

                            <i class="fa fa-time" style="font-size:25px; float:left;"></i>
                             
                             <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["StartTime"].ToString()
                                    + " To " + objEvent.Ds.Tables[0].Rows[i]["EndTime"].ToString()); %>
                             
                             </li>
                             <li>
                            <i class="fa fa-map-marker" style="font-size:27px; float:left;"></i>
                             
                             <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["Location"].ToString()); %>
                             </li>

                             <li style="text-align:justify">
                            <i class="fa fa-list-alt" style="font-size:20px; float:left;"></i>
                             
                             <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["EventDescription"].ToString()); %>
                             </li>
                          
                        </ul>
                    </div>
                </div>
                <%
                    }
        
               }
           }
                     
          %>
        <%
          if (f==0) {    %>
                      
                       <p class="text-center wow fadeInDown" style="color:Black;font-size:25px;">
            <br />
                         No Ongoing Events ...
                       </p>
           <%} %>
                   </div>


            </section>

            </div>
        </div>
    </section>
    
    
    
        <!--Upcoming Events start -->
        <section id="pricing">
        
        <div class="container">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Upcoming Events</h2>
                <p class="text-center wow fadeInDown">

              We create events aiming to spear the voice for poor and needy
              people who can not get medical treatments. We gather support for
              them.
                 
                 <br> Please update with our events and confirm your presence.</p>
            </div>

           

       <%--     <div class="row">--%>

       <%
           if (objEvent.Ds.Tables[0].Rows.Count > 0)
           {
               for (int i = 0; i < objEvent.Ds.Tables[0].Rows.Count; i++)
               {
                   if (objEvent.Ds.Tables[0].Rows[i]["EventType"].ToString() == "Upcoming Event")
                   {
                       
                  

                   %>
                <div class="col-sm-6 col-md-3">
                    <div class="wow zoomIn" data-wow-duration="400ms" data-wow-delay="0ms">
                    <%if (i == 0)
                      { %>
                              <ul class="pricing featured">
                    <% } %>
                      
                      <% else
                          { %>
                          
                          <ul class="pricing">
                      <% } %>
                        
                            <li class="plan-header">
                                <div class="price-duration">
                                <%

                                    String EventDate = objEvent.Ds.Tables[0].Rows[i]["EventDate"].ToString();
                                    String EventDate1 = Convert.ToDateTime(EventDate.Substring(3, 2) + "/" + EventDate.Substring(0, 2) + "/" + EventDate.Substring(6, 4)).ToLongDateString();
                                    String[] Date = EventDate1.Split(' ');
                                    String EventDay = Date[2].Substring(0, 2);
                                    String EventMonth = Date[1];
                                    String EventYear = Date[3];
                                    
                                     %>
                          
                                     <span class="price" style="margin-top:25px;">
                                     <i class="fa fa-calender" style="font-size:25px;"></i>
                                    
                                        <% Response.Write(EventDay); %>
                                    </span>
                                    <span class="duration">
                                    <b>
                                        <% Response.Write(EventMonth); %></b>
                                    </span>
                                    
                                    <span class="duration">
                                    <b>
                                        <% Response.Write(EventYear); %>
                                    </b>
                                    </span>
                                </div>

                                <div class="plan-name">
                                    <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["EventName"].ToString()); %>
                                </div>
                            </li>
                            
                            <li>

                            <i class="fa fa-time" style="font-size:25px; float:left;"></i>
                             
                             <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["StartTime"].ToString()
                                    + " To " + objEvent.Ds.Tables[0].Rows[i]["EndTime"].ToString()); %>
                             
                             </li>
                             <li>
                            <i class="fa fa-map-marker" style="font-size:27px; float:left;"></i>
                             
                             <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["Location"].ToString()); %>
                             </li>

                             <li style="text-align:justify">
                            <i class="fa fa-list-alt" style="font-size:20px; float:left;"></i>
                             
                             <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["EventDescription"].ToString()); %>
                             </li>
                          
                        </ul>
                    </div>
                </div>
                <%
                    }
               }
           }
                      
          %>
          
           
            </div>
        </section>

       <!-- Past events start -->
     
    
       <section id="pricing">
     
        <div class="container">
     
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Past Events</h2>
                <p class="text-center wow fadeInDown">
              <%--  Lorem ipsum dolor sit amet, consectetur adipisicing elit,
                 sed do eiusmod tempor incididunt ut 
                 
                 <br> et dolore magna aliqua. Ut enim ad minim veniam</p>--%>
            </div>
    <%--           <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical"  Height="400px" Width="100%" Wrap="false" >--%>
               
       
       <table>
       <%
           if (objEvent.Ds.Tables[0].Rows.Count > 0)
           {
               int c = 0;
               for (int i = 0; i < objEvent.Ds.Tables[0].Rows.Count; i++)
               {
                   if (objEvent.Ds.Tables[0].Rows[i]["EventType"].ToString() == "Past Event")
                   {
                      
                       if (c % 4 == 0)
                       {
                          
                           %>
                           <tr>
                           <td>
                       <%}
                           c = c + 1;
                   %>
                <div class="col-sm-6 col-md-3">
                    <div class="wow zoomIn" data-wow-duration="400ms" data-wow-delay="0ms">
                        <ul class="pricing">
                            <li class="plan-header">
                                <div class="price-duration">
                                <%
                                    
String EventDate = objEvent.Ds.Tables[0].Rows[i]["EventDate"].ToString();
String EventDate1 = Convert.ToDateTime(EventDate.Substring(3, 2) + "/" + EventDate.Substring(0, 2) + "/" + EventDate.Substring(6, 4)).ToLongDateString();
String[] Date = EventDate1.Split(' ');
String EventDay = Date[2].Substring(0, 2);
String EventMonth = Date[1];
String EventYear = Date[3];
                                    
                                %>
                          
                                     <span class="price" style="margin-top:25px;">
                                     <i class="fa fa-calender" style="font-size:25px;"></i>
                                    
                                        <% Response.Write(EventDay); %>
                                    </span>
                                    <span class="duration">
                                    <b>
                                        <% Response.Write(EventMonth); %></b>
                                    </span>
                                    
                                    <span class="duration">
                                    <b>
                                        <% Response.Write(EventYear); %>
                                    </b>
                                    </span>
                                </div>

                                <div class="plan-name">
                                    <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["EventName"].ToString()); %>
                                </div>
                            </li>
                            
                            <li>

                            <i class="fa fa-time" style="font-size:25px; float:left;"></i>
                             
                             <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["StartTime"].ToString()
                                    + " To " + objEvent.Ds.Tables[0].Rows[i]["EndTime"].ToString()); %>
                             
                             </li>
                             <li>
                            <i class="fa fa-map-marker" style="font-size:27px; float:left;"></i>
                             
                             <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["Location"].ToString()); %>
                             </li>

                             <li style="text-align:justify">
                            <i class="fa fa-list-alt" style="font-size:20px; float:left;"></i>
                             
                             <% Response.Write(objEvent.Ds.Tables[0].Rows[i]["EventDescription"].ToString()); %>
                             </li>
                          
                        </ul>
                    </div>
                </div>
                
                <% if (c % 4 == 0 )
                   { %>
              
            </td></tr>
        
                   <%        
                    }
                }
              }
           }  
          %>
          </table>
            </div>
     
    </section>
        <!--/#Events End -->
       

</asp:Content>
