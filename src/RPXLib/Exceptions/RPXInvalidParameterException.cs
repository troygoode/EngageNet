using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXInvalidParameterException : RPXResponseException
	{
		public RPXInvalidParameterException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXInvalidParameterException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXInvalidParameterException()
		{
		}
	}
}