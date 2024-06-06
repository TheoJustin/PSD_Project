﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ProjectPSD.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home Page</h1>

    <asp:GridView ID="StationeryGV" runat="server" OnRowEditing="UpdateRow" AutoGenerateColumns="false" OnSelectedIndexChanged="StationeryGV_SelectedIndexChanged" OnRowDeleting="DeleteRow">
        <Columns>
            <asp:BoundField DataField="StationeryID" HeaderText="StationeryID" SortExpression="StationeryID"></asp:BoundField>
            <asp:BoundField DataField="StationeryName" HeaderText="StationeryName" SortExpression="StationeryName"></asp:BoundField>
            <asp:BoundField DataField="StationeryPrice" HeaderText="StationeryPrice" SortExpression="StationeryPrice"></asp:BoundField>
            <asp:CommandField  ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions"></asp:CommandField>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button" ShowHeader="True" HeaderText="View Detail"></asp:CommandField>
        </Columns>
    </asp:GridView>

    <hr />
    <asp:Button ID="InsertBtn" runat="server" Text="Insert New Stationery" OnClick="InsertBtn_Click"/>
    <asp:Label ID="username" runat="server" Text=""></asp:Label>
    <asp:Label ID="password" runat="server" Text=""></asp:Label>
</asp:Content>
