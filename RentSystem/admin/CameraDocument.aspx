<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="CameraDocument.aspx.cs" Inherits="RentSystem.admin.CameraDocument" %>

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
        <asp:HiddenField ID="hidcardocid" runat="server" />
               <asp:HiddenField ID="hidImageName" runat="server" />
        <!-- Page Header -->

        <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
            <center><h1><b>Camera Document</b></h1></center>
            <hr />
        </div>
        <!--End Page Header -->


        <div class="col-sm-6 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
            <div class="row">
            <div class="row">
                <div class="col-sm-4">
                    <label>Company Name</label>
                </div>
                <div class="col-sm-10">
                    <asp:DropDownList ID="ddlcompany" runat="server" CssClass="form-control" Style="border-radius: 10px;" AutoPostBack="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Company Name" InitialValue="-Select Company-" CssClass="text-danger" ControlToValidate="ddlcompany"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="row">
                <div class="row">
                    <div class="col-sm-4">
                        <label>DocumentName</label>
                    </div>
                    <div class="col-sm-10">
                        <asp:TextBox ID="txtdocumentname" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert Document Name" CssClass="text-danger" ControlToValidate="txtdocumentname"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="row">
                    <div class="col-cm-4">
                        <label style="margin-left: 15px;">Image</label>
                    </div>
                    <div class="col-sm-3">
                        <div class="col-sm-4">
                            <asp:FileUpload ID="fpCameraDocumentImages" runat="server" AllowMultiple="false" />
                       
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
        </div>
        <div class="row">
            <div class="col-md-10" style="margin-right:50px;">
                <div class="white-box">
                    <div style="margin-left: 170px;">
                            <div class="row" style="box-shadow: 2px 2px 2px 2px; padding:10px; margin:5px;">

                    <div class="row">
                        <div class="col-md-2">
                            <asp:DropDownList runat="server" ID="cboPageSize" Style="background-color: aliceblue; color: black" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboPageSize_SelectedIndexChanged">
                                <asp:ListItem Value="2">2</asp:ListItem>
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
                            <asp:TextBox ID="Tsearch" runat="server" CssClass="form-control" Style="border-radius: 20px; background-color: aliceblue; color: black"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <asp:Button ID="Submit" CausesValidation="false" runat="server" CssClass="btn btn-primary" OnClick="btnsearch_Click" Style="border-radius: 20px" Text="Search" /><br />
                        </div>
                    </div>
                    <div class="row">
                        <div class="text-right p-b-10" style="margin-right:150px;">
                            <asp:Repeater ID="rptPager" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton CausesValidation="false" ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                        CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "btn btn-primary btn-sm" : "btn btn-default btn-sm" %>'
                                        OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
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
            </div>
        </div>
        
        <div class="row">
            <asp:Repeater ID="rptinfoCameraDocument" runat="server" OnItemCommand="rptinfoCameraDocument_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-responsive table-bordered" style="width:700px; margin-left:170px;box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                        <tr style="background-color: #b52e31;">
                            <th>Company Name</th>
                            <th>Document Name</th>
                            <th>Image</th>
                            <th>Status</th>
                            <th>Action</th>

                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr style="background-color: white;">
                         <td><%#Eval("CompanyName") %></td>
                        <td><%#Eval("DocumentName") %></td>
                        <td>
                            <img src='../admin/CameraDocument_Img/<%#Eval("Image") %>' style="width: 100px; height: 100px;" />
                        </td>
                        <td><%#Eval("Status") %></td>
                        <td>
                            <asp:LinkButton ID="lnkedit" runat="server" CommandName="edit" ToolTip="Edit" CommandArgument='<%#Eval("DocumentId") %>' CssClass="btn btn-primary" CausesValidation="false"><i class="fa fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton ID="lnkstatus" runat="server" CommandName="status" ToolTip="status" CommandArgument='<%#Eval("DocumentId") %>' CssClass="btn btn-success" CausesValidation="false"><i class="fa fa-anchor"></i></asp:LinkButton>
                        </td>

                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            alert('hi')
        });

          if ($('#<%=hidImageName.ClientID%>').val() != "") {
            $('#imgFullSizePreview').attr('src', 'CameraDocument_Img/' + $('#<%=hidImageName.ClientID%>').val());
        }

        $('#<%=fpCameraDocumentImages.ClientID %>').change(function () {
            var fileName = $('#<%=fpCameraDocumentImages.ClientID%>').val();
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
            $('#<%=fpCameraDocumentImages.ClientID%>').val("");
        }
    </script>

</asp:Content>
