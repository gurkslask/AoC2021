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
            List<string> oxy = s.Split('\n').ToList();
            List<string> co = s.Split('\n').ToList();

            int removepos = 0;
            string removenum;
            int cc = oxy.Count();
            for (int letter = 0; letter < cc  ; letter++)
            {
                if (oxy.Count() == 1) {break;}
                int count_1 = 0;
                int count_0 = 0;
               foreach (string row in oxy)
               {
                   //if (letter == 1) {System.Console.WriteLine(row[letter].ToString().ToString());}
                   if (row[letter].ToString().ToString() == "1".ToString()) { count_1 += 1;}
                   else { count_0 += 1;}
               } 
               if ( count_1 > count_0 ){
                   removenum = "0";
                    oxy = removeFromList(oxy, removenum, removepos);
               }
               else if ( count_1 < count_0 ){
                   removenum = "1";
                    oxy = removeFromList(oxy, removenum, removepos);
               }
               else
               {
                   removenum = "0";
                    oxy = removeFromList(oxy, removenum, removepos);
               }
               removepos += 1;
               /*System.Console.WriteLine("Finished loop");
               foreach (string row in oxy)
               {
                   System.Console.WriteLine(row);
               }*/
            }


            int oxyint = Convert.ToInt32(oxy[0], 2);
            System.Console.WriteLine($"Oxynumret är {oxyint}");
            System.Console.WriteLine($"Binärt är {oxy[0]}");


            removepos = 0;
            cc = co[1].Count();
            for (int letter = 0; letter < cc; letter++)
            {
                if (co.Count() == 1) {break;}
                int count_1 = 0;
                int count_0 = 0;
               foreach (string row in co)
               {
                   //if (letter == 1) {System.Console.WriteLine(row[letter].ToString().ToString());}
                   if (row[letter].ToString().ToString() == "1".ToString()) { count_1 += 1;}
                   else { count_0 += 1;}
               } 
               if ( count_1 < count_0 ){
                   removenum = "0";
                    co = removeFromList(co, removenum, removepos);
               }
               else if ( count_1 > count_0 ){
                   removenum = "1";
                    co = removeFromList(co, removenum, removepos);
               }
               else
               {
                   removenum = "1";
                    co = removeFromList(co, removenum, removepos);
               }
               removepos += 1;
            }

            int coint = Convert.ToInt32(co[0], 2);
            System.Console.WriteLine($"conumret är {coint}");


            return oxyint * coint;
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
