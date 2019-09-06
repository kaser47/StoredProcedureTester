using System.Threading.Tasks;
using StoredProcedureTester.Models;

namespace StoredProcedureTester.Interfaces
{
    public interface ISqlRunner
    {
        Task<TestSummary> RunSqlAsync(StoredProcedureTest test);
    }
}