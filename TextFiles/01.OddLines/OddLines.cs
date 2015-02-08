//Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.Text;
using System.IO;
class OddLines
{
    static void Main()
    {
        try
        {
            System.Text.Encoding encodingCyr = System.Text.Encoding.GetEncoding(1251);

            string fileName = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\01.OddLines\test.txt";
            StreamReader reader = new StreamReader(fileName, encodingCyr);

            using (reader)
            {
                int countLine = 0;
                string lineRead = reader.ReadLine();

                while (lineRead != null)
                {
                    countLine++;

                    if (countLine % 2 != 0)
                    {
                        Console.WriteLine(lineRead);
                    }

                    lineRead = reader.ReadLine();
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!!!");
        }
    }
}