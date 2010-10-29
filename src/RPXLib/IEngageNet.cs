using System.Collections.Generic;
using EngageNet.Data;

namespace EngageNet
{
	public interface IEngageNet
	{
		GetContactsResponse GetContacts(string authenticationDetailsIdentifier);
		void UpdateStatus(string authenticationDetailsIdentifier, string status);
		//void AddActivity(string authenticationDetailsIdentifier, RPXActivity activity);

		IDictionary<string, IEnumerable<string>> GetAllMappings();
		IEnumerable<string> GetAllMappings(string localKey);
		void RemoveAllMappings(string localKey);
		void MapLocalKey(string authenticationDetailsIdentifier, string localKey);
		void UnmapLocalKey(string authenticationDetailsIdentifier, string localKey);

		AuthenticationDetails GetUserData(string authenticationDetailsIdentifier);
		AuthenticationDetails GetAuthenticationDetails(string token, bool extended);
		AuthenticationDetails GetAuthenticationDetails(string token);
	}
}