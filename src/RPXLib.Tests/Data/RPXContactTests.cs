using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using RPXLib.Data;

namespace RPXLib.Tests.Data
{
	[TestFixture]
	public class RPXContactTests
	{
		[Test]
		public void GetFromXElement_ParsesContactCorrectly()
		{
			var xelement = new XElement("entry", 
					new XElement("displayName", "Some User"),
					new XElement("emails")
				);
			var contact = RPXContact.FromXElement(xelement);

			Assert.AreEqual("Some User", contact.DisplayName);
			Assert.IsNotNull(contact.EmailAddresses);
			Assert.AreEqual(0, contact.EmailAddresses.Count());
		}

		[Test]
		public void GetFromXElement_ParsesContactCorrectlyWithoutDisplayNameElement()
		{
			var xelement = new XElement("entry",
					new XElement("emails")
				);
			var contact = RPXContact.FromXElement(xelement);

			Assert.IsNull(contact.DisplayName);
			Assert.IsNotNull(contact.EmailAddresses);
			Assert.AreEqual(0, contact.EmailAddresses.Count());
		}

		[Test]
		public void GetFromXElement_ParsesContactCorrectlyWithoutEmailsElement()
		{
			var xelement = new XElement("entry",
					new XElement("displayName", "Some User")
				);
			var contact = RPXContact.FromXElement(xelement);

			Assert.AreEqual("Some User", contact.DisplayName);
			Assert.IsNotNull(contact.EmailAddresses);
			Assert.AreEqual(0, contact.EmailAddresses.Count());
		}
	}
}