using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SubsetK
{
    static void Main()
    {
        Console.Write("N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("K = ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Sum = ");
        int sum = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            Console.Write("numbers[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int max = (int)Math.Pow(2, n) - 1;

        for (int i = 0; i <= max; i++)
        {
            int currentSum = 0;
            int times = 0;
            List<int> numOfSum = new List<int>();

            for (int j = 0; j < numbers.Length; j++)
            {
                int bit = (i >> j) & 1;

                if (bit == 1 && times < k)
                {
                    currentSum += numbers[j];
                    times++;
                    numOfSum.Add(numbers[j]);
                }
            }

            if (sum == currentSum && times == k)
            {
                output.AppendLine(string.Join(", ", numOfSum));
            }
        }

        if (output.ToString() == "")
        {
            Console.WriteLine("No such sum.");
        }
        else
        {
            Console.Write(output.ToString());
        }
        
    }
}

//Write a program that reads three integer numbers N, K and S and an array of N elements from the console.
//Find in the array a subset of K elements that have sum S or indicate about its absence.