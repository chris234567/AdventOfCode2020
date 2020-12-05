using System;
using System.Linq;
using System.IO;

namespace AdventOfCode2020_05
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_05\day05_input.txt";
            var seats = File.ReadAllLines(path);

            int upper = 127, lower = 0;
            int right = 7, left = 0;
            int posX, posY, seatID;
            int greatestSeatID = 0;
            var occupiedSeats = new bool[1023];

            foreach(var element in seats)
            {
                posY = SeatsYX(element, upper, lower, 6, 'F', 'B');
                posX = SeatsYX(element, right, left, 9, 'L', 'R');

                seatID = posY * 8 + posX;

                if (seatID > greatestSeatID)
                    greatestSeatID = seatID;

                occupiedSeats[seatID] = true; // for Part 2
            }

            Console.WriteLine("The greatest seatID is : " + greatestSeatID);

            // Part 2

            int counter = 0;
            int highestMissingSeat = 0;

            foreach(var element in occupiedSeats)
            {
                if(!element && counter < greatestSeatID) // the closest seatID to greatestSeatID is te one thats missing
                    highestMissingSeat = counter;
                counter++;
            }

            Console.WriteLine("Your seatID is: " + highestMissingSeat);
        }

        static int SeatsYX(string s, int upper, int lower, int length, char a, char b)
        {
            int counter = 0;

            foreach (var element in s)
            {
                if (element == a) 
                {
                    upper -= (upper - lower) / 2 + 1;
                    if (counter == length)
                        return upper;
                }
                else if (element == b)
                {
                    lower += (upper - lower) / 2 + 1;
                    if (counter == length)
                        return lower;
                }
                counter++;
            }
            return 0;
        }
    }
}
