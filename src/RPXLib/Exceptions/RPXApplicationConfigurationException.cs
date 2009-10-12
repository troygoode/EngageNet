using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXApplicationConfigurationException : RPXResponseException
	{
		public RPXApplicationConfigurationException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXApplicationConfigurationException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXApplicationConfigurationException()
		{
		}
	}
}