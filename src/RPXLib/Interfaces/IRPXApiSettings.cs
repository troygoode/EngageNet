using System.Net;

namespace RPXLib.Interfaces
{
    public interface IRPXApiSettings
    {
        string ApiKey { get; }
        string ApiBaseUrl { get; }
        IWebProxy WebProxy { get; }
    }
}