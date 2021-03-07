<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="reg-result.aspx.cs" Inherits="RentSystem.reg_rersult" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodycontent" runat="server">
    <h3 style="color:black;">OTP SEND YOUR REGISTERED EMAIL ID  <%= Convert.ToString(Request["EID"]) %><a href="Login.aspx">Log in</a></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footercontent" runat="server">
</asp:Content>
