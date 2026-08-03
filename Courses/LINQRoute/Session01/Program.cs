using LINQ.DataSources;

namespace Session01;

class Program
{
    static void Main(string[] args)
    {
        string[] words = ["apple", "banana", "cherry", "date", "elderberry", "fig", "grape"];

        var reverse = words
            .Select(w => new string(w.Reverse().ToArray()));

        foreach (var item in reverse)
        {
            Console.WriteLine(item);
        }
    }

    static ProductStockResponse ToDto(Product product)
    {
        return new ProductStockResponse(
            product.ProductName,
            product.UnitsInStock > 0,
            GetStockLevel(product.UnitsInStock));
    }

    public static string GetStockLevel(int unitsInStock)
    {
        if (unitsInStock == 0)
            return "Out of stock";
        if (unitsInStock < 10)
            return "Low";
        if (unitsInStock < 20)
            return "High";
        else
            return "Very High";
    }
}