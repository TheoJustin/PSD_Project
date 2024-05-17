<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ProjectPSD.Views.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Login page</h1>
    <hr />
    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
    <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
    <asp:TextBox ID="PasswordTB" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Remember Me"></asp:Label>
    <asp:CheckBox ID="RememberCB" runat="server" />
    <br />
    <asp:Button ID="submitBtn" runat="server" Text="Button" OnClick="submitBtn_Click" />
    <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
</asp:Content>
