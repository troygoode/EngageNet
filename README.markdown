The [JanRain Engage](http://rpxnow.com/) authentication service is a public API to simplify the integration of single sign-on via identity providers like Google, Facebook, Twitter, and OpenID. This project is a wrapper library for the Engage service written in .Net 4.0.

Included is an ASP.Net MVC 2 sample web site to demonstrate integrating the library into your MVC website.

# Getting Started (Asp.Net MVC)

## Step 1: Add reference to EngageNet.dll and EngageNet.Mvc.dll

## Step 2: Configure Engage

Somewhere in your application startup you'll need to configure the EngageProvider by giving it your Engage application domain (your-site.rpxnow.com) and your API key. Both are available on your dashboard when you're logged in to to [RPXNow.com](http://rpxnow.com/). Here is an example of the configuration:
<pre>
EngageProvider.ApplicationDomain = "your-site-name.rpxnow.com"; //TODO: set your site's Application Domain
EngageProvider.Settings = new EngageNetSettings("YOUR_API_KEY"); //TODO: set your API key
</pre>

## Step 3: Create a new controller named "EngageController". Add the following code to the controller:
<pre>
public ViewResult LogOn()
{
	return View();
}
</pre>

## Step 4A: Create the LogOn view. If you want to have a link that pops up the Engage overlay for logging in, use this example code:
<pre>
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="EngageNet.Mvc.Html" %>

<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
	Log On
</asp:Content>

<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Log On</h2>

	<p><%= Html.Engage().LogOnLink("Log On", "ProcessLogOn", "Engage") %></p>
	<%= Html.Engage().LogOnLinkScript() /*TODO: ideally this script include should be moved to the end of your page*/ %>
</asp:Content>
</pre>

## Step 4B: Create the LogOn view. If you want to have an embedded version of the Engage login, use this example code:
<pre>
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="EngageNet.Mvc.Html" %>

<asp:Content ID="title" ContentPlaceHolderID="TitleContent" runat="server">
	Log On
</asp:Content>

<asp:Content ID="main" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Log On</h2>

	<%= Html.Engage().InlineWidget("ProcessLogOn", "Engage") %>
</asp:Content>
</pre>

## Step 5: In the EngageController, you'll need to process the data returned from JanRain's servers. Add the following action and constructors:
<pre>
private readonly IEngageNet _engage;

public EngageController(IEngageNet engage)
{
	_engage = engage;
}

public EngageController() : this(EngageProvider.Build())
{
}

public RedirectToRouteResult ProcessLogOn(string token)
{
	if (string.IsNullOrEmpty(token))
		return RedirectToAction("LogOnCancelled");

	var authenticationDetails = _engage.GetAuthenticationDetails(token, true);
	FormsAuthentication.SetAuthCookie(authenticationDetails.Identifier, true);

	return RedirectToAction("LogOnSuccess");
}
</pre>

## Step 6: Create LogOnCancelled and LogOnSuccess views, or have those scenarios redirect to existing actions.

Check out the [wiki](http://wiki.github.com/TroyGoode/EngageNet/) for more details.