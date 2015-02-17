using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public struct SpaceObjects
{
    public int x;
    public int y;
    public char symbol;
    public ConsoleColor color;
}

public class SpaceWars
{
    static int playingFieldWidth = 5;
    static SpaceObjects userShip;
    static List<SpaceObjects> shotsFired = new List<SpaceObjects>();
    static Random randomGenerator = new Random();
    static List<SpaceObjects> enemyShips = new List<SpaceObjects>();
    static int kills = 0;
    static int livesCount = 5;
    static bool lostGame;
    static void Main()
    {
        SetPlayingFieldSize();
        CreateUserShip();

        while (true)
        {
            lostGame = false;

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                MoveSpaceShipOrGenerateShot(pressedKey);
            }

            GenerateEnemyShips();
            MoveEnemyShips();
            MoveShot();

            CheckIfThereIsAHit();

            Console.Clear();

            if (lostGame)
            {
                PrintStringOnPosition(8, 8, "Lost life", ConsoleColor.Yellow);
                enemyShips.Clear();
            }

            DrawField();
            PrintEnemiesOnPosition();
            PrintShotsOnPosition();
            PrintOnPosition(userShip.x, userShip.y, userShip.symbol, userShip.color);
            PrintStringOnPosition(8, 4, "Kills: " + kills, ConsoleColor.White);
            PrintStringOnPosition(8, 5, "Lives: " + livesCount, ConsoleColor.White);

            Thread.Sleep(100);
        }
    }

    private static void CheckIfThereIsAHit()
    {
        for (int i = 0; i < shotsFired.Count; i++)
        {
            for (int j = 0; j < enemyShips.Count; j++)
            {
                if (shotsFired[i].x == enemyShips[j].x && shotsFired[i].y == enemyShips[j].y)
                {
                    kills++;
                    enemyShips.Remove(enemyShips[j]);
                    shotsFired.Remove(shotsFired[i]);
                    break;
                }
            }
        }
    }

    static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(x, y);
        Console.Write(str);
    }

    private static void PrintEnemiesOnPosition()
    {
        foreach (var enemy in enemyShips)
        {
            PrintOnPosition(enemy.x, enemy.y, enemy.symbol, enemy.color);
        }
    }

    private static void MoveEnemyShips()
    {
        int chance = randomGenerator.Next(1, 101);

        if (chance < 15)
        {
            List<SpaceObjects> newList = new List<SpaceObjects>();
            for (int i = 0; i < enemyShips.Count; i++)
            {
                SpaceObjects currentEnemy = enemyShips[i];
                SpaceObjects newEnemy = new SpaceObjects();
                newEnemy.x = currentEnemy.x;
                newEnemy.y = currentEnemy.y + 1;
                newEnemy.symbol = currentEnemy.symbol;
                newEnemy.color = currentEnemy.color;

                if (newEnemy.y == userShip.y)
                {
                    livesCount--;
                    lostGame = true;
                }

                if (newEnemy.y < Console.WindowHeight)
                {
                    newList.Add(newEnemy);
                }


                if (livesCount <= 0)
                {
                    PrintStringOnPosition(8, 10, "GAME OVER!!!", ConsoleColor.Red);
                    PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            enemyShips = newList;
        }
    }

    private static void GenerateEnemyShips()
    {
        int chance = randomGenerator.Next(1, 101);

        if (chance < 30)
        {
            SpaceObjects enemy = new SpaceObjects();
            enemy.x = randomGenerator.Next(0, playingFieldWidth);
            enemy.y = 0;
            enemy.symbol = '#';
            enemy.color = ConsoleColor.Red;

            enemyShips.Add(enemy);
        }
    }

    private static void PrintShotsOnPosition()
    {
        foreach (var shot in shotsFired)
        {
            PrintOnPosition(shot.x, shot.y, shot.symbol, shot.color);
        }
    }

    private static void MoveShot()
    {
        List<SpaceObjects> newList = new List<SpaceObjects>();
        for (int i = 0; i < shotsFired.Count; i++)
        {
            SpaceObjects currentShot = shotsFired[i];
            SpaceObjects newShot = new SpaceObjects();
            newShot.x = currentShot.x;
            newShot.y = currentShot.y - 1;
            newShot.symbol = currentShot.symbol;
            newShot.color = currentShot.color;
            
            if (newShot.y >= 0)
            {
                newList.Add(newShot);
            }
        }
        shotsFired = newList;
    }

    private static void MoveSpaceShipOrGenerateShot(ConsoleKeyInfo pressedKey)
    {
        while (Console.KeyAvailable) // Izchistva bufera i kogato se zadurji kopche nqma da zaciklq kolata v edna posoka
        {
            Console.ReadKey(true);
        }
        if (pressedKey.Key == ConsoleKey.LeftArrow)
        {
            if (userShip.x - 1 >= 0)
            {
                userShip.x--;
            }
        }
        else if (pressedKey.Key == ConsoleKey.RightArrow)
        {
            if (userShip.x + 1 < playingFieldWidth)
            {
                userShip.x++;
            }
        }
        else if (pressedKey.Key == ConsoleKey.Spacebar)
        {
            SpaceObjects shot = new SpaceObjects();
            shot.x = userShip.x;
            shot.y = userShip.y;
            shot.symbol = '*';
            shot.color = ConsoleColor.Green;

            shotsFired.Add(shot);
        }
    }

    private static void CreateUserShip()
    {
        userShip.x = 2;
        userShip.y = Console.WindowHeight - 1; ;
        userShip.symbol = '^';
        userShip.color = ConsoleColor.White;
    }

    static void SetPlayingFieldSize()
    {
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 30;
    }

    static void DrawField()
    {
        for (int y = 0; y < Console.WindowHeight; y++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(playingFieldWidth, y);
            Console.Write('|');
        }
    }

    static void PrintOnPosition(int x, int y, char ch, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(x, y);
        Console.Write(ch);
    }
}