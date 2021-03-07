<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change-Password.aspx.cs" Inherits="RentSystem.admin.Change_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="css/font-awesome.css" rel="stylesheet">
    <!-- jQuery -->
    <link href='//fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css' />
    <link href='//fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'>
    <!-- lined-icons -->
    <link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
    <script src="js/simpleCart.min.js"> </script>
    <script src="js/amcharts.js"></script>
    <script src="js/serial.js"></script>
    <script src="js/light.js"></script>
    <!-- //lined-icons -->
    <script src="js/jquery-1.10.2.min.js"></script>
    <!--pie-chart--->
    <script src="js/pie-chart.js" type="text/javascript"></script>
    <script type="text/javascript">


        $(document).ready(function () {
            $('#demo-pie-1').pieChart({
                barColor: '#3bb2d0',
                trackColor: '#eee',
                lineCap: 'round',
                lineWidth: 8,
                onStep: function (from, to, percent) {
                    $(this.element).find('.pie-value').text(Math.round(percent) + '%');
                }
            });

            $('#demo-pie-2').pieChart({
                barColor: '#fbb03b',
                trackColor: '#eee',
                lineCap: 'butt',
                lineWidth: 8,
                onStep: function (from, to, percent) {
                    $(this.element).find('.pie-value').text(Math.round(percent) + '%');
                }
            });

            $('#demo-pie-3').pieChart({
                barColor: '#ed6498',
                trackColor: '#eee',
                lineCap: 'square',
                lineWidth: 8,
                onStep: function (from, to, percent) {
                    $(this.element).find('.pie-value').text(Math.round(percent) + '%');
                }
            });


        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="col-sm-12" style="margin-top:100px;">
            <div class="col-sm-6" style="margin: 50px; margin-left: 310px; box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <div class="row" style="background-color: silver; font-size: 30px; color: black; text-align: center; margin-top: 10px;">
                        <span>Change Password</span>
                    </div>
                    <div class="row" style="margin-top: 10px;">
                        <label><b>Old Password</b></label>
                        <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ErrorMessage="Please Insert Old Password" Style="color: black" ControlToValidate="txtOldPass"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row">
                        <label><b>New Password</b></label>
                        <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="Please Insert New Password" Style="color: black" ControlToValidate="txtNewPass"></asp:RequiredFieldValidator>
                    </div>
                    <div class="row">
                        <label><b>Confirm Password</b></label>
                        <asp:TextBox ID="txtConPass" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ErrorMessage="Please Insert Confirm Password" Style="color: black" ControlToValidate="txtConPass"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" ControlToCompare="txtNewPass" ControlToValidate="txtConPass" style="color:red" Display="Dynamic" runat="server" ErrorMessage="Check Confirm Password With New Password">

                    </asp:CompareValidator>

                    </div>
                    <div class="row" style="margin: 10px;">
                        <center><asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-lg" OnClick="btnSubmit_Click"  Text="Change" runat="server" />
                    </center>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
