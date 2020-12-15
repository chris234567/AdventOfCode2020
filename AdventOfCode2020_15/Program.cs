using System;
using System.IO;
using System.Collections.Generic;

    // comment: i dont know how to optimize it any further... 
    // im suspecting the temporary dictionary isn't very performant,
    // but i dont know of any method to search a certain interval ( alle elements except the last ) of a dictionary with wich the temp array of course would become obsolete.

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
            {
                spokenNums.Add(i, Convert.ToInt32(input[i]));
            }

            int position = spokenNums.Count;

            while (position != num)
            {
                int previousNumber = spokenNums[position - 1];
                var temp = new Dictionary<int, int>();

                for (int i = 0; i < spokenNums.Count - 1; i++)
                {
                    temp.Add(i, spokenNums[i]); // all spoken nums except the previous one
                }

                if (!temp.ContainsValue(previousNumber))
                {
                    spokenNums.Add(position, 0);
                }
                else
                {
                    int maxIndex = 0;

                    for (int i = 0; i < temp.Count; i++)
                        if (temp[i] == previousNumber)
                            maxIndex = i;

                    spokenNums.Add(position, (position - 1) - maxIndex);
                }

                position++;
            }
            
            Console.WriteLine("The 2020th number of spoken numbers is : " + spokenNums[num - 1]);
        }
    } 
}
