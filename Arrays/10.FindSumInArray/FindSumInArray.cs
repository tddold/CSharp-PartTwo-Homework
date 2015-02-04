using System;
using System.Collections.Generic;

class FindSumInArray
{
    static void Main()
    {
        Console.Write("Enter the desired sum (s): ");
        int sum = int.Parse(Console.ReadLine()); // try with 11
        int[] numbers = { 4, 3, 1, 4, 2, 5, 8 };

        int begin = 0;
        int currentSum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            currentSum = numbers[i];
            begin = i;

            for (int j = i + 1; j < numbers.Length; j++)
            {
                currentSum += numbers[j];

                if (currentSum == sum)
                {
                    for (int k = begin; k <= j; k++)
                    {
                        Console.Write("{0} ",numbers[k]);
                    }
                    Console.WriteLine();
                    break;
                }
            }

            if (sum == currentSum) // Comment this to find more than one sequences
            {
                break;
            }
        }
    }
}

//Write a program that finds in given array of integers a sequence of given sum S (if present).
