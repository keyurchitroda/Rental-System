<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="Camera_MemberDetails.aspx.cs" Inherits="RentSystem.Member.Camera_MemberDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">

    <div class="col-sm-12" style="margin-top:25px;">
        <asp:Repeater runat="server" ID="rptcameraDetails">
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
                                                    <img src='/admin/Camera_Img/<%# Eval("Image") %>' data-imagezoom="true" style="width: 420px; height: 350px;" class="img-fluid" alt=" ">
                                                </div>

                                            </ul>
                                            <div class="clearfix"></div>
                                            <div style="margin-left: 140px;">
                                                <button type="button" class="btn btn-outline waves-effect waves-light" style="width: 200px; background-color: black;">
                                                    <a href="Booking.aspx?cid=<%#Eval("CameraId") %>&CatId=3" style="color: white" class="button">Book Now</a>
                                                </button>

                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-sm-7  text-left">
                                    <table class="table table-responsive" style="width: 400px; height: 350px; margin-left: 180px; margin-top: 60px; font-size: 18px;">


                                        <tr>
                                            <td colspan="2">
                                                <h4><b><%#Eval("CompanyName")%>/<%#Eval("ModelName")%></b></h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="color:black;">
                                                <b>Owner Name</b>
                                            </td>
                                            <td>
                                                <%#Eval("Owner") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="color:black;">
                                                <b>Address</b>
                                            </td>
                                            <td>
                                                <%#Eval("Address") %>
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


                                        <tr style="color:blue;">
                                            <td>
                                                <b>Price</b> 
                                            </td>
                                            <td>
                                                <%#Eval("Price") %>(<%#Eval("RentTypeName") %>)
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
