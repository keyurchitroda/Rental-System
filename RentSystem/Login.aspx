<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RentSystem.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <link href="css/foodongo.css" rel="stylesheet" />
    <div class="col-sm-12">
        <div class="row">
            <div class="col-sm-1"></div>
            <div class="col-sm-10" style="padding-bottom: 10px; border-radius: 25px;">
                <div class="row">
                    <div class="col-sm-5"></div>
                    <div class="col-sm-2">

                        <h3 style="text-align: center; color: azure;">Login</h3>
                    </div>
                </div>

                <div class="row" style="border-radius: 25px;  width:800px; margin-left:130px;">
                    <div class="col-sm-12" style="margin: 1%; padding: 20px; border-radius: 25px; background-color: aliceblue">

                        <div class="row" style="padding-top: 10px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6">
                                <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="updatepanel1" runat="server">
                                    <ContentTemplate>

                                        <asp:TextBox runat="server" ID="txtUserid" AutoPostBack="true" OnTextChanged="txtUserid_TextChanged" CssClass="textboxReg" Placeholder="UserId" Style="font-size:15px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert UserId" CssClass="text-danger" ControlToValidate="txtUserid"></asp:RequiredFieldValidator>
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtpass" CssClass="textboxReg" Placeholder="Password" TextMode="Password" Style="font-size:15px;"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Insert Password" CssClass="text-danger" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
                                &nbsp;
                              
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-3" style="padding: 5px;">
                            </div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:UpdatePanel ID="updatepanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMsg" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                        <asp:Label ID="lblMsg1" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtOTP" CssClass="textboxReg" Placeholder="OTP" Visible="false" Style="font-size:15px;"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                &nbsp;
                            </div>
                        </div>

                        <div class="row" style="padding-bottom: 30px; margin-right:30px;">
                            <div class="col-sm-5"></div>
                            <div class="col-sm-3">
                                <div class="col-sm-12" >
                                    <div class="col-sm-4" style="margin-right:30px;">
                                        <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Login" CssClass="btnReg btn"></asp:Button>
                                    </div>
                                    <div class="col-sm-4">
                                        <asp:Button ID="btnsingin" CausesValidation="false" OnClick="btnsingin_Click" runat="server" Text="Sign In" CssClass="btnReg btn"></asp:Button>
                                    </div>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            
                            <div class="col-sm-12">
                                <div class="col-sm-5"></div>
                                <div class="col-sm-4" style="margin-top:10px; margin-left:30px;">
                                  <asp:Button ID="btnforgot" CausesValidation="false" OnClick="btnforgot_Click" runat="server" Text="Forgot Password" CssClass="btn-link btn-danger" ></asp:button>
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
