using System.Threading.Tasks;
using StoredProcedureTester.Models;

namespace StoredProcedureTester.Interfaces
{
    public interface ISqlTestRunner
    {
        Task<TestSummary> Run(StoredProcedureTest currentTest, bool isRetry);
    }
}