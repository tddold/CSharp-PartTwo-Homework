using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDSlides
{
    class Ball
    {
        public Ball(Ball ball)
        {
            this.Width = ball.Width;
            this.Height = ball.Height;
            this.Depth = ball.Depth;
        }
        public Ball(int width, int height, int depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }
        public int Width { get; set; }

        public int Height { get; set; }

        public int Depth { get; set; }
    }
    class ThreeDSlides
    {
        private static int width, height, depth;
        private static string[, ,] cube;
        private static Ball cubeBall;
        static void Main()
        {
            ReadInput();

            ProccessesBallCommands();
        }

        private static void ProccessesBallCommands()
        {
            while (true)
            {
                string currCell = cube[cubeBall.Width, cubeBall.Height, cubeBall.Depth];

                string[] splittedCell = currCell.Split();

                string command = splittedCell[0];

                switch (command)
                {
                    case "S":
                        ProccessBallSlide(splittedCell[1]);
                        break;
                    case "T":
                        cubeBall.Width = int.Parse(splittedCell[1]);
                        cubeBall.Depth = int.Parse(splittedCell[2]);
                        break;
                    case "B":
                        PrintMessage();
                        return;
                    case "E":
                        if (cubeBall.Height == height - 1)
                        {
                            PrintMessage();
                            return;
                        }
                        cubeBall.Height++;
                        break;
                    default: throw new ArgumentException("Invalid command!");
                }
            }
        }

        private static void ProccessBallSlide(string command)
        {
            Ball newCubeBall = new Ball(cubeBall);

            switch (command)
            {
                case "R":
                    newCubeBall.Height++;
                    newCubeBall.Width++;
                    break;
                case "L":
                    newCubeBall.Height++;
                    newCubeBall.Width--;
                    break;
                case "F":
                    newCubeBall.Depth--; // --
                    newCubeBall.Height++;
                    break;
                case "B":
                    newCubeBall.Depth++; // ++
                    newCubeBall.Height++;
                    break;
                case "FL":
                    newCubeBall.Depth--; // --
                    newCubeBall.Width--;
                    newCubeBall.Height++;
                    break;
                case "FR":
                    newCubeBall.Depth--; // --
                    newCubeBall.Width++;
                    newCubeBall.Height++;
                    break;
                case "BL":
                    newCubeBall.Depth++; // ++
                    newCubeBall.Width--;
                    newCubeBall.Height++;
                    break;
                case "BR":
                    newCubeBall.Depth++; // ++
                    newCubeBall.Width++;
                    newCubeBall.Height++;
                    break;
                default:
                    throw new ArgumentException("Invalid slide commnad");
            }

            if (IsPassable(newCubeBall))
            {
                cubeBall = new Ball(newCubeBall);
            }
            else
            {
                PrintMessage();
                Environment.Exit(0);
            }
        }

        private static void PrintMessage()
        {
            string currentCell = cube[cubeBall.Width, cubeBall.Height, cubeBall.Depth];

            if (currentCell == "B" || cubeBall.Height != height - 1)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }

            Console.WriteLine("{0} {1} {2}", cubeBall.Width, cubeBall.Height, cubeBall.Depth);
        }

        private static bool IsPassable(Ball ball)
        {
            if (ball.Width >= 0 &&
                ball.Height >= 0 &&
                ball.Depth >= 0 &&
                ball.Width < width &&
                ball.Height < height &&
                ball.Depth < depth)
            {
                return true;
            }
            return false;
        }

        private static void ReadInput()
        {
            string[] rawNumbers = Console.ReadLine().Split();
            width = int.Parse(rawNumbers[0]);
            height = int.Parse(rawNumbers[1]);
            depth = int.Parse(rawNumbers[2]);

            cube = new string[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string[] lineFragment = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                for (int d = 0; d < depth; d++)
                {
                    string[] cubeContent = lineFragment[d].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int w = 0; w < width; w++)
                    {
                        cube[w, h, d] = cubeContent[w];
                    }
                }
            }

            string[] rawBallCoords = Console.ReadLine().Split();

            int ballWidth = int.Parse(rawBallCoords[0]);
            int ballDepth = int.Parse(rawBallCoords[1]);

            cubeBall = new Ball(ballWidth, 0, ballDepth);
        }
    }
}
