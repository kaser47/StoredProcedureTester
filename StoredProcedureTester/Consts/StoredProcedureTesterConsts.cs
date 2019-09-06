using System.Collections.Generic;
using System.Text;

namespace StoredProcedureTester.Consts
{
    public static class StoredProcedureTesterConsts
    {
        public static List<string> StartupScripts = new List<string>()
        {
            "sp_configure 'Show Advanced Options', 1;",
            "RECONFIGURE;",
            "sp_configure 'Ad Hoc Distributed Queries', 1;",
            "RECONFIGURE;"
        };

        public static string FilePath = @"C:/Temp/StoredProcedureTester/";
        public static string Filename = @"results.csv";


        public static StringBuilder GetTemplate()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("IF OBJECT_ID('tempdb..##UnoptimisedTempTable') IS NOT NULL");
            sb.AppendLine("    DROP TABLE ##UnoptimisedTempTable;");
            sb.AppendLine("IF OBJECT_ID('tempdb..##OptimisedTempTable') IS NOT NULL");
            sb.AppendLine("    DROP TABLE ##OptimisedTempTable;");
            sb.AppendLine("DECLARE @OverallResult BIT = 0;");
            sb.AppendLine("--When comparing two stored procedures you need to make sure you update these two variables--");

            sb.AppendLine("DECLARE @BeforeStoredProcedureName NVARCHAR(100) = N'{UnoptimisedStoredProcedureName}';");
            sb.AppendLine("DECLARE @AfterStoredProcedureName NVARCHAR(100) = N'{OptimisedStoredProcedureName}';");

            sb.AppendLine("DECLARE @FirstTestResult BIT = 0;");
            sb.AppendLine("DECLARE @FirstTestMessage NVARCHAR(100);");
            sb.AppendLine("DECLARE @SecondTestResult BIT = 0;");
            sb.AppendLine("DECLARE @SecondTestMessage NVARCHAR(100);");
            sb.AppendLine("DECLARE @ThirdTestResult BIT = 0;");
            sb.AppendLine("DECLARE @ThirdTestMessage NVARCHAR(100);");
            sb.AppendLine("DECLARE @FourthTestResult BIT = 0;");
            sb.AppendLine("DECLARE @FourthTestMessage NVARCHAR(100);");
            sb.AppendLine("DECLARE @UnoptimisedStart DATETIME;");
            sb.AppendLine("DECLARE @UnoptimisedEnd DATETIME;");
            sb.AppendLine("DECLARE @OptimisedStart DATETIME;");
            sb.AppendLine("DECLARE @OptimisedEnd DATETIME;");
            sb.AppendLine("DECLARE @BeforeSql NVARCHAR(MAX);");
            sb.AppendLine("SET @BeforeSql");
            sb.AppendLine("    = N'SELECT * INTO ##UnoptimisedTempTable FROM OPENROWSET(''SQLNCLI'', ''Server=(local);Trusted_Connection=yes;'',");
            sb.AppendLine("    ''EXEC ' + @BeforeStoredProcedureName");

            sb.AppendLine("	{UsingUnoptimisedParameters}");

            sb.AppendLine("	  + ''')';");
            sb.AppendLine("SET @UnoptimisedStart = GETUTCDATE()");
            sb.AppendLine("EXEC (@BeforeSql);");
            sb.AppendLine("SET @UnoptimisedEnd = GETUTCDATE()");
            sb.AppendLine("DECLARE @AfterSql NVARCHAR(MAX);");
            sb.AppendLine("SET @AfterSql");
            sb.AppendLine("    = N'SELECT * INTO ##OptimisedTempTable FROM OPENROWSET(''SQLNCLI'', ''Server=(local);Trusted_Connection=yes;'',");
            sb.AppendLine("    ''EXEC ' + @AfterStoredProcedureName");
            sb.AppendLine("      --Parameters for the optimised stored procedure should be added here, I have left some examples commented out to make it easier.");

            sb.AppendLine("	  {UsingOptimisedParameters}");

