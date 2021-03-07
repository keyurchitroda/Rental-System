<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="cardetails.aspx.cs" Inherits="RentSystem.cardetails_aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12">
        <asp:Repeater runat="server" ID="rptcarDetails">
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
                                                    <img src='/admin/Car_Img/<%# Eval("CarImage") %>' data-imagezoom="true" style="width: 400px; height: 300px;" class="img-fluid" alt=" ">
                                                </div>

                                            </ul>
                                            <div class="clearfix" style="margin-left:150px;">
                                            
                                                 <a href="Login.aspx?cid=<%#Eval("CarDetailsId") %>" class="btn btn-primary btn-lg" style="width:150px;">Book Now</a>
                                            </div>

                                        </div>
                                    </div>
                                </div>

                                <div class="col-sm-7  text-left">
                                    <table class="table table-responsive " style="width: 400px; height: 350px; margin-left: 180px; margin-top: 90px; font-size: 20px;">

                                        <tr>
                                            <td colspan="2">
                                                <h4><%#Eval("CompanyName")%>/<%#Eval("ModelName")%>/<%#Eval("SubModelName")%></h4>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color: white">
                                                <b>Car No</b>
                                            </td>
                                            <td>
                                                <%#Eval("CarNo") %>
                                                
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color: white">
                                                <b>State</b>

                                            </td>
                                            <td>
                                                <%#Eval("StateName") %>
                                                
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="color: white">
                                                <b>City</b>
                                            </td>
                                            <td>
                                                <%#Eval("CityName") %>
                                                
                                            </td>
                                        </tr>
                                        <tr style="color: darkgreen;">
                                            <td>
                                                <b>Price</b>
                                            </td>
                                            <td>
                                               <%#Eval("CarPrice") %> (<%#Eval("RentTypeName") %>)
                                                    
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
            </div>
      
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>

