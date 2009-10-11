using NUnit.Framework;
using RPXLib.Data;

namespace RPXLib.Tests.Data
{
    [TestFixture]
    public class RPXAuthenticationDetailsTests
    {
        #region Setup/Teardown

        [SetUp]
        public void TestSetup()
        {
            details = new RPXAuthenticationDetails();
        }

        #endregion

        private RPXAuthenticationDetails details;

        [Test]
        public void CanPopulateBirthdayProperty()
        {
            Assert.IsNull(details.Birthday);
            details.AddProperty("birthday", "test");
            Assert.AreEqual("test", details.Birthday);
        }

        [Test]
        public void CanPopulateDisplayNameProperty()
        {
            Assert.IsNull(details.DisplayName);
            details.AddProperty("displayName", "test");
            Assert.AreEqual("test", details.DisplayName);
        }

        [Test]
        public void CanPopulateEmailProperty()
        {
            Assert.IsNull(details.Email);
            details.AddProperty("email", "test");
            Assert.AreEqual("test", details.Email);
        }

        [Test]
        public void CanPopulateGenderProperty()
        {
            Assert.IsNull(details.Gender);
            details.AddProperty("gender", "test");
            Assert.AreEqual("test", details.Gender);
        }

        [Test]
        public void CanPopulateIdentifierProperty()
        {
            Assert.IsNull(details.Identifier);
            details.AddProperty("identifier", "test");
            Assert.AreEqual("test", details.Identifier);
        }

        [Test]
        public void CanPopulateLocalKeyProperty()
        {
            Assert.IsNull(details.LocalKey);
            details.AddProperty("primaryKey", "test");
            Assert.AreEqual("test", details.LocalKey);
        }

        [Test]
        public void CanPopulatePhoneNumberProperty()
        {
            Assert.IsNull(details.PhoneNumber);
            details.AddProperty("phoneNumber", "test");
            Assert.AreEqual("test", details.PhoneNumber);
        }

        [Test]
        public void CanPopulatePhotoUrlProperty()
        {
            Assert.IsNull(details.PhotoUrl);
            details.AddProperty("photo", "test");
            Assert.AreEqual("test", details.PhotoUrl);
        }

        [Test]
        public void CanPopulatePreferredUsernameProperty()
        {
            Assert.IsNull(details.PreferredUsername);
            details.AddProperty("preferredUsername", "dn");
            Assert.AreEqual("dn", details.PreferredUsername);
        }

		[Test]
		public void CanPopulateProviderNameProperty()
		{
			Assert.IsNull(details.ProviderName);
			details.AddProperty("providerName", "Facebook");
			Assert.AreEqual("Facebook", details.ProviderName);
		}

        [Test]
        public void CanPopulateUrlProperty()
        {
            Assert.IsNull(details.Url);
            details.AddProperty("url", "test");
            Assert.AreEqual("test", details.Url);
        }

        [Test]
        public void CanPopulateUtcOffsetProperty()
        {
            Assert.IsNull(details.UtcOffset);
            details.AddProperty("utcOffset", "test");
            Assert.AreEqual("test", details.UtcOffset);
        }

        [Test]
        public void CanPopulateVerifiedEmailProperty()
        {
            Assert.IsNull(details.VerifiedEmail);
            details.AddProperty("verifiedEmail", "test");
            Assert.AreEqual("test", details.VerifiedEmail);
        }
    }
}