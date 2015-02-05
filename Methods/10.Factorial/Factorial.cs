using System;
using System.Numerics;
class FactorialOfN
{
    static void Main()
    {
        int[] arr = new int[100];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i + 1;
        }

        CalculateFactorialOfN(arr);
    }
    
    static void CalculateFactorialOfN(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            BigInteger factorial = Factorial(array[i]);
            Console.WriteLine(factorial);
        }
    }

    static BigInteger Factorial(int i)
    {
        BigInteger fact = i;
        while (i > 1)
        {
            fact *= i - 1;
            i--;
        }
        return fact;
    }

}

//Write a program to calculate n! for each n in the range [1..100].