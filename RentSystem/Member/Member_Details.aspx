<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="Member_Details.aspx.cs" Inherits="RentSystem.Member.Member_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <style>
        .divs {
            width: 150px;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="body2" style="margin-top:25px;">
        <div class="main">
            <asp:Repeater ID="rptCarData" runat="server">
                <HeaderTemplate>
                    <div class="col-sm-12 ">
                        <center><h1>
                          <i class="fa fa-car"></i>
                          <b>Car</b>
                          <i class="fa fa-car"></i>
                         </h1></center>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>

                    <div class="col-sm-4" style="margin-top: 15px;">
                        <div class="row">
                            <img src='../admin/Car_Img/<%#Eval("CarImage") %>' style="width: 250px; height: 200px;" alt="" />
                        </div>

                        <div class="row"><%#Eval("CompanyName") %> / <%#Eval("ModelName")%> / <%#Eval("SubModelName") %></div>
                        <div class="row">Rent:<%#Eval("RentTypeName") %> </div>
                        <div class="row">Price: Rs.<%#Eval("CarPrice") %></div>
                        <div>
                            <button type="button" class="btn btn-outline waves-effect waves-light" style="background-color: black;">
                                <a style="color: white;" href='Booking.aspx?cid=<%#Eval("CarDetailsId") %>&CatId=1' class="button">Book Now</a>
                            </button>
                            <button type="button" class="btn btn-outline waves-effect waves-light" style="background-color: black;">
                                <a style="color: white;" href="Car_MemberDetails.aspx?Id=<%#Eval("CarDetailsId") %>" class="button">Read more</a>
                            </button>
                        </div>

                    </div>

                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>


            <asp:Repeater ID="RptHouseData" runat="server">
                <HeaderTemplate>
                    <div class="col-sm-12 ">
                        <center><h1>
                          <i class="fa fa-home"></i>
                          <b>House</b>
                          <i class="fa fa-home"></i>
                         </h1></center>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-sm-4" style="margin-top: 15px;">
                        <div class="row">
                            <img src='../admin/HouseImage/<%#Eval("Images") %>' style="width: 250px; height: 200px;" alt="" />
                        </div>

                        <div class="row">HouseNo/Name:<%#Eval("HouseNo") %></div>
                        <div class="row">House Type :<%#Eval("HouseTypeName") %></div>
                        <div class="row">Rent Type :<%#Eval("RentTypeName") %></div>
                        <div class="row">Price:Rs.<%#Eval("Price") %></div>
                        <div>
                            <button type="button" class="btn btn-outline waves-effect waves-light" style="background-color: black;">
                                <a style="color: white;" href="Booking.aspx?cid=<%#Eval("HouseId") %>&CatId=2" class="button">Book Now</a>
                            </button>
                            <button type="button" class="btn btn-outline waves-effect waves-light" style="background-color: black;">
                                <a style="color: white;" href="House_MemberDetails.aspx?Id=<%#Eval("HouseId") %>" class="button">Read more</a>
                            </button>
                        </div>
                    </div>

                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>


            <asp:Repeater ID="rptCameraData" runat="server">
                <HeaderTemplate>
                    <div class="col-sm-12 ">
                        <center><h1>
                          <i class="fa fa-camera"></i>
                          <b>Camera</b>
                          <i class="fa fa-camera"></i>
                         </h1></center>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-sm-4" style="margin-top: 15px;">
                        <div class="row">
                            <img src='../admin/Camera_Img/<%#Eval("Image") %>' style="width: 250px; height: 200px;" alt="" />
                        </div>

                        <div class="row">Company:<%#Eval("CompanyName") %></div>
                        <div class="row">Rent Type :<%#Eval("RentTypeName") %></div>
                        <div class="row">Price:Rs.<%#Eval("Price") %></div>
                        <div>
                            <button type="button" class="btn btn-outline waves-effect waves-light" style="background-color: black;">
                                <a style="color: white;" href="Booking.aspx?cid=<%#Eval("CameraId") %>&CatId=3" class="button">Book Now</a>
                            </button>
                            <button type="button" class="btn btn-outline waves-effect waves-light" style="background-color: black;">
                                <a style="color: white;" href="Camera_MemberDetails.aspx?Id=<%#Eval("CameraId") %>" class="button">Read more</a>
                            </button>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
