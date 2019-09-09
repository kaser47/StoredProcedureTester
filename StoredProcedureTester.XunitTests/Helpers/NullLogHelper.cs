using System;
using System.Collections.Generic;
using System.ComponentModel;
using StoredProcedureTester.Interfaces;

namespace StoredProcedureTester.Tests.IntegrationTests
{
    public class NullLogHelper : ILogHelper
    {
        public void Log(string message)
        {
            return;
        }

        public BindingList<KeyValuePair<DateTime, string>> GetLogs()
        {
            return null;
        }
    }
}