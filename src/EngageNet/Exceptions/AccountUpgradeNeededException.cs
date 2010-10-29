using System;

namespace RPXLib.Exceptions
{
	[Serializable]
	public class AccountUpgradeNeededException : ResponseException
	{
		public AccountUpgradeNeededException(int errorCode, string message, Exception inner)
			: base(errorCode, message, inner)
		{
		}

		public AccountUpgradeNeededException(int errorCode, string message)
			: base(errorCode, message, null)
		{
		}

		public AccountUpgradeNeededException()
		{
		}
	}
}