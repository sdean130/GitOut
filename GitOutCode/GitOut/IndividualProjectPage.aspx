<%@ Page Title="Individual Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="IndividualProjectPage.aspx.cs" Inherits="GitOut.IndividualProjectPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link rel="stylesheet" runat="server" media="screen" href="~/OverView.css" />
    <div class="main">
        <h2 id="TitleHeader"></h2>
        <ul class="listed" id="ProjectFiles" OnLoad="listLoad" runat="server"></ul>
        <p>Here is some text</p>
    </div>
    <div>
        <asp:Button runat="server" Text="Download" OnClick="downloadFiles" CssClass="btn btn-default"/>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button runat="server" Text="Upload" OnClick="uploadFiles" CssClass="btn btn-default"/>
        <br />
        <asp:Label runat="server" ID="StatusLabel" Text="Upload Status: " />
    </div>
</asp:Content>
