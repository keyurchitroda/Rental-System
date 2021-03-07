<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="Totalbooking.aspx.cs" Inherits="RentSystem.admin.Totalbooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
     <div class="col-sm-12" >
         <div class="row">
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1><b>Total Booking</b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
               <input type="submit" class="btn btn-primary" onclick="funprint();" value="Print Report" />
        </div>
        <asp:Repeater ID="rptreport" runat="server">
            <HeaderTemplate>
                <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); margin-left: 20px;">
                    <tr style="background-color: #b52e31;">
                        <td><b>View</b></td>
                        <td><b>User Name</b></td>
                        <td><b>User Mobile No</b></td>
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
