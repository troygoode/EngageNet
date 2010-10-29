namespace EngageNet.Data
{
	public class ActivityMediaFlash : ActivityMedia
	{
		public string SwfUrl { get; set; }
		public string ImageUrl { get; set; }
		public int? Width { get; set; }
		public int? WidthExpanded { get; set; }
		public int? Height { get; set; }
		public int? HeightExpanded { get; set; }
	}
}