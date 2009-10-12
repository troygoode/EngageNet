using System.Collections.Generic;
using RPXLib.Data;

namespace RPXLib.Interfaces
{
    public interface IRPXService
    {
    	RPXGetContactsResponse GetContacts(string authenticationDetailsIdentifier);
		void UpdateStatus(string authenticationDetailsIdentifier, string status);
		//void AddActivity(string authenticationDetailsIdentifier, RPXActivity activity);

    	IDictionary<string, IEnumerable<string>> GetAllMappings();
        IEnumerable<string> GetAllMappings(string localKey);
        void RemoveAllMappings(string localKey);
        void MapLocalKey(string authenticationDetailsIdentifier, string localKey);
        void UnmapLocalKey(string authenticationDetailsIdentifier, string localKey);

    	RPXAuthenticationDetails GetUserData(string authenticationDetailsIdentifier);
        RPXAuthenticationDetails GetAuthenticationDetails(string token, bool extended);
        RPXAuthenticationDetails GetAuthenticationDetails(string token);
    }
}