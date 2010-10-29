using System;

namespace EngageNet.Exceptions
{
	[Serializable]
	public class PreviouslyOperationalProviderException : ResponseException
	{
		public PreviouslyOperationalProviderException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public PreviouslyOperationalProviderException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public PreviouslyOperationalProviderException()
		{
		}
	}
}