<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
	Log On Success
</asp:Content>

<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
	<style type="text/css">
		dt{font-weight: bold;}
	</style>

	<h2>Log On Success</h2>

	<p>You've successfully logged on!</p>

	<% var logonInfo = (EngageNet.Data.AuthenticationDetails)TempData["EngageLogonInfo"]; %>
	<% if(logonInfo != null){ %>
	<dl>
		<dt>Identifier</dt><dd><%= logonInfo.Identifier%></dd>
		<dt>Provider Name</dt><dd><%= logonInfo.ProviderName%></dd>
		<dt>Local Key</dt><dd><%= logonInfo.LocalKey%></dd>

		<dt>Address</dt><dd><%= logonInfo.Address.Formatted%></dd>
		<dt>Birthday</dt><dd><%= logonInfo.Birthday%></dd>
		<dt>Display Name</dt><dd><%= logonInfo.DisplayName%></dd>
		<dt>Email</dt><dd><%= logonInfo.Email%></dd>
		<dt>Gender</dt><dd><%= logonInfo.Gender%></dd>
		<dt>Name</dt><dd><%= logonInfo.Name.Formatted%></dd>
		<dt>Phone Number</dt><dd><%= logonInfo.PhoneNumber%></dd>
		<dt>Photo URL</dt><dd><%= logonInfo.PhotoUrl%></dd>
		<dt>Preferred Username</dt><dd><%= logonInfo.PreferredUsername%></dd>
		<dt>Url</dt><dd><%= logonInfo.Url%></dd>
		<dt>UTC Offset</dt><dd><%= logonInfo.UtcOffset%></dd>
		<dt>Verified Email</dt><dd><%= logonInfo.VerifiedEmail%></dd>
	</dl>
	<% } %>
</asp:Content>