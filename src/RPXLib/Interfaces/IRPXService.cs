using RPXLib.Data;

namespace RPXLib.Interfaces
{
    public interface IRPXService
    {
        RPXIdentifiers GetAllMappings(string localKey);
        void RemoveAllMappings(string localKey);
        void MapLocalKey(string authenticationDetailsIdentifier, string localKey);
        void UnmapLocalKey(string authenticationDetailsIdentifier, string localKey);
        RPXAuthenticationDetails GetAuthenticationDetails(string token, bool extended);
        RPXAuthenticationDetails GetAuthenticationDetails(string token);
    }
}