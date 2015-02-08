//Write a program that removes from a text file all words listed in given another text file.
//Handle all possible exceptions in your methods.

using System;
using System.IO;
using System.Collections.Generic;
using System.Security;
class RemoveWords
{
    static string[] words = { "happy", "cool", "hot", "warm", "tea", "vase", "more", "best", "honey", "rain", "cliff", "box" };
    static void Main()
    {
        try
        {
            string input = GenerateFile();
            string output = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\12.RemoveWords\output.txt";
            string wordsFile = GenerateWords();

            StreamReader readWordsFile = new StreamReader(wordsFile);

            List<string> words = new List<string>();

            using (readWordsFile)
            {
                words = new List<string>(readWordsFile.ReadToEnd().Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
            }

            using (StreamReader read = new StreamReader(input))
            {
                using (StreamWriter write = new StreamWriter(output))
                {
                    string line = read.ReadLine();

                    while (line != null)
                    {
                        string[] splitLine = line.Split(' ');

                        for (int i = 0; i < splitLine.Length; i++)
                        {
                            bool theSame = false;
                            for (int j = 0; j < words.Count; j++)
                            {
                                if (words[j] == splitLine[i])
                                {
                                    theSame = true;
                                    break;
                                }
                            }
                            if (!theSame)
                            {
                                write.Write(splitLine[i] + " ");
                            }
                        }
                        write.WriteLine();
                        line = read.ReadLine();
                    }
                }
            }
        }
        catch (IndexOutOfRangeException exc)   // When generating words
        {
            Console.WriteLine(exc.Message);
        }
        catch (ArgumentException exc)   // When generating files
        {
            Console.WriteLine(exc.Message);
        }
        catch (FileNotFoundException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (DirectoryNotFoundException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (IOException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (SecurityException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch (UnauthorizedAccessException exc)
        {
            Console.WriteLine(exc.Message);
        }


    }

    static string GenerateFile()
    {
        string input = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\12.RemoveWords\Input.txt";
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
        string input = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\12.RemoveWords\Words.txt";
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
