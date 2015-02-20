using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombingCuboids
{
    class BombingCuboids
    {
        static int[] lettersHit = new int[91];
        static int totalHit = 0;
        const char Empty = ' '; 
        static void Main()
        {
            int width, height, depth;
            string[] dimension = Console.ReadLine().Split();

            width = int.Parse(dimension[0]);
            height = int.Parse(dimension[1]);
            depth = int.Parse(dimension[2]);

            char[, ,] cube = InputCube(width, height, depth);

            int bombsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < bombsCount; i++)
            {
                string[] bombValues = Console.ReadLine().Split();
                int bombWidth = int.Parse(bombValues[0]),
                    bombHeight = int.Parse(bombValues[1]),
                    bombDepth = int.Parse(bombValues[2]),
                    power = int.Parse(bombValues[3]);

                DetonateBomb(cube, bombWidth, bombHeight, bombDepth, power);
                FallDown(cube);
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(totalHit);

            for (int i = 0; i < lettersHit.Length; i++)
            {
                if (lettersHit[i] != 0)
                {
                    Console.WriteLine("{0} {1}",(char)i,lettersHit[i]);
                }
            }
        }

        private static void FallDown(char[, ,] cube)
        {
            int width = cube.GetLength(0);
            int depth = cube.GetLength(2);

            for (int pillarW = 0; pillarW < width; pillarW++)
            {
                for (int pillarD = 0; pillarD < depth; pillarD++)
                {
                    FallDownPillar(cube,pillarW, pillarD);
                }
            }
        }

        private static void FallDownPillar(char[, ,] cube, int pillarW, int pillarD)
        {
            int height = cube.GetLength(1);

            int bottom = 0;

            for (int pillarHeight = 0; pillarHeight < height; pillarHeight++)
            {
                if (cube[pillarW,pillarHeight,pillarD] != Empty)
                {
                    if (pillarHeight != bottom)
                    {
                        cube[pillarW, bottom, pillarD] = cube[pillarW, pillarHeight, pillarD];
                        cube[pillarW, pillarHeight, pillarD] = Empty;
                    }
                    bottom++;
                }
            }
        }

        private static void DetonateBomb(char[, ,] cube, int bombWidth, int bombHeight, int bombDepth, int power)
        {
            int width = cube.GetLength(0);
            int height = cube.GetLength(1);
            int depth = cube.GetLength(2);

            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        if (cube[w, h, d] != Empty)
                        {
                            int distSquarred = GetDistSquarred(w, h, d, bombWidth, bombHeight, bombDepth);
                            int pSquarred = power * power;

                            if (distSquarred <= pSquarred)
                            {
                                char currentLetter = cube[w, h, d];
                                lettersHit[(int)currentLetter]++;
                                totalHit++;
                                cube[w, h, d] = Empty;
                            }
                        }
                    }
                }
            }
        }

        private static int GetDistSquarred(int w, int h, int d, int bombWidth, int bombHeight, int bombDepth)
        {
            int deltaWidth = (w - bombWidth);
            int deltaHeight = (h - bombHeight);
            int deltaDepth = (d - bombDepth);
            return deltaWidth * deltaWidth + deltaHeight * deltaHeight + deltaDepth * deltaDepth;
        }

        private static char[, ,] InputCube(int width, int height, int depth)
        {
            char[, ,] cube = new char[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string[] plateRows = Console.ReadLine().Split();

                for (int d = 0; d < depth; d++)
                {
                    string currentPlateRow = plateRows[d];

                    for (int w = 0; w < width; w++)
                    {
                        cube[w, h, d] = currentPlateRow[w];
                    }
                }
            }

            return cube;
        }
    }
}
