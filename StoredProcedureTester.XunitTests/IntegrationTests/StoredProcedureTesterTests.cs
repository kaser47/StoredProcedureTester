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
using Xunit;

namespace StoredProcedureTester.Tests.IntegrationTests
{
    public class StoredProcedureTesterTests
    {
        [Fact]
        public async Task TestTwoStoredProceduresThatReturnTheSameData()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateDuplicateStoredProceduresAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest();
            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeTrue();
            testSummary.ThirdTestResult.Result.ShouldBeTrue();
            testSummary.FourthTestResult.Result.ShouldBeTrue();
            testSummary.OverallResult.ShouldBeTrue();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoStoredProceduresThatReturnDifferentNumberOfRows()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateTwoStoredProceduresOneReturnsMoreRowsAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest();
            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeFalse();
            testSummary.SecondTestResult.Result.ShouldBeFalse();
            testSummary.ThirdTestResult.Result.ShouldBeFalse();
            testSummary.FourthTestResult.Result.ShouldBeFalse();
            testSummary.OverallResult.ShouldBeFalse();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoStoredProceduresThatReturnDifferentNumberOfColumns()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateTwoStoredProceduresOneReturnsMoreColumnsAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest();
            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeFalse();
            testSummary.ThirdTestResult.Result.ShouldBeFalse();
            testSummary.FourthTestResult.Result.ShouldBeFalse();
            testSummary.OverallResult.ShouldBeFalse();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoStoredProceduresThatReturnDifferentColumn()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateTwoStoredProceduresOneReturnsDifferentColumnAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest();
            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeTrue();
            testSummary.ThirdTestResult.Result.ShouldBeFalse();
            testSummary.FourthTestResult.Result.ShouldBeFalse();
            testSummary.OverallResult.ShouldBeFalse();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoStoredProceduresThatReturnDifferentData()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateTwoStoredProceduresOneReturnsDifferentDataAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest();
            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeTrue();
            testSummary.ThirdTestResult.Result.ShouldBeTrue();
            testSummary.FourthTestResult.Result.ShouldBeFalse();
            testSummary.OverallResult.ShouldBeFalse();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoDuplicateStoredProceduresThatUseIntParameter()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseIntParameterAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                .AddIntParameterToBoth("TestInt", 1);

            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeTrue();
            testSummary.ThirdTestResult.Result.ShouldBeTrue();
            testSummary.FourthTestResult.Result.ShouldBeTrue();
            testSummary.OverallResult.ShouldBeTrue();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoDuplicateStoredProceduresThatUseStringParameter()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseStringParameterAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                .AddStringParameterToBoth("TestString", "Test");

            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeTrue();
            testSummary.ThirdTestResult.Result.ShouldBeTrue();
            testSummary.FourthTestResult.Result.ShouldBeTrue();
            testSummary.OverallResult.ShouldBeTrue();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoDuplicateStoredProceduresThatUseGuidParameter()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseGuidParameterAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                .AddGuidParameterToBoth("TestGuid", Guid.NewGuid());

            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeTrue();
            testSummary.ThirdTestResult.Result.ShouldBeTrue();
            testSummary.FourthTestResult.Result.ShouldBeTrue();
            testSummary.OverallResult.ShouldBeTrue();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoDuplicateStoredProceduresThatUseDateTimeParameter()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseDateTimeParameterAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                .AddDateTimeParameterToBoth("TestDateTime", DateTime.Now);

            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeTrue();
            testSummary.ThirdTestResult.Result.ShouldBeTrue();
            testSummary.FourthTestResult.Result.ShouldBeTrue();
            testSummary.OverallResult.ShouldBeTrue();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoDuplicateStoredProceduresThatUseBoolParameter()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseBoolParameterAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                .AddBoolParameterToBoth("TestBool", true);

            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeTrue();
            testSummary.ThirdTestResult.Result.ShouldBeTrue();
            testSummary.FourthTestResult.Result.ShouldBeTrue();
            testSummary.OverallResult.ShouldBeTrue();

            //Drop stored procedures
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        [Fact]
        public async Task TestTwoDuplicateStoredProceduresThatUseCustomParameter()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());

            await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseCustomParameterAsync();

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                .AddCustomParameterToBoth("TestCustom", "Custom");

            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);

            //Check test data is passed
            testSummary.FirstTestResult.Result.ShouldBeTrue();
            testSummary.SecondTestResult.Result.ShouldBeTrue();
            testSummary.ThirdTestResult.Result.ShouldBeTrue();
            testSummary.FourthTestResult.Result.ShouldBeTrue();
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
