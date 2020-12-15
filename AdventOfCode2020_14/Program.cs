using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode2020_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\Chris\source\AdventOfCode2020\AdventOfCode2020_14\input_day14.txt");

            var currBitMask = new int[36]; // 36-bit uint bitmask
            var maxMem = 0;

            for (int i = 0; i < input.Length; i++) // get maximu MemorySlot
            {
                if (input[i].StartsWith("mem"))
                {
                    string trimmed = input[i][4..input[i].IndexOf(']')];
                    int temp = Int32.Parse(trimmed);

                    if (temp > maxMem)
                        maxMem = temp;
                }
            }

            var memory = new long[maxMem + 1]; // long because int has only 32 bits and we're 4 bits over

            for (int i = 0; i < input.Length; i++) // goes through every line
            {
                if (input[i].StartsWith("mask")) // update bitmask
                {
                    input[i] = input[i].Remove(0, 7);
                    int k = 0;

                    for (int r = 0; r < input[i].Length; r++)
                    {
                        if (input[i][r] == 'X')
                            currBitMask[k] = 2; // X is represented as 2
                        else
                            currBitMask[k] = Int32.Parse(input[i][r].ToString());
                        k++;
                    }
                }
                else if (input[i].StartsWith("mem"))
                {
                    // read memory slot 

                    string trimmed = input[i][4..input[i].IndexOf(']')];
                    int currMemorySlot = Int32.Parse(trimmed);

                    // decimal - binary - decimal Conversion

                    long currMemoryValue = long.Parse(input[i].Split(' ')[^1]);
                    string convertedBinaryString = Convert.ToString(currMemoryValue, 2);
                    var convertedBinaryInt = new int[currBitMask.Length];
                    int diff = currBitMask.Length - convertedBinaryString.Length;

                    int counter = 0;

                    for (int t = diff; t < convertedBinaryInt.Length; t++)
                    {
                        if (t < diff)
                        {
                            convertedBinaryInt[t] = 0; // leading zeroes
                            continue;
                        }

                        convertedBinaryInt[t] = Convert.ToInt32(convertedBinaryString[counter]) - 48; // ascii value of '0' is 48
                        counter++;
                    }

                    for (int d = 0; d < currBitMask.Length; d++)
                    {
                        switch (currBitMask[d])
                        {
                            case 0:
                                convertedBinaryInt[d] = 0;
                                break;
                            case 1:
                                convertedBinaryInt[d] = 1;
                                break;
                            case 2: // (X) leave as is
                                break;
                        }
                    }

                    double convertedDecimal = 0;

                    for (int f = convertedBinaryInt.Length - 1; f >= 0; f--) // b = 2 to b = 10
                    {
                        if (convertedBinaryInt[35 - f] == 1)
                            convertedDecimal += Math.Pow(2, f);

                    }
                    memory[currMemorySlot] = (long) convertedDecimal;
                }
            }

            long sum = 0;

            foreach (var item in memory)
            {
                sum += item;
            }

            Console.WriteLine("sum of memory values : " + sum);
        }
    }
}
