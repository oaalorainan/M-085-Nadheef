<%@ Page Title="" Language="C#" MasterPageFile="~/Mp.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HHackathon_Waste.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder111" runat="server">
    User Name:
    <br />
    <asp:TextBox ID="tbUser" runat="server" />
    <br /><br />
    Password:
    <br />
    <asp:TextBox ID="tbPass" runat="server" />
    <br /><br />
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
</asp:Content>
