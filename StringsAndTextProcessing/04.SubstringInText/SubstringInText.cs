//Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).

using System;

class SubstringInText
{
    static void Main()
    {
        string text = "We are living in an yellow submarine."
                   + " We don't have anything else. Inside the submarine is very tight."
                   + " So we are drinking all the day. We will move out of it in 5 days.";

        string search = "in";

        int count = 0;
        int index = text.ToLower().IndexOf(search, 0);

        while (index >= 0)
        {
            count++;
            index++;
            index = text.ToLower().IndexOf(search, index);
        }
        Console.WriteLine(count);
    }
}
