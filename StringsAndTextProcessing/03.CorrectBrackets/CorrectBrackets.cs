//Write a program to check if in a given expression the brackets are put correctly.

using System;

class CorrectBrackets
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string input = Console.ReadLine();
        bool correct = CheckBrackets(input);

        if (correct)
        {
            Console.WriteLine("Brackets are correct");
        }
        else
        {
            Console.WriteLine("Incorrect brackets");
        }
    }

    static bool CheckBrackets(string input)
    {
        int counter = 0;

        if (input[0] == ')')
        {
            return false;
        }

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                counter++;
            }
            else if (input[i] == ')')
            {
                counter--;
            }
        }

        if (counter == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}