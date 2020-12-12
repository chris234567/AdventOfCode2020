using System;
using System.IO;

namespace AdventOfCode2020_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_12\input_day12.txt";
            var navigationRoute = File.ReadAllLines(path);

            int north = 0;
            int east = 0;
            int south = 0;
            int west = 0;
            string[] directions = new string[] { "north", "east", "south", "west" }; // for better imagination
            int currDirection = 1;
            int currDegree;

            foreach (var instruction in navigationRoute)
            {
                char currChar = instruction[0];

                if (currChar == 'R' || currChar == 'L') // turning
                {
                    currDegree = Int32.Parse(instruction.Trim('R', 'L')) % 360;

                    switch (currDegree)
                    {
                        case 0:
                            break;
                        case 90:
                            if (currChar == 'R')
                                currDirection = (currDirection + 1) % 4;
                            else if (currChar == 'L')
                                currDirection = Math.Abs((currDirection - 1) % 4);
                            break;
                        case 180:
                            if (currChar == 'R')
                                currDirection = (currDirection + 2) % 4;
                            else if (currChar == 'L')
                                currDirection = Math.Abs((currDirection - 2) % 4);
                            break;
                        case 270:
                            if (currChar == 'R')
                                currDirection = (currDirection + 3) % 4;
                            else if (currChar == 'L')
                                currDirection = Math.Abs((currDirection - 3) % 4);
                            break;
                    }
                }
                else // moving
                {
                    if (currChar == 'F')
                    {
                        switch (currDirection)
                        {
                            case 0:
                                north += Int32.Parse(instruction.Trim('F'));
                                break;
                            case 1:
                                east += Int32.Parse(instruction.Trim('F'));
                                break;
                            case 2:
                                south += Int32.Parse(instruction.Trim('F'));
                                break;
                            case 3:
                                west += Int32.Parse(instruction.Trim('F'));
                                break;
                        }
                    }
                    else if (currChar == 'N')
                    {
                        north += Int32.Parse(instruction.Trim('N'));
                    }
                    else if (currChar == 'E')
                    {
                        east += Int32.Parse(instruction.Trim('E'));
                    }
                    else if (currChar == 'S')
                    {
                        south += Int32.Parse(instruction.Trim('S'));
                    }
                    else if (currChar == 'W')
                    {
                        west += Int32.Parse(instruction.Trim('W'));
                    }
                }
            }

            int posX = Math.Abs(west - east);
            int posY = Math.Abs(north - south);

            Console.WriteLine(posX + posY);
        }
    } // 1996, 3128, (3820, 3948, 4632 ( too high )) false
}
