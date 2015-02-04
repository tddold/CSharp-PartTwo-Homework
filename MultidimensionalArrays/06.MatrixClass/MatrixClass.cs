using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MatrixClass
{
    public class Matrix
    {
        private int rows;
        private int cols;
        private int[,] matrix;

        public Matrix(int inputRows, int intputCols)
        {
            this.Rows = inputRows;
            this.Cols = intputCols;
            this.matrix = new int[rows, intputCols];
        }
        public int Rows
        {
            get { return this.rows; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Rows of the matrix cannot be less than 1");
                }
                this.rows = value;
            }
        }

        public int Cols
        {
            get { return this.cols; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Cols of the matrix cannot be less than 1");
                }
                this.cols = value;
            }
        }

        public int this[int row, int col]
        {
            get
            {
                ValidateIndecies(row, col);
                return this.matrix[row, col];
            }
            set
            {
                ValidateIndecies(row, col);
                this.matrix[row, col] = value;
            }
        }

        public void FillMatrix()
        {
            Console.WriteLine("Enter {0} lines with {1} numbers, separated by comma", this.Rows, this.Cols);

            for (int row = 0; row < this.Rows; row++)
            {
                Console.Write("Row {0}: ", row);
                int[] numbers = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();

                if (numbers.Length != this.Cols)
                {
                    throw new ArgumentOutOfRangeException("number of columns", "The entered numbers exceed the length of the column");
                }

                for (int col = 0; col < this.Cols; col++)
                {
                    this.matrix[row, col] = numbers[col];
                }
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new ArgumentException("Adding", "Matrices must have equal dimensions");
            }

            Matrix result = new Matrix(a.Rows, a.Cols);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    result[row, col] = a[row, col] + b[row, col];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols)
            {
                throw new ArgumentException("Substraction", "Matrices must have equal dimensions");
            }

            Matrix result = new Matrix(a.Rows, a.Cols);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Cols; col++)
                {
                    result[row, col] = a[row, col] - b[row, col];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Cols != b.Rows)
            {
                throw new ArgumentException("Matrices cannot be multiplied");
            }

            Matrix result = new Matrix(a.Rows, b.Cols);

            for (int row = 0; row < result.Rows; row++)
            {
                for (int col = 0; col < result.Cols; col++)
                {
                    int temp = 0;
                    for (int i = 0; i < result.Cols; i++)
                    {
                        temp += a[row, i] * b[i, col];
                    }
                    result[row, col] = temp;
                }
            }

            return result;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    output.AppendFormat("{0,4}", this.matrix[row, col]);
                }
                output.AppendLine();
            }

            return output.ToString();
        }

        private void ValidateIndecies(int row, int col)
        {
            if (row < 0 || row >= this.Rows)
            {
                throw new IndexOutOfRangeException("Provided row is out if boundaries");
            }

            if (col < 0 || col >= this.Cols)
            {
                throw new IndexOutOfRangeException("Provided col is out if boundaries");
            }
        }
    }
    class MatrixClass
    {
        static void Main()
        {
            Matrix first = new Matrix(2, 3);
            first.FillMatrix();
            Matrix second = new Matrix(3, 3);
            second.FillMatrix();

            Matrix multi = first * second;

            Console.WriteLine(multi);

            first = new Matrix(2, 2);
            first.FillMatrix();
            second = new Matrix(2, 2);
            second.FillMatrix();

            Matrix add = first + second;
            Matrix sub = first - second;

            Console.WriteLine(add);
            Console.WriteLine(sub);
        }
    }
}
