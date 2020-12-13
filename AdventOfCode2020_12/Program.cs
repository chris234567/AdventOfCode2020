using System;
using System.IO;

namespace AdventOfCode2020_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_12\input_day12.txt";
            string[] navigationRoute = File.ReadAllLines(path);

            SolvePart1(navigationRoute);
            SolvePart2(navigationRoute);
        }

        static void SolvePart1(string[] navigationRoute)
        {
            int north = 0;
            int east = 0;
            int south = 0;
            int west = 0;
            string[] directions = new string[] { "north", "east", "south", "west" }; // for better imagination // could be implemented as an enum...
            int currDirection = 1; // facing east at start
            int currDegree;

            foreach (var instruction in navigationRoute)
            {
                char currChar = instruction[0];

                if (currChar == 'R' || currChar == 'L') // turning
                {
                    currDegree = Int32.Parse(instruction.Trim('R', 'L')) % 360;

                    switch (currDegree)
                    {
                        case 90:
                            if (currChar == 'R')
                                currDirection = (currDirection + 1) % 4;
                            else if (currChar == 'L')
                                currDirection = (currDirection - 1 + 4) % 4; // why doesnt math.abs work?!
                            break;
                        case 180:
                            if (currChar == 'R')
                                currDirection = (currDirection + 2) % 4;
                            else if (currChar == 'L')
                                currDirection = (currDirection - 2 + 4) % 4;
                            break;
                        case 270:
                            if (currChar == 'R')
                                currDirection = (currDirection + 3) % 4;
                            else if (currChar == 'L')
                                currDirection = (currDirection - 3 + 4) % 4;
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
        static void SolvePart2(string[] navigationRoute)
        {
            int north = 0;
            int east = 0;
            int south = 0;
            int west = 0;
            string[] directions = new string[] { "north", "east", "south", "west" }; // for better imagination
            int currDirection1 = 1; // waypoint facing part east
            int currDirection2 = 0; // and part north at start
            int currDegree;

            int[] waypoint = new int[] { 10, 1, 0, 0}; // 10 east 1 north

            foreach (var instruction in navigationRoute)
            {
                char currChar = instruction[0];

                if (currChar == 'R' || currChar == 'L') // turning
                {
                    currDegree = Int32.Parse(instruction.Trim('R', 'L')) % 360;
                    int value = 0; // positions to be shifted

                    switch (currDegree)
                    {
                        case 90:
                            if (currChar == 'R')
                            {
                                currDirection1 = (currDirection1 + 1) % 4;
                                currDirection2 = (currDirection2 + 1) % 4;
                                value = 1;
                            }
                            else if (currChar == 'L')
                            {
                                currDirection1 = (currDirection1 - 1 + 4) % 4;
                                currDirection2 = (currDirection2 - 1 + 4) % 4;
                                value = - 1;
                            }
                            break;
                        case 180:
                            if (currChar == 'R')
                            {
                                currDirection1 = (currDirection1 + 2) % 4;
                                currDirection2 = (currDirection2 + 2) % 4;
                                value = 2;
                            }
                            else if (currChar == 'L')
                            {
                                currDirection1 = (currDirection1 - 2 + 4) % 4;
                                currDirection2 = (currDirection2 - 2 + 4) % 4;
                                value = -2;
                            }
                            break;
                        case 270:
                            if (currChar == 'R')
                            {
                                currDirection1 = (currDirection1 + 3) % 4;
                                currDirection2 = (currDirection2 + 3) % 4;
                                value = 3;
                            }
                            else if (currChar == 'L')
                            {
                                currDirection1 = (currDirection1 - 3 + 4) % 4;
                                currDirection2 = (currDirection2 - 3 + 4) % 4;
                                value = -3;
                            }
                            break;
                    }

                    if (value > 0)
                    {
                        int[] temp = new int[waypoint.Length];

                        for (int i = 0; i < waypoint.Length; i++)
                        {
                            temp[i] = waypoint[Math.Abs((i - value)) % waypoint.Length];
                        }

                        waypoint = temp;
                    } 
                    else if (value < 0)
                    {
                        int[] temp = new int[waypoint.Length];

                        for (int i = 0; i < waypoint.Length; i++)
                        {
                            temp[i] = waypoint[(i - value + 4) % waypoint.Length];
                        }

                        waypoint = temp;
                    }
                }
                else // moving
                {
                    if (currChar == 'F')
                    {
                        switch (currDirection1)
                        {
                            case 0:
                                north += waypoint[0] * Int32.Parse(instruction.Trim('F'));
                                break;
                            case 1:
                                east += waypoint[1] * Int32.Parse(instruction.Trim('F'));
                                break;
                            case 2:
                                south += waypoint[2] * Int32.Parse(instruction.Trim('F'));
                                break;
                            case 3:
                                west += waypoint[3] * Int32.Parse(instruction.Trim('F'));
                                break;
                        }
                        switch (currDirection2)
                        {
                            case 0:
                                north += waypoint[0] * Int32.Parse(instruction.Trim('F'));
                                break;
                            case 1:
                                east += waypoint[1] * Int32.Parse(instruction.Trim('F'));
                                break;
                            case 2:
                                south += waypoint[2] * Int32.Parse(instruction.Trim('F'));
                                break;
                            case 3:
                                west += waypoint[3] * Int32.Parse(instruction.Trim('F'));
                                break;
                        }
                    }
                    else if (currChar == 'N')
                    {
                        waypoint[0] += Int32.Parse(instruction.Trim('N'));
                    }
                    else if (currChar == 'E')
                    {
                        waypoint[1] += Int32.Parse(instruction.Trim('E'));
                    }
                    else if (currChar == 'S')
                    {
                        waypoint[2] += Int32.Parse(instruction.Trim('S'));
                    }
                    else if (currChar == 'W')
                    {
                        waypoint[3] += Int32.Parse(instruction.Trim('W'));
                    }
                }
            }

            int posX = Math.Abs(west - east);
            int posY = Math.Abs(north - south);

            Console.WriteLine(posX + posY);
        }
        //public static int[] RotateVector(int[] waypoint, double degree)
        //{
        //    waypoint[0] = waypoint[0] * Convert.ToInt32(Math.Cos(degree)) - waypoint[1] * Convert.ToInt32(Math.Sin(degree)); // x
        //    waypoint[1] = waypoint[0] * Convert.ToInt32(Math.Sin(degree)) + waypoint[1] * Convert.ToInt32(Math.Cos(degree)); // y

        //    return waypoint;
        //}
    }
}
