using System;

namespace EngageNet.Exceptions
{
	[Serializable]
	public class UnsupportedProviderFeatureException : ResponseException
	{
		public UnsupportedProviderFeatureException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public UnsupportedProviderFeatureException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public UnsupportedProviderFeatureException()
		{
		}
	}
}