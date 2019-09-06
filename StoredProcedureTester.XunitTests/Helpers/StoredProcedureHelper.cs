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

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlQueryDropFirstStoredProcedure, connection);
                SqlCommand command2 = new SqlCommand(sqlQueryDropSecondStoredProcedure, connection);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                await command2.ExecuteNonQueryAsync();
            }
        }

        public async Task CreateDuplicateStoredProceduresAsync()
        {
            string sqlQueryCreateFirstStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestUnoptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("1", "Column1"));

            string sqlQueryCreateSecondStoredProcedure =
                _sqlQueryBuilder.BuildCreateStoredProcedureQuery(StoredProcedureTesterTestsConsts
                    .TestOptimisedStoredProcedureName, string.Empty, _sqlQueryBuilder.BuildSelectQuery("1", "Column1"));

            using (SqlConnection connection = new SqlConnection(StoredProcedureTesterTestsConsts.ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlQueryCreateFirstStoredProcedure, connection);
                SqlCommand command2 = new SqlCommand(sqlQueryCreateSecondStoredProcedure, connection);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                await command2.ExecuteNonQueryAsync();
            }
        }

        //Create Two Stored Procedures One returns more rows
        //Create Two Stored Procedures One returns more columns
        //Create Two Stored Procedures returns same columns but one returns different name
        //Create Two Stored Procedures returns same columns but different data


    }

    public interface IStoredProcedureHelper
    {
        Task DropStoredProceduresAsync();
        Task CreateDuplicateStoredProceduresAsync();
    }
}
