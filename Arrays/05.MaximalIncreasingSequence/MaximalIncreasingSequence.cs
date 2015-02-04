using System;
using System.Collections.Generic;

class MaximalIncreasingSequence
{
    static void Main()
    {
        int[] array = new int[] { 3, 2, 3, 4, 5, 6, 7, 8, 9, 2, 2, 4 };

        int countMax = 1;
        int number = 0;

        int previous = array[0];
        int currentCount = 1;

        for (int i = 1; i < array.Length; i++)
        {
            if (previous < array[i])
            {
                currentCount++;
            }
            else
            {
                currentCount = 1;
            }

            if (currentCount > countMax)
            {
                countMax = currentCount;
                number = array[i];
            }

            previous = array[i];
        }

        number = number - (countMax - 1);

        for (int i = 0; i < countMax; i++)
        {
            if (i == countMax - 1)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.Write(number++ + ", ");
            }
        }
    }
}

//Write a program that finds the maximal increasing sequence in an array.