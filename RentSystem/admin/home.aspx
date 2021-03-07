<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="RentSystem.admin.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
    <meta http-equiv="refresh" content="30" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <script language="javascript">
        setTimeout(function () {
            window.location.reload(1);
        }, 30000);
    </script>
    <div>

        <h3>WelCome Rental System</h3>
        <div class="row">
            <div class="col-sm-3">
                <div class="row" style="background-color:burlywood; text-align: center; color: white; height: 20px">
                    <a href="Totalbooking.aspx">Total Booking</a>

                </div>
                <div class="row" style="height: 100px; font-weight: 500; background-color: burlywood; color: white; text-align: center;">
                    <asp:Label ID="lblTotalbooking" runat="server" CssClass="fa-2x"></asp:Label>
                </div>
            </div>

            <div class="col-sm-3" style="margin-left: 10px;">
                <div class="row" style="background-color: orange; text-align: center; color: white; height: 20px">
                    <a href="Today-Booking-report.aspx">ToDay Booking</a>

                </div>
                <div class="row" style="height: 100px; background-color: orange; color: white; text-align: center;">
                    <asp:Label ID="lblTodaybooking" runat="server" CssClass="fa-2x"></asp:Label>
                </div>
            </div>

            <div class="col-sm-3" style="margin-left: 10px;">
                <div class="row" style="background-color: darkgray; text-align: center; color: white; height: 20px">
                    <a href="Monthwise-Booking-report.aspx" style="color: white;">Monthwise Booking</a>

                </div>
                <div class="row" style="height: 100px; background-color: darkgrey; color: white; text-align: center;">
                    <asp:Label ID="lblmonthwise" runat="server" CssClass="fa-2x"></asp:Label>
                </div>
            </div>

            <div class="col-sm-3" style="margin-left: 10px; margin-top: 10px;">
                <div class="row" style="background-color:chocolate; text-align: center; color: white; height: 20px">
                    <a href="TotalUser.aspx" style="color: white;">Total User</a>

                </div>
                <div class="row" style="height: 100px; background-color: chocolate; color: white; text-align: center;">
                    <asp:Label ID="lbltotaluser" runat="server" CssClass="fa-2x"></asp:Label>
                </div>
            </div>

            <div class="col-sm-3" style="margin-left: 10px; margin-top: 10px;">
                <div class="row" style="background-color: brown; text-align: center; color: white; height: 20px">
                    <a href="TodayUser.aspx" style="color: white;">ToDay User</a>

                </div>
                <div class="row" style="height: 100px; background-color: brown; color: white; text-align: center;">
                    <asp:Label ID="lbltodayuser" runat="server" CssClass="fa-2x"></asp:Label>
                </div>
            </div>
           <%-- <div class="col-sm-3" style="margin-left: 10px; margin-top: 10px;">
                <div class="row" style="background-color:darksalmon; text-align: center; color: white; height: 20px">
                    <a href="Datewise-report.aspx" style="color: white;">Datewise Booking</a>

                </div>
                <div class="row" style="height: 100px; background-color: darksalmon; color: white; text-align: center;">
                    <asp:Label ID="lblDatewise" runat="server" CssClass="fa-2x"></asp:Label>
                </div>
            </div>--%>
            <div class="col-sm-3" style="margin-left: 10px; margin-top: 10px;">
                <div class="row" style="background-color:cadetblue; text-align: center; color: white; height: 20px">
                    <a href="BookingCancel-report.aspx" style="color: white;">Booking Cancel</a>

                </div>
                <div class="row" style="height: 100px; background-color: cadetblue; color: white; text-align: center;">
                    <asp:Label ID="lblBookingCancel" runat="server" CssClass="fa-2x"></asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
