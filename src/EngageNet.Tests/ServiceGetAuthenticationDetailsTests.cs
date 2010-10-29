using System;
using System.Collections.Generic;
using System.Xml.Linq;
using EngageNet.Api;
using NUnit.Framework;
using Rhino.Mocks;

namespace EngageNet.Tests
{
	[TestFixture]
	public class ServiceGetAuthenticationDetailsTests
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
		public void GetAuthenticationDetails_CallsApiWrapperWithCorrectDetails()
		{
			var emptyResponse = new XElement("rsp", new XElement("profile"));

			_mockApiWrapper.Expect(
				w => w.Call(
					Arg<string>.Matches(s => s.Equals("auth_info")),
					Arg<IDictionary<string, string>>.Matches(
						d => d["token"].Equals("token")))).Return(emptyResponse);

			_engageNet.GetAuthenticationDetails("token");

			_mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		public void GetAuthenticationDetails_Extended_CallsApiWrapperWithCorrectDetails()
		{
			var emptyResponse = new XElement("rsp", new XElement("profile"));

			_mockApiWrapper.Expect(
				w => w.Call(
					Arg<string>.Matches(s => s.Equals("auth_info")),
					Arg<IDictionary<string, string>>.Matches(
						d => d["token"].Equals("token") &&
						     d["extended"].Equals("true")))).Return(emptyResponse);

			_engageNet.GetAuthenticationDetails("token", true);

			_mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetAuthenticationDetails_ThrowsOnEmptyToken()
		{
			_engageNet.GetAuthenticationDetails("");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetAuthenticationDetails_ThrowsOnNullToken()
		{
			_engageNet.GetAuthenticationDetails(null);
		}
	}
}