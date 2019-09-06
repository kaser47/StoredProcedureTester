using System.Threading.Tasks;
using StoredProcedureTester.Interfaces;
using StoredProcedureTester.Models;

namespace StoredProcedureTester.Runners
{
    public class SqlTestRunner : ISqlTestRunner
    {
        private readonly ISqlRunner _sqlRunner;
        private readonly ISqlBuilder _sqlBuilder;
        private readonly ILogHelper _logHelper;

        public string GeneratedSql { get; }

        public SqlTestRunner(ILogHelper logHelper)
        {
            _logHelper = logHelper;
            _sqlRunner = new SqlRunner(_logHelper);
            _sqlBuilder = new SqlBuilder(_logHelper);
        }

        public async Task<TestSummary> Run(StoredProcedureTest currentTest)
        {
            _sqlBuilder.BuildSqlQueryText(currentTest);
            TestSummary testSummary = await _sqlRunner.RunSqlAsync(currentTest);
            return testSummary;
        }
    }
}