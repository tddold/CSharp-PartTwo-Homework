using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = { 1, 1, 2, 1, 1, 4, 1, 1, 2, 1 };

        int index = LargerThanNeighbours(numbers);

        Console.WriteLine(index);
    }

    static int LargerThanNeighbours(int[] array)
    {
        for (int i = 1; i < array.Length - 1; i++)
        {
            if (array[i - 1] < array[i] && array[i] > array[i + 1])
            {
                return i;
            }
        }
        return -1;
    }
}

//Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there’s no such element.
//Use the method from the previous exercise.