using System;
using System.Collections.Generic;
using EngageNet.Api;
using NUnit.Framework;
using Rhino.Mocks;

namespace EngageNet.Tests
{
	[TestFixture]
	public class ServiceStatusTests
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
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetMappings_ThrowsOnNullIdentifier()
		{
			_engageNet.UpdateStatus(null, "status");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetMappings_ThrowsOnNullStatus()
		{
			_engageNet.UpdateStatus("id", null);
		}

		[Test]
		public void UpdateStatus_CallsApiWrapperWithCorrectDetails()
		{
			_mockApiWrapper.Expect(
				w => w.Call(
					Arg<string>.Matches(s => s.Equals("set_status")),
					Arg<IDictionary<string, string>>.Matches(
						d => d["identifier"].Equals("id") && d["status"].Equals("statusValue")
						))).Return(null);

			_engageNet.UpdateStatus("id", "statusValue");

			_mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void UpdateStatus_ThrowsOnEmptyIdentifier()
		{
			_engageNet.UpdateStatus("", "status");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void UpdateStatus_ThrowsOnEmptyStatus()
		{
			_engageNet.UpdateStatus("id", "");
		}
	}
}