using EngageNet.Data;
using NUnit.Framework;

namespace EngageNet.Tests.Data
{
	[TestFixture]
	public class AuthenticationDetailsTests
	{
		#region Setup/Teardown

		[SetUp]
		public void TestSetup()
		{
			_details = new AuthenticationDetails();
		}

		#endregion

		private AuthenticationDetails _details;

		[Test]
		public void CanPopulateBirthdayProperty()
		{
			Assert.IsNull(_details.Birthday);
			_details.AddProperty("birthday", "test");
			Assert.AreEqual("test", _details.Birthday);
		}

		[Test]
		public void CanPopulateDisplayNameProperty()
		{
			Assert.IsNull(_details.DisplayName);
			_details.AddProperty("displayName", "test");
			Assert.AreEqual("test", _details.DisplayName);
		}

		[Test]
		public void CanPopulateEmailProperty()
		{
			Assert.IsNull(_details.Email);
			_details.AddProperty("email", "test");
			Assert.AreEqual("test", _details.Email);
		}

		[Test]
		public void CanPopulateGenderProperty()
		{
			Assert.IsNull(_details.Gender);
			_details.AddProperty("gender", "test");
			Assert.AreEqual("test", _details.Gender);
		}

		[Test]
		public void CanPopulateIdentifierProperty()
		{
			Assert.IsNull(_details.Identifier);
			_details.AddProperty("identifier", "test");
			Assert.AreEqual("test", _details.Identifier);
		}

		[Test]
		public void CanPopulateLocalKeyProperty()
		{
			Assert.IsNull(_details.LocalKey);
			_details.AddProperty("primaryKey", "test");
			Assert.AreEqual("test", _details.LocalKey);
		}

		[Test]
		public void CanPopulatePhoneNumberProperty()
		{
			Assert.IsNull(_details.PhoneNumber);
			_details.AddProperty("phoneNumber", "test");
			Assert.AreEqual("test", _details.PhoneNumber);
		}

		[Test]
		public void CanPopulatePhotoUrlProperty()
		{
			Assert.IsNull(_details.PhotoUrl);
			_details.AddProperty("photo", "test");
			Assert.AreEqual("test", _details.PhotoUrl);
		}

		[Test]
		public void CanPopulatePreferredUsernameProperty()
		{
			Assert.IsNull(_details.PreferredUsername);
			_details.AddProperty("preferredUsername", "dn");
			Assert.AreEqual("dn", _details.PreferredUsername);
		}

		[Test]
		public void CanPopulateProviderNameProperty()
		{
			Assert.IsNull(_details.ProviderName);
			_details.AddProperty("providerName", "Facebook");
			Assert.AreEqual("Facebook", _details.ProviderName);
		}

		[Test]
		public void CanPopulateUrlProperty()
		{
			Assert.IsNull(_details.Url);
			_details.AddProperty("url", "test");
			Assert.AreEqual("test", _details.Url);
		}

		[Test]
		public void CanPopulateUtcOffsetProperty()
		{
			Assert.IsNull(_details.UtcOffset);
			_details.AddProperty("utcOffset", "test");
			Assert.AreEqual("test", _details.UtcOffset);
		}

		[Test]
		public void CanPopulateVerifiedEmailProperty()
		{
			Assert.IsNull(_details.VerifiedEmail);
			_details.AddProperty("verifiedEmail", "test");
			Assert.AreEqual("test", _details.VerifiedEmail);
		}
	}
}