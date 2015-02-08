//Modify the solution of the previous problem to replace only whole words (not strings).

using System;
using System.IO;
class ReplaceWholeWord
{
    static void Main()
    {
        string input = GenerateLargeFile();
        string tempFile = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\08.ReplaceWholeWord\TempFile.txt";
        string search = "start";
        string replace = "finish";

        using (StreamReader read = new StreamReader(input))
        {
            using (StreamWriter write = new StreamWriter(tempFile, true))
            {
                string line = read.ReadLine();
                while (line != null)
                {
                    string[] splittedLine = line.Split(' ');

                    for (int i = 0; i < splittedLine.Length; i++)
                    {
                        if (splittedLine[i] == search)
                        {
                            write.Write(replace);
                            if (i != splittedLine.Length - 1)
                            {
                                write.Write(" ");
                            }
                            
                        }
                        else
                        {
                            write.Write(splittedLine[i]);
                            if (i != splittedLine.Length - 1)
                            {
                                write.Write(" ");
                            }
                        }
                    }
                    write.WriteLine();
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
        string fileName = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\08.ReplaceWholeWord\InputFile.txt";
        Random generator = new Random();

        StreamWriter writer = new StreamWriter(fileName, true);

        using (writer)
        {
            string[] words = { "start", "starter", "starting", "start-up", "start-again", "bystart", "stop" };
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
