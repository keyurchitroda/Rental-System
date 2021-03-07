<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="camera.aspx.cs" Inherits="RentSystem.camera" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12">
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
                                                        <img src='/admin/Camera_Img/<%# Eval("Image") %>' data-imagezoom="true" style="width: 450px; height: 350px;" class="img-fluid" alt=" ">
                                                    </div>
                                            
                                            </ul>
                                            <div class="clearfix" style="margin-left:170px;">
                                            
                                                 <a href="Login.aspx?cid=<%#Eval("CameraId") %>" class="btn btn-primary btn-lg" style="width:150px;">Book Now</a>
                                                 <a href="CameraDocument.aspx?cid=<%#Eval("CompanyId") %>" class="btn btn-primary btn-lg" style="width:150px;">Document</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="col-sm-7  text-left">
                                    <table class="table table-responsive " style="width: 400px; height: 350px; margin-left: 180px; margin-top: 90px; font-size: 20px;">

                                        <tr>
                                            <td style="color:white;">
                                                <b>Company</b>
                                            </td>
                                            <td>
                                                <%#Eval("CompanyName") %>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="color:white;">
                                                <b>Model</b>
                                            </td>
                                            <td>
                                                <%#Eval("ModelName") %>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td style="color:white;">
                                                <b>SubModel</b>
                                            </td>
                                            <td>
                                                <%#Eval("SubModelName") %>
                                            </td>
                                        </tr>--%>
                                        <tr style="color:darkgreen;">
                                            <td>
                                                Price 
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
            </div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
