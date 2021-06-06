using System;
using System.Collections.Generic;
using System.IO;

namespace BoggleSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Solver.scrabbleWords = new List<string>(File.ReadAllLines(@"C:\Users\macle\source\repos\BoggleSolver\ScrabbleWords.txt"));
            Solver.maximumWordLength = 6;

            Console.WriteLine("Enter the single integer representing the LxW dimensions of the board:");
            int dimension = Int32.Parse(Console.ReadLine());
            while (true)
            {
                Console.WriteLine("Enter the board from top-left to bottom-right; single line of characters:");
                string boardString = Console.ReadLine();
                Solver.Solve(new Board(dimension, boardString));
                Console.WriteLine("");
            }
        }
    }
}
