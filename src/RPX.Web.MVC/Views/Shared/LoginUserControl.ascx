<%@ Import Namespace="RPX.Web.MVC.Extensions"%>
<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ <%= Html.ActionLink("Sign Out", "SignOut", "RPXAuthentication")%> ]
<%
    }
    else {
%> 
        [ <a class="rpxnow" onclick="return false;" href="https://rpxtest.rpxnow.com/openid/v2/signin?token_url=<%=Html.RPXTokenUrl() %>">Sign In</a> ]
        <script src="https://rpxnow.com/openid/v2/widget" type="text/javascript"></script>
        <script type="text/javascript">
            RPXNOW.token_url = '<%=Html.RPXTokenUrl() %>';
            RPXNOW.realm = '<%=Html.RPXRealm() %>';
            RPXNOW.overlay = true;
        </script>
<%
    }
%>



