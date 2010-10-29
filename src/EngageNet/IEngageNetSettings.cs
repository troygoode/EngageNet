using System.Net;

namespace EngageNet
{
	public interface IEngageNetSettings
	{
		string ApiKey { get; }
		string ApiBaseUrl { get; }
		IWebProxy WebProxy { get; }
	}
}