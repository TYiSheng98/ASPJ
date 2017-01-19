<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="ASPJ.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:Button ID="Button1" runat="server" Text="Like gg page" />--%>
    <asp:UpdatePanel ID="Refresh" runat="server">

        <ContentTemplate>
            <asp:Timer ID="TimerforN" runat="server" Interval="1000" OnTick="TimerforN_Tick">
            </asp:Timer>
            <asp:Label ID="loop" runat="server" Text="Label"></asp:Label>
            <ul runat="server" id="tabs">

            </ul>
        </ContentTemplate>



    </asp:UpdatePanel>
    <asp:Label ID="Inital" runat="server" Text="Label"></asp:Label>
    </asp:Content>
