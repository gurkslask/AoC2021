﻿using System;
using mainlib;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s;
            s = mainlib.Class1.Hello();
            System.Console.WriteLine(s);
            System.Console.WriteLine("Basic: " + mainlib.Class1.SolveBasic(mainlib.Class1.ReadSolveFile("2")));
            System.Console.WriteLine("Advanced: " + mainlib.Class1.SolveAdv(mainlib.Class1.ReadSolveFile("2")));
        }
    }
}
