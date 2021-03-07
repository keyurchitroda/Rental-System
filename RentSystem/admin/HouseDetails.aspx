<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="HouseDetails.aspx.cs" Inherits="RentSystem.admin.housedetails" %>

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
            box-shadow: 0 0 2px 2px #C2C2C2;
            border-radius: 5px;
        }

        .bimg-80 {
            background-repeat: no-repeat;
            width: auto;
            height: 80px;
            background-size: 100% 100%;
            box-shadow: 0 0 2px 2px #C2C2C2;
            border-radius: 5px;
        }

        .imgHolder.imageBoxPad {
            position: absolute;
            left: 5px;
            bottom: 5px;
            padding: 1% 1%;
        }

            .imgHolder.imageBoxPad.removeImg {
                position: relative;
                width: 18px;
                height: 18px;
                padding: 0px;
                font-weight: bold;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12 women_main" >
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1><b>HouseDetails</b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
        </div>
        <div class="col-sm-6 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
            <div class="col-sm-12">
                <asp:HiddenField ID="Hidhouse" runat="server" />
                <asp:HiddenField ID="HidImage" runat="server" />
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">HouseNo/Name</label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txthouseno" runat="server" CssClass="form-control" Style="border-radius: 10px; margin-left: 15px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Insert HouseNo/Name" CssClass="text-danger" ControlToValidate="txthouseno"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-12">

                <div class="col-sm-4">
                    <label style="margin-left: 15px;">HouseOwner</label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txthouse" runat="server" CssClass="form-control" Style="border-radius: 10px; margin-left: 15px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert HouseOwner" CssClass="text-danger" ControlToValidate="txthouse"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">HouseAddress</label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txthouseaddr" runat="server" CssClass="form-control" Style="border-radius: 10px; margin-left: 15px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert HouseAddress" CssClass="text-danger" ControlToValidate="txthouseaddr"></asp:RequiredFieldValidator>
                </div>
            </div>

             <div class="col-sm-12">
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">Mobile</label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" Style="border-radius: 10px; margin-left: 15px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Insert Mobile" CssClass="text-danger" ControlToValidate="txtmobile"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">State</label>
                </div>
                <div class="col-sm-8">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlState" CssClass="form-control" OnTextChanged="ddlState_TextChanged" Style="border-radius: 10px; margin-left: 15px;"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select State" InitialValue="-Select State-" CssClass="text-danger" ControlToValidate="ddlState"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">City</label>
                </div>
                <div class="col-sm-8">

                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlCity" CssClass="form-control" OnTextChanged="ddlCity_TextChanged" Style="border-radius: 10px; margin-left: 15px;"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Insert City" CssClass="text-danger" InitialValue="-Select city-" ControlToValidate="ddlCity"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">Area</label>
                </div>
                <div class="col-sm-8">

                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlArea" CssClass="form-control" Style="border-radius: 10px; margin-left: 15px;"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue=" -Select Area-" runat="server" ErrorMessage="Please Insert Area" CssClass="text-danger" ControlToValidate="ddlArea"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">HouseType</label>
                </div>
                <div class="col-sm-8">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlhousetype" AutoPostBack="true" CssClass="form-control" Style="border-radius: 10px; margin-left: 15px;" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select HouseType" InitialValue="-Select HouseType-" CssClass="text-danger" ControlToValidate="ddlhousetype"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label>HouseImage</label>
                </div>
                <div class="col-sm-8">
                    <asp:FileUpload ID="HouseImages" runat="server" AllowMultiple="false" />
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Insert HouseImage" CssClass="text-danger" ControlToValidate="HouseImages"></asp:RequiredFieldValidator>--%>
                </div>
                <div class="col-sm-6" style="padding-top: 5px;">
                    <div class="imgHolder" style="margin-left:250px;">
                        <img id="imgFullSizePreview" src="assets/img/NoImages.png" class="bimg-150" />
                        <div class="imageBoxPad">
                            <input type="button" class="btn btn-danger removeImg" onclick="RemoveImage();" value="X" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="col-sm-2" style="margin-left:180px;">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" CssClass="btn btn-primary" />
                </div>
                <div>
                        <asp:Label ID="lblduplicate" runat="server" Text="Please check duplicate" CssClass="text text-danger" Visible="false"></asp:Label>
                    </div>

            </div>

        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="white-box">
                    <div class="row" style="box-shadow: 2px 2px 2px 2px; padding: 10px; margin: 5px;">
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" ID="cboPageSize" Style="background-color: aliceblue; color: black" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboPageSize_SelectedIndexChanged">

                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="25">25</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                                <asp:ListItem Value="100">100</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <div class="text-left">
                                <asp:Literal ID="ltrRecordFound" runat="server"></asp:Literal>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <label>Search</label>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Style="border-radius: 20px; background-color: aliceblue; color: black"></asp:TextBox>
                        </div>
                        <div class="col-sm-2" style="margin-bottom:10px;">
                            <asp:Button ID="btnsearch" CausesValidation="false" runat="server" CssClass="btn btn-primary" OnClick="btnsearch_Click" Style="border-radius: 20px" Text="Search" /><br />
                        </div>
                        <div class="row">
                        <div class="text-right p-b-10" style="margin-right:190px;">
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
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="col-sm-12">

            <asp:Repeater ID="rptHouseDetinfo" runat="server" OnItemCommand="rptHouseDetinfo_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-responsive table-bordered" style=" box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                        <tr style="background-color: #b52e31">
                            <th>HouseNo</th>
                            <th>HouseType</th>
                            <th>Images</th>
                            <th>Status</th>
                            <th>Action</th>

                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%#Eval("HouseNo") %></td>
                        <td><%#Eval("HouseTypeName") %></td>
                        <td>
                          <a href="house_det.aspx?Id=<%#Eval("HouseId") %>" class="btn btn-primary">   <img src='../admin/HouseImage/<%#Eval("Images") %>' style="width: 100px;" /></td></a>
                        <td><%#Eval("Status") %></td>
                        <td>
                            <asp:LinkButton ID="lnkupdate" runat="server" CommandArgument='<%#Eval("HouseId") %>' ToolTip="Edit" CommandName="edit" CssClass="btn btn-primary" CausesValidation="false"><i class="fa fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton ID="lnkstatus" runat="server" CommandArgument='<%#Eval("HouseId") %>' ToolTip="Status" CommandName="status" CssClass="btn btn-success" CausesValidation="false"><i class="fa fa-anchor"></i></asp:LinkButton>
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

        //alert('hi');

        if ($('#<%=HidImage.ClientID%>').val() != "") {
            $('#imgFullSizePreview').attr('src', 'HouseImage/' + $('#<%=HidImage.ClientID%>').val());
        }


        $('#<%=HouseImages.ClientID%>').change(function () {
            var fileName = $('#<%=HouseImages.ClientID%>').val();
            if (fileName) {
                readURL(this);

            } else {
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
            $('#<%=HouseImages.ClientID%>').val("");
        }
    </script>
</asp:Content>
