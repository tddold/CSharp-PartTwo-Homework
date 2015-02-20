using System;
using System.Numerics;

class GagNumbers
{
    static string ConvertGagSringToNumber(string digit)
    {
        string result = "NO";
        switch (digit)
        {
            case "-!": result = "0"; break;
            case "**": result = "1"; break;
            case "!!!": result = "2"; break;
            case "&&": result = "3"; break;
            case "&-": result = "4"; break;
            case "!-": result = "5"; break;
            case "*!!!": result = "6"; break;
            case "&*!": result = "7"; break;
            case "!!**!-": result = "8"; break;
        }
        return result;
    }

    static BigInteger Power(int i, int j)
    {
        BigInteger result = 1;
        for (int p = 0; p < j; p++)
        {
            result *= i;
        }
        return result;
    }

    static void Main()
    {
        string input = Console.ReadLine();

        string partialInput = string.Empty;
        string nineSystemNumber = "";

        for (int i = 0; i < input.Length; i++)
        {
            partialInput += input[i];

            string currentDigit = ConvertGagSringToNumber(partialInput);

            if (currentDigit != "NO")
            {
                nineSystemNumber += currentDigit;
                partialInput = string.Empty;
            }
        }

        //Console.WriteLine(nineSystemNumber);
        BigInteger decResult = 0;

        for (int i = 0; i < nineSystemNumber.Length; i++)
        {
            decResult += BigInteger.Parse(nineSystemNumber[i].ToString()) * Power(9, nineSystemNumber.Length - 1 - i);
        }
        Console.WriteLine(decResult);
    }
}