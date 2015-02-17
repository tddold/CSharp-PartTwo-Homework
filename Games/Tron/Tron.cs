using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
class Tron
{
    static int left = 0;
    static int right = 1;
    static int up = 2;
    static int down = 3;

    static int firstPlayerScore = 0;
    static int firstPlayerDirection = right;
    static int firstPlayerColumn = 0;
    static int firstPlayerRow = 5;

    static int secondPlayerDirection = left;
    static int secondPlayerScore = 0;
    static int secondPlayerColumn = 100;
    static int secondPlayerRow = 5;

    static bool[,] isUsed;
    static void Main()
    {
        SetGameField();
        isUsed = new bool[Console.WindowWidth, Console.WindowHeight];

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ChangePlayerDirection(key);
            }

            MovePlayers();

            bool firstPlayerLoses = DoesPlayerLose(firstPlayerRow, firstPlayerColumn);
            bool secondPlayerLoses = DoesPlayerLose(secondPlayerRow, secondPlayerColumn);

            if (firstPlayerLoses && secondPlayerLoses)
            {
                firstPlayerScore++;
                secondPlayerScore++;
                Console.WriteLine();
                Console.WriteLine("Game over");
                Console.WriteLine("Draw game!!!");
                Console.WriteLine("Current score {0} - {1}",firstPlayerScore,secondPlayerScore);
                ResetGame();
            }
            if (firstPlayerLoses)
            {
                secondPlayerScore++;
                Console.WriteLine();
                Console.WriteLine("Game over");
                Console.WriteLine("Second player wins!!!");
                Console.WriteLine("Current score {0} - {1}", firstPlayerScore, secondPlayerScore);
                ResetGame();
            }
            if (secondPlayerLoses)
            {
                firstPlayerScore++;
                Console.WriteLine();
                Console.WriteLine("Game over");
                Console.WriteLine("First player wins!!!");
                Console.WriteLine("Current score {0} - {1}", firstPlayerScore, secondPlayerScore);
                ResetGame();
            }

            

            isUsed[firstPlayerColumn, firstPlayerRow] = true;
            isUsed[secondPlayerColumn, secondPlayerRow] = true;

            WriteOnPosition(firstPlayerColumn, firstPlayerRow, '*',ConsoleColor.Yellow);
            WriteOnPosition(secondPlayerColumn, secondPlayerRow, '*',ConsoleColor.Cyan);

            Thread.Sleep(100);
        }
    }

    static void ResetGame()
    {
        isUsed = new bool[Console.WindowWidth, Console.WindowHeight];
        SetGameField();
        firstPlayerDirection = right;
        secondPlayerDirection = left;
        Console.WriteLine("Press any key to start game.");
        Console.ReadKey();
        Console.Clear();
        MovePlayers();
    }

    static bool DoesPlayerLose(int row , int col)
    {
        if (row < 0)
        {
            return true;
        }
        if (col < 0)
        {
            return true;
        }
        if (row >= Console.WindowHeight)
        {
            return true;
        }
        if (col >= Console.WindowWidth)
        {
            return true;
        }

        if (isUsed[col, row])
        {
            return true;
        }

        return false;
    }

    // 0 => game is still active
    // 1 => first player wins
    // 2 => second player wins
    //private static int IsGameOver()
    //{
    //    if (firstPlayerRow < 0)
    //    {
    //        return 2;
    //    }
    //    if (firstPlayerColumn < 0)
    //    {
    //        return 2;
    //    }
    //    if (firstPlayerRow >= Console.WindowHeight)
    //    {
    //        return 2;
    //    }
    //    if (firstPlayerColumn >= Console.WindowWidth)
    //    {
    //        return 2;
    //    }

    //    if (isUsed[firstPlayerColumn,firstPlayerRow])
    //    {
    //        return 2;
    //    }

    //    if (secondPlayerRow < 0)
    //    {
    //        return 1;
    //    }
    //    if (secondPlayerColumn < 0)
    //    {
    //        return 1;
    //    }
    //    if (secondPlayerRow >= Console.WindowHeight)
    //    {
    //        return 1;
    //    }
    //    if (secondPlayerColumn >= Console.WindowWidth)
    //    {
    //        return 1;
    //    }

    //    if (isUsed[secondPlayerColumn, secondPlayerRow])
    //    {
    //        return 1;
    //    }

    //    return 0;
    //}

    private static void SetGameField()
    {
        Console.WindowWidth = 30;
        Console.BufferHeight = 30;

        Console.WindowWidth = 100;
        Console.BufferWidth = 100;

        firstPlayerColumn = 0;
        firstPlayerRow = Console.WindowHeight / 2;

        secondPlayerColumn = Console.WindowWidth - 1;
        secondPlayerRow = Console.WindowHeight / 2;
    }

    private static void MovePlayers()
    {
        if (firstPlayerDirection == right)
        {
            firstPlayerColumn++;
        }
        if (firstPlayerDirection == left)
        {
            firstPlayerColumn--;
        }
        if (firstPlayerDirection == up)
        {
            firstPlayerRow--;
        }
        if (firstPlayerDirection == down)
        {
            firstPlayerRow++;
        }


        if (secondPlayerDirection == right)
        {
            secondPlayerColumn++;
        }
        if (secondPlayerDirection == left)
        {
            secondPlayerColumn--;
        }
        if (secondPlayerDirection == up)
        {
            secondPlayerRow--;
        }
        if (secondPlayerDirection == down)
        {
            secondPlayerRow++;
        }

    }

    static void WriteOnPosition(int x, int y, char ch, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(x, y);
        Console.Write(ch);
    }

    static void ChangePlayerDirection(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.W)
        {
            firstPlayerDirection = up;
        }
        if (key.Key == ConsoleKey.A)
        {
            firstPlayerDirection = left;
        }
        if (key.Key == ConsoleKey.D)
        {
            firstPlayerDirection = right;
        }
        if (key.Key == ConsoleKey.S)
        {
            firstPlayerDirection = down;
        }


        if (key.Key == ConsoleKey.LeftArrow)
        {
            secondPlayerDirection = left;
        }
        if (key.Key == ConsoleKey.RightArrow)
        {
            secondPlayerDirection = right;
        }
        if (key.Key == ConsoleKey.UpArrow)
        {
            secondPlayerDirection = up;
        }
        if (key.Key == ConsoleKey.DownArrow)
        {
            secondPlayerDirection = down;
        }
    }
}
