namespace StudentGradeManager;

class Program
{
    static void Main(string[] args)
    {
        int[] students = new int[5];
        Grade[] studentsGrades = new Grade[5];
        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < students.Length; i++)
        {
            Console.Write($"Enter score for Student {i+1}: ");
            bool isStudentScoreParsed = int.TryParse(Console.ReadLine(), out int score);
            if (!isStudentScoreParsed || score < 0 || score > 100)
            {
                Console.WriteLine("Score value is invalid!");
                Console.WriteLine("Try again later!");
                return;
            }
            
            // if the score is valid it will reach here because no returning!
            students[i] = score;
        }

        GetGrade(students, studentsGrades);
        GetMinMax(students, out min, out max);
        
        Console.WriteLine("");
        Console.WriteLine("--- Report ---");
        for (int i = 0; i < students.Length; i++)
            Console.WriteLine($"Student {i+1}: {students[i]} -> Grade: {studentsGrades[i]}");

        Console.WriteLine();
        Console.WriteLine($"Average: {CalculateAverage(students)}");
        Console.WriteLine($"Highest Score: {max}");
        Console.WriteLine($"Lowest Score: {min}");
    }
    
    public static void GetGrade(int[] students, Grade[] studentsGrades)
    {
        for (int i = 0; i < studentsGrades.Length; i++)
        {
            switch (students[i])
            {
                case >= 90:
                    studentsGrades[i] = Grade.A;
                    break;
            
                case >= 80:
                    studentsGrades[i] = Grade.B;
                    break;
            
                case >= 70:
                    studentsGrades[i] = Grade.C;
                    break;
            
                case >= 60:
                    studentsGrades[i] = Grade.D;
                    break;
            
                case < 60:
                    studentsGrades[i] = Grade.F;
                    break;
            }
        }
    }
    
    public static double CalculateAverage(int[] students)
    {
        int sum = 0;
        for (int i = 0; i < students.Length; i++)
        {
            sum += students[i];
        }

        return sum * 1.0 / students.Length;
    }
    
    public static void GetMinMax(int[] students, out int min, out int max)
    {
        min = int.MaxValue;
        max = int.MinValue;
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i] < min)
                min = students[i];
            
            if (students[i] > max)
                max = students[i];
        }
    }
}