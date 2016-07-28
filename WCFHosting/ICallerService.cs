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
    //netsh http add urlacl url=http://+:5884/CallerService user=everyone
    [ServiceContract]
    public interface ICallerService
    {
        [OperationContract]
        //[WebInvoke(Method = "*")]
        [WebGet(UriTemplate = "Call/{number}")]
        string Call(string number);
        [OperationContract]
        //[WebInvoke(Method = "*")]
        [WebGet(UriTemplate = "Stop")]
        void Stop();
        [WebGet(UriTemplate = "Ping")]
        string Ping();
    }
}
