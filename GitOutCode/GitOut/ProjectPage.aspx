<%@ Page Title="Project Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectPage.aspx.cs" Inherits="GitOut.ProjectPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" runat="server" media="screen" href="~/OverView.css" />
	<h2><%: Title %></h2>
    <div >
        <asp:Button ID="newProjectBtn" runat="server" Text="New Project" OnClick="LoadNewPage" CssClass="btn btn-default"/>
    </div>

    <div>
        <ul class="listed" id="ProjectList" runat="server" OnLoad="AddData"></ul>
    </div>
</asp:Content>
