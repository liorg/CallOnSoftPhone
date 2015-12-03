using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WCFHosting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICallerService" in both code and config file together.
    [ServiceContract]
    public interface ICallerService
    {
        [OperationContract]
        [WebGet(UriTemplate = "Call/{number}")]
        bool Call(string number);
    }
}
