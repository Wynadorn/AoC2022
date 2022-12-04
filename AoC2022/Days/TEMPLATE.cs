using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Days
{
    internal class Day : IDay
    {
        public void Solve(string puzzleInput)
        {
            SolvePartOne(puzzleInput);
            SolvePartTwo(puzzleInput);
        }

        private void SolvePartOne(string puzzleInput)
        {
            string answer = "";
            Console.WriteLine($"\tAnswer day {this.GetType().Name[3..]} part 1: {answer}");
        }

        private void SolvePartTwo(string puzzleInput)
        {
            string answer = "";
            Console.WriteLine($"\tAnswer day {this.GetType().Name[3..]} part 2: {answer}");
        }
    }
}