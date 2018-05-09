<%@ Page Title="Manage Orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageOrdersPage.aspx.cs" Inherits="BestTransferMoney.ManageOrdersPage" %>

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
    <asp:GridView ID="gvOrders" runat="server" OnRowDeleting="gvOrders_RowDeleting" OnRowUpdating="gvOrders_RowUpdating"
        TabIndex="1" AutoGenerateColumns="False" DataKeyNames="OrderId" CellPadding="4" ForeColor="#333333"
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="OrderId" InsertVisible="False" ReadOnly="True" SortExpression="OrderId" />
            <asp:BoundField DataField="UserUserId" HeaderText="UserUserId" SortExpression="UserUserId" />
            <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
            <asp:BoundField DataField="CurrencyFrom" HeaderText="CurrencyFrom" SortExpression="CurrencyFrom" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
            <asp:BoundField DataField="CurrencyTo" HeaderText="CurrencyTo" SortExpression="CurrencyTo" />
            <asp:BoundField DataField="AmountTotal" HeaderText="Amount Total" SortExpression="AmountTotal" />
            <asp:ButtonField ButtonType="Image" CommandName="More" Visible="false" ImageUrl="~/Images/ic_more_horiz.png" />
            <asp:ButtonField CommandName="Update" ButtonType="Button" Text="Update" ControlStyle-CssClass="btn btn-primary btn-sm" />
            <asp:ButtonField CommandName="Delete" ButtonType="Button" Text="Delete" ControlStyle-CssClass="btn btn-danger btn-sm" />
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
    <br />
    <asp:TextBox runat="server" ID="txtOrderId" placeholder="Order ID" Width="130px" ReadOnly="true" CssClass="form-control"></asp:TextBox>
    <br />
     <asp:Label ID="lblSend" runat="server" Text="You send exactly:" Font-Bold="True" Font-Italic="True"></asp:Label>
    <br /><br />
    <asp:TextBox ID="txtAmount" runat="server" Width="100px" Height="30px" placeholder="Amount $"></asp:TextBox>
    &nbsp
    <asp:DropDownList ID="ddlFrom" runat="server" CssClass="btn btn-primary dropdown-toggle dropdown-toggle-split">
        <asp:ListItem>FROM</asp:ListItem>
        <asp:ListItem Value="CAD$">Canadian Dollar - CAD$</asp:ListItem>
        <asp:ListItem Value="US$">American Dollar - US$</asp:ListItem>
        <asp:ListItem Value="R$">Real - R$</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblRecipient" runat="server" Text="Recipient gets" Font-Bold="True" Font-Italic="True"></asp:Label>
    <br /><br />
    <asp:TextBox ID="txtTotal" runat="server" Width="150px" placeholder="Total $" ReadOnly="true" Height="30px"></asp:TextBox>
    &nbsp
    <asp:DropDownList ID="ddlTo" runat="server" CssClass="btn btn-primary dropdown-toggle dropdown-toggle-split">
        <asp:ListItem>TO</asp:ListItem>
        <asp:ListItem Value="CAD$">Canadian Dollar - CAD$</asp:ListItem>
        <asp:ListItem Value="US$">American Dollar - US$</asp:ListItem>
        <asp:ListItem Value="R$">Real - R$</asp:ListItem>
    </asp:DropDownList>
    <br /><br />    
    <asp:Button ID="btnCalculate" runat="server" Text="Check" CssClass="btn btn-info btn-sm" OnClick="btnCalculate_Click" />
    <br />
    <br />
    <asp:Label ID="lblCalculation" runat="server" Text="You must fill all the form." Visible="False" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
    <br />
    <br />
    
    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
    &nbsp
        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary" OnClick="btnClear_Click" />
    &nbsp
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
</asp:Content>
