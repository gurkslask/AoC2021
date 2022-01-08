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
            List<int> inList = parseInput(ss);
            int maxPos = inList.Max() - 1;
            // array 0 = pos 1, 
            int[] positions = new int[maxPos];
            for (int pos = 0; pos < maxPos; pos++)
            {
                int realpos = pos + 1;
                foreach (int crab in inList)
                {
                    positions[pos] += Math.Abs(realpos - (crab + 1));
                }
            }
            return Array.IndexOf(positions, positions.Min());
        }
        public static int SolveAdv(string ss){
            return 42;
        }
        public static List<int> parseInput(string s)
        {
            List<int> resList = new List<int>();
            foreach (string row in s.Split(","))
            {
                resList.Add(int.Parse(row));
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
