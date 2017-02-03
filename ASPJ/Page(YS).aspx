<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page(YS).aspx.cs" Inherits="ASPJ.Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- below is put File owner @ file name--%>
    <asp:Label ID="Itemowner" runat="server" Text="3185322e-a097-4535-9dd5-dcda559fb58e"></asp:Label>
    <asp:Label ID="Session" runat="server" ></asp:Label>
    <%--payment part--%>
    <asp:Button ID="purchaseb" runat="server" Text="Purchase this Item!" OnClick="purchaseb_Click" BackColor="#99CCFF" />
   <%-- <asp:Button ID="purchaseb" runat="server" Text="Buy now!" OnClick="purchaseb_Click" />--%>
    <%--inbox part--%>
    <asp:Button ID="smsg" runat="server" Text="Send a message" OnClick="smsg_Click" />
    <br />
    <%--Review part--%>
    <h1>Comment this page!</h1>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="CButton" runat="server" Text="Comment" OnClick="CButton_Click" />
   <%-- <ul>
        <li>
            <asp:Button ID="Button1" runat="server" Text="Button" Width="135px" />
        </li>
    </ul>--%>
</asp:Content>
