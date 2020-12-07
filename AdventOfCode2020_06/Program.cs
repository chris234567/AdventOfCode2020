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
            var input = File.ReadAllText(path);
            input.Split("y");
            foreach (var element in input)
            {
                Console.WriteLine(element);
            }
            //int count = 0;
            //int lines = 0;
            //Dictionary<char, int> characters = new Dictionary<char, int>(); ;

            //for (int i = 0; i < groups.Length; i++)
            //{
            //    if (!(groups[i] == ""))
            //        lines++;

            //    var curr = groups[i].ToCharArray();

            //    for (int l = 0; l < curr.Length; l++)
            //        if(!characters.TryAdd(curr[l], 1))
            //            characters[curr[l]]++;

            //    if (groups[i] == "" || i == groups.Length - 1) // next group
            //    {
            //        int counter = 0;

            //        for (char k = (char)97; k < 123; k++)
            //            if (characters.ContainsKey(k))
            //                //if (characters[k] == lines) // <-- Part 2
            //                    counter++;
                    
            //        count += counter;
            //        characters.Clear(); // reset
            //        lines = 0;
            //    }
            //}
            //Console.WriteLine("Count: " + count);
        }
    }
}
