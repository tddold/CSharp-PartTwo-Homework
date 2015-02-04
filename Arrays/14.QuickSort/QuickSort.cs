using System;
using System.Collections.Generic;
using System.Linq;

class QuickSort
{
    static void Main()
    {
        string[] array = { "Levski", "Botev", "CSKA", "Ludogorec", "Litex", "Slavia", "Lokomotiv" };
        Printing(array);

        Quicksort(array, 0, array.Length - 1);
        Printing(array);
    }

    private static void Printing(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ",array[i]);
        }
        Console.WriteLine();
    }

    private static void Quicksort(IComparable[] elements, int left, int right)
    {
        int i = left;
        int j = right;
        IComparable pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                //Swap
                IComparable temp = elements[i];
                elements[i] = elements[j];
                elements[j] = temp;

                j--;
                i++;
            }
        }

        if (left < j)
        {
            Quicksort(elements, left, j);
        }

        if (i < right)
        {
            Quicksort(elements, i, right);
        }
    }
}

//Write a program that sorts an array of strings using the Quick sort algorithm (find it in Wikipedia).