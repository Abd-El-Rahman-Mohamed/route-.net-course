namespace Assignment2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

#region Part 01 : Theoretical Questions

    #region Q1 : Consider the following class:

    // a) Identify at least two problems with this design from an encapsulation perspective.
    // 1. The data shouldn't be accessed directly, which in our code leads to Balance can hold 
    //  negative value while in Business it may be not allowable.
    // 2. Validating data, which is not applied in the `Withdraw` method, that enables also 
    //  to make the balance negative.

    // b) Describe how you would fix this class to follow proper encapsulation principles.
    // You do not need to write the full code.
    // The solution is to make the fields private to prevent messing with them values.
    // Then adding a getter and setter with logic and validation for not entering any messing
    //  data such as wrong names for `Owner` field and negative ints for `Balance`
    // Also we can make this using Properties instead of Getter and Setter methods.

    // c) Explain why exposing fields directly (as public) is considered a bad practice in OOP.
    // It allows messing with the data because it lacks the data validation before setting its
    //  values.

    #endregion

    #region Q02 : What is the difference between a field and a property in C#? Can a property contain logic? Give an example of a read-only property that returns a calculated value.
    // Q: What is the difference between a field and a property in C#?
    // Field is a variable that holds a value and is owned by the object.
    //  when setting it if it's public, its value will be set directly without any validation.
    // To avoid this we can make it private, but the problem that it will make its value
    //   inaccessible and we cannot read it.
    // Properties separates these two operations (getting the value of the field and setting it
    //  a value)
    // Also properties is used to add validation before setting its value to prevent messing
    //  with the values.

    // Q: What is the difference between a field and a property in C#?
    // So, yes A propety can contain logic.

    // Q: Give an example of a read-only property that returns a calculated value.
    // An example can be an area of a circle that takes the radius and also it has `get` and no 
    //  `set`
    // Code is in the class of `Circle`
    #endregion

    #region Q3 : Look at the following code and answer the questions below:
    // a) What is `this[int index]` called? Explain its purpose.
    // It's an indexer which is originally a special property that takes an index.
    // Its purpose is to search for the array containg object details and returns the one with
    // the given index even if the index is int or a string.

    // b) What happens if someone writes `register[10] = "Ali";` ? How would you make the indexer
    // safer?
    // The problem can occur if the array length is less than 10, so to solve this we write a 
    // validation to validate the index to be less than the array index before setting the array
    // item's value, then we can handle it to return a message or throw an error.

    // c) Can a class have more than one indexer? If yes, give an example of when that would be
    // useful.
    // Yes, it can.
    // It can have one with the normal index for the array starting with 0 and ending with
    //  array.length - 1 to return the item based on its index.
    // Also another one to return the item based on its value.
    // An example for when the another one will be useful can be when we are searching for 
    // Employee details based on its ID in the company like `1234e5`:
    // employee["1234e5"];
    // So it will return its string data, such as: "Name: Mohamed Ahmed, Age: 45, HireDate: 17-5-2026"
    #endregion

    #region Q4 : Consider the following code and answer the questions below:
    // a) What does the `static` keyword mean on `TotalOrders`? How is it different from the
    // `Item` field?
    // `static` keyword makes the field related to the class not the instance object which leads
    //  to that its value will be shared between all the objects and can be accessed throw the
    // name of the class itself not the object name such as `Order.TotalOrders`.
    // While `ItemField` is related to the instance object, so each object has its own ItemField
    //  and also its own value of ItemField.

    // b) Can a static method inside `Order` access the `Item` field directly? Why or why not?
    // Not static methods only call static fields and static methods.
    // Static methods cannot call neither static fields nor static methods.

    #endregion
    
#endregion