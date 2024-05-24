<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="ProjectPSD.Views.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cart Page</h1>

    <asp:GridView ID="CartGV" runat="server" OnRowEditing="CartGV_RowEditing" OnRowDeleting="CartGV_RowDeleting" AutoGenerateColumns="False" DataKeyNames="UserId, StationeryId" >
        <Columns>
            <%--<asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="UserId, StationeryID"></asp:BoundField>
            <asp:BoundField DataField="StationeryId" HeaderText="Stationery Id" SortExpression="StationeryId"></asp:BoundField>--%>
            <asp:BoundField DataField="MsStationery.StationeryName" HeaderText="Stationery Name" SortExpression="Stationery.StationeryName"></asp:BoundField>
            <asp:BoundField DataField="MsStationery.StationeryPrice" HeaderText="Stationery Price" SortExpression="Stationery.StationeryPrice"></asp:BoundField>
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Cart.Quantity"></asp:BoundField>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ShowHeader="True" HeaderText="Actions"></asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="debug" runat="server" Text=""></asp:Label>
</asp:Content>
