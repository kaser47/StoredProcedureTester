using System;
using System.Collections.Generic;
using System.ComponentModel;
using StoredProcedureTester.Interfaces;

namespace StoredProcedureTester.Helpers
{
    class LogHelper : ILogHelper
    {
        public BindingList<KeyValuePair<DateTime, string>> logs { get; }

        public LogHelper()
        {
            logs = new BindingList<KeyValuePair<DateTime, string>>();
        }

        public void Log(string message)
        {
            logs.Add(new KeyValuePair<DateTime, string>(DateTime.UtcNow, message));
        }

        public BindingList<KeyValuePair<DateTime, string>> GetLogs()
        {
            return logs;
        }
    }
}
