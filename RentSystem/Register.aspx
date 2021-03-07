<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RentSystem.Register" %>

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

                        <h3 style="text-align: center; color: azure;">Register</h3>
                    </div>
                </div>
                <div class="row" style="border-radius: 25px;">
                    <asp:Label ID="ltrMsg" runat="server"></asp:Label>
                    <div class="col-sm-12" style="margin: 1%; padding: 20px; border-radius: 25px; background-color: aliceblue">
                        <div class="row" style="padding-top: 10px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-3" style="padding-top: 10px;">
                                <asp:TextBox runat="server" ID="txtfname" CssClass="textboxReg" Placeholder="First Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Insert First Name" CssClass="text-danger" ControlToValidate="txtfname"></asp:RequiredFieldValidator>
                                &nbsp;
                            </div>
                            &nbsp;
                            <div class="col-sm-3" style="padding-top: 10px;">
                                <asp:TextBox runat="server" ID="txtlname" CssClass="textboxReg" Placeholder="Last Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert Last Name" CssClass="text-danger" ControlToValidate="txtlname"></asp:RequiredFieldValidator>
                                &nbsp;
                            </div>
                        </div>
                        <div class="row" style="padding-top: 10px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6">
                                <asp:TextBox runat="server" ID="txtaddress" CssClass="textboxReg" Placeholder="Address" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert Address" CssClass="text-danger" ControlToValidate="txtaddress"></asp:RequiredFieldValidator>
                                &nbsp;
                            </div>
                        </div>


                        <div class="col-sm-12">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-3" style="padding-top: 30px;">
                                <asp:TextBox runat="server" ID="txtBirthdate" CssClass="textboxReg" Placeholder="Birthdate"></asp:TextBox>
                                &nbsp;
                            </div>
                            &nbsp;        
                            <div class="col-sm-3" style="align-content: center;">
                                <asp:Label runat="server" CssClass="col-sm-2 lblReg pos2">Gender</asp:Label><br />
                                &nbsp;&nbsp;
                                <asp:DropDownList runat="server" ID="ddlGender" CssClass="col-sm-10 textboxReg" Placeholder="DD" BackColor="white">
                                    <asp:ListItem Enabled="False" Selected="True">I am...</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Gender" CssClass="text-danger" ControlToValidate="ddlGender"></asp:RequiredFieldValidator>
                            </div>
                            &nbsp;
                        </div>

                        <div class="row" style="padding-top: 100px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtemail" CssClass="textboxReg" Placeholder="Email Address" TextMode="Email"></asp:TextBox>&nbsp;
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Select Email" CssClass="text-danger" ControlToValidate="txtemail"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtpass" CssClass="textboxReg" Placeholder="Password" TextMode="Password"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Insert Password" CssClass="text-danger" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
                                &nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtcompass" CssClass="textboxReg" Placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Confirm passowrd" CssClass="text-danger" ControlToValidate="txtcompass"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Please Enter Confirm Password" CssClass="text-danger" ControlToCompare="txtpass" ControlToValidate="txtcompass"></asp:CompareValidator>
                                &nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtmob" CssClass="textboxReg" Placeholder="Mobile Number" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Insert Mobile" CssClass="text-danger" ControlToValidate="txtmob"></asp:RequiredFieldValidator>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Insert 10 Digit Number" CssClass="text-danger" ControlToValidate="txtmob" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                                &nbsp;
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-2">
                                <b>Verification code</b>
                            </div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:Image ID="Image2" runat="server" Height="55px" ImageUrl="~/Captcha.aspx" Width="186px" />
                                <br />
                                <asp:Label runat="server" ID="lblCaptchaMessage"></asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtVerificationCode" CssClass="textboxReg" Placeholder="Enter Verification Code"></asp:TextBox>
                                &nbsp;
                            </div>
                        </div>

                        <div class="row" style="padding-bottom: 30px;">
                            <div class="col-sm-5"></div>
                            <div class="col-sm-3">
                                <div class="col-sm-6">

                                    <asp:LinkButton ID="btnsubmit" runat="server" CssClass="btnReg btn" OnClick="btnsubmit_Click">Submit</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-sm-1"></div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.min.js"></script>
    <script src="js/moment.js"></script>
    <script src="js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#<%=txtBirthdate.ClientID%>').datetimepicker
                ({
                    format: 'DD/MM/YYYY',
                    //minDate: new Date(),
                });
        });
    </script>
</asp:Content>
