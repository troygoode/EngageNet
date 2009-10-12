using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXServiceTemporarilyUnavailableException : RPXResponseException
	{
		public RPXServiceTemporarilyUnavailableException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXServiceTemporarilyUnavailableException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXServiceTemporarilyUnavailableException()
		{
		}
	}
}