using System;
using System.Collections.Generic;

class MaximalKSum
{
    static void Main()
    {
        Console.Write("Enter the array size(n):");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());

        int[] arrayOfN = new int[n];

        while (k > n)
        {
            Console.WriteLine("N must be bigger than K!!!");

            Console.Write("Enter the array size(n): ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Enter k: ");
            k = int.Parse(Console.ReadLine());
            arrayOfN = new int[n];
        }

        for (int i = 0; i < arrayOfN.Length; i++)
        {
            Console.Write("arrayOfN[{0}] = ", i);
            arrayOfN[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arrayOfN);

        int sum = 0;

        for (int i = 0; i < k; i++)
        {
            sum += arrayOfN[n - 1 - i];    
        }

        Console.WriteLine("The sum is " + sum);
    }
}

//Write a program that reads two integer numbers N and K and an array of N elements from the console.
//Find in the array those K elements that have maximal sum.