using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class ApplicationConfigurationException : ResponseException
	{
		public ApplicationConfigurationException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public ApplicationConfigurationException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public ApplicationConfigurationException()
		{
		}
	}
}