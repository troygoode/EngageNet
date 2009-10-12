using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class RPXAccountUpgradeNeededException : RPXResponseException
	{
		public RPXAccountUpgradeNeededException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public RPXAccountUpgradeNeededException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public RPXAccountUpgradeNeededException()
		{
		}
	}
}