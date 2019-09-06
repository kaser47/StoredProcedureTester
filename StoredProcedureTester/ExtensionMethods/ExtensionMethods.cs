namespace StoredProcedureTester.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static string GetResultString(this bool boolean)
        {
            if (boolean)
            {
                return "PASS";
            }
            else
            {
                return "FAIL";
            }
        }
    }
}