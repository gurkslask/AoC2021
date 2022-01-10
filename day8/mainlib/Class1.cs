using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace mainlib
{
    public class Class1
    {
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
            var inputList = parseInput(ss);
            int res = 0;
            foreach (cords c in inputList){
                Console.WriteLine(c);
                foreach (string outputVal in c.outputValue){
                    if (outputVal.Length == 2){
                        //1
                        res += 1; 
                        Console.WriteLine("1");
                    } else if (outputVal.Length == 4){
                        // 4
                        res += 1;
                        Console.WriteLine("4");
                    } else if (outputVal.Length == 3){
                        // 7
                        res += 1;
                        Console.WriteLine("7");
                    } else if (outputVal.Length == 7){
                        // 8
                        res += 1;
                        Console.WriteLine("8");
                    }
                }
            }
            return res;
        }

        public static int SolveAdv(string ss){
            return 42;
        }
        public static string printGrid(List<List<int>> inList)
        {

            string res = "";
            foreach(List<int> i in inList)
            {
                res += String.Join(",", i);
                res += "\n";
            }
            return res;
        }
        public struct cords{
            public List<string> signalPatterns;
            public List<string> outputValue;
            public override string ToString(){
                return $"Patterns: {String.Join(" ", signalPatterns)} \nOutput: {String.Join(" ", outputValue)}\n Output 1: {outputValue[3]}";
            }
            public cords()
            {
                this.signalPatterns = new List<string>();
                this.outputValue = new List<string>();
            }
        }
        public static List<cords> parseInput(string s)
        {
            string pattern = @"(\w*)\s(\w*)\s(\w*)\s(\w*)\s(\w*)\s(\w*)\s(\w*)\s(\w*)\s(\w*)\s(\w*)\s\|\s(\w*)\s(\w*)\s(\w*)\s(\w*)";
            List<cords> resList = new List<cords>();
            foreach (string row in s.Split("\n"))
            {
                //Console.WriteLine($"String innan parse {row}.");
                if (row.Length > 2){
                    Match m = Regex.Match(row, pattern);
                    cords c = new cords();
                    c.signalPatterns.Add(m.Groups[1].Value);
                    c.signalPatterns.Add(m.Groups[2].Value);
                    c.signalPatterns.Add(m.Groups[3].Value);
                    c.signalPatterns.Add(m.Groups[4].Value);
                    c.signalPatterns.Add(m.Groups[5].Value);
                    c.signalPatterns.Add(m.Groups[6].Value);
                    c.signalPatterns.Add(m.Groups[7].Value);
                    c.signalPatterns.Add(m.Groups[8].Value);
                    c.signalPatterns.Add(m.Groups[9].Value);
                    c.signalPatterns.Add(m.Groups[10].Value);
                    c.outputValue.Add(m.Groups[11].Value);
                    c.outputValue.Add(m.Groups[12].Value);
                    c.outputValue.Add(m.Groups[13].Value);
                    c.outputValue.Add(m.Groups[14].Value);
                    resList.Add(c);
                }
            }
            //foreach(cords c in resList){Console.WriteLine($"Inne u parse: {c}");}
            return resList;
        }

        public static List<string> removeFromList(List<string> inlist, string siffra, int rempovepos){
            List<string> minlista = inlist;
            List<string> ToBeRemoved = new List<string>();
            int i = rempovepos;
                ToBeRemoved.Clear();
                // System.Console.WriteLine($"Här är listan innan det tas bort från {i} position, siffra {siffra}");
                /*foreach (string row in minlista)
                {
                    System.Console.WriteLine(row);
                }*/
                foreach (string row in minlista)
                {
                    if (row[i].ToString() == siffra ) {
                        // System.Console.WriteLine($"Nu tar jag bort {row}, för den har {siffra} på post {i}");
                        ToBeRemoved.Add(row);
                    }
                }
                foreach (string pos in ToBeRemoved)
                {
                    minlista.Remove(pos);
                }

            return minlista;
        }
    }
}
