using System;
using System.Runtime.Serialization;

namespace EngageNet.Exceptions
{
	[Serializable]
	public abstract class ResponseException : EngageException
	{
		protected ResponseException()
		{
		}

		protected ResponseException(int errorCode, string message, Exception inner)
			: base(message, inner)
		{
			ErrorCode = errorCode;
		}

		protected ResponseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public int ErrorCode { get; set; }
	}
}