using System;
using System.Collections.Generic;


namespace mainlib
{
    public class Class1

    {
        public static string Hello(){
            return "Hello";
            
        }
        public static string ReadFile(string day){
            string s;
            s = System.IO.File.ReadAllText($"/home/alex/Projects/AoC2021/day{day}/mainlib/testinput.txt");
            return s;
        }
        public static string ReadSolveFile(string day){
            string s;
            s = System.IO.File.ReadAllText($"/home/alex/Projects/AoC2021/day{day}/mainlib/input.txt");
            return s;
        }
        public static int SolveBasic(string ss){
            string[] s = ss.Split('\n');
            string gamma = "";
            string eps = "";
            for (int letter = 0; letter < s[1].Length ; letter++)
            {
                int count_1 = 0;
                int count_0 = 0;
               foreach (string row in s)
               {
                   //if (letter == 1) {System.Console.WriteLine(row[letter].ToString());}
                   if (row[letter].ToString() == "1".ToString()) { count_1 += 1;}
                   else { count_0 += 1;}
               } 
               //System.Console.WriteLine($"Count 0 : {count_0}, Count 1 {count_1}");
               if (count_0 > count_1) {gamma += "0"; eps += "1";}
               else { gamma += "1"; eps += "0"; }
            }
            //System.Console.WriteLine($"Gamma: {gamma}");
            //System.Console.WriteLine($"Eps: {eps}");
            int gammaint = Convert.ToInt32(gamma, 2);
            int epsint = Convert.ToInt32(eps, 2);
            return gammaint * epsint;
        }
        public static int SolveAdv(string s){
            return 42;
        }
    }
}
