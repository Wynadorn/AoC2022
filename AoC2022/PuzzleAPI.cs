using AoC2022.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AoC2022
{
    static class PuzzleAPI
    {
        public static string GetPuzzleInput(int day, int star = 1, bool forceRefresh = false)
        {
            string cacheFileName = $"./cache/{day}-{star}-input.txt";
            if (File.Exists(cacheFileName) && !forceRefresh)
            {
                return File.ReadAllText(cacheFileName);
            }
            else
            {
                var url = new Uri($"https://adventofcode.com/2022/day/{day}/input");

                using HttpClientHandler handler = new HttpClientHandler { UseCookies = false };
                using HttpClient client = new HttpClient(handler);
                
                var message = new HttpRequestMessage(HttpMethod.Get, url);
                message.Headers.Add("Cookie",
                                    "_ga=GA1.2.472988738.1670093144; " +
                                    "_gid=GA1.2.965468856.1670093144; " +
                                    "session=53616c7465645f5f82e9dfbbd6faa245fe4897439aea6810e2e3aa9f0f76e517d0a207890724b087f2305f7aaa91e7158cf6e5996f6eef77ef5c983f4eba75b6;");
                HttpResponseMessage result = client.Send(message);
                result.EnsureSuccessStatusCode();

                string? stringResult = result.Content.ReadAsStringAsync().Result;
                if(!string.IsNullOrEmpty(stringResult))
                {
                    var directory = Path.GetDirectoryName(cacheFileName);
                    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    File.WriteAllText(cacheFileName, stringResult);
                    return stringResult;
                }
                else
                {
                    throw new Exception($"Unable to get puzzle input for day {day}.");
                }
            }
        }

        public static void Solve(int day)
        {
            IDay? solver;

            try
            {
                Type? type = Type.GetType($"AoC2022.Days.Day{day}", true);
                if(type == null)
                    throw new Exception("Couln't find solver");

                solver = Activator.CreateInstance(type) as IDay;
                if(solver == null)
                    throw new Exception("Couln't find solver");
            }
            catch(Exception)
            {
                ShowFail(day);
                return;
            }

            string rawInput = GetPuzzleInput(day);
            solver.Solve(rawInput);
            return;
        }

        private static void ShowFail(int day)
        {
            Console.WriteLine($"Unable to find a solution for day {day}.");
        }
    }
}