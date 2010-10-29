using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EngageNet.Data
{
	public class Contact
	{
		public string DisplayName { get; private set; }
		public IEnumerable<ContactEmailAddress> EmailAddresses { get; private set; }

		public static Contact FromXElement(XElement xElement)
		{
			return new Contact
			       	{
			       		DisplayName = xElement.Element("displayName") == null
			       		              	? null
			       		              	: xElement.Element("displayName").Value,
			       		EmailAddresses = xElement.Element("emails") == null
			       		                 	? new List<ContactEmailAddress>()
			       		                 	: xElement
			       		                 	  	.Element("emails")
			       		                 	  	.Elements("email")
			       		                 	  	.Select(ContactEmailAddress.FromXElement)
			       		                 	  	.ToList()
			       	};
		}
	}
}