using System;
using System.IO;
class CompareTextFiles
{
    static void Main()
    {
        System.Text.Encoding encodingCyr = System.Text.Encoding.GetEncoding(1251);

        string fileOne = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\04.CompareTextFiles\FileOne.txt";
        string fileTwo = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\04.CompareTextFiles\FileTwo.txt";

        try
        {
            StreamReader readerOne = new StreamReader(fileOne, encodingCyr);
            StreamReader readerTwo = new StreamReader(fileTwo, encodingCyr);

            int same = 0;
            int different = 0;

            using (readerOne)
            {
                using (readerTwo)
                {
                    string readOneLine = readerOne.ReadLine();
                    string readTwoLine = readerTwo.ReadLine();

                    while (readOneLine != null || readTwoLine != null)
                    {
                        if (readOneLine == readTwoLine)
                        {
                            same++;
                        }
                        else
                        {
                            different++;
                        }

                        readOneLine = readerOne.ReadLine();
                        readTwoLine = readerTwo.ReadLine();
                    }
                }
            }

            Console.WriteLine("The number of the same lines is " + same);
            Console.WriteLine("The number of the different lines is " + different);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Files not found!!!");;
        }
    }
}
