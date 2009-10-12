using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using RPXLib.Interfaces;

namespace RPXLib.Tests
{
	[TestFixture]
	public class RPXServiceContactsTests
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
		public void GetContacts_CallsApiWrapperWithCorrectDetails()
		{
			var emptyResponse = new XElement("rsp",
			                                 new XElement("response",
			                                              new XElement("startIndex", 0),
			                                              new XElement("itemsPerPage", 0),
			                                              new XElement("totalResults", 0)
			                                 	)
				);

			mockApiWrapper.Expect(
				w => w.Call(
				     	Arg<string>.Matches(s => s.Equals("get_contacts")),
				     	Arg<IDictionary<string, string>>.Matches(
				     		d => d["identifier"].Equals("id")
				     		))).Return(emptyResponse);

			rpxService.GetContacts("id");

			mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetContacts_ThrowsOnEmptyIdentifier()
		{
			rpxService.GetContacts("");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GetContacts_ThrowsOnNullIdentifier()
		{
			rpxService.GetContacts(null);
		}
	}
}