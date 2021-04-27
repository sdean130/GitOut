<%@ Page Title="Main Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="GitOut.MainMenu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p>If you have not already registered for an account, you can do that <a href="Account/Register">here</a>.</p>
    <p>From here you can sign into GitOut by clicking on this link <a href="Account/Login">here</a>.</p>
</asp:Content>
