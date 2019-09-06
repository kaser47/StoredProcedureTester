using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoredProcedureTester.Enums;
using StoredProcedureTester.Models;
using StoredProcedureTester.Tests.Consts;

namespace StoredProcedureTester.Tests.Factories
{
    public static class StoredProcedureTestFactory
    {
        public static StoredProcedureTest DefaultTest()
        {
            StoredProcedureTest storedProcedureTest = new StoredProcedureTest();
            storedProcedureTest.DatabaseName = StoredProcedureTesterTestsConsts.DatabaseName;
            storedProcedureTest.UnoptimisedStoredProcedureName = $"[StoredProcedureTester].{StoredProcedureTesterTestsConsts.TestUnoptimisedStoredProcedureName}";
            storedProcedureTest.OptimisedStoredProcedureName = $"[StoredProcedureTester].{StoredProcedureTesterTestsConsts.TestOptimisedStoredProcedureName}";
            
            return storedProcedureTest;
        }

        public static StoredProcedureTest AddIntParameterToBoth(this StoredProcedureTest test, string parameterName, int value)
        {
            test.UnoptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value.ToString(), TestParameterDataType.Int));
            test.OptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value.ToString(), TestParameterDataType.Int));

            return test;
        }

        public static StoredProcedureTest AddStringParameterToBoth(this StoredProcedureTest test, string parameterName, string value)
        {
            test.UnoptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value, TestParameterDataType.String));
            test.OptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value, TestParameterDataType.String));

            return test;
        }

        public static StoredProcedureTest AddGuidParameterToBoth(this StoredProcedureTest test, string parameterName, Guid value)
        {
            test.UnoptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value.ToString(), TestParameterDataType.Guid));
            test.OptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value.ToString(), TestParameterDataType.Guid));

            return test;
        }

        public static StoredProcedureTest AddDateTimeParameterToBoth(this StoredProcedureTest test, string parameterName, DateTime value)
        {
            test.UnoptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value.ToString(), TestParameterDataType.DateTime));
            test.OptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value.ToString(), TestParameterDataType.DateTime));

            return test;
        }

        public static StoredProcedureTest AddBoolParameterToBoth(this StoredProcedureTest test, string parameterName, bool value)
        {
            test.UnoptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value.ToString(), TestParameterDataType.Bool));
            test.OptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value.ToString(), TestParameterDataType.Bool));

            return test;
        }

        public static StoredProcedureTest AddCustomParameterToBoth(this StoredProcedureTest test, string parameterName, string value)
        {
            test.UnoptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value, TestParameterDataType.Custom));
            test.OptimisedStoredProcedureParameters.Add(new TestParameter(parameterName, value, TestParameterDataType.Custom));

            return test;
        }
    }
}
