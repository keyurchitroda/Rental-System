<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="cardetails.aspx.cs" Inherits="RentSystem.admin.cardetails" %>

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
    <div>
        <div class="col-sm-12 women_main">
            <asp:HiddenField ID="Hidcardetailsid" runat="server" />
            <asp:HiddenField ID="hidImageName" runat="server" />
            <div class="row">
                <!-- Page Header -->

                <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                    <center><h1><b>Car Details</b></h1></center>
                    <hr />
                </div>
                <!--End Page Header -->
            </div>
            <div class="col-sm-8 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
                <div class="row">
                    <div class="row">
                        <div class="col-sm-4">
                            <label>Company Name</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlcompany"  runat="server" CssClass="form-control" Style="border-radius: 10px;" OnTextChanged="ddlcompany_TextChanged" AutoPostBack="true" ForeColor="Black"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Company Name" InitialValue="-Select Company-" CssClass="text-danger" ControlToValidate="ddlcompany"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>Model Name</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlmodel" runat="server" CssClass="form-control" Style="border-radius: 10px;" OnTextChanged="ddlmodel_TextChanged" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Model Name" CssClass="text-danger" InitialValue="-Select Model-" ControlToValidate="ddlmodel"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>SubModel Name</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlsubmodel" runat="server" CssClass="form-control" Style="border-radius: 10px;" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" InitialValue="-Select SubModel-" ErrorMessage="Please Select Sub-Model Name" CssClass="text-danger" ControlToValidate="ddlsubmodel"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>No</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" ID="txtcarno" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Insert No" CssClass="text-danger" ControlToValidate="txtcarno"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>Register No </label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox runat="server" ID="txtcarregno" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Insert Register No" CssClass="text-danger" ControlToValidate="txtcarregno"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>State</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlcarstate" runat="server" CssClass="form-control" OnTextChanged="ddlcarstate_TextChanged" Style="border-radius: 10px;" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select State" InitialValue="-Select State-" CssClass="text-danger" ControlToValidate="ddlcarstate"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>City</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlcarcity" runat="server" CssClass="form-control" Style="border-radius: 10px;" AutoPostBack="true"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Select City" InitialValue="-Select City-" CssClass="text-danger" ControlToValidate="ddlcarcity"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>Owner</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtcarowner" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Insert Owner Name" CssClass="text-danger" ControlToValidate="txtcarowner"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>Owner Mobile No </label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtownermob" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Insert Owner Mobile No" CssClass="text-danger" ControlToValidate="txtownermob"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>Owner Address</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtcarowneradd" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please Insert Owner Address" CssClass="text-danger" ControlToValidate="txtcarowneradd"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>Price</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtcarprice" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Insert Price" CssClass="text-danger" ControlToValidate="txtcarprice"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-4">
                            <label>Rent Type</label>
                        </div>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlrenttype" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please select Rent Type" InitialValue="-Select RentType-" CssClass="text-danger" ControlToValidate="ddlrenttype"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-2">
                            <label>Image</label>
                        </div>
                        <div class="col-sm-1">
                            <asp:FileUpload ID="CarImages" runat="server" AllowMultiple="false" />
                            
                            <br />
                            <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Style="border-radius: 10px;" Text="SUBMIT" OnClick="btnsubmit_Click"></asp:Button>
                        </div>
                        <div class="col-sm-4" style="padding-top: 5px;">
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
            <div class="row">
                <div class="col-md-12">
                    <div class="white-box">
                        <div class="row"  style="box-shadow:2px 2px 2px 2px;padding:10px; margin:5px; ">
                            <div class="col-md-2">

                                <asp:DropDownList ID="cboPageSize" runat="server" Style="background-color: aliceblue; color: black" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboPageSize_SelectedIndexChanged">

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
                            <div class="col-sm-2">
                                <asp:Button ID="btnsearch" CausesValidation="false" runat="server" CssClass="btn btn-primary" OnClick="btnsearch_Click" Style="border-radius: 20px" Text="Search" /><br />
                            </div>
                        
                        <div class="row">
                            <div class="text-right p-b-10" style="margin-right:160px;margin-top:50px;">
                                <asp:Repeater ID="rptPager" runat="server" >
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


            <%--            <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-2 text-right">
                        <label>SEARCH</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtsearch" runat="server"  CssClass="form-control" Style="border-radius: 25px;"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnsearch" Text="SEARCH" onclick="btnsearch_Click" runat="server" CssClass="btn btn-success" CausesValidation="false" Style="border-radius: 10px;"></asp:Button>
                    </div>
                </div>--%>
            <div class="col-sm-12">
                <asp:Repeater ID="rptCarDetailsInfo" runat="server" OnItemCommand="rptCarDetailsInfo_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">
                            <tr style="background-color: #b52e31;">
                                <th>Car No</th>
                                <th>Owner Name</th>
                                <th>Owner Mobile No</th>
                                <th>Image</th>
                                <th>Status</th>
                                <th>Action</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: white;">
                            <td><%#Eval("CarNo") %></td>
                            <td><%#Eval("CarOwner") %></td>
                            <td><%#Eval("CarOwnerMobileNo") %></td>

                            <td>
                              <a href="car_det.aspx?Id=<%#Eval("CarDetailsId") %>" class="btn btn-primary"><img src='../admin/Car_Img/<%#Eval("CarImage") %>' style="width: 100px;" /></a>
                            </td>
                            <td><%#Eval("Status") %></td>
                            <td>
                                <asp:LinkButton ID="lnkedit" runat="server" CommandName="edit" CommandArgument='<%#Eval("CarDetailsId") %>' ToolTip="Edit" CssClass="btn btn-primary" CausesValidation="false"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="lnkstatus" runat="server" CommandArgument='<%#Eval("CarDetailsId") %>' CommandName="status" ToolTip="Status" CssClass="btn btn-success" CausesValidation="false"><i class="fa fa-anchor"></i></asp:LinkButton>
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
            //alert('hi')
        });

        if ($('#<%=hidImageName.ClientID%>').val() != "") {
            $('#imgFullSizePreview').attr('src', 'car_img/' + $('#<%=hidImageName.ClientID%>').val());
        }

        $('#<%=CarImages.ClientID %>').change(function () {
            var fileName = $('#<%=CarImages.ClientID%>').val();
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
    </script>
</asp:Content>
