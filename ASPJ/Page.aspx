<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="ASPJ.Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Itemowner" runat="server" Text="gg"></asp:Label>
    <asp:Button ID="likeb" runat="server" Text="Like this Item!" OnClick="likeb_Click" BackColor="#99CCFF" />
    <asp:Button ID="purchaseb" runat="server" Text="Buy now!" OnClick="purchaseb_Click" />
    <asp:Button ID="commb" runat="server" Text="Commission" OnClick="commb_Click" />

    <ul>
        <li>
            <asp:Button ID="Button1" runat="server" Text="Button" Width="135px" />
        </li>
    </ul>
</asp:Content>
