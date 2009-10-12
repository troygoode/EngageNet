using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXDataNotFoundException : RPXResponseException
	{
		public RPXDataNotFoundException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXDataNotFoundException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXDataNotFoundException()
		{
		}
	}
}