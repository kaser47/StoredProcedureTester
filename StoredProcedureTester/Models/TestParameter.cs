using StoredProcedureTester.Enums;

namespace StoredProcedureTester.Models
{
    public class TestParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public TestParameterDataType Type { get; set; }

        public override string ToString()
        {
            return $"@{Name}='{Value}' : {Type}";
        }

        public static TestParameter Default()
        {
            TestParameter testParameter = new TestParameter("Id", "1", 0);
            return testParameter;
        }

        public TestParameter(string name, string value, TestParameterDataType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        public string GetSqlString()
        {
            string result = string.Empty;

            switch (Type)
            {
                case TestParameterDataType.Guid:
                    result = $"@{Name} =\"' + CAST('{Value}' AS NVARCHAR(MAX)) + N'\"";
                    break;
                case TestParameterDataType.DateTime:
                    result = $"@{Name} =\"' + CAST('{Value}' AS NVARCHAR(MAX)) + N'\"";
                    //Todo: ASHR006 - Check what format DateTime needs to be in.
                    break;
                default:
                    result = $"@{Name} =' + CAST('{Value}' AS NVARCHAR(MAX)) + N'";
                    break;
            }

            return result;
        }
    }
}