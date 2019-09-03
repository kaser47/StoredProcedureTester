using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedureTester
{
    class LogHelper
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
    }
}
