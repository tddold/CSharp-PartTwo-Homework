//Write a program that reads a text file containing a square matrix of numbers.
//Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
//The first line in the input file contains the size of matrix N.
//Each of the next N lines contain N numbers separated by space.
//The output should be a single number in a separate text file.


using System;
using System.IO;
class MaximalAreaSum
{
    static void Main()
    {
        string fileName = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\05.MaximalAreaSum\matrix.txt";

        string result = @"C:\Users\mhlv\Desktop\New folder\CSharp_2015\C# part2\new\TextFiles\05.MaximalAreaSum\result.txt";

        StreamWriter writer = new StreamWriter(result,true);

        using (writer)
        {
            int[,] matrix = GetMatrix(fileName);

            writer.WriteLine(GetMax(matrix));
        }
    }

    static int[,] GetMatrix(string fileName)
    {
        using (StreamReader input = new StreamReader(fileName))
        {
            int n = int.Parse(input.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                string[] numbers = input.ReadLine().Split(' ');

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = int.Parse(numbers[col]);    
                }
            }

            return matrix;
        }
    }

    static int GetMax(int[,] matrix)
    {
        int sum = int.MinValue;

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLongLength(1) - 1; col++)
            {
                int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                if (currentSum > sum)
                {
                    sum = currentSum;
                }
            }
        }

        return sum;
    }
}
