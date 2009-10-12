using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXFacebookErrorException : RPXResponseException
	{
		public RPXFacebookErrorException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXFacebookErrorException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXFacebookErrorException()
		{
		}
	}
}