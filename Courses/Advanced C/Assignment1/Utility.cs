using System.Numerics;

namespace Assignment1;

public class Utility<T>(T a, T b)
{
    public T a { get; private set; } = a;
    public T b { get; private set; } = b;

    // Q4: What is a generic method? Write Swap<T> method.
    public void Swap<T>(ref T a, ref T b)
        => (a, b) = (b, a);
    
    // Q5: Write a generic method FindMax<T> that finds maximum value
    // I will add the constraint `where T : INumber` to allow the expression of `item > max` to be ran
    // Q10: What is the interface constraint? Write an example.
    public T FindMax<T>(List<T> items)
        where T : INumber<T>
    {
        T max = items[0];
        foreach(T item in items)
            if (max > item)
                max = item;

        return max;
    }
}