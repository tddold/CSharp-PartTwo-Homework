//Write a program that concatenates two text files into another text file.

using System;
using System.Text;
using System.IO;
class ConcatenateTextFiles
{
    static void Main()
    {
        System.Text.Encoding encodingCyr = System.Text.Encoding.GetEncoding(1251);

        try
        {
            string fileOne = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\02.ConcatenateTextFiles\FileOne.txt";
            string fileTwo = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\02.ConcatenateTextFiles\FileTwo.txt";

            StreamReader readOne = new StreamReader(fileOne, encodingCyr);
            StreamReader readTwo = new StreamReader(fileTwo, encodingCyr);

            string readFileOne = "";
            string readFileTwo = "";

            using (readOne)
            {
                readFileOne = readOne.ReadToEnd();
            }

            using (readTwo)
            {
                readFileTwo = readTwo.ReadToEnd();
            }

            StreamWriter newFile = new StreamWriter(@"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\02.ConcatenateTextFiles\New File.txt", true, encodingCyr);

            using (newFile)
            {
                newFile.WriteLine(readFileOne);
                newFile.WriteLine(readFileTwo);
            }


        }
        catch (FileLoadException)
        {
            Console.WriteLine("Files not found.");
        }
    }
}