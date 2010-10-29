using System;

namespace EngageNet.Exceptions
{
	[Serializable]
	public class MappingExistsException : ResponseException
	{
		public MappingExistsException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public MappingExistsException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public MappingExistsException()
		{
		}
	}
}