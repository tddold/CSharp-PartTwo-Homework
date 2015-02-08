//Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file.
//Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
class ReplaceSubString
{
    static void Main()
    {
        string input = GenerateLargeFile();
        string tempFile = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\07.ReplaceSubString\TempFile.txt";
        string search = "start";
        string replace = "finish";

        using (StreamReader read = new StreamReader(input))
        {
            using (StreamWriter write = new StreamWriter(tempFile,true))
            {
                string line = read.ReadLine();
                while (line != null)
                {
                    write.WriteLine(line.Replace(search,replace));
                    line = read.ReadLine();
                }
            }
        }
        File.Replace(tempFile, input, "backup.txt");
        //Delete back up file
        File.Delete("backup.txt");
    }

    static string GenerateLargeFile()
    {
        string fileName = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\07.ReplaceSubString\InputFile.txt";
        Random generator = new Random();

        StreamWriter writer = new StreamWriter(fileName, true);

        using (writer)
        {
            string[] words = { "start", "starter", "starting", "start-up", "start again", "bystart", "stop"};
            long fileSize = 0;
            long max = 1000;

            while (fileSize < max)
            {
                string word = "";

                for (int i = 0; i < 6; i++)
                {
                    word += words[generator.Next(words.Length)] + " ";
                }
                writer.WriteLine(word);
                FileInfo file = new FileInfo(fileName);
                fileSize = file.Length;
            }
        }

        return fileName;
    }
}
