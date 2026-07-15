namespace Assignment1;

// Q11: What is the base class constraint? Write an example.
public class Car(string model, double speed)
{
    public string Model { get; private set; } = model;
    public double Speed { get; private set; } = speed;
}