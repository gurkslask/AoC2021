using System;
using System.Collections.Generic;
using System.Linq;


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
            string[] inputLines = s.Split("\n");
            int res = 0;
            foreach (string row in inputLines)
            {
                Dictionary<char, int> scores = new() {
                    {')', 3},
                    {']', 57},
                    {'}', 1197},
                    {'>', 25137},
                };
                List<char> lastOpen = new();
                foreach (char c in row)
                {
                    if (openers.Contains(c))
                    {
                        lastOpen.Add(c);
                        //Console.WriteLine($"Här är {c}, listan ser nu ut: {string.Join("", lastOpen)}");
                    } else {
                        if (c != pairs[lastOpen.Last()]){
                            res += scores[c];
                            break;
                        } else {
                            lastOpen.RemoveAt(lastOpen.Count - 1);
                        }
                    }
                    
                }
                
            }
            return res;
        }
        public static double SolveAdv(string s){
            string[] inputLines = s.Split("\n");
            List<string> illegalLines = new();
            List<double> RowScores = new();
            double res = 0;
            foreach (string row in inputLines)
            {
                double row_res = 0;
                bool illegal = false;
                //Console.WriteLine(row);
                Dictionary<char, int> scores = new() {
                    {')', 1},
                    {']', 2},
                    {'}', 3},
                    {'>', 4},
                };
                List<char> lastOpen = new();
                foreach (char c in row)
                {
                    if (openers.Contains(c))
                    {
                        lastOpen.Add(c);
                        // Console.WriteLine($"Här är {c}, listan ser nu ut: {string.Join("", lastOpen)}");
                    } else {
                        if (c != pairs[lastOpen.Last()]){
                            // Console.WriteLine($"{c} gör den illegal");
                            res += scores[c];
                            illegal = true;
                            break;
                        } else {
                            lastOpen.RemoveAt(lastOpen.Count - 1);
                        }
                    }
                }
                if (!illegal) {
                    lastOpen.Reverse();
                    Console.WriteLine($"This is incomplete\n{row}\nThese are remaining {string.Join("", lastOpen)}");

                    illegalLines.Add(row);

                    foreach (char c in lastOpen) { row_res = row_res * 5; row_res = row_res + scores[pairs[c]];}
                    Console.WriteLine($"These chars {string.Join("", lastOpen)} got score {row_res}");
                    RowScores.Add(row_res);
                }
            }
            RowScores.Sort();
            Console.WriteLine($"{string.Join(" *---* ", RowScores)} -****-");
            res = RowScores[(RowScores.Count() / 2) + 1];
            return res;
        }
        public static int CountOpen(Dictionary<char, int> inDict){
            int res = 0;
            res = inDict['('] + inDict['['] + inDict['{'] + inDict['<'];
            return res;
        }
        public static int CountClosed(Dictionary<char, int> inDict){
            int res = 0;
            res = inDict[')'] + inDict[']'] + inDict['}'] + inDict['>'];
            return res;
        }
        public static List<char> openers = new() {'(', '{', '[', '<'};
        public static List<char> closers = new() {')', '}', ']', '>'};
        public static Dictionary<char, char> pairs = new() {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'},
            {'<', '>'},
        };
    }
}
