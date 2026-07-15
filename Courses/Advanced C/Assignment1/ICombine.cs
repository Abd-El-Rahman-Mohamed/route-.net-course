namespace Assignment1;

// Q7: What is the 'struct' constraint? Write an example.
public interface ICombine<T>
    where T : struct
{
    string Combine();
}