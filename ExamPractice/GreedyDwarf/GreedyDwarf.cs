using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GreedyDwarf
{
    static long ProccessPattern(int[] vally)
    {
        string[] rawNumbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] pattern = new int[rawNumbers.Length];

        for (int i = 0; i < pattern.Length; i++)
        {
            pattern[i] = int.Parse(rawNumbers[i]);
        }

        long coinSum = 0;
        coinSum += vally[0];
        bool[] visited = new bool[vally.Length];
        visited[0] = true;
        int currentPosition = 0;

        while (true)
        {
            for (int i = 0; i < pattern.Length; i++)
            {
                int nextMove = currentPosition + pattern[i];
                if (nextMove >= 0 && nextMove < vally.Length && !visited[nextMove])
                {
                    coinSum += vally[nextMove];
                    visited[nextMove] = true;
                    currentPosition = nextMove;
                }
                else
                {
                    return coinSum;
                }
            }
        }
    }
    static void Main()
    {
        string[] rawNumbers = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] vallyNumberes = new int[rawNumbers.Length];

        for (int i = 0; i < vallyNumberes.Length; i++)
        {
            vallyNumberes[i] = int.Parse(rawNumbers[i]);
        }

        int numberOfPatterns = int.Parse(Console.ReadLine());

        long sum = long.MinValue;

        for (int i = 0; i < numberOfPatterns; i++)
        {
            long currentSum = ProccessPattern(vallyNumberes);
            if (currentSum > sum)
            {
                sum = currentSum;
            }
        }
        Console.WriteLine(sum);
    }
}
