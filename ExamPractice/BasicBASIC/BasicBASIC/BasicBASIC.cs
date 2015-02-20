using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicBASIC
{
    class BasicBASIC
    {
        static void Main()
        {
            long V, W, X, Y, Z;

            string[] lines = new string[10001];
            string command = Console.ReadLine();

            while (command != "RUN")
            {
                string[] split = command.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

                StringBuilder sb = new StringBuilder();
                for (int i = 1; i < split.Length; i++)
                {
                    if (split[i] == "=" || split[i] == "-" || split[i] == "+" || split[i] == ">" || split[i] == "<")
                    {
                        sb.Append(split[i]);
                    }
                    else
                    {
                        if (i < split.Length - 1 && (split[i + 1].Contains('-') || split[i + 1].Contains('+') || split[i + 1].Contains('=') || split[i + 1].Contains('<') || split[i + 1].Contains('>')))
                        {
                            sb.Append(split[i]);
                        }
                        else
                        {
                            sb.Append(split[i] + " ");
                        }
                    }

                    lines[int.Parse(split[0])] = sb.ToString();
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (line == null)
                {
                    continue;
                }

                if (line == "STOP")
                {
                    break;
                }

                if (line == "CLS")
                {
                    Console.Clear();
                    continue;
                }

                
            }
        }
    }
}
