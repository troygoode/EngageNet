using NUnit.Framework;
using RPXLib.Data;

namespace RPXLib.Tests.Data
{
    [TestFixture]
    public class RPXAddressTests
    {
        #region Setup/Teardown

        [SetUp]
        public void TestSetup()
        {
            address = new RPXAddress();
        }

        #endregion

        private RPXAddress address;

        [Test]
        public void CanPopulateCountryProperty()
        {
            Assert.IsNull(address.Country);
            address.AddProperty("country", "test");
            Assert.AreEqual("test", address.Country);
        }

        [Test]
        public void CanPopulateFormattedProperty()
        {
            Assert.IsNull(address.Formatted);
            address.AddProperty("formatted", "test");
            Assert.AreEqual("test", address.Formatted);
        }

        [Test]
        public void CanPopulateLocalityProperty()
        {
            Assert.IsNull(address.Locality);
            address.AddProperty("locality", "test");
            Assert.AreEqual("test", address.Locality);
        }

        [Test]
        public void CanPopulatePostalCodeProperty()
        {
            Assert.IsNull(address.PostalCode);
            address.AddProperty("postalCode", "test");
            Assert.AreEqual("test", address.PostalCode);
        }

        [Test]
        public void CanPopulateRegionProperty()
        {
            Assert.IsNull(address.Region);
            address.AddProperty("region", "test");
            Assert.AreEqual("test", address.Region);
        }

        [Test]
        public void CanPopulateStreetAddressProperty()
        {
            Assert.IsNull(address.StreetAddress);
            address.AddProperty("streetAddress", "test");
            Assert.AreEqual("test", address.StreetAddress);
        }
    }
}