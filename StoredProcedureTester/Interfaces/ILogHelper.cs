using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedureTester.Interfaces
{
    public interface ILogHelper
    {
        void Log(string message);
        BindingList<KeyValuePair<DateTime, string>> GetLogs();
    }
}
