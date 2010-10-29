using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class TokenUrlMismatchException : AuthenticationErrorException
	{
		public TokenUrlMismatchException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public TokenUrlMismatchException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public TokenUrlMismatchException()
		{
		}
	}
}