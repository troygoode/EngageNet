using System.Collections.Generic;
using System.Xml.Linq;
using RPXLib.Data;
using RPXLib.Interfaces;

namespace RPXLib
{
    public class RPXService : IRPXService
    {
        private readonly IRPXApiWrapper apiWrapper;

        public RPXService(IRPXApiWrapper apiWrapper)
        {
            this.apiWrapper = apiWrapper;
        }

        #region IRPXService Members

        public RPXIdentifiers GetAllMappings(string localKey)
        {
            if (string.IsNullOrEmpty(localKey))
                throw new RPXAuthenticationException(
                    "The local key supplied to the GetAllMappings request was null or empty");

            var req = new Dictionary<string, string>();
            req.Add("primaryKey", localKey);

            XElement returnedElement = apiWrapper.Call("mappings", req);
            return RPXIdentifiers.FromXElement(returnedElement);
        }

        public void RemoveAllMappings(string localKey)
        {
            var identifiers = GetAllMappings(localKey);
            foreach (var identifier in identifiers)
            {
                UnmapLocalKey(identifier, localKey);
            }
        }

        public void MapLocalKey(string authenticationDetailsIdentifier, string localKey)
        {
            if (string.IsNullOrEmpty(authenticationDetailsIdentifier))
                throw new RPXAuthenticationException(
                    "The identifier supplied to the MapLocalKey request was null or empty");

            if (string.IsNullOrEmpty(localKey))
                throw new RPXAuthenticationException(
                    "The local key supplied to the MapLocalKey request was null or empty");

            var req = new Dictionary<string, string>();
            req.Add("identifier", authenticationDetailsIdentifier);
            req.Add("primaryKey", localKey);

            apiWrapper.Call("map", req);
        }

        public void UnmapLocalKey(string authenticationDetailsIdentifier, string localKey)
        {
            if (string.IsNullOrEmpty(authenticationDetailsIdentifier))
                throw new RPXAuthenticationException(
                    "The identifier supplied to the UnmapLocalKey request was null or empty");

            if (string.IsNullOrEmpty(localKey))
                throw new RPXAuthenticationException(
                    "The local key supplied to the UnmapLocalKey request was null or empty");

            var req = new Dictionary<string, string>();
            req.Add("identifier", authenticationDetailsIdentifier);
            req.Add("primaryKey", localKey);

            apiWrapper.Call("unmap", req);
        }

        public RPXAuthenticationDetails GetAuthenticationDetails(string token, bool extended)
        {
            if (string.IsNullOrEmpty(token))
                throw new RPXAuthenticationException(
                    "The token supplied to the GetAuthenticationDetails request was null or empty");

            var req = new Dictionary<string, string>();
            req.Add("token", token);
            if (extended)
                req.Add("extended", "true");

            var returnedElement = apiWrapper.Call("auth_info", req);
            return RPXAuthenticationDetails.FromXElement(returnedElement);
        }

        public RPXAuthenticationDetails GetAuthenticationDetails(string token)
        {
            return GetAuthenticationDetails(token, false);
        }

        #endregion
    }
}