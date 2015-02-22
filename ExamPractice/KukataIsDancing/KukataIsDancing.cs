using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLecture
{
    class KukataIsDancing
    {
        static int kukataDirection = 3;
        static int kukataRow = 1;
        static int kukataCol = 1;
        // Directions
        // 0 -> right
        // 1 -> down
        // 2 -> left
        // 3 -> up
        // 4 -> 0 (%)
        // rotate right -> direction++;  // cw
        // rotate left -> direction--;  // ccw
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string danceMoves = Console.ReadLine();

                kukataRow = 1;
                kukataCol = 1;

                foreach (var move in danceMoves)
                {
                    if (move == 'L')
                    {
                        kukataDirection = RotateLeft(kukataDirection);
                    }
                    else if (move == 'R')
                    {
                        kukataDirection = RotateRight(kukataDirection);
                    }
                    else if (move == 'W' )
                    {
                        MoveKukata();
                    }
                }

                sb.Append(CheckKukataPosition());
                if (i != n-1)
                {
                    sb.AppendLine();
                }
            }

            Console.WriteLine(sb.ToString());
        }

        private static string CheckKukataPosition()
        {
            if ((kukataRow == 0 || kukataRow == 2) && (kukataCol == 0 || kukataCol == 2))
            {
                return "RED";
            }
            else if (kukataRow == 1 && kukataCol == 1)
            {
                return "GREEN";
            }
            else
            {
                return "BLUE";
            }
        }

        static void MoveKukata()
        {
            if (kukataDirection == 0)
            {
                kukataCol = (kukataCol + 1) % 3;
            }
            else if (kukataDirection == 1)
            {
                kukataRow = (kukataRow + 1) % 3;
                
            }
            else if (kukataDirection == 2)
            {
                kukataCol--;
                if (kukataCol == -1)
                {
                    kukataCol = 2;
                }
            }
            else if (kukataDirection == 3)
            {
                kukataRow--;
                if (kukataRow == -1)
                {
                    kukataRow = 2;
                }
            }
        }
        static int RotateLeft(int direction)
        {
            int newDirection = direction - 1;

            if (newDirection == -1)
            {
                newDirection = 3;
            }

            return newDirection;
        }

        static int RotateRight(int direction)
        {
            int newDirection = direction + 1;

            if (newDirection == 4)
            {
                newDirection = 0;
            }

            return newDirection;
        }
    }
}
