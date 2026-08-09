namespace Assignment02;

class Program
{
    static void Main(string[] args)
    {
        var products = Source.ProductList;
        var customers = Source.CustomerList;
        
        Console.WriteLine("Top 3 most expensive products: ");
        // 1. Get top 3 most expensive products
        var top3MostExpensiveProducts = products
            .OrderByDescending(p => p.UnitPrice)
            .Take(3);
        
        foreach(var top3MostExpensiveProduct in top3MostExpensiveProducts)
            Console.WriteLine(top3MostExpensiveProduct);
        
        Console.WriteLine("\nProducts of Page 2: ");
        // 2. show page 2 of products, with page size = 5
        var page2OfProducts = products
            .Skip(10)
            .Take(5);
        
        foreach(var page2Product in page2OfProducts)
            Console.WriteLine(page2Product);
        
        Console.WriteLine("\nProducts with Price smaller than 25: ");
        // 3. Take products from the list as long as Their UnitPrice is less than $25 (list is ordered by price).
        var lessThan25PriceProducts = products
            .OrderBy(p => p.UnitPrice)
            .TakeWhile(p => p.UnitPrice < 25);
        
        foreach(var lessThan25PriceProduct in lessThan25PriceProducts)
            Console.WriteLine(lessThan25PriceProduct);

        
        // 4. Check if ALL products in the "Seafood" category are in stock
        var isAllSeafoodProductsInStock = products
            .Where(p => p.Category == "Seafood")
            .All(p => p.UnitsInStock > 0);
        
        Console.WriteLine($"\nIs All Seafood Products In Stock? {(isAllSeafoodProductsInStock ? "Yes" : "No")}");
        
        // 5. Check if the ID list contains 9 int[] ids = { 3, 9, 13, 18 };
        int[] ids = { 3, 9, 13, 18 };
        var isTheIdListContained = products
            .Count(p => ids.Contains(p.ProductID)) == ids.Length;
        
        Console.WriteLine($"\nIs The Id List contained in the Product Ids? {(isTheIdListContained ? "Yes" : "No")}");
        
        Console.WriteLine("\nCategories and Products Count for each category: ");
        // 6. Group all products by Category and print each group with its product count.
        var categoriesDetails = products
            .GroupBy(p => p.Category)
            .Select(g => new 
            {
               Category = g.Key,
               ProductCount = g.Count()
            });
        
        foreach(var categoryDetails in categoriesDetails)
            Console.WriteLine(categoryDetails);
        
        Console.WriteLine("\nCategories and Products Names for each category: ");
        // 7. Group products by Category and project only product names per group
        var groupedProductsByCategory = products
            .GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                ProductNames = g.Select(p => p.ProductName).ToList()
            });
        foreach (var groupedProductByCategory in groupedProductsByCategory)
            Console.WriteLine(groupedProductByCategory);
        
        Console.WriteLine("\nCategories that have more than 3 products: ");
        // 8. Find all categories that have MORE THAN 3 products
        var categoriesHavingMoreThan3Products = products
            .GroupBy(p => p.Category)
            .Where(g => g.Count() > 3)
            .Select(g => new
            {
                Category = g.Key,
                ProductCount = g.Count()
            });
        
        foreach (var categoriesHavingMoreThan3Product in categoriesHavingMoreThan3Products)
            Console.WriteLine(categoriesHavingMoreThan3Product);
        
        Console.WriteLine("\nCountry, Count of Customers in it, and Total Order Value: ");
        // 9. Using QUERY SYNTAX, group customers by Country, and for each
        // group select { Country, Count, TotalOrderValue }.
        var groupedByCountryCustomers = from c in customers
            group c by c.Country into g
            select new
            {
                Country = g.Key,
                Count = g.Count(),
                TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
            };
        
        foreach (var groupedByCountryCustomer in groupedByCountryCustomers)
            Console.WriteLine(groupedByCountryCustomer);
        
        // 10. Calculate the total number of units in stock across all products
        var totalNumberOfUnits = products
            .Sum(p => p.UnitsInStock);
        Console.WriteLine($"\nTotal number of units in stock across all products: {totalNumberOfUnits}");
        
        // 11. Find the CHEAPEST and MOST EXPENSIVE product prices
        var cheapestProductPrice = products
            .Min(p => p.UnitPrice);
        
        var mostExpensiveProductPrice = products
            .Max(p => p.UnitPrice);
        
        Console.WriteLine($"\nThe Cheapest Product Price: {cheapestProductPrice}, The Most Expensive Product Price: {mostExpensiveProductPrice}");
        
        Console.WriteLine($"\nDistinct list of all product categories: ");
        // 12. Get a distinct list of all product categories
        var distinctCategories = products
            .GroupBy(p => p.Category)
            .Select(g => g.Key)
            .Distinct();
        
        foreach (var distinctCategory in distinctCategories)
            Console.WriteLine(distinctCategory);


        Console.WriteLine("\nProduct IDs that are in set A but not in set B: ");
        // 13. find product IDs that are in setA but NOT in setB
        // int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
        // int[] setB = { 3, 6, 9, 12, 15, 13 }; 
        int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
        int[] setB = { 3, 6, 9, 12, 15, 13 };

        var productIdsInSetAOnly = setA.Except(setB);
        foreach (var productIdInSetAOnly in productIdsInSetAOnly)
            Console.WriteLine(productIdInSetAOnly);
        
        Console.WriteLine("\nCountries that are in list 1 but not in list 2: ");
        // Find countries that appear in list1 but NOT in list2
        // (case-insensitive).
        // string[] list1 = { "Germany", "France", "UK", "Spain" };
        // string[] list2 = { "france", "SPAIN", "Italy" };
        string[] list1 = { "Germany", "France", "UK", "Spain" };
        string[] list2 = { "france", "SPAIN", "Italy" };

        var countriesInList1Only = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
        
        foreach (var countryInList1Only in countriesInList1Only)
            Console.WriteLine(countryInList1Only);
        
        // Build a Dictionary<int, Product> keyed by ProductID. Then retrieve and print the product with ID = 18.
        Dictionary<int, Product> productsDictionary = products
            .ToDictionary(p => p.ProductID);
    
        Console.WriteLine($"\nProduct with ID = 18: {productsDictionary[18]}");
        
        // 16. Get the first product whose price is greater than $50.
        var firstProductWhosePriceGreaterThan50 = products
            .OrderBy(p => p.UnitPrice)
            .FirstOrDefault(p => p.UnitPrice > 50);
        
        Console.WriteLine($"\nFirst product whose price is greater than $50: {firstProductWhosePriceGreaterThan50}");
        
        // 17. Try to get the first product with a price > $500. it returns null instead of throwing.
        var firstProductWhosePriceGreaterThan500 = products
            .OrderBy(p => p.UnitPrice)
            .FirstOrDefault(p => p.UnitPrice > 500);
        
        Console.WriteLine($"\nFirst product whose price is greater than $500: {firstProductWhosePriceGreaterThan500}");
        
        Console.WriteLine($"\nMultiplication table row for 7");
        
        // 18. Generate a multiplication table row for 7
        var multiplicationTableRowFor7 = Enumerable.Range(1, 12)
            .Select(i => $"{i} x 7 = {i * 7}");
 
        foreach (var multiplicationTableRowFor7Element in multiplicationTableRowFor7)
            Console.WriteLine(multiplicationTableRowFor7Element);
        
        Console.WriteLine($"\nEven numbers between 1 and 30: ");
        // 19. Generate even numbers between 1 and 30.
        var evenNumbersBetween1And30 = Enumerable
            .Range(1, 30)
            .Where(n => n % 2 == 0);
        
        foreach (var evenNumberBetween1And30 in evenNumbersBetween1And30)
            Console.WriteLine(evenNumberBetween1And30);
        
        Console.WriteLine($"\nConcatenated first 3 Product Names and first 3 Customer Company Names: ");
        // 20. Concatenate the first 3 product names with the first 3 customer company names into a single
        // sequence.
        var firstThreeProductsNames = products
            .Take(3)
            .Select(p => p.ProductName);
        
        var firstThreeCustomersCompanyNames = customers
            .Take(3)
            .Select(c => c.CompanyName);

        var concatenatedProductsCustomers = firstThreeProductsNames
            .Concat(firstThreeCustomersCompanyNames);
        
        foreach (var concatenatedProductCustomer in concatenatedProductsCustomers)
            Console.WriteLine(concatenatedProductCustomer);
        
        Console.WriteLine($"\nWhich Product is sold to which Company?: ");
        // 21. Pair each product with a customer (by position) and produce
        // a string "ProductName sold to CompanyName".
        var productNames = products
            .Select(p => p.ProductName);
        
        var companyNames = customers
            .Select(c => c.CompanyName);

        var soldInformation = productNames
            .Zip(companyNames, (pName, cName) => $"{pName} sold to {cName}");
        
        foreach (var soldInformationItem in soldInformation)
            Console.WriteLine(soldInformationItem);
    }
}