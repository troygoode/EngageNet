using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class CredentialsRevokedException : ResponseException
	{
		public CredentialsRevokedException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public CredentialsRevokedException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public CredentialsRevokedException()
		{
		}
	}
}