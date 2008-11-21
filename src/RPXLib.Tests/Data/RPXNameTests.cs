using NUnit.Framework;
using RPXLib.Data;

namespace RPXLib.Tests.Data
{
    [TestFixture]
    public class RPXNameTests
    {
        #region Setup/Teardown

        [SetUp]
        public void TestSetup()
        {
            name = new RPXName();
        }

        #endregion

        private RPXName name;

        [Test]
        public void CanPopulateFamilyNameProperty()
        {
            Assert.IsNull(name.FamilyName);
            name.AddProperty("familyName", "test");
            Assert.AreEqual("test", name.FamilyName);
        }

        [Test]
        public void CanPopulateFormattedProperty()
        {
            Assert.IsNull(name.Formatted);
            name.AddProperty("formatted", "test");
            Assert.AreEqual("test", name.Formatted);
        }

        [Test]
        public void CanPopulateGivenNameProperty()
        {
            Assert.IsNull(name.GivenName);
            name.AddProperty("givenName", "test");
            Assert.AreEqual("test", name.GivenName);
        }

        [Test]
        public void CanPopulateHonorificPrefixProperty()
        {
            Assert.IsNull(name.HonorificPrefix);
            name.AddProperty("honorificPrefix", "test");
            Assert.AreEqual("test", name.HonorificPrefix);
        }

        [Test]
        public void CanPopulateHonorificSuffixProperty()
        {
            Assert.IsNull(name.HonorificSuffix);
            name.AddProperty("honorificSuffix", "test");
            Assert.AreEqual("test", name.HonorificSuffix);
        }

        [Test]
        public void CanPopulateMiddleNameProperty()
        {
            Assert.IsNull(name.MiddleName);
            name.AddProperty("middleName", "test");
            Assert.AreEqual("test", name.MiddleName);
        }
    }
}