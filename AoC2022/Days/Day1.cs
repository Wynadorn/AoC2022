namespace AoC2022.Days
{
    class Day1 : IDay
    {
        public void Solve(string puzzleInput)
        {
            int total = 0;
            List<int> totals = new List<int>();

            foreach(string line in puzzleInput.Split('\n', StringSplitOptions.None))
            {
                if(string.IsNullOrEmpty(line))
                {
                    totals.Add(total);
                    total = 0;
                }
                else
                {
                    total += int.Parse(line);
                }
            }
            totals.Sort();
            totals.Reverse();

            Console.WriteLine($"\tAnswer day 1 part 1: {totals[0]}");
            Console.WriteLine($"\tAnswer day 1 part 2: {totals[0]+ totals[1]+ totals[2]}");

        }
    }
}
