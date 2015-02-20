using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableLengthCodesVersionTwo
{
    class VariableLengthCodesVersionTwo
    {
        static void Main()
        {
            string encodedText = Console.ReadLine();

            string[] encodedStrings = encodedText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            byte[] encodedNumbers = new byte[encodedStrings.Length];

            for (int i = 0; i < encodedNumbers.Length; i++)
            {
                encodedNumbers[i] = byte.Parse(encodedStrings[i]);
            }

            StringBuilder binaryEncodedText = new StringBuilder();

            foreach (var number in encodedNumbers)
            {
                binaryEncodedText.Append(
                    Convert.ToString(number, 2).PadLeft(8, '0')
                    );
            }

            string[] encodedSymbols = binaryEncodedText.ToString().Split(new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries);

            //int codeTableSize = int.Parse(reader.ReadLine());
            int codeTableSize = int.Parse(Console.ReadLine());

            char[] symbolPerCodeLength = new char[codeTableSize + 1];

            for (int i = 0; i < codeTableSize; i++)
            {
                string currentPair = Console.ReadLine();

                char currentSymbol = currentPair[0];
                int codeLength = int.Parse(currentPair.Substring(1));

                symbolPerCodeLength[codeLength] = currentSymbol;
            }

            for (int i = 0; i < encodedSymbols.Length; i++)
            {
                var encodedSymbol = encodedSymbols[i];

                Console.Write(symbolPerCodeLength[encodedSymbol.Length]);
            }
        }
    }
}
