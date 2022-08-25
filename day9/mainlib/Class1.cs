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
            List<double> lowpoints = new();
            string[] instring = s.Split("\n");
            /*foreach (var item in instring)
            {
                Console.WriteLine(item);
                
            }*/
            double res = 0; 
            int rowpos = 0;
            foreach (string row in instring){
                int charpos = 0;
                foreach (char character in row){

                    // Console.WriteLine($"{rowpos}:{charpos}");
                    char topvalue = '9';
                    if ( rowpos == 0 ){
                        // Console.WriteLine("vi är på toppen");
                    } else {
                    topvalue = instring[rowpos - 1][charpos];
                    }

                    char botvalue = '9';
                    if ( rowpos == instring.Length - 2 ){
                        //Console.WriteLine("vi är på botten");
                    } else {
                    botvalue = instring[rowpos + 1][charpos];
                    }

                    char leftvalue = '9';
                    if ( charpos == 0 ){
                        //Console.WriteLine("vi är på vänste");
                    } else {
                    leftvalue = instring[rowpos][charpos - 1];
                    }

                    char rightvalue = '9';
                    if ( charpos == row.Length - 1 ){
                        //Console.WriteLine("vi är på höger");
                    } else {
                    rightvalue = instring[rowpos][charpos + 1];
                    }
                    charpos += 1;
                    char temp = character;
                    if (
                            char.GetNumericValue(character) < char.GetNumericValue(topvalue) && 
                            char.GetNumericValue(character) < char.GetNumericValue(botvalue) && 
                            char.GetNumericValue(character) < char.GetNumericValue(leftvalue) && 
                            char.GetNumericValue(character) < char.GetNumericValue(rightvalue)  
                        ){
                        lowpoints.Add(char.GetNumericValue(character));
                    }
                }
                rowpos += 1;
            }
            foreach (double item in lowpoints)
            {
                // Console.WriteLine(item);
                res += item + 1; 
            }
            return Convert.ToInt32(res);
        }
        public static int SolveAdv(string s){
            List<double> lowpoints = new();
            string[] grid = s.Split("\n");
            foreach (string ss in grid){Console.WriteLine(ss);}
            int rowpos = 0;
            foreach (string row in grid){
                int charpos = 0;
                foreach (char character in row){
                    Console.WriteLine($"Here: {rowpos}:{charpos}");
                    char topvalue = '9';
                    if ( rowpos == 0 ){
                        // Console.WriteLine("vi är på toppen");
                    } else {
                    topvalue = grid[rowpos - 1][charpos];
                    }

                    char botvalue = '9';
                    if ( rowpos == grid.Length - 2 ){
                        Console.WriteLine("vi är på botten");
                    } else {
                    botvalue = grid[rowpos + 1][charpos];
                    }

                    char leftvalue = '9';
                    if ( charpos == 0 ){
                        Console.WriteLine("vi är på vänste");
                    } else {
                    leftvalue = grid[rowpos][charpos - 1];
                    }

                    char rightvalue = '9';
                    if ( charpos == row.Length - 1 ){
                        Console.WriteLine("vi är på höger");
                    } else {
                    rightvalue = grid[rowpos][charpos + 1];
                    }
                    char temp = character;
                    if (
                            char.GetNumericValue(character) < char.GetNumericValue(topvalue) && 
                            char.GetNumericValue(character) < char.GetNumericValue(botvalue) && 
                            char.GetNumericValue(character) < char.GetNumericValue(leftvalue) && 
                            char.GetNumericValue(character) < char.GetNumericValue(rightvalue)  
                        ){
                        List<string> WhereHaveWeBeen = new();
                        lowpoints.Add(recurFunc(grid, rowpos, charpos, grid[rowpos][charpos], "none", ref WhereHaveWeBeen));
                    }
                    charpos += 1;
                }
                rowpos += 1;
                }
            double result = 1;
            lowpoints.Sort();
            lowpoints.Reverse();
            List<double> TopThree = new();
            TopThree = lowpoints.GetRange(0, 3);

            foreach (var item in lowpoints)
            {
                Console.WriteLine(item);
            }
            foreach (var item in TopThree)
            {
                Console.WriteLine(item);
                result *= item;
            }
            return Convert.ToInt32(result);
        }

        public static int ctoi(char character){return Convert.ToInt32(char.GetNumericValue(character));}

        public static int recurFunc(string[] grid, int rowpos, int charpos, char callvalue, string directionToOrigin, ref List<string> WhereHaveWeBeen){
            Console.WriteLine($"Recur: {rowpos}, {charpos}, callvalue: {callvalue}");
            int count = 1;
            // vandra åt höger
            if (WhereHaveWeBeen.Contains($"{rowpos}, {charpos}")){
                Console.WriteLine("Här har vi redan varit ");
                foreach (var item in WhereHaveWeBeen)
                {
                    Console.WriteLine($"BeenListan: {item}");
                    
                }
                return 0;
            }
            WhereHaveWeBeen.Add($"{rowpos}, {charpos}");

            if ( charpos == grid[0].Length - 1){
                    Console.WriteLine("Recur: vi är på höger");
            } else if (directionToOrigin == "right"){
                    Console.WriteLine("Fel  håll");
                    // Det är där vi kom ifrån
            } else if (ctoi(grid[rowpos][charpos]) == 9){
                    // Om det är 9 är det stopp
                    Console.WriteLine("Här var det 9");
                    count = 0;
            //} else if (callvalue > ctoi(grid[rowpos][charpos + 1])) {

            } else {
                    Console.WriteLine("Nu kör vi recur igen");
                    count += recurFunc(grid, rowpos, charpos + 1, callvalue, "left", ref WhereHaveWeBeen);
            }

                // vandra åt vänster
            if ( charpos == 0){
                    Console.WriteLine("Recur: vi är på vänster");
            } else if (directionToOrigin == "left"){
                    // Det är där vi kom ifrån
            } else if (ctoi(grid[rowpos][charpos]) == 9){
                    // Om det är 9 är det stopp
                    count = 0;
            // } else if (callvalue > ctoi(grid[rowpos][charpos - 1])) {
            } else {
                    count += recurFunc(grid, rowpos, charpos - 1, callvalue, "right", ref WhereHaveWeBeen);
            }
                
                // vandra uppåt
            if ( rowpos == 0){
                    Console.WriteLine("Recur: vi är överst");
            } else if (directionToOrigin == "up"){
                    // Det är där vi kom ifrån
            } else if (ctoi(grid[rowpos][charpos]) == 9){
                    // Om det är 9 är det stopp
                    count = 0;
            //} else if (callvalue > ctoi(grid[rowpos - 1][charpos])) {
            } else {
                    count += recurFunc(grid, rowpos - 1, charpos, callvalue, "down",ref WhereHaveWeBeen);
            }
                
                // vandra neråt
            if ( rowpos == grid.Length - 2){
                    Console.WriteLine("Recur: vi är nederst");
            } else if (directionToOrigin == "down"){
                    // Det är där vi kom ifrån
            } else if (ctoi(grid[rowpos][charpos]) == 9){
                    // Om det är 9 är det stopp
                    count = 0;
            //} else if (callvalue > ctoi(grid[rowpos + 1][charpos])) {
            } else {
                    count += recurFunc(grid, rowpos + 1, charpos, callvalue, "up", ref WhereHaveWeBeen);
            }
            Console.WriteLine($"Returnar {count}");
            return count;
        }
    }
}
