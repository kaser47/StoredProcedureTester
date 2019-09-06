using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using StoredProcedureTester.Consts;
using StoredProcedureTester.Interfaces;
using StoredProcedureTester.Models;

namespace StoredProcedureTester.Runners
{
    public class SqlRunner : ISqlRunner
    {
        private readonly ILogHelper _logHelper;

        public SqlRunner(ILogHelper logHelper)
        {
            _logHelper = logHelper;
        }

        public async Task<TestSummary> RunSqlAsync(StoredProcedureTest test)
        {
            try
            {
                string connectionString = $"SERVER=(local);DATABASE={test.DatabaseName};Integrated Security=true";

                foreach (string startupScript in StoredProcedureTesterConsts.StartupScripts)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(startupScript, connection);
                        await connection.OpenAsync();
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(test.GeneratedSql, connection);
                    //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                    await connection.OpenAsync();
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        TestSummary testSummary = new TestSummary(test);
                        while (await reader.ReadAsync())
                        {

                            testSummary.FirstTestResult = new TestResult((bool)reader["First Test Result"],
                                reader["First Test Message"] == DBNull.Value
                                    ? string.Empty
                                    : (string)reader["First Test Message"]);
                            testSummary.SecondTestResult = new TestResult((bool)reader["Second Test Result"],
                                reader["Second Test Message"] == DBNull.Value
                                    ? string.Empty
                                    : (string)reader["Second Test Message"]);
                            testSummary.ThirdTestResult = new TestResult((bool)reader["Third Test Result"],
                                reader["Third Test Message"] == DBNull.Value
                                    ? string.Empty
                                    : (string)reader["Third Test Message"]);
                            testSummary.FourthTestResult = new TestResult((bool)reader["Fourth Test Result"],
                                reader["Fourth Test Message"] == DBNull.Value
                                    ? string.Empty
                                    : (string)reader["Fourth Test Message"]);
                            testSummary.OverallResult = (bool)reader["Overall Result"];
                            testSummary.UnoptimisedDateTimeStart = (DateTime)reader["Unoptimised Start"];
                            testSummary.UnoptimisedDateTimeEnd = (DateTime)reader["Unoptimised End"];
                            testSummary.OptimisedDateTimeStart = (DateTime)reader["Optimised Start"];
                            testSummary.OptimisedDateTimeEnd = (DateTime)reader["Optimised End"];

                            //Save to excel
                            SaveToFile(testSummary);

                            _logHelper.Log("Ran SQL");
                            if (testSummary.OverallResult)
                            {
                                _logHelper.Log("Test PASSED");
                            }
                            else
                            {
                                _logHelper.Log("Test FAILED");
                            }
                        }

                        return testSummary;
                    }
                    catch (Exception ex)
                    {
                        _logHelper.Log(ex.Message);
                        throw;
                    }
                    finally
                    {
                        // Always call Close when done reading.
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                _logHelper.Log(ex.Message);
                throw;
            }
        }

        private void SaveToFile(TestSummary testSummary)
        {
            if (!Directory.Exists(StoredProcedureTesterConsts.FilePath))
                Directory.CreateDirectory(@"C:/Temp/StoredProcedureTester");

            var path = Path.Combine(StoredProcedureTesterConsts.FilePath, StoredProcedureTesterConsts.Filename);

            if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine($"{testSummary.ToCsv()}");
                }
            }
            else
            {
                using (var fs = File.Create(path))
                {

                }

                using (var tw = new StreamWriter(path, true))
                {
                    tw.WriteLine($"Date, Database Name, Unoptimised Stored Procedure Name, Optimised Stored Procedure Name, Unoptimised Total Speed (ms), Optimised Total Speed (ms), Difference (ms), Difference (%), Result");
                    tw.WriteLine($"{testSummary.ToCsv()}");
                }
            }


        }
    }
}