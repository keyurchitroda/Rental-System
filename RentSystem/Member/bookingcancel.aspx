<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="bookingcancel.aspx.cs" Inherits="RentSystem.Member.bookingcancel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <style>
        .women_main {
            -webkit-box-shadow: 0px 0px 2px 1px rgba(37, 37, 37, 0.39);
            box-shadow: 0px 0px 2px 1px rgba(37, 37, 37, 0.39);
            padding: 1em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12" style="margin-top: 25px;">
        <div class="row bg-title">

            <div class="col-lg-12">
                <h4 class="page-title">Booking Cancel</h4>
                <ol class="breadcrumb">
                    <li><a href="Index.aspx">Dashboard</a></li>
                    <li><a href="My_Booking.aspx">My Booking</a></li>
                    <li><a href="bookingdetails.aspx">View BookingDetails</a></li>
                    <li class="active">Booking Cancel</li>
                </ol>
            </div>
        </div>

        <div class="col-sm-9 women_main" style="margin-top: 10px; margin-bottom: 50px; margin-left: 140px; background-color: gainsboro;">
            <div class="col-sm-7" style="margin-top: 20px; margin-left: 160px;">
                <div class="col-sm-12" style="margin-top: 10px;">

                    <div class="col-sm-4" style="color: black">
                        <b>Bank Name</b>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtbankname" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert Bankname" ControlToValidate="txtbankname" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-sm-12" style="margin-top: 5px;">
                    <div class="col-sm-4" style="color: black">
                        <b>IFSC Code</b>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtIFSCcode" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert IFSC code" ControlToValidate="txtIFSCcode" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-sm-12" style="margin-top: 5px;">
                    <div class="col-sm-4" style="color: black">
                        <b>Holder Name</b>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtholdername" runat="server" CssClass="form-control"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Insert Holder name" ControlToValidate="txtholdername" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                </div>
                <div class="col-sm-12" style="margin-top: 5px;">
                    <div class="col-sm-4" style="color: black">
                        <b>A/C NO</b>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtaccountNo" runat="server" CssClass="form-control" MaxLength="16"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Insert Account No" ControlToValidate="txtaccountNo" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-sm-12" style="margin-top: 5px;">
                    <div class="col-sm-4" style="color: black">
                        <b>Amount</b>
                    </div>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtamount" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-12" style="margin-top: 15px;">
                    <div class="col-sm-10" style="margin-left: 90px; word-spacing: 15px;">
                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-success" Text="Booking Cancel" OnClick="btnsubmit_Click" />

                        <%-- <div class="col-sm-4" style="margin-left: 150px;">--%>
                        <asp:Button ID="btncancel" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btncancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
