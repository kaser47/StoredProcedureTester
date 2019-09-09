using System;

namespace StoredProcedureTester.Tests.Enums
{
    [Flags]
    enum ResultEnum
    {
        AllFail = 0,
        FirstTest = 1,
        SecondTest = 2,
        ThirdTest = 4,
        FourthTest = 8,
        OverallTest = 16,
        AllPass = FirstTest | SecondTest | ThirdTest | FourthTest | OverallTest,
        
    }
}
