using System.IO;
using EngageNet.Api;
using EngageNet.Exceptions;
using NUnit.Framework;

namespace EngageNet.Tests
{
	[TestFixture]
	public class ApiResponseParserTests
	{
		[Test]
		[ExpectedException(typeof (AuthenticationErrorException), ExpectedMessage = "Authentication error")]
		public void HandlesAuthenticationErrorErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Authentication error' code='3'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (DataNotFoundException), ExpectedMessage = "Data not found")]
		public void HandlesDataNotFoundErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Data not found' code='2'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (PreviouslyOperationalProviderException),
			ExpectedMessage = "Error interacting with a previously operational provider")]
		public void HandlesErrorInteractingWithAPreviouslyOperationProviderErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Error interacting with a previously operational provider' code='6'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (FacebookErrorException), ExpectedMessage = "Facebook Error")]
		public void HandlesFacebookErrorErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Facebook Error' code='4'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (InvalidParameterException), ExpectedMessage = "Invalid parameter")]
		public void HandlesInvalidParameterErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Invalid parameter' code='1'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (MappingExistsException), ExpectedMessage = "Mapping exists")]
		public void HandlesMappingExistsErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Mapping exists' code='5'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (MissingParameterException), ExpectedMessage = "Missing parameter")]
		public void HandlesMissingParameterErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Missing parameter' code='0'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (CredentialsMissingException),
			ExpectedMessage = "Missing third-party credentials for this identifier")]
		public void HandlesMissingThirdPartyCredentialsForThisIdentifierErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Missing third-party credentials for this identifier' code='8'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (AccountUpgradeNeededException),
			ExpectedMessage = "RPX account upgrade needed to access this API")]
		public void HandlesRPXAccountUpgradeNeededToAccessThisAPIErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='RPX account upgrade needed to access this API' code='7'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (ServiceTemporarilyUnavailableException),
			ExpectedMessage = "Service Temporarily Unavailable")]
		public void HandlesServiceTemporarilyUnavailableErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Service Temporarily Unavailable' code='-1'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (UnsupportedProviderFeatureException),
			ExpectedMessage = "The provider or identifier does not support this feature")]
		public void HandlesTheProviderOrIdentifierDoesNotSupportThisFeatureErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='The provider or identifier does not support this feature' code='11'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (CredentialsRevokedException),
			ExpectedMessage = "Third-party credentials have been revoked")]
		public void HandlesThirdPartyCredentialsHaveBeenRevokedErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Third-party credentials have been revoked' code='9'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (TokenUrlMismatchException),
			ExpectedMessage = "Token URL mismatch: (your tokenUrl parameter) (original token URL)")]
		public void HandlesTokenUrlMismatchErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Token URL mismatch: (your tokenUrl parameter) (original token URL)' code='3'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (UnknownResponseException), ExpectedMessage = "Lorem Ipsum Dolor")]
		public void HandlesUnknownErrorCodesByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Lorem Ipsum Dolor' code='-999'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (ApplicationConfigurationException),
			ExpectedMessage = "Your application is not properly configured")]
		public void HandlesYourApplicationIsNotProperlyConfiguredErrorCodeByThrowingException()
		{
			var errResponse =
				"<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Your application is not properly configured' code='10'/></rsp>";
			ApiResponseParser.Parse(errResponse);
		}

		[Test]
		[ExpectedException(typeof (EngageException))]
		public void ThrowsOnBlankInput()
		{
			ApiResponseParser.Parse("");
		}

		[Test]
		[ExpectedException(typeof (EngageException))]
		public void ThrowsOnNullReaderInput()
		{
			ApiResponseParser.Parse((TextReader) null);
		}

		[Test]
		[ExpectedException(typeof (EngageException))]
		public void ThrowsOnNullStringInput()
		{
			ApiResponseParser.Parse((string) null);
		}
	}
}