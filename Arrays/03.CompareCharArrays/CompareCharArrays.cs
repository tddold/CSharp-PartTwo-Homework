using System;
using System.Collections.Generic;

class CompareCharArrays
{
    static void Main()
    {
        Console.Write("Enter first char array: ");
        string first = Console.ReadLine();

        Console.Write("Enter second char array: ");
        string second = Console.ReadLine();

        while ((first.Length != second.Length))
        {
            Console.WriteLine("Length is not equal");
            Console.WriteLine("Try again\n");

            Console.Write("Enter first char array: ");
            first = Console.ReadLine();

            Console.Write("Enter second char array: ");
            second = Console.ReadLine();
        }

        for (int i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i])
            {
                Console.WriteLine("{0} != {1}",first[i], second[i]);
            }
            else
            {
                Console.WriteLine("{0} == {1}", first[i], second[i]);
            }
        }
    }
}

//Write a program that compares two char arrays lexicographically (letter by letter).