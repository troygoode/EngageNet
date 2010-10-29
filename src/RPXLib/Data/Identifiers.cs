using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace EngageNet.Data
{
	public class Identifiers : List<string>
	{
		public static Identifiers FromXElement(XElement xElement)
		{
			var identifiers = new Identifiers();
			identifiers.AddRange(xElement.Element("identifiers").Elements("identifier").Select(element => element.Value));

			return identifiers;
		}
	}
}