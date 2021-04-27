<%@ Page Title="New Project" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="GitOut.NewProject" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="NewProjectName" CssClass="col-md-2 control-label">Project Name</asp:Label>
            <div class=" col-md-10">
                <asp:TextBox runat="server" ID="NewProjectName" CssClass="form-control" TextMode="SingleLine" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NewProjectName"
                    CssClass="text-danger" ErrorMessage="The project name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ProjectDescription" CssClass="col-md-2 control-label">Project Description</asp:Label>
            <div class=" col-md-10">
                <asp:TextBox runat="server" ID="ProjectDescription" CssClass="form-control" TextMode="MultiLine" />
            </div>
        </div>
		<div class="form-group">
			<div class="col-md-offset-2 col-md-10">
				<input type="radio" name="view" value="Public" checked/>Public<br />
				<p>Any user can view this project</p>
				<input type="radio" name="view" value="Private"/>Private<br />
				<p>Only people you share with can view this project</p>
			</div>
		</div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Create_Project" Text="Create New Project" CssClass="btn btn-default" />
				<asp:Button runat="server" OnClick="ReturnToProject" Text="Cancel" CssClass="btn btn-default" CausesValidation="False" />
            </div>
        </div>
		
    </div>
</asp:Content>
