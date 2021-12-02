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
            s = System.IO.File.ReadAllText($"/home/alex/Projects/AoC2021/day{day}/mainlib/test.txt");
            return s;
        }
        public static string ReadSolveFile(string day){
            string s;
            s = System.IO.File.ReadAllText($"/home/alex/Projects/AoC2021/day{day}/mainlib/input.txt");
            return s;
        }
        public static int SolveBasic(string s){
            bool debug = true;
            List<int> inputdata = new List<int>();
            string[] sinputdata = s.Split('\n');
            foreach (string row in sinputdata) {
                inputdata.Add(int.Parse(row));
                //System.Console.WriteLine(row);
            } 

            int incCount = 0;
            int prev = inputdata[0];
            foreach (int i in inputdata){
                //System.Console.WriteLine(i);
                if (i > prev){
                    //System.Console.WriteLine(i);
                    incCount = incCount + 1;
                }
                prev = i;
            }
            
            return incCount;
        }
        public static int SolveAdv(string s){
            bool debug = true;
            List<int> inputdata = new List<int>();
            List<int> windows = new List<int>();
            string[] sinputdata = s.Split('\n');
            foreach (string row in sinputdata) {
                inputdata.Add(int.Parse(row));
                //System.Console.WriteLine(row);
            } 

            for (int i = 0 ; i < inputdata.Count; i++) {
                if (i < inputdata.Count - 2) {
                    windows.Add(inputdata[i] + inputdata[i + 1] + inputdata[i + 2]);
                }
            }

            int incCount = 0;
            int prev = windows[0];
            foreach (int i in windows){
                System.Console.WriteLine(i);
                if (i > prev){
                    //System.Console.WriteLine(i);
                    incCount = incCount + 1;
                }
                prev = i;
            }
            
            return incCount;
        }
    }
}
