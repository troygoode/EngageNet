using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXTokenUrlMismatchException : RPXAuthenticationErrorException
	{
		public RPXTokenUrlMismatchException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXTokenUrlMismatchException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXTokenUrlMismatchException()
		{
		}
	}
}