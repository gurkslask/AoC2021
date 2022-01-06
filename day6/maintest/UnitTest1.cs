using System;
using Xunit;

namespace maintest
{
    public class UnitTest1
    {
        [Fact]
        public void TestSolve()
        {
            string s = mainlib.Class1.ReadFile("6");
            int want = 5934;
            int got = mainlib.Class1.SolveBasic(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
        [Fact]
        public void TestSolveAdv()
        {
            string s = mainlib.Class1.ReadFile("6");
            long want = 26984457539;
            long got = mainlib.Class1.SolveAdv(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);
        }
    }
}
