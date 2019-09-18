using System.Text;
using StoredProcedureTester.Consts;
using StoredProcedureTester.Interfaces;
using StoredProcedureTester.Models;

namespace StoredProcedureTester
{
    public class SqlBuilder : ISqlBuilder
    {
        private readonly ILogHelper _logHelper;
        StringBuilder stringBuilder = StoredProcedureTesterConsts.GetTemplate();
        private bool hasBeenBuilt = false;

        public SqlBuilder(ILogHelper logHelper)
        {
            _logHelper = logHelper;
        }

        public void Build(StoredProcedureTest test)
        {
            FillVariables(test);
            _logHelper.Log("Built SQL");
            hasBeenBuilt = true;
        }

        public void BuildSqlQueryText(StoredProcedureTest test)
        {
            if (!hasBeenBuilt)
            {
                Build(test);
            }
        }

        public void ResetSql()
        {
            hasBeenBuilt = false;
            stringBuilder = StoredProcedureTesterConsts.GetTemplate();
        }

        private void FillVariables(StoredProcedureTest test)
        {
            stringBuilder.Replace("{UnoptimisedStoredProcedureName}", $"{test.DatabaseName}.{test.UnoptimisedStoredProcedureName}");
            stringBuilder.Replace("{OptimisedStoredProcedureName}", $"{test.DatabaseName}.{test.OptimisedStoredProcedureName}");

            StringBuilder unOptimisedParameters = new StringBuilder();
            for (int i = 0; i < test.UnoptimisedStoredProcedureParameters.Count; i++)
            {
                TestParameter testParameter = test.UnoptimisedStoredProcedureParameters[i];

                if (i == 0)
                {
                    unOptimisedParameters.AppendLine($"+N' {testParameter.GetSqlString()}'");
                }
                else
                {
                    unOptimisedParameters.AppendLine($"+N', {testParameter.GetSqlString()}'");
                }
            }

            StringBuilder optimisedParameters = new StringBuilder();
            for (int i = 0; i < test.OptimisedStoredProcedureParameters.Count; i++)
            {
                TestParameter testParameter = test.OptimisedStoredProcedureParameters[i];

                if (i == 0)
                {
                    optimisedParameters.AppendLine($"+N' {testParameter.GetSqlString()}'");
                }
                else
                {
                    optimisedParameters.AppendLine($"+N', {testParameter.GetSqlString()}'");
                }
            }

            stringBuilder.Replace("{UsingUnoptimisedParameters}", unOptimisedParameters.ToString());
            stringBuilder.Replace("{UsingOptimisedParameters}", optimisedParameters.ToString());

            test.SetGeneratedSql(stringBuilder.ToString());
        }

    }
}