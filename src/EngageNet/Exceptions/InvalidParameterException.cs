using System;

namespace EngageNet.Exceptions
{
	[Serializable]
	public class InvalidParameterException : ResponseException
	{
		public InvalidParameterException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public InvalidParameterException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public InvalidParameterException()
		{
		}
	}
}