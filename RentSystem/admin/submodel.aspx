<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="submodel.aspx.cs" Inherits="RentSystem.admin.submodel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headercontent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
        <asp:HiddenField ID="hidsmid" runat="server" />
        <div class="col-sm-12 women_main" >
            <div class="row">
                <!-- Page Header -->

                <div class="col-lg-12" style="text-shadow: 10px 5px 5px #888888;">
                    <center><h1><b>Submodel</b></h1></center>
                    <hr />
                </div>
                <!--End Page Header -->
            </div>
            <div class="col-sm-6 fa-border" style="box-shadow: 2px 2px 4px 3px rgba(37, 37, 37, 0.39); padding: 30px; margin-left: 250px; margin-bottom: 50px; background-color: whitesmoke; border-color: black; border-radius: 10px;">
                <div class="col-sm-12">
                    <div class="row">
                        <div class="col-sm-4" style="margin-left: 10px;">
                            <label>Company Name</label>
                        </div>
                        <div class="col-sm-7">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control" Style="border-radius: 10px;" OnTextChanged="ddlCompany_TextChanged" AutoPostBack="True"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Company Name" InitialValue="-Select Company-" CssClass="text-danger" ControlToValidate="ddlCompany"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4" style="margin-left: 10px;">
                            <label>Model Name</label>

                        </div>
                        <div class="col-sm-7">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlModel" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Model Name" InitialValue="-Select Model-" CssClass="text-danger" ControlToValidate="ddlmodel"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="col-sm-12">
                            <div class="row">
                                <div class="col-sm-4">
                                    <label>Sub-Model Name</label>
                                    </div>
                                <div class="col-lg-7">
                                    <asp:TextBox ID="txtSmname" runat="server" CssClass="form-control" Style="border-radius: 10px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert Sub-Model" CssClass="text-danger" ControlToValidate="txtSmname"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12" style="padding-bottom: 15px; margin-left: 165px;" >
                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnsubmit_Click" />
                            </div>
                             <div>
                        <asp:Label ID="lblduplicate" runat="server" Text="Please check duplicate" CssClass="text text-danger" Visible="false"></asp:Label>
                    </div>

                        </div>
                    </div>
                    </div>
                </div>


                    <div class="row">
                        <br />
                        <%-- <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-2 text-right">
                        <label>SEARCH</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtsearch" runat="server"  CssClass="form-control" Style="border-radius: 25px;"></asp:TextBox>
                    </div>
                    <div class="col-sm-2">
                        <asp:Button ID="btnsearch" Text="SEARCH" OnClick="btnsearch_Click" runat="server" CssClass="btn btn-success" CausesValidation="false" Style="border-radius: 10px;"></asp:Button>
                    </div>
                </div>--%>
                        <div class="row">
                            <div class="col-md-9" style="margin-left:171px;"> 
                                <div class="white-box">
                                    <div class="row" style="box-shadow: 2px 2px 2px 2px; padding: 10px; margin: 5px;">
                                        <div class="col-md-2">

                                            <asp:DropDownList ID="cboPageSize" runat="server" Style="background-color: aliceblue; color: black" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboPageSize_SelectedIndexChanged">

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
                                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Style="border-radius: 20px; background-color: aliceblue; color: black"></asp:TextBox>
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
                            <asp:Repeater ID="rptSubModelInfo" runat="server" OnItemCommand="rptSubModelInfo_ItemCommand">

                                <HeaderTemplate>

                                    <table class="table table-responsive table-bordered"  style=" width: 750px; box-shadow: 2px 2px 2px 2px; padding: 10px; margin: 5px;">
                                        <tr style="background-color: #b52e31;">
                                            <th>Company Name</th>
                                            <th>Model Name</th>
                                            <th>Sub-Model Name</th>
                                            <th>Status</th>
                                            <th>Action</th>
                                        </tr>
                                </HeaderTemplate>

                                <ItemTemplate>
                                    <tr style="background-color: white;">
                                        <td><%#Eval("CompanyName") %></td>
                                        <td><%#Eval("ModelName") %></td>
                                        <td><%#Eval("SubModelName") %></td>
                                        <td><%#Eval("Status") %></td>

                                        <td>
                                            <asp:LinkButton ID="lnkupdate" runat="server" CommandArgument='<%#Eval("SubModelId") %>' CommandName="edit" ToolTip="Edit" CssClass="btn btn-primary " CausesValidation="false"><i class="fa fa-edit"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkstatus" runat="server" CommandArgument='<%#Eval("SubModelId") %>' CommandName="status" ToolTip="Status" CssClass="btn btn-success" CausesValidation="false"><i class="fa fa-anchor"></i></asp:LinkButton>
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
