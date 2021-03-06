<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="RentSystem.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
     <style>
        .divs {
            width: 150px;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="body2">

        <div class="main">
             <div class="col-sm-12">
                        <asp:Label ID="ltrMsg" runat="server" CssClass="text-danger"></asp:Label>
                    </div>
            <asp:Repeater ID="rptCarData" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>                   
                    <div class="col-sm-4" style="margin-top: 15px;">
                        <div class="row">
                            <a href="cardetails.aspx?Id=<%#Eval("CarDetailsId") %>">
                                <img src='admin/Car_Img/<%#Eval("CarImage") %>' style="width: 250px; height: 200px;" alt="" />
                            </a>
                        </div>

                        <div class="row"><%#Eval("CompanyName") %></div>
                         <div class="row"><%#Eval("ModelName") %></div>
                         <div class="row"><%#Eval("SubModelName") %></div>
                        <div class="row">Rent:<%#Eval("RentTypeName") %> </div>
                        <div class="row">Price: Rs.<%#Eval("CarPrice") %></div>
                        <div>
                            <a href="Login.aspx?cid=<%#Eval("CarDetailsId") %>" class="button">Book Now</a>
                            <a href="cardetails.aspx?Id=<%#Eval("CarDetailsId") %>" class="button">Read more</a>
                        </div>

                    </div>

                </ItemTemplate>
                <FooterTemplate></FooterTemplate>
            </asp:Repeater>


            <asp:Repeater ID="RptHouseData" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-sm-4" style="margin-top: 15px;">
                        <div class="row">
                            <a href="housedetails.aspx?Id=<%#Eval("HouseId") %>">
                                <img src='admin/HouseImage/<%#Eval("Images") %>' style="width: 250px; height: 200px;" alt="" />
                            </a>
                        </div>

                        <div class="row">HouseNo/Name:<%#Eval("HouseNo") %></div>
                        <div class="row">State:<%#Eval("StateName") %></div>
                        <div class="row">City:<%#Eval("CityName") %></div>
                        <div class="row">Area:<%#Eval("AreaName") %></div>
                        <div class="row">House Type :<%#Eval("HouseTypeName") %></div>
                        <div class="row">Rent Type :<%#Eval("RentTypeName") %></div>
                        <div class="row">Price:<%#Eval("Price") %></div>
                        <div>
                            <a href="Login.aspx?cid=<%#Eval("HouseId") %>" class="button">Book Now</a>
                            <a href="housedetails.aspx?Id=<%#Eval("HouseId") %>" class="button">Read more</a>
                        </div>
                    </div>

                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>


            <asp:Repeater ID="rptCameraData" runat="server">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-sm-4" style="margin-top: 15px;">
                        <div class="row">
                            <a href="camera.aspx?Id=<%#Eval("CameraId") %>">
                                <img src='admin/Camera_Img/<%#Eval("Image") %>' style="width: 250px; height: 200px;" alt="" />
                            </a>
                        </div>

                      
                        <div class="row">Company:<%#Eval("CompanyName") %></div>
                        <div class="row">Company:<%#Eval("ModelName") %></div>
                       <div class="row">Company:<%#Eval("SubModelName") %></div>
                        <div class="row">Rent Type :<%#Eval("RentTypeName") %></div>
                        <div class="row">Price: <%#Eval("Price") %></div>
                        <div>
                            <a href="Login.aspx?cid=<%#Eval("CameraId") %>" class="button">Book Now</a>
                            <a href="camera.aspx?Id=<%#Eval("CameraId") %>" class="button">Read more</a>
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
