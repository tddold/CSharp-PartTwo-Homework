using System;
using System.Collections.Generic;

class CompareArrays
{
    static void Main()
    {
        Console.Write("Enter lenght of arrays: ");
        int length = int.Parse(Console.ReadLine());

        int[] arrayOne = new int[length];
        int[] arrayTwo = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("arrayOne[{0}]= ",i);
            arrayOne[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < length; i++)
        {
            Console.Write("arrayTwo[{0}]= ", i);
            arrayTwo[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < length; i++)
        {
            if (arrayOne[i] != arrayTwo[i])
            {
                Console.WriteLine("{0} != {1}",arrayOne[i],arrayTwo[i]);
            }
            else
            {
                Console.WriteLine("{0} == {1}", arrayOne[i], arrayTwo[i]);
            }
        }
    }
}

//Write a program that reads two integer arrays from the console and compares them element by element.
