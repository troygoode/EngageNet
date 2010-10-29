using System.Collections.Generic;

namespace EngageNet.Data
{
	public abstract class ElementBase
	{
		private readonly IDictionary<string, string> properties = new Dictionary<string, string>();

		protected string GetPropertyValue(string propertyKey)
		{
			return properties.ContainsKey(propertyKey) ? properties[propertyKey] : null;
		}

		public void AddProperty(string propertyName, string propertyValue)
		{
			properties[propertyName] = propertyValue;
		}
	}
}