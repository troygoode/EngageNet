using System.Collections.Generic;
using System.Xml.Linq;

namespace RPXLib.Interfaces
{
    public interface IRPXApiWrapper
    {
        XElement Call(string methodName, IDictionary<string, string> queryData);
    }
}