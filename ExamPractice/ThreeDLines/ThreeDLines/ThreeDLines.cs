using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDLines
{
    class ThreeDLines
    {
        private static char[, ,] cube;
        private static int width, height, depth;
        private static int[] dirsWidth = { 1, 0, 1, -1, 0, 0, 0, 1, -1, 1, 1, 1, 1 };
        private static int[] dirsHeight = { 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, -1, 1, -1 };
        private static int[] dirsDepth = { 0, 0, 1, 1, 1, 1, -1, 0, 0, 1, 1, -1, -1 };
        private static int bestLineLength = 0;
        private static int bestNumberOfLines = 0;

        static void Main()
        {
            string[] rawNumbers = Console.ReadLine().Split();
            width = int.Parse(rawNumbers[0]);
            height = int.Parse(rawNumbers[1]);
            depth = int.Parse(rawNumbers[2]);
            cube = new char[width, height, depth];

            for (int h = 0; h < height; h++)
            {
                string line = Console.ReadLine();
                string[] lineFragment = line.Split();

                for (int d = 0; d < depth; d++)
                {
                    string depthFragment = lineFragment[d];

                    for (int w = 0; w < width; w++)
                    {
                        cube[w, h, d] = depthFragment[w];
                    }
                }
            }

            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < height; h++)
                {
                    for (int d = 0; d < depth; d++)
                    {
                        ProccessDirs(w, h, d);
                    }
                }
            }

            Console.WriteLine(bestLineLength + " " + bestNumberOfLines);
        }

        private static void ProccessDirs(int w, int h, int d)
        {
            char curCell = cube[w, h, d];
            for (int i = 0; i < dirsDepth.Length; i++)
            {
                int currentLineLength = 1;
                int curWidth = w;
                int curHeight = h;
                int curDepth = d;

                while (true)
                {
                    curWidth += dirsWidth[i];
                    curHeight += dirsHeight[i];
                    curDepth += dirsDepth[i];

                    if (!IsInCube(curWidth,curHeight,curDepth))
                    {
                        break;
                    }

                    if (cube[curWidth,curHeight,curDepth] == curCell)
                    {
                        currentLineLength++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentLineLength > bestLineLength)
                {
                    bestLineLength = currentLineLength;
                    bestNumberOfLines = 1;
                }
                else if(currentLineLength == bestLineLength)
                {
                    bestNumberOfLines++;
                }
            }
        }

        private static bool IsInCube(int w,int h,int d)
        {
            if (w >= 0 &&
                h >= 0 &&
                d >= 0 &&
                w < width &&
                h < height &&
                d < depth)
            {
                return true;
            }
            return false;
        }
    }
}
