using System;

namespace StoredProcedureTester.Enums
{
    [Flags]
    public enum ParameterType
    {
        Unoptimised = 1,
        Optimised = 2,
    }
}