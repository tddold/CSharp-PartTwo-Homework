//Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe.

using System;
using System.Collections.Generic;
using System.Text;

class Palindromes
{
    static void Main()
    {
        string text = "Nice blue sky. No exe flying in the sky." +
            " ABBA will not come in Bulgaria. I don`t know what is lamal," +
            " maybe I will find some day a mouseesuom.";

        string[] splitted = text.Split(new char[] { ',', ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in splitted)
        {
            bool isPalindrome = true;

            for (int i = 0; i < word.Length / 2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome && word.Length > 1)
            {
                Console.WriteLine(word);
            }
        }
    }
}
