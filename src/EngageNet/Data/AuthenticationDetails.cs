using System.Xml.Linq;

namespace EngageNet.Data
{
	public class AuthenticationDetails : ElementBase
	{
		public Address Address { get; private set; }

		public string Birthday
		{
			get { return GetPropertyValue("birthday"); }
		}

		public string DisplayName
		{
			get { return GetPropertyValue("displayName"); }
		}

		public string Email
		{
			get { return GetPropertyValue("email"); }
		}

		public string Gender
		{
			get { return GetPropertyValue("gender"); }
		}

		public string Identifier
		{
			get { return GetPropertyValue("identifier"); }
		}

		public string LocalKey
		{
			get { return GetPropertyValue("primaryKey"); }
		}

		public Name Name { get; private set; }

		public string PhoneNumber
		{
			get { return GetPropertyValue("phoneNumber"); }
		}

		public string PhotoUrl
		{
			get { return GetPropertyValue("photo"); }
		}

		public string PreferredUsername
		{
			get { return GetPropertyValue("preferredUsername"); }
		}

		public string ProviderName
		{
			get { return GetPropertyValue("providerName"); }
		}

		public string Url
		{
			get { return GetPropertyValue("url"); }
		}

		public string UtcOffset
		{
			get { return GetPropertyValue("utcOffset"); }
		}

		public string VerifiedEmail
		{
			get { return GetPropertyValue("verifiedEmail"); }
		}

		private void AssignName(Name name)
		{
			Name = name;
		}

		private void AssignAddress(Address address)
		{
			Address = address;
		}

		public static AuthenticationDetails FromXElement(XElement xElement)
		{
			var details = new AuthenticationDetails();

			foreach (var element in xElement.Element("profile").Elements())
			{
				var elementLocalName = element.Name.LocalName;
				switch (elementLocalName)
				{
					case "name":
						details.AssignName(Name.FromXElement(element));
						break;
					case "address":
						details.AssignAddress(Address.FromXElement(element));
						break;
					default:
						details.AddProperty(elementLocalName, element.Value);
						break;
				}
			}

			if (details.Name == null)
				details.AssignName(new Name());

			if (details.Address == null)
				details.AssignAddress(new Address());

			return details;
		}
	}
}