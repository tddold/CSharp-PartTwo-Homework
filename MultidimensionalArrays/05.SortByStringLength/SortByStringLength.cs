//You are given an array of strings. Write a method that sorts the 
//array by the length of its elements (the number of characters composing them).

using System;
using System.Collections.Generic;

class SortByStringLength
{
    static void Main()
    {
        string[] teams = { "CSKA", "SLAVIA", "LEVSKI", "LUDOGOREC", "LITEX",
                             "BOTEV", "PIRIN", "RILECO", "NEFTOHIMIK" };

        Array.Sort(teams, new TeamsComparer());

        foreach (var team in teams)
        {
            Console.WriteLine(team);
        }
    }

    public class TeamsComparer : IComparer<string>
    {
        public int Compare(string teamOne, string teamTwo)
        {
            return teamOne.Length.CompareTo(teamTwo.Length);
        }
    }
}
