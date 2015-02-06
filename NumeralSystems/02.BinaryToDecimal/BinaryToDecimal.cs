//Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.Write("Enter binary number: ");
        string binary = Console.ReadLine();

        int decimalNumber = 0;
        int power = binary.Length - 1;

        for (int i = 0; i < binary.Length; i++)
        {
            decimalNumber += int.Parse(binary[i].ToString()) * (int)Math.Pow(2, power);
            power--;
        }

        Console.WriteLine(decimalNumber);
    }
}