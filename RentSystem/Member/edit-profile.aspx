<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="edit-profile.aspx.cs" Inherits="RentSystem.Member.edit_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">

  <%--  <link href="CSS/bootstrap.css" rel="stylesheet" />
   <link href="css/bootstrap-datetimepicker.min.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="row bg-title" style="margin-top:25px;">
      
        <div class="col-lg-12">
            <h4 class="page-title">Edit Profile</h4>
            <ol class="breadcrumb">
                <li><a href="Index.aspx">Dashboards</a></li>
                <li class="active">Edit Profile</li>
            </ol>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2"></div>
        <div class="col-sm-8 col-xs-12 col-md-8 col-lg-8">
            <div class="row">
                <div class="col-lg-12">
                    <div class="white-box">
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label style="color: black;">First Name</label>
                                    <asp:TextBox ID="txtFirst" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label style="color: black;">Last Name</label>
                                    <asp:TextBox ID="txtLast" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="color: black;">BirthDate</label>
                                    <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="color: black;">Email Id</label>
                                    <asp:TextBox ID="txtEmailId"  runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="color: black;">Mobile</label>
                                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label style="color: black;">Address</label>
                                    <asp:TextBox ID="txtadd" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-8">
                                <div class="form-group">
                                    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" CssClass="btn btn-success col-sm-4" runat="server" Text="Submit" />
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
     <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.min.js"></script>
    <script src="js/moment.js"></script>
     <script src="js/bootstrap-datetimepicker.min.js"></script>
   <script type="text/javascript">
        $(function()
        {
            $('#<%=txtBirthDate.ClientID%>').datetimepicker
                ({
                    format: 'DD/MM/YYYY',
                    //minDate: new Date(),
            });
        });
    </script>
</asp:Content>
