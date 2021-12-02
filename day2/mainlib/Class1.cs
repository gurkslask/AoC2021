using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            string re = @"(\w*) (\d*)";
            int depth = 0;
            int horizontal_Pos = 0;
            foreach (string row in s.Split('\n')){
                Match match = Regex.Match(row, re);
                //System.Console.WriteLine($"row {row}");
                //System.Console.WriteLine($"len {row.Length}");
                //System.Console.WriteLine($"G1: {match.Groups[1]}");
                //System.Console.WriteLine($"G2: {match.Groups[2]}");
                if (row.Length > 3){
                    string dir = match.Groups[1].ToString();
                    int len = int.Parse(match.Groups[2].ToString());
                    if (dir == "forward") {horizontal_Pos = horizontal_Pos + len;};
                    if (dir == "down") {depth = depth + len;};
                    if (dir == "up") {depth = depth - len;};
                }
            }
            return depth * horizontal_Pos;
        }
        public static int SolveAdv(string s){
            string re = @"(\w*) (\d*)";
            int depth = 0;
            int horizontal_Pos = 0;
            int aim = 0;
            foreach (string row in s.Split('\n')){
                Match match = Regex.Match(row, re);
                //System.Console.WriteLine($"row {row}");
                //System.Console.WriteLine($"len {row.Length}");
                //System.Console.WriteLine($"G1: {match.Groups[1]}");
                //System.Console.WriteLine($"G2: {match.Groups[2]}");
                if (row.Length > 3){
                    string dir = match.Groups[1].ToString();
                    int len = int.Parse(match.Groups[2].ToString());
                    if (dir == "forward") {horizontal_Pos = horizontal_Pos + len; depth = depth + (aim * len);};
                    if (dir == "down") {aim = aim + len;};
                    if (dir == "up") {aim = aim - len;};
                }
            }
            return depth * horizontal_Pos;
            
        }
    }
}
