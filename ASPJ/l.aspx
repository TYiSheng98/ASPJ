<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="l.aspx.cs" Inherits="ASPJ.l" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .l li{ width:35%;background-color:lightblue;list-style:none;position: relative;margin:2% auto;height:100px;}
        .l li h5{ position:relative;top:20%;font-size:1.5em;text-align:center;}
        .h{color:red;font-size: 20px;float:right;}
        .count{position: relative;left: -5px;top:5px;}
        .a{cursor:pointer;}
    </style>
    <div class="a">
                 <span class="glyphicon-bell h">
                     <span class="count">3</span>
                 </span>
            </div>
    <ul class="l" runat="server" id="hi">
        <li  id="oo" runat="server" > 
            <h5>Someone purchased your product </h5>
        </li>
        <li> 
            <h5>Someone purchased your product </h5>
        </li>
        
    </ul>

    
</asp:Content>
