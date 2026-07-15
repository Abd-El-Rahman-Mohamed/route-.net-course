namespace Assignment1;

// Q11: What is the base class constraint? Write an example.
public class Van(double cargoCapacity ) : Car("Van-Model", 100)
{
    public double CargoCapacity  { get; private set; } = cargoCapacity ;
}