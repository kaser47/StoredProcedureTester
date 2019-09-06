using System;
using System.Collections.Generic;
using System.Text;

namespace StoredProcedureTester.Tests.Consts
{
    public static class StoredProcedureTesterTestsConsts
    {
        public static StringBuilder CreateSchema()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CREATE SCHEMA [StoredProcedureTester];");

            return sb;
        }

        public static StringBuilder DropSchema()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DROP SCHEMA [StoredProcedureTester];");

            return sb;
        }


        public static StringBuilder CreateStoredProcedure()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CREATE PROCEDURE [StoredProcedureTester].{TestName}");
            sb.AppendLine("{Parameters}");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine("	SET NOCOUNT ON;");
            sb.AppendLine("{Query}");
            sb.AppendLine("END");

            return sb;
        }

        public static StringBuilder DropStoredProcedure()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DROP PROCEDURE [StoredProcedureTester].{TestName}");

            return sb;
        }

        public static string DatabaseName = "VCBedrock";
        public static string ConnectionString = $"SERVER=(local);DATABASE=VCBedrock;Integrated Security=true";
        public static string TestUnoptimisedStoredProcedureName = "Test";
        public static string TestOptimisedStoredProcedureName = "TestOptimised";
        
        public static StringBuilder SelectQuery()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT {Value} AS {Column}");
            return stringBuilder;
        }

        public static StringBuilder ComplexSelectQuery()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("{query}");
            return stringBuilder;
        }
    }
}
