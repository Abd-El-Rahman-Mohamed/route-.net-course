namespace Session01;

public abstract class Animal
{
    protected Animal(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}