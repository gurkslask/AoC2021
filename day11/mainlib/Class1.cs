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
            int[,] grid = new int[10,10]{
                {0,1,2,3,4,5,6,7,8,9},
                {1,1,2,3,4,5,6,7,8,9},
                {2,1,2,3,4,5,6,7,8,9},
                {3,1,2,3,4,5,6,7,8,9},
                {4,1,2,3,4,5,6,7,8,9},
                {5,1,2,3,4,5,6,7,8,9},
                {6,1,2,3,4,5,6,7,8,9},
                {7,1,2,3,4,5,6,7,8,9},
                {8,1,2,3,4,5,6,7,8,9},
                {9,1,2,3,4,5,6,7,8,9},
            };
            //Console.WriteLine($"rank {grid.Rank}, len {grid.Length}");
            int flashes = 0;
            int rownum = 0;
            foreach (var row in s.Split("\n"))
            {
                int charnum = 0;
                //Console.WriteLine(row);
                foreach (char c in row)
                {
                    grid[rownum, charnum] = c - '0';
                    charnum += 1;
                }
                rownum += 1;
            }
            //Console.WriteLine("He");
            Console.WriteLine(printGrid(grid));
            for (int i = 0; i < 100; i++)
            {
                // step 1
                incAll(ref grid);
                // step 2
                bool done = false;
                while (!done) {
                    done = true;
                    for (int row = 0; row < grid.GetLength(0) ; row++)
                    {
                        for (int charr = 0; charr < grid.GetLength(1) ; charr++)
                        {
                            if (grid[row, charr] > 9 && grid[row,charr] < 1000){
                                flash(ref grid, row, charr);
                                flashes += 1;
                                done = false;
                            }
                        }
                    }
                }
                // step 3
                for (int row = 0; row < grid.GetLength(0) ; row++)
                {
                    for (int charr = 0; charr < grid.GetLength(1) ; charr++)
                    {
                        if (grid[row,charr] > 1000){
                            grid[row,charr] = 0;
                        }
                    }
                }
            }
            return flashes;
        }
        public static int SolveAdv(string s){
            int[,] grid = new int[10,10]{
                {0,1,2,3,4,5,6,7,8,9},
                {1,1,2,3,4,5,6,7,8,9},
                {2,1,2,3,4,5,6,7,8,9},
                {3,1,2,3,4,5,6,7,8,9},
                {4,1,2,3,4,5,6,7,8,9},
                {5,1,2,3,4,5,6,7,8,9},
                {6,1,2,3,4,5,6,7,8,9},
                {7,1,2,3,4,5,6,7,8,9},
                {8,1,2,3,4,5,6,7,8,9},
                {9,1,2,3,4,5,6,7,8,9},
            };
            int flashes = 0;
            int rownum = 0;
            foreach (var row in s.Split("\n"))
            {
                int charnum = 0;
                //Console.WriteLine(row);
                foreach (char c in row)
                {
                    grid[rownum, charnum] = c - '0';
                    charnum += 1;
                }
                rownum += 1;
            }
            //Console.WriteLine("He");
            Console.WriteLine(printGrid(grid));
            for (int i = 0; i < 999999; i++)
            {
                int loopnum = 0;
                // step 1
                incAll(ref grid);
                // step 2
                bool done = false;
                while (!done) {
                    done = true;
                    for (int row = 0; row < grid.GetLength(0) ; row++)
                    {
                        for (int charr = 0; charr < grid.GetLength(1) ; charr++)
                        {
                            if (grid[row, charr] > 9 && grid[row,charr] < 1000){
                                flash(ref grid, row, charr);
                                flashes += 1;
                                done = false;
                            }
                        }
                    }
                }
                // step 3
                for (int row = 0; row < grid.GetLength(0) ; row++)
                {
                    for (int charr = 0; charr < grid.GetLength(1) ; charr++)
                    {
                        if (grid[row,charr] > 1000){
                            grid[row,charr] = 0;
                        }
                    }
                }
                // Check number of flashes
                Console.WriteLine($"number of flashes: {flashes}, looprun: {i}");
                if (flashes >= 100){return i + 1; }
                flashes = 0;
                loopnum += 1;
            }
            return 0;
        }
        public static void flash(ref int[,] grid, int rowpos, int charpos){
            // inc top
            try{
                grid[rowpos + 1, charpos] += 1;
            } catch (IndexOutOfRangeException){
            }
            // top right
            try{
                grid[rowpos + 1, charpos + 1] += 1;
            } catch (IndexOutOfRangeException){
            }
            // top left
            try{
                grid[rowpos + 1, charpos - 1] += 1;
            } catch (IndexOutOfRangeException){
            }
            // inc right
            try{
                grid[rowpos, charpos + 1] += 1;
            } catch (IndexOutOfRangeException){
            }
            // inc left
            try{
                grid[rowpos, charpos - 1] += 1;
            } catch (IndexOutOfRangeException){
            }
            // inc left bot
            try{
                grid[rowpos - 1, charpos - 1] += 1;
            } catch (IndexOutOfRangeException){
            }
            // inc right bot
            try{
                grid[rowpos - 1, charpos + 1] += 1;
            } catch (IndexOutOfRangeException){
            }
            // inc bot
            try{
                grid[rowpos - 1, charpos] += 1;
            } catch (IndexOutOfRangeException){
            }

            grid[rowpos, charpos] = 1001;
        }
        public static void incAll(ref int[,] grid){
            for (int row = 0; row < grid.GetLength(0) ; row++)
            {
                for (int charr = 0; charr < grid.GetLength(1) ; charr++)
                {
                    grid[row, charr] += 1;
                }
            }
        }
        public static string printGrid(int[,] grid){
            string oo = "";
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int charr = 0; charr < grid.GetLength(1); charr++)
                {
                    oo += grid[row, charr] + ",";
                }
                oo += "\n";
            }
        return oo;
        }
    }
}
