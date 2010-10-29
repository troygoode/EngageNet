using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class AuthenticationErrorException : ResponseException
	{
		public AuthenticationErrorException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public AuthenticationErrorException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public AuthenticationErrorException()
		{
		}
	}
}