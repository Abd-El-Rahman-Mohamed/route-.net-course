namespace Assignment1;

// Q11: What is the base class constraint? Write an example.
public class SUV(double groundClearance) : Car("SUV-Model", 120)
{
    public double GroundClearance { get; private set; } = groundClearance;
}