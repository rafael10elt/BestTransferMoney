<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsersPage.aspx.cs" Inherits="BestTransferMoney.ManageUsersPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="form-inline">
        <br />
        <asp:TextBox runat="server" ID="txtSearch" placeholder="Search" CssClass="form-control"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-info" OnClick="btnSearch_Click" />
        &nbsp
            <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="btn btn-secondary" OnClick="btnReset_Click" />
    </div>
    <br />
    <br />
    <asp:GridView ID="gvUsers" runat="server" OnRowCommand="gvUsers_RowCommand" OnRowDeleting="gvUsers_RowDeleting" OnRowUpdating="gvUsers_RowUpdating"
        TabIndex="1" AutoGenerateColumns="False" DataKeyNames="UserId" CellPadding="4" ForeColor="#333333"
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="UserId" InsertVisible="False" SortExpression="UserId" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone" SortExpression="PhoneNumber" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Password" HeaderText="Password" Visible="false" SortExpression="Password" />
            <asp:BoundField DataField="Admin" HeaderText="Admin" SortExpression="Admin" />
            <asp:ButtonField ButtonType="Image" CommandName="More" Visible="false" ImageUrl="~/Images/ic_more_horiz.png" />
            <asp:ButtonField CommandName="Update" ButtonType="Button" Text="Update" ControlStyle-CssClass="btn btn-primary btn-sm" >
<ControlStyle CssClass="btn btn-primary btn-sm"></ControlStyle>
            </asp:ButtonField>
            <asp:ButtonField CommandName="Delete" ButtonType="Button" Text="Delete" ControlStyle-CssClass="btn btn-danger btn-sm" >
<ControlStyle CssClass="btn btn-danger btn-sm"></ControlStyle>
            </asp:ButtonField>
            <asp:ButtonField CommandName="Admin" ButtonType="Button" Text="Admin" ControlStyle-CssClass="btn btn-info btn-sm" >
<ControlStyle CssClass="btn btn-info btn-sm"></ControlStyle>
            </asp:ButtonField>
            <asp:ButtonField CommandName="Undo" ButtonType="Button" Text="Undo" ControlStyle-CssClass="btn btn-info btn-sm" >
<ControlStyle CssClass="btn btn-info btn-sm"></ControlStyle>
            </asp:ButtonField>
            
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <div>
        <br />
        <br />
        <asp:TextBox runat="server" ID="txtUserId" Width="100px" placeholder="User ID" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPhoneNumber" runat="server" placeholder="Phone Number" TextMode="Phone" Width="300px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirm Password" Width="400px" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblAdmin" Text="The user is an Admin?" runat="server"></asp:Label><br />
        <asp:RadioButton ID="rdYes" Text="Yes" runat="server"
            GroupName="admin" />
        <asp:RadioButton ID="rdNo" Text="No" runat="server"
            GroupName="admin" /><br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
        &nbsp
    <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-warning" OnClick="btnClear_Click" />
        &nbsp
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
