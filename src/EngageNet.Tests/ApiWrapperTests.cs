using EngageNet.Api;
using NUnit.Framework;

namespace EngageNet.Tests
{
	public class ApiWrapperTests
	{
		[Test]
		public void ConstructorAppendsDirectorySeperatorIfNotExists()
		{
			var settings = new EngageNetSettings("http://abc.com", "", null);
			var api = new ApiWrapper(settings);
			Assert.AreEqual("http://abc.com/", api.BaseUrl);
		}

		[Test]
		public void ConstructorSetsApiKey()
		{
			var settings = new EngageNetSettings("http://abc.com/", "apikey", null);
			var api = new ApiWrapper(settings);
			Assert.AreEqual("apikey", api.ApiKey);
		}

		[Test]
		public void ConstructorSetsBaseUrl()
		{
			var settings = new EngageNetSettings("http://abc.com/", "", null);
			var api = new ApiWrapper(settings);
			Assert.AreEqual("http://abc.com/", api.BaseUrl);
		}
	}
}