<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="StationeryDetailPage.aspx.cs" Inherits="ProjectPSD.Views.StationeryDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Stationery Detail</h1>
    <hr />

    <h3>Stationery Name</h3>
    <asp:Label ID="StationeryNameLbl" runat="server" Text=""></asp:Label>
    <hr />

    <h3>Stationery Price</h3>
    <asp:Label ID="StationeryPriceLbl" runat="server" Text=""></asp:Label>
    <hr />

    <asp:Label ID="QtyLbl" runat="server" Text="Quantity" Visible="false"></asp:Label>
    <asp:TextBox ID="QtyTB" runat="server" Visible="false"></asp:TextBox>

    <asp:Button ID="AddToCartBtn" runat="server" Text="Add To Cart" Visible="false" OnClick="AddToCartBtn_Click"/>
    <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
</asp:Content>
