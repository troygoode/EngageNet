using System;
using NUnit.Framework;
using Rhino.Mocks;
using RPXLib.Interfaces;

namespace RPXLib.Tests
{
    [TestFixture]
    public class RPXServiceActivityTests
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

		//[Test]
		//public void AddActivity_CallsApiWrapperWithCorrectDetails()
		//{
		//    mockApiWrapper.Expect(
		//        w => w.Call(
		//                Arg<string>.Matches(s => s.Equals("activity")),
		//                Arg<IDictionary<string, string>>.Matches(
		//                    d => d["identifier"].Equals("id")
		//                    ))).Return(null);

		//    rpxService.AddActivity("id", null);

		//    mockApiWrapper.VerifyAllExpectations();
		//}

		[Test]
		[ExpectedException(typeof(NotImplementedException))]
		public void AddActivity_ThrowsNotImplementedException()
		{
			rpxService.AddActivity("", null);
		}
    }
}