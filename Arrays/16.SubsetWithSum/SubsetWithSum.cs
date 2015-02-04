using System;
using System.Collections.Generic;
using System.Text;

class SubsetWithSum
{
    static void Main()
    {
        Console.Write("Enter sum: ");
        int sum = int.Parse(Console.ReadLine());

        int[] numbers = { 2, 1, 2, 4, 3, 5, 2, 6 };

        int max = (int)Math.Pow(2, numbers.Length) - 1;

        int count = 0;

        StringBuilder output = new StringBuilder();

        for (int i = 1; i <= max; i++)
        {
            int currentSum = 0;
            List<int> numOfSum = new List<int>();

            for (int j = 0; j < numbers.Length; j++)
            {
                int bit = (i >> j) & 1;

                if (bit == 1)
                {
                    currentSum += numbers[j];
                    numOfSum.Add(numbers[j]);
                }
            }

            if (sum == currentSum)
            {
                output.AppendLine(string.Join(", ", numOfSum));
                count++;
            }
        }

        Console.WriteLine("{0} subsets exist.",count);
        Console.Write(output.ToString());
    }
}

//We are given an array of integers and a number S.
//Write a program to find if there exists a subset of the elements of the array that has a sum S.