//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
//Display them in the standard date format for Canada.

using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
class DatesFromTextCanada
{
    static void Main()
    {
        string text = "Contact Telerik at 15.03.2012 or 16.02.2002";

        DateTime date;

        foreach (var item in Regex.Matches(text,@"\d+\.\d+\.\d+"))
        {
            string[] dateArr = item.ToString().Split('.');
            date = new DateTime(int.Parse(dateArr[2]), int.Parse(dateArr[1]), int.Parse(dateArr[0]));
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            Console.WriteLine(date.ToString("dddd, MMMM dd, yyyy h:mm:ss tt"));
        }
    }
}