using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JoroTheRabbit
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputNumber = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[inputNumber.Length];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(inputNumber[i]);
        }

        int bestPath = 0;

        for (int startIndex = 0; startIndex < numbers.Length; startIndex++)
        {
            for (int step = 1; step < numbers.Length; step++)
            {
                int index = startIndex;
                int currentPath = 1;
                int next = (index + step); //next = (index + step) % numbers.Length;
                if (next >= numbers.Length)
                {
                    next -= numbers.Length;
                }

                while (numbers[index] < numbers[next]) //next != startIndex && 
                {
                    currentPath++;
                    index = next;
                    next = (index + step) % numbers.Length;
                }
                if (bestPath < currentPath)
                {
                    bestPath = currentPath;
                }
            }
        }
        Console.WriteLine(bestPath);
    }
}
