using System.Collections.Generic;
using System.Xml.Linq;

namespace EngageNet.Data
{
	public class AllIdentifiers : Dictionary<string, IEnumerable<string>>
	{
		public static AllIdentifiers FromXElement(XElement xElement)
		{
			var allIdentifiers = new AllIdentifiers();

			foreach (var setofIdentifiers in xElement.Element("mappings").Elements("mapping"))
				allIdentifiers.Add(setofIdentifiers.Element("primaryKey").Value, Identifiers.FromXElement(setofIdentifiers));

			return allIdentifiers;
		}
	}
}