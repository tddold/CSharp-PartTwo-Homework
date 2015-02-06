//You are given a sequence of positive integer values written into a string, separated by spaces.
//Write a function that reads these values from given string and calculates their sum.

using System;
using System.Collections.Generic;
using System.Linq;

class SumIntegers
{
    static void Main()
    {
        Console.Write("Enter numbers seperated by space: ");
        string input = Console.ReadLine();
        int[] numbers = input
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n.ToString()))
            .ToArray();

        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        Console.WriteLine(sum);
    }
}