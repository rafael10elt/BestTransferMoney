<%@ Page Title="Sign Up Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="BestTransferMoney.SignUpPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <asp:Image ID="ImageSignUp" runat="server" ImageUrl="~/Images/signimage.jpg" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPhoneNumber" runat="server" placeholder="Phone Number" TextMode="Phone" Width="300px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirm Password" TextMode="Password" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClientClick='return confirm("User added Succesfully!");' OnClick="btnSave_Click" />
        &nbsp
    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-warning" OnClick="btnClear_Click" />
        &nbsp
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
        <asp:CompareValidator runat="server" ID="PasswordValidator" ErrorMessage="Password does not match!" CssClass="alert alert-danger" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
    </div>
</asp:Content>
