using StoredProcedureTester.Enums;

namespace StoredProcedureTester.Models
{
    public interface IParameterManager
    {
        void AddParameter(string name, string value, ParameterType type, TestParameterDataType dataType);
        void RemoveParameter(TestParameter testParameter, ParameterType type);
    }
}