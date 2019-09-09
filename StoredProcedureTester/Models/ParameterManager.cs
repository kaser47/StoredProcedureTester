using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoredProcedureTester.Enums;
using StoredProcedureTester.Interfaces;

namespace StoredProcedureTester.Models
{
    //Todo: ASHR006 - Finish writing this class then implement it.

    public class ParameterManager : IParameterManager
    {
        private readonly ILogHelper _logHelper;
        private readonly StoredProcedureTest _test;

        public ParameterManager(ILogHelper logHelper,StoredProcedureTest test)
        {
            _logHelper = logHelper;
            _test = test;
        }

        public void AddParameter(string name, string value, ParameterType type, TestParameterDataType dataType)
        {
            //TODO: ASHR006 - Add Validation
            TestParameter newTestParameter = new TestParameter(name, value, dataType);

            if (type.HasFlag(ParameterType.Optimised))
            {
                _test.OptimisedStoredProcedureParameters.Add(newTestParameter);
                _logHelper.Log($"Added: {newTestParameter} to Optimised");
            }

            if (type.HasFlag(ParameterType.Unoptimised))
            {
                _test.UnoptimisedStoredProcedureParameters.Add(newTestParameter);
                _logHelper.Log($"Added: {newTestParameter} to Unoptimised");
            }
        }

        public void RemoveParameter(TestParameter testParameter, ParameterType type)
        {
            if (type.HasFlag(ParameterType.Optimised))
            {
                _test.OptimisedStoredProcedureParameters.Remove(testParameter);
                _logHelper.Log($"Removed: {testParameter} to Optimised");
            }

            if (type.HasFlag(ParameterType.Unoptimised))
            {
                _test.UnoptimisedStoredProcedureParameters.Remove(testParameter);
                _logHelper.Log($"Removed: {testParameter} to Unoptimised");
            }
        }
    }
}
