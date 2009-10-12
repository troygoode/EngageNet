using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXCredentialsRevokedException : RPXResponseException
	{
		public RPXCredentialsRevokedException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXCredentialsRevokedException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXCredentialsRevokedException()
		{
		}
	}
}