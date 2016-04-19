using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace WCFHosting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CallerService" in both code and config file together.
    public class CallerService : ICallerService
    {
        
        //  //http://localhost:5884/CallService/Call/444444
        public string Call(string number)
        {
            try
            {
                Config config = Config.GetSinglton();

                //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
                //HttpContext.Current.Response.AddHeader("Access-Control-Request-Method", "POST,GET,PUT,DELETE,OPTIONS");
                //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "X-Requested-With,Content-Type,Content-Length,Accept");
                
                dynamic utilites = Activator.CreateInstance(Type.GetTypeFromProgID("SmartBarClient.Client"));
                var userName = String.IsNullOrEmpty(config.UserName) ? "" : config.UserName;
                var pws = String.IsNullOrEmpty(config.Pws) ? "" : config.Pws;

                int objInit = utilites.Init(true, true, false, userName, pws, "", 0);
                int objCall=utilites.Agent_PressButton_MakeCall("", number, "");
                return "ok user="+ userName+",pws="+ pws+" for number " + number + ",objInit=" + objInit.ToString()+",objCall=" + objCall.ToString();
            }
            catch (Exception e)
            {

                return e.ToString();
            }
        }
    }
}
