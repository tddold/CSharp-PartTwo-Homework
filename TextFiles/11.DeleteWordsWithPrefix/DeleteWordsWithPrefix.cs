//Write a program that deletes from a text file all words that start with the prefix test.
//Words contain only the symbols 0…9, a…z, A…Z, _.

using System;
using System.IO;
class DeleteWordsWithPrefix
{
    static void Main()
    {
        //string[] words = {  "test23AA???ing", "test645FSAEup", "wake", "gener123ate", "over", "more", "test_9???", "test?<>::load", "ptest992lity" };

        //foreach (var word in words)
        //{
        //    Console.WriteLine(word.Contains("test"));
        //}

        string input = GenerateFile();
        string temp = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\11.DeleteWordsWithPrefix\temp.txt";
        string prefix = "test";

        using (StreamReader read = new StreamReader(input))
        {
            using (StreamWriter write = new StreamWriter(temp))
            {
                string line = read.ReadLine();

                while (line != null)
                {
                    string[] splitLine = line.Split(' ');

                    foreach (var word in splitLine)
                    {
                        if (!(word.Contains(prefix) && word.IndexOf("test") == 0))
                        {
                            write.Write(word + " ");
                        }
                    }
                    write.WriteLine();
                    line = read.ReadLine();
                }
            }
        }

        File.Replace(temp, input, "backup.txt");
        File.Delete(temp);
        File.Delete("backup.txt");
    }

    static string GenerateFile()
    {
        string input = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\11.DeleteWordsWithPrefix\Input.txt";
        Random generator = new Random();
        using (StreamWriter write = new StreamWriter(input,true))
        {
            string[] words = { "test", "test23AA???ing", "test645FSAEup", "wake", "gener123ate", "over", "more", "test_9???", "test?<>::load", "ptest992lity" };
            long fileSize = 0;
            long maxSize = 20;
            while (fileSize < maxSize)
            {
                string word = "";
                for (int i = 0; i < 7; i++)
                {
                    word += words[generator.Next(words.Length)] + " ";
                }
                write.WriteLine(word);
                FileInfo file = new FileInfo(input);
                fileSize = file.Length;
            }
        }
        return input;
    }
}