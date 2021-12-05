using System;
using Xunit;
using mainlib;

namespace maintest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string s = mainlib.Class1.Hello();
            Assert.True(s == "Hello");

        }
        [Fact]
        public void TestSolve()
        {
            string s = mainlib.Class1.ReadFile("4");
            int want = 4512;
            int got = mainlib.Class1.SolveBasic(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
        /*[Fact]
        public void TestSolveAdv()
        {
            string s = mainlib.Class1.ReadFile("4");
            int want = 230;
            int got = mainlib.Class1.SolveAdv(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }*/
    }
}
