namespace Assignment2;

public class Circle
{
    public decimal Radius { get; set; }

    public decimal Area
    {
        get
        {
            return Radius * (decimal)Math.Pow(Math.PI, 2);
        }
    }

}