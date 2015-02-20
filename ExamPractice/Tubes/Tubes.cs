namespace Fighters
{
    using System;
    public class Tubes
    {
        public static void Main()
        {
            int tubes = int.Parse(Console.ReadLine()); //initial tubes

            int friends = int.Parse(Console.ReadLine()); //fightrers

            long[] tubesSizes = new long[tubes];

            long maxTube = 0;

            for (int i = 0; i < tubes; i++)
            {
                tubesSizes[i] = long.Parse(Console.ReadLine());

                if (maxTube < tubesSizes[i])
                {
                    maxTube = tubesSizes[i];
                }
            }

            long left = 1;
            long right = maxTube;
            long middle = (left + right) / 2;

            long finalResult = -1;

            while (left <= right)
            {
                long eventrual = 0;

                for (int j = 0; j < tubesSizes.Length; j++)
                {
                    eventrual += tubesSizes[j] / middle;
                }

                if (eventrual < friends)
                {
                    right = middle - 1;
                    middle = (left + right) / 2;
                }
                else if (eventrual >= friends)
                {
                    finalResult = middle;
                    left = middle + 1;
                    middle = (left + right) / 2;
                }
            }
            Console.WriteLine(finalResult);

            //TO SLOW!!!! 25/100
            //for (long i = maxTube; i >= 1 ; i--)
            //{
            //    long eventual = 0;

            //    for (int j = 0; j < tubesSizes.Length; j++)
            //    {
            //        eventual += tubesSizes[j] / i;   
            //    }

            //    if (eventual >= friends)
            //    {
            //        Console.WriteLine(i);
            //        break;
            //    }
            //}
        }
    }
}
