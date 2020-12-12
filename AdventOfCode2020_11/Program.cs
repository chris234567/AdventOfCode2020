using System;
using System.IO;

namespace AdventOfCode2020_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_11\input_day11.txt";
            var input = File.ReadAllLines(path);

            char[,] myCharArrayOrigin = new char[input.Length, input[0].Length];

            for (int y = 0; y < myCharArrayOrigin.GetLength(0); y++) // for easier indexing and cause of string immutability
            {
                for (int x = 0; x < myCharArrayOrigin.GetLength(1); x++)
                {
                    myCharArrayOrigin[x, y] = input[x][y];
                }
            }

            char[,] myCharArray = new char[input.Length, input[0].Length];

            for (int y = 0; y < myCharArray.GetLength(0); y++) // copy oder so was
            {
                for (int x = 0; x < myCharArray.GetLength(1); x++)
                {
                    myCharArray[x, y] = myCharArrayOrigin[x, y];
                }
            }


            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    if (y == 0 || y != myCharArray.GetLength(0) - 1 && x == 0 || x == myCharArray.GetLength(1) - 1)
                        if (myCharArray[x, y] == 'L')
                            myCharArray[x, y] = '#';
                        else
                        {
                            if (myCharArray[x, y] == 'L') // empty seat
                                if (y != 0 && myCharArray[x, y - 1] != '#') // no adjacent seat on x axis
                                    if (y != myCharArray.GetLength(0) - 1 && myCharArray[x, y + 1] != '#')
                                        if (x != 0 && myCharArray[x - 1, y] != '#') // no adjacent seat on y axis
                                            if (x != myCharArray.GetLength(1) - 1 && myCharArray[x + 1, y] != '#')

                                                myCharArray[x, y] = '#';
                        }
                }
            }

            for (int i = 0; i < myCharArray.GetLength(0); i++)
            {
                for (int e = 0; e < myCharArray.GetLength(1); e++)
                {
                    Console.Write(myCharArray[i, e]);
                }
                Console.WriteLine();
            }
        }
    }
}

// Anderer Loesungsansatz

//using System;
//using System.IO;

//namespace AdventOfCode2020_11
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string path = @"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_11\input_day11.txt";
//            var input = File.ReadAllLines(path);

//            char[,] myCharArray = new char[input.Length, input[0].Length];

//            for (int y = 0; y < myCharArray.GetLength(0); y++) // for easier indexing and cause of string immutability
//            {
//                for (int x = 0; x < myCharArray.GetLength(1); x++)
//                {
//                    myCharArray[x, y] = input[x][y];
//                }
//            }

//            // Rule 1

//            for (int y = 0; y < myCharArray.GetLength(0); y++)
//            {
//                for (int x = 0; x < myCharArray.GetLength(1); x++)
//                {
//                    int counter = 0;

//                    if (myCharArray[x, y] == 'L') // empty seat

//                        if (y == 0) // first col
//                            // irgentwas
//                            continue;

//                    if (myCharArray[y, x - 1] != '#')

//                        if (y != myCharArray.GetLength(0) - 1) // last col

//                            if (myCharArray[x, y + 1] != '#')

//                                if (x != 0) // first row

//                                    if (myCharArray[x - 1, y] != '#')

//                                        if (x != myCharArray.GetLength(1) - 1) // last col

//                                            if (myCharArray[x + 1, y] != '#')

//                                                myCharArray[x, y] = '#';
//                }
//            }

//            // Rule 2

//            //for (int y = 0; y < input.Length; y++)
//            //{
//            //    for (int x = 0; x < input[0].Length; x++)
//            //    {
//            //        int counter = 0;

//            //        if (myCharArray[x, y] == '#') // occupied seat

//            //            if (y != 0) // first col
//            //            {
//            //                if (myCharArray[x, y - 1] == '#')
//            //                    if (y != myCharArray.GetLength(0) - 1) // last col
//            //                    {
//            //                        if (myCharArray[x, y + 1] == '#')
//            //                            if (x != 0) // first row
//            //                            {
//            //                                if (myCharArray[x - 1, y] == '#')
//            //                                    if (x != myCharArray.GetLength(1) - 1) // last col
//            //                                    {
//            //                                        if (myCharArray[x + 1, y] == '#')

//            //                                            counter++;
//            //                                    }
//            //                                    else
//            //                                        counter++;
//            //                            }
//            //                            else
//            //                                counter++;
//            //                    }
//            //                    else
//            //                        counter++;
//            //            }
//            //            else
//            //                counter++;

//            //        if (counter > 3)
//            //            myCharArray[x, y] = 'L';
//            //    }
//            //}

//            // Printout

//            for (int i = 0; i < myCharArray.GetLength(0); i++)
//            {
//                for (int e = 0; e < myCharArray.GetLength(1); e++)
//                {
//                    Console.Write(myCharArray[i, e]);
//                }
//                Console.WriteLine();
//            }
//        }
//    }
//}
