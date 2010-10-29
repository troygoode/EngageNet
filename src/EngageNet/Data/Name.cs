using System.Xml.Linq;

namespace EngageNet.Data
{
	public class Name : ElementBase
	{
		public string Formatted
		{
			get { return GetPropertyValue("formatted"); }
		}

		public string FamilyName
		{
			get { return GetPropertyValue("familyName"); }
		}

		public string GivenName
		{
			get { return GetPropertyValue("givenName"); }
		}

		public string MiddleName
		{
			get { return GetPropertyValue("middleName"); }
		}

		public string HonorificPrefix
		{
			get { return GetPropertyValue("honorificPrefix"); }
		}

		public string HonorificSuffix
		{
			get { return GetPropertyValue("honorificSuffix"); }
		}

		public static Name FromXElement(XElement xElement)
		{
			var name = new Name();

			foreach (var element in xElement.Elements())
			{
				var elementLocalName = element.Name.LocalName;
				name.AddProperty(elementLocalName, element.Value);
			}

			return name;
		}
	}
}