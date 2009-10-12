using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using RPXLib;
using RPXLib.Data;
using RPXLib.Interfaces;

namespace RPX.Web.MVC.Controllers
{
    public class RPXAuthenticationController : Controller
    {
        /// <summary>
        /// Don't forget to map a route to this controller, if you decide to use this base implementation
        /// Check the global.asax.cs file for example routing
        /// </summary>
        
        private readonly IRPXService rpxService;

        public RPXAuthenticationController()
        {
            throw new Exception("Once you have confirmed the base url value, this exception can then be removed.");
            //TODO: Confirm the base url from your RPX account configuration - https://rpxnow.com/account
            const string baseUrl = "https://rpxnow.com/api/v2/";

            throw new Exception("Once you have set your api key value, this exception can then be removed.");
            //TODO: Get the api key from your RPX account configuration - https://rpxnow.com/account
            const string apiKey = "your_key_goes_here";

            //if you need to access the service via a web proxy set the proxy details here
            const IWebProxy webProxy = null;

            var settings = new RPXApiSettings(baseUrl, apiKey, webProxy);
            rpxService = new RPXService(settings);
        }

        /// <summary>
        /// Pretty please use a Dependency Injection framework and 
        /// register the implementation of this interface so it can 
        /// be resolved for you automatically in the constructor.
        /// 
        /// It is for your own good!
        /// </summary>
        public RPXAuthenticationController(IRPXService rpxService)
        {
            this.rpxService = rpxService;
        }

        public ActionResult HandleResponse(string token)
        {
            //according to the spec, it is possible to get here without a token
            //which means that the user cancelled the login request
            if (string.IsNullOrEmpty(token))
                return View("LoginCancelled");

            //This service call will throw an exception if it fails. 
            //You may want to catch it explicitly.
            var authenticationDetails = rpxService.GetAuthenticationDetails(token, true);
            TempData["id"] = authenticationDetails.Identifier;

            SignIn(GetLocalKey(authenticationDetails), true);

            return RedirectToAction("SignedIn", "RPXAuthentication");
        }

        public ViewResult SignedIn()
        {
            return View("SignedIn");
        }

        public RedirectToRouteResult SignOut()
        {
            SignOutCurrentUser();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Use this method to map the openId identifier to something in your local domain. 
        /// It is possible that you may have already mapped this user, which you can 
        /// confirm by checking the LocalKey property of the AuthenticationDetails.
        /// </summary>
        private static string GetLocalKey(RPXAuthenticationDetails authenticationDetails)
        {
            if (string.IsNullOrEmpty(authenticationDetails.LocalKey))
            {

                throw new Exception("Once you have set your local domain mapping functionality, this exception can then be removed.");
                //TODO: Map the openId identifier to your local domain
                //TODO: This would also be a great place to interrogate the returned details - name, email etc.
                return "looked_up_local_key";
            }

            // previously mapped
            return authenticationDetails.LocalKey;
        }

        private static void SignIn(string localId, bool rememberMe)
        {
            FormsAuthentication.SetAuthCookie(localId, rememberMe);
        }

        private static void SignOutCurrentUser()
        {
            FormsAuthentication.SignOut();
        }
    }
}