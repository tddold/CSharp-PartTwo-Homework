//Write a program, that reads from the console an array of N integers and an integer K, 
//sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.

using System;

class BinarySearch
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter number[{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter search value k = ");
        int k = int.Parse(Console.ReadLine());

        Array.Sort(numbers);

        //print sorted array

        Console.WriteLine(new string('-', n * 4));

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0, 4}", i);
        }
        Console.WriteLine(" :Indexes");

        Console.WriteLine(new string('-',n*4));

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0, 4}", numbers[i]);
        }
        Console.WriteLine(" :Values");

        Console.WriteLine(new string('-', n * 4));

        int index = Array.BinarySearch(numbers, k);

        if (index == -1) // returns - 1 when k is lower than the lowest number in the array
        {
            Console.WriteLine("No such number! \n(The searched value is lower that all of\n the elements so there is no lower number)\n");
        }
        else if (index < -1) // returns this when k is greater than all of the numbers in the array
        {
            int realIndex = ~index - 1; // ~index gives the size of the array of numbers[] 
            Console.WriteLine("The biggest number < than {0} is {1} with index of {2}", k, numbers[realIndex], realIndex);
        }
        else if (index >= 0) // returns the index when k equal to a number in the array of numbers[]
        {
            Console.WriteLine("Number {0} exists in the array and has index of {1}", numbers[index], index);
        }
    }
}