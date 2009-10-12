using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXMissingParameterException : RPXResponseException
	{
		public RPXMissingParameterException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXMissingParameterException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXMissingParameterException()
		{
		}
	}
}