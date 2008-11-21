using System.Net;

namespace RPXLib.Interfaces
{
    public interface IRPXApiSettings
    {
        string ApiKey { get; }
        string BaseUrl { get; }
        IWebProxy WebProxy { get; }
    }
}