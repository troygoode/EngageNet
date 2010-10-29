using System;

namespace EngageNet.Exceptions
{
	[Serializable]
	public class FacebookErrorException : ResponseException
	{
		public FacebookErrorException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public FacebookErrorException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public FacebookErrorException()
		{
		}
	}
}