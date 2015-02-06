using System;

class ReadNumbers
{
    static int counter = 0;
    static void ReadNumber(int start, int end)
    {
        if (counter == 10)
        {
            Console.WriteLine("You have entered all ten numbers!");
            return;
        }
        else if (start == end - 1)
        {
            Console.Clear();
            Console.WriteLine("You have entered {0} valid numbers!",counter);
            Console.WriteLine("No more numbers left in the range!");
            return;
        }

        int number;
        Console.Write("Enter number is range [{0},{1}]: ",start,end);
        try
        {
            number = int.Parse(Console.ReadLine());
            if (start > number || number > end)
            {
                throw new ArgumentOutOfRangeException();
            }
            counter++;
            start = number;
            ReadNumber(start, end);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Your number is too big!", start, end);
            ReadNumber(start, end); // comment this row if you want the program to stop at this exception
            return;
        }
        catch (FormatException)
        {
            Console.WriteLine("Your number is not valid!");
            ReadNumber(start, end); // comment this row if you want the program to stop at this exception
            return;
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Your number is not in the range [{0},{1}]!", start, end);
            ReadNumber(start, end); // comment this row if you want the program to stop at this exception
            return;
        }
    }
    static void Main()
    {
        int min = 1;
        int max = 100;
        ReadNumber(min, max);
    }
}