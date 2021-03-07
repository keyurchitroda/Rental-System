<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="House_MemberDetails.aspx.cs" Inherits="RentSystem.Member.House_MemberDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12" style="margin-top:25px;">
        <asp:Repeater runat="server" ID="rpthouseDetails">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>


                <div class="banner-bottom py-lg-5 py-3">
                    <div class="container">
                        <div class="inner-sec-shop pt-lg-4 pt-3">
                            <div class="row">
                                <div class="col-lg-4 single-right-left " style="margin-top: 80px;">
                                    <div class="grid images_3_of_2">
                                        <div class="flexslider1">
                                            <ul class="slides">

                                                <div class="thumb-image">
                                                    <img src='/admin/HouseImage/<%# Eval("Images") %>' data-imagezoom="true" style="width: 420px; height: 350px;" class="img-fluid" alt=" ">
                                                </div>

                                            </ul>
                                            <div class="clearfix"></div>
                                            <div style="margin-left: 140px;">
                                                <button type="button" class="btn btn-outline waves-effect waves-light" style="width: 200px; background-color: black;">
                                                    <a href="Booking.aspx?cid=<%#Eval("HouseId") %>&CatId=2" style="color: white" class="button">Book Now</a>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-sm-7  text-left">
                                    <table class="table table-responsive" style="width: 400px; height: 350px; margin-left: 180px; margin-top: 70px; font-size: 15px;">

                                        <tr>
                                            <td style="color:black;">
                                               <b>Owner Name</b>
                                            </td>
                                            <td>
                                                <%#Eval("HouseOwner") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color:black;">
                                                <b>Mobile</b>
                                            </td>
                                            <td>
                                                <%#Eval("MobileNo") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color:black;">
                                                <b>Address</b>
                                            </td>
                                            <td>
                                                <%#Eval("HouseAddress") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color:black;">
                                                <b>House Type</b>
                                            </td>
                                            <td>
                                                <%#Eval("HouseTypeName") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color:black;">
                                                <b>House No/Name</b>
                                            </td>
                                            <td>
                                                <%#Eval("HouseNo") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color:black;">
                                                <b>State</b>
                                            </td>
                                            <td>
                                                <%#Eval("StateName") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color:black;">
                                                <b>City</b>
                                            </td>
                                            <td>
                                                <%#Eval("CityName") %>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color:black;">
                                                <b>Area</b>
                                            </td>
                                            <td>
                                                <%#Eval("AreaName") %>
                                            </td>
                                        </tr>

                                        <tr style="color:blue;">
                                            <td>
                                                <b>Price</b>
                                            </td>

                                            <td><%#Eval("Price") %>(<%#Eval("RentTypeName") %>)
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
                </div>
                </div>
            </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
