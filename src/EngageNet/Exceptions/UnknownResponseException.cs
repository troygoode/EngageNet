using System;

namespace EngageNet.Exceptions
{
	[Serializable]
	public class UnknownResponseException : ResponseException
	{
		public UnknownResponseException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public UnknownResponseException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public UnknownResponseException()
		{
		}
	}
}