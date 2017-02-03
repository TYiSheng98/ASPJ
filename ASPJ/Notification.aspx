<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="ASPJ.Notification" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
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
         .h{color:red;font-size: 20px;float:right;}
        .count{position: relative;left: -5px;top:5px;}
        .a{cursor:pointer;}
    </style>
    <%--insert the icon as button when integerated--%>
     <asp:HiddenField ID="NO" runat="server" />
    <script>
        <%--var icon = document.getElementById('<%=((Label)Master.FindControl("Note")).ClientID %>').innerHTML;
        alert(icon);--%>
        //var t = document.createTextNode("1");
        //icon.appendchild(t);
        if (document.getElementById("<%= NO.ClientID %>").value > "0") {
           document.getElementById("Span1").innerHTML = document.getElementById("<%= NO.ClientID %>").value;
        }
        function CLICK(clicked_id,type ,cid) {
            //alert(clicked_id);
            var clicked = document.getElementById(clicked_id);
            if (clicked.style.background != '#ffe0b3') {
                clicked.style.background = '#ffe0b3';
                
                __doPostBack('lala', clicked_id);
            }
            //link to jc comment
            if (type == "3") {
                //alert(cid);
                window.open("/Page.aspx?externalid=" + cid);
            }
            else if (type == "2") {
                window.open("/Inbox.aspx?externalid=" + cid);
            }
        }
           //function del(ID){
           //    var clicked = document.getElementById(ID);
           //    __doPostBack('haha', ID);
           // }
            

        

    </script>
   
    <asp:UpdatePanel ID="Refresh" runat="server">

        <ContentTemplate>
            <%--<div class="a">
                 <span class="glyphicon-bell h">
                     <span class="count" id="counter" runat="server"></span>
                 </span>
            </div>--%>
            <asp:Timer ID="TimerforN" runat="server" Interval="5000" OnTick="TimerforN_Tick"></asp:Timer>
            <h1 id="header" runat="server"></h1>
            <ul runat="server" id="tabs"  class="l">

            </ul>
            <asp:Label ID="loop" runat="server" Text=""></asp:Label>

        </ContentTemplate>



    </asp:UpdatePanel>
    <asp:Label ID="Inital" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <%--<asp:Label ID="TestLabel" runat="server" Text="Label"></asp:Label>--%>
    </asp:Content>
