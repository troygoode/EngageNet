using System.Xml.Linq;

namespace RPXLib.Data
{
    public class RPXName : RPXElementBase
    {
        public string Formatted
        {
            get { return GetPropertyValue("formatted"); }
        }

        public string FamilyName
        {
            get { return GetPropertyValue("familyName"); }
        }

        public string GivenName
        {
            get { return GetPropertyValue("givenName"); }
        }

        public string MiddleName
        {
            get { return GetPropertyValue("middleName"); }
        }

        public string HonorificPrefix
        {
            get { return GetPropertyValue("honorificPrefix"); }
        }

        public string HonorificSuffix
        {
            get { return GetPropertyValue("honorificSuffix"); }
        }

        public static RPXName FromXElement(XElement xElement)
        {
            var name = new RPXName();

            foreach (var element in xElement.Elements())
            {
                var elementLocalName = element.Name.LocalName;
                name.AddProperty(elementLocalName, element.Value);
            }

            return name;
        }
    }
}