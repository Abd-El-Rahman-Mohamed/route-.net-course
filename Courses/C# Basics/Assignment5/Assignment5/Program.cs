using System.IO.Pipes;
using System.Text.RegularExpressions;

namespace Assignment5;

class Program
{
    static void Main(string[] args)
    {
        // I comment return for not valid inputs to not close the program
        //  when your good self is testing it.
        #region Part 1: Enums Q1 : Day of the Week
        Console.Write("Enter a day number: ");
        bool isDayNumberParsed = Enum.TryParse(Console.ReadLine(), out DayOfWeek day);
        if (!isDayNumberParsed || ((int)day < 1 || (int)day > 7))
        {
            Console.WriteLine("Day Number is invalid!");
        }
        else
        {
            Console.WriteLine($"Day: {day}");
            switch (day)
            {
                case DayOfWeek.Saturday:
                    Console.WriteLine("It's the Weekend");
                    break;

                case DayOfWeek.Sunday:
                    Console.WriteLine("It's a Workday");
                    break;

                case DayOfWeek.Monday:
                    Console.WriteLine("It's a Workday");
                    break;

                case DayOfWeek.Tuesday:
                    Console.WriteLine("It's a Workday");
                    break;

                case DayOfWeek.Wednesday:
                    Console.WriteLine("It's a Workday");
                    break;

                case DayOfWeek.Thursday:
                    Console.WriteLine("It's a Workday");
                    break;

                case DayOfWeek.Friday:
                    Console.WriteLine("It's the Weekend");
                    break;

                default:
                    Console.WriteLine("Not a day");
                    break;
            }
        }
        #endregion

        #region  Part 2 Q1 Array Statistics

        Console.Write("Enter array size: ");
        
        bool isArrSizeParsed = int.TryParse(Console.ReadLine(), out int arrSize);
        if (!isArrSizeParsed)
        {
            Console.WriteLine("Array size is invalid");
        }

        int[] arr = new int[arrSize];
        
        for (int i = 0; i < arrSize; i++)
        {
            Console.Write($"Enter element [{i}]: ");
            bool isItemParsed = int.TryParse(Console.ReadLine(), out int parsedItemValue);
            if (!isItemParsed)
            {
                Console.WriteLine("Item must be an integer value");
            }
            else
            {
                arr[i] = parsedItemValue;
            }
        }

        int sum = 0;
        double average = 0;
        int max = int.MinValue;
        int min = int.MaxValue;
        
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];

            average = sum * 1.0 / arr.Length;

            if (arr[i] > max) max = arr[i];

            if (arr[i] < min) min = arr[i];
        }
        
        Console.WriteLine($"Sum     = {sum}");
        Console.WriteLine($"Average = {average}");
        Console.WriteLine($"Max     = {max}");
        Console.WriteLine($"Min     = {min}");

        Console.Write("Reverse = ");
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            Console.Write($"{arr[i]}, ");
        }

        #endregion
        
        #region Part 2 Q2  Student Grades Matrix

        // Reads grades from the user into a [3, 4] array
        double[,] arr2D = new double[3, 4] // grades are more suitable to be stored as double
        {
            { 1, 2,  3 , 4},
            { 5, 6 , 7,  8},
            { 9, 10, 11, 12}
        };
        
        Console.WriteLine("");
        for (int i = 0; i < arr2D.GetLength(0); i++)
        {
            for (int j = 0; j < arr2D.GetLength(1); j++)
            {
                Console.Write($"Enter the value for element arr2D[{i},{j}]: ");
                bool isGradeParsed = double.TryParse(Console.ReadLine(), out double gradeParsed);
                if (!isGradeParsed)
                {
                    Console.WriteLine("Invalid value!");
                    // return;
                }
                else
                {
                    arr2D[i, j] = gradeParsed;
                }
            }
        }
        
        // Prints each student's average grade.
        for (int i = 0; i < arr2D.GetLength(0); i++)
        {
            double sumForEachStudent = 0;
            double averageForEachStudent = 0;
            for (int j = 0; j < arr2D.GetLength(1); j++)
            {
                sumForEachStudent += arr2D[i, j];
            }

            averageForEachStudent = sumForEachStudent / arr2D.GetLength(1);
            Console.WriteLine($"The Average Grade for {i} Student: {averageForEachStudent}");
        }
        
        // Prints the overall class averal
        double sumForClass = 0;
        double averageForClass = 0;
        
        for (int i = 0; i < arr2D.GetLength(0); i++)
        {
            for (int j = 0; j < arr2D.GetLength(1); j++)
            {
                sumForClass += arr2D[i, j];
            }

            averageForClass = sumForClass / arr2D.Length;
        }
        Console.WriteLine($"The Average Grade for the Class Overall: {averageForClass}");

        #endregion
        
        #region Part 3 Functions (Methods) Q1 : Basic Calculator Functions
        
        Console.Write("Enter the operation (+, -, *, /): ");
        string operation = Console.ReadLine()!;
        string operationPattern = @"\+|\-|\*|\/"; // I used regex to match for only the four operations
        bool isOperationValid = Regex.IsMatch(operation, operationPattern);
        if (!isOperationValid)
        {
            Console.WriteLine("Operation is invalid!");
            // return;
        }
        
        Console.Write("Enter value for num1: ");
        bool isNum1Parsed = double.TryParse(Console.ReadLine(), out double num1);
        if (!isNum1Parsed)
        {
            Console.WriteLine("Number is invalid!");
            // return;
        }

        Console.Write("Enter value for num2: ");
        bool isNum2Parsed = double.TryParse(Console.ReadLine(), out double num2);
        if (!isNum2Parsed)
        {
            Console.WriteLine("Number is invalid!");
            // return;
        }
        
        // If all is valid, then the program will reach here 👇!
        Calculator(operation, num1, num2);

        #endregion
        
        #region Part 3 Functions (Methods) Q2 : Circle Calculator with out

        Console.Write("Enter value for radius: ");
        bool isRadiusParsed = double.TryParse(Console.ReadLine(), out double radius);
        if (!isRadiusParsed || radius < 0)
        {
            Console.WriteLine("Radius value is invalid!");
            // return;
        }
        double area;
        double circumference;
        
        CalculateCircle(radius, out area, out circumference);
        
        Console.WriteLine($"Area: {area}");
        Console.WriteLine($"Circumference: {circumference}");

        #endregion
    }
    
    public static void Calculator(string operation, double num1, double num2)
    {
        switch (operation)
        {
            case "+":
                Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                break;
            
            case "-":
                Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                break;
            
            case "*":
                Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                break;
            
            case "/":
                if(num2 != 0) 
                    Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
                else 
                    Console.WriteLine("In Math, dividing by zero is not permittable!");
                break;
            
            default:
                Console.WriteLine("Invalid operation");
                break;
        }
    }

    public static void CalculateCircle(double radius, out double area, out double circumference)
    {
        area = Math.PI * Math.Pow(radius, 2);
        circumference = 2 * Math.PI * radius;
    }
}