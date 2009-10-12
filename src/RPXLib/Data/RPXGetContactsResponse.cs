using System.Collections.Generic;
using System.Xml.Linq;

namespace RPXLib.Data
{
	public class RPXGetContactsResponse : List<RPXContact>
	{
		public int ItemsPerPage { get; private set; }
		public int TotalResults { get; private set; }
		public int StartIndex { get; private set; }

		public static RPXGetContactsResponse FromXElement(XElement xElement)
		{
			var contacts = new RPXGetContactsResponse
			               	{
								ItemsPerPage = int.Parse(xElement.Element("response").Element("itemsPerPage").Value),
								TotalResults = int.Parse(xElement.Element("response").Element("totalResults").Value),
								StartIndex = int.Parse(xElement.Element("response").Element("startIndex").Value)
			               	};

			foreach(var contact in xElement.Element("response").Elements("entry"))
				contacts.Add(RPXContact.FromXElement(contact));

			return contacts;
		}
	}
}