using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020_09
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_09\input_day09.txt";
            var lines = File.ReadAllLines(path);

            var numbers = new long[lines.Length];
            int cntr = 0;

            foreach (var element in lines) // convert to long array to save convert to or smthg like that
            {
                numbers[cntr] = long.Parse(element);
                cntr++;
            }

            // PART 1

            for (int i = 25; i < numbers.Length; i++) // every line, starting at the 26th number
            {
                int counter = 0;

                for (int k = i - 25; k < i; k++) // first num
                    for (int l = k + 1; l < i; l++) // second num // plus 1 makes sure they are diff nums
                        if (numbers[i] == (numbers[k] + numbers[l]))
                            counter++;

                if (counter == 0)
                    Console.WriteLine(" \nfautly number : " + numbers[i]);
            }

            // PART 2

            long min = 0;
            long max = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (Recursion(i, numbers) != null)
                {
                    var list = Recursion(i, numbers);
                    min = list[0];

                    for (int k = 0; k < list.Count; k++)
                    {
                        if (list[k] < min)
                            min = list[k];
                        if (list[k] > max)
                            max = list[k];
                    }
                    break;
                }
            }

            Console.WriteLine(" \nencryption weakness : " + (min + max));


            static List<long> Recursion(int start, long[] numbers)
            {
                long sum = 0;
                var contiguousSet = new List<long>();

                for (int i = start; i < numbers.Length; i++) // every line, starting at the 26th number
                {
                    contiguousSet.Add(numbers[i]);
                    sum += numbers[i];

                    if (sum == 20874512)
                        return contiguousSet;

                    else if (sum > 20874512)
                        break;
                }
                return null;
            }
        }
    }
}

