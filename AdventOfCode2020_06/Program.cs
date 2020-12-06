using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_06\day06_input.txt";
            var groups = File.ReadAllLines(path);

            Dictionary<char, int> characters = new Dictionary<char, int>(); ;
            int count = 0;
            int lines = 0;

            for (int i = 0; i < groups.Length; i++)
            {
                var curr = groups[i].ToCharArray();

                for (int l = 0; l < curr.Length; l++)
                {
                    if(!characters.TryAdd(curr[l], 1))
                    {
                        characters[curr[l]]++;
                    }
                }

                if (groups[i] == "" || i == groups.Length - 1) // next group
                {
                    int counter = 0;

                    if (i != 5 && i != groups.Length - 1) // because line counter does weird stuff 
                        lines--;

                    for (char k = (char)97; k < 123; k++)
                    {
                        if (characters.ContainsKey(k))
                            //if (characters[k] == lines) // <-- Part 2
                                counter++;
                    }
                    
                    count += counter;
                    characters.Clear(); // reset
                    lines = 0;
                }
                lines++;
            }
            Console.WriteLine(count);
        }
    }
}
