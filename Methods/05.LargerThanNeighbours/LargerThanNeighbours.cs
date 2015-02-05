using System;

class LargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = { 2, 3, 5, 7, -2, 3, 1 };
        int index = 3;

        CheckIfBiggerThanNeighbours(numbers, index);
    }

    static void CheckIfBiggerThanNeighbours(int[] array, int index)
    {
        if (index - 1 < 0 || index + 1 > array.Length - 1)
        {
            Console.WriteLine("Does not have left or right neighbor!");
        }
        else
        {
            if ((array[index] > array[index - 1]) && (array[index] > array[index + 1]))
            {
                Console.WriteLine("The number at index {0} is bigger than its neighbors", index);
            }
            else
            {
                Console.WriteLine("The number at index {0} is not bigger than its neighbors", index);
            }
        }
        
    }
}

//Write a method that checks if the element at given position in given array of integers is larger than its two neighbours (when such exist).