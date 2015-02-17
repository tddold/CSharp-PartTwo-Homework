using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public struct Object
{
    public int x;
    public int y;
    public char c;
    public ConsoleColor color;
}
public class JustCars
{

    static Object userCar = new Object();
    static int playingFieldWidth = 5;
    public static void Main()
    {
        int livesCount = 5;
        Console.BufferHeight = Console.WindowHeight = 30;
        Console.BufferWidth = Console.WindowWidth = 30;
        userCar.x = 2;
        userCar.y = Console.WindowHeight - 1;
        userCar.c = '^';
        userCar.color = ConsoleColor.Yellow;
        Random randomGenerator = new Random();
        List<Object> objects = new List<Object>();
        double speed = 100.0;
        double acceleration = 0.5;

        while (true)
        {
            speed += acceleration;

            if (speed > 400)
            {
                speed = 400;
            }

            int chance = randomGenerator.Next(0, 100);

            if (chance < 1)
            {
                Object newObject = new Object();
                newObject.color = ConsoleColor.Cyan;
                newObject.c = '-';
                newObject.x = randomGenerator.Next(0, playingFieldWidth);
                newObject.y = 0;
                objects.Add(newObject);
            }
            else if (chance < 20)
            {
                Object newObject = new Object();
                newObject.color = ConsoleColor.Cyan;
                newObject.c = '*';
                newObject.x = randomGenerator.Next(0, playingFieldWidth);
                newObject.y = 0;
                objects.Add(newObject);
            }
            else
            {
                // add car

                Object newCar = new Object();
                newCar.color = ConsoleColor.Green;
                newCar.x = randomGenerator.Next(0, playingFieldWidth);
                newCar.y = 0;
                newCar.c = '#';
                objects.Add(newCar);
            }

            

            bool hitted = false;

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                //while (Console.KeyAvailable) // Izchistva bufera i kogato se zadurji kopche nqma da zaciklq kolata v edna posoka
                //{
                //    Console.ReadKey(true);
                //}
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userCar.x - 1 >= 0)
                    {
                        userCar.x--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (userCar.x + 1 < playingFieldWidth)
                    {
                        userCar.x++;
                    }
                }
            }

            List<Object> newList = new List<Object>();
            for (int i = 0; i < objects.Count; i++) // move cars
            {
                Object oldCar = objects[i];
                Object justObject = new Object();
                justObject.x = oldCar.x;
                justObject.y = oldCar.y + 1;
                justObject.c = oldCar.c;
                justObject.color = oldCar.color;

                if (justObject.c == '-' && justObject.y == userCar.y && justObject.x == userCar.x) // check for bonus
                {
                    livesCount++;
                }

                if (justObject.c == '*' && justObject.y == userCar.y && justObject.x == userCar.x) // check for bonus
                {
                    speed -= 20;
                }

                if (justObject.c == '#' && justObject.y == userCar.y && justObject.x == userCar.x) // check if car is hitting the usercar
                {
                    livesCount--;
                    speed += 50;
                    if (speed > 400)
                    {
                        speed = 400;
                    }
                    hitted = true;

                    if (livesCount <= 0)
                    {
                        PrintStringOnPosition(8, 10, "GAME OVER!!!", ConsoleColor.Red);
                        PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
                        Console.ReadLine();
                        Environment.Exit(0);
                    }
                }

                if (justObject.y < Console.WindowHeight)
                {
                    newList.Add(justObject);
                }
                //Car car = cars[i];
                //car.y++;
                //if (car.y < Console.WindowHeight)
                //{ 
                //    cars[i] = car;
                //}
                //else
                //{
                //    cars.RemoveAt(i);
                //}
            }
            objects = newList;
            Console.Clear();

            // Redraw playfield
            DrawField();

            if (hitted)
            {
                PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Red);
                objects.Clear();
            }
            else
            {
                PrintOnPosition(userCar.x, userCar.y, userCar.c, userCar.color); // printe user car
            }

            foreach (var car in objects)
            {
                PrintOnPosition(car.x, car.y, car.c, car.color); // print other cars
            }

            // Draw Info
            PrintStringOnPosition(8, 4, "Lives: " + livesCount, ConsoleColor.White);
            PrintStringOnPosition(8, 5, "Speed: " + speed, ConsoleColor.White);
            PrintStringOnPosition(8, 6, "Acceleration: " + acceleration, ConsoleColor.White);
            Thread.Sleep((int)(600 - speed));
        }
    }

    static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(x, y);
        Console.Write(str);
    }
    private static void DrawField()
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