<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="ProjectPSD.Views.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register Page</h1>
    <hr />
    <div>
        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="DOB"></asp:Label>
        <asp:Calendar ID="DobCalendar" runat="server" OnSelectionChanged="DobCalendar_SelectionChanged"></asp:Calendar>
        <asp:TextBox ID="SelectedDateTB" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
        <asp:RadioButtonList ID="RadioButtonListGender" runat="server">
            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
        <asp:TextBox ID="AddressTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label5" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="PasswordTB" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label6" runat="server" Text="Phone"></asp:Label>
        <asp:TextBox ID="PhoneTB" runat="server"></asp:TextBox>
    </div>
    <div style="color:red">
        <asp:Label ID="ErrorMsg" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click"/>
    </div>
    <hr />
</asp:Content>
