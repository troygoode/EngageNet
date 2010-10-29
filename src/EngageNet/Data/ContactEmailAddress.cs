using System.Xml.Linq;

namespace EngageNet.Data
{
	public class ContactEmailAddress
	{
		public string Type { get; private set; }
		public string EmailAddress { get; private set; }

		public static ContactEmailAddress FromXElement(XElement xElement)
		{
			return new ContactEmailAddress
			       	{
			       		Type = xElement.Element("type") == null ? null : xElement.Element("type").Value,
			       		EmailAddress = xElement.Element("value") == null ? null : xElement.Element("value").Value
			       	};
		}
	}
}