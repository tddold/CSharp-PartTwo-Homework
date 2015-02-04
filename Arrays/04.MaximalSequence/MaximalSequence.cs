using System;
using System.Collections.Generic;

class MaximalSequence
{
    static void Main()
    {
        int[] array = new int[] { 2, 1, 1, 1, 1, 1, 1, 2, 3, 3, 2, 2, 2, 1 };

        int maxSequenceCount = 0;
        int sequenceNumber = 0;

        int previous = array[0];

        int currentCount = 1;

        for (int i = 1; i < array.Length; i++)
        {
            if (previous == array[i])
            {
                currentCount++;
            }
            else
            {
                currentCount = 1;
            }

            if (currentCount > maxSequenceCount)
            {
                maxSequenceCount = currentCount;
                sequenceNumber = previous;
            }

            previous = array[i];
        }

        for (int i = 0; i < maxSequenceCount; i++)
        {
            if (i == maxSequenceCount - 1)
            {
                Console.WriteLine(sequenceNumber);
            }
            else
            {
                Console.Write(sequenceNumber + ", ");
            }
            
        }
    }
}

//Write a program that finds the maximal sequence of equal elements in an array.