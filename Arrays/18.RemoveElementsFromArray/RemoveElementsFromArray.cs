using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RemoveElementsFromArray
{
    static void Main()
    {
        int[] array = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };

        int max = (int)Math.Pow(2, array.Length) - 1;

        List<int> longest = new List<int>();

        for (int i = 1; i <= max; i++)
        {
            List<int> current = new List<int>();

            for (int j = 0; j < array.Length; j++)
            {
                int bit = (i >> j) & 1;

                if (bit == 1)
                {
                    current.Add(array[j]);
                }
            }

            bool isIncreasing = true;
            int previous = current[0];
            for (int j = 1; j < current.Count; j++)
            {
                if (previous > current[j])
                {
                    isIncreasing = false;
                }
                previous = current[j];
            }

            if (current.Count > longest.Count && isIncreasing)
            {
                longest = new List<int>(current);
            }
        }

        Console.WriteLine(string.Join(", ",longest));
    }

}

﻿//Write a program that reads an array of integers and 
//removes from it a minimal number of elements in such 
//way that the remaining array is sorted in increasing 
//order. Print the remaining sorted array. Example:
//{6, 1, 4, 3, 0, 3, 6, 4, 5}  {1, 3, 3, 4, 5}