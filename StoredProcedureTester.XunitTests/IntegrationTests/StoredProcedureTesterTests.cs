using System;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using StoredProcedureTester.Models;
using StoredProcedureTester.Runners;
using StoredProcedureTester.Tests.Enumns;
using StoredProcedureTester.Tests.Factories;
using StoredProcedureTester.Tests.Helpers;
using Xunit;

namespace StoredProcedureTester.Tests.IntegrationTests
{
    public class StoredProcedureTesterTests
    {
        private static async Task Cleanup()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());
            await storedProcedureHelper.DropStoredProceduresAsync();
        }

        private static async Task<TestSummary> RunStoredProcedureTester(StoredProcedureTest storedProcedureTest = null)
        {
            if (storedProcedureTest == null)
            {
                storedProcedureTest = StoredProcedureTestFactory.DefaultTest();
            }

            SqlTestRunner sqlTestRunner = new SqlTestRunner(new NullLogHelper());
            TestSummary testSummary = await sqlTestRunner.Run(storedProcedureTest);
            return testSummary;
        }

        private static StoredProcedureHelper CreateStoredProcedureHelper()
        {
            StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper(new SqlQueryBuilder());
            return storedProcedureHelper;
        }

        private bool CheckResult(TestSummary testSummary, ResultEnum resultEnum)
        {
            bool testResult = false;
            bool firstTest = resultEnum.HasFlag(ResultEnum.FirstTest);
            bool secondTest = resultEnum.HasFlag(ResultEnum.SecondTest);
            bool thirdTest = resultEnum.HasFlag(ResultEnum.ThirdTest);
            bool fourthTest = resultEnum.HasFlag(ResultEnum.FourthTest);
            bool overallTest = resultEnum.HasFlag(ResultEnum.OverallTest);

            if (testSummary.FirstTestResult.Result == firstTest &&
                testSummary.SecondTestResult.Result == secondTest &&
                testSummary.ThirdTestResult.Result == thirdTest &&
                testSummary.FourthTestResult.Result == fourthTest &&
                testSummary.OverallResult == overallTest)
            {
                testResult = true;
            }

            return testResult;
        }

        [Fact]
        [Trait("Integration", "Test Results")]
        public async Task TestTwoStoredProceduresThatReturnTheSameData()
        {
            try
            {
                //Arrange
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateDuplicateStoredProceduresAsync();

                //Act
                var testSummary = await RunStoredProcedureTester();

                //Assert
                CheckResult(testSummary, ResultEnum.AllPass).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }

        [Fact]
        [Trait("Integration", "Test Results")]
        public async Task TestTwoStoredProceduresThatReturnDifferentNumberOfRows()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateTwoStoredProceduresOneReturnsMoreRowsAsync();

                var testSummary = await RunStoredProcedureTester();

                CheckResult(testSummary, ResultEnum.AllFail).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            } 
        }

        [Fact]
        [Trait("Integration", "Test Results")]
        public async Task TestTwoStoredProceduresThatReturnDifferentNumberOfColumns()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateTwoStoredProceduresOneReturnsMoreColumnsAsync();

                var testSummary = await RunStoredProcedureTester();

                CheckResult(testSummary, ResultEnum.FirstTest).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }

        [Fact]
        [Trait("Integration", "Test Results")]
        public async Task TestTwoStoredProceduresThatReturnDifferentColumn()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateTwoStoredProceduresOneReturnsDifferentColumnAsync();

                var testSummary = await RunStoredProcedureTester();

                CheckResult(testSummary, ResultEnum.FirstTest | ResultEnum.SecondTest).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }

        [Fact]
        [Trait("Integration", "Test Results")]
        public async Task TestTwoStoredProceduresThatReturnDifferentData()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateTwoStoredProceduresOneReturnsDifferentDataAsync();

                var testSummary = await RunStoredProcedureTester();

                CheckResult(testSummary, ResultEnum.FirstTest | ResultEnum.SecondTest | ResultEnum.ThirdTest).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }

        [Fact]
        [Trait("Integration", "Test Parameters")]
        public async Task TestTwoDuplicateStoredProceduresThatUseIntParameter()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseIntParameterAsync();

                StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                    .AddIntParameterToBoth("TestInt", 1);

                var testSummary = await RunStoredProcedureTester(storedProcedureTest);

                CheckResult(testSummary, ResultEnum.AllPass).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }

        [Fact]
        [Trait("Integration", "Test Parameters")]
        public async Task TestTwoDuplicateStoredProceduresThatUseStringParameter()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseStringParameterAsync();

                StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                    .AddStringParameterToBoth("TestString", "Test");

                var testSummary = await RunStoredProcedureTester(storedProcedureTest);

                CheckResult(testSummary, ResultEnum.AllPass).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }

        [Fact]
        [Trait("Integration", "Test Parameters")]
        public async Task TestTwoDuplicateStoredProceduresThatUseGuidParameter()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseGuidParameterAsync();

                StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                    .AddGuidParameterToBoth("TestGuid", Guid.NewGuid());

                var testSummary = await RunStoredProcedureTester(storedProcedureTest);

                CheckResult(testSummary, ResultEnum.AllPass).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }

        [Fact]
        [Trait("Integration", "Test Parameters")]
        public async Task TestTwoDuplicateStoredProceduresThatUseDateTimeParameter()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseDateTimeParameterAsync();

                StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                    .AddDateTimeParameterToBoth("TestDateTime", DateTime.Now);

                var testSummary = await RunStoredProcedureTester(storedProcedureTest);

                CheckResult(testSummary, ResultEnum.AllPass).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }

        [Fact]
        [Trait("Integration", "Test Parameters")]
        public async Task TestTwoDuplicateStoredProceduresThatUseBoolParameter()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseBoolParameterAsync();

                StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                    .AddBoolParameterToBoth("TestBool", true);

                var testSummary = await RunStoredProcedureTester(storedProcedureTest);

                CheckResult(testSummary, ResultEnum.AllPass).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }

        [Fact]
        [Trait("Integration", "Test Parameters")]
        public async Task TestTwoDuplicateStoredProceduresThatUseCustomParameter()
        {
            try
            {
                var storedProcedureHelper = CreateStoredProcedureHelper();
                await storedProcedureHelper.CreateDuplicateStoredProceduresThatUseCustomParameterAsync();

                StoredProcedureTest storedProcedureTest = StoredProcedureTestFactory.DefaultTest()
                    .AddCustomParameterToBoth("TestCustom", "Custom");

                var testSummary = await RunStoredProcedureTester(storedProcedureTest);

                CheckResult(testSummary, ResultEnum.AllPass).ShouldBeTrue();
            }
            finally
            {
                await Cleanup();
            }
        }
    }
}
