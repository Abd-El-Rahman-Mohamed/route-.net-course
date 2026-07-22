// Exercise 1: Student Grade Manager
namespace StudentGradeManager;

class Program
{
    // Create a program that manages student grades using One Of Collections
    static void Main(string[] args)
    {
        // 1. Create a Collection with these grades: 85, 92, 78, 95, 88, 70, 100, 65
        List<int> grades = [85, 92, 78, 95, 88, 70, 100, 65];
        
        // 2. Print the collection, Count, first and last grade
        Console.WriteLine("--- All Grades ---");
        grades.ForEach(grade => Console.WriteLine(grade));
        Console.WriteLine();
        Console.WriteLine($"Grade Count: {grades.Count}");
        Console.WriteLine();
        Console.WriteLine($"First Grade: {grades[0]}");
        Console.WriteLine();
        Console.WriteLine($"Last Grade: {grades[^1]}");
        
        // 3. Sort the grades ascending, then print
        grades.Sort();
        Console.WriteLine("--- All Grades Sorted Ascending ---");
        grades.ForEach(grade => Console.WriteLine(grade));

        // 4. Get the first grade above 90
        Console.WriteLine();
        Console.WriteLine($"First grade above 90: {grades.Find(grade => grade > 90)}");
        
        // 5. Get all grades below 75 (failing grades)
        List<int> failingGrades = grades.FindAll(grade => grade < 75);
        Console.WriteLine();
        Console.WriteLine("--- Failing Grades ---");
        failingGrades.ForEach(failingGrade => Console.WriteLine(failingGrade));
        
        // 6. Remove all failing grades (below 75)
        grades.RemoveAll(grade => grade < 75);
        
        // 7. Check if any grade equals 100
        bool isThereGradeEquals100 = grades.Exists(grade => grade == 100);
        Console.WriteLine();
        Console.WriteLine($"Is there a grade equals 100? {isThereGradeEquals100}");
        
        // 8. Create a List<string> where each grade becomes "Grade: X"
        List<string> gradesString = [];
        grades.ForEach(grade => gradesString.Add($"Grade: {grade.ToString()}"));
        Console.WriteLine();
        Console.WriteLine("--- Grade: grade ---");
        gradesString.ForEach(gradeString => Console.WriteLine(gradeString));
    }
}