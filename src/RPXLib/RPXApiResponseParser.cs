using System.IO;
using System.Xml.Linq;

namespace RPXLib
{
    public class RPXApiResponseParser
    {
        public XElement Parse(TextReader responseReader)
        {
            if (responseReader == null)
                throw new RPXAuthenticationException();

            XDocument doc = XDocument.Load(responseReader, LoadOptions.None);
            if (doc.Root.Attribute("stat").Value == "ok")
                return doc.Root;

            string errMsg = doc.Root.Element("err").Attribute("msg").Value;
            string errCode = doc.Root.Element("err").Attribute("code").Value;
            throw new RPXAuthenticationException(string.Format("{0}. [Error code: {1}]", errMsg, errCode));
        }

        public XElement Parse(string responseString)
        {
            if (string.IsNullOrEmpty(responseString))
                throw new RPXAuthenticationException();

            using (var stringReader = new StringReader(responseString))
            {
                return Parse(stringReader);
            }
        }
    }
}