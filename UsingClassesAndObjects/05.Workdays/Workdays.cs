//Write a method that calculates the number of workdays between today and given date, passed as parameter.
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;
using System.Collections.Generic;
class Workdays
{
    static void Main()
    {
        DateTime today = DateTime.Now;
        Console.WriteLine(today.ToShortDateString());
        Console.Write("Enter future date: ");
        string future = Console.ReadLine();

        DateTime futureDate = DateTime.Parse(future);
        Console.WriteLine(futureDate.ToShortDateString());

        TimeSpan span = futureDate - today;

        //Console.WriteLine(span.Days);

        int timeBetween = span.Days;
        int workDays = 0;

        for (int i = 0; i < timeBetween; i++)
        {
            if (!(today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday))
            {
                if (!IsPublicHoliday(today))
                {
                    workDays++;
                }
            }
            today = today.AddDays(1);
        }

        Console.WriteLine("Work days between the time interval is " + workDays);
    }

    static bool IsPublicHoliday(DateTime date)
    {
        bool isHoliday = false;

        List<DateTime> publicHolidaysList = new List<DateTime>();

        publicHolidaysList.Add(Convert.ToDateTime("1.1.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("2.1.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("3.3.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("10.4.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("13.4.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("1.5.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("6.5.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("24.5.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("6.9.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("22.9.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("24.12.2015"));
        publicHolidaysList.Add(Convert.ToDateTime("25.12.2015"));

        foreach (var holiday in publicHolidaysList)
        {
            if (date.Equals(holiday))
            {
                isHoliday = true;
                break;
            }
        }
        return isHoliday;
    }
}
