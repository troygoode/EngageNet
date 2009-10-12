using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RPXLib.Data
{
	public class RPXContact
	{
		public string DisplayName { get; private set; }
		public IEnumerable<RPXContactEmailAddress> EmailAddresses { get; private set; }

		public static RPXContact FromXElement(XElement xElement)
		{
			return new RPXContact
			       	{
			       		DisplayName = xElement.Element("displayName") == null
			       			? null
			       			: xElement.Element("displayName").Value,
						EmailAddresses = xElement.Element("emails") == null
							? new List<RPXContactEmailAddress>()
							: xElement
			       				.Element("emails")
			       				.Elements("email")
			       				.Select(email => RPXContactEmailAddress.FromXElement(email))
			       				.ToList()
			       	};
		}
	}
}