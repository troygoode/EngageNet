using System;
using System.Collections.Generic;
using EngageNet.Api;
using EngageNet.Data;

namespace EngageNet
{
	public class EngageNet : IEngageNet
	{
		private readonly IApiWrapper apiWrapper;

		public EngageNet(string apiKey)
			: this(new EngageNetSettings(apiKey))
		{
		}

		public EngageNet(IEngageNetSettings engageNetSettings)
			: this(new ApiWrapper(engageNetSettings))
		{
		}

		public EngageNet(IApiWrapper apiWrapper)
		{
			this.apiWrapper = apiWrapper;
		}

		#region IEngageNet Members

		public GetContactsResponse GetContacts(string authenticationDetailsIdentifier)
		{
			if (string.IsNullOrEmpty(authenticationDetailsIdentifier))
				throw new ArgumentNullException("authenticationDetailsIdentifier",
				                                "The identifier supplied to the GetContacts request was null or empty");

			var req = new Dictionary<string, string>
			          	{
			          		{"identifier", authenticationDetailsIdentifier}
			          	};

			var returnedElement = apiWrapper.Call("get_contacts", req);
			return GetContactsResponse.FromXElement(returnedElement);
		}

		public void UpdateStatus(string authenticationDetailsIdentifier, string status)
		{
			if (string.IsNullOrEmpty(authenticationDetailsIdentifier))
				throw new ArgumentNullException("authenticationDetailsIdentifier",
				                                "The identifier supplied to the UpdateStatus request was null or empty");

			if (string.IsNullOrEmpty(status))
				throw new ArgumentNullException("status", "The status supplied to the UpdateStatus request was null or empty");

			var req = new Dictionary<string, string>
			          	{
			          		{"identifier", authenticationDetailsIdentifier},
			          		{"status", status}
			          	};

			apiWrapper.Call("set_status", req);
		}

		public IDictionary<string, IEnumerable<string>> GetAllMappings()
		{
			var req = new Dictionary<string, string>();

			var returnedElement = apiWrapper.Call("all_mappings", req);
			return AllIdentifiers.FromXElement(returnedElement);
		}

		public IEnumerable<string> GetAllMappings(string localKey)
		{
			if (string.IsNullOrEmpty(localKey))
				throw new ArgumentNullException("localKey", "The local key supplied to the GetAllMappings request was null or empty");

			var req = new Dictionary<string, string>
			          	{
			          		{"primaryKey", localKey}
			          	};

			var returnedElement = apiWrapper.Call("mappings", req);
			return Identifiers.FromXElement(returnedElement);
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
				throw new ArgumentNullException("authenticationDetailsIdentifier",
				                                "The identifier supplied to the MapLocalKey request was null or empty");

			if (string.IsNullOrEmpty(localKey))
				throw new ArgumentNullException("localKey", "The local key supplied to the MapLocalKey request was null or empty");

			var req = new Dictionary<string, string>
			          	{
			          		{"identifier", authenticationDetailsIdentifier},
			          		{"primaryKey", localKey}
			          	};

			apiWrapper.Call("map", req);
		}

		public void UnmapLocalKey(string authenticationDetailsIdentifier, string localKey)
		{
			if (string.IsNullOrEmpty(authenticationDetailsIdentifier))
				throw new ArgumentNullException("authenticationDetailsIdentifier",
				                                "The identifier supplied to the UnmapLocalKey request was null or empty");

			if (string.IsNullOrEmpty(localKey))
				throw new ArgumentNullException("localKey", "The local key supplied to the UnmapLocalKey request was null or empty");

			var req = new Dictionary<string, string>
			          	{
			          		{"identifier", authenticationDetailsIdentifier},
			          		{"primaryKey", localKey}
			          	};

			apiWrapper.Call("unmap", req);
		}

		public AuthenticationDetails GetUserData(string authenticationDetailsIdentifier)
		{
			if (string.IsNullOrEmpty(authenticationDetailsIdentifier))
				throw new ArgumentNullException("authenticationDetailsIdentifier",
				                                "The authenticationDetailsIdentifier supplied to the GetUserData request was null or empty");

			var req = new Dictionary<string, string>
			          	{
			          		{"identifier", authenticationDetailsIdentifier}
			          	};

			var returnedElement = apiWrapper.Call("get_user_data", req);
			return AuthenticationDetails.FromXElement(returnedElement);
		}

		public AuthenticationDetails GetAuthenticationDetails(string token, bool extended)
		{
			if (string.IsNullOrEmpty(token))
				throw new ArgumentNullException("token",
				                                "The token supplied to the GetAuthenticationDetails request was null or empty");

			var req = new Dictionary<string, string>
			          	{
			          		{"token", token}
			          	};
			if (extended)
				req.Add("extended", "true");

			var returnedElement = apiWrapper.Call("auth_info", req);
			return AuthenticationDetails.FromXElement(returnedElement);
		}

		public AuthenticationDetails GetAuthenticationDetails(string token)
		{
			return GetAuthenticationDetails(token, false);
		}

		#endregion

		public void AddActivity(string authenticationDetailsIdentifier, Activity activity)
		{
			throw new NotImplementedException();

			if (string.IsNullOrEmpty(authenticationDetailsIdentifier))
				throw new ArgumentNullException("authenticationDetailsIdentifier",
				                                "The identifier supplied to the AddActivity request was null or empty");

			if (activity == null)
				throw new ArgumentNullException("activity", "The activity supplied to the AddActivity request was null");

			if (string.IsNullOrEmpty(activity.Url))
				throw new ArgumentNullException("activity",
				                                "The activity supplied to the AddActivity request has a null or empty value for its Url property");

			if (string.IsNullOrEmpty(activity.Action))
				throw new ArgumentNullException("activity",
				                                "The activity supplied to the AddActivity request has a null or empty value for its Action property");

			var req = new Dictionary<string, string>
			          	{
			          		{"identifier", authenticationDetailsIdentifier},
			          		{"activity", activity.ToString()} //BUG: serailize activity as JSON
			          	};

			apiWrapper.Call("activity", req);
		}
	}
}