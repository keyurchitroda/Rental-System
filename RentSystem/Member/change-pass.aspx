<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="change-pass.aspx.cs" Inherits="RentSystem.Member.change_pass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="row bg-title" style="margin-top: 25px;">
        <div class="col-lg-12">
            <h4 class="page-title">Change Password</h4>
            <ol class="breadcrumb">
                <li><a href="Index.aspx">Dashboard</a></li>
                <li class="active">Change Password</li>
            </ol>
        </div>
    </div>

    <div class="row">
         <div class="col-sm-2"></div>
        <div class="col-sm-6 col-xs-12 col-md-6 col-lg-6">
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="lblMSG" runat="server" Text=""></asp:Label>
                    <div class="white-box">
                        <div class="row" style="margin-left:70px;">
                            <div class="col-sm-9">
                                <div class="form-group">
                                    <label style="color: black;">Old Password</label>
                                    <asp:TextBox ID="txtOldPass" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert Old Password" CssClass="text-danger" ControlToValidate="txtOldPass"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-left:70px;">
                            <div class="col-sm-9">
                                <div class="form-group">
                                    <label style="color: black;">New Password</label>
                                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert New Password" CssClass="text-danger" ControlToValidate="txtPass"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-left:70px;">
                            <div class="col-sm-9">
                                <div class="form-group">
                                    <label style="color: black;">Confirm Password</label>
                                    <asp:TextBox ID="txtCpass" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Insert Confirm Password" CssClass="text-danger" ControlToValidate="txtCpass"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Check Your Password" CssClass="text-danger" ControlToCompare="txtPass" ControlToValidate="txtCpass" Display="Dynamic"></asp:CompareValidator>

                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-left:170px;">
                            <div class="col-sm-9">
                                <div class="form-group">
                                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-success col-sm-5" runat="server" Text="Submit" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
