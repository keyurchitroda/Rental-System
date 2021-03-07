<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="adminbookingdetails.aspx.cs" Inherits="RentSystem.admin.adminbookingdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
<div class="col-sm-12">
       <div class="col-sm-12" >
         <div class="row">
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1><b> Details </b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
        </div>
      <asp:Repeater ID="rptBookingDetails" runat="server">
            <HeaderTemplate>
                <tr>
                    <table class="table table-responsive table-bordered" style=" box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                        <tr style="background-color: #b52e31;color:white">

                            <td>Image</td>
                            <td>Company Name</td>
                            <td>Model Name</td>
                            <td>SubModel Name</td>
                            <td>Car No</td>
                            <td>Owner Name</td>
                            <td>Owner MobileNo</td>
                           
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>

                    <td>
                        <img src='/admin/Car_Img/<%# Eval("CarImage") %>' style="height: 100px; width: 150px;"></td>
                    <td><%#Eval("CompanyName") %></td>
                    <td><%#Eval("ModelName") %></td>
                    <td><%#Eval("SubModelName") %></td>
                    <td><%#Eval("CarNo") %></td>
                    <td><%#Eval("CarOwner") %></td>
                    <td><%#Eval("CarOwnerMobileNo") %></td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <asp:Repeater ID="rptHouseBooking" runat="server">
            <HeaderTemplate>
                <tr>
                    <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                        <tr style="background-color: #b52e31;">

                            <th>Image</th>
                            <th>State Name</th>
                            <th>City Name</th>
                            <th>Area Name</th>
                            <th>House No</th>
                            <th>Owner</th>
                            <th>Owner Addres</th>
                             
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>

                    <td>
                        <img src='/admin/HouseImage/<%# Eval("Images") %>' style="height: 100px; width: 150px;"></td>
                    <td><%#Eval("StateName") %></td>
                    <td><%#Eval("CityName") %></td>
                    <td><%#Eval("AreaName") %></td>
                    <td><%#Eval("HouseNo") %></td>
                    <td><%#Eval("HouseOwner") %></td>
                    <td><%#Eval("HouseAddress ") %></td>
                       </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <asp:Repeater ID="rptCameraBooking" runat="server">
            <HeaderTemplate>
                <tr>
                    <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                        <tr style="background-color: #b52e31;">

                            <th>Image</th>
                            <th>Company Name</th>
                            <th>Model Name</th>
                            <th>Owner</th>
                            <th>MobileNo</th>
                              
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>

                    <td>
                        <img src='/admin/Camera_Img/<%# Eval("Image") %>' style="height: 100px; width: 150px;"></td>
                    <td><%#Eval("CompanyName") %></td>
                    <td><%#Eval("ModelName") %></td>
                    <td><%#Eval("Owner") %></td>
                    <td><%#Eval("MobileNo") %></td>
                      
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
