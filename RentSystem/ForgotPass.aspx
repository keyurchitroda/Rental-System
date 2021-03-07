<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="RentSystem.ForgotPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <link href="css/foodongo.css" rel="stylesheet" />
    <div class="col-sm-12">
        <asp:Label ID="lblMsg" runat="server" Visible="false"/>
        <div class="row">
            <div class="col-sm-1"></div>
            <div class="col-sm-10" style="padding-bottom: 10px; border-radius: 25px;">
                <div class="row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">

                        <h3 style="text-align: center; color: azure;">Forgot Password</h3>
                    </div>
                </div>

                <div class="row" style="border-radius: 25px; width: 800px; margin-left: 130px;">
                    <div class="col-sm-12" style="margin: 1%; padding: 20px; border-radius: 25px; background-color: aliceblue">

                        <div class="row" style="padding-top: 10px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6">
                                <asp:TextBox runat="server" ID="txtEmailid" AutoPostBack="true" Style="font-size: 15px;" CssClass="textboxReg" Placeholder="EmailId"></asp:TextBox>
                                &nbsp;                 
                            </div>
                        </div>

                        <div class="row" style="padding-bottom: 30px; margin-right: 30px;">
                            <div class="col-sm-5"></div>
                            <div class="col-sm-3">
                                <div class="col-sm-12">
                                    <div class="col-sm-4" style="margin-right: 30px;">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btnReg btn"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-sm-1"></div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
