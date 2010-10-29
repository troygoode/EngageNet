using System.Collections.Generic;

namespace EngageNet.Data
{
	public abstract class ElementBase
	{
		private readonly IDictionary<string, string> _properties = new Dictionary<string, string>();

		protected string GetPropertyValue(string propertyKey)
		{
			return _properties.ContainsKey(propertyKey) ? _properties[propertyKey] : null;
		}

		public void AddProperty(string propertyName, string propertyValue)
		{
			_properties[propertyName] = propertyValue;
		}
	}
}