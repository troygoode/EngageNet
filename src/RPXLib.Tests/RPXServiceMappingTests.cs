using System;
using System.Collections.Generic;
using System.Xml.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using RPXLib.Interfaces;

namespace RPXLib.Tests
{
    [TestFixture]
    public class RPXServiceMappingTests
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

			mockApiWrapper.Expect(
				w => w.Call(
				     	Arg<string>.Matches(s => s.Equals("all_mappings")),
				     	Arg<IDictionary<string, string>>.Matches(
				     		d => d.Count == 0))).Return(emptyResponse);

			rpxService.GetAllMappings();

			mockApiWrapper.VerifyAllExpectations();
		}

        [Test]
        public void GetMappings_CallsApiWrapperWithCorrectDetails()
        {
            var emptyResponse = new XElement("rsp", new XElement("identifiers", new XElement("identifier")));

            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("mappings")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["primaryKey"].Equals("key")))).Return(emptyResponse);

            rpxService.GetAllMappings("key");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void GetMappings_ThrowsOnEmptyLocalKey()
        {
            rpxService.GetAllMappings("");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void GetMappings_ThrowsOnNullLocalKey()
        {
            rpxService.GetAllMappings(null);
        }

        [Test]
        public void MapLocalKey_CallsApiWrapperWithCorrectDetails()
        {
            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("map")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["identifier"].Equals("id") &&
                                  d["primaryKey"].Equals("key")))).Return(null);

            rpxService.MapLocalKey("id", "key");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void MapLocalKey_ThrowsOnEmptyIdentifier()
        {
            rpxService.MapLocalKey("", "key");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void MapLocalKey_ThrowsOnEmptyLocalKey()
        {
            rpxService.MapLocalKey("id", "");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void MapLocalKey_ThrowsOnNullIdentifier()
        {
            rpxService.MapLocalKey(null, "key");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void MapLocalKey_ThrowsOnNullLocalKey()
        {
            rpxService.MapLocalKey("id", null);
        }

        [Test]
        public void UnmapLocalKey_CallsApiWrapperWithCorrectDetails()
        {
            mockApiWrapper.Expect(
                w => w.Call(
                         Arg<string>.Matches(s => s.Equals("unmap")),
                         Arg<IDictionary<string, string>>.Matches(
                             d => d["identifier"].Equals("id") &&
                                  d["primaryKey"].Equals("key")))).Return(null);

            rpxService.UnmapLocalKey("id", "key");

            mockApiWrapper.VerifyAllExpectations();
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void UnmapLocalKey_ThrowsOnEmptyIdentifier()
        {
            rpxService.UnmapLocalKey("", "key");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void UnmapLocalKey_ThrowsOnEmptyLocalKey()
        {
            rpxService.UnmapLocalKey("id", "");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void UnmapLocalKey_ThrowsOnNullIdentifier()
        {
            rpxService.UnmapLocalKey(null, "key");
        }

        [Test]
		[ExpectedException(typeof(ArgumentNullException))]
        public void UnmapLocalKey_ThrowsOnNullLocalKey()
        {
            rpxService.UnmapLocalKey("id", null);
        }
    }
}