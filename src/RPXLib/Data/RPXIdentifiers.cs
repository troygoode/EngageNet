using System.Collections.Generic;
using System.Xml.Linq;

namespace RPXLib.Data
{
    public class RPXIdentifiers : List<string>
    {
        public static RPXIdentifiers FromXElement(XElement xElement)
        {
            var identifiers = new RPXIdentifiers();

            foreach (var element in xElement.Element("identifiers").Elements("identifier"))
                identifiers.Add(element.Value);

            return identifiers;
        }
    }
}