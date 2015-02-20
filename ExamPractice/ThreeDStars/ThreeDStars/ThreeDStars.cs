using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDStars
{
    class ThreeDStars
    {
        private static int width, depth, height, starCount;
        private static char[, ,] cube;
        private static Dictionary<char, int> starType = new Dictionary<char, int>();
        static void Main()
        {
            ReadInput();
            FindStars();
            PrintMessage();
        }

        private static void PrintMessage()
        {
            var dict = starType.OrderBy(d => d.Key);

            Console.WriteLine(starCount);

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        private static void FindStars()
        {
            for (int h = 1; h < height - 1; h++)
            {
                for (int d = 1; d < depth - 1; d++)
                {
                    for (int w = 1; w < width - 1; w++)
                    {
                        FindSingleStar(w, h, d);
                    }
                }
            }
        }

        private static void FindSingleStar(int w, int h, int d)
        {
            char currChar = cube[w, h, d];

            bool isStar =
                currChar == cube[w + 1, h, d] &&
                currChar == cube[w - 1, h, d] &&
                currChar == cube[w, h + 1, d] &&
                currChar == cube[w, h - 1, d] &&
                currChar == cube[w, h, d + 1] &&
                currChar == cube[w, h, d - 1];

            if (isStar)
            {
                starCount++;
                if (starType.ContainsKey(currChar))
                {
                    starType[currChar]++;
                }
                else
                {
                    starType.Add(currChar, 1);
                }
            }
        }

        private static void ReadInput()
        {
            string[] rawNumbers = Console.ReadLine().Split();
            width = int.Parse(rawNumbers[0]);
            height = int.Parse(rawNumbers[1]);
            depth = int.Parse(rawNumbers[2]);

            cube = new char[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string[] lineFragment = Console.ReadLine().Split();

                for (int d = 0; d < depth; d++)
                {
                    string cubeContent = lineFragment[d];
                    for (int w = 0; w < width; w++)
                    {
                        cube[w, h, d] = cubeContent[w];
                    }
                }
            }
        }
    }
}
