namespace Assignment;

class Program
{
    static void Main(string[] args)
    {
        /* Notes on my submission: */
        // 1. To run the code with the exceptions that are existing because that the examples are designed to throw
        //     them, then uncomment the bookmarked lines: 50, 51, 81, 82, 83, 142, 162
        // 2. The duplicated variables names among the questions, I write them as "xInQXX" which XX is the question
        //     number
        #region Q1
        double d = 9.99;
        int x = (int)d;
        Console.WriteLine(x);
        // Explanation: Because that when casting explicitly from double to int
        //               it doesn't round instead it truncate the value
        #endregion
        
        #region Q2
        int n = 5;
        double d2 = (double)n / 2;
        Console.WriteLine(d2);
        // Explanation: Adding the explicit casting `(double)` at the left of `n` to cast it from int to double 
        //              Because that when we divided int on int it gives us int not double.
        #endregion
        
        #region Q3
        // In one line:
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine($"So, your age is: {age}");
        
        // With more safety if the user inputs wrong data to prevent FormatException:
        Console.Write("Enter your age: ");
        bool isAgeCorrectlyTyped = int.TryParse(Console.ReadLine(), out int ageWithSafety);
        if (isAgeCorrectlyTyped)
        {
            Console.WriteLine($"So, your age is: {ageWithSafety}");
        }
        else
        {
            Console.WriteLine("Enter a valid age");
        }

        #endregion
        
        #region Q4
        string s = "12a";
        // int xInQ4 = int.Parse(s); 
        // Console.WriteLine(xInQ4);
        // It will throw FormatException
        //  because there's `a` in `12a` that cannot be parsed to a numeric value.
        #endregion
        
        #region Q5
        bool solveParseError = int.TryParse(s, out int xOutput);
        if (solveParseError)
        {
            Console.WriteLine(xOutput);
        }
        else
        {
            Console.WriteLine("Invalid");
        }
        #endregion
        
        #region Q6
        object o = 10;
        int a = (int)o;
        Console.WriteLine(a + 1);
        // It will print 11
        // It's because the boxing and unboxing in C#.
        //  Boxing in the line `object o = 10` creates a box in the heap which holds the value `10` and `o` here stores
        //   the address in the object to reference the box created in the heap.
        //  Unboxing in the line `int a = (int)o;` takes the boxed value that is referenced to by the reference `o`
        //   from the heap then it casts (unboxes) it into int value to be stored in `a`. 
        #endregion
        
        #region Q7
        // object oInQ7 = 10;
        // long xInQ7 = (long)oInQ7;
        //  Console.WriteLine(xInQ7);
        
        // 1) It will throw InvalidCastException
        // 2) This happens because that when the value of `10` is boxed it's boxed as Int32 which is (int) and long works
        //  as Int64, so Int32 cannot be cast into Int64 using the explicit casting. 
        // 3) The fix for this problem can be one of these:
        //   1. Using `Convert.ToInt64` while unboxing to convert the unboxed Int32 (int) to Int64 (long)
        //   2. Or using the `(long)` explicit casting while boxing to the object to unbox it then successfully.
        
        // The First Fix:
        object oInQ7WhileBoxing = (long)10;
        long xInQ7FirstFix = (long)oInQ7WhileBoxing;
        Console.WriteLine(xInQ7FirstFix);
        
        // The Second Fix
        object oInQ7WhileUnboxing = 10;
        long xInQ7SecondFix = Convert.ToInt64(oInQ7WhileUnboxing);
        Console.WriteLine(xInQ7SecondFix);
        #endregion
        
        #region Q8
        try
        {
            object oInQ8 = 10;
            long xInQ8 = Convert.ToInt64(oInQ8);
            Console.WriteLine(xInQ8);
        }
        catch (Exception ex)
        {
            Console.WriteLine(-1);
        }
        #endregion
        
        #region Q9
        string? name = null;
        Console.WriteLine(name?.Length);
        // This prints null which actually prints nothing (empty line), because than name has no value and is null, so 
        //  the operation `?.` checks if there's a value it will print it if it has no value (null) then it doesn't
        //  throw NullReferenceException instead it prints null (the empty line)
        #endregion
        
        #region Q10
        string? name2 = null;
        int length = name2?.Length ?? 0;
        // This will return 0 because it checks using the `??` operator if `name2` has value it prints the value, if
        //  it's null, then it prints 0. (In our case it's null, so 0 will be printed)
        #endregion
        
        #region Q11
        string? sInQ11 = null;
        int xInQ11 = int.Parse(sInQ11 ?? "0");
        Console.WriteLine(xInQ11);
        // It prints 0.
        // Explanation: In this case the Parse argument is either the value of `sInQ11` if it's not null and having a
        //  value or "0" if it's null. (In our case `sInQ11` is null, so the Parsed value is "0")
        #endregion
        
        #region Q12
        string? sInQ12 = null;
        // Console.WriteLine(sInQ12!.Length);
        // The problem here is the WriteLine will throw `NullReferenceException` because the operator `!` doesn't make
        //  anything to throwing the exception it's only useful to hide the warnings and also for the meaning that I
        //  tell the compiler "trust me, this value will not be null except only at the initialization"
        
        // We can handle using the `?.` to print empty line when `sInQ12` is null and prevent exceptions:
        Console.WriteLine(sInQ12!?.Length);
        #endregion
        
        #region Q13
        string? sInQ13 = null;
        int xInQ13 = Convert.ToInt32(sInQ13);
        Console.WriteLine(xInQ13);
        // It will print 0 because of that using `Convert.ToInt32()` adds an additional check condition that's executed
        //  when the converted value is null then it will return `0`.
        #endregion
        
        #region Q14
        string? sInQ14 = null;
        
        // int aInQ14 = int.Parse(sInQ14); // This will throw ArgumentException because int.Parse is not designed to
                                        //  handle null
        
        int b = Convert.ToInt32(sInQ14);
        Console.WriteLine(b); // This will print `0` because `Convert.ToInt32` has an additional condition which gives
                              //  `0` as a default value if the user is trying to convert `null` to Int32. 
        #endregion
        
        #region Q15
        string? user = null;

        if (String.IsNullOrWhiteSpace(user))
        {
            Console.WriteLine("Guest");
        }
        else
        {
            Console.WriteLine(user);
        }
        #endregion
    }
}