<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="RPXLib.Data"%>

<asp:Content ID="handleResponseContent" ContentPlaceHolderID="MainContent" runat="server">
    <% string id = (string) TempData["id"]; %>
    <h2>You are now logged in via RPX</h2>
    <p>
        Your authentication provider identifier is : <%=id %>
    </p>
</asp:Content>
