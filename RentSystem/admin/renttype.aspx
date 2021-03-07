﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="renttype.aspx.cs" Inherits="RentSystem.admin.renttype" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-sm-12 women_main" >
        <asp:HiddenField ID="hidrid" runat="server" />

        <div class="col-sm-12" style="padding-top: 35px;">
            <div class="row">
                <!-- Page Header -->

                <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                    <center><h1><b>Rent Type</b></h1></center>
                    <hr />
                </div>
                <!--End Page Header -->
            </div>
            <div class="col-sm-6 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
                <div class="col-sm-12">
                    <div class="col-sm-4">
                        <label><b>CategoryName</b></label>
                    </div>
                    <div class="col-sm-8">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Category Name" InitialValue="-Select Category-" CssClass="text-danger" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

            <div class="col-sm-12">
                <div class="row">
                    <div class="col-sm-4" style="margin-left: 15px;">
                        <label><b>Rent Type</b></label>
                        </div>
                    <div class="col-sm-7">
                        <asp:TextBox ID="txtrenttype" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert Rent Type" ControlToValidate="txtrenttype" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

                <div class="row">
                    <div class="col-sm-12" style="padding-bottom: 10px; margin-left: 170px;">
                        <asp:Button ID="btnsubmit" runat="server" Text="SUBMIT" CssClass="btn btn-primary" OnClick="btnsubmit_Click" Style="border-radius: 10px;"></asp:Button>
                    </div>
                     <div>
                        <asp:Label ID="lblduplicate" runat="server" Text="Please check duplicate" CssClass="text text-danger" Visible="false"></asp:Label>
                    </div>

                </div>
            </div>

            <%-- <div class="row">
                <br />
                <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-2 text-right">
                        <label>SEARCH</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control" Style="border-radius: 25px;"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnsearch" Text="SEARCH" runat="server" CssClass="btn btn-success" CausesValidation="false" Style="border-radius: 10px;" OnClick="btnsearch_Click"></asp:Button>
                    </div>
                </div>
            </div>--%>
            <div class="row">
                <div class="col-md-8" style="margin-left:170px;">
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
                                <asp:TextBox ID="txtsearch" runat="server" CssClass="form-control" Style="border-radius: 20px; background-color: aliceblue; color: black"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btnsearch" CausesValidation="false" runat="server" CssClass="btn btn-primary" OnClick="btnsearch_Click" Style="border-radius: 20px" Text="Search" /><br />
                            </div>
                       
                        <div class="row">
                            <div class="text-right p-b-10" style="margin-right:160px;margin-top:50px;">
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
                <asp:Repeater ID="rptrentInfo" runat="server" OnItemCommand="rptrentInfo_ItemCommand">
                    <HeaderTemplate>
                        <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 2px 2px; padding: 10px; margin: 5px;">
                            <tr style="background-color: #b52e31;">
                                <th>Category Name</th>
                                <th>RentTypeName</th>
                                <th>Status</th>
                                <th>Action</th>

                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="background-color: white;">
                            <td><%#Eval("CategoryName") %></td>
                            <td><%#Eval("RentTypeName") %></td>
                            <td><%#Eval("Status") %></td>
                            <td>
                                <asp:LinkButton ID="lnkupdate" runat="server" CommandArgument='<%#Eval("RentTypeId") %>' CommandName="edit" CssClass="btn btn-primary " CausesValidation="false" ToolTip="Edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="lnkstatus" runat="server" CommandArgument='<%#Eval("RentTypeId") %>' CommandName="status" CssClass="btn btn-success" CausesValidation="false" ToolTip="Status"><i class="fa fa-anchor"></i></asp:LinkButton>
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
</asp:Content>
