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
        public void TestReadFile()
        {
            string s = mainlib.Class1.ReadFile("1");
            Assert.True(s == "HelloTest");

        }
        [Fact]
        public void TestSolve()
        {
            string s = @"199
                        200
                        208
                        210
                        200
                        207
                        240
                        269
                        260
                        263";
            int want = 7;
            int got = mainlib.Class1.SolveBasic(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
        [Fact]
        public void TestSolveAdv()
        {
            string s = @"199
                        200
                        208
                        210
                        200
                        207
                        240
                        269
                        260
                        263";
            int want = 5;
            int got = mainlib.Class1.SolveAdv(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
    }
}
