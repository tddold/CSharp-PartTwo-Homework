//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

using System;
using System.IO;
using System.Collections.Generic;
class SaveSortedNames
{
    static void Main()
    {
        string fileName = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\06.SaveSortedNames\names.txt";

        string sortedName = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\06.SaveSortedNames\SortedNames.txt";

        StreamReader reader = new StreamReader(fileName);

        List<string> names = new List<string>();


        using (reader)
        {
            string name = reader.ReadLine();

            while (name != null)
            {
                names.Add(name);

                name = reader.ReadLine();
            }
        }

        names.Sort();

        StreamWriter writer = new StreamWriter(sortedName, true);

        using (writer)
        {
            for (int i = 0; i < names.Count; i++)
            {
                writer.WriteLine(names[i]);
            }
        }
    }
}