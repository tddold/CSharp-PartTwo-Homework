using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GenomeDecoder
{
    static void Main()
    {
        string inputFormat = Console.ReadLine();
        string[] splitInput = inputFormat.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int lettersPerLine = int.Parse(splitInput[0]);
        int lettersPerSubsequence = int.Parse(splitInput[1]);

        string encodedGenome = Console.ReadLine();
        StringBuilder decodedGenome = DecodedGenome(encodedGenome);

        PrintFormattedOutput(decodedGenome, lettersPerLine, lettersPerSubsequence);

    }

    static void PrintFormattedOutput(StringBuilder decodedGenome, int lettersPerLine, int lettersPerSubsequence)
    {
        int outputLines = (int)Math.Ceiling((double)decodedGenome.Length / (double)lettersPerLine);

        int maxLineNumberDigits = outputLines.ToString().Length;
        StringBuilder currentFormattedLine = new StringBuilder();
        int currentIndexInDecodedGenom = 0;

        for (int line = 1; line <= outputLines; line++)
        {
            string leadingIntervals = new string(' ',maxLineNumberDigits - line.ToString().Length);
            currentFormattedLine.Append(leadingIntervals);
            currentFormattedLine.Append(line);

            currentIndexInDecodedGenom = (line - 1) * lettersPerLine;
            for (int i = currentIndexInDecodedGenom; i < line*lettersPerLine; i++)
            {
                if ((currentIndexInDecodedGenom - i) % lettersPerSubsequence == 0)
                {
                    currentFormattedLine.Append(' ');
                }
                if ( i >= decodedGenome.Length)
                {
                    break;
                }
                currentFormattedLine.Append(decodedGenome[i]);
            }
            Console.WriteLine(currentFormattedLine);
            currentFormattedLine.Clear();
        }
        
    }

    static StringBuilder DecodedGenome(string encodedGenome)
    {
        StringBuilder decodedGenome = new StringBuilder();

        StringBuilder repeatTimesString = new StringBuilder();

        foreach (char symbol in encodedGenome)
        {
            if (symbol == 'A' || symbol == 'C' || symbol == 'G' || symbol == 'T')
            {
                int repeatTimes = 1;
                if (repeatTimesString.Length != 0)
                {
                    repeatTimes = int.Parse(repeatTimesString.ToString());
                    repeatTimesString.Clear();
                }
                string genomeSubsequence = new string(symbol, repeatTimes);
                decodedGenome.Append(genomeSubsequence);
            }
            else
            {
                repeatTimesString.Append(symbol);
            }
        }

        return decodedGenome;
    }
}