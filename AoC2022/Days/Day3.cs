using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022.Days
{
    internal class Day3 : IDay
    {
        public void Solve(string puzzleInput)
        {
            //puzzleInput = "vJrwpWtwJgWrhcsFMMfFFhFp\r\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\r\nPmmdzqPrVvPwwTWBwg\r\nwMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\r\nttgJtRGJQctTZtZT\r\nCrZsJsPPZsGzwwsLwLmpwMDw";

            SolvePartOne(puzzleInput);
            SolvePartTwo(puzzleInput);
        }

        string scoreLookup = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private void SolvePartOne(string puzzleInput)
        {
            int totalScore = 0;

            foreach (string line in puzzleInput.Split('\n', StringSplitOptions.None))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    string left  = line[0..(line.Length / 2)];
                    string right = line[^(line.Length / 2)..^0];

                    List<char> matches = new List<char>();

                    foreach(char c in left)
                    {
                        foreach(char c2 in right)
                        {
                            if (c == c2)
                            {
                                if(!matches.Contains(c))
                                    matches.Add(c);
                            }
                        }
                    }

                    foreach (var match in matches)
                    {
                        totalScore += scoreLookup.IndexOf(match)+1;
                    }
                }
            }



            string answer = totalScore.ToString();
            Console.WriteLine($"\tAnswer day {this.GetType().Name[3..]} part 1: {answer}");
        }
        
        private void SolvePartTwo(string puzzleInput)
        {
            int totalScore = 0;
            var lines = puzzleInput.Split('\n', StringSplitOptions.None);

            for(int i = 0; i+3 < lines.Length; i+=3)
            {
                string c = lines[i];
                string c2 = lines[i + 1];
                string c3 = lines[i + 2];

                List<char> matches = new List<char>();
                foreach (char q in c)
                {
                    foreach (char q2 in c2)
                    {
                        if (q == q2)
                        {
                            if (!matches.Contains(q))
                                matches.Add(q);
                        }
                    }
                }

                List<char> realMatches = new List<char>();
                foreach (var match in matches)
                {
                    foreach (char q3 in c3)
                    {
                        if (match == q3)
                        {
                            if (!realMatches.Contains(q3))
                                realMatches.Add(q3);
                        }
                    }
                }

                foreach (var match in realMatches)
                {
                    totalScore += scoreLookup.IndexOf(match) + 1;
                }
            }


            string answer = totalScore.ToString();
            Console.WriteLine($"\tAnswer day {this.GetType().Name[3..]} part 2: {answer}");
        }
    }
}