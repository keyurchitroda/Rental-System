<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="HouseDocument.aspx.cs" Inherits="RentSystem.HouseDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div>
        <div class="col-sm-12 ">
            <asp:Repeater runat="server" ID="rptDoc">
                <HeaderTemplate>
                    <div style="font-size: 20px; color: white; margin-left: 700px;">
                        <b>House Document</b>
                    </div>
                    
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
                                                    <img src='admin/HouseDoc_Img/<%#Eval("Images") %>' data-imagezoom="true" style="width: 450px; height: 350px;" class="img-fluid" alt=" ">
                                                </div>

                                            </ul>
                                           
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                   
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
