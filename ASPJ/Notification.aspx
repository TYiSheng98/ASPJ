<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Notification.aspx.cs" Inherits="ASPJ.Notification" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<asp:Button ID="Button1" runat="server" Text="Like gg page" />--%>
    <style>
        #tabs {
            border-color: red;
        }

        .ya {
            list-style: none;
        }

        .l li {
            width: 35%;
            list-style: none;
            position: relative;
            margin: 2% auto;
            height: 130px;
        }

            .l li h5 {
                position: relative;
                top: 20%;
                font-size: 1.5em;
                text-align: center;
            }

            .l li h6 {
                text-align: right;
            }

            .l li:hover {
                cursor: pointer;
            }

        .h {
            color: red;
            font-size: 20px;
            float: right;
        }

        .count {
            position: relative;
            left: -5px;
            top: 5px;
        }

        .a {
            cursor: pointer;
        }

        .modal-footer {
            margin-top: 0px;
        }
        .button {
  padding: 15px 25px;
  font-size: 24px;
  text-align: center;
  cursor: pointer;
  outline: none;
  color: #fff;
  background-color: #4CAF50;
  border: none;
  border-radius: 15px;
  box-shadow: 0 9px #999;
}
.buttonM{background-color:#4ea0e8;}
.buttonD{background-color:#e54242}
.buttonM:hover {background-color: #3a8ad1;}
.buttonD:hover {background-color:#d13232;}
        .button:active {
            box-shadow: 0 5px #666;
            transform: translateY(4px);
        }
        .buttonM:active{background-color: #3a8ad1;}
        .buttonM:active {background-color: #d13232; }
        .closeb{
            background-color:#ff1a1a;color:white;
        }
        .closeb:hover{background-color:#e60000;color:white;}
        .confirmb{background-color: #4CAF50;color:white;}
        .confirmb:hover{background-color: #3e8e41;color:white;}
    </style>
    
    <script>
        <%--var icon = document.getElementById('<%=((Label)Master.FindControl("Note")).ClientID %>').innerHTML;
        alert(icon);--%>
        //var t = document.createTextNode("1");
        //icon.appendchild(t);
       <%-- if (document.getElementById("<%= NO.ClientID %>").value > "0") {
            document.getElementById("Span1").innerHTML = document.getElementById("<%= NO.ClientID %>").value;
        }--%>
        function CLICK(clicked_id, type, cid) {
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="alert alert-success" id="header" runat="server" style="font-size:2em;font-weight:bold;">
                <%--<strong>Info!</strong> This alert box could indicate a neutral informative change or action.--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Trigger the modal with a button -->
    <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>--%>
     <asp:Button runat="server" ID="ALL" OnClick="ALL_Click" CssClass=" button buttonM" Text="Mark All as Read"/>
    <asp:Button ID="DEl" runat="server" Text="Delete All" data-toggle="modal" data-target="#myModal" CssClass=" button buttonD" />
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Confirm delete all?</h4>
                </div>
                <%--<div class="modal-body">
          <p>You have one notification!</p>
            <p>Are u sure?</p>
        </div>--%>
                <div class="modal-footer">
                    <asp:Button ID="DeleteB" runat="server" Text="Confirm" OnClick="DeleteB_Click" CssClass="btn btn-default confirmb" />
                    <button type="button" class="btn btn-default closeb"  data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>


    <asp:UpdatePanel ID="Refresh" runat="server">

        <ContentTemplate>
            <%--<div class="a">
                 <span class="glyphicon-bell h">
                     <span class="count" id="counter" runat="server"></span>
                 </span>
            </div>--%>
            <asp:Timer ID="TimerforN" runat="server" Interval="5000" OnTick="TimerforN_Tick"></asp:Timer>
            <%--<h1 id="header" runat="server"></h1>--%>
            
            <ul runat="server" id="tabs" class="l">
            </ul>
            <asp:Label ID="loop" runat="server" Text=""></asp:Label>

        </ContentTemplate>



    </asp:UpdatePanel>
    <asp:Label ID="Inital" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <%--<asp:Label ID="TestLabel" runat="server" Text="Label"></asp:Label>--%>
</asp:Content>
