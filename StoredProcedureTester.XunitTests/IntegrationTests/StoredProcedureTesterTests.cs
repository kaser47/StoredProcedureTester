using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using StoredProcedureTester.Interfaces;
using StoredProcedureTester.Models;
using StoredProcedureTester.Runners;
using StoredProcedureTester.Tests.Factories;
using StoredProcedureTester.Tests.Helpers;

namespace StoredProcedureTester.Tests.IntegrationTests
{
    public class StoredProcedureTesterTests
    {
        public async Task TestTwoStoredProceduresThatReturnTheSameData()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateDuplicateStoredProceduresAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTestNoParameters();
            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.OverallResult.ShouldBeTrue();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }
    }

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
