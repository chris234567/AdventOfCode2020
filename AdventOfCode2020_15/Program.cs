using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020_15
{
    class Program
    {
        static void Main(string[] args)
        {
            var myReader = new StreamReader(@"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_15\input_day15.txt"); // i am just using a StreamReader to try it out ;)
            var input = myReader.ReadLine().Split(',');

            // PART 1

            SpeakingGame(input, 2020);

            // PART 2

            SpeakingGame(input, 30000000);

            myReader.Close();
        }

        static void SpeakingGame(string[] input, int num)
        {
            var spokenNums = new Dictionary<int, int>();

            for (int i = 0; i < input.Length; i++)

                spokenNums.Add(i, Convert.ToInt32(input[i]));

            for (int position = spokenNums.Count; position < num; position++)
            {
                int previousNumber = spokenNums[position - 1];

                if (spokenNums.Values.ToList().IndexOf(previousNumber) != spokenNums.Count - 1) // like .Contains(previousNumber) except it ignores last index

                    spokenNums.Add(position, (position - 1) - spokenNums.Values.ToList().LastIndexOf(previousNumber, spokenNums.Count - 2));
                else
                    spokenNums.Add(position, 0);
            }
            
            Console.WriteLine("The 2020th number of spoken numbers is : " + spokenNums[num - 1]);
        }
    } 
}
