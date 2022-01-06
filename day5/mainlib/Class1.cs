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
            List<List<int>> grid = new List<List<int>>();
            List<cords> resList = new List<cords>();
            resList = parseInput(ss);
            int max_x = resList.Max(t => Math.Max(t.x1, t.x2)) + 1;
            int max_y = resList.Max(t => Math.Max(t.y1, t.y2)) + 1;
            // Console.WriteLine($"X: {max_x}, Y: {max_y}");
            // Populate list
            for (int i = 0; i < max_x; i++){
                grid.Add(new List<int>(new int[max_y]));
            }
            foreach(cords c in resList) {
                //Console.WriteLine(c);
                if (c.x1 == c.x2){
                    for (int i = 0; i < Math.Abs(c.y1-c.y2) + 1; i++)
                    {
                        int low_y = Math.Min(c.y1, c.y2);
                         //Console.WriteLine($"Försöker skriva till position: x:{c.x1} y: {low_y + i}");
                        grid[c.x1][low_y + i] += 1;
                        // Console.WriteLine($"y-linje, nya värdet är {grid[c.x1][low_y + i] }");
                    }
                }
                if (c.y1 == c.y2){
                    for (int i = 0; i < Math.Abs(c.x1-c.x2) + 1; i++)
                    {
                        int low_x = Math.Min(c.x1, c.x2);
                        // Console.WriteLine($"Försöker skriva till position: x:{low_x + i} y: {c.y1}");
                        grid[low_x + i][c.y1] += 1;
                        // Console.WriteLine($"x-linje, nya värdet är {grid[low_x + i][c.y1] }");
                    }
                }
            }
            //Console.WriteLine(printGrid(grid));
            int res = 0;
            foreach (List<int> i in grid)
            {
                foreach(int k in i)
                {
                    if (k > 1)
                    {
                        res += 1;
                    }
                }
            }
            return res;
        }

        public static int SolveAdv(string ss){
            List<List<int>> grid = new List<List<int>>();
            List<cords> resList = new List<cords>();
            resList = parseInput(ss);
            int max_x = resList.Max(t => Math.Max(t.x1, t.x2)) + 1;
            int max_y = resList.Max(t => Math.Max(t.y1, t.y2)) + 1;
            // Console.WriteLine($"X: {max_x}, Y: {max_y}");
            // Populate list
            for (int i = 0; i < max_x; i++){
                grid.Add(new List<int>(new int[max_y]));
            }
            foreach(cords c in resList) {
                //Console.WriteLine(c);
                if (c.x1 == c.x2){
                    for (int i = 0; i < Math.Abs(c.y1-c.y2) + 1; i++)
                    {
                        int low_y = Math.Min(c.y1, c.y2);
                         //Console.WriteLine($"Försöker skriva till position: x:{c.x1} y: {low_y + i}");
                        grid[c.x1][low_y + i] += 1;
                        // Console.WriteLine($"y-linje, nya värdet är {grid[c.x1][low_y + i] }");
                    }
                }
                if (c.y1 == c.y2){
                    for (int i = 0; i < Math.Abs(c.x1-c.x2) + 1; i++)
                    {
                        int low_x = Math.Min(c.x1, c.x2);
                        // Console.WriteLine($"Försöker skriva till position: x:{low_x + i} y: {c.y1}");
                        grid[low_x + i][c.y1] += 1;
                        // Console.WriteLine($"x-linje, nya värdet är {grid[low_x + i][c.y1] }");
                    }
                }
                //Diagonal line
                if (Math.Abs(c.x1 - c.x2) == Math.Abs(c.y1 - c.y2))
                {
                    Console.WriteLine($"Cords: {c}");
                    for (int i = 0; i < Math.Abs(c.x1-c.x2) + 1; i++)
                    {
                        int wx = c.x1;
                        int wy = c.y1;
                        // 4,4 5,3 up right x +, y -
                        // 4,4 5,5 down right x+, y +
                        // 4,4 3,5 down left x -, y +
                        // 4,4 3,3 up left x -, y -
                        if (c.x1 < c.x2 && c.y1 > c.y2){wx += i; wy -= i;/*up right*/}
                        else if (c.x1 < c.x2 && c.y1 < c.y2){wx += i; wy += i;/* down right*/}
                        else if (c.x1 > c.x2 && c.y1 < c.y2){wx -= i; wy += i;/* down left*/}
                        else if (c.x1 > c.x2 && c.y1 > c.y2){wx -= i; wy -= i;/* up left*/}
                        // Console.WriteLine($"Försöker skriva till position: x:{wx} y: {wy}");
                        grid[wx][wy] += 1;
                    }
                }
            }
            Console.WriteLine(printGrid(grid));
            int res = 0;
            foreach (List<int> i in grid)
            {
                foreach(int k in i)
                {
                    if (k > 1)
                    {
                        res += 1;
                    }
                }
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
            public int x1;
            public int x2;
            public int y1;
            public int y2;
            public override string ToString(){
                return $"{x1},{y1} -> {x2},{y2}";
            }
        }
        public static List<cords> parseInput(string s)
        {
            string pattern = @"(\d*),(\d*) -> (\d*),(\d*)";
            List<cords> resList = new List<cords>();
            foreach (string row in s.Split("\n"))
            {
                //Console.WriteLine($"String innan parse {row}.");
                if (row.Length > 2){
                    Match m = Regex.Match(row, pattern);
                    cords c = new cords();
                    c.x1 = int.Parse(m.Groups[1].Value);
                    c.y1 = int.Parse(m.Groups[2].Value);
                    c.x2 = int.Parse(m.Groups[3].Value);
                    c.y2 = int.Parse(m.Groups[4].Value);
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
