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
            string s = @"
forward 5
down 5
forward 8
up 3
down 8
forward 2";
            int want = 150;
            int got = mainlib.Class1.SolveBasic(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
        [Fact]
        public void TestSolveAdv()
        {
            string s = @"
forward 5
down 5
forward 8
up 3
down 8
forward 2";
            int want = 900;
            int got = mainlib.Class1.SolveAdv(s);
            System.Console.WriteLine($"Got: {got} \n Want: {want}");
            Assert.True(got == want);

        }
    }
}
