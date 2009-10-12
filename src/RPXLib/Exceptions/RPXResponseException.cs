using System;
using System.Runtime.Serialization;

namespace RPXLib.Exceptions
{
	[Serializable]
	public abstract class RPXResponseException : RPXException
	{
		protected RPXResponseException()
		{
		}

		protected RPXResponseException(int errorCode, string message, Exception inner)
			: base(message, inner)
		{
			ErrorCode = errorCode;
		}

		protected RPXResponseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public int ErrorCode { get; set; }
	}
}