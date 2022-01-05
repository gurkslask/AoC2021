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
            s = System.IO.File.ReadAllText($"/home/alex/Projects/AoC2021/day{day}/mainlib/testinput.txt");
            return s;
        }
        public static string ReadSolveFile(string day){
            string s;
            s = System.IO.File.ReadAllText($"/home/alex/Projects/AoC2021/day{day}/mainlib/input.txt");
            return s;
        }
        public static int SolveBasic(string ss){

            string random_numbers = ss.Split('\n')[0];
            System.Console.WriteLine($"Random numbers är: {random_numbers}");

            List<board> lGrid = new List<board>();

            string[] s = ss.Split('\n');
            float modulusen = (s.Count() - 1) / 6;
            int lower = 2;
            int upper = 7;
            for (int i = 0; i < modulusen; i += 1)
            {
                lGrid.Add(new board(string.Join('\n', s[lower..upper])));
                lower += 6;
                upper += 6;
            }
            int c = 1;
            Console.WriteLine(lGrid.Count());
            foreach (board b in lGrid)
            {
                Console.WriteLine("Init: \n " + b.ToString());
            }
            int res = 0;
            bool done = false;
            // Loop through numbers and check if done
            foreach (string snumber in random_numbers.Split(','))
            {
                int number = int.Parse(snumber);
                foreach (board g in lGrid)
                {
                    g.insertnum((number));
                    if (g.checkIfBoardIsWin()) {
                        Console.WriteLine("********** KLART ********");
                        foreach(board b in lGrid){
                            res = g.countNonMarked() * number;
                            done = true;
                            Console.WriteLine(res);
                        }
                    g.Print();
                    
                    }
                }
                if (done) { break;}
            }
        Console.WriteLine(lGrid.Count());
        foreach (board b in lGrid)
        {
            Console.WriteLine(b.ToString());
        }
        return res;
    }

    public static int SolveAdv(string s){
            return 42;
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
    public class board{
        public struct gridItem
        {
            public int num;
            public bool check = false;
            public gridItem(int num, bool check) {
                this.num = num;
                this.check = check;
            }
        }
        gridItem[,] grid = new gridItem[5,5];
        public override string ToString()
        {
            string res = "";
            int c = 0;
            foreach (gridItem row in grid)
            {
                res += $"S: {row.num}, c: {row.check};";
                c += 1;
                if (c == 5){
                    res += "\n";
                    c = 0;
                }
            }
            return res;

        }
        public board(string boardInput)
        {
            int irow = 0;
            int icol = 0;
            foreach (string row in boardInput.Split("\n"))
            {
                foreach (string col in Regex.Split(row, @"\s+"))
                {
                    if (col.Length > 0){
                        // System.Console.WriteLine($"co: {col}, len {col.Length}");
                        // System.Console.WriteLine($"icol {icol}, irow{irow}");
                        grid[irow, icol] = new gridItem(int.Parse(col), false);
                        icol += 1;
                    }
                }
                icol = 0;
                irow += 1;
            }
        }
        public bool checkIfBoardIsWin()
        {
            bool done = false;
            for (int i = 0; i < 4; i++)
            {
                if (grid[i, 0].check && grid[i, 1].check && grid[i, 2].check && grid[i, 3].check && grid[i, 4].check  && grid[i, 4].check  ) {
                    done = true;
                }
                if (grid[0, i].check && grid[1, i].check && grid[2, i].check && grid[3, i].check && grid[4, i].check  && grid[4, i].check  ) {
                    done = true;
                }
            }
            return done;
        }

        public int countNonMarked()
        {
            int count = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if(!grid[row, col].check){
                        count += grid[row, col].num;
                        Console.WriteLine($"{grid[row, col].num}");
                    }
                }
            }
            return count;
        }
        public void Print(){
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if(!grid[row, col].check){
                        //System.Console.WriteLine($"{grid[row, 0].num} : {grid[row, 0].check} , {grid[row, 1].num} : {grid[row, 1].check} , {grid[row, 2].num} : {grid[row, 2].check} ");
                    }
                }
            }
        }
        public void insertnum(int inNum){
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if(grid[row, col].num == inNum){
                        grid[row, col].check = true;
                    }
                }
            }
        }
        }
    }

    }
