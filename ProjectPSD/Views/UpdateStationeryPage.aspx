<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateStationeryPage.aspx.cs" Inherits="ProjectPSD.Views.UpdateStationeryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Update Stationery</h1>
    <hr />

    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="PriceTB" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="UpdateBtn" runat="server" Text="Update Stationery" OnClick="UpdateBtn_Click"/>
    <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
</asp:Content>
