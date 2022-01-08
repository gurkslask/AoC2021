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
            // Get the highest position for the for loop
            int maxPos = inList.Max() + 1;
            // Make array with positions
            int[] positions = new int[maxPos];
            // Loop as many times as there are positions 
            for (int pos = 0; pos < maxPos; pos++)
            {
                foreach (int crab in inList)
                {
                    positions[pos] += Math.Abs(pos - (crab));
                }
                Console.WriteLine($"Position {pos}, fuel {positions[pos]}");
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
