//Write methods that calculate the surface of a triangle by given:
//Side and an altitude to it;
//Three sides;
//Two sides and an angle between them;
//Use System.Math.

using System;

class TriangleSurface
{
    static void Main()
    {
        Console.WriteLine("Please choose method to calculate triangle's surface:");

        int userInput = UserInput();

        switch (userInput)
        {
            case 1:
                Console.Write("Enter side: ");
                double side = double.Parse(Console.ReadLine());
                Console.Write("Enter altitude: ");
                double altitude = double.Parse(Console.ReadLine());
                Console.WriteLine("The area is " + SurfaceBySideAndAltitude(side, altitude));
                break;
            case 2:
                Console.Write("Enter sideA: ");
                double sideA = double.Parse(Console.ReadLine());
                Console.Write("Enter sideB: ");
                double sideB = double.Parse(Console.ReadLine());
                Console.Write("Enter sideC: ");
                double sideC = double.Parse(Console.ReadLine());
                Console.WriteLine("The area is " + SurfaceByThreeSides(sideA, sideB, sideC));
                break;
            case 3:
                Console.Write("Enter sideA: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Enter sideB: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("Enter angle in degrees: ");
                int angle = int.Parse(Console.ReadLine());
                Console.WriteLine("The area is " + SurfaceByTwoSidesAndAngle(a, b, angle));
                break;
        }
    }

    static int UserInput()
    {
        bool rightDecision = false;
        int choice = 0;

        while (!rightDecision)
        {
            Console.WriteLine("To calculate surface by given side and altitude: press 1");
            Console.WriteLine("To calculate surface by given three sides: press 2");
            Console.WriteLine("To calculate surface by given two sides and angle between: press 3");
            Console.Write("Your choise: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1 || choice == 2 || choice == 3)
            {
                rightDecision = true;
            }
        }
        return choice;
    }

    static double SurfaceBySideAndAltitude(double side, double altitude)
    {
        return (side * altitude) / 2;
    }

    static double SurfaceByThreeSides(double a, double b, double c)
    {
        double semiPerimeter = (a + b + c) / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
    }

    static double SurfaceByTwoSidesAndAngle(double a, double b, double degree)
    {
        return (a * b * Math.Sin(degree)) / 2;
    }
}