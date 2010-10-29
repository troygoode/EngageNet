using System.Web.Mvc;
using System.Web.Security;
using EngageNet.Mvc;

namespace EngageNet.SampleWebsiteMvc2.Controllers
{
	public class EngageController : Controller
	{
		private readonly IEngageNet _engage;

		public EngageController(IEngageNet engage)
		{
			_engage = engage;
		}

		public EngageController()
		{
			//TODO: you should move the setting of the static EngageProvider.Settings to your global.asax or other setup code
			if (EngageProvider.Settings == null)
			{
				EngageProvider.ApplicationDomain = "your-site-name.rpxnow.com"; //TODO: set your site's Application Domain
				EngageProvider.Settings = new EngageNetSettings("YOUR_API_KEY"); //TODO: set your API key
			}

			_engage = EngageProvider.Build();
		}

		public ViewResult LogOn()
		{
			return View();
		}

		public ViewResult LogOnCancelled()
		{
			return View();
		}

		public ViewResult LogOnSuccess()
		{
			return View();
		}

		public RedirectToRouteResult LogOff()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}

		public RedirectToRouteResult ProcessLogOn(string token)
		{
			if (string.IsNullOrEmpty(token))
				return RedirectToAction("LogOnCancelled");

			var authenticationDetails = _engage.GetAuthenticationDetails(token, true);
			FormsAuthentication.SetAuthCookie(authenticationDetails.Identifier, true);

			// pass auth details to LogOnSuccess page so that it can be displayed (for demo/illustration purposes only)
			TempData["EngageLogonInfo"] = authenticationDetails;

			return RedirectToAction("LogOnSuccess");
		}
	}
}