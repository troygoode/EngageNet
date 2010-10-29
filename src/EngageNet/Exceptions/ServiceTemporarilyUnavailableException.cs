using System;

namespace EngageNet.Exceptions
{
	[Serializable]
	public class ServiceTemporarilyUnavailableException : ResponseException
	{
		public ServiceTemporarilyUnavailableException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public ServiceTemporarilyUnavailableException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public ServiceTemporarilyUnavailableException()
		{
		}
	}
}