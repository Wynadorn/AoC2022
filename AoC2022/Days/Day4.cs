using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Days
{
    internal class Day4 : IDay
    {
        public void Solve(string puzzleInput)
        {
            //puzzleInput = "2-4,6-8\r\n2-3,4-5\r\n5-7,7-9\r\n2-8,3-7\r\n6-6,4-6\r\n2-6,4-8";

            SolvePartOne(puzzleInput);
            SolvePartTwo(puzzleInput);
        }

        private void SolvePartOne(string puzzleInput)
        {
            int matches = 0;

            foreach (string line in puzzleInput.Split('\n', StringSplitOptions.None))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string[] assingments = line.Split(',');
                    string[] elft1 = assingments[0].Split('-');
                    string[] elft2 = assingments[1].Split('-');

                    int elf1Min = int.Parse(elft1[0]);
                    int elf1Max = int.Parse(elft1[1]);
                    int elf2Min = int.Parse(elft2[0]);
                    int elf2Max = int.Parse(elft2[1]);

                    if(elf1Min >= elf2Min && elf1Max <= elf2Max ||
                       elf2Min >= elf1Min && elf2Max <= elf1Max)
                    {
                        matches++;
                        //Console.WriteLine($"Total matches found: {++matches}");
                    }
                }
            }

            string answer = matches.ToString();
            Console.WriteLine($"\tAnswer day {this.GetType().Name[3..]} part 1: {answer}");
        }

        private void SolvePartTwo(string puzzleInput)
        {
            int matches = 0;

            foreach (string line in puzzleInput.Split('\n', StringSplitOptions.None))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string[] assingments = line.Split(',');
                    string[] elft1 = assingments[0].Split('-');
                    string[] elft2 = assingments[1].Split('-');

                    int elf1Min = int.Parse(elft1[0]);
                    int elf1Max = int.Parse(elft1[1]);
                    int elf2Min = int.Parse(elft2[0]);
                    int elf2Max = int.Parse(elft2[1]);

                    if (elf1Min >= elf2Min && elf1Min <= elf2Max ||
                        elf1Max >= elf2Min && elf1Max <= elf2Max ||
                        elf2Min >= elf1Min && elf2Min <= elf1Max ||
                        elf2Max >= elf1Min && elf2Max <= elf1Max)
                    {
                        matches++;
                        //Console.WriteLine($"Total matches found: {++matches}");
                    }
                }
            }

            string answer = matches.ToString();
            Console.WriteLine($"\tAnswer day {this.GetType().Name[3..]} part 2: {answer}");
        }
    }
}