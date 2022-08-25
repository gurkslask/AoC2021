using System;
using Xunit;

namespace maintest
{
    public class UnitTest1
    {
        [Fact]
        public void TestSolve()
        {
            string s = mainlib.Class1.ReadFile("10");
            int want = 26397;
            int got = mainlib.Class1.SolveBasic(s);
            System.Console.WriteLine($"-- Basic --Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
        [Fact]
        public void TestSolveAdv()
        {
            string s = mainlib.Class1.ReadFile("10");
            int want = 288957;
            int got = mainlib.Class1.SolveAdv(s);
            System.Console.WriteLine($" -- Advanced -- Got: {got} \n Want: {want}");
            Assert.True(got == want);
        }
    }
}
