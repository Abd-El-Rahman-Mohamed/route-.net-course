using System.Text;

namespace ShopMaster;

class Program
{
    static void Main(string[] args)
    {
        // 2. Product Catalog 
        List<Product> catalog = new()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
            new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
            new Product { Id = 3, Name = "T-shirt", Category = "Clothing", Price = 30, Stock = 100 },
            new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
            new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
            new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
            new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
            new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
            new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
            new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 120, Stock = 15 }
        };

        // Expected Output:
        /* Make sure your console output matches the expected output for each task.  */
        Console.WriteLine("--- Electronics ———");
        List<Product> electronics = ProductService.SearchProducts(catalog, IsElectronicCategory);
        foreach (var electronicProduct in electronics)
            Console.WriteLine($"{electronicProduct.Name} - ${electronicProduct.Price} (Stock: {electronicProduct.Stock})");

        Console.WriteLine();
        
        Console.WriteLine("--- Under $50 ---");
        List<Product> under50Products = ProductService.SearchProducts(catalog, IsCheaperThan50);
        foreach (var under50Product in under50Products)
            Console.WriteLine($"{under50Product.Name} - ${under50Product.Price} (Stock: {under50Product.Stock})");
        
        Console.WriteLine();
        
        Console.WriteLine("--- In Stock ---");
        List<Product> inStockProducts = ProductService.SearchProducts(catalog, IsInStock);
        foreach (var inStockProduct in inStockProducts)
            Console.WriteLine($"{inStockProduct.Name} - ${inStockProduct.Price} (Stock: {inStockProduct.Stock})");
        
        Console.WriteLine();
        
        Console.WriteLine("--- Clothing Under $100 ---");
        List<Product> clothingUnder100Products = ProductService.SearchProducts(catalog, IsClothingAndPriceLessThan100);
        foreach (var clothingUnder100Product in clothingUnder100Products)
            Console.WriteLine($"{clothingUnder100Product.Name} - ${clothingUnder100Product.Price} (Stock: {clothingUnder100Product.Stock})");

        Console.WriteLine();
        
        // Scenario 1  Short Report: Print each product as Name - $Price 
        Console.WriteLine("--- Short Report ---");
        ProductService.PrintReport(catalog, (product) => {
                Console.WriteLine($"{product.Name} - ${product.Price}");
        });

        Console.WriteLine();
        
        // Scenario 2  Detailed Report: Print each product as [Category] Name | Price: $X | Stock: Y
        Console.WriteLine("--- Detailed Report ---");
        ProductService.PrintReport(catalog, (product) => {
                Console.WriteLine($" [{product.Category}] {product.Name} | Price: ${product.Price} | Stock {product.Stock}");
        });
        
        Console.WriteLine();
        
        // Scenario 3 Summary List: Transform each product into a string like "Laptop ($1200)". Print all results.
        Console.WriteLine("--- Summary List ---");
        List<string> summarizedProducts = ProductService.TransformProducts(catalog, SummarizeProduct);
        foreach(var summarizedProduct in summarizedProducts)
            Console.WriteLine(summarizedProduct);

        Console.WriteLine();
        
        // Scenario 4 Price Label: Transform each product into "Expensive!" if Price > $100, or "Affordable"
        //  otherwise. Print each as Name: Label.
        Console.WriteLine("--- Price Labels ---");
        List<string> priceLabelsProducts = ProductService.TransformProducts(catalog, PriceLabel);
        foreach (var priceLabelsProduct in priceLabelsProducts)
            Console.WriteLine(priceLabelsProduct);

        Console.WriteLine();

        Console.WriteLine("Low-Stock Alert");
        List<Product> lowStockProducts = ProductService.FilterProducts(catalog, FilterLowStock);
        foreach (var lowStockProduct in lowStockProducts)
            Console.WriteLine($"[LOW STOCK] {lowStockProduct.Name}: only {lowStockProduct.Stock} left!");
    }
    

    /*
     Then, call this method four times with different lambda expressions to perform the following searches: 
        1. All Electronics products 
        2. Products cheaper than $50 
        3. Products that are in stock (Stock > 0) 
        4. Clothing products under $100
     */
    static bool IsElectronicCategory(Product product) => product.Category == "Electronics";
    static bool IsCheaperThan50(Product product) => product.Price < 50;
    static bool IsInStock(Product product) => product.Stock > 0;
    static bool IsClothingAndPriceLessThan100(Product product) => product is { Category: "Clothing", Price: < 100 };
    
    // Scenario 3 Summary List: Transform each product into a string like "Laptop ($1200)". Print all results. 
    static string SummarizeProduct(Product product) => $"{product.Name} (${product.Price})";
    // Scenario 4 Price Label: Transform each product into "Expensive!" if Price > $100, or "Affordable"
    //  otherwise. Print each as Name: Label.
    static string PriceLabel(Product product) => $"{product.Name}: {(product.Price > 100 ? "Expensive!" : "Affordable")}";

    /*
     Scenario 5  Low-Stock Alert: Find products with Stock < 20 and print an alert for each in the format-: 
     [LOW STOCK] Name: only X left!
     */
    static bool FilterLowStock(Product product) => product.Stock < 20;
}