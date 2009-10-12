using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXAuthenticationErrorException : RPXResponseException
	{
		public RPXAuthenticationErrorException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXAuthenticationErrorException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXAuthenticationErrorException()
		{
		}
	}
}