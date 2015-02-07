//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.

using System;

class DateDifference
{
    static void Main()
    {
        Console.Write("Enter first date in the format day.month.year: ");
        DateTime firstDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter second date in the format day.month.year: ");
        DateTime secondDate = DateTime.Parse(Console.ReadLine());

        TimeSpan daysBetween = firstDate - secondDate;

        Console.WriteLine("Days between: " + Math.Abs(daysBetween.Days));
    }
}