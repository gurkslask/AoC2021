using System;
using Xunit;

namespace maintest
{
    public class UnitTest1
    {
        [Fact]
        public void TestSolve()
        {
            string s = mainlib.Class1.ReadFile("9");
            int want = 15;
            int got = mainlib.Class1.SolveBasic(s);
            System.Console.WriteLine($"-- Basic --Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
        [Fact]
        public void TestSolveAdv()
        {
            string s = mainlib.Class1.ReadFile("9");
            int want = 1134;
            int got = mainlib.Class1.SolveAdv(s);
            System.Console.WriteLine($" -- Advanced -- Got: {got} \n Want: {want}");
            Assert.True(got == want);
        }
    }
}
