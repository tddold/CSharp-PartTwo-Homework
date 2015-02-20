using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Patterns
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col].ToString());
                }
            }

            long bestSum = long.MinValue;
            bool foundSolution = false;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (CheckIfIsASolutions(matrix, row, col))
                    {
                        foundSolution = true;
                        long currentSum = FindCurrentSum(matrix, row, col);

                        if (currentSum > bestSum)
                        {
                            bestSum = currentSum;
                        }
                    }
                }
            }

            if (foundSolution)
            {
                Console.WriteLine("YES {0}", bestSum);
            }
            else
            {
                long diagonal = 0;
                for (int i = 0; i < size; i++)
                {
                    diagonal += matrix[i, i];
                }

                Console.WriteLine("No {0}", diagonal);
            }
        }

        private static long FindCurrentSum(int[,] matrix, int row, int col)
        {
            long sum = matrix[row, col] +
                       matrix[row, col + 1] +
                       matrix[row, col + 2] +
                       matrix[row + 1, col + 2] +
                       matrix[row + 2, col + 2] +
                       matrix[row + 2, col + 3] +
                       matrix[row + 2, col + 4];


            return sum;
        }

        private static bool CheckIfIsASolutions(int[,] matrix, int row, int col)
        {
            if (row + 2 >= matrix.GetLength(0) || col + 4 >= matrix.GetLength(1))
            {
                return false;
            }

            bool result = matrix[row, col] == (matrix[row, col + 1] - 1) &&
                          matrix[row, col + 1] == (matrix[row, col + 2] - 1) &&
                          matrix[row, col + 2] == (matrix[row + 1, col + 2] - 1) &&
                          matrix[row + 1, col + 2] == (matrix[row + 2, col + 2] - 1) &&
                          matrix[row + 2, col + 2] == (matrix[row + 2, col + 3] - 1) &&
                          matrix[row + 2, col + 3] == (matrix[row + 2, col + 4] - 1);


            return result;
        }
    }
}
