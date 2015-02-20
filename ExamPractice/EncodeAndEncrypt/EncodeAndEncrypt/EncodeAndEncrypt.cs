using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodeAndEncrypt
{
    class EncodeAndEncrypt
    {
        static void Main()
        {
            string message = Console.ReadLine();
            string cypher = Console.ReadLine();

            string encryptedMessage = Encrypt(message, cypher);

            string messageToEncode = encryptedMessage + cypher;

            //Console.WriteLine(messageToEncode);

            string encodedMessage = Encode(messageToEncode);

            Console.WriteLine(encodedMessage + cypher.Length);

        }

        private static string Encode(string messageToEncode)
        {
            StringBuilder result = new StringBuilder();

            char previous = messageToEncode[0];
            int count = 1;

            for (int i = 1; i < messageToEncode.Length; i++)
            {
                if (previous == messageToEncode[i])
                {
                    count++;
                }
                else
                {
                    if (count == 1)
                    {
                        result.Append(previous);
                    }
                    else if (count == 2)
                    {
                        result.Append(previous, count);;
                    }    
                    else
                    {
                        result.Append(count);
                        result.Append(previous);
                    }
                    count = 1;
                }
                previous = messageToEncode[i];
            }

            if (count == 1)
            {
                result.Append(previous);
            }
            else if (count == 2)
            {
                result.Append(previous, count); ;
            }
            else
            {
                result.Append(count);
                result.Append(previous);
            }

            return result.ToString();
        }

        private static string Encrypt(string message, string cypher)
        {
            StringBuilder result = new StringBuilder(message);

            int maxLength = Math.Max(message.Length, cypher.Length);

            for (int step = 0; step < maxLength; step++)
            {
                int messageIndex = step % message.Length;
                int cypherIndex = step % cypher.Length;

                result[messageIndex] = (char)(((result[messageIndex] - 'A') ^ (cypher[cypherIndex] - 'A')) + 'A');
            }

            return result.ToString();
        }
    }
}
