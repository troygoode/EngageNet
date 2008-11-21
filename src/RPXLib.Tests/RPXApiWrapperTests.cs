using NUnit.Framework;

namespace RPXLib.Tests
{
    public class RPXApiWrapperTests
    {
        [Test]
        public void ConstructorAppendsDirectorySeperatorIfNotExists()
        {
            var settings = new RPXApiSettings("http://abc.com", "");
            var api = new RPXApiWrapper(settings);
            Assert.AreEqual("http://abc.com/", api.BaseUrl);
        }

        [Test]
        public void ConstructorSetsApiKey()
        {
            var settings = new RPXApiSettings("http://abc.com/", "apikey");
            var api = new RPXApiWrapper(settings);
            Assert.AreEqual("apikey", api.ApiKey);
        }

        [Test]
        public void ConstructorSetsBaseUrl()
        {
            var settings = new RPXApiSettings("http://abc.com/", "");
            var api = new RPXApiWrapper(settings);
            Assert.AreEqual("http://abc.com/", api.BaseUrl);
        }
    }
}