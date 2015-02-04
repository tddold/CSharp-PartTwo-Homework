using System;
using System.Collections.Generic;

class PrimeNumbers
{
    static void Main()
    {
        long n = 10000000;
        bool[] e = new bool[n];

        for (int i = 2; i < n; i++)
        {
            e[i] = true;
        }

        for (int i = 2; i < n; i++)
        {
            if (e[i] == true)
            {
                for (int j = 2; (j * i) < n; j++)
                {
                    e[i * j] = false;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (e[i])
            {
                Console.WriteLine("{0}", i);
            }
        }
    }
}

//Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm