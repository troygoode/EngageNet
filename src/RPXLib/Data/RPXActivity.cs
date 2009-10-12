using System.Collections.Generic;

namespace RPXLib.Data
{
	public class RPXActivity
	{
		public string Url { get; set; }
		public string Action { get; set; }
		public string UserGeneratedContent { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public IEnumerable<string> Links { get; set; }
		public IEnumerable<RPXActivityMedia> Media { get; set; }
		public IDictionary<string, object> Properties { get; set; }
	}
}