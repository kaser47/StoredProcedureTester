using System.ComponentModel;

namespace StoredProcedureTester.Models
{
    public class StoredProcedureTest
    {
        public string DatabaseName { get; set; }
        public string UnoptimisedStoredProcedureName { get; set; }
        public string OptimisedStoredProcedureName { get; set; }
        public BindingList<TestParameter> UnoptimisedStoredProcedureParameters { get; set; }
        public BindingList<TestParameter> OptimisedStoredProcedureParameters { get; set; }

        public string GeneratedSql { get; private set; }

        public StoredProcedureTest()
        {
            UnoptimisedStoredProcedureParameters = new BindingList<TestParameter>();
            OptimisedStoredProcedureParameters = new BindingList<TestParameter>();
        }

        public static StoredProcedureTest Default()
        {
            StoredProcedureTest test = new StoredProcedureTest();
            test.UnoptimisedStoredProcedureName = "VCBedrock.dbo.Test";
            test.OptimisedStoredProcedureName = "VCBedrock.dbo.TestOptimised";

            test.UnoptimisedStoredProcedureParameters.Add(TestParameter.Default());
            test.OptimisedStoredProcedureParameters.Add(TestParameter.Default());

            return test;
        }

        public void SetGeneratedSql(string sql)
        {
            GeneratedSql = sql;
        }
    }
}