using System.Collections.Generic;

namespace RPXLib.Data
{
    public abstract class RPXElementBase
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