using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace BunnyFactory
{
    class BunnyFactory
    {
        static void Main()
        {
            var bunniesPerCage = new List<ulong>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                bunniesPerCage.Add(ulong.Parse(input));

                input = Console.ReadLine();
            }

            int cages = bunniesPerCage.Count;

            BigInteger sum = 0;
            BigInteger product = 1;
            int howManyCagesToTake = 1;

            while (true)
            {
                ulong takenCages = 0;

                if (howManyCagesToTake > bunniesPerCage.Count)
                {
                    break;
                }

                for (int i = 0; i < howManyCagesToTake; i++)
                {
                    takenCages += bunniesPerCage[i];
                }

                if ((int)takenCages > bunniesPerCage.Count - howManyCagesToTake)
                {
                    break;
                }

                for (int i = howManyCagesToTake; i < (int)takenCages + howManyCagesToTake; i++)
                {
                    sum += bunniesPerCage[i];
                    product *= bunniesPerCage[i];
                }

                string newBunniesPerCage = sum.ToString() + product;

                for (int i = (int)takenCages + howManyCagesToTake; i < bunniesPerCage.Count; i++)
                {
                    newBunniesPerCage += bunniesPerCage[i];
                }

                bunniesPerCage = new List<ulong>();

                for (int i = 0; i < newBunniesPerCage.Length; i++)
                {
                    if (newBunniesPerCage[i] == '1' || newBunniesPerCage[i] == '0')
                    {
                        continue;
                    }

                    bunniesPerCage.Add(ulong.Parse(newBunniesPerCage[i].ToString()));
                }

                howManyCagesToTake++;
                sum = 0;
                product = 1;
            }

			// Console.WriteLine(string.Join(" ",bunniesPerCage));
            for (int i = 0; i < bunniesPerCage.Count; i++)
            {
                if (i == bunniesPerCage.Count - 1)
                {
                    Console.Write(bunniesPerCage[i]);
                }
                else
                {
                    Console.Write(bunniesPerCage[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
