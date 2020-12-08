﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020_07
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_07/input_day7.txt";
            var input = File.ReadAllLines(path);
            var validColors = new List<string>();

            // PART 1

            //validColors.Add("shiny gold");

            //for (int p = 0; p < validColors.Count; p++) // foreach (var color in validColors)
            //{
            //    foreach (var element in input)
            //    {
            //        Part1(element, validColors[p], ref validColors);
            //    }
            //}
            //Console.WriteLine(validColors.Distinct().Count() - 1); // minus 1 `cause the shiny golden bag cannot contain itself

            // PART 2

            Console.WriteLine(Part2("shiny gold", input, ref validColors) - 1); // minus 1 `cause the shiny goden bag doesnt count
        }

        static void Part1(string element, string color, ref List<string> validColors)
        {
            if (element.Contains(color))
            {
                string[] r = element.Split(" ");

                if (r[0] + $" {r[1]}" != color)
                {
                    validColors.Add(r[0] + $" {r[1]}");
                }
            }
        }

        static int Part2(string color, string[] input, ref List<string> validColors)
        {
            int individualBags = 1;

            foreach (var element in input)
            {
                string[] r = element.Split(" ");

                if (r[0] + $" {r[1]}" == color)
                {
                    if (r.Length <= 7 || validColors.Contains(color)) // "contains no other bags"
                        return 1;

                    for (int b = 4; ; b += 4) // 20 = max elements per line
                    {
                        try
                        {
                            int counter = Int32.Parse(r[b]);
                            Console.WriteLine(r[b]);
                            Console.WriteLine(r[b + 1] + $" {r[b + 2]}");
                            individualBags = individualBags + (counter * Part2(r[b + 1] + $" {r[b + 2]}", input, ref validColors));
                        }
                        catch (IndexOutOfRangeException)
                        {
                            return individualBags;
                        }
                    }
                }
            }
            return individualBags;
        }
    }
}
