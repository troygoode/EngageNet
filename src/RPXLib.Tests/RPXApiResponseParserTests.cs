using System.IO;
using NUnit.Framework;

namespace RPXLib.Tests
{
    [TestFixture]
    public class RPXApiResponseParserTests
    {
        #region Setup/Teardown

        [SetUp]
        public void TestSetup()
        {
            service = new RPXApiResponseParser();
        }

        #endregion

        private RPXApiResponseParser service;

        [Test]
        [ExpectedException(typeof (RPXAuthenticationException), ExpectedMessage = "Data not found. [Error code: 2]")]
        public void HandlesErrorResponseByThrowingExceptionContainingReturnedErrorMessage()
        {
            var errResponse =
                "<?xml version='1.0' encoding='UTF-8'?><rsp stat='fail'><err msg='Data not found' code='2'/></rsp>";
            service.Parse(errResponse);
        }

        [Test]
        [ExpectedException(typeof (RPXAuthenticationException))]
        public void ThrowsOnBlankInput()
        {
            service.Parse("");
        }

        [Test]
        [ExpectedException(typeof (RPXAuthenticationException))]
        public void ThrowsOnNullReaderInput()
        {
            service.Parse((TextReader) null);
        }

        [Test]
        [ExpectedException(typeof (RPXAuthenticationException))]
        public void ThrowsOnNullStringInput()
        {
            service.Parse((string) null);
        }
    }
}