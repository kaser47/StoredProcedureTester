using System;
using System.Text;

namespace StoredProcedureTester.Models
{
    public class TestSummary
    {
        public StoredProcedureTest Test { get; }
        public TestResult FirstTestResult { get; set; }
        public TestResult SecondTestResult { get; set; }
        public TestResult ThirdTestResult { get; set; }
        public TestResult FourthTestResult { get; set; }
        public bool OverallResult { get; set; }
        public DateTime UnoptimisedDateTimeStart { get; set; }
        public DateTime UnoptimisedDateTimeEnd { get; set; }
        public DateTime OptimisedDateTimeStart { get; set; }
        public DateTime OptimisedDateTimeEnd { get; set; }

        public TestSummary(StoredProcedureTest test)
        {
            Test = test;
        }

        public double UnoptimisedTotalTime {
            get
            {
                TimeSpan span = UnoptimisedDateTimeEnd - UnoptimisedDateTimeStart;
                return span.Milliseconds;
            }
        }
        public double OptimisedTotalTime
        {
            get
            {
                TimeSpan span = OptimisedDateTimeEnd - OptimisedDateTimeStart;
                return span.Milliseconds;
            }
        }
        public double DifferenceTotalTime
        {
            get
            {
                return UnoptimisedTotalTime - OptimisedTotalTime;
            }
        }
        public double DifferencePercentage
        {
            get { return (OptimisedTotalTime / UnoptimisedTotalTime) * 100; }
        }

        public string ToCsv()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(DateTime.Now.ToString("dd-MM-yy HH:mm:ss"));
            stringBuilder.Append($",{Test.DatabaseName}");
            stringBuilder.Append($",{Test.UnoptimisedStoredProcedureName}");
            stringBuilder.Append($",{Test.OptimisedStoredProcedureName}");
            stringBuilder.Append($",{UnoptimisedTotalTime}");
            stringBuilder.Append($",{OptimisedTotalTime}");
            stringBuilder.Append($",{DifferenceTotalTime}");
            stringBuilder.Append($",{DifferencePercentage}");
            stringBuilder.Append($",{OverallResult}");

            return stringBuilder.ToString();
        }
    }
}