using System;
using System.Collections.Generic;
using System.Xml.Linq;
using EngageNet.Api;
using NUnit.Framework;
using Rhino.Mocks;

namespace EngageNet.Tests
{
	[TestFixture]
	public class ServiceMappingTests
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
		public void GetAllMappings_CallsApiWrapperWithCorrectDetails()
		{
			var emptyResponse = new XElement("rsp",
			                                 new XElement("mappings",
			                                              new XElement("mapping",
			                                                           new XElement("primaryKey"),
			                                                           new XElement("identifiers")
			                                              	)
			                                 	)
				);

			_mockApiWrapper.Expect(
				w => w.Call(
					Arg<string>.Matches(s => s.Equals("all_mappings")),
					Arg<IDictionary<string, string>>.Matches(
						d => d.Count == 0))).Return(emptyResponse);

			_engageNet.GetAllMappings();

			_mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		public void GetMappings_CallsApiWrapperWithCorrectDetails()
		{
			var emptyResponse = new XElement("rsp", new XElement("identifiers", new XElement("identifier")));

			_mockApiWrapper.Expect(
				w => w.Call(
					Arg<string>.Matches(s => s.Equals("mappings")),
					Arg<IDictionary<string, string>>.Matches(
						d => d["primaryKey"].Equals("key")))).Return(emptyResponse);

			_engageNet.GetAllMappings("key");

			_mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetMappings_ThrowsOnEmptyLocalKey()
		{
			_engageNet.GetAllMappings("");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void GetMappings_ThrowsOnNullLocalKey()
		{
			_engageNet.GetAllMappings(null);
		}

		[Test]
		public void MapLocalKey_CallsApiWrapperWithCorrectDetails()
		{
			_mockApiWrapper.Expect(
				w => w.Call(
					Arg<string>.Matches(s => s.Equals("map")),
					Arg<IDictionary<string, string>>.Matches(
						d => d["identifier"].Equals("id") &&
						     d["primaryKey"].Equals("key")))).Return(null);

			_engageNet.MapLocalKey("id", "key");

			_mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void MapLocalKey_ThrowsOnEmptyIdentifier()
		{
			_engageNet.MapLocalKey("", "key");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void MapLocalKey_ThrowsOnEmptyLocalKey()
		{
			_engageNet.MapLocalKey("id", "");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void MapLocalKey_ThrowsOnNullIdentifier()
		{
			_engageNet.MapLocalKey(null, "key");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void MapLocalKey_ThrowsOnNullLocalKey()
		{
			_engageNet.MapLocalKey("id", null);
		}

		[Test]
		public void UnmapLocalKey_CallsApiWrapperWithCorrectDetails()
		{
			_mockApiWrapper.Expect(
				w => w.Call(
					Arg<string>.Matches(s => s.Equals("unmap")),
					Arg<IDictionary<string, string>>.Matches(
						d => d["identifier"].Equals("id") &&
						     d["primaryKey"].Equals("key")))).Return(null);

			_engageNet.UnmapLocalKey("id", "key");

			_mockApiWrapper.VerifyAllExpectations();
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void UnmapLocalKey_ThrowsOnEmptyIdentifier()
		{
			_engageNet.UnmapLocalKey("", "key");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void UnmapLocalKey_ThrowsOnEmptyLocalKey()
		{
			_engageNet.UnmapLocalKey("id", "");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void UnmapLocalKey_ThrowsOnNullIdentifier()
		{
			_engageNet.UnmapLocalKey(null, "key");
		}

		[Test]
		[ExpectedException(typeof (ArgumentNullException))]
		public void UnmapLocalKey_ThrowsOnNullLocalKey()
		{
			_engageNet.UnmapLocalKey("id", null);
		}
	}
}