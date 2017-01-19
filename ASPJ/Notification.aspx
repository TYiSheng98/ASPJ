<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="ASPJ.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:Button ID="Button1" runat="server" Text="Like gg page" />--%>
    <style>
        #tabs{
            border-color:red;
        }
        .ya{
            list-style: none;
            }
       
    </style>
   
    <asp:UpdatePanel ID="Refresh" runat="server">

        <ContentTemplate>
            <%--<asp:Timer ID="TimerforN" runat="server" Interval="10000" OnTick="TimerforN_Tick">
            </asp:Timer>--%>
            <asp:Label ID="loop" runat="server" Text=""></asp:Label>
            <ul runat="server" id="tabs">

            </ul>

        </ContentTemplate>



    </asp:UpdatePanel>
    <asp:Label ID="Inital" runat="server" Text="Label"></asp:Label>
    </asp:Content>
