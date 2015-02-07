//Write a program that extracts from a given text all sentences containing given word.

using System;
class ExtractSentences
{
    static void Main()
    {
        string text = "We are living in an yellow submarine." +
            " We don't have anything else." +
            " Inside the submarine is very tight." +
            " So we are drinking all the day." +
            " We will move out of it in 5 days.";

        string keyWord = "in";

        string[] splitted = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var sent in splitted)
        {
            //I came up with a easier way to solve it, but the other comment solution works too.

            string[] words = sent.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (keyWord == words[i])
                {
                    Console.WriteLine(sent.Trim() + ".");
                }
            }


            //int index = sent.IndexOf(keyWord);

            //while (index >= 0)
            //{
            //    //Here I check if the word is in the begging, end or middle of the sentence.
            //    if ((sent[index - 1] == ' ' && sent[index + keyWord.Length] == ' ')
            //        || (index == 0 && sent[index + keyWord.Length] == ' ')
            //        || (sent[index - 1] == ' ' && (index + keyWord.Length) == sent.Length))
            //    {
            //        Console.WriteLine(sent.Trim() + ".");
            //    }
            //    index++;
            //    index = sent.IndexOf(keyWord, index);
            //}
        }
    }
}
