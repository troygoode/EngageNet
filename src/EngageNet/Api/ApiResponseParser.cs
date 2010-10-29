using System.IO;
using System.Xml.Linq;
using RPXLib.Exceptions;

namespace EngageNet.Api
{
	public static class ApiResponseParser
	{
		public static XElement Parse(TextReader responseReader)
		{
			if (responseReader == null)
				throw new EngageException("No response to parse");

			var doc = XDocument.Load(responseReader, LoadOptions.None);
			if (doc.Root.Attribute("stat").Value == "ok")
				return doc.Root;

			var errCode = int.Parse(doc.Root.Element("err").Attribute("code").Value);
			var errMsg = doc.Root.Element("err").Attribute("msg").Value;

			switch (errCode)
			{
				case -1:
					throw new ServiceTemporarilyUnavailableException(errCode, errMsg);
				case 0:
					throw new MissingParameterException(errCode, errMsg);
				case 1:
					throw new InvalidParameterException(errCode, errMsg);
				case 2:
					throw new DataNotFoundException(errCode, errMsg);
				case 3:
					if (errMsg.ToLowerInvariant().StartsWith("token url mismatch"))
						throw new TokenUrlMismatchException(errCode, errMsg);
					throw new AuthenticationErrorException(errCode, errMsg);
				case 4:
					throw new FacebookErrorException(errCode, errMsg);
				case 5:
					throw new MappingExistsException(errCode, errMsg);
				case 6:
					throw new PreviouslyOperationalProviderException(errCode, errMsg);
				case 7:
					throw new AccountUpgradeNeededException(errCode, errMsg);
				case 8:
					throw new CredentialsMissingException(errCode, errMsg);
				case 9:
					throw new CredentialsRevokedException(errCode, errMsg);
				case 10:
					throw new ApplicationConfigurationException(errCode, errMsg);
				case 11:
					throw new UnsupportedProviderFeatureException(errCode, errMsg);
				default:
					throw new UnknownResponseException(errCode, errMsg);
			}
		}

		public static XElement Parse(string responseString)
		{
			if (string.IsNullOrEmpty(responseString))
				throw new EngageException("No response to parse.");

			using (var stringReader = new StringReader(responseString))
			{
				return Parse(stringReader);
			}
		}
	}
}