using System;

class SayHello
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        PrintHello(name);
    }

    static void PrintHello(string name)
    {
        Console.WriteLine("Hello " + name);
    }
}

//Write a method that asks the user for his name and prints “Hello, <name>”
//Write a program to test this method.