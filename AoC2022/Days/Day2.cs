namespace AoC2022.Days
{
    class Day2 : IDay
    {
        public void Solve(string puzzleInput)
        {
            int totalScore = 0;

            foreach (string line in puzzleInput.Split('\n', StringSplitOptions.None))
            {

                if(!string.IsNullOrEmpty(line))
                {
                    totalScore += GetScore((line.ToArray())[0], (line.ToArray())[2]);
                }
                
            }
            
            Console.WriteLine($"\tAnswer day 2 part 1: {totalScore}");
            Console.WriteLine($"\tAnswer day 2 part 2: {SlovePartTwo(puzzleInput)}");
        }

        private static int GetScore(char A, char B)
        {
            int roundScore = 0;

            switch (B)
            {
                case 'X':
                    roundScore = 1;
                    break;
                case 'Y':
                    roundScore = 2;
                    break;
                case 'Z':
                    roundScore = 3;
                    break;
            }

            roundScore += ResultScore(A, B);
            return roundScore;
        }

        private static string SlovePartTwo(string puzzleInput)
        {
            int totalScore = 0;

            foreach (string line in puzzleInput.Split('\n', StringSplitOptions.None))
            {

                if (!string.IsNullOrEmpty(line))
                {
                    switch ((line.ToArray())[2])
                    {
                        //lose
                        case 'X':
                            switch ((line.ToArray())[0])
                            {
                                case 'A':
                                    totalScore += GetScore('A', 'Z');
                                    break;
                                case 'B':
                                    totalScore += GetScore('B', 'X');
                                    break;
                                case 'C':
                                    totalScore += GetScore('C', 'Y');
                                    break;
                            }
                            break;
                        //draw
                        case 'Y':
                            switch ((line.ToArray())[0])
                            {
                                case 'A':
                                    totalScore += GetScore('A', 'X');
                                    break;
                                case 'B':
                                    totalScore += GetScore('B', 'Y');
                                    break;
                                case 'C':
                                    totalScore += GetScore('C', 'Z');
                                    break;
                            }
                            break;
                        //win
                        case 'Z':
                            switch ((line.ToArray())[0])
                            {
                                case 'A':
                                    totalScore += GetScore('A', 'Y');
                                    break;
                                case 'B':
                                    totalScore += GetScore('B', 'Z');
                                    break;
                                case 'C':
                                    totalScore += GetScore('C', 'X');
                                    break;
                            }
                            break;
                    }
                }
            }

            return totalScore.ToString();
        }

        static int ResultScore(char A, char B)
        {
            switch (B)
            {
                case 'X':
                    if (A == 'A')
                        return 3;
                    if (A == 'B')
                        return 0;
                    if (A == 'C')
                        return 6;
                    break;
                case 'Y':
                    if (A == 'A')
                        return 6;
                    if (A == 'B')
                        return 3;
                    if (A == 'C')
                        return 0;
                    break;
                case 'Z':
                    if (A == 'A')
                        return 0;
                    if (A == 'B')
                        return 6;
                    if (A == 'C')
                        return 3;
                    break;
            }
            throw new Exception();
        }
    }
}