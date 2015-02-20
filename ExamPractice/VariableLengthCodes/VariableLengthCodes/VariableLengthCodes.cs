using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableLengthCodes
{
    class VariableLengthCodes
    {
        static void Main()
        {
            //new KeyValuePair<char, string>(key, value)
            string[] firstLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string encodedText = "";

            for (int i = 0; i < firstLine.Length; i++)
            {
                encodedText += Convert.ToString(int.Parse(firstLine[i]), 2).PadLeft(8, '0');
            }

            string[] encodedTextAsArray = encodedText.Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries);

            int lines = int.Parse(Console.ReadLine());

            var keyPairValue = new List<KeyValuePair<char, string>>();

            for (int i = 0; i < lines; i++)
            {
                string pair = Console.ReadLine();

                var digits = new List<int>();

                for (int j = pair.Length - 1; j >= 0; j--)
                {
                    if (!char.IsDigit(pair[j]))
                    {
                        break;
                    }

                    digits.Add(int.Parse(pair[j].ToString()));
                }

                digits.Reverse();
                int numberCode = 0;

                for (int j = 0; j < digits.Count; j++)
                {
                    numberCode = numberCode * 10 + digits[j];
                }

                keyPairValue.Add(new KeyValuePair<char, string>(pair[0], new string('1', numberCode)));
            }

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < encodedTextAsArray.Length; i++)
            {
                foreach (var pair in keyPairValue)
                {
                    if (pair.Value == encodedTextAsArray[i])
                    {
                        result.Append(pair.Key);
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
