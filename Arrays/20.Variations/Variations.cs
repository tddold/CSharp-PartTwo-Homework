using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GenerateVariations
{
    static int n = int.Parse(Console.ReadLine());
    static int k = int.Parse(Console.ReadLine());

    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    static void Variations(int[] array, int index)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = 1; i <= n ; i++)
            {
                array[index] = i;
                Variations(array, index + 1);
            }
        }
    }

    static void Main()
    {
        int[] variations = new int[k];
        Variations(variations, 0);
    }
}