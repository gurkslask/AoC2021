using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace mainlib
{
    public class Class1
    {
        const int daysForBredFish = 6;
        const int daysForNewFish = 8;
        const int days = 80;
        public struct Fish{
            public int day = 0;
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
            var inList = parseInput(ss);
            List<int> templista = new List<int>();
            //Console.WriteLine($"Fiskar: {String.Join(",", inList)}");
            for (int i = 0; i < 80; i++)
            {
                //Console.WriteLine($"Fiskar: {String.Join(",", inList)}, varv: {i}");
                foreach (var nn in inList) {templista.Add(nn); }
                //Console.WriteLine($"TempFiskar: {String.Join(",", templista)}, varv: {i}");
                for (int fish = 0;  fish < inList.Count(); fish++)
                {
                    if (templista[fish] == 0)
                    {
                        templista[fish] = daysForBredFish;
                        templista.Add(daysForNewFish);
                    } else {
                        templista[fish] -= 1;
                    }
                }
                //Console.WriteLine($"Varv {i} klar");
                inList = new List<int>();
                foreach (var nn in templista) {inList.Add(nn); }
                templista = new List<int>();
            }
            return inList.Count();
        }

        public static long SolveAdv(string ss){
            var inList = parseInput(ss);
            long[] numArr = new long[9];
            long[] tempArr = new long[9];
            long pullover = 0;
            foreach (int i in inList )
            {
                numArr[i] += 1;
            }
            for (int i = 0; i < 256; i++)
            {
                //Console.WriteLine($"Fiskar: {String.Join(",", numArr)}");
                for (int k = 0; k < 9; k++)
                {
                    if (k == 0){
                        tempArr[8] = numArr[k];
                        pullover = numArr[k];
                    } else {
                        tempArr[k - 1] = numArr[k];
                    }
                }
                tempArr[6] += pullover;
                pullover = 0;
                numArr = new long[9];
                for (int  k = 0;  k < 9; k++)
                {
                    numArr[k] = tempArr[k];
                }
            }
            long res = 0;
            foreach (long item in numArr)
            {
                res += item;
            }
            return res;
        }
        public static List<int> parseInput(string s)
        {
            //string pattern = @"(\d*),(\d*) -> (\d*),(\d*)";
            List<int> resList = new List<int>();
            foreach (string num in s.Split(","))
            {
                resList.Add(int.Parse(num));
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
