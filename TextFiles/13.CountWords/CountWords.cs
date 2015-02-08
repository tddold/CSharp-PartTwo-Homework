//Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file test.txt.
//The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order.
//Handle all possible exceptions in your methods.

using System;
using System.IO;
class CountWords
{
    static string[] words = { "happy", "cool", "hot", "warm", "tea", "vase", "more", "best", "honey", "rain", "cliff", "box" };
    static void Main()
    {
        string input = GenerateFile();
        string output = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\13.CountWords\result.txt";
        string words = GenerateWords();
        string[] search = File.ReadAllLines(words);
        int[] values = new int[search.Length];

        using (StreamReader read = new StreamReader(input))
        {
            using (StreamWriter write = new StreamWriter(output,true))
            {
                string line = read.ReadLine();

                while (line != null)
                {
                    string[] splittLine = line.Split(' ');

                    for (int i = 0; i < splittLine.Length; i++)
                    {
                        for (int j = 0; j < search.Length; j++)
                        {
                            if (splittLine[i] == search[j])
                            {
                                values[j]++;
                                break;
                            }
                        }
                    }
                    line = read.ReadLine();
                }

                for (int i = 0; i < search.Length; i++)
                {
                    write.WriteLine("{0} - {1} times", search[i], values[i]);
                }
            }
        }
    }

    static string GenerateFile()
    {
        string input = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\13.CountWords\test.txt";
        Random generator = new Random();
        using (StreamWriter write = new StreamWriter(input))
        {
            long fileSize = 0;
            long maxSize = 20;
            while (fileSize < maxSize)
            {
                string word = "";
                for (int i = 0; i < 10; i++)
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

    static string GenerateWords()
    {
        string input = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\13.CountWords\words.txt";
        Random generator = new Random();
        using (StreamWriter write = new StreamWriter(input))
        {
            for (int i = 0; i < 4; i++)
            {
                write.WriteLine(words[generator.Next(words.Length)]);
            }
        }
        return input;
    }
}