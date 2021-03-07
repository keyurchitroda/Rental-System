<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="RentSystem.Member.Booking" %>

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
    <div style="margin-top:35px;">
    <div class="row">
        <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
            <center><h1><b>Booking</b></h1></center>
            <hr />
        </div>
    </div>
    <div class="col-sm-12 women_main" style="margin-top: 10px; margin-bottom: 50px; background-color: gainsboro;">
        <div class="col-sm-7" style="margin-top: 20px; margin-left: 200px;">
            <div class="col-sm-12" style="margin-top: 10px;">
                <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="false"></asp:Label>
                <div class="col-sm-4" style="color: black">
                    <b>User Name</b>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="UserName" runat="server" ReadOnly="true" Text="UN" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="col-sm-12" style="margin-top: 5px;">

                <div class="col-sm-4" style="color: black">
                    <b>Category Name</b>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="CName" runat="server" ReadOnly="true" Text="C" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="col-sm-12" style="margin-top: 5px;">

                <div class="col-sm-4" style="color: black;">
                    <b>Start Date</b>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtstartdate" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic"   runat="server" ControlToValidate="txtstartdate" ErrorMessage="Please Enter StartDate" CssClass="text-danger" Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-sm-12" style="margin-top: 5px;">
                <div class="col-sm-4" style="color: black">
                    <b>End Date</b>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtenddate" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="txtenddate" ErrorMessage="Please Enter EndDate" CssClass="text-danger" Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-sm-12" style=" margin-top: 5px;">

                <div class="col-sm-4" style="color: black">
                    <b>Deposite Amount</b>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtdepamount" runat="server" ReadOnly="true" Text="1000" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="col-sm-12" style="margin-top: 5px;">

                <div class="col-sm-4" style="color: black;">

                    <b>Card No</b>
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtcardno1" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ControlToValidate="txtcardno1" ErrorMessage="Please enter CardNo" CssClass="text-danger" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Enter Valid CardNo" ControlToValidate="txtcardno1" CssClass="text-danger" Style="padding-top: 10px;" ValidationExpression="\d{4}" Display="Dynamic"></asp:RegularExpressionValidator>
                    &nbsp;
                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtcardno2" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" runat="server" ControlToValidate="txtcardno2" ErrorMessage="Please enter CardNo" CssClass="text-danger" Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter Valid CardNo" ControlToValidate="txtcardno2" CssClass="text-danger" Display="Dynamic" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>

                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtcardno3" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" runat="server" ControlToValidate="txtcardno3" ErrorMessage="Please enter CardNo" CssClass="text-danger" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Please Enter Valid CardNo" ControlToValidate="txtcardno3" CssClass="text-danger" Display="Dynamic" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>

                </div>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtcardno4" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Display="Dynamic" runat="server" ControlToValidate="txtcardno4" ErrorMessage="Please enter CardNo" CssClass="text-danger" Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic" ErrorMessage="Please Enter Valid CardNo" ControlToValidate="txtcardno4" CssClass="text-danger" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>

                </div>
            </div>

            <div class="col-sm-12" >

                <div class="col-sm-4" style="color: black">
                    <b>Expiry Date</b>
                </div>
                <div class="col-sm-4">
                    <asp:DropDownList ID="ddlmonth" runat="server">
                        <asp:ListItem Value="1">01</asp:ListItem>
                        <asp:ListItem Value="2">02</asp:ListItem>
                        <asp:ListItem Value="3">03</asp:ListItem>
                        <asp:ListItem Value="4">04</asp:ListItem>
                        <asp:ListItem Value="5">05</asp:ListItem>
                        <asp:ListItem Value="6">06</asp:ListItem>
                        <asp:ListItem Value="7">07</asp:ListItem>
                        <asp:ListItem Value="8">08</asp:ListItem>
                        <asp:ListItem Value="9">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                    </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" runat="server" ControlToValidate="txtcardno1" ErrorMessage="Please enter CardNo" CssClass="text-danger" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>                   
                    &nbsp;
                </div>
                <div class="col-sm-4">
                   <asp:DropDownList ID="ddlyear" runat="server">
                        <asp:ListItem Value="1">2019</asp:ListItem>
                        <asp:ListItem Value="2">2020</asp:ListItem>
                        <asp:ListItem Value="3">2021</asp:ListItem>
                        <asp:ListItem Value="4">2022</asp:ListItem>
                        <asp:ListItem Value="5">2023</asp:ListItem>
                        <asp:ListItem Value="6">2024</asp:ListItem>
                        <asp:ListItem Value="7">2025</asp:ListItem>
                        <asp:ListItem Value="8">2026</asp:ListItem>
                        <asp:ListItem Value="9">2027</asp:ListItem>
                        <asp:ListItem Value="10">2028</asp:ListItem>
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server" ControlToValidate="txtcardno2" ErrorMessage="Please enter CardNo" CssClass="text-danger" Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>

                </div>
               <%-- <div class="col-sm-8">
                    <asp:TextBox ID="txtexpirydate" runat="server" CssClass="form-control"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ControlToValidate="txtexpirydate" ErrorMessage="Please Enter Expiry Date" CssClass="text-danger" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                </div>--%>
            </div>

            <div class="col-sm-12" style="margin-top: 5px;">

                <div class="col-sm-4" style="color: black">
                    <b>CVV</b>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtcvv" runat="server" CssClass="form-control" MaxLength="3"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="txtcvv" ErrorMessage="Please Enter CVV No" CssClass="text-danger" Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" runat="server" ErrorMessage="Please Enter Valid CVV" ControlToValidate="txtcvv" CssClass="text-danger" ValidationExpression="\d{3}"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="col-sm-12" style="margin-top: 5px;">

                <div class="col-sm-4" style="color: black">
                    <b>CardOwner Name</b>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtcardowner" runat="server" CssClass="form-control"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" runat="server" ControlToValidate="txtcardowner" ErrorMessage="Please Enter Card Owner Name" CssClass="text-danger" Text="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-sm-3" style="margin-bottom: 15px; margin-left: 210px;margin-top: 10px;"">
                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click" />
            </div>

        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.min.js"></script>
    <script src="js/moment.js"></script>
    <script src="js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript">
        $(function () {


            $('#<%=txtstartdate.ClientID%>').datetimepicker
                ({
                    format: 'DD/MM/YYYY',
                    minDate: new Date(),
                });
            $('#<%=txtenddate.ClientID%>').datetimepicker
                ({
                    format: 'DD/MM/YYYY',
                    minDate: new Date(),
                });
           <%-- $('#<%=txtexpirydate.ClientID%>').datetimepicker
                ({
                    format: 'DD/MM/YYYY',
                    minDate: new Date(),
                });--%>

        });



    </script>
</asp:Content>
