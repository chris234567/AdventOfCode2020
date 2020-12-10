using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace AdventOfCode2020_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_10\input_day10.txt";
            var input = File.ReadAllLines(path).Select(s => int.Parse(s)).ToList();

            input.Add(0);
            input.Sort();
            input.Add(input[input.Count - 1] + 3);

            // PART 1

            int ones = 0;
            int threes = 0;

            for (int i = 0; i < input.Count - 1; i++)
            {
                int diff = input[i + 1] - input[i];

                if (diff == 1)
                    ones++;
                else if (diff == 3)
                    threes++;
            }

            Console.WriteLine($"ones : {ones} * threes : {threes}\n = {ones * threes}");

            // PART2 

            // in the works...
        }
    }
}
