using LINQ.DataSources;

namespace Assignment01;

class Program
{
    static void Main(string[] args)
    {
        // 1. Get all products from the "Seafood" category. Print each
        // product's name and price.
        var products = Source.ProductList;

        var seafoodProducts = products
            .Where(p => p.Category == "Seafood")
            .Select(p => new { p.ProductName, p.UnitPrice });
        
        Console.WriteLine("Seafood Products: ");
        foreach(var seafoodProduct in seafoodProducts)
            Console.WriteLine(seafoodProduct);

        Console.WriteLine();
        // 2. Get a list of only the product names from ProductList. Print each name.
        var productNames = products
            .Select(p => p.ProductName);

        Console.WriteLine("Products Names: ");
        foreach (var productName in productNames)
            Console.WriteLine(productName);

        Console.WriteLine();
        // 3. Sort all products by UnitPrice (ascending). Print each product's name and price.
        var sortedProducts = products
            .OrderBy(p => p.UnitPrice)
            .Select(p => new { p.ProductName, p.UnitPrice });

        Console.WriteLine("Products Name and Price sorted by Unit Price ascending");
        foreach(var sortedProduct in sortedProducts)
            Console.WriteLine(sortedProduct);

        Console.WriteLine();
        // 4. Get all products where UnitPrice is between 10 and 30
        var productsWhoseUnitPriceIsBetween10And20 = products
            .Where(p => p.UnitPrice is > 10 and < 20);
        
        Console.WriteLine("Products where UnitPrice is between 10 and 30: ");
        foreach(var productWhoseUnitPriceIsBetween10And20 in productsWhoseUnitPriceIsBetween10And20)
            Console.WriteLine(productWhoseUnitPriceIsBetween10And20);
        
        Console.WriteLine();
        // 5. Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category.
        var inStockCondimentsProducts = products
            .Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

        Console.WriteLine("Products that are in stock (UnitsInStock > 0) and belong to the \"Condiments\" category.");
        foreach (var inStockCondimentsProduct in inStockCondimentsProducts)
            Console.WriteLine(inStockCondimentsProduct);

        Console.WriteLine();
        /*
         6. Create a new anonymous type with three properties:
           ● Name → the product name
           ● Price → the unit price
           ● StockStatus → a string: "Available" if UnitsInStock > 0,
           otherwise "Out of Stock"
           ● Print the result.
         */
        var productsWithStockStatus = products
            .Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });
        Console.WriteLine("Products with calculated Stock Status: ");
        foreach(var productWithStockStatus in productsWithStockStatus)
            Console.WriteLine(productWithStockStatus);

        Console.WriteLine();
        // 7. Print each product's name along with its position (1-based)
        // in the list. Expected format: 1. Chai, 2. Chang, etc.
        var positionedProducts = products
            .Select((p, i) => new { Name = $"{i + 1}. {p.ProductName}" });

        Console.WriteLine("Positioned Products: ");
        foreach(var positionedProduct in positionedProducts)
            Console.WriteLine(positionedProduct);

        Console.WriteLine();
        // 8. Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending.
        var sortedByCategoryProducts = products
            .OrderBy(p => p.Category)
            .ThenByDescending(p => p.UnitPrice);
        
        Console.WriteLine("Products sorted by Category, and in each Category sorted by UnitPrice: ");
        foreach (var sortedByCategoryProduct in sortedByCategoryProducts)
            Console.WriteLine(sortedByCategoryProduct);

        Console.WriteLine();
        // 9. Get all products from the "Beverages" category, sorted by
        // UnitsInStock descending. Print name and stock.
        var beveragesProducts = products
            .Where(p => p.Category == "Beverages")
            .Select(p => new { p.ProductName, p.UnitsInStock })
            .OrderByDescending(p => p.UnitsInStock);
        
        Console.WriteLine("Beverages Products Names and Stock sorted by UnitsInStock descendingly: ");
        foreach (var beverageProduct in beveragesProducts)
            Console.WriteLine(beverageProduct);

        Console.WriteLine();
        // Using QUERY SYNTAX with a compound from clause, list
        // all orders placed in 1997 or later showing CustomerID and
        // OrderDate.
        var customers = Source.CustomerList;
        var since1997Orders = from c in customers
            from o in c.Orders
            where o.OrderDate.Year >= 1997
            select new { c.CustomerID, o.OrderDate };

        Console.WriteLine("All orders placed in 1997 and later Customer ID and Order Date: ");
        foreach(var since1997Order in since1997Orders)
            Console.WriteLine(since1997Order);

        Console.WriteLine();
        // 11. Show position number alongside ProductName
        var positioningProducts = (from p in products 
            select p)
            .Select((p, i) => new { Name = $"{i + 1}. {p.ProductName}" });

        Console.WriteLine("Products Names with the corresponding Position: ");
        foreach(var positioningProduct in positioningProducts)
            Console.WriteLine(positioningProduct);

        Console.WriteLine();
        /*
         12. Sort first by-word length and then by a
           case-insensitive sort of the words in an array.
           
           String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
         */
        String [] Arr = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};
        var sortedByWordLengthArray = Arr
            .OrderBy(word => word.Length);
        
        Console.WriteLine("Arr sorted by word length: ");
        foreach(var sortedByWordLengthArrayItem in sortedByWordLengthArray)
            Console.WriteLine(sortedByWordLengthArrayItem);

        // then by a case-insensitive sort of the words in an array.
        Console.WriteLine();
        var sortedWithCaseInsensitiveSortingArray = Arr
            .OrderBy(word => word, StringComparer.OrdinalIgnoreCase);
        
        Console.WriteLine("Sorted Array With Case Insensitive Sorting: ");
        foreach(var sortedWithCaseInsensitiveSortingArrayItem in sortedWithCaseInsensitiveSortingArray)
            Console.WriteLine(sortedWithCaseInsensitiveSortingArrayItem);

        Console.WriteLine();
        // 13. Create a list of all digits in the array whose second
        // letter is 'i' that is reversed from the order in the
        // original array.
        string[] digitsNames = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        var reversedIfSecondLetterIsIList = digitsNames
            .Where(d => d[1] == 'i')
            .Reverse()
            .ToList();
        
        Console.WriteLine("Reversed array of digits whose second letter is i: ");
        foreach (var reversedIfSecondLetterIsIListItem in reversedIfSecondLetterIsIList)
            Console.WriteLine(reversedIfSecondLetterIsIListItem);
    }
}