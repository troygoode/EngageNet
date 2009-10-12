using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using RPXLib.Interfaces;

namespace RPXLib.Tests
{
    [TestFixture]
    public class RPXServiceGetUserDataTests
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
        public void GetUserData_CallsApiWrapperWithCorrectDetails()
        {
            var emptyResponse = new XElement("rsp", new XElement("profile"));

            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("get_user_data")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["identifier"].Equals("id")))).Return(emptyResponse);

            rpxService.GetUserData("id");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
        [ExpectedException(typeof (ArgumentNullException))]
		public void GetUserData_ThrowsOnEmptyIdentifier()
        {
			rpxService.GetUserData("");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetUserData_ThrowsOnNullIdentifier()
        {
			rpxService.GetUserData(null);
        }
    }
}