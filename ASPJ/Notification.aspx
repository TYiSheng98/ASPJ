﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="ASPJ.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<asp:Button ID="Button1" runat="server" Text="Like gg page" />--%>
    <style>
        #tabs{
            border-color:red;
        }
        .ya{
            list-style: none;
            }
       .l li{ width:35%;list-style:none;position: relative;margin:2% auto;height:130px;}
        .l li h5{ position:relative;top:20%;font-size:1.5em;text-align:center;}
         .l li h6{text-align:right;}
         .l li:hover{cursor:pointer;}
    </style>
    <script>
        function ha(clicked_id) {
            //alert(clicked_id);
            var clicked = document.getElementById(clicked_id);
            if (clicked.style.background != '#F5F5DC') {
                clicked.style.background = '#F5F5DC';
                __doPostBack('lala', clicked_id);
            }
           function del(ID){
               var clicked = document.getElementById(ID);
               __doPostBack('haha', ID);
            }
            

        }

    </script>
   
    <asp:UpdatePanel ID="Refresh" runat="server">

        <ContentTemplate>
            <%--<asp:Timer ID="TimerforN" runat="server" Interval="2000" OnTick="TimerforN_Tick"></asp:Timer>--%>
            <asp:Label ID="loop" runat="server" Text=""></asp:Label>
            <h1 id="header" runat="server"></h1>
            <ul runat="server" id="tabs"  class="l">

            </ul>

        </ContentTemplate>



    </asp:UpdatePanel>
    <asp:Label ID="Inital" runat="server" Text="Label"></asp:Label>
    </asp:Content>
