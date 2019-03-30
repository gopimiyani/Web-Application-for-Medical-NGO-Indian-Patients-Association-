<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLab/Home.Master" AutoEventWireup="true"
    CodeBehind="Dashboard1.aspx.cs" Inherits="IPA1.Dashboard1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <!-- BEGIN PAGE HEADER-->
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN THEME CUSTOMIZER-->
                <div id="theme-change" class="hidden-phone">
                    <i class="icon-cogs"></i><span class="settings"><span class="text">Theme:</span> <span
                        class="colors"><span class="color-default" data-style="default"></span><span class="color-gray"
                            data-style="gray"></span><span class="color-purple" data-style="purple"></span>
                        <span class="color-navy-blue" data-style="navy-blue"></span></span></span>
                </div>
                <!-- END THEME CUSTOMIZER-->
                <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                <h3 class="page-title">
                    Dashboard 
                    <%--<small>General Information </small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Admin Lab</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Dashboard</a><span class="divider-last">&nbsp;</span></li>
                    <li class="pull-right search-wrap">
                     
                    </li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN PAGE CONTENT-->
        <div id="page" class="dashboard">
            <!-- BEGIN OVERVIEW STATISTIC BLOCKS-->
            <div class="row-fluid circle-state-overview">
                <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                   <div class="circle-stat block">
                        <div class="visual">
                            <div class="circle-state-icon">
                           <a href="UserMast.aspx?UserType=Volunteer">
                   
                                <i class="icon-user turquoise-color"></i>
                                </a>
                            </div>
                            <input class="knob" data-width="100" data-height="100" data-displayprevious="true"
                                data-thickness=".2" value="100" data-fgcolor="#4CC5CD" data-bgcolor="#4CC5CD">
                        </div>
               
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblVolunteers" runat="server" Text=""></asp:Label>
                                <%-- +33--%>
                            </div>
                            <%--         <asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label>--%>
                            <div class="title">
                              Volunteers  
                            </div>
                        </div>
                    </div>
                </div>
                <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                    <div class="circle-stat block">
                        <div class="visual">
                            <div class="circle-state-icon">
                               <a href="UserMast.aspx?UserType=Hospital">
                                <i class="icon-plus-sign green-color"></i>
                                </a>
                            </div>
                            <input class="knob" data-width="100" data-height="100" data-displayprevious="true"
                                data-thickness=".2" value="100" data-fgcolor="#a8c77b" data-bgcolor="#a8c77b" />
                        </div>
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblHospitals" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="title">
                                Hospitals</div>
                        </div>
                    </div>
                </div>
                <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                    <div class="circle-stat block">
                        <div class="visual">
                            <div class="circle-state-icon">
                               <a href="UserMast.aspx?UserType=BloodBank">
                                <i class="icon-tint red-color"></i>
                                </a>
                            </div>
                            <input class="knob" data-width="100" data-height="100" data-displayprevious="true"
                                data-thickness=".2" value="100" data-fgcolor="#e17f90" data-bgcolor="#e17f90" />
                        </div>
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblBloodBanks" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="title">
                                BloodBanks</div>
                        </div>
                    </div>
                </div>
                <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                    <div class="circle-stat block">
                        <div class="visual">
                            <div class="circle-state-icon">
                               <a href="UserMast.aspx?UserType=PharmaCompany">
                                <i class="icon-bar-chart gray-color"></i>
                                </a>
                            </div>
                            <input class="knob" data-width="100" data-height="100" data-displayprevious="true"
                                data-thickness=".2" value="100" data-fgcolor="#b9baba" data-bgcolor="#b9baba" />
                        </div>
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblPharmaCompanies" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="title">
                                PharmaCompanies</div>
                        </div>
                    </div>
                </div>
                <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                    <div class="circle-stat block">
                        <div class="visual">
                            <div class="circle-state-icon">
                               <a href="UserMast.aspx?UserType=Doctor">
                                <i class="icon-plus blue-color"></i>
                                </a>
                            </div>
                            <input class="knob" data-width="100" data-height="100" data-displayprevious="true"
                                data-thickness=".2" value="100" data-fgcolor="#93c4e4" data-bgcolor="#93c4e4" />
                        </div>
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblDoctors" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="title">
                                Doctors</div>
                        </div>
                    </div>
                </div>
                
            <%--</div>--%>
            <!-- next -->
         <%--   <div class="space20">
            </div>
         --%> <%--  <div class="row-fluid circle-state-overview">--%>
          
          <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                    <div class="circle-stat block">
                        <div class="visual">
                            <div class="circle-state-icon">
                               <a href="UserMast.aspx?UserType=Donor">
                                <i class="icon-user purple-color"></i>
                                </a>
                            </div>
                            <input class="knob" data-width="100" data-height="100" data-displayprevious="true"
                                data-thickness=".2" value="100" data-fgcolor="#c8abdb" data-bgcolor="#c8abdb" />
                        </div>
                        <div class="details">
                            <div class="number">
                                <asp:Label ID="lblDonors" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="title">
                                Donors</div>
                        </div>
                    </div>
                </div>

            <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                <div class="circle-stat block">
                    <div class="visual">
                        <div class="circle-state-icon">
                            <a href="ViewRequest.aspx?Status=Pending">
                            <i class="icon-hand-up red-color"></i>
                            </a>
                        </div>
                        <input class="knob" data-width="100" data-height="100" data-displayprevious="true"
                            data-thickness=".2" value="100" data-fgcolor="#e17f90" data-bgcolor="#e17f90" />
                    </div>
                    <div class="details">
                        <div class="number">
                            <asp:Label ID="lblPendingRequests" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="title">
                            Pending Requests</div>
                    </div>
                </div>
            </div>
          


            <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                <div class="circle-stat block">
                    <div class="visual">
                        <div class="circle-state-icon">
                        <a href="ApproveNewUser.aspx">
                            <i class="icon-user turquoise-color"></i>
                            </a>
                        </div>
                        <input class="knob" data-width="100" data-height="100" data-displayprevious="true"
                            data-thickness=".2" value="100" data-fgcolor="#4CC5CD" data-bgcolor="#4CC5CD">
                    </div>
                    <div class="details">
                        <div class="number">
                            <asp:Label ID="lblPendingUsers" runat="server" Text=""></asp:Label>
                            <%-- +33--%>
                        </div>
                        <%--         <asp:Label ID="lbl2" runat="server" Text="Label"></asp:Label>--%>
                        <div class="title">
                            Approve
                           <br /> Pending Users
                           
                        </div>
                    </div>
                </div>
            </div>

                  <div class="span2 responsive" data-tablet="span3" data-desktop="span2">
                    <div class="circle-stat block">
                        <div class="visual">
                            <div class="circle-state-icon">
                         <%--   <a href="#">--%>
                                <i class="icon-eye-open green-color"></i>
                                <%--</a>--%>
                            </div>

                            <input class="knob" data-width="100" data-height="100" data-displayprevious="true"
                                data-thickness=".2" value="100" data-fgcolor="#a8c77b" data-bgcolor="#a8c77b" />
                        </div>
                        <div class="details">
                            <div class="number">
                              <asp:Label ID="lblUniqueVisitor" runat="server" Text=""></asp:Label>
                               </div>
                            <div class="title">
                                 Visitors</div>
                        </div>
                    </div>
                </div>
                  <!-- END NOTIFICATIONS PORTLET-->
                  </div>
     </div>
    <!-- END PAGE CONTENT-->
    <script type="text/javascript" src="../assets/uniform/jquery.uniform.min.js"></script>
    <script type="text/javascript" src="../assets/data-tables/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../assets/data-tables/DT_bootstrap.js"></script>
    <script type="text/javascript" src="../js/table-editable.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            App.init();
            TableEditable.init();
        });
    </script>
</asp:Content>
