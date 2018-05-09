<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="BestTransferMoney.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div>
        <br />
        <br />
        <asp:Image ID="ImageLogin" runat="server" Width="223px" Height="203px" ImageUrl="~/Images/logimage.jpg" />
        <br />
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Login" TextMode="Email" CssClass="form-control" Width="400px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control" Width="400px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success" OnClick="btnLogin_Click" />
        &nbsp
        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-warning" OnClick="btnClear_Click" />

        &nbsp
       <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="btn btn-primary" OnClick="btnSignUp_Click"/>
     <asp:Label ID="lblEmailValidation" runat="server" Text="Email Incorrect!" CssClass="alert alert-danger" Visible="false"></asp:Label>
        <br /><br /><br />&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp &nbsp&nbsp        
        <asp:Label ID="lblPasswordValidation" runat="server" Text="Password Incorrect!" CssClass="alert alert-danger" Visible="false"></asp:Label>
    </div>
</asp:Content>
