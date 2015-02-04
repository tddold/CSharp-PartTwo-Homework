//Write a program that fills and prints a matrix of size (n, n) as shown below:

using System;

class FillTheMatrix
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        Console.WriteLine("Printing matrix a):\n ");

        int count = 1;

        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = count;
                count++;
            }
        }

        PrintingMatrix(n, matrix);

        Console.WriteLine("\nPrinting matrix b):\n ");

        count = 1;

        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }
        }

        PrintingMatrix(n, matrix);

        Console.WriteLine("\nPrinting matrix c):\n ");

        count = 1;
        int r = n - 1;
        int c = 0;

        for (int i = 0; i < n * n; i++)
        {
            matrix[r, c] = count;
            r++;
            c++;
            count++;

            if (r == n || c == n)
            {
                r--;
                if (c == n)
                {
                    r--;
                    c--;
                }
                while (r - 1 >= 0 && c - 1 >= 0)
                {
                    r--;
                    c--;
                }
            }
        }

        PrintingMatrix(n, matrix);

        Console.WriteLine("\nPrinting matrix d):\n ");

        r = 0;
        c = 0;
        int maxRow = n - 1;
        int maxCol = n - 1;
        count = 1;

        do
        {
            for (int i = r; i <= maxRow; i++)
            {
                matrix[i, c] = count;
                count++;
            }
            c++;

            for (int i = c; i <= maxCol; i++)
            {
                matrix[maxRow, i] = count;
                count++;
            }
            maxRow--;

            for (int i = maxRow; i >= r; i--)
            {
                matrix[i, maxCol] = count;
                count++;
            }
            maxCol--;

            for (int i = maxCol; i >= c; i--)
            {
                matrix[r, i] = count;
                count++;
            }
            r++;

        } while (count <= n*n);

        PrintingMatrix(n, matrix);
    }

    static void PrintingMatrix(int n, int[,] matrix)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}