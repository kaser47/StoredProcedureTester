using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoredProcedureTester.Models;
using StoredProcedureTester.Tests.Consts;

namespace StoredProcedureTester.Tests.Factories
{
    public static class StoredProcedureTestFactory
    {
        public static StoredProcedureTest DefaultTestNoParameters()
        {
            StoredProcedureTest storedProcedureTest = new StoredProcedureTest();
            storedProcedureTest.DatabaseName = StoredProcedureTesterTestsConsts.DatabaseName;
            storedProcedureTest.UnoptimisedStoredProcedureName =
                StoredProcedureTesterTestsConsts.TestUnoptimisedStoredProcedureName;
            storedProcedureTest.OptimisedStoredProcedureName =
                StoredProcedureTesterTestsConsts.TestOptimisedStoredProcedureName;
            
            return storedProcedureTest;
        }
    }
}
