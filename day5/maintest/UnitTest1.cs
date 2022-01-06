using System;
using Xunit;

namespace maintest
{
    public class UnitTest1
    {
        [Fact]
        public void TestSolve()
        {
            string s = mainlib.Class1.ReadFile("5");
            int want = 5;
            int got = mainlib.Class1.SolveBasic(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
        [Fact]
        public void TestSolveAdv()
        {
            string s = mainlib.Class1.ReadFile("5");
            int want = 12;
            int got = mainlib.Class1.SolveAdv(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);
        }
    }
}
