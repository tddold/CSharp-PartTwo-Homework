using System;

class ReverseNumber
{
    static void Main()
    {
        Console.Write("Enter decimal number: ");
        decimal number = decimal.Parse(Console.ReadLine());

        Reverse(number);
    }

    static void Reverse(decimal number)
    {
        char[] numToStr = number.ToString().ToCharArray();
        Array.Reverse(numToStr);
        string reversedNumInStr = new string(numToStr);
        decimal reversedNum = decimal.Parse(reversedNumInStr);

        Console.WriteLine("The new number is " + reversedNum);

    }
}

//Write a method that reverses the digits of given decimal number.