<%@ Page Title="Convert Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConvertPage.aspx.cs" Inherits="BestTransferMoney.ConvertPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div>
        <br />        
        <asp:Image ID="ImageLogin" runat="server" ImageUrl="~/Images/moneyimage.jpg" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblSend" runat="server" Text="You send exactly:" Font-Bold="True" Font-Italic="True"></asp:Label>
        <br /><br />
        <asp:TextBox ID="txtAmount" runat="server" TextMode="Number" Width="100px" Height="30px" placeholder="Amount $"></asp:TextBox>
        &nbsp&nbsp
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
        &nbsp&nbsp 
        <asp:DropDownList ID="ddlTo" runat="server" CssClass="btn btn-primary dropdown-toggle dropdown-toggle-split">
            <asp:ListItem>TO</asp:ListItem>
            <asp:ListItem Value="CAD$">Canadian Dollar - CAD$</asp:ListItem>
            <asp:ListItem Value="US$">American Dollar - US$</asp:ListItem>
            <asp:ListItem Value="R$">Real - R$</asp:ListItem>
        </asp:DropDownList>
        <br /><br />
        <asp:Button ID="btnCalculate" runat="server" Text="Check" CssClass="btn btn-info btn-sm" OnClick="btnCalculate_Click" />
        <br /><br />               
        <asp:Label ID="lblDate" runat="server" Visible="false" Text=""></asp:Label>
        <br />        
        
        <asp:Label ID="lblCalculation" runat="server" Text="You must fill all the form." Visible="False" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
        <br /><br />
        
        <asp:Button ID="btnSave" runat="server" Text="Confirm" CssClass="btn btn-success" OnClientClick='return confirm("Order added Succesfully!");' OnClick="btnSave_Click" />
        &nbsp
        <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary" OnClick="btnClear_Click" />
    </div>
</asp:Content>