            sb.AppendLine("	  + ''')';");
            sb.AppendLine("SET @OptimisedStart = GETUTCDATE()");
            sb.AppendLine("EXEC (@AfterSql);");
            sb.AppendLine("SET @OptimisedEnd = GETUTCDATE()");
            sb.AppendLine("DECLARE @UnoptimisedCount INT;");
            sb.AppendLine("DECLARE @OptimisedCount INT;");
            sb.AppendLine("DECLARE @IdenticalCount INT;");
            sb.AppendLine("DECLARE @UnoptimisedNumberOfColumns INT;");
            sb.AppendLine("DECLARE @OptimisedNumberOfColumns INT;");
            sb.AppendLine("DECLARE @IdenticalNumberOfColumns INT;");
            sb.AppendLine("SELECT @UnoptimisedCount = COUNT(*)");
            sb.AppendLine("FROM");
            sb.AppendLine("(SELECT * FROM ##UnoptimisedTempTable) AS u;");
            sb.AppendLine("SELECT @OptimisedCount = COUNT(*)");
            sb.AppendLine("FROM");
            sb.AppendLine("(SELECT * FROM ##OptimisedTempTable) AS o;");
            sb.AppendLine("--Test both queries return same number of records");
            sb.AppendLine("IF (@UnoptimisedCount = @OptimisedCount)");
            sb.AppendLine("BEGIN");
            sb.AppendLine("	SET @FirstTestMessage = 'Both queries returned ' + CAST(@UnoptimisedCount AS NVARCHAR(MAX)) + ' record(s)';");
            sb.AppendLine("    SET @FirstTestResult = 1;");
            sb.AppendLine("	SELECT @UnoptimisedNumberOfColumns = COUNT(*)");
            sb.AppendLine("    FROM tempdb.sys.columns");
            sb.AppendLine("    WHERE object_id = OBJECT_ID('tempdb..##UnoptimisedTempTable');");
            sb.AppendLine("    SELECT @OptimisedNumberOfColumns = COUNT(*)");
            sb.AppendLine("    FROM tempdb.sys.columns");
            sb.AppendLine("    WHERE object_id = OBJECT_ID('tempdb..##OptimisedTempTable');");
            sb.AppendLine("	--Test both queries return same number of columns");
            sb.AppendLine("    IF (@UnoptimisedNumberOfColumns = @OptimisedNumberOfColumns)");
            sb.AppendLine("    BEGIN");
            sb.AppendLine("	SET @SecondTestMessage = 'Both queries have ' + CAST(@UnoptimisedCount AS NVARCHAR(MAX)) + ' column(s)';");
            sb.AppendLine("	SET @SecondTestResult = 1");
            sb.AppendLine("        SELECT @IdenticalNumberOfColumns = COUNT(*)");
            sb.AppendLine("        FROM");
            sb.AppendLine("        (");
            sb.AppendLine("            SELECT name,");
            sb.AppendLine("                   system_type_id,");
            sb.AppendLine("                   user_type_id");
            sb.AppendLine("            FROM tempdb.sys.columns");
            sb.AppendLine("            WHERE object_id = OBJECT_ID('tempdb..##UnoptimisedTempTable')");
            sb.AppendLine("            GROUP BY name,");
            sb.AppendLine("                     system_type_id,");
            sb.AppendLine("                     user_type_id,");
            sb.AppendLine("                     max_length");
            sb.AppendLine("            UNION");
            sb.AppendLine("            SELECT name,");
            sb.AppendLine("                   system_type_id,");
            sb.AppendLine("                   user_type_id");
            sb.AppendLine("            FROM tempdb.sys.columns");
            sb.AppendLine("            WHERE object_id = OBJECT_ID('tempdb..##OptimisedTempTable')");
            sb.AppendLine("            GROUP BY name,");
            sb.AppendLine("                     system_type_id,");
            sb.AppendLine("                     user_type_id,");
            sb.AppendLine("                     max_length");
            sb.AppendLine("        ) AS t;");
            sb.AppendLine("		--Test both queries have the same columns (Checks against name, type and max length");
            sb.AppendLine("        IF (");
            sb.AppendLine("               @IdenticalNumberOfColumns = @UnoptimisedNumberOfColumns");
            sb.AppendLine("               AND @IdenticalNumberOfColumns = @OptimisedNumberOfColumns");
            sb.AppendLine("           )");
            sb.AppendLine("        BEGIN");
            sb.AppendLine("		SET @ThirdTestMessage = 'Both queries have the same column(s)';");
            sb.AppendLine("		SET @ThirdTestResult = 1;");
            sb.AppendLine("            SELECT @IdenticalCount = COUNT(*)");
            sb.AppendLine("            FROM");
            sb.AppendLine("            (");
            sb.AppendLine("                SELECT *");
            sb.AppendLine("                FROM ##UnoptimisedTempTable");
            sb.AppendLine("                UNION");
            sb.AppendLine("                SELECT *");
            sb.AppendLine("                FROM ##OptimisedTempTable");
            sb.AppendLine("            ) AS i;");
            sb.AppendLine("			--Test both queries return the exact same data");
            sb.AppendLine("            IF (");
            sb.AppendLine("                   @IdenticalCount = @UnoptimisedCount");
            sb.AppendLine("                   AND @IdenticalCount = @OptimisedCount");
            sb.AppendLine("               )");
            sb.AppendLine("            BEGIN");
            sb.AppendLine("               SET @FourthTestMessage ='Both queries return the same record(s)';");
            sb.AppendLine("			   SET @FourthTestResult = 1;");
            sb.AppendLine("			   SET @OverallResult = 1;");
            sb.AppendLine("            END;");
            sb.AppendLine("            ELSE");
            sb.AppendLine("            BEGIN");
            sb.AppendLine("                SET @FourthTestMessage = 'Queries return different record(s)';");
            sb.AppendLine("            END;");
            sb.AppendLine("        END;");
            sb.AppendLine("        ELSE");
            sb.AppendLine("        BEGIN");
            sb.AppendLine("            SET @ThirdTestMessage = 'The queries return different column(s)';");
            sb.AppendLine("        END;");
            sb.AppendLine("    END;");
            sb.AppendLine("ELSE");
            sb.AppendLine("BEGIN");
            sb.AppendLine("    SET @SecondTestMessage = 'Unoptimised returns ' + CAST(@UnoptimisedNumberOfColumns AS NVARCHAR(MAX))");
            sb.AppendLine("           + ' column(s) BUT optimised returned ' + CAST(@OptimisedNumberOfColumns AS NVARCHAR(MAX)) + ' column(s)';");
            sb.AppendLine("END;");
            sb.AppendLine("END;");
            sb.AppendLine("   ELSE");
            sb.AppendLine("    BEGIN");
            sb.AppendLine("        SET @FirstTestMessage = 'Unoptimised returned ' + CAST(@UnoptimisedCount AS NVARCHAR(MAX))");
            sb.AppendLine("               + ' record(s) BUT optimised returned ' + CAST(@OptimisedCount AS NVARCHAR(MAX)) + ' record(s)';");
            sb.AppendLine("    END;");
            sb.AppendLine("IF OBJECT_ID('tempdb..##UnoptimisedTempTable') IS NOT NULL");
            sb.AppendLine("    DROP TABLE ##UnoptimisedTempTable;");
            sb.AppendLine("IF OBJECT_ID('tempdb..##OptimisedTempTable') IS NOT NULL");
            sb.AppendLine("    DROP TABLE ##OptimisedTempTable;");
            sb.AppendLine("SELECT	");
            sb.AppendLine("		");
            sb.AppendLine("		@FirstTestResult AS [First Test Result], ");
            sb.AppendLine("		@FirstTestMessage AS [First Test Message], ");
            sb.AppendLine("		");
            sb.AppendLine("		@SecondTestResult AS [Second Test Result], ");
            sb.AppendLine("		@SecondTestMessage AS [Second Test Message], ");
            sb.AppendLine("		");
            sb.AppendLine("		@ThirdTestResult AS [Third Test Result],");
            sb.AppendLine("		@ThirdTestMessage AS [Third Test Message],");
            sb.AppendLine("		");
            sb.AppendLine("		@FourthTestResult AS [Fourth Test Result],");
            sb.AppendLine("		@FourthTestMessage AS [Fourth Test Message],");
            sb.AppendLine("		");
            sb.AppendLine("		@OverallResult AS [Overall Result], ");
            sb.AppendLine("		@UnoptimisedStart AS [Unoptimised Start], ");
            sb.AppendLine("		@UnoptimisedEnd AS [Unoptimised End], ");
            sb.AppendLine("		@OptimisedStart AS [Optimised Start], ");
            sb.AppendLine("		@OptimisedEnd AS [Optimised End]");


            return sb;
        }


    }
}
