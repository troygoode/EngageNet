using System;
using System.Collections.Generic;
using System.Xml.Linq;
using EngageNet.Api;
using NUnit.Framework;
using Rhino.Mocks;

namespace EngageNet.Tests
{
	[TestFixture]
	public class ServiceContactsTests
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
		public void GetContacts_CallsApiWrapperWithCorrectDetails()
		{
			var emptyResponse = new XElement("rsp",
			                                 new XElement("response",
			                                              new XElement("startIndex", 0),
			                                              new XElement("itemsPerPage", 0),
			                                              new XElement("totalResults", 0)
			                                 	)
				);

			_mockApiWrapper.Expect(
				w => w.Call(
					Arg<string>.Matches(s => s.Equals("get_contacts")),
					Arg<IDictionary<string, string>>.Matches(
						d => d["identifier"].Equals("id")
						))).Return(emptyResponse);

			_engageNet.GetContacts("id");

			_mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetContacts_ThrowsOnEmptyIdentifier()
		{
			_engageNet.GetContacts("");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetContacts_ThrowsOnNullIdentifier()
		{
			_engageNet.GetContacts(null);
		}
	}
}