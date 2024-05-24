<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateCartPage.aspx.cs" Inherits="ProjectPSD.Views.UpdateCartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Cart</h1>
    <hr />

    <asp:Label ID="Label1" runat="server" Text="Name : "></asp:Label>
    <asp:Label ID="StationeryName" runat="server" Text=""></asp:Label>
    <br />

    <asp:Label ID="Label3" runat="server" Text="Price : "></asp:Label>
    <asp:Label ID="StationeryPrice" runat="server" Text=""></asp:Label>
    <br />

    <asp:Label ID="Label2" runat="server" Text="Quantity : "></asp:Label>
    <asp:TextBox runat="server" ID="qtyTB" />
    <br />

    <asp:Button ID="UpdateBtn" runat="server" Text="Update Cart" OnClick="UpdateBtn_Click"/>
    <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
</asp:Content>
