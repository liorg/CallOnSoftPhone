using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WCFHosting
{
    public class Logger
    {
        string sSource;
        string sLog;
        public Logger()
        {
            sSource = "Application";
            sLog = "Dialer";

            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);
        }
        public void Write(string message, EventLogEntryType typeEventLogEntryType = EventLogEntryType.Error)
        {
            message = "{" + GetUserName() + "}" + message;
            EventLog.WriteEntry(sSource, message, typeEventLogEntryType, 234);
        }
        string GetUserName()
        {
            String  userName = Environment.UserName;
           // String UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return userName;
        }
    }
}
