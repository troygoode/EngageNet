using System.Collections.Generic;
using System.Xml.Linq;

namespace EngageNet.Api
{
	public interface IApiWrapper
	{
		XElement Call(string methodName, IDictionary<string, string> queryData);
	}
}