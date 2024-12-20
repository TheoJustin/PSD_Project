﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionPage.aspx.cs" Inherits="ProjectPSD.Views.TransactionPage" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Transaction Page</h1>
    <asp:GridView ID="TransactionGV" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="TransactionGV_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
            <asp:BoundField DataField="MsUser.UserName" HeaderText="Customer Name" SortExpression="MsUser.UserName" />
            <asp:CommandField HeaderText="Transaction Detail" ShowHeader="True" ShowSelectButton="True" SelectText="See Detail"  />
        </Columns>
    </asp:GridView>
    
</asp:Content>
