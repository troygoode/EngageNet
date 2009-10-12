using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXCredentialsMissingException : RPXResponseException
	{
		public RPXCredentialsMissingException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXCredentialsMissingException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXCredentialsMissingException()
		{
		}
	}
}