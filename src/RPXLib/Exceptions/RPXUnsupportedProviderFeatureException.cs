using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXUnsupportedProviderFeatureException : RPXResponseException
	{
		public RPXUnsupportedProviderFeatureException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXUnsupportedProviderFeatureException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXUnsupportedProviderFeatureException()
		{
		}
	}
}