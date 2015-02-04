using System;
using System.Collections.Generic;

class MaximalSum
{
    static void Main()
    {
        int[] numbers = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        //int[] numbers = { -2, -3, 4, -1, -2, 1, 5, -3 };
        //int[] numbers = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

        int maxSoFar = numbers[0];
        int maxStartingHere = numbers[0];
        int begin = 0;
        int tempBegin = 0;
        int end = 0;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (maxStartingHere < 0)
            {
                maxStartingHere = numbers[i];
                tempBegin = i;
            }
            else
            {
                maxStartingHere += numbers[i];
            }

            if (maxSoFar < maxStartingHere)
            {
                maxSoFar = maxStartingHere;
                begin = tempBegin;
                end = i;
            }
        }

        for (int i = begin; i <= end; i++)
        {
            Console.Write("{0} ", numbers[i]);

        }

        Console.WriteLine("Sum = " + maxSoFar);
    }
}

//Write a program that finds the sequence of maximal sum in given array.