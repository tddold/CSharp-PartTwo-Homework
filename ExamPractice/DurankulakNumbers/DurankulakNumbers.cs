using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class DurankulakNumbers
{
    static string[] GetDurankulakDigits()
    {
        string[] durankulakDigits = new string[168];
        int index = 0;

        for (char i = 'A'; i <= 'Z' ; i++)
        {
            durankulakDigits[index] = i.ToString();
            index++;
        }

        for (char i = 'a'; i <= 'f'; i++)
        {
            char lastChar = i;
            if (lastChar == 'f')
            {
                for (char j = 'A'; j <= 'L' ; j++)
                {
                    durankulakDigits[index] = i.ToString() + j.ToString();
                    index++;
                }
            }
            else
            {
                for (char j = 'A'; j <= 'Z'; j++)
                {
                    durankulakDigits[index] = i.ToString() + j.ToString();
                    index++;
                }
            }
        }

        return durankulakDigits;
    }

    static BigInteger Power(int power)
    {
        BigInteger result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= 168;
        }
        return result;
    }

    static void Main()
    {
        string[] durankulakDigits = GetDurankulakDigits();

        string input = Console.ReadLine();
        string partialInput = string.Empty;
        List<string> output = new List<string>();

        for (int i = 0; i < input.Length; i++)
        {
            partialInput += input[i];

            for (int j = 0; j < durankulakDigits.Length; j++)
            {
                if (partialInput == durankulakDigits[j])
                {
                    output.Add(j.ToString());
                    partialInput = "";
                }
            }
        }
        BigInteger result = 0;

        for (int i = 0; i < output.Count; i++)
        {
            result += BigInteger.Parse(output[i]) * Power(output.Count - i - 1);
        }
        Console.WriteLine(result);
    }
}