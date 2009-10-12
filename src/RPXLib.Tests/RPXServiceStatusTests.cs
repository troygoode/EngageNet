using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using RPXLib.Interfaces;

namespace RPXLib.Tests
{
    [TestFixture]
    public class RPXServiceStatusTests
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
		public void UpdateStatus_CallsApiWrapperWithCorrectDetails()
		{
			mockApiWrapper.Expect(
				w => w.Call(
						Arg<string>.Matches(s => s.Equals("set_status")),
						Arg<IDictionary<string, string>>.Matches(
							d => d["identifier"].Equals("id") && d["status"].Equals("statusValue")
							))).Return(null);

			rpxService.UpdateStatus("id", "statusValue");

			mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void UpdateStatus_ThrowsOnEmptyIdentifier()
		{
			rpxService.UpdateStatus("", "status");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetMappings_ThrowsOnNullIdentifier()
		{
			rpxService.UpdateStatus(null, "status");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void UpdateStatus_ThrowsOnEmptyStatus()
		{
			rpxService.UpdateStatus("id", "");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetMappings_ThrowsOnNullStatus()
		{
			rpxService.UpdateStatus("id", null);
		}
    }
}