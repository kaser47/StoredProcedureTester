using System;
using System.Collections.Generic;
using System.Text;

namespace StoredProcedureTester.Tests.Consts
{
    public static class StoredProcedureTesterTestsConsts
    {
        public static StringBuilder CreateStoredProcedure()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("USE [VCBedrock]");
            sb.AppendLine("GO");
            sb.AppendLine("SET ANSI_NULLS ON");
            sb.AppendLine("GO");
            sb.AppendLine("SET QUOTED_IDENTIFIER ON");
            sb.AppendLine("GO");
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

            sb.AppendLine("USE [VCBedrock]");
            sb.AppendLine("GO");
            sb.AppendLine("DROP PROCEDURE [StoredProcedureTester].{TestName}");
            sb.AppendLine("GO");

            return sb;
        }

        public static string DatabaseName = "VCBedrock";
        public static string ConnectionString = $"SERVER=(local);DATABASE=VC.Bedrock;Integrated Security=true";
        public static string TestUnoptimisedStoredProcedureName = "Test";
        public static string TestOptimisedStoredProcedureName = "TestOptimised";
        
        public static StringBuilder SelectQuery()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("SELECT {Value} AS {Column}");
            return stringBuilder;
        }
    }
}
