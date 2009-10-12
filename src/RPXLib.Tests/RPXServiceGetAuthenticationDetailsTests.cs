using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using RPXLib.Interfaces;

namespace RPXLib.Tests
{
    [TestFixture]
    public class RPXServiceGetAuthenticationDetailsTests
    {
        #region Setup/Teardown

        [SetUp]
        public void TestSetup()
        {
            mockApiWrapper = MockRepository.GenerateMock<IRPXApiWrapper>();
            rpxService = new RPXService(mockApiWrapper);
        }

        #endregion

        private RPXService rpxService;
        private IRPXApiWrapper mockApiWrapper;

        [Test]
        public void GetAuthenticationDetails_CallsApiWrapperWithCorrectDetails()
        {
            var emptyResponse = new XElement("rsp", new XElement("profile"));

            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("auth_info")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["token"].Equals("token")))).Return(emptyResponse);

            rpxService.GetAuthenticationDetails("token");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
        public void GetAuthenticationDetails_Extended_CallsApiWrapperWithCorrectDetails()
        {
            var emptyResponse = new XElement("rsp", new XElement("profile"));

            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("auth_info")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["token"].Equals("token") &&
                                  d["extended"].Equals("true")))).Return(emptyResponse);

            rpxService.GetAuthenticationDetails("token", true);

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GetAuthenticationDetails_ThrowsOnEmptyToken()
        {
            rpxService.GetAuthenticationDetails("");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthenticationDetails_ThrowsOnNullToken()
        {
            rpxService.GetAuthenticationDetails(null);
        }
    }
}