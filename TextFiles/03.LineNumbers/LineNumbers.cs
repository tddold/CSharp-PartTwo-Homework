//Write a program that reads a text file and inserts line numbers in front of each of its lines.
//The result should be written to another text file.

using System;
using System.IO;
class LineNumbers
{
    static void Main()
    {
        string fileName = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\03.LineNumbers\File.txt";
        System.Text.Encoding encodingCyr = System.Text.Encoding.GetEncoding(1251);

        try
        {
            StreamReader reader = new StreamReader(fileName, encodingCyr);
            StreamWriter writer = new StreamWriter(@"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\03.LineNumbers\NewFile.txt", true, encodingCyr);

            using (reader)
            {
                using (writer)
                {
                    string readLine = reader.ReadLine();
                    int countLine = 0;

                    while (readLine != null)
                    {
                        countLine++;

                        writer.WriteLine("{0}: {1}", countLine, readLine);

                        readLine = reader.ReadLine();
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!!!");
        }
    }
}