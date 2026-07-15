namespace Assignment1;

// Q9: What is the 'new()' constraint? Write an example
// To make the class implementing the interface returning a new object using the default constructor.
// Q12: How do you apply multiple constraints? Write an example
public interface ICreate<T>
    where T : class, new()
{
    T Create();
}