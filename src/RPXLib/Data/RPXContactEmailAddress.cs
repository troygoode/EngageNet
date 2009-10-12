using System.Xml.Linq;

namespace RPXLib.Data
{
	public class RPXContactEmailAddress
	{
		public string Type { get; private set; }
		public string EmailAddress { get; private set; }

		public static RPXContactEmailAddress FromXElement(XElement xElement)
		{
			return new RPXContactEmailAddress
			       	{
			       		Type = xElement.Element("type") == null ? null : xElement.Element("type").Value,
						EmailAddress = xElement.Element("value") == null ? null : xElement.Element("value").Value
			       	};
		}
	}
}