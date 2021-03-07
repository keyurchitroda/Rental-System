<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="area.aspx.cs" Inherits="RentSystem.admin.area" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class=" col-sm-12 women_main" >
        <div class="row">
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1><b>Area</b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
        </div>
        <asp:HiddenField ID="hidaid" runat="server" />
        <div class="col-sm-6 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-3">
                        <label>State</label>
                    </div>
                    <div class="col-sm-9">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlState" AutoPostBack="true" CssClass="form-control" runat="server" OnTextChanged="ddlState_TextChanged"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select State" InitialValue="-Select State-" CssClass="text-danger" ControlToValidate="ddlState"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="col-sm-12">
                    <div class="col-sm-3">
                        <label>City</label>
                    </div>
                    <div class="col-sm-9">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCity" AutoPostBack="true" CssClass="form-control" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select City" CssClass="text-danger" InitialValue="-Select city-" ControlToValidate="ddlCity"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="col-sm-12">
                    <div class="col-sm-3">
                        <label>AreaName</label>
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtareaname" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Insert AreaName" CssClass="text-danger" ControlToValidate="txtareaname"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-sm-12">
                    <div class="col-sm-5" style="margin-left: 150px;">
                        <asp:Button ID="btnsubmit" OnClick="btnsubmit_Click" CssClass="btn btn-success" runat="server" Text="Submit" />
                    </div>
                    <div>
                        <asp:Label ID="lblduplicate" runat="server" Text="Please check duplicate" CssClass="text text-danger" Visible="false"></asp:Label>
                    </div>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-10" style="padding-right: 15px; padding-left: 10px;">
                <div class="white-box">
                    <div class="row">
                        <div style="margin-left: 170px;">
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


                                <div class="col-md-3">
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
            <asp:Repeater ID="rptUserInfo" OnItemCommand="rptUserInfo_ItemCommand" runat="server">
                <HeaderTemplate>
                    <table class="table table-responsive table-bordered" style="width: 700px; box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); margin-left: 160px;">
                        <tr style="background-color: #b52e31;">
                            <td><b>StateName</b></td>
                            <td><b>CityName</b></td>
                            <td><b>AreaName</b></td>
                            <td><b>Status</b></td>
                            <td><b>Action</b></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("StateName") %></td>
                        <td><%#Eval("CityName") %></td>
                        <td><%#Eval("AreaName") %></td>
                        <td><%#Eval("Status") %></td>
                        <td>
                            <asp:LinkButton ID="lnkUpdate" CausesValidation="false" CommandArgument='<%#Eval("AreaId") %>' ToolTip="Edit" CommandName="edit" CssClass="btn btn-primary" runat="server"><i class="fa fa-edit"></i></asp:LinkButton>
                            <asp:LinkButton ID="lnkStatus" CausesValidation="false" CommandArgument='<%#Eval("AreaId") %>' ToolTip="Status" CommandName="status" CssClass="btn btn-success" runat="server"><i class="fa fa-anchor"></i></asp:LinkButton>
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
</asp:Content>
