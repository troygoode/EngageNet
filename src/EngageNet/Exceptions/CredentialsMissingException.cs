using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class CredentialsMissingException : ResponseException
	{
		public CredentialsMissingException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public CredentialsMissingException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public CredentialsMissingException()
		{
		}
	}
}