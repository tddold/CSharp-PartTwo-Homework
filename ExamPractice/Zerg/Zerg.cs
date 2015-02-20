namespace Zerg
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ZergProblem
    {
        static int ConvertZergDigitToInt(string currentDigit)
        {
            switch (currentDigit)
            {
                case "Rawr": return 0; 
                case "Rrrr": return 1; 
                case "Hsst": return 2; 
                case "Ssst": return 3; 
                case "Grrr": return 4; 
                case "Rarr": return 5; 
                case "Mrrr": return 6; 
                case "Psst": return 7; 
                case "Uaah": return 8; 
                case "Uaha": return 9; 
                case "Zzzz": return 10;
                case "Bauu": return 11;
                case "Djav": return 12;
                case "Myau": return 13;
                case "Gruh": return 14;
                default: throw new ArgumentException();
            }
        }

        static long PowerOfFifteen(int power)
        {
            long result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= 15;
            }
            return result;
        }

        static void Main()
        {
            string zergMessage = Console.ReadLine();
            int position = (zergMessage.Length / 4) - 1;
            long result = 0;

            for (int i = 0; i < zergMessage.Length; i += 4)
            {
                string currentDigit = zergMessage.Substring(i, 4);
                result += ConvertZergDigitToInt(currentDigit) * PowerOfFifteen(position);

                position--;
            }
            Console.WriteLine(result);
        }
    }
}


