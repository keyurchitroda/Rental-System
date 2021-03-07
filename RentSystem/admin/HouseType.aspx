<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="HouseType.aspx.cs" Inherits="RentSystem.admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12 women_main" >
        <div class="row">
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1><b>HouseType</b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
        </div>
        <asp:HiddenField ID="hidtid" runat="server" />
        <div class="row">
             <div class="col-sm-6 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label>HouseType Name</label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txthousetype" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert HouseType Name" CssClass="text-danger" ControlToValidate="txthousetype"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label>Rent Type</label>
                </div>
                <div class="col-sm-8">
                    <asp:DropDownList ID="ddlrenttype" runat="server" CssClass="form-control" Style="border-radius: 20px;" AutoPostBack="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Rent Type" InitialValue="-Select RentType-" CssClass="text-danger" ControlToValidate="ddlrenttype"></asp:RequiredFieldValidator>
                </div>
            </div>


            <div class="col-sm-12">
                <div class="col-sm-4">
                    <label>Price</label>
                </div>
                <div class="col-sm-8">
                    <asp:TextBox ID="txtprice" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert Price" CssClass="text-danger" ControlToValidate="txtprice"></asp:RequiredFieldValidator>
                </div>
            </div>

            <div class="col-sm-12">
                <div class="col-sm-6" style="margin-left:150px;">
                    <asp:Button ID="btnsubmit" CssClass="btn btn-primary" OnClick="btnsubmit_Click" runat="server" Text="Submit" />
                </div>
                <div>
                        <asp:Label ID="lblduplicate" runat="server" Text="Please check duplicate" CssClass="text text-danger" Visible="false"></asp:Label>
                    </div>

            </div>
                 </div>
            <%--  <div class="col-sm-12">
                <div class="col-sm-2">
                    <label>Search</label>
                </div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtsearch"  runat="server"   CssClass="form-control" ></asp:TextBox>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="col-sm-2">
                    <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" Text="Search" CssClass="btn btn-success" CausesValidation="false"></asp:Button>
                </div>
</div>--%>
            <div class="row">
                <div class="col-md-8" style="margin-left:130px;">
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
                            <div class="col-sm-2" style="padding-bottom:10px;">
                                <label>Search</label>
                            </div>
                            <div class="col-sm-4" style="padding-bottom:10px;">
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Style="border-radius: 20px; background-color: aliceblue; color: black"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button ID="btnsearch" CausesValidation="false" runat="server" CssClass="btn btn-primary" OnClick="btnsearch_Click" Style="border-radius: 20px" Text="Search" /><br />
                            </div>
                        
                        <div class="row">
                            <div class="text-right p-b-10" style="margin-right:190px;">
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
             
            <div class="col-sm-12">
                <div class="col-sm-8" style="margin-left:130px;  box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); margin-left: 140px;">
                    <asp:Repeater ID="rptHouseInfo" runat="server" OnItemCommand="rptHouseInfo_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-responsive table-bordered"  >
                                <tr style="background-color:#b52e31">
                                    <td><b>Housetype</b></td>
                                   <td><b>RentType</b></td>
                                    <td><b>Price</b></td>
                                    <td><b>Status</b></td>
                                    <td><b>Action</b></td>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("HouseTypeName") %></td>
                                <td><%#Eval("RentTypeName") %></td>
                                <td><%#Eval("Price") %></td>
                                <td><%#Eval("Status") %></td>
                                <td>
                                    <asp:LinkButton ID="linkedit" runat="server" CssClass="btn btn-primary" ToolTip="Edit" CommandArgument='<%#Eval("HouseTypeId") %>' CommandName="edit" CausesValidation="false"><i class="fa fa-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="linkstatus" runat="server" CssClass="btn btn-success" ToolTip="Status" CommandArgument='<%#Eval("HouseTypeId")%>' CommandName="status" CausesValidation="false"><i class="fa fa-anchor"></i></asp:LinkButton>
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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>

