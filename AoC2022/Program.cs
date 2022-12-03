namespace AoC2022
{
    static class Program
    {
        static bool ApplicationIsRunning = true;

        static void Main(string[] args)
        {
            while(ApplicationIsRunning)
            {
                if (args.Length == 0)
                {
                    int day = GetDay();
                    PuzzleAPI.Solve(day);
                }

                Console.WriteLine();
                Console.WriteLine("Would you like to solve another puzzle? (Y/n)");
                var key = Console.ReadKey();
                if(key.Key == ConsoleKey.N || key.Key == ConsoleKey.Escape)
                {
                    ApplicationIsRunning = false;
                }
            }
            
        }

        private static int GetDay()
        {
            int day;

            Console.WriteLine("Which day would you like to solve?");
            string? userInput = Console.ReadLine();
            
            while(!int.TryParse(userInput, out day))
            {
                Console.WriteLine("Invalid input, try again.");
                userInput = Console.ReadLine();
            }

            return day;
        }
    }
}
