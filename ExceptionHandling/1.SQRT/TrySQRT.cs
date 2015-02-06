using System;

class TrySQRT
{
    static void Main()
    {
        try
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());
            if (n < 0)
            {
                throw new ArithmeticException();
            }
            Console.WriteLine(Math.Sqrt(n));
        }
        catch (ArgumentNullException)
        {
            Console.Error.WriteLine("Invalid number");
        }
        catch (FormatException)
        {
            Console.Error.WriteLine("Invalid number");
        }
        catch (OverflowException)
        {
            Console.Error.WriteLine("Invalid number");
        }
        catch (ArithmeticException)
        {
            Console.Error.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}