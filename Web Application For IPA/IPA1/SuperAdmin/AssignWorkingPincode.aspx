<%@ Page Title="" Language="C#" MasterPageFile="~/SuperAdmin/SuperAdmin.Master" AutoEventWireup="true" CodeBehind="AssignWorkingPincode.aspx.cs" Inherits="IPA1.SuperAdmin.AssignWorkingPincode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
    
       input[type="text"],input[type="textarea"]
        {
            width:206px;
        }
   

    .style1
    {
        width: 210px;
    }
   

        .style4
        {
            width: 190px;
        }
           

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <!-- BEGIN PAGE CONTAINER-->
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
                    Assign Working Pincode

                    <%--<small>Editable Table Sample</small>--%>
                </h3>
                <ul class="breadcrumb">
                    <li><a href="Dashboard1.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                    </li>
                    <li><a href="#">Transaction</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="AdminDetail.aspx">Admin</a> <span class="divider">&nbsp;</span> </li>
                    <li><a href="#">Admin Detail Form</a><span class="divider-last">&nbsp;</span></li>
                </ul>
                <!-- END PAGE TITLE & BREADCRUMB-->
            </div>
        </div>
        <!-- END PAGE HEADER-->
        <!-- BEGIN ADVANCED TABLE widget-->
         <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN EXAMPLE TABLE widget-->
                <div class="widget">
                    <div class="widget-title">
                        <h4>
                            <i class="icon-reorder"></i>Admin Form</h4>
                        <span class="tools"><a href="javascript:;" class="icon-chevron-down"></a><a href="javascript:;"
                            class="icon-remove"></a></span>
                    </div>
                    <div class="widget-body">
                        <div class="portlet-body">
                            <div class="clearfix">
                            </div>
                        </div>
                        <div class="btn-group pull-right">
                            <button class="btn dropdown-toggle" data-toggle="dropdown">
                                Tools <i class="icon-angle-down"></i>
                            </button>
                            <ul class="dropdown-menu pull-right">
                                <li><a href="#">Print</a></li>
                                <li><a href="#">Save as PDF</a></li>
                                <li><a href="#">Export to Excel</a></li>
                            </ul>
                        </div>
                    </div>
        
                            <div class="space10">
                            </div>
                           
                            <!-- Here Put grid or table -->
  





     <table class="" style="margin-left:15px;">
        <tr>
            <td class="style1">
                <asp:Label ID="lblAdminName" runat="server" Text="Admin Name"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlAdminName" runat="server" 
                    CssClass="form-grid_dropdown" 
                    onselectedindexchanged="ddlAdminName_SelectedIndexChanged" AutoPostBack="true" >
                </asp:DropDownList>
            </td>
            <td>
            <asp:Label ID="lblcvAdminName" runat="server" ForeColor="Red" ></asp:Label>
            </td>
        </tr>
         <tr>
            <td class="style1">
                <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlState" runat="server" CssClass="form-grid_dropdown" 
                    onselectedindexchanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
             <td>
            <asp:Label ID="lblcvState" runat="server" ForeColor="Red" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-grid_dropdown" 
                    onselectedindexchanged="ddlCity_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
             <td>
            <asp:Label ID="lblcvCity" runat="server" ForeColor="Red" ></asp:Label>
            </td>
        </tr>
       <tr>
       <td>
           <asp:Button ID="btnGetPinCodeList" runat="server" 
               onclick="btnGetPinCodeList_Click" Text="Get Pincode List" />
           </td>
       <td></td>
       </tr>
        <tr>
            <td class="style1">
              <strong>  <asp:Label ID="lblSelectPincode" runat="server" Text="Select Working Pincode"></asp:Label></strong>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:CheckBoxList ID="cblPincode" runat="server">
                </asp:CheckBoxList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        
    </table>
         <table>
                                <tr>
                                    <td class="style4">

                                        &nbsp;&nbsp;&nbsp;

                               <asp:LinkButton ID="btnAssign" runat="server" OnClick="btnAssign_Click"
                                 class="btn btn-info">
                            <i class="icon-plus icon-white"></i>
                            Assign
                            </asp:LinkButton>
                                        
                                        
                                        <br />
                                        <br />
                                        
                                        
                                        </td>
                                    
                            <td>      
                         
                           </td>
                            <td>

                                <br />
                           
                           </td>
                           </tr>
                           </table>



</asp:Content>

