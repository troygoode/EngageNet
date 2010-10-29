using EngageNet.Data;
using NUnit.Framework;

namespace EngageNet.Tests.Data
{
	[TestFixture]
	public class AddressTests
	{
		#region Setup/Teardown

		[SetUp]
		public void TestSetup()
		{
			_address = new Address();
		}

		#endregion

		private Address _address;

		[Test]
		public void CanPopulateCountryProperty()
		{
			Assert.IsNull(_address.Country);
			_address.AddProperty("country", "test");
			Assert.AreEqual("test", _address.Country);
		}

		[Test]
		public void CanPopulateFormattedProperty()
		{
			Assert.IsNull(_address.Formatted);
			_address.AddProperty("formatted", "test");
			Assert.AreEqual("test", _address.Formatted);
		}

		[Test]
		public void CanPopulateLocalityProperty()
		{
			Assert.IsNull(_address.Locality);
			_address.AddProperty("locality", "test");
			Assert.AreEqual("test", _address.Locality);
		}

		[Test]
		public void CanPopulatePostalCodeProperty()
		{
			Assert.IsNull(_address.PostalCode);
			_address.AddProperty("postalCode", "test");
			Assert.AreEqual("test", _address.PostalCode);
		}

		[Test]
		public void CanPopulateRegionProperty()
		{
			Assert.IsNull(_address.Region);
			_address.AddProperty("region", "test");
			Assert.AreEqual("test", _address.Region);
		}

		[Test]
		public void CanPopulateStreetAddressProperty()
		{
			Assert.IsNull(_address.StreetAddress);
			_address.AddProperty("streetAddress", "test");
			Assert.AreEqual("test", _address.StreetAddress);
		}
	}
}