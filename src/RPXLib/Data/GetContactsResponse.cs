using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EngageNet.Data
{
	public class GetContactsResponse : List<Contact>
	{
		public int ItemsPerPage { get; private set; }
		public int TotalResults { get; private set; }
		public int StartIndex { get; private set; }

		public static GetContactsResponse FromXElement(XElement xElement)
		{
			var contacts = new GetContactsResponse
			               	{
			               		ItemsPerPage = int.Parse(xElement.Element("response").Element("itemsPerPage").Value),
			               		TotalResults = int.Parse(xElement.Element("response").Element("totalResults").Value),
			               		StartIndex = int.Parse(xElement.Element("response").Element("startIndex").Value)
			               	};
			contacts.AddRange(xElement.Element("response").Elements("entry").Select(contact => Contact.FromXElement(contact)));
			return contacts;
		}
	}
}