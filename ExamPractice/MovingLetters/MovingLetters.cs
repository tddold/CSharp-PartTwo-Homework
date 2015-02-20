namespace MovingLetters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MovingLettersTask
    {
        static StringBuilder ExtractLetters(string[] words)
        {
            StringBuilder result = new StringBuilder();

            int maxLength = words.Max(x => x.Length);

            for (int i = 0; i < maxLength; i++)
            {
                foreach (var word in words)
                {
                    if (word.Length > i)
                    {
                        result.Append(word[word.Length - i - 1]);
                    }
                }
            }
            return result;
        }

        static string MoveLetters(StringBuilder strangePieceOfWords)
        {
            for (int i = 0; i < strangePieceOfWords.Length; i++)
            {
                char currentSymbol = strangePieceOfWords[i];
                int transition = char.ToLower(currentSymbol) - 'a' + 1;

                int nextPosition = (i + transition) % (strangePieceOfWords.Length);
                strangePieceOfWords.Remove(i, 1);
                strangePieceOfWords.Insert(nextPosition, currentSymbol);

            }

            return strangePieceOfWords.ToString();
        }

        static void Main()
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

            StringBuilder strangeCombinationOfLetters = ExtractLetters(words);

            string finalResult = MoveLetters(strangeCombinationOfLetters);

            Console.WriteLine(finalResult);
        }
    }
}
