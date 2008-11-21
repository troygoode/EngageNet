using System;
using System.Web.Mvc;

namespace RPX.Web.MVC.Extensions
{
    public static class RPXHtmlExtensions
    {
        public static string RPXTokenUrl(this HtmlHelper htmlHelper)
        {
            throw new Exception("You need to supply the full callback url. Localhost is fine for the example application, just remove this exception.");
            //TODO: Return the full url to the action that handles the RPX token response
            return "http://localhost:1291/RPXAuthentication/HandleResponse";
        }

        public static string RPXRealm(this HtmlHelper htmlHelper)
        {
            throw new Exception("Once you have set your realm value, this exception can then be removed.");
            //TODO: Get the realm value from your RPX account configuration - https://rpxnow.com/account
            return "your.rpx.realm";            
        }
    }
}