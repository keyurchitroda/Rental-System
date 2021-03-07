<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="RentSystem.Member.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row bg-title" style="margin-top:25px;">
        <div class="col-lg-12">
            <h4 class="page-title">Welcome To Rental System
            </h4>
            <ol class="breadcrumb">
                <li><a href="index.aspx">Dashboard</a></li>
            </ol>
        </div>
    </div>

    <div class="wrapper">
        <div class="col-sm-8">
            <div id="slider">
                <img src="images/img1.jpg" alt="" title="<strong>Villa Neverland, 2006</strong><span>9 rooms, 3 baths, 6 beds, building size: 5000 sq. ft. &nbsp; &nbsp; &nbsp; Price: $ 600 000 &nbsp; &nbsp; &nbsp; <a href='#'>Read more</a></span>">
            </div>
        </div>
        <div class="col-sm-4">
            <div class="tab table-bordered" style="border: 2px solid white; background-color: white; margin-bottom: 10px;">
                <input type="button" id="btncar" onclick="funshow1();" class="btn btn-primary" value="Car" />
                <input type="button" id="btnhouse" onclick="funshow2();" class="btn btn-primary" value="House" />
                <input type="button" id="btncamera" onclick="funshow3();" class="btn btn-primary" value="Camera" />
                <div id="t1" style="border: 2px solid white; height: 330px; background-color: #808080; display: block;">
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>Company</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCompany" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>Model</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlModel" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>SubModel</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSubModel" CssClass="form-control" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-8" style="margin-left: 100px; margin-top: 10px;">
                        <asp:Button ID="btnsearchCar" OnClick="btnsearchCar_Click" runat="server" Text="Search" CssClass="btn btn-success" />
                    </div>
                </div>

                <div id="t2" style="border: 2px solid white; height: 330px; background-color: #808080; display: none;">
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>State</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>

                                    <asp:DropDownList ID="ddlState" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>City</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>

                                    <asp:DropDownList ID="ddlCity" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>Area</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                <ContentTemplate>

                                    <asp:DropDownList ID="ddlArea" CssClass="form-control" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>House Type</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>

                                    <asp:DropDownList ID="ddlhousetype" CssClass="form-control" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="col-sm-6" style="margin-left: 100px; margin-top: 10px;">
                        <asp:Button ID="btnsearchHouse" OnClick="btnsearchHouse_Click" runat="server" Text="Search" CssClass="btn btn-success" />
                    </div>

                </div>
                <div id="t3" style="border: 2px solid white; height: 330px; background-color: #808080; display: none;">
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>Company</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCompany1" OnSelectedIndexChanged="ddlCompany1_SelectedIndexChanged" CssClass="form-control" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>Model</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlModel1"  CssClass="form-control" OnSelectedIndexChanged="ddlModel1_SelectedIndexChanged" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-12" style="margin-top: 10px;">
                        <div class="col-sm-3" style="color: black;">
                            <label>
                                <h5><b>SubModel</b></h5>
                            </label>
                        </div>
                        <div class="col-sm-9">
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlSubModel1" CssClass="form-control" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="col-sm-6" style="margin-left: 100px; margin-top: 10px;">
                        <asp:Button ID="btnsearchCamera" OnClick="btnsearchCamera_Click" runat="server" Text="Search" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
    <script>
        function funshow1() {
            document.getElementById("t1").style.display = "block";
            document.getElementById("t2").style.display = "none";
            document.getElementById("t3").style.display = "none";
        }
        function funshow2() {
            document.getElementById("t1").style.display = "none";
            document.getElementById("t2").style.display = "block";
            document.getElementById("t3").style.display = "none";
        }
        function funshow3() {
            document.getElementById("t1").style.display = "none";
            document.getElementById("t2").style.display = "none";
            document.getElementById("t3").style.display = "block";
        }
    </script>
</asp:Content>
