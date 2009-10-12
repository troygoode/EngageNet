using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXMappingExistsException : RPXResponseException
	{
		public RPXMappingExistsException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXMappingExistsException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXMappingExistsException()
		{
		}
	}
}