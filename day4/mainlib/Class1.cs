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
            string random_numbers = ss.Split('\n')[0];
            System.Console.WriteLine($"Random numbers är: {random_numbers}");

            List<board> lGrid = new List<board>();
            string[] s = ss.Split('\n');
            // Make grids
            for (int i = 2; i < (s.Count() -2) % 6; i+= 6)
            {
                int k = i + 6;
                System.Console.WriteLine($"Här kommer lite data {string.Join(' ', s[i..k])}");
                lGrid.Add(new board(string.Join('\n', s[i..k])));
            }
            int res = 0;
            // Loop through numbers and check if done
            foreach (string number in random_numbers.Split(','))
            {
                foreach (board g in lGrid)
                {
                    g.insertnum(int.Parse(number));
                    if (g.checkIfBoardIsWin()) {
                        res = g.countNonMarked() * res;
                    }
                    
                }
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
        gridItem[,] grid = new gridItem[4,4];
        public board(string boardInput)
        {
            int irow = 0;
            int icol = 0;
            foreach (string row in boardInput.Split("\n"))
            {
                foreach (string col in row.Split(" "))
                {
                    if (col != "  "){
                        System.Console.WriteLine($"co: {col}, len {col.Length}");
                        grid[irow, icol] = new gridItem(int.Parse(col), false);
                        icol += 1;
                    }
                }
                irow += 1;
            }
        }
        public bool checkIfBoardIsWin()
        {
            bool done = false;
            for (int i = 0; i < 4; i++)
            {
                if (grid[i, 0].check && grid[i, 1].check && grid[i, 2].check && grid[i, 3].check && grid[i, 4].check  ) {
                    done = true;
                }
                if (grid[0, i].check && grid[1, i].check && grid[2, i].check && grid[3, i].check && grid[4, i].check  ) {
                    done = true;
                }
            }
            return done;
        }

        public int countNonMarked()
        {
            int count = 0;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if(!grid[row, col].check){
                        count += grid[row, col].num;
                    }
                }
            }
            return count;
        }
        public void insertnum(int inNum){
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
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
