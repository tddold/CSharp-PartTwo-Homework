using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeAndDecrypt
{
    class DecodeAndDecrypt
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var digits = new List<int>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(input[i]))
                {
                    digits.Add(input[i] - '0');
                }
                else
                {
                    break;
                }
            }

            digits.Reverse();

            int lengthOfCypher = 0;

            for (int i = 0; i < digits.Count; i++)
            {
                lengthOfCypher = lengthOfCypher * 10 + digits[i];
            }

            //Console.WriteLine(lengthOfCypher);
            var encodedMessage = input.Substring(0, input.Length - digits.Count);

            var decodedMessage = Decode(encodedMessage);
            //Console.WriteLine(decodedMessage);

            var cypher = decodedMessage.Substring(decodedMessage.Length - lengthOfCypher,lengthOfCypher);
            //Console.WriteLine(cypher);

            var encryptedMessage = decodedMessage.Substring(0, decodedMessage.Length - lengthOfCypher);
            //Console.WriteLine(encryptedMessage);

            var decryptedMessage = Decrypt(encryptedMessage, cypher);


            Console.WriteLine(decryptedMessage);

        }

        private static string Decode(string encodedMessage)
        {
            StringBuilder result = new StringBuilder();

            int count = 0;

            foreach (var symbol in encodedMessage)
            {
                if (char.IsDigit(symbol))
                {
                    count *= 10;
                    count = count + (symbol - '0');
                }
                else
                {
                    if (count > 0)
                    {
                        result.Append(symbol,count);
                        count = 0;
                    }
                    else
                    {
                        result.Append(symbol);
                    }
                }
            }

            return result.ToString();
        }

        static string Decrypt(string encryptedMessage, string cypher)
        {
            var steps = Math.Max(encryptedMessage.Length, cypher.Length);
            var result = new StringBuilder(encryptedMessage);

            for (int step = 0; step < steps; step++)
            {
                var messageIndex = step % encryptedMessage.Length;
                var cypherIndex = step % cypher.Length;

                result[messageIndex] = (char)(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
            }

            return result.ToString();
        }
    }
}
