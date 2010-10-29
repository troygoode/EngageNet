using System.Collections.Generic;

namespace EngageNet.Data
{
	public class Activity
	{
		public string Url { get; set; }
		public string Action { get; set; }
		public string UserGeneratedContent { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public IEnumerable<string> Links { get; set; }
		public IEnumerable<ActivityMedia> Media { get; set; }
		public IDictionary<string, object> Properties { get; set; }
	}
}