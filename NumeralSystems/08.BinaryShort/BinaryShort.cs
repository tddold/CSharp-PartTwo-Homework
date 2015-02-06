//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;

class BinaryShort
{
    static void Main()
    {
        Console.Write("Enter 16-bit signed integer number: ");
        short num = short.Parse(Console.ReadLine());

        Console.WriteLine(Convert.ToString(num,2).PadLeft(16,'0'));
    }
}
