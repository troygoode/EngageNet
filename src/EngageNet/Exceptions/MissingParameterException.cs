using System;

namespace EngageNet.Exceptions
{
	[Serializable]
	public class MissingParameterException : ResponseException
	{
		public MissingParameterException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public MissingParameterException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public MissingParameterException()
		{
		}
	}
}