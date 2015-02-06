//Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;

class RandomNumbers
{
    static void Main()
    {
        Random generator = new Random();

        for (int i = 1; i < 11; i++)
        {
            Console.WriteLine("{0} random number: {1}",i,generator.Next(100,201));
        }
    }
}