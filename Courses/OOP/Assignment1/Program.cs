namespace Assignment1;

// Part 01 :

/*
Q1: Explain with code example how class and struct behave differently
Struct:
     - Has no inheritance so it doesn't have protected, protected internal, and private
         internal access modifer, it only has public, private, and internal. 
     - It's a value type that's stored in the stack
     - It's supposed to be used if it's a whole thing that's represented by many fields and
        method.
     - It's supposed to be used if the component we create has small size (16 Bytes or smaller)
Example in the `RGB.cs` and `pixelColor` variable in Main method

Class:
     - Has inheritance, so its access modifiers are: public, private, internal, and also
         protected, protected internal, private protected. 
     - It's a reference type, that whose object is stored in the managed heap.
     - It's supposed to be used if we represent a component which has fields and methods.
     - It's supposed to be used if the component we create has bigger size (16 Bytes or bigger)
Example in the `Book.cs` and `Whispers of the Hollow Grove` variable in Main method
*/

/*
Q2: Explain the difference between public and private access modifiers with an example. 
Public: 
    It means that the component whose access modifier is `public` can be accessed anywhere inside 
    the same project or outside the project.
    It's the default access modifier for:
        - Enum constants
        - Interface methods
    Example for it when I print the value of `RedValue` from the `RGB` struct in the `Main` method
Private: 
    It means that the component whose access modifier is `private` can be accessed only in the 
    same project. 
    It's the default access modifier for:
        - Class fields and methods
        - Struct fields and methods
    Example for it when I print the value of `SecretOfTheStory` from the `whispersOfTheHollowGrove`
    in the `Main` method.
*/

/*
Q3 : Describe the steps to create and use a class library in Visual Studio.
Researcher it because I am using NetBrains Rider.
    1. Keyboard Input: `Ctrl + Shift + N`
    2. Type `Class Library`
    3. Press `Enter`
    4. Then a class library is created
*/

/*
Q4 : What is a class library? Why do we use class libraries?
Class Library is a type of project that can not run and it contains classes.
Class Libraries are used to contain a collection classes for a specific single usage, which 
gives us these advantages:
    - Organization, because it splits classes into a collections of classes who has the same main 
        concern
    - Reusability, which makes the collections of classes allowed to be used in shared programs.
    - Maintainability, which makes tracking the problems and bugs easier because it splits the 
        classes with the same concern which almost the same as logic.
*/

class Program
{
    static void Main(string[] args)
    {
        #region Q1
        RGB pixelColor = new RGB(128, 0, 128); // For purple color for example
        // No object in the heap for now

        Book whispersOfTheHollowGrove =
            new Book(
                "Whispers of the Hollow Grove", 
                "978-9364266611", 
                "Rebecca Bhattacharjee"
                );
        #endregion
        
        #region Q2

        Console.WriteLine(pixelColor.RedValue);
        
        // It's a part of the example but it gives error, so I comment the following line. 👇
        // Console.WriteLine(whispersOfTheHollowGrove.SecretOfTheStory);
        
        #endregion
    }
}