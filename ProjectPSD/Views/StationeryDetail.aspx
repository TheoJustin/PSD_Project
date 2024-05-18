<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="StationeryDetail.aspx.cs" Inherits="ProjectPSD.Views.StationeryDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Stationery Detail</h1>
    <hr />

    <h3>Stationery Name</h3>
    <asp:Label ID="StationeryNameLbl" runat="server" Text=""></asp:Label>
    <hr />

    <h3>Stationery Price</h3>
    <asp:Label ID="StationeryPriceLbl" runat="server" Text=""></asp:Label>
    <hr />

    <asp:Label ID="qty" runat="server" Text="Quantity"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

    <asp:Button ID="Button1" runat="server" Text="Add To Cart" />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>
