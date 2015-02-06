//Write a program to convert decimal numbers to their hexadecimal representation.

using System;
using System.Collections.Generic;
class DecimalToHex
{
    static void Main()
    {
        Console.Write("Enter decimal number: ");
        int number = int.Parse(Console.ReadLine());
        List<byte> hex = new List<byte>();

        while (number != 0)
        {
            hex.Add((byte)(number % 16));

            number /= 16;
        }

        Console.Write("0x");

        for (int i = hex.Count - 1; i >= 0; i--)
        {
            switch (hex[i])
            {
                case 10: Console.Write("A"); break;
                case 11: Console.Write("B"); break;
                case 12: Console.Write("C"); break;
                case 13: Console.Write("D"); break;
                case 14: Console.Write("E"); break;
                case 15: Console.Write("F"); break;
                default: Console.Write(hex[i]);
                    break;
            }
        }
        Console.WriteLine();
    }
}