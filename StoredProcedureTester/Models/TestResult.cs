namespace StoredProcedureTester.Models
{
    public class TestResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }

        public TestResult(bool result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}