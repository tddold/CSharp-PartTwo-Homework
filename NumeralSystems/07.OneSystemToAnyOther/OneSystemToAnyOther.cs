//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤ 16).

using System;

class OneSystemToAnyOther
{
    static void Main()
    {
        Console.Write("Enter number to convert: ");
        string givenNumber = Console.ReadLine();
        Console.Write("Enter the base of the given number: ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Enter the base of the converted number: ");
        int d = int.Parse(Console.ReadLine());
        Console.WriteLine(BaseSToBaseD(givenNumber, s, d));
    }

    static int GetNumber(string s, int i)
    {
        if (s[i] >= 'A')
        {
            return s[i] - 'A' + 10;
        }
        return s[i] - '0';
    }

    static char GetChar(long num)
    {
        if (num>=10)
        {
            return (char)(num + 'A' - 10);
        }
        return (char)(num + '0');
    }

    static string DecimalToBaseD(long number, int systemBase = 2)
    {
        string result = "";
        while (number > 0)
        {
            result = GetChar(number % systemBase) + result;
            number = number / systemBase;
        }
        return result;
    }

    static long BaseSToDecimal(string str, int systemBase = 2)
    {
        long number = 0;
        for (int i = str.Length - 1, j = 1; i >= 0; i--, j *= systemBase)
        {
            number += GetNumber(str, i) * j;
        }
        return number;
    }
    static string BaseSToBaseD(string input, int s, int d)
    {
        return DecimalToBaseD(BaseSToDecimal(input, s), d);
    }
}
