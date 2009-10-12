using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXUnknownResponseException : RPXResponseException
	{
		public RPXUnknownResponseException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXUnknownResponseException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXUnknownResponseException()
		{
		}
	}
}