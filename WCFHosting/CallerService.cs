using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFHosting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CallerService" in both code and config file together.
    public class CallerService : ICallerService
    {
        public bool Call(string number)
        {
            try
            {
                dynamic utilites = Activator.CreateInstance(Type.GetTypeFromProgID("SmartBarClient.Client"));

                utilites.Init(true, true, false, "", "", "", 0);
                utilites.Agent_PressButton_MakeCall("", number, "");
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
