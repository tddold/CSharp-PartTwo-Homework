using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDoge
{
    class HelpDoge
    {
        static string[] size = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        static char[,] grid = new char[int.Parse(size[0]), int.Parse(size[1])];

        static void Main()
        {
            string[] boneCoordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            grid[int.Parse(boneCoordinates[0]), int.Parse(boneCoordinates[1])] = 'b';

            int numberOfEnemies = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEnemies; i++)
            {
                string[] enemieCoord = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                grid[int.Parse(enemieCoord[0]), int.Parse(enemieCoord[1])] = '*';
            }

            //FindBone(0, 0);

            //Console.WriteLine(countAllWays);
        }



        //static int countAllWays = 0;
        //static bool InRange(int row, int col)
        //{
        //    bool rowInRange = row >= 0 && row < grid.GetLength(0);
        //    bool colInRange = col >= 0 && col < grid.GetLength(1);
        //    return rowInRange && colInRange;
        //}

        //static void FindBone(int row,int col)
        //{
        //    if (!InRange(row,col))
        //    {
        //        return;
        //    }

        //    if (grid[row,col] == 'b')
        //    {
        //        countAllWays++;
        //    }

        //    if (grid[row,col] != '\0')
        //    {
        //        return;
        //    }

        //    // Temporary mark the current cell as visited to avoid cycles
        //    grid[row, col] = 's';
        //    FindBone(row, col + 1); //right
        //    FindBone(row + 1, col); // down
        //    grid[row, col] = '\0';
        //}
    }
}
