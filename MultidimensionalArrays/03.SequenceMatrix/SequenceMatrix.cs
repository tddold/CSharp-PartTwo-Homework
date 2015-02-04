//We are given a matrix of strings of size N x M. Sequences in the matrix we define 
//as sets of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.

using System;

class SequenceMatrix
{
    static void Main()
    {
        string[,] elements = 
        {
            {"ha", "fifi", "ho", "hi"},
            {"fo", "ha", "hi", "xx"},
            {"xxx", "ho", "ha", "xx"}
        };

        int currentSeq = 1;
        int bestSeq = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;
        string direction = "";

        //sequence left to right

        for (int row = 0; row < elements.GetLength(0); row++)
        {
            for (int col = 0; col < elements.GetLength(1) - 1; col++)
            {
                if (elements[row,col] == elements[row,col + 1])
                {
                    currentSeq++;
                }
                else
                {
                    currentSeq = 1;
                }

                if (currentSeq > bestSeq)
                {
                    bestRow = row;
                    bestCol = col + 1;
                    bestSeq = currentSeq;
                    direction = "horizontal";
                }
            }
            currentSeq = 1;
        }

        //sequence top to bottom

        for (int col = 0; col < elements.GetLength(1); col++)
        {
            for (int row = 0; row < elements.GetLength(0) - 1; row++)
            {
                if (elements[row,col] == elements[row +1,col])
                {
                    currentSeq++;
                }
                else
                {
                    currentSeq = 1;
                }

                if (currentSeq > bestSeq)
                {
                    bestRow = row;
                    bestCol = col + 1;
                    bestSeq = currentSeq;
                    direction = "down";
                }
            }
            currentSeq = 1;
        }

        //diagonal, top left to bottom right (TLBR)

        for (int i = 0; i < elements.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < elements.GetLength(1) - 1; j++)
            {
                for (int row = i, col = j; row < elements.GetLength(0) - 1 && col < elements.GetLength(1) - 1; row++, col++)
                {
                    if (elements[row, col] == elements[row + 1, col + 1])
                    {
                        currentSeq++;
                    }
                    else
                    {
                        currentSeq = 1;
                    }

                    if (currentSeq > bestSeq)
                    {
                        bestSeq = currentSeq;
                        bestRow = row + 1;
                        bestCol = col + 1;
                        direction = "TLBR"; // top left to bottom right
                    }
                }
            }
            currentSeq = 1;
        }


        //diagonal top right to bottom left (TRBL)

        for (int i = 0; i < elements.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < elements.GetLength(1); j++)
            {
                for (int row = i, col = j; row < elements.GetLength(0) - 1 && col > 0; row++, col--)
                {
                    if (elements[row, col] == elements[row + 1, col - 1])
                    {
                        currentSeq++;
                    }
                    else
                    {
                        currentSeq = 1;
                    }

                    if (currentSeq > bestSeq)
                    {
                        bestSeq = currentSeq;
                        bestRow = row + 1;
                        bestCol = col - 1;
                        direction = "TRBL"; // top left to bottom right
                    }
                }
            }
            currentSeq = 1;
        }


        // Populate the bool matrix for selected cells

        bool[,] selectedCells = new bool[elements.GetLength(0), elements.GetLength(1)];

        switch (direction)
        {
            case "horizontal":
                for (int i = bestCol; i >= Math.Abs(bestSeq - bestCol - 1); i--)
                {
                    selectedCells[bestRow, i] = true;
                }
                break;
            case "down":
                for (int i = bestRow; i >= Math.Abs(bestSeq - bestRow - 1); i--)
                {
                    selectedCells[i, bestCol] = true;
                }
                break;
            case "TLBR":
                for (int row = bestRow, col = bestCol; row >= Math.Abs(bestSeq - bestRow - 1) && col >= Math.Abs(bestSeq - bestCol - 1); row--, col--)
                {
                    selectedCells[row, col] = true;
                }
                break;
            case "TRBL":
                for (int row = bestRow, col = bestCol; row >= Math.Abs(bestSeq - bestRow - 1); row--, col++)
                {
                    selectedCells[row, col] = true;
                }
                break;
        }

        for (int i = 0; i < elements.GetLength(0); i++)
        {
            for (int j = 0; j < elements.GetLength(1); j++)
            {
                if (selectedCells[i, j] == true)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("{0, 4} ", elements[i, j]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.Write("{0, 4} ", elements[i, j]);
                }
            }
            Console.WriteLine();
        }
    }
}