using System;

class AppearanceCount
{
    static void Main()
    {
        int[] numbers = { -2, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3, 4 };
        int searchedNumber = 4;

        int count = CountGivenNumber(numbers, searchedNumber);

        Console.WriteLine("It appears {0} times.", count);
    }

    static int CountGivenNumber(int[] array, int search)
    {
        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (search == array[i])
            {
                count++;
            }
        }
        return count;
    }
}

//Write a method that counts how many times given number appears in given array.
//Write a test program to check if the method is workings correctly.