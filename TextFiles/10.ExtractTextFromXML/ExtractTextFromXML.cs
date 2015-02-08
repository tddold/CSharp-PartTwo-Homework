//Write a program that extracts from given XML file all the text without the tags.

using System;
using System.IO;
class ExtractTextFromXML
{
    static void Main()
    {
        string file = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\10.ExtractTextFromXML\xml.txt";

        StreamReader read = new StreamReader(file);

        using (read)
        {
            string text = read.ReadToEnd();
            int index = 0;

            while (index != text.Length - 1 && index != -1)
            {
                int start = text.IndexOf(">", index);
                int end = text.IndexOf("<", start);

                if (end != start + 1)
                {
                    if ((end - start - 1) < 0)
                    {
                        continue;
                    }
                    string extract = text.Substring(start + 1, end - start - 1);
                    Console.Write(extract.Trim() + " ");
                }
                index = text.IndexOf(">", end + 1);
            }
        }
    }
}
