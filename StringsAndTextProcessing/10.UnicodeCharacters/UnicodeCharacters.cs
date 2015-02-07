//Write a program that converts a string to a sequence of C# Unicode character literals.
//Use format strings.

using System;
using System.Text;
class UnicodeCharacters
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();

        StringBuilder convert = new StringBuilder();

        foreach (var ch in input)
        {
            convert.AppendFormat("\\u{0:X4}", (int)ch);
        }

        Console.WriteLine(convert.ToString());
    }
}