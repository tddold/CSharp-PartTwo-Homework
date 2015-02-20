using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class ThreeInOne
{
    static void Main()
    {
        TaskOne();
        TaskTwo();
        TaskThree();
    }

    static void TaskOne()
    {
        int[] scores = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToArray();

        int? winner = null;
        for (int i = 0; i < scores.Length; i++)
        {
            int currentScore = scores[i];
            if (currentScore <= 21)
            {
                if (winner == null || currentScore > scores[winner.Value])
                {
                    winner = i;
                }
            }
        }
        if (winner == null)
        {
            Console.WriteLine(-1);
        }
        else
        {
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] == scores[winner.Value] && i != winner.Value)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
            Console.WriteLine(winner.Value);
        }
    }

    static void TaskTwo()
    {
        int[] bites = Console.ReadLine().Split(',').Select(s => int.Parse(s)).ToArray();
        Array.Sort(bites);
        Array.Reverse(bites);
        int friends = int.Parse(Console.ReadLine());
        int all = friends + 1;
        int[] numberOfbitesPerPerson = new int[all];
        int count = 0;

        // int myBites = 0;
        //for (int i = 0; i < bites.Length; i = (i + friends + 1))
        //{
        //    myBites += bites[i];
        //}

        for (int i = 0; i < bites.Length; i++)
        {
            numberOfbitesPerPerson[count] += bites[i];

            if (count != all - 1)
            {
                count++;
            }
            else
            {
                count = 0;
            }
        }
        Console.WriteLine(numberOfbitesPerPerson[0]);
    }

    static void TaskThree()
    {
        var number = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
        int[] current = number.Take(3).ToArray();
        int[] target = number.Skip(3).Take(3).ToArray();
        const int GOLD = 0;
        const int SILVER = 1;
        const int BRONZE = 2;

        int operations = 0;
        while (true)
        {
            if (current[GOLD] >= target[GOLD] &&
                current[SILVER] >= target[SILVER] &&
                current[BRONZE] >= target[BRONZE])
            {
                Console.WriteLine(operations);
                return;
            }
            while (current[SILVER] > target[SILVER])
            {
                if (current[GOLD] < target[GOLD])
                {
                    if (current[SILVER] - target[SILVER] >= 11)
                    {
                        current[SILVER] -= 11;
                        current[GOLD] += 1;
                        operations++;
                    }
                    else if (current[BRONZE] - target[BRONZE] >= 11)
                    {
                        current[BRONZE] -= 11;
                        current[SILVER] += 1;
                        operations++;
                    }
                    else
                    {
                        Console.WriteLine(-1);
                        return;
                    }
                }
                else if (current[BRONZE] < target[BRONZE])
                {
                    current[BRONZE] += 9;
                    current[SILVER] -= 1;
                    operations++;
                }
                else
                {
                    Console.WriteLine(operations);
                    return;
                }
            }

            while (current[SILVER] < target[SILVER])
            {
                if (current[GOLD] > target[GOLD])
                {
                    current[SILVER] += 9;
                    current[GOLD] -= 1;
                    operations++;
                }
                else if (current[BRONZE] - target[BRONZE] >= 11)
                {
                    current[BRONZE] -= 11;
                    current[SILVER] += 1;
                    operations++;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            if (current[GOLD] < target[GOLD])
            {
                if (current[BRONZE] - target[BRONZE] >= 11)
                {
                    current[BRONZE] -= 11;
                    current[SILVER] += 1;
                    operations++;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            if (current[BRONZE] < target[BRONZE])
            {
                if (current[GOLD] > target[GOLD])
                {
                    current[SILVER] += 9;
                    current[GOLD] -= 1;
                    operations++;
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
        }
    }

}