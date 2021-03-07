<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="camera.aspx.cs" Inherits="RentSystem.admin.camera" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-sm-12 women_main">
        <asp:HiddenField ID="HidCamera" runat="server" />
        <asp:HiddenField ID="hidImageName" runat="server" />
        <div class="row">
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1><b>Camera Details</b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
        </div>
        <div class="col-sm-8 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
            <div class="row">
                <div class="row">
                    <div class="col-sm-3">
                        <label>Company Name</label>
                    </div>
                    <div class="col-sm-7">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlcompany" runat="server" OnTextChanged="ddlcompany_TextChanged" CssClass="form-control" Style="border-radius: 10px;" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Company Name" InitialValue="-Select Company-" CssClass="text-danger" ControlToValidate="ddlcompany"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <label>Model Name</label>
                    </div>
                    <div class="col-sm-7">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlmodel" runat="server" OnTextChanged="ddlmodel_TextChanged" CssClass="form-control" Style="border-radius: 10px;" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="-Select Model-" runat="server" ErrorMessage="Please Select Model Name" CssClass="text-danger" ControlToValidate="ddlmodel"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <label>SubModel Name</label>
                    </div>
                    <div class="col-sm-7">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlsubmodel" runat="server" CssClass="form-control" Style="border-radius: 10px;" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Select SubModel Name" CssClass="text-danger" InitialValue="-Select SubModel-" ControlToValidate="ddlsubmodel"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>


                <div class="row">
                    <div class="col-sm-3">
                        <label>RentType </label>
                    </div>
                    <div class="col-sm-7">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlrenttype" runat="server" CssClass="form-control" Style="border-radius: 10px;" AutoPostBack="true"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Rent Type" InitialValue="-Select RentType-" CssClass="text-danger" ControlToValidate="ddlrenttype"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <label>Owner</label>
                    </div>
                    <div class="col-sm-7">
                        <asp:TextBox ID="txtOwner" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Insert Owner" CssClass="text-danger" ControlToValidate="txtOwner"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <label>Mobile</label>
                    </div>
                    <div class="col-sm-7">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Insert Mobile" CssClass="text-danger" ControlToValidate="txtMobile"></asp:RequiredFieldValidator>
                    </div>

                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <label>Address</label>
                    </div>
                    <div class="col-sm-7">
                        <asp:TextBox ID="txtxAddress" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Insert Address" CssClass="text-danger" ControlToValidate="txtxAddress"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-3">
                        <label>Price</label>
                    </div>
                    <div class="col-sm-7">
                        <asp:TextBox ID="txtprice" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Insert Price" CssClass="text-danger" ControlToValidate="txtprice"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col-cm-3">
                        <label>Image</label>
                    </div>
                    <div class="col-sm-3">
                        <div class="col-sm-4">
                            <asp:FileUpload ID="fpCameraImages" runat="server" AllowMultiple="false" />

                            <br />
                            <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" CssClass="btn btn-primary" Style="border-radius: 20px;" OnClick="btnsubmit_Click" />
                        </div>
                        <div class="col-sm-2">
                            <div class="row">
                                <div class="imgHolder" style="margin-left: 215px;">
                                    <img id="imgFullSizePreview" src="assets/img/NoImages.png" class="bimg-150" />
                                    <div class="imageBoxPad">
                                        <input type="button" class="btn btn-danger removeImg" onclick="RemoveImage();" value="X" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <asp:Label ID="lblduplicate" runat="server" Text="Please check duplicate" CssClass="text text-danger" Visible="false"></asp:Label>
                        </div>

                    </div>
                </div>

            </div>
        </div>
        <div class="row" style="margin-right: 100px;">
            <div class="col-md-12">
                <div class="white-box">
                    <div class="row">

                        <div class="row" style="box-shadow: 2px 2px 2px 2px; padding: 10px; margin: 5px;">

                            <div class="col-md-2" style="margin-top: 5px;">
                                <asp:DropDownList runat="server" ID="cboPageSize" Style="background-color: aliceblue; color: black" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboPageSize_SelectedIndexChanged">

                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="15">15</asp:ListItem>
                                    <asp:ListItem Value="25">25</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3" style="margin-top: 5px;">
                                <div class="text-left">
                                    <asp:Literal ID="ltrRecordFound" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="col-sm-1" style="margin-top: 5px;">
                                <label>Search</label>
                            </div>
                            <div class="col-sm-4" style="margin-top: 5px;">
                                <asp:TextBox ID="Tsearch" runat="server" CssClass="form-control" Style="border-radius: 20px; background-color: aliceblue; color: black"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btnsearch" CausesValidation="false" runat="server" OnClick="btnsearch_Click1" CssClass="btn btn-primary" Style="border-radius: 20px" Text="Search" /><br />
                            </div>

                            <div class="row">
                                <div class="text-right p-b-10" style="margin-right: 60px; margin-top: 50px; margin-bottom: 10px;">
                                    <asp:Repeater ID="rptPager" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton CausesValidation="false" ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "btn btn-primary btn-sm" : "btn btn-default btn-sm" %>'
                                                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>

            </div>
        </div>


        <div class="row">
            <asp:Repeater ID="rptcameraInfo" runat="server" OnItemCommand="rptcameraInfo_ItemCommand2">
                <HeaderTemplate>
                    <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                        <tr style="background-color: #b52e31;">
                            <th>Owner Name</th>
                            <th>Owner Mobile No</th>
                            <th>Owner Address</th>
                            <th>Price</th>
                            <th>Image</th>
                            <th>Status</th>
                            <th>Action</th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: white;">

                        <td><%#Eval("Owner") %></td>
                        <td><%#Eval("MobileNo") %></td>
                        <td><%#Eval("Address") %></td>
                        <td><%#Eval("Price") %></td>
                        <td>
                            <a href="cam_det.aspx?Id=<%#Eval("CameraId") %>" class="btn btn-primary">
                                <img src='../admin/Camera_Img/<%#Eval("Image") %>' style="width: 100px;" /></a>
                        </td>
                        <td><%#Eval("Status") %></td>
                        <td>
                            <asp:LinkButton ID="lnkedit" runat="server" CommandName="edit" ToolTip="Edit" CommandArgument='<%#Eval("CameraId") %>' CssClass="btn btn-primary" CausesValidation="false"><i class="fa fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton ID="lnkstatus" runat="server" CommandName="status" ToolTip="status" CommandArgument='<%#Eval("CameraId") %>' CssClass="btn btn-success" CausesValidation="false"><i class="fa fa-anchor"></i></asp:LinkButton>
                        </td>
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
    <script type="text/javascript">
        $(document).ready(function () {
            alert('hi')
        });

        if ($('#<%=hidImageName.ClientID%>').val() != "") {
            $('#imgFullSizePreview').attr('src', 'Camera_Img/' + $('#<%=hidImageName.ClientID%>').val());
        }

        $('#<%=fpCameraImages.ClientID %>').change(function () {
            var fileName = $('#<%=fpCameraImages.ClientID%>').val();
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
            $('#<%=fpCameraImages.ClientID%>').val("");
        }
    </script>

</asp:Content>
