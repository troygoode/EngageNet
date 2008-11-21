using System.Xml.Linq;

namespace RPXLib.Data
{
    public class RPXAddress : RPXElementBase
    {
        public string Formatted
        {
            get { return GetPropertyValue("formatted"); }
        }

        public string StreetAddress
        {
            get { return GetPropertyValue("streetAddress"); }
        }

        public string Locality
        {
            get { return GetPropertyValue("locality"); }
        }

        public string Region
        {
            get { return GetPropertyValue("region"); }
        }

        public string PostalCode
        {
            get { return GetPropertyValue("postalCode"); }
        }

        public string Country
        {
            get { return GetPropertyValue("country"); }
        }

        public static RPXAddress FromXElement(XElement xElement)
        {
            var name = new RPXAddress();

            foreach (var element in xElement.Elements())
            {
                var elementLocalName = element.Name.LocalName;
                name.AddProperty(elementLocalName, element.Value);
            }

            return name;
        }
    }
}