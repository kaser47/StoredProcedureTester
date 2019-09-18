using StoredProcedureTester.Models;

namespace StoredProcedureTester.Interfaces
{
    public interface ISqlBuilder
    {
        void BuildSqlQueryText(StoredProcedureTest test);
        void ResetSql();
    }
}