using System;
using System.Collections.Generic;

class SelectionSort
{
    static void Main()
    {
        int[] array = { 66, 90, 42, 11, 32, 44, 33, 61, 24, 42, 5, 7, 51, 3, 23, 84, 20, 22, 16, 73, 43, 33, 66, 39, 99,
                        88, 6, 51, 53, 25, 57, 95, 31, 61, 17, 81, 22, 61, 68, 52, 64, 32, 67, 38, 48, 58, 45, 62, 40, 19};

        int startPosition = 0;

        while (startPosition < array.Length)
        {
            int currentMin = int.MaxValue;
            int currentMinIndex = 0;

            for (int i = startPosition; i < array.Length; i++)
            {
                if (array[i] < currentMin)
                {
                    currentMin = array[i];
                    currentMinIndex = i;
                }
            }

            int temp = array[startPosition];

            array[startPosition] = array[currentMinIndex];
            array[currentMinIndex] = temp;

            startPosition++;
        }

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("{0}: {1}", i, array[i]);
        }
    }
}

//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
//Use the Selection sort algorithm: Find the smallest element, move it at the first position, find the 
//smallest from the rest, move it at the second position, etc.