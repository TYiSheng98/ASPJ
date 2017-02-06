<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="ASPJ.SendMessage" %>
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
    <fieldset>
    <legend>Send Message</legend>
    <div class="form-group">
      <label for="inputEmail" class="col-lg-2 control-label">Sender</label>
        <%--<asp:Label ID="inputEmail" runat="server" Text="Label" CssClass="col-lg-2 control-label"></asp:Label>--%>
      <div class="col-lg-10">
        <%--<input type="text" class="form-control" id="inputEmail" placeholder="Email">--%>
          <asp:TextBox ID="inputEmail" runat="server" CssClass="form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This field is required!" Display="Dynamic" SetFocusOnError="True" CssClass="rfv" validationgroup="a"  ControlToValidate="inputEmail"></asp:RequiredFieldValidator>
      </div>
    </div>
        <br />
        <div class="form-group">
      <label class="col-lg-2 control-label">RE:</label>
        
      <div class="col-lg-10">
        
          <asp:TextBox ID="subject" runat="server" CssClass="form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" SetFocusOnError="True" CssClass="rfv" ErrorMessage="This field is required!"  validationgroup="a" ControlToValidate="subject"></asp:RequiredFieldValidator>
      </div>
    </div>
        <br />
    <%--<div class="form-group">
      <label for="inputPassword" class="col-lg-2 control-label">Password</label>
      <div class="col-lg-10">
        <input type="password" class="form-control" id="inputPassword" placeholder="Password">
        <div class="checkbox">
          <label>
            <input type="checkbox"> Checkbox
          </label>
        </div>
      </div>
    </div>--%>
    <div class="form-group">
      <label for="textArea" class="col-lg-2 control-label">Message</label>
      <div class="col-lg-10">
          <asp:TextBox ID="textArea" runat="server" CssClass="form-control" placeholder="Write Your Message here!" Rows="4" TextMode="MultiLine"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" SetFocusOnError="True" CssClass="rfv" ErrorMessage="This field is required!" validationgroup="a"  ControlToValidate="textArea"></asp:RequiredFieldValidator>
        <%--<textarea class="form-control" rows="3" id="textArea"></textarea>--%>
       <%-- <span class="help-block">A longer block of help text that breaks onto a new line and may extend beyond one line.</span>--%>
      </div>
   </div>
    <%-- <div class="form-group">
      <label class="col-lg-2 control-label">Radios</label>
      <div class="col-lg-10">
        <div class="radio">
          <label>
            <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked="">
            Option one is this
          </label>
        </div>
        <div class="radio">
          <label>
            <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">
            Option two can be something else
          </label>
        </div>
      </div>
    </div>--%>
    <%--<div class="form-group">
      <label for="select" class="col-lg-2 control-label">Selects</label>
      <div class="col-lg-10">
        <select class="form-control" id="select">
          <option>1</option>
          <option>2</option>
          <option>3</option>
          <option>4</option>
          <option>5</option>
        </select>
        <br>
        <select multiple="" class="form-control">
          <option>1</option>
          <option>2</option>
          <option>3</option>
          <option>4</option>
          <option>5</option>
        </select>
      </div>
    </div>--%>
    <div class="form-group">
      <div class="col-lg-10 col-lg-offset-2">
        <%--<button type="reset" class="btn btn-default">Cancel</button>
        <button type="submit" class="btn btn-primary">Submit</button>--%>
          <asp:Button ID="ResetB" runat="server" Text="Reset" CssClass="btn btn-default" OnClick="ResetB_Click" />
          <asp:Button ID="SendB" runat="server" Text="Send" CssClass="btn btn-primary" OnClick="SendB_Click" validationgroup="a" />
      </div>
    </div>
  </fieldset>
</asp:Content>
