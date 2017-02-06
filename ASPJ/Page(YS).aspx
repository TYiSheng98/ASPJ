<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page(YS).aspx.cs" Inherits="ASPJ.Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
     .rfv
    {
        padding-left:10px;
        color:#B50128;
        font-size:12px;
        font-family: Verdana, Tahoma, Arial;
        font-weight:bold;
    }
        </style>
    <%-- below is put File owner @ file name--%>
    <div class="jumbotron">
    <h1 runat="server" id="filename"></h1>
        <a href="user.aspx"<asp:Label ID="Itemowner" runat="server" Text="by w"></asp:Label></a>
        </div>
    <asp:HiddenField ID="Itemownerid" runat="server" Value="3185322e-a097-4535-9dd5-dcda559fb58e"/>
    <%--<asp:Label ID="Itemowner" runat="server" Text=""></asp:Label>--%>
    
    <%--<asp:Label ID="Session" runat="server" ></asp:Label>--%>
    <%--payment part--%>
    <asp:Button ID="purchaseb" runat="server" Text="Purchase this Item!" OnClick="purchaseb_Click" CssClass="btn btn-success" />
   <%-- <asp:Button ID="purchaseb" runat="server" Text="Buy now!" OnClick="purchaseb_Click" />--%>
    <%--inbox part--%>
    <asp:Button ID="smsg" runat="server" Text="Send a message" OnClick="smsg_Click" CssClass="btn btn-danger" />
    <br />
    <%--Review part--%>
    <h1>Comment this page!</h1>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="CButton" runat="server" Text="Comment" OnClick="CButton_Click" CssClass="btn btn-primary" validationgroup="a" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field is required!" Display="Dynamic" SetFocusOnError="True" CssClass="rfv"  ControlToValidate="TextBox1" validationgroup="a"></asp:RequiredFieldValidator>
   <%-- <ul>
        <li>
            <asp:Button ID="Button1" runat="server" Text="Button" Width="135px" />
        </li>
    </ul>--%>
</asp:Content>
