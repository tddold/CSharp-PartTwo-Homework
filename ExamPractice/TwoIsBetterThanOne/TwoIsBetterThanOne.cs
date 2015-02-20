using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class TwoIsBetterThanOne
{
    static bool isPalindrom(long number)
    {
        string num = number.ToString();
        for (int i = 0; i < num.Length / 2; i++)
        {
            if (num[i] != num[num.Length - i - 1])
            {
                return false;
            }
        }
        return true;
    }

    static int FindLuckyNumbers(long lowerBound, long upperBound)
    {
        long max = upperBound; //1000000000000000000;
        int left = 0;
        var numbers = new List<long> { 3, 5 };

        int count = 0;
        while (left < numbers.Count)
        {
            int right = numbers.Count;
            for (int i = left; i < right; i++)
            {
                if (numbers[i] < max)
                {
                    numbers.Add((numbers[i] * 10) + 3);
                    numbers.Add((numbers[i] * 10) + 5);
                }
            }
            left = right;
        }

        foreach (var num in numbers)
        {
            if (num >= lowerBound && num <= upperBound && isPalindrom(num))
            {
                count++;
            }
        }

        return count;
    }
    static void Main()
    {
        string input = Console.ReadLine();
        string[] tokens = input.Split(' ');
        long lowerBound = long.Parse(tokens[0]);
        long upperBound = long.Parse(tokens[1]);

        int count = FindLuckyNumbers(lowerBound, upperBound);

        string inputList = Console.ReadLine();
        int percent = int.Parse(Console.ReadLine());

        string[] listTokens = inputList.Split(',');
        List<int> numbers = new List<int>();
        for (int i = 0; i < listTokens.Length; i++)
        {
            numbers.Add(int.Parse(listTokens[i]));
        }
        int answerSecondTask = FindAnswerSecondTask(numbers, percent);
        Console.WriteLine(count);
        Console.WriteLine(answerSecondTask);
    }

    static int FindAnswerSecondTask(List<int> numbers, int percent)
    {
        numbers.Sort();
        for (int i = 0; i < numbers.Count; i++)
        {
            int countSmaller = 0;
            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[i] >= numbers[j])
                {
                    countSmaller++;
                }
            }
            if (countSmaller >= numbers.Count * (percent / 100.0))
            {
                return numbers[i];
            }
        }
        return numbers[numbers.Count - 1];
    }
}
