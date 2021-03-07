<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="My_Booking.aspx.cs" Inherits="RentSystem.Member.My_Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12" style="margin-top:25px;">
        <div class="row bg-title">

            <div class="col-lg-12">
                <h4 class="page-title">My Booking</h4>
                <ol class="breadcrumb">
                    <li><a href="Index.aspx">Dashboard</a></li>
                    <li class="active">My Booking</li>
                </ol>
            </div>
        </div>

        <asp:Repeater ID="rptBooking" runat="server">
            <HeaderTemplate>
                <tr>
                    <table class="table table-responsive table-bordered" style="color:white; box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                        <tr style="background-color: #b52e31;color:white;">
                           
                            <td><b>BookingNO</b></td>
                            <td>StartDate</td>
                            <td>EndDate</td>
                           <td>Category</td>
                            <td>Deposite Amount</td>
                            <td>Status</td>
                            <td>Action</td>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                   
                    <td>#BRS<%#Eval("BookingId") %></td>
                    <td><%#Eval("StartDate") %></td>
                    <td><%#Eval("EndDate") %></td>
                    <td><%#Eval("CategoryName") %></td>
                    <td><%#Eval("DepositeAmount") %></td>
                    <td><%#Eval("Status").ToString()=="0"?"Pending":"Completed" %></td>
                    <td><a href="bookingdetails.aspx?CType=<%#Eval("CategoryName") %>&CID=<%#Eval("CategoryId") %>">view</a></td>
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

