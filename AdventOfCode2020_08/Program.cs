using System;
using System.IO;

namespace AdentOfCode2020_08
{
    class Program
    {
        static void Main(string[] args)
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

                Console.WriteLine(line[0] + "" + line[1]); // we are here

                if (counter == 0 && duplicates[i] == true) // only executes once
                {
                    //break; // PART 1

                    i -= jump;
                    line = instructions[i].Split(" "); // dunno

                    switch (line[0])
                    {
                        case "jmp":
                            i++;
                            break;
                        case "nop":
                            i += Int32.Parse(line[1]);
                            break;
                    }

                    counter++; // only executes once
                    continue;
                }

                jump = 0;

                Console.WriteLine(i);

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

            Console.WriteLine(acc);
        }
    } // 1589, 1599 false
}
