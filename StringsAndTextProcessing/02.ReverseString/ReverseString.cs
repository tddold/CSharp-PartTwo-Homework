//Write a program that reads a string, reverses it and prints the result at the console.

using System;
class ReverseString
{
    static void Main()
    {
        Console.Write("Enter string: ");
        char[] input = Console.ReadLine().ToCharArray();

        Array.Reverse(input);

        Console.WriteLine(input);
    }
}