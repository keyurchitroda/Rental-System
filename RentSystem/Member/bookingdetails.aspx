<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="bookingdetails.aspx.cs" Inherits="RentSystem.Member.bookingdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12" style="margin-top:25px;">
        <div class="row bg-title">

            <div class="col-lg-12">
                <h4 class="page-title">View BookingDetails</h4>
                <ol class="breadcrumb">
                    <li><a href="Index.aspx">Dashboard</a></li>
                    <li><a href="My_Booking.aspx">My Booking</a></li>
                    <li class="active">View BookingDetails</li>
                </ol>
            </div>
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
                            <td>Booking Cancel</td>
                            
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
                    <td>
                        <a href="bookingcancel.aspx?amount=<%#Eval("DepositeAmount") %>&bid=<%#Eval("BookingId") %>" class="fa fa-close btn btn-danger"></a>
                    </td>
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
                              <th>Booking Cancel</th>
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
                     <td>
                        <a href="bookingcancel.aspx?amount=<%#Eval("DepositeAmount") %>&bid=<%#Eval("BookingId") %>" class="fa fa-close btn btn-danger"></a>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <asp:Repeater ID="rptCamraBooking" runat="server">
            <HeaderTemplate>
                <tr>
                    <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                        <tr style="background-color: #b52e31;">

                            <th>Image</th>
                            <th>Company Name</th>
                            <th>Model Name</th>
                            <th>Owner</th>
                            <th>MobileNo</th>
                              <th>Booking Cancel</th>
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
                       <td>
                        <a href="bookingcancel.aspx?amount=<%#Eval("DepositeAmount") %>&bid=<%#Eval("BookingId") %>" class="fa fa-close btn btn-danger"></a>
                    </td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
