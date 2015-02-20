using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Guitar
{
    static void Main()
    {
        string[] songsString = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int[] songs = new int[songsString.Length];
        for (int i = 0; i < songs.Length; i++)
        {
            songs[i] = int.Parse(songsString[i]);
        }

        int start = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());

        int[,] clever = new int[songs.Length + 1, max + 1];

        clever[0, start] = 1;

        for (int i = 1; i < clever.GetLength(0); i++)
        {
            var interval = songs[i - 1];

            for (int j = 0; j < clever.GetLength(1); j++)
            {
                if (clever[i - 1,j] == 1)
                {
                    if (j - interval >= 0)
                    {
                        clever[i, j - interval] = 1;
                    }

                    if (j + interval <= max)
                    {
                        clever[i, j + interval] = 1;
                    }
                }
            }
        }

        for (int i = max; i >=0; i--)
        {
            if (clever[songs.Length, i] == 1)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}
