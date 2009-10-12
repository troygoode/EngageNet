using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXPreviouslyOperationalProviderException : RPXResponseException
	{
		public RPXPreviouslyOperationalProviderException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXPreviouslyOperationalProviderException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXPreviouslyOperationalProviderException()
		{
		}
	}
}