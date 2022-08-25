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
                //Console.WriteLine(c);
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

        public static string removeChar(string s, char Char)
        {
            try{
            int i = s.IndexOf(Char);
            s = s.Remove(i, 1);
            } catch (ArgumentOutOfRangeException) {
            }

            return s;
        }
        public static int SolveAdv(string ss){
            var inputList = parseInput(ss);
            int res = 0;
            /*
             aaa
            b   c
            b   c
            b   c
             ddd
            e   f
            e   f
            e   f
             ggg
            */
            mainlib.coords coordsModel = new mainlib.coords();
            foreach (cords c in inputList){
                // Först ska vi hitta posisitioner
                // Console.WriteLine($"Nu ska vi hitta positioner på {c.signalPatterns}");

                coordsModel.find_num_1(c);
                coordsModel.find_num_7(c);
                coordsModel.find_num_4(c);
                coordsModel.find_num_9(c);
                coordsModel.find_num_6(c);
                coordsModel.find_num_3(c);
                coordsModel.find_num_8(c);
                coordsModel.find_num_5(c);
                coordsModel.find_num_2(c);
                coordsModel.find_num_0(c);
                Console.WriteLine("Nu har vi fått ut alla positionerna, så här ser de ut:");
                coordsModel.print();
                Console.WriteLine($"Det här är siffrornas pattern {coordsModel.printNums()}");

                Console.WriteLine($"¨~~~~~Nu kör vi \n{c}\n~~~~");
                string sres = "";
                foreach (string outputVal in c.outputValue){
                    // Med hjälp av positionerna ska vi kolla vad som är output
                    /*Dictionary<string, int> actPatterns = new Dictionary<string,int>{
                        {"acedgfb" , 8},
                        {"cdfbe" , 5},
                        {"gcdfa" , 2, acdfg},
                        {"fbcad" , 3},
                        {"dab" , 7},
                        {"cefabd" , 9},
                        {"cdfgeb" , 6},
                        {"eafb" , 4},
                        {"cagedb" , 0},
                        {"ab" , 1}
                        tr och br
                    };*/

                    Console.WriteLine("*******BEGIN*****");
                    // Console.WriteLine($"Nu kör vi {outputVal}");

                    List<string> ord_patterns = new ();
                    foreach(string pattern in c.signalPatterns){
                        ord_patterns.Add(String.Concat(pattern.OrderBy(c => c)));
                    }

                    string ord_output = string.Concat(outputVal.OrderBy(c => c));
                    // Console.WriteLine($"Här är ordered output {ord_output}");
                    IEnumerable<string> result = from pattern in ord_patterns
                        where pattern == ord_output
                        select pattern;
                    List<string> lresult = result.ToList();
                    foreach (string ress in lresult) {
                        Console.WriteLine(ress);
                        Console.WriteLine($"Siffran blev {coordsModel.number_dict[ress]} ");
                        sres += coordsModel.number_dict[ress].ToString();
                    }

                    Console.WriteLine($"*******END***** Parsed: {int.Parse(sres)}");

                }
                res += int.Parse(sres);
                Console.WriteLine($"*******************************************sres: {sres}");
                Console.WriteLine($"*******************************************sres: {res}");
            }
            return res;
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
