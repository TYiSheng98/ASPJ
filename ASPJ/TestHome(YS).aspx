<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestHome(YS).aspx.cs" Inherits="ASPJ.TestHome_YS_" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="Username" runat="server"></asp:TextBox>
    <asp:TextBox ID="Password" runat="server"></asp:TextBox>
    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
</asp:Content>
