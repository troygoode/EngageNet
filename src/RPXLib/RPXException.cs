using System;
using System.Runtime.Serialization;

namespace RPXLib
{
	[Serializable]
	public class RPXException : ApplicationException
	{
		public RPXException()
		{
		}

		public RPXException(string message)
			: base(message)
		{
		}

		public RPXException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected RPXException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}