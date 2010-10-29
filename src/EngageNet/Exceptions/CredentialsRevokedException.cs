using System;

namespace EngageNet.Exceptions
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