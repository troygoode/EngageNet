<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="EngageNet.Mvc.Html" %>

<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
	Log On
</asp:Content>

<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">

	<h2>Log On</h2>

	<h3>Overlay Exampe</h3>
	<p><%= Html.Engage().LogOnLink("Log On", "ProcessLogOn", "Engage") %></p>
	<%= Html.Engage().LogOnLinkScript() /*TODO: ideally this script include should be moved to the end of your page*/ %>

	<h3>Embedded Example</h3>
	<%= Html.Engage().InlineWidget("ProcessLogOn", "Engage") %>

</asp:Content>