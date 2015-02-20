using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneTaskIsNotEnough
{
    class OneTaskIsNotEnough
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int finalLamp = GetFinalLamp(n);

            string commandsOne = Console.ReadLine();
            string commands = Console.ReadLine();
            Console.WriteLine(finalLamp);
            Task(commandsOne);
            Task(commands);
        }

        static void Task(string commands)
        {
            int[] dx = { 1, 0, -1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            int x = 0;
            int y = 0;
            int orientation = 0;

            for (int i = 0; i < 4; i++)
            {
                foreach (var command in commands)
                {
                    if (command == 'S')
                    {
                        x += dx[orientation];
                        y += dy[orientation];
                    }
                    else if (command == 'L')
                    {
                        orientation = -1;
                        orientation += 4;
                        orientation %= 4;
                    }
                    else if (command == 'R')
                    {
                        orientation += 1;
                        orientation %= 4;
                    }
                }
            }
            if (x == 0 && y ==0)
            {
                Console.WriteLine("bounded");
            }
            else
            {
                Console.WriteLine("unbounded");
            }
        }

        static int GetFinalLamp(int n)
        {
            bool[] lamps = new bool[n + 1];
            int step = 2;
            int finalLamp = 0;

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j += step)
                {
                    if (!lamps[j])
                    {
                        finalLamp = j;
                    }
                    lamps[j] = true;
                }
                step++;
            }
            return finalLamp;
        }
    }
}
