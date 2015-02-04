using System;
using System.Collections.Generic;
using System.Linq;

class MergeSort
{
    static void Main()
    {
        Console.Write("Enter numbers separated by coma: ");
        int[] numbers = Console.ReadLine()
            .Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n))
            .ToArray();

        SortArray(numbers, 0, numbers.Length - 1);
        Console.WriteLine(String.Join(", ", numbers));
    }

    private static void SortArray(int[] numbers, int left, int right)
    {
        int mid;

        if (left < right)
        {
            mid = (left + right) / 2;

            SortArray(numbers, left, mid);
            SortArray(numbers, mid + 1, right);

            MergeArrays(numbers, left, mid + 1, right);
        }
    }

    private static void MergeArrays(int[] numbers, int left, int mid, int right)
    {
        int numbersCount = right - left + 1;
        int leftEnd = mid - 1;
        int position = left;
        int[] temp = new int[numbers.Length];

        while ((left <= leftEnd) && (mid <= right))
        {
            if (numbers[left] <= numbers[mid])
            {
                temp[position++] = numbers[left++];
            }
            else
            {
                temp[position++] = numbers[mid++];
            }
        }

        while (left <= leftEnd)
        {
            temp[position++] = numbers[left++];
        }

        while (mid <= right)
        {
            temp[position++] = numbers[mid++];
        }

        for (int index = numbersCount - 1; index >= 0; index--)
        {
            numbers[right] = temp[right];
            --right;
        }
    }
}

//Write a program that sorts an array of integers using the Merge sort algorithm (find it in Wikipedia).
