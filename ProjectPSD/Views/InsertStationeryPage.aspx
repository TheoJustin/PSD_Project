<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertStationeryPage.aspx.cs" Inherits="ProjectPSD.Views.InsertPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Insert Stationery</h1>
    <hr />

    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="Label2" runat="server" Text="Price"></asp:Label>
    <asp:TextBox ID="PriceTB" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="InsertBtn" runat="server" Text="Insert" OnClick="InsertBtn_Click"/>
    <asp:Label ID="errMsg" runat="server" Text=""></asp:Label>
</asp:Content>
