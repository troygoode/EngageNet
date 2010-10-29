namespace EngageNet.Mvc
{
	public static class EngageProvider
	{
		public static string ApplicationDomain { get; set; }
		public static IEngageNetSettings Settings { get; set; }

		public static IEngageNet Build()
		{
			return new EngageNet(Settings);
		}
	}
}