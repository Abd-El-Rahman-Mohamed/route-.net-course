using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Assignment4;

class Program
{
    static void Main(string[] args)
    {
        #region Question1
        // A junior developer wrote this code to build a comma-separated list of 5,000 product IDs:
        var stringAndStringBuilderStopWatch = new Stopwatch();

        stringAndStringBuilderStopWatch.Start();
        string productList = "";
        for(int i = 1; i <= 5000; i++)
        {
            productList += "PROD-" + i + ",";
        }
        stringAndStringBuilderStopWatch.Stop();
        Console.WriteLine($"Time taken by for loop using string: {stringAndStringBuilderStopWatch}");
        
        // a) The previous code is bad because doing many operations on string like in the previous
        //  for loop create new object each time the string is operated on so it makes the time
        //  complexity bad.
        // What happens in memory regarding the previous code is that each iteration:
        //  1. a new object is created in the heap containing the new value entered to productList
        //  2. productList removes the reference that references the old value of productList
        //  3. productList references the new value that is entered to it.
        //  Note: The value entered to productList means the value of `"PROD-" + i + ","`.
        
        // b) The previous code using StringBuilder:
        stringAndStringBuilderStopWatch.Reset();
        stringAndStringBuilderStopWatch.Start();
        StringBuilder productListSB = new StringBuilder("");
        for(int i = 1; i <= 5000; i++)
        {
            productListSB.Append("PROD-" + i + ",");
        }
        stringAndStringBuilderStopWatch.Stop();
        Console.WriteLine($"Time taken by for loop using StringBuilder: {stringAndStringBuilderStopWatch}");
        
        // c) Comparing the time they take using `StopWatch`, so I wrapped the previous codes
        //  using the `StopWatch` class
        #endregion
        
        #region Question2
        // Ticket Pricing System 
 

        // Using byte age because that I assume no one will have neither age exceeding 255 nor negative age
        byte age; 
        bool isWeekend;
        bool isValidStudent = false;
        decimal price;
        StringBuilder invoice = new StringBuilder("------------------Invoice------------------\n");
        
        #region checkingAgeInput
        Console.Write("Enter your age: ");
        bool isAgeParsed = byte.TryParse(Console.ReadLine(), out age);
        while (!isAgeParsed || age is < 1 or > 125)
        {
            Console.Write("Enter a valid Age: ");
            isAgeParsed = byte.TryParse(Console.ReadLine(), out age);
        }
        Console.WriteLine($"Age: {age}");
        #endregion
        
        #region checkingDayInput
        Console.Write("Day of week: ");
        bool isDayParsed = int.TryParse(Console.ReadLine(), out int day);
        while (!isDayParsed || day is < 1 or > 7)
        {
            Console.Write("Enter a valid Day of week: ");
            isDayParsed = int.TryParse(Console.ReadLine(), out day);
        }
        isWeekend = day is 6 or 7;
        Console.WriteLine($"Day: {day}");
        #endregion
        

        #region checkingStudentInput
        Console.Write("Are you a student? (yes/no) ");
        string isStudent = Console.ReadLine()!;
        while (isStudent != "yes" && isStudent != "no")
        {
            Console.Write("Enter either 'yes' or 'no': ");
            isStudent = Console.ReadLine()!;
        }

        if (isStudent == "yes")
        {
            const int validId = 12345678;
            Console.Write("Enter your id: ");
            bool isIdParsed = int.TryParse(Console.ReadLine(), out int studentId);
            isValidStudent = false; 
            while (!isIdParsed || studentId != validId)
            {
                Console.Write("Enter a valid id: ");
                isIdParsed = int.TryParse(Console.ReadLine(), out studentId);
            }

            isValidStudent = true;
        }
        #endregion

        #region mainQuestionLogic
        if (age < 5)
        {
            invoice.AppendLine($"- Children's until age of 5 tickets are for free!");
            price = 0m;
        }
        else if (age <= 12)
        {
            price = 30m;
            invoice.AppendLine($"- The ages From 5-12 ticket price is 30LE!");
        }
        else if (age <= 59)
        {
            price = 25m;
            invoice.AppendLine($"- The ages From 13-59 ticket price is 30LE!");
        }
        else
        {
            // This will make age matches 60 and bigger because I used byte then it will no have negative numbers nor  
            //  values greater than  125 because of the condition in while
            price = 25m;
            invoice.AppendLine($"- The ages From 60 and up tickets price is 25LE!");
        } 

        if (isWeekend && price != 0)
        {
            price += 10m;
            invoice.AppendLine($"- Weekend ticket's price is raised by 10LE surcharge!");
        }

        if (isValidStudent)
        {
            price -= 0.2m * price;
            invoice.AppendLine($"- Student's ticket prices are discounted by 20%!");
        }
        
        invoice.AppendLine("---------");
        invoice.AppendLine($"Total Price: {price}LE");
        invoice.AppendLine("------------------------------------------------");
        Console.WriteLine(invoice);
        #endregion
        
        #endregion
        
        #region Question3
        // Convert the following if-else chain to

        string fileExtension = ".pdf";
        string fileType;
        
        // Using traditional switch statement
        switch (fileExtension)
        {
            case ".pdf":
                fileType = "PDF Document";
                break;
            
            case ".docx":
            case ".doc":
                fileType = "Word Document";
                break;
            
            case ".xlsx":
            case ".xls":
                fileType = "Excel Spreadsheet";
                break;
            
            case ".jpg":
            case ".png":
            case ".gif":
                fileType = "Image File";
                break;
            
            default:
                fileType = "Unknown file type";
                break;
        }
        
        // Using switch expression statement
        fileType = fileExtension switch
        {
            ".pdf" => "PDF Document",
            ".docx" or ".doc" => "Word Document",
            ".xlsx" or ".xls" => "Excel Spreadsheet",
            ".jpg" or ".png" or ".gif" => "Image File",
            _ => "Unknown File Type"
        };

        #endregion
        
        #region Question4
        // Ternary Operator 

        int temprature = 35;
        string weatherAdvice;

        weatherAdvice = temprature < 0 ? "Freezing! Stay indoors."
                        : temprature < 15 ? "Cold. Wear a jacket."
                        : temprature < 25 ? "Pleasant weather."
                        : temprature < 35 ? "Warm. Stay hydrated."
                        : "Hot! Avoid sun exposure.";

        // Unfortunately, this version of ternary operator is not readable as the if-elseif-else statement.
        // We can use the ternary operator only if we have one condition and will assign a value based on it.
        //  Not nesting it like this!

        #endregion
        
        #region Question5
        // Input Validation with Loops 

        string password = "";
        int attempts = 0;
        int digitsInPassword = 0;
        bool isPasswordValid = false;
        
        do
        {
            Console.Write("Enter Password: ");
            password = Console.ReadLine();
        
            if (password.Length < 8)
            {
                Console.WriteLine("Password length must be at least 8");
                attempts++;
                continue;
            }

            bool passwordHasSpaces = false;
            bool passwordHasADigit = false;
            foreach(var letter in password)
            {
                bool isLetterANumber = int.TryParse(letter.ToString(), out int parsed);
                if (letter == ' ')
                {
                    Console.WriteLine("Password cannot contain spaces");
                    attempts++;
                    passwordHasSpaces = true;
                    break;
                }
                
                if (isLetterANumber)
                {
                    passwordHasADigit = true;
                }
            }

            if (passwordHasSpaces) continue;
            if (!passwordHasADigit)
            {
                Console.WriteLine("Password must contain a digit");
                attempts++;
                continue;
            };

            if (password.ToLower() == password)
            {
                Console.WriteLine("Password must contain at least one uppercase character!");
                attempts++;
                continue;
            }
            
            isPasswordValid = true;
        
            attempts++;
        } while (attempts < 5 && !isPasswordValid);
        
        if (isPasswordValid)
            Console.WriteLine("Password accepted!");
        else // means that the attempts exceeds 5
            Console.WriteLine("Account locked");
        
        #endregion
        
        #region Question6
        // Array Processing

        int[] scores = [85, 42, 91, 67, 55, 78, 39, 88, 72, 95, 60, 48];
        
        StringBuilder fallingScores = new StringBuilder("");
        
        // (a) find and display all falling scores
        foreach (var item in scores)
        {
            switch (item)
            {
                case < 50:
                    fallingScores.Append($" {item}");
                    break;
            }
        }
        Console.WriteLine($"Falling Scores are {fallingScores}");
        
        // (b) find the first score above 90 and stop searching immediately
        foreach (var item in scores)
        {
            if (item > 90)
            {
                Console.WriteLine($"First score above 90 is {item}");
                break;
            }
        }
        
        // (c) calculate the class average, excluding any scores below 40 (considered absent)
        int sumAbove40 = 0;
        foreach(var item in scores)
        {
            if (item > 40)
                sumAbove40 += item;
        }
        // I think that we will divide above all the length because the below 40 are considered absent
        Console.WriteLine($"The class average: {(double)sumAbove40 / scores.Length}");

        int aStudentsCount = 0;
        int bStudentsCount = 0;
        int cStudentsCount = 0;
        int dStudentsCount = 0;
        int fStudentsCount = 0;
        foreach(var item in scores)
        {
            switch (item)
            {
                case (>= 90 and <= 100):
                    aStudentsCount++;
                    break;

                case (>= 80 and <= 89):
                    bStudentsCount++;
                    break;
                    
                case (>= 70 and <= 79):
                    cStudentsCount++;
                    break;
                    
                case (>= 60 and <= 69):
                    dStudentsCount++;
                    break;
                    
                case (< 60 ):
                    fStudentsCount++;
                    break;
            }
        }
        #endregion
    }
}