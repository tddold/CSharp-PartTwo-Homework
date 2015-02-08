//Write a program that deletes from given text file all odd lines.
//The result should be in the same file.

using System;
using System.IO;
class DeleteOddLines
{
    static void Main()
    {
        string input = GenerateLargeFile();
        string tempFile = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\09.DeleteOddLines\TempFile.txt";

        StreamReader read = new StreamReader(input);
        StreamWriter write = new StreamWriter(tempFile, true);

        using (read)
        {
            using (write)
            {
                string line = read.ReadLine();
                int count = 1;

                while (line != null)
                {
                    if (count % 2 ==0)
                    {
                        write.WriteLine(line);
                    }
                    count++;
                    line = read.ReadLine();
                }
            }
        }

        File.Replace(tempFile, input, "backup.txt");
        File.Delete(tempFile);
        File.Delete("backup.txt");

    }

    static string GenerateLargeFile()
    {
        string fileName = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\09.DeleteOddLines\InputFile.txt";
        Random generator = new Random();

        StreamWriter write = new StreamWriter(fileName, true);

        using (write)
        {
            string[] words = { "start", "starter", "starting", "start-up", "start again", "bystart", "stop" };
            long fileSize = 0;
            long maxSize = 1000;
            int count = 1;

            while (fileSize < maxSize)
            {
                string word = "";

                for (int i = 0; i < 6; i++)
                {
                    word += words[generator.Next(words.Length)] + " ";
                }
                write.WriteLine("{0}: {1}", count, word);
                FileInfo file = new FileInfo(fileName);
                fileSize = file.Length;
                count++;
            }
        }

        return fileName;
    }
}