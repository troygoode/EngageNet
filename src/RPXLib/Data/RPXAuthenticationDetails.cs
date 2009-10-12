using System.Xml.Linq;

namespace RPXLib.Data
{
    public class RPXAuthenticationDetails : RPXElementBase
    {
        private RPXAddress address;
        private RPXName name;

        public RPXAddress Address
        {
            get { return address; }
        }

        public string Birthday
        {
            get { return GetPropertyValue("birthday"); }
        }

        public string DisplayName
        {
            get { return GetPropertyValue("displayName"); }
        }

        public string Email
        {
            get { return GetPropertyValue("email"); }
        }

        public string Gender
        {
            get { return GetPropertyValue("gender"); }
        }

        public string Identifier
        {
            get { return GetPropertyValue("identifier"); }
        }

        public string LocalKey
        {
            get { return GetPropertyValue("primaryKey"); }
        }

        public RPXName Name
        {
            get { return name; }
        }

        public string PhoneNumber
        {
            get { return GetPropertyValue("phoneNumber"); }
        }

        public string PhotoUrl
        {
            get { return GetPropertyValue("photo"); }
        }

        public string PreferredUsername
        {
            get { return GetPropertyValue("preferredUsername"); }
        }

    	public string ProviderName
    	{
    		get { return GetPropertyValue("providerName"); }
    	}

        public string Url
        {
            get { return GetPropertyValue("url"); }
        }

        public string UtcOffset
        {
            get { return GetPropertyValue("utcOffset"); }
        }

        public string VerifiedEmail
        {
            get { return GetPropertyValue("verifiedEmail"); }
        }

        private void AssignName(RPXName name)
        {
            this.name = name;
        }

        private void AssignAddress(RPXAddress address)
        {
            this.address = address;
        }

        public static RPXAuthenticationDetails FromXElement(XElement xElement)
        {
            var details = new RPXAuthenticationDetails();

            foreach (var element in xElement.Element("profile").Elements())
            {
                var elementLocalName = element.Name.LocalName;
                if (elementLocalName == "name")
                {
                    details.AssignName(RPXName.FromXElement(element));
                }
                else if (elementLocalName == "address")
                {
                    details.AssignAddress(RPXAddress.FromXElement(element));
                }
                else
                {
                    details.AddProperty(elementLocalName, element.Value);
                }
            }

			if(details.Name == null)
				details.AssignName(new RPXName());

			if(details.Address == null)
				details.AssignAddress(new RPXAddress());

            return details;
        }
    }
}