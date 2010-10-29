using System;
using System.Collections.Generic;
using System.Xml.Linq;
using EngageNet.Api;
using NUnit.Framework;
using Rhino.Mocks;

namespace EngageNet.Tests
{
	[TestFixture]
	public class ServiceGetUserDataTests
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

		[Test]
		public void GetUserData_CallsApiWrapperWithCorrectDetails()
		{
			var emptyResponse = new XElement("rsp", new XElement("profile"));

			_mockApiWrapper.Expect(
				w => w.Call(
					Arg<string>.Matches(s => s.Equals("get_user_data")),
					Arg<IDictionary<string, string>>.Matches(
						d => d["identifier"].Equals("id")))).Return(emptyResponse);

			_engageNet.GetUserData("id");

			_mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetUserData_ThrowsOnEmptyIdentifier()
		{
			_engageNet.GetUserData("");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetUserData_ThrowsOnNullIdentifier()
		{
			_engageNet.GetUserData(null);
		}
	}
}