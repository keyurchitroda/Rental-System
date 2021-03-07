<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="category.aspx.cs" Inherits="RentSystem.admin.category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="col-sm-12 women_main" >
        <div class="row">
            <!-- Page Header -->

            <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                <center><h1 ><b>Category</b></h1></center>
                <hr />
            </div>
            <!--End Page Header -->
        </div>

        <div class="col-sm-6 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
            <div class="row">
                <div class="row">
                    <asp:HiddenField ID="hidcid" runat="server" />
                    <div class="col-sm-8">
                        <label style="margin-left: 70px;">Category Name</label>
                        <asp:TextBox ID="txtcname" runat="server" CssClass="form-control col-sm-5" Style="border-radius: 10px; margin-left: 70px;"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Insert Category" ControlToValidate="txtcname" CssClass="text-danger"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6" style="margin-left: 160px; padding-top: 10px;">
                        <asp:Button ID="btninsert" runat="server" Text="SUBMIT" CssClass="btn btn-success" OnClick="btninsert_Click" Style="border-radius: 10px;"></asp:Button>
                    </div>
                     <div>
                        <asp:Label ID="lblduplicate" runat="server" Text="Please check duplicate" CssClass="text text-danger" Visible="false"></asp:Label>
                    </div>

                </div>
            </div>
        </div>

        <div class="row">
            <br />
            <div class="row">
                <div class="col-md-10">
                    <div>
                        <div style="margin-left:170px;">
                            <div class="row" style="box-shadow:2px 2px 2px 2px;padding:10px; margin:5px;">
                                <div class="col-md-2">

                                    <asp:DropDownList ID="cboPageSize" runat="server" Style="color:black; " CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboPageSize_SelectedIndexChanged" BackColor="WhiteSmoke">
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="5">5</asp:ListItem>
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
                                <div class="col-sm-1">
                                    <asp:Button ID="btnsearch" CausesValidation="false" runat="server" CssClass="btn btn-primary" OnClick="btnsearch_Click" Style="border-radius: 20px" Text="Search" /><br />
                                </div>
                                <div class="row" style="padding-right:360px;">
            <div class="text-right p-b-10">
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

                <asp:Repeater ID="rptcatinfo" runat="server" OnItemCommand="rptcatinfo_ItemCommand">
                    <HeaderTemplate>

                        <table class="table table-responsive table-bordered" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39);">

                            <tr style="background-color: #b52e31;">
                                <th>Category Name</th>
                                <th>Status</th>

                                <th>Action</th>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr style="background: white;">

                            <td><%#Eval("CategoryName") %></td>
                            <td><%#Eval("Status") %></td>

                            <td>
                                <asp:LinkButton ID="lnkupdate" runat="server" CommandArgument='<%#Eval("CategoryId") %>' ToolTip="Edit" CommandName="edit" CssClass="btn btn-primary" CausesValidation="false"><i class="fa fa-edit"></i></asp:LinkButton>
                                <asp:LinkButton ID="lnkstatus" runat="server" CommandArgument='<%#Eval("CategoryId") %>' ToolTip="Status" CommandName="status" CssClass="btn btn-success" CausesValidation="false"><i class="fa fa-anchor"></i></asp:LinkButton>
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
