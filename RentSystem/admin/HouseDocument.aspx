<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="HouseDocument.aspx.cs" Inherits="RentSystem.admin.HouseDocument" %>

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
    <div class=" col-sm-12 women_main">
        <asp:HiddenField ID="hdocid" runat="server" />
        <asp:HiddenField ID="hidImageName" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1><b>House Document</b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
        </div>
        <div class="col-sm-6 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
            <div class="col-sm-12" style="margin-top: 50px;">
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">HouseType</label>
                </div>
                <div class="col-sm-8">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlDocument" runat="server" CssClass="form-control" Style="border-radius: 10px; margin-left: 15px;" AutoPostBack="true" OnSelectedIndexChanged="ddlDocument_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select HouseType" CssClass="text-danger" InitialValue="-Select HouseType-" ControlToValidate="ddlDocument"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="col-sm-12" style="margin-top: 8px;">
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">HouseNo/Name</label>
                </div>
                <div class="col-sm-8">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlhouseno" runat="server" CssClass="form-control" Style="border-radius: 10px; margin-left: 15px;" AutoPostBack="true"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select HouseNo" CssClass="text-danger" InitialValue="-Select HouseNo/Name-" ControlToValidate="ddlhouseno"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>


            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label style="margin-left: 15px;">DocumentType</label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtdocument" runat="server" CssClass="form-control" Style="border-radius: 10px; margin-left: 15px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert DocumentType" CssClass="text-danger" ControlToValidate="txtdocument"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label>Image</label>
                </div>
                <div class="col-sm-8">
                    <div class="row">
                        <asp:FileUpload ID="fpImages" runat="server" AllowMultiple="false" />
                       
                    </div>
                    <div class="row">
                        <div class="imgHolder">
                            <img id="imgFullSizePreview" src="assets/img/NoImages.png" class="bimg-150" />
                            <div class="imageBoxPad">
                                <input type="button" class="btn btn-danger removeImg" onclick="RemoveImage();" value="X" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6" style="padding-top: 5px; margin-top: 20px; padding-bottom: 40px;">
                </div>
            </div>

            <div class="col-sm-12">
                <div class="col-sm-2" style="margin-left: 150px;">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" CssClass="btn btn-primary" />
                </div>
                <div>
                        <asp:Label ID="lblduplicate" runat="server" Text="Please check duplicate" CssClass="text text-danger" Visible="false"></asp:Label>
                    </div>

            </div>
        </div>

        <div class="row">
            <div class="col-md-8" style="margin-left: 170px;">
                <div>
                    <div class="row" style="box-shadow: 2px 2px 2px 2px; padding: 10px; margin: 5px;">
                        <div class="col-md-2">
                            <asp:DropDownList ID="cboPageSize" runat="server" Style="background-color: aliceblue; color: black" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboPageSize_SelectedIndexChanged">
                                <asp:ListItem Value="5">5</asp:ListItem>
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
                        <div class="col-sm-1">
                            <label>Search</label>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Style="border-radius: 20px; background-color: aliceblue; color: black"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <asp:Button ID="btnsearch" CausesValidation="false" runat="server" CssClass="btn btn-primary" OnClick="btnsearch_Click" Style="border-radius: 20px" Text="Search" /><br />
                        </div>

                        <div class="row">
                            <div class="text-right p-b-10" style="margin-right: 160px; margin-top: 50px;">
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
            <div class="col-sm-6">
                <asp:Repeater ID="rptHouseDocument" OnItemCommand="rptHouseDocument_ItemCommand" runat="server">
                    <HeaderTemplate>
                        <table class="table table-responsive table-bordered" style="width: 750px; box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); margin-left: 140px;">
                            <tr style="background-color: #b52e31">
                                <td><b>HouseTpyeName</b></td>
                                <td><b>HouseNo/Name</b></td>
                                <td><b>Document Type</b></td>
                                <td><b>Images</b></td>
                                <td><b>Status</b></td>
                                <td><b>Action</b></td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("HouseTypeName") %></td>
                            <td><%#Eval("HouseNo") %></td>
                            <td><%#Eval("Documenttype") %></td>
                            <td>
                                <img src='../admin/HouseDoc_Img/<%#Eval("Images") %>' style="width: 100px;" /></td>
                            <td><%#Eval("Status") %></td>
                            <td>
                                <asp:LinkButton ID="lnkupdate" runat="server" CommandArgument='<%#Eval("DocumentId") %>' ToolTip="Edit" CommandName="edit" CssClass="btn btn-primary" CausesValidation="false"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="lnkstatus" runat="server" CommandArgument='<%#Eval("DocumentId") %>' ToolTip="Status" CommandName="status" CssClass="btn btn-success" CausesValidation="false"><i class="fa fa-anchor"></i></asp:LinkButton>
                            </td>
                        </tr>

                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script type="text/javascript">

        //alert('hi');

            if ($('#<%=hidImageName.ClientID%>').val() != "") {
            $('#imgFullSizePreview').attr('src', 'HouseDoc_Img/' + $('#<%=hidImageName.ClientID%>').val());
        }


        $('#<%=fpImages.ClientID%>').change(function () {
            var fileName = $('#<%=fpImages.ClientID%>').val();
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
            $('#<%=fpImages.ClientID%>').val("");
        }
    </script>
</asp:Content>
