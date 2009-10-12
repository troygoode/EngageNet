using System.Collections.Generic;
using System.Xml.Linq;

namespace RPXLib.Data
{
	public class RPXAllIdentifiers : Dictionary<string, IEnumerable<string>>
	{
		public static RPXAllIdentifiers FromXElement(XElement xElement)
		{
			var allIdentifiers = new RPXAllIdentifiers();

			foreach(var setofIdentifiers in xElement.Element("mappings").Elements("mapping"))
				allIdentifiers.Add(setofIdentifiers.Element("primaryKey").Value, RPXIdentifiers.FromXElement(setofIdentifiers));
			
			return allIdentifiers;
		}
	}
}