using System;
using Xunit;

namespace maintest
{
    public class UnitTest1
    {
        [Fact]
        public void TestSolve()
        {
            string s = mainlib.Class1.ReadFile("11");
            int want = 1656;
            int got = mainlib.Class1.SolveBasic(s);
            System.Console.WriteLine($"-- Basic --Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
        [Fact]
        public void TestSolveAdv()
        {
            string s = mainlib.Class1.ReadFile("11");
            int want = 195;
            int got = mainlib.Class1.SolveAdv(s);
            System.Console.WriteLine($" -- Advanced -- Got: {got} \n Want: {want}");
            Assert.True(got == want);
        }
    }
}
