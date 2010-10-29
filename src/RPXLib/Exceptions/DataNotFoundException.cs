using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class DataNotFoundException : ResponseException
	{
		public DataNotFoundException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public DataNotFoundException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public DataNotFoundException()
		{
		}
	}
}