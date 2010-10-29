using EngageNet.Data;
using NUnit.Framework;

namespace EngageNet.Tests.Data
{
	[TestFixture]
	public class NameTests
	{
		#region Setup/Teardown

		[SetUp]
		public void TestSetup()
		{
			_name = new Name();
		}

		#endregion

		private Name _name;

		[Test]
		public void CanPopulateFamilyNameProperty()
		{
			Assert.IsNull(_name.FamilyName);
			_name.AddProperty("familyName", "test");
			Assert.AreEqual("test", _name.FamilyName);
		}

		[Test]
		public void CanPopulateFormattedProperty()
		{
			Assert.IsNull(_name.Formatted);
			_name.AddProperty("formatted", "test");
			Assert.AreEqual("test", _name.Formatted);
		}

		[Test]
		public void CanPopulateGivenNameProperty()
		{
			Assert.IsNull(_name.GivenName);
			_name.AddProperty("givenName", "test");
			Assert.AreEqual("test", _name.GivenName);
		}

		[Test]
		public void CanPopulateHonorificPrefixProperty()
		{
			Assert.IsNull(_name.HonorificPrefix);
			_name.AddProperty("honorificPrefix", "test");
			Assert.AreEqual("test", _name.HonorificPrefix);
		}

		[Test]
		public void CanPopulateHonorificSuffixProperty()
		{
			Assert.IsNull(_name.HonorificSuffix);
			_name.AddProperty("honorificSuffix", "test");
			Assert.AreEqual("test", _name.HonorificSuffix);
		}

		[Test]
		public void CanPopulateMiddleNameProperty()
		{
			Assert.IsNull(_name.MiddleName);
			_name.AddProperty("middleName", "test");
			Assert.AreEqual("test", _name.MiddleName);
		}
	}
}