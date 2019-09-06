using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using StoredProcedureTester.Tests.Consts;

namespace StoredProcedureTester.Tests.Helpers
{
    public class StoredProcedureHelper : IStoredProcedureHelper
    {
        private readonly ISqlQueryBuilder _sqlQueryBuilder;

        public StoredProcedureHelper(ISqlQueryBuilder sqlQueryBuilder)
        {
            _sqlQueryBuilder = sqlQueryBuilder;
        }

        public async Task DropStoredProceduresAsync()
        {
            string sqlQueryDropFirstStoredProcedure =
                _sqlQueryBuilder.BuildDropStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName);
            string sqlQueryDropSecondStoredProcedure =
                _sqlQueryBuilder.BuildDropStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName);

            string dropSchemaSql = _sqlQueryBuilder.BuildDropSchemaQuery();

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand dropUnoptimisedStoredProcedure = new SqlCommand(sqlQueryDropFirstStoredProcedure, connection);
                SqlCommand dropOptimisedStoredProcedure = new SqlCommand(sqlQueryDropSecondStoredProcedure, connection);
                SqlCommand dropSchema = new SqlCommand(dropSchemaSql, connection);
                await connection.OpenAsync();
                await dropUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await dropOptimisedStoredProcedure.ExecuteNonQueryAsync();
                await dropSchema.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateDuplicateStoredProceduresAsync()
        {
            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("1", "Column1"));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("1", "Column1"));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateTwoStoredProceduresOneReturnsMoreRowsAsync()
        {
            StringBuilder complexSelectQuery = new StringBuilder();
            complexSelectQuery.AppendLine("DECLARE @TestDate TABLE	(Column1 int)");
            complexSelectQuery.AppendLine("INSERT INTO @TestDate (Column1)");
            complexSelectQuery.AppendLine("VALUES");
            complexSelectQuery.AppendLine("(1),");
            complexSelectQuery.AppendLine("(2)");
            complexSelectQuery.AppendLine("SELECT Column1 FROM @TestDate");


            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("1", "Column1"));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateTwoStoredProceduresOneReturnsMoreColumnsAsync()
        {
            StringBuilder complexSelectQuery = new StringBuilder();
            complexSelectQuery.AppendLine("SELECT 1 AS Column1, 2 AS Column2");

            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("1", "Column1"));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateTwoStoredProceduresOneReturnsDifferentColumnAsync()
        {
            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("1", "Column1"));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("1", "Column2"));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateTwoStoredProceduresOneReturnsDifferentDataAsync()
        {
            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("1", "Column1"));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("2", "Column1"));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateDuplicateStoredProceduresThatUseIntParameterAsync()
        {
            StringBuilder complexSelectQuery = new StringBuilder();
            complexSelectQuery.AppendLine("SELECT @TestInt as Column1");

            StringBuilder parameter = new StringBuilder();
            parameter.AppendLine("@TestInt INT");

            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateDuplicateStoredProceduresThatUseStringParameterAsync()
        {
            StringBuilder complexSelectQuery = new StringBuilder();
            complexSelectQuery.AppendLine("SELECT @TestString as Column1");

            StringBuilder parameter = new StringBuilder();
            parameter.AppendLine("@TestString NVARCHAR(MAX)");

            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateDuplicateStoredProceduresThatUseGuidParameterAsync()
        {
            StringBuilder complexSelectQuery = new StringBuilder();
            complexSelectQuery.AppendLine("SELECT @TestGuid as Column1");

            StringBuilder parameter = new StringBuilder();
            parameter.AppendLine("@TestGuid UNIQUEIDENTIFIER");

            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateDuplicateStoredProceduresThatUseDateTimeParameterAsync()
        {
            StringBuilder complexSelectQuery = new StringBuilder();
            complexSelectQuery.AppendLine("SELECT @TestDateTime as Column1");

            StringBuilder parameter = new StringBuilder();
            parameter.AppendLine("@TestDateTime DATETIME");

            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateDuplicateStoredProceduresThatUseBoolParameterAsync()
        {
            StringBuilder complexSelectQuery = new StringBuilder();
            complexSelectQuery.AppendLine("SELECT @TestBool as Column1");

            StringBuilder parameter = new StringBuilder();
            parameter.AppendLine("@TestBool BIT");

            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateDuplicateStoredProceduresThatUseCustomParameterAsync()
        {
            StringBuilder complexSelectQuery = new StringBuilder();
            complexSelectQuery.AppendLine("SELECT @TestCustom as Column1");

            StringBuilder parameter = new StringBuilder();
            parameter.AppendLine("@TestCustom NVARCHAR(MAX)");

            string createSchemaSql = _sqlQueryBuilder.BuildCreateSchemaQuery();

            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, parameter.ToString(), _sqlQueryBuilder.BuildComplexSelectQuery(complexSelectQuery));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand createUnoptimisedStoredProcedure = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand createOptimisedStoredProcedure = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                SqlCommand createSchema = new SqlCommand(createSchemaSql, connection);
                await connection.OpenAsync();
                await createSchema.ExecuteNonQueryAsync();
                await createUnoptimisedStoredProcedure.ExecuteNonQueryAsync();
                await createOptimisedStoredProcedure.ExecuteNonQueryAsync();
            }
        }
    }

    public interface IStoredProcedureHelper
    {
        Task DropStoredProceduresAsync();
        Task CreateDuplicateStoredProceduresAsync();
        Task CreateTwoStoredProceduresOneReturnsMoreRowsAsync();
        Task CreateTwoStoredProceduresOneReturnsMoreColumnsAsync();
        Task CreateTwoStoredProceduresOneReturnsDifferentColumnAsync();
        Task CreateTwoStoredProceduresOneReturnsDifferentDataAsync();
        Task CreateDuplicateStoredProceduresThatUseIntParameterAsync();
        Task CreateDuplicateStoredProceduresThatUseStringParameterAsync();
        Task CreateDuplicateStoredProceduresThatUseGuidParameterAsync();
        Task CreateDuplicateStoredProceduresThatUseDateTimeParameterAsync();
        Task CreateDuplicateStoredProceduresThatUseBoolParameterAsync();
        Task CreateDuplicateStoredProceduresThatUseCustomParameterAsync();
    }
}
