using System.IO;
using NUnit.Framework;
using RPXLib.Exceptions;

namespace RPXLib.Tests
{
    [TestFixture]
    public class RPXApiResponseParserTests
    {
        [Test]
		[ExpectedException(typeof(RPXServiceTemporarilyUnavailableException), ExpectedMessage = "Service Temporarily Unavailable")]
		public void HandlesServiceTemporarilyUnavailableErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Service Temporarily Unavailable' code='-1'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXMissingParameterException), ExpectedMessage = "Missing parameter")]
		public void HandlesMissingParameterErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Missing parameter' code='0'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXInvalidParameterException), ExpectedMessage = "Invalid parameter")]
		public void HandlesInvalidParameterErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Invalid parameter' code='1'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

        [Test]
        [ExpectedException(typeof (RPXDataNotFoundException), ExpectedMessage = "Data not found")]
        public void HandlesDataNotFoundErrorCodeByThrowingException()
        {
            var errResponse =
                "<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Data not found' code='2'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
        }

		[Test]
		[ExpectedException(typeof(RPXTokenUrlMismatchException), ExpectedMessage = "Token URL mismatch: (your tokenUrl parameter) (original token URL)")]
		public void HandlesTokenUrlMismatchErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Token URL mismatch: (your tokenUrl parameter) (original token URL)' code='3'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXAuthenticationErrorException), ExpectedMessage = "Authentication error")]
		public void HandlesAuthenticationErrorErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Authentication error' code='3'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXFacebookErrorException), ExpectedMessage = "Facebook Error")]
		public void HandlesFacebookErrorErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Facebook Error' code='4'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXMappingExistsException), ExpectedMessage = "Mapping exists")]
		public void HandlesMappingExistsErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Mapping exists' code='5'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXPreviouslyOperationalProviderException), ExpectedMessage = "Error interacting with a previously operational provider")]
		public void HandlesErrorInteractingWithAPreviouslyOperationProviderErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Error interacting with a previously operational provider' code='6'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXAccountUpgradeNeededException), ExpectedMessage = "RPX account upgrade needed to access this API")]
		public void HandlesRPXAccountUpgradeNeededToAccessThisAPIErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='RPX account upgrade needed to access this API' code='7'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXCredentialsMissingException), ExpectedMessage = "Missing third-party credentials for this identifier")]
		public void HandlesMissingThirdPartyCredentialsForThisIdentifierErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Missing third-party credentials for this identifier' code='8'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXCredentialsRevokedException), ExpectedMessage = "Third-party credentials have been revoked")]
		public void HandlesThirdPartyCredentialsHaveBeenRevokedErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Third-party credentials have been revoked' code='9'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXApplicationConfigurationException), ExpectedMessage = "Your application is not properly configured")]
		public void HandlesYourApplicationIsNotProperlyConfiguredErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Your application is not properly configured' code='10'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXUnsupportedProviderFeatureException), ExpectedMessage = "The provider or identifier does not support this feature")]
		public void HandlesTheProviderOrIdentifierDoesNotSupportThisFeatureErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='The provider or identifier does not support this feature' code='11'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof(RPXUnknownResponseException), ExpectedMessage = "Lorem Ipsum Dolor")]
		public void HandlesUnknownErrorCodesByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Lorem Ipsum Dolor' code='-999'/></rsp>";
            RPXApiResponseParser.Parse(errResponse);
		}

        [Test]
		[ExpectedException(typeof(RPXException))]
        public void ThrowsOnBlankInput()
        {
            RPXApiResponseParser.Parse("");
        }

        [Test]
        [ExpectedException(typeof (RPXException))]
        public void ThrowsOnNullReaderInput()
        {
            RPXApiResponseParser.Parse((TextReader)null);
        }

        [Test]
		[ExpectedException(typeof(RPXException))]
        public void ThrowsOnNullStringInput()
        {
            RPXApiResponseParser.Parse((string)null);
        }
    }
}