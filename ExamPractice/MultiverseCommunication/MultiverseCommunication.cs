using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class MultiverseCommunication
{
    static int Multiverse(string toChange)
    {
        int numberToChange = -1;
        switch (toChange)
        {
            case "CHU": numberToChange = 0; break;
            case "TEL": numberToChange = 1; break;
            case "OFT": numberToChange = 2; break;
            case "IVA": numberToChange = 3; break;
            case "EMY": numberToChange = 4; break;
            case "VNB": numberToChange = 5; break;
            case "POQ": numberToChange = 6; break;
            case "ERI": numberToChange = 7; break;
            case "CAD": numberToChange = 8; break;
            case "K-A": numberToChange = 9; break;
            case "IIA": numberToChange = 10; break;
            case "YLO": numberToChange = 11; break;
            case "PLA": numberToChange = 12; break;
        }
        return numberToChange;
    }

    static long Power(int times)
    {
        long power = 1;
        for (int i = 0; i < times; i++)
        {
            power *= 13;
        }
        return power;
    }
    static void Main()
    {
        string input = Console.ReadLine();
        List<int> toConvert = new List<int>();
        StringBuilder multi = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            multi.Append(input[i]);
            int number = Multiverse(multi.ToString());
            if (number != -1)
            {
                toConvert.Add(number);
                multi.Clear();
            }
        }

        long result = 0;

        for (int i = 0; i < toConvert.Count; i++)
        {
            result += toConvert[i] * Power(toConvert.Count - 1 - i);
        }
        Console.WriteLine(result);
    }
}
