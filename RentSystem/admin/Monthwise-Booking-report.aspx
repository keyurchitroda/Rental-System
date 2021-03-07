<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="Monthwise-Booking-report.aspx.cs" Inherits="RentSystem.admin.Monthwise_Booking_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12">
        <div class="row">
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1><b>Monthwise Booking</b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
             <input type="submit" class="btn btn-primary" onclick="funprint();" value="Print Report" />
        </div>
        <div class="col-sm-12" style="margin-bottom:20px;">
            <div class="col-sm-1" style="margin-left: 150px;">
                Month
            </div>

            <div class="col-sm-4">
                <asp:DropDownList ID="ddlmonth" runat="server" CssClass="form-control">
                    <asp:ListItem Value="1">January</asp:ListItem>
                    <asp:ListItem Value="2">February</asp:ListItem>
                    <asp:ListItem Value="3">March</asp:ListItem>
                    <asp:ListItem Value="4">April</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">August</asp:ListItem>
                    <asp:ListItem Value="9">September</asp:ListItem>
                    <asp:ListItem Value="10">Octomber</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
        </div>
        <div class="col-sm-12">
            <asp:Label ID="ltrMsg" Visible="false" runat="server"></asp:Label>
        </div>
        <asp:Repeater ID="rptreport" runat="server">
            <HeaderTemplate>
                <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); margin-left: 20px;">
                    <tr style="background-color: #b52e31;">
                        <td><b>View</b></td>
                        <td><b>User Name</b></td>
                        <td><b>User MobileNo</b></td>
                        <td><b>CategoryName</b></td>
                        <td><b>BookingDate</b></td>
                        <td><b>StartDate</b></td>
                        <td><b>EndDate</b></td>
                        <td><b>DepositeAmount</b></td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><a href="adminbookingdetails.aspx?CType=<%#Eval("CategoryName") %>&CID=<%#Eval("CategoryId") %>">view</a></td>
                    <td><%#Eval("FirstName")+" "+Eval("LastName") %></td>
                    <td><%#Eval("Mobile") %></td>
                    <td><%#Eval("CategoryName") %></td>
                    <td><%#Eval("BookingDate") %></td>
                    <td><%#Eval("StartDate") %></td>
                    <td><%#Eval("EndDate") %></td>
                    <td><%#Eval("DepositeAmount") %></td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
     <script type="text/javascript">
        function funprint() {
            window.print();
        }
    </script>
</asp:Content>
