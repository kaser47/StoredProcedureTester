using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProcedureTester
{
    public static class StoredProcedureTesterConsts
    {
        public static StringBuilder GetTemplate()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("sp_configure 'Show Advanced Options', 1;");
            sb.AppendLine("GO");
            sb.AppendLine("RECONFIGURE;");
            sb.AppendLine("GO");
            sb.AppendLine("sp_configure 'Ad Hoc Distributed Queries', 1;");
            sb.AppendLine("GO");
            sb.AppendLine("RECONFIGURE;");
            sb.AppendLine("GO");
            sb.AppendLine("IF OBJECT_ID('tempdb..##UnoptimisedTempTable') IS NOT NULL");
            sb.AppendLine("    DROP TABLE ##UnoptimisedTempTable;");
            sb.AppendLine("IF OBJECT_ID('tempdb..##OptimisedTempTable') IS NOT NULL");
            sb.AppendLine("    DROP TABLE ##OptimisedTempTable;");
            sb.AppendLine("DECLARE @Fail BIT = 0;");
            sb.AppendLine("--When comparing two stored procedures you need to make sure you update these two variables--");

            sb.AppendLine("DECLARE @BeforeStoredProcedureName NVARCHAR(100) = N'{UnoptimisedStoredProcedureName}';");
            sb.AppendLine("DECLARE @AfterStoredProcedureName NVARCHAR(100) = N'{OptimisedStoredProcedureName}';");

            sb.AppendLine("DECLARE @UnoptimisedStart DATETIME;");
            sb.AppendLine("DECLARE @UnoptimisedEnd DATETIME;");
            sb.AppendLine("DECLARE @OptimisedStart DATETIME;");
            sb.AppendLine("DECLARE @OptimisedEnd DATETIME;");
            sb.AppendLine("DECLARE @BeforeSql NVARCHAR(MAX);");
            sb.AppendLine("SET @BeforeSql");
            sb.AppendLine("    = N'SELECT * INTO ##UnoptimisedTempTable FROM OPENROWSET(''SQLNCLI'', ''Server=(local);Trusted_Connection=yes;'',");
            sb.AppendLine("    ''EXEC ' + @BeforeStoredProcedureName");

            sb.AppendLine("{UsingUnoptimisedParameters}");

            sb.AppendLine("	  + ''')';");
            sb.AppendLine("SET @UnoptimisedStart = GETUTCDATE()");
            sb.AppendLine("EXEC (@BeforeSql);");
            sb.AppendLine("SET @UnoptimisedEnd = GETUTCDATE()");
            sb.AppendLine("DECLARE @AfterSql NVARCHAR(MAX);");
            sb.AppendLine("SET @AfterSql");
            sb.AppendLine("    = N'SELECT * INTO ##OptimisedTempTable FROM OPENROWSET(''SQLNCLI'', ''Server=(local);Trusted_Connection=yes;'',");
            sb.AppendLine("    ''EXEC ' + @AfterStoredProcedureName");
            sb.AppendLine("      --Parameters for the optimised stored procedure should be added here, I have left some examples commented out to make it easier.");

            sb.AppendLine("{UsingOptimisedParameters}");

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
            sb.AppendLine("    PRINT ('Both queries returned ' + CAST(@UnoptimisedCount AS NVARCHAR(MAX)) + ' record(s)');");
            sb.AppendLine("    SELECT @UnoptimisedNumberOfColumns = COUNT(*)");
            sb.AppendLine("    FROM tempdb.sys.columns");
            sb.AppendLine("    WHERE object_id = OBJECT_ID('tempdb..##UnoptimisedTempTable');");
            sb.AppendLine("    SELECT @OptimisedNumberOfColumns = COUNT(*)");
            sb.AppendLine("    FROM tempdb.sys.columns");
            sb.AppendLine("    WHERE object_id = OBJECT_ID('tempdb..##OptimisedTempTable');");
            sb.AppendLine("	--Test both queries return same number of columns");
            sb.AppendLine("    IF (@UnoptimisedNumberOfColumns = @OptimisedNumberOfColumns)");
            sb.AppendLine("    BEGIN");
            sb.AppendLine("        PRINT ('Both queries have ' + CAST(@UnoptimisedCount AS NVARCHAR(MAX)) + ' column(s)');");
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
            sb.AppendLine("            PRINT ('Both queries have the same column(s)');");
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
            sb.AppendLine("                PRINT ('Both queries return the same record(s)');");
            sb.AppendLine("            END;");
            sb.AppendLine("            ELSE");
            sb.AppendLine("            BEGIN");
            sb.AppendLine("                PRINT ('Queries return different record(s)');");
            sb.AppendLine("				SET @Fail = 1;");
            sb.AppendLine("            END;");
            sb.AppendLine("        END;");
            sb.AppendLine("        ELSE");
            sb.AppendLine("        BEGIN");
            sb.AppendLine("            PRINT ('The queries return different column(s)');");
            sb.AppendLine("			SET @Fail = 1;");
            sb.AppendLine("        END;");
            sb.AppendLine("    END;");
            sb.AppendLine("ELSE");
            sb.AppendLine("BEGIN");
            sb.AppendLine("    PRINT ('Unoptimised returns ' + CAST(@UnoptimisedNumberOfColumns AS NVARCHAR(MAX))");
            sb.AppendLine("           + ' column(s) BUT optimised returned ' + CAST(@OptimisedNumberOfColumns AS NVARCHAR(MAX)) + ' column(s)'");
            sb.AppendLine("          );");
            sb.AppendLine("	SET @Fail = 1;");
            sb.AppendLine("END;");
            sb.AppendLine("END;");
            sb.AppendLine("   ELSE");
            sb.AppendLine("    BEGIN");
            sb.AppendLine("        PRINT ('Unoptimised returned ' + CAST(@UnoptimisedCount AS NVARCHAR(MAX))");
            sb.AppendLine("               + ' record(s) BUT optimised returned ' + CAST(@OptimisedCount AS NVARCHAR(MAX)) + ' record(s)'");
            sb.AppendLine("              );");
            sb.AppendLine("        SET @Fail = 1;");
            sb.AppendLine("    END;");
            sb.AppendLine("	DECLARE @UnoptimsedTotalTime AS FLOAT = CONVERT(FLOAT, DATEDIFF(MILLISECOND,@UnoptimisedStart,@UnoptimisedEnd)) ");
            sb.AppendLine("	DECLARE @OptimsedTotalTime AS FLOAT = CONVERT(FLOAT, DATEDIFF(MILLISECOND,@OptimisedStart,@OptimisedEnd))");
            sb.AppendLine("	DECLARE @DifferencePercentage AS FLOAT = (@OptimsedTotalTime / @UnoptimsedTotalTime) * 100");
            sb.AppendLine("PRINT('Unoptimsed took: ' ");
            sb.AppendLine("	+ CAST(@UnoptimsedTotalTime AS NVARCHAR(MAX)) ");
            sb.AppendLine("	+ '(ms) Optimised took: '");
            sb.AppendLine("	+ CAST(@OptimsedTotalTime AS NVARCHAR(MAX)) ");
            sb.AppendLine("	+ '(ms) Difference: '+");
            sb.AppendLine("	+ CAST(@DifferencePercentage AS NVARCHAR(MAX)) ");
            sb.AppendLine("	+'%')");
            sb.AppendLine("IF (@Fail = 0)");
            sb.AppendLine("BEGIN");
            sb.AppendLine("    PRINT('PASS');");
            sb.AppendLine("END;");
            sb.AppendLine("ELSE");
            sb.AppendLine("BEGIN");
            sb.AppendLine("    PRINT('FAIL');");
            sb.AppendLine("END;");
            sb.AppendLine("IF OBJECT_ID('tempdb..##UnoptimisedTempTable') IS NOT NULL");
            sb.AppendLine("    DROP TABLE ##UnoptimisedTempTable;");
            sb.AppendLine("IF OBJECT_ID('tempdb..##OptimisedTempTable') IS NOT NULL");
            sb.AppendLine("    DROP TABLE ##OptimisedTempTable;");

            return sb;
        }


    }
}
