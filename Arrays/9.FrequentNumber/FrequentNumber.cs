using System;
using System.Collections.Generic;

class FrequentNumber
{
    static void Main()
    {
        int[] numbers = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        int mostFrequent = 0;
        int mostCount = 1;

        for (int i = 0; i < numbers.Length; i++)
        {
            int currentCount = 1;

            for (int j = 0; j < numbers.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }
                else
                {
                    if (numbers[i] == numbers[j])
                    {
                        currentCount++;
                    }
                }
            }

            if (currentCount > mostCount)
            {
                mostCount = currentCount;
                mostFrequent = numbers[i];
            }
        }

        Console.WriteLine("{0} ({1} times)",mostFrequent,mostCount);
    }
}

//Write a program that finds the most frequent number in an array.