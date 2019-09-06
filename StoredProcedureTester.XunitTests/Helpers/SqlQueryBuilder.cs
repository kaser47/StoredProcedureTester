﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoredProcedureTester.Tests.Consts;

namespace StoredProcedureTester.Tests.Helpers
{
    public class SqlQueryBuilder : ISqlQueryBuilder
    {
        public string BuildDropStoredProcedureQuery(string storedProcedureName)
        {
            StringBuilder sqlQueryBuilder = StoredProcedureTesterTestsConsts.DropStoredProcedure();
            sqlQueryBuilder.Replace("{TestName}", storedProcedureName);

            return sqlQueryBuilder.ToString();
        }

        public string BuildCreateStoredProcedureQuery(string storedProcedureName, string parameters, string query)
        {
            StringBuilder sqlQueryBuilder = StoredProcedureTesterTestsConsts.CreateStoredProcedure();
            sqlQueryBuilder.Replace("{TestName}", storedProcedureName);
            sqlQueryBuilder.Replace("{Parameters}", parameters);
            sqlQueryBuilder.Replace("{Query}", query);

            return sqlQueryBuilder.ToString();
        }

        public string BuildSelectQuery(string value, string column)
        {
            StringBuilder sqlSelectQueryBuilder = StoredProcedureTesterTestsConsts.SelectQuery();
            sqlSelectQueryBuilder.Replace("{Value}", value);
            sqlSelectQueryBuilder.Replace("{Column}", column);

            return sqlSelectQueryBuilder.ToString();
        }

    }

    public interface ISqlQueryBuilder
    {
        string BuildDropStoredProcedureQuery(string storedProcedureName);
        string BuildCreateStoredProcedureQuery(string storedProcedureName, string parameters, string query);
        string BuildSelectQuery(string value, string column);
    }
}
