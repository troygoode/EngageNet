using System;
using EngageNet.Api;
using NUnit.Framework;
using Rhino.Mocks;

namespace EngageNet.Tests
{
	[TestFixture]
	public class ServiceActivityTests
	{
		#region Setup/Teardown

		[SetUp]
		public void TestSetup()
		{
			_mockApiWrapper = MockRepository.GenerateMock<IApiWrapper>();
			_engageNet = new EngageNet(_mockApiWrapper);
		}

		#endregion

		private EngageNet _engageNet;
		private IApiWrapper _mockApiWrapper;

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
		[ExpectedException(typeof (NotImplementedException))]
		public void AddActivity_ThrowsNotImplementedException()
		{
			_engageNet.AddActivity("", null);
		}
	}
}