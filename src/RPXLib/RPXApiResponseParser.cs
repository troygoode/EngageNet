using System.IO;
using System.Xml.Linq;
using RPXLib.Exceptions;

namespace RPXLib
{
	public static class RPXApiResponseParser
	{
		public static XElement Parse(TextReader responseReader)
		{
			if (responseReader == null)
				throw new RPXException("No response to parse");

		    var doc = XDocument.Load(responseReader, LoadOptions.None);
			if (doc.Root.Attribute("stat").Value == "ok")
				return doc.Root;

			var errCode = int.Parse(doc.Root.Element("err").Attribute("code").Value);
			var errMsg = doc.Root.Element("err").Attribute("msg").Value;

			switch (errCode)
			{
				case -1:
					throw new RPXServiceTemporarilyUnavailableException(errCode, errMsg);
				case 0:
					throw new RPXMissingParameterException(errCode, errMsg);
				case 1:
					throw new RPXInvalidParameterException(errCode, errMsg);
				case 2:
					throw new RPXDataNotFoundException(errCode, errMsg);
				case 3:
					if(errMsg.ToLowerInvariant().StartsWith("token url mismatch"))
						throw new RPXTokenUrlMismatchException(errCode, errMsg);
					throw new RPXAuthenticationErrorException(errCode, errMsg);
				case 4:
					throw new RPXFacebookErrorException(errCode, errMsg);
				case 5:
					throw new RPXMappingExistsException(errCode, errMsg);
				case 6:
					throw new RPXPreviouslyOperationalProviderException(errCode, errMsg);
				case 7:
					throw new RPXAccountUpgradeNeededException(errCode, errMsg);
				case 8:
					throw new RPXCredentialsMissingException(errCode, errMsg);
				case 9:
					throw new RPXCredentialsRevokedException(errCode, errMsg);
				case 10:
					throw new RPXApplicationConfigurationException(errCode, errMsg);
				case 11:
					throw new RPXUnsupportedProviderFeatureException(errCode, errMsg);
				default:
					throw new RPXUnknownResponseException(errCode, errMsg);
			}
		}

		public static XElement Parse(string responseString)
		{
			if (string.IsNullOrEmpty(responseString))
				throw new RPXException("No response to parse.");

			using (var stringReader = new StringReader(responseString))
			{
				return Parse(stringReader);
			}
		}
	}
}