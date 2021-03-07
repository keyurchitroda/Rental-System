<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="cardocument.aspx.cs" Inherits="RentSystem.admin.cardocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
    <style>
        .imgHolder {
            position: relative;
            display: block;
        }

        .bimg-150 {
            background-repeat: no-repeat;
            width: auto;
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

    <asp:HiddenField ID="hiddocid" runat="server" />
    <asp:HiddenField ID="hidImageName" runat="server" />
    <div class="col-sm-12 women_main">
        <div class="row">
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1 ><b>Car Document</b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
        </div>

        <div class="col-sm-6 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label>Car No</label>
                </div>
                <div class="col-sm-8">
                    <asp:DropDownList ID="ddlCarNo" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Car No" InitialValue="-Select CarNo-" CssClass="text-danger" ControlToValidate="ddlCarNo"></asp:RequiredFieldValidator>

                </div>
            </div>

            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label>Document Type</label>
                </div>
                <div class="col-sm-8">
                    <asp:DropDownList ID="ddlcardoc" runat="server" CssClass="form-control" Style="border-radius: 10px;">
                        <asp:ListItem>PUC</asp:ListItem>
                        <asp:ListItem>RC-BOOK</asp:ListItem>
                        <asp:ListItem></asp:ListItem>

                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Document" CssClass="text-danger" InitialValue="-Select Document-" ControlToValidate="ddlcardoc"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label>Image</label>
                </div>
                <div class="col-sm-8">
                    <div class="row">
                        <asp:FileUpload ID="fpDocumentImages" runat="server" AllowMultiple="false" />
                        <br />
                    </div>
                    <div class="row">
                        <div class="imgHolder" style="">
                            <img id="imgFullSizePreview" src="assets/img/NoImages.png" class="bimg-150" style="height: 150px; width: 160px;" />
                            <div class="imageBoxPad">
                                <input type="button" class="btn btn-danger removeImg" onclick="RemoveImage();" value="X" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12" style="padding-bottom: 15px; margin-left: 15px;">
                    <asp:Button ID="btnsub" runat="server" Text="SUBMIT" CssClass="btn btn-primary" OnClick="btnsub_Click" />

                </div>
                 <div>
                        <asp:Label ID="lblduplicate" runat="server" Text="Please check duplicate" CssClass="text text-danger" Visible="false"></asp:Label>
                    </div>
            </div>
        </div>

        <div class="row">
            <br />
            <%-- <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-2 text-right">
                        <label>SEARCH</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control" Style="border-radius: 25px;"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnsearch" Text="SEARCH" runat="server" CssClass="btn btn-success" onclick="btnsearch_Click" CausesValidation="false" Style="border-radius: 10px;"></asp:Button>
                    </div>
                </div>--%>
            <div class="row">
                <div class="col-md-8" style="margin-left: 170px;">
                    <div class="white-box">
                        <div class="row" style="box-shadow: 2px 2px 2px 2px; padding: 5px; margin: 5px;">
                            <div class="col-md-2">
                                <asp:DropDownList runat="server" ID="cboPageSize" Style="background-color: aliceblue; color: black" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboPageSize_SelectedIndexChanged">
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
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
                                <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control" Style="border-radius: 20px; background-color: aliceblue; color: black"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btnsearch" CausesValidation="false" runat="server" CssClass="btn btn-primary" OnClick="btnsearch_Click" Style="border-radius: 20px" Text="Search" /><br />
                            </div>
                            <div class="row">
                                <div class="text-right p-b-10" style="margin-right: 60px; margin-top: 50px;">
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

            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <asp:Repeater ID="rptCarDocInfo" runat="server" OnItemCommand="rptCarDocInfo_ItemCommand">

                    <HeaderTemplate>

                        <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                            <tr style="background-color: #b52e31;">
                                <th>Car No</th>
                                <th>Document Type</th>
                                <th>Image</th>
                                <th>Status</th>
                                <th>Action</th>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr style="background-color: white;">
                            <td><%#Eval("CarNo") %></td>
                            <td><%#Eval("DocumentType") %></td>
                            <td>
                                <img src='../admin/CarDoc_Img/<%#Eval("Image")%>' style="width: 100px;" /></td>
                            <td><%#Eval("Status") %></td>
                            <td>
                                <asp:LinkButton ID="lnkupdate" runat="server" CommandArgument='<%#Eval("DocumentId") %>' CommandName="edit" ToolTip="Edit" CssClass="btn btn-primary " CausesValidation="false"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="lnkstatus" runat="server" CommandArgument='<%#Eval("DocumentId") %>' CommandName="status" ToolTip="Status" CssClass="btn btn-success" CausesValidation="false"><i class="fa fa-anchor"></i></asp:LinkButton>
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
        $(document).ready(function () {
            // alert('hi')
        });
        if ($('#<%=hidImageName.ClientID%>').val() != "") {
            $('#imgFullSizePreview').attr('src', 'CarDoc_Img/' + $('#<%=hidImageName.ClientID%>').val());
        }

        $('#<%=fpDocumentImages.ClientID %>').change(function () {
            var fileName = $('#<%=fpDocumentImages.ClientID%>').val();
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
            $('#<%=fpDocumentImages.ClientID%>').val("");
        }
    </script>
</asp:Content>
