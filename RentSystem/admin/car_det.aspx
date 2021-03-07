<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="car_det.aspx.cs" Inherits="RentSystem.admin.car_det" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
    <style>
        .imgHolder {
            position: relative;
            display: block;
        }

        .bimg-150 {
            background-repeat: no-repeat;
            width: auto;
            height: 150px;
            background-size: 100% 100%;
            box-shadow: 0 0 2px 2px #c2c2c2;
            border-radius: 5px;
        }

        .bimg-80 {
            background-repeat: no-repeat;
            width: auto;
            height: 80px;
            background-size: 100% 100%;
            box-shadow: 0 0 2px 2px #c2c2c2;
            border-radius: 5px;
        }

        .imgHolder .imageBoxPad {
            position: absolute;
            left: 5px;
            bottom: 5px;
            padding: 1% 1%;
        }

            .imgHolder .imageBoxPad .removeImg {
                position: relative;
                width: 18px;
                height: 18px;
                padding: 0px;
                font-weight: bold;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12 women_main">
        <asp:Repeater runat="server" ID="rptImage">
            <HeaderTemplate>
                <div class="row">
                    <div class="col-sm-4" style="padding-top: 5px;">
                        <div class="row">
                            <div class="imgHolder" style="margin-left: 215px;">
            </HeaderTemplate>
            <ItemTemplate>
                <img src='Car_Img/<%#Eval("CarImage") %>' style="width: 250px; height: 200px;" />
            </ItemTemplate>
            <FooterTemplate>
                </div>
                </div>
            </div>
            </div>
            </FooterTemplate>
        </asp:Repeater>
        <div class="row">
            <asp:Repeater ID="rptCarDetailsInfo" runat="server">
                <HeaderTemplate>
                    <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                        <tr style="background-color: #b52e31;">
                            <th>Company Name</th>
                            <th>Model Name</th>
                            <th>SubModel Name</th>
                            <th>CarReg No</th>
                            <th>State</th>
                            <th>City</th>
                            <th>Owner Address </th>
                            <th>Price</th>
                            <th>Rent Type</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: white;">
                        <td><%#Eval("CompanyName") %></td>
                        <td><%#Eval("ModelName") %></td>
                        <td><%#Eval("SubModelName") %></td>
                        <td><%#Eval("CarRegNo") %></td>
                        <td><%#Eval("StateName") %></td>
                        <td><%#Eval("CityName") %></td>
                        <td><%#Eval("CarOwnerAddress") %></td>
                        <td><%#Eval("CarPrice") %></td>
                        <td><%#Eval("RentTypeName") %></td>

                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <%--<script type="text/javascript">
        $(document).ready(function () {
            //alert('hi')
        });

        $('#<%=imgHolder.ClientID %>').change(function () {
            var fileName = $('#<%=imgHolder.ClientID%>').val();
            if (fileName) {
                readURL(this);
            }
            else {
                $('#imgFullSizePreview').attr('src', 'assets/img/NoImages.png');
            }
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgFullSizePreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
            else {
                $('#imgFullSizePreview').attr('src', 'assets/img/NoImages.png');
            }
        }

        function RemoveImage() {
            $('#imgFullSizePreview').attr('src', 'assets/img/NoImages.png');
            $('#<%=CarImages.ClientID%>').val("");
        }
    </script>--%>
</asp:Content>
