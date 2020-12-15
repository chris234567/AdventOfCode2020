using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_13\input_day13.txt");

            int earliestDeparture = Int32.Parse(input[0]);
            var times = input[1].Split(',');
            var buses = new List<int>();
            var busIDS = new List<int>();

            foreach (var bus in times)
            {
                if (bus != "x")
                {
                    buses.Add(Int32.Parse(bus));
                    busIDS.Add(Int32.Parse(bus));
                }
            }

            // PART 1

            for (int i = 0; i < buses.Count; i++)
            {
                buses[i] = buses[i] * (earliestDeparture / buses[i] + 1);
            }

            int diff = earliestDeparture;
            int currIndex = 0;

            foreach (var bus in buses)
            {
                if (bus - earliestDeparture < diff)
                {
                    diff = bus - earliestDeparture;
                    currIndex = buses.IndexOf(bus);
                }
            }

            Console.WriteLine("Bus ID * minutes waiting : " + diff * busIDS[currIndex]);

            // PART 2 // in the works

            busIDS = new List<int>();
            var remainders = new List<int>();
            int counter = 0;

            foreach (var bus in times)
            {
                if (bus != "x")
                {
                    busIDS.Add(Int32.Parse(bus));
                    remainders.Add(counter);
                }
                else
                {
                    busIDS.Add(0); // needed for iteration
                }

                counter++;
            }

            // iterative solution approach 1

            long earliestTimestamp = 100000000000000;

            while (true)
            {
                int counter1 = 0;

                foreach (var ID in busIDS)
                {
                    if (ID == 0)
                        counter1++;

                    else if ((earliestTimestamp + counter1) % ID == 0)
                        counter1++;
                }

                if (counter1 == busIDS.Count)
                    break;

                earliestTimestamp += busIDS[0];

            }

            // iterative solution approach 2

            //Console.WriteLine(findMinX(busIDS, remainders, busIDS.Count));

            static long findMinX(List<int> num, List<int> rem, int k)
            {
                long x = 100000000000000;

                while (true)
                {
                    int j;

                    for (j = 0; j < k; j++)
                        if (x % num[j] != rem[j])
                            break;

                    if (j == k)
                        return x;

                    x += 41;

                }
            }
        }
    }
}
