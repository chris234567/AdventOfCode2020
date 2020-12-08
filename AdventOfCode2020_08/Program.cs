using System;
using System.IO;

namespace AdentOfCode2020_08
{
    class Program
    {
        static void Main(string[] args)
        {
            // PART 1

            Part1();

            // PART 2

            for (int i = 0; i < 1000; i++)
            {
                Part2(i);
            }
        }
        static void Part1()
        {
            var path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_08\input_day08.txt";
            var instructions = File.ReadAllLines(path);
            var acc = 0;
            var duplicates = new bool[instructions.Length];
            int jump = 0;

            for (int i = 0; i < instructions.Length;)
            {
                var line = instructions[i].Split(" ");

                if (duplicates[i] == true)
                    break;

                duplicates[i] = true;

                switch (line[0])
                {
                    case "acc":
                        acc += Int32.Parse(line[1]);
                        i++;
                        jump += 1;
                        break;
                    case "jmp":
                        i += Int32.Parse(line[1]);
                        jump += Int32.Parse(line[1]);
                        break;
                    case "nop":
                        i++;
                        jump += 1;
                        break;
                }
            }
            Console.WriteLine("\n Part1 : " + acc);
        }

        static bool Part2(int start)
        {
            var path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_08\input_day08.txt";
            var instructions = File.ReadAllLines(path);
            var acc = 0;
            var duplicates = new bool[instructions.Length];
            int jump = 0;
            int counter = 0;

            for (int i = 0; i < instructions.Length;)
            {
                var line = instructions[i].Split(" ");

                if (i == start && counter == 0) // only executes on i once
                {
                    i -= jump;
                    line = instructions[i].Split(" ");

                    switch (line[0])
                    {
                        case "jmp":
                            i++;
                            break;
                        case "nop":
                            i += Int32.Parse(line[1]);
                            break;
                    }

                    counter++;
                    continue;
                }
                if (duplicates[i] == true)
                    return false;

                jump = 0;
                duplicates[i] = true;

                switch (line[0])
                {
                    case "acc":
                        acc += Int32.Parse(line[1]);
                        i++;
                        jump += 1;
                        break;
                    case "jmp":
                        i += Int32.Parse(line[1]);
                        jump += Int32.Parse(line[1]);
                        break;
                    case "nop":
                        i++;
                        jump += 1;
                        break;
                }
            }
            Console.WriteLine("\n Part2 : " + acc);
            return true;
        }
    }
}
